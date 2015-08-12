//    #[license]
//    SmartsheetClient SDK for C#
//    %%
//    Copyright (C) 2014 SmartsheetClient
//    %%
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//        
//            http://www.apache.org/licenses/LICENSE-2.0
//        
//    Unless required by applicable law or agreed To in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//    %[license]

using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// 
/// </summary>
namespace Smartsheet.Api.Internal.OAuth
{

	using HttpClient = Api.Internal.Http.HttpClient;
	using HttpClientException = Api.Internal.Http.HttpClientException;
	using HttpMethod = Api.Internal.Http.HttpMethod;
	using HttpRequest = Api.Internal.Http.HttpRequest;
	using HttpResponse = Api.Internal.Http.HttpResponse;
	using JSONSerializationException = Api.Internal.Json.JsonSerializationException;
	using JsonSerializer = Api.Internal.Json.JsonSerializer;
	using Util = Api.Internal.Utility.Utility;
	using AccessDeniedException = Api.OAuth.AccessDeniedException;
	using AccessScope = Api.OAuth.AccessScope;
	using AuthorizationResult = Api.OAuth.AuthorizationResult;
	using InvalidOAuthClientException = Api.OAuth.InvalidOAuthClientException;
	using InvalidOAuthGrantException = Api.OAuth.InvalidOAuthGrantException;
	using InvalidScopeException = Api.OAuth.InvalidScopeException;
	using InvalidTokenRequestException = Api.OAuth.InvalidTokenRequestException;
	using OAuthAuthorizationCodeException = Api.OAuth.OAuthAuthorizationCodeException;
	using OAuthFlow = Api.OAuth.OAuthFlow;
	using OAuthTokenException = Api.OAuth.OAuthTokenException;
	using Token = Api.OAuth.Token;
	using UnsupportedOAuthGrantTypeException = Api.OAuth.UnsupportedOAuthGrantTypeException;
	using UnsupportedResponseTypeException = Api.OAuth.UnsupportedResponseTypeException;
	using System.Security.Cryptography;
	using System.IO;
	using System.Net;

	/// <summary>
	/// Default implementation of OAuthFlow.
	/// 
	/// Thread Safety: Implementation of this interface must be thread safe.
	/// </summary>
	public class OAuthFlowImpl : OAuthFlow
	{
		/// <summary>
		/// Represents the HttpClient.
		/// 
		/// It will be initialized in constructor and will not change afterwards.
		/// </summary>
		private HttpClient httpClient;

		/// <summary>
		/// Represents the JsonSerializer.
		/// 
		/// It will be initialized in constructor and will not change afterwards.
		/// </summary>
		private JsonSerializer jsonSerializer;

		/// <summary>
		/// Represents the Client ID.
		/// 
		/// It will be initialized in constructor and will not change afterwards.
		/// </summary>
		private string clientId;

		/// <summary>
		/// Represents the Client Secret.
		/// 
		/// It will be initialized in constructor and will not change afterwards.
		/// </summary>
		private string clientSecret;

		/// <summary>
		/// Represents the redirect URL.
		/// 
		/// It will be initialized in constructor and will not change afterwards.
		/// </summary>
		private string redirectURL;

		/// <summary>
		/// Represents the authorization URL.
		/// 
		/// It will be initialized in constructor and will not change afterwards.
		/// </summary>
		private string authorizationURL;

		/// <summary>
		/// Represents the token URL.
		/// 
		/// It will be initialized in constructor and will not change afterwards.
		/// </summary>
		private string tokenURL;

		/// <summary>
		/// Constructor.
		/// 
		/// Exceptions: - 
		/// </summary>
		/// <param name="clientId"> the client Id </param>
		/// <param name="clientSecret"> the client secret </param>
		/// <param name="redirectURL"> the redirect Url </param>
		/// <param name="authorizationURL"> the authorization Url </param>
		/// <param name="tokenURL"> the token Url </param>
		/// <param name="httpClient"> the http client </param>
		/// <param name="jsonSerializer"> the Json serializer </param>
		/// <exception cref="System.InvalidOperationException"> If any argument is null, or empty string. </exception>
		public OAuthFlowImpl(string clientId, string clientSecret, string redirectURL, string authorizationURL,
				string tokenURL, HttpClient httpClient, JsonSerializer jsonSerializer)
		{
			Util.ThrowIfNull(clientId, clientSecret, redirectURL, authorizationURL, tokenURL, httpClient, jsonSerializer);
			Util.ThrowIfEmpty(clientId, clientSecret, redirectURL, authorizationURL, tokenURL);

			this.clientId = clientId;
			this.clientSecret = clientSecret;
			this.redirectURL = redirectURL;
			this.authorizationURL = authorizationURL;
			this.tokenURL = tokenURL;
			this.httpClient = httpClient;
			this.jsonSerializer = jsonSerializer;
		}

		/// <summary>
		/// Generate a new authorization URL. 
		/// 
		/// Exceptions: - IllegalArgumentException : if scopes is null/empty
		/// </summary>
		/// <param name="scopes"> the scopes </param>
		/// <param name="state"> an arbitrary string that will be returned To your app; intended To be used by you To ensure that 
		/// this redirect is indeed from an OAuth flow that you initiated </param>
		/// <returns> the authorization URL </returns>
		public virtual string NewAuthorizationURL(IEnumerable<AccessScope> scopes, string state)
		{
			Util.ThrowIfNull(scopes);
			if (state == null)
			{
				state = "";
			}

			// Build a map of parameters for the URL
			Dictionary<string, string> @params = new Dictionary<string, string>();
			@params["response_type"] = "code";
			@params["client_id"] = clientId;
			@params["redirect_uri"] = redirectURL;
			@params["state"] = state;

			StringBuilder scopeBuffer = new StringBuilder();
			foreach (AccessScope scope in scopes)
			{
				scopeBuffer.Append(scope.ToString() + " ");
			}
			@params["scope"] = scopeBuffer.ToString().Substring(0, scopeBuffer.Length - 1);

			// Generate the URL with the parameters
			return GenerateURL(authorizationURL, @params);
		}

		/// <summary>
		/// Extract AuthorizationResult from the authorization response URL (i.e. the RedirectURL with the response
		/// parameters from Smartsheet OAuth server).
		/// 
		/// Exceptions: 
		///   - IllegalArgumentException : if authorizationResponseURL is null/empty, or a malformed URL 
		///   - AccessDeniedException : if the user has denied the authorization request 
		///   - UnsupportedResponseTypeException : if the response Type isn't supported (note that this won't really happen in current implementation) 
		///   - InvalidScopeException : if some of the specified scopes are invalid 
		///   - OAuthAuthorizationCodeException : if any other error occurred during the operation
		/// </summary>
		/// <param name="authorizationResponseURL"> the authorization response URL </param>
		/// <returns> the authorization RequestResult </returns>
		/// <exception cref="UriFormatException "> the URI syntax exception </exception>
		/// <exception cref="OAuthAuthorizationCodeException"> the o auth authorization Code exception </exception>
		public virtual AuthorizationResult ExtractAuthorizationResult(string authorizationResponseURL)
		{
			Util.ThrowIfNull(authorizationResponseURL);
			Util.ThrowIfEmpty(authorizationResponseURL);


			// Get all of the parms from the URL
			Uri uri = new Uri(authorizationResponseURL);
			string query = uri.Query;
			if (String.IsNullOrEmpty(query))
			{
				throw new OAuthAuthorizationCodeException("There must be a query string in the response URL");
			}

			IDictionary<string, string> map = new Dictionary<string, string>();
			string[] @params = query.TrimStart('?').Split(new Char[] { '&' });
			for (int i = 0; i < @params.Length; i++)
			{
				int index = @params[i].IndexOf('=');
				map[@params[i].Substring(0, index)] = @params[i].Substring(index + 1);
			}

			// Check for an error response in the URL and throw it.
			if (map.ContainsKey("error") && map["error"].Length > 0)
			{
				string error = map["error"];
				if ("access_denied".Equals(error))
				{
					throw new AccessDeniedException("Access denied.");
				}
				else if ("unsupported_response_type".Equals(error))
				{
					throw new UnsupportedResponseTypeException("response_type must be set to \"code\".");
				}
				else if ("invalid_scope".Equals(error))
				{
					throw new InvalidScopeException("One or more of the requested access scopes are invalid. " + "Please check the list of access scopes");
				}
				else
				{
					throw new OAuthAuthorizationCodeException("An undefined error was returned of type: " + error);
				}
			}


			AuthorizationResult authorizationResult = new AuthorizationResult();


			if (map.ContainsKey("code"))
			{
				authorizationResult.Code = map["code"];
			}

			if (map.ContainsKey("state"))
			{
				authorizationResult.State = map["state"];
			}

			long? expiresIn = 0L;
			try
			{
				expiresIn = Convert.ToInt64(map["expires_in"]);
			}
			catch (Exception)
			{
				expiresIn = 0L;
			}
			authorizationResult.ExpiresInSeconds = expiresIn;

			return authorizationResult;
		}

		/// <summary>
		/// Obtain a new token using AuthorizationResult.
		/// 
		/// Exceptions: 
		///   - IllegalArgumentException : if authorizationResult is null 
		///   - InvalidTokenRequestException : if the token request is invalid (note that this won't really happen in current implementation) 
		///   - InvalidOAuthClientException : if the client information is invalid 
		///   - InvalidOAuthGrantException : if the authorization Code or refresh token is invalid or expired, the 
		///   redirect_uri does not match, or the hash Value does not match the client secret and/or Code 
		///   - UnsupportedOAuthGrantTypeException : if the grant Type is invalid (note that this won't really happen in 
		///   current implementation) 
		///   - OAuthTokenException : if any other error occurred during the operation
		/// </summary>
		/// <param name="authorizationResult"> the authorization RequestResult </param>
		/// <returns> the token </returns>
		/// <exception cref="OAuthTokenException"> the o auth token exception </exception>
		/// <exception cref="JSONSerializationException"> the JSON serializer exception </exception>
		/// <exception cref="System.UriFormatException"> the URI syntax exception </exception>
		/// <exception cref="InvalidRequestException"> the invalid request exception </exception>
		public virtual Token ObtainNewToken(AuthorizationResult authorizationResult)
		{
			if (authorizationResult == null)
			{
				throw new System.ArgumentException();
			}

			// create a Map of the parameters
			Dictionary<string, string> @params = new Dictionary<string, string>();
			@params["grant_type"] = "authorization_code";
			@params["client_id"] = clientId;
			@params["code"] = authorizationResult.Code;
			@params["redirect_uri"] = redirectURL;
			@params["hash"] = getHash(authorizationResult.Code);

			// Generate the URL and then get the token
			return RequestToken(GenerateURL(tokenURL, @params));
		}

		/// <summary>
		/// Refresh token.
		/// 
		/// Exceptions: 
		///   - IllegalArgumentException : if token is null. 
		///   - InvalidTokenRequestException : if the token request is invalid 
		///   - InvalidOAuthClientException : if the client information is invalid 
		///   - InvalidOAuthGrantException : if the authorization Code or refresh token is invalid or expired, 
		///   the redirect_uri does not match, or the hash Value does not match the client secret and/or Code 
		///   - UnsupportedOAuthGrantTypeException : if the grant Type is invalid
		///   - OAuthTokenException : if any other error occurred during the operation
		/// </summary>
		/// <param name="token"> the token To refresh </param>
		/// <returns> the refreshed token </returns>
		/// <exception cref="OAuthTokenException"> the o auth token exception </exception>
		/// <exception cref="JSONSerializationException"> the JSON serializer exception </exception>
		/// <exception cref="System.UriFormatException"> the URI syntax exception </exception>
		/// <exception cref="InvalidRequestException"> the invalid request exception </exception>
		public virtual Token RefreshToken(Token token)
		{
			// Create a map of the parameters
			IDictionary<string, string> @params = new Dictionary<string, string>();
			@params["grant_type"] = "refresh_token";
			@params["client_id"] = clientId;
			@params["refresh_token"] = token.RefreshToken;
			@params["redirect_uri"] = redirectURL;
			@params["hash"] = getHash(token.RefreshToken);

			// Generate the URL and get the token
			return RequestToken(GenerateURL(tokenURL, @params));
		}

		/// <summary>
		/// Request a token.
		/// 
		/// Exceptions: 
		///   - IllegalArgumentException : if Url is null or empty 
		///   - InvalidTokenRequestException : if the token request is invalid 
		///   - InvalidOAuthClientException : if the client information is invalid 
		///   - InvalidOAuthGrantException : if the authorization Code or refresh token is invalid or 
		///   expired, the redirect_uri does not match, or the hash Value does not match the client secret and/or Code 
		///   - UnsupportedOAuthGrantTypeException : if the grant Type is invalid 
		///   - OAuthTokenException : if any other error occurred during the operation
		/// </summary>
		/// <param name="url"> the URL (with request parameters) from which the token will be requested </param>
		/// <returns> the token </returns>
		/// <exception cref="OAuthTokenException"> the o auth token exception </exception>
		/// <exception cref="JSONSerializationException"> the JSON serializer exception </exception>
		/// <exception cref="System.UriFormatException"> the URI syntax exception </exception>
		/// <exception cref="InvalidRequestException"> the invalid request exception </exception>
		private Token RequestToken(string url)
		{

			// Create the request and send it To get the response/token.
			HttpRequest request = new HttpRequest();
			request.Uri = new Uri(url);
			request.Method = HttpMethod.POST;
			request.Headers = new Dictionary<string, string>();
			request.Headers["Content-Type"] = "application/x-www-form-urlencoded";
			HttpResponse response = httpClient.Request(request);

			// Create a map of the response
			StreamReader inputStream = response.Entity.GetContent();
			IDictionary<string, object> map = jsonSerializer.DeserializeMap(inputStream);
			httpClient.ReleaseConnection();

			// Check for a error response and throw it.
			if (response.StatusCode != HttpStatusCode.OK && map.ContainsKey("error") && map["error"] != null)
			{
				string errorType = map["error"].ToString();
				string errorDescription = map["message"] == null ? "" : (string)map["message"];
				if ("invalid_request".Equals(errorType))
				{
					throw new InvalidTokenRequestException(errorDescription);
				}
				else if ("invalid_client".Equals(errorType))
				{
					throw new InvalidOAuthClientException(errorDescription);
				}
				else if ("invalid_grant".Equals(errorType))
				{
					throw new InvalidOAuthGrantException(errorDescription);
				}
				else if ("unsupported_grant_type".Equals(errorType))
				{
					throw new UnsupportedOAuthGrantTypeException(errorDescription);
				}
				else
				{
					throw new OAuthTokenException(errorDescription);
				}
			}

			// Another error by not getting a 200 RequestResult
			else if (response.StatusCode != HttpStatusCode.OK)
			{
				throw new OAuthTokenException("Token request failed with http error code: " + response.StatusCode);
			}

			// Create a token based on the response
			Token token = new Token();
			object tempObj = map["access_token"];
			token.AccessToken = tempObj == null ? "" : (string)tempObj;
			tempObj = map["token_type"];
			token.TokenType = tempObj == null ? "" : (string)tempObj;
			tempObj = map["refresh_token"];
			token.RefreshToken = tempObj == null ? "" : (string)tempObj;

			long? expiresIn = 0L;
			try
			{
				expiresIn = Convert.ToInt64(Convert.ToString(map["expires_in"]));
			}
			catch (Exception)
			{
				expiresIn = 0L;
			}
			token.ExpiresInSeconds = expiresIn;

			return token;
		}

		/// <summary>
		/// Revoke token.
		/// </summary>
		/// <param name="token"> the  token </param>
		/// <exception cref="OAuthTokenException"> the o auth token exception </exception>
		/// <exception cref="JSONSerializationException"> the JSON serializer exception </exception>
		/// <exception cref="System.UriFormatException"> the URI syntax exception </exception>
		/// <exception cref="InvalidRequestException"> the invalid request exception </exception>
		/// <exception cref="System.InvalidOperationException"> if any other error occurred during the operation </exception>
		public virtual void RevokeToken(Token token)
		{
			// Create the request and send it To get the response/token.
			HttpRequest request = new HttpRequest();
			request.Uri = new Uri(tokenURL);
			request.Method = HttpMethod.DELETE;
			// Set authorization header 
			request.Headers["Authorization"] = "Bearer " + token.AccessToken;
			HttpResponse response = httpClient.Request(request);
			// Another error by not getting a 200 RequestResult
			if (response.StatusCode != HttpStatusCode.OK)
			{
				throw new OAuthTokenException("Token request failed with http error code: " + response.StatusCode);
			}
			httpClient.ReleaseConnection();
		}

		/// <summary>
		/// Helper function To generate a URL using the base URL and the given parameters. It will encode each of the 
		/// parameters as well.
		/// </summary>
		/// <param name="baseURL"> The base URL that the parameters will be appended To. </param>
		/// <param name="parameters"> The parameters that will be appended To the base URL. Each parameter will be URL encoded. </param>
		/// <returns> A string representing the full URL. </returns>
		protected internal virtual string GenerateURL(string baseURL, IDictionary<string, string> parameters)
		{
			// Supports handling a relative URL
			if (baseURL == null)
			{
				baseURL = "";
			}

			// Add a question mark To the URL if there isn't one already.
			if (!baseURL.Contains("?"))
			{
				baseURL += "?";
			}

			// Test To see if a & should be the next character in the URL
			bool needsAmpersand = true;
			if (baseURL.EndsWith("?") || baseURL.EndsWith("&"))
			{
				needsAmpersand = false;
			}

			// Add the parameters To the URL
			StringBuilder sb = new StringBuilder(baseURL);
			if (parameters != null)
			{
				foreach (KeyValuePair<string, string> param in parameters)
				{
					// Don't add a & after a ?
					if (needsAmpersand)
					{
						sb.Append("&");
					}
					needsAmpersand = true; // this only matters for the first &;

					sb.Append(Uri.EscapeDataString(param.Key));
					sb.Append("=");

					string key = param.Value;
					if (key != null)
					{
						sb.Append(Uri.EscapeDataString(param.Value));
					}
				}
			}

			return sb.ToString();
		}

		/// <summary>
		/// Gets the http client.
		/// </summary>
		/// <returns> the http client </returns>
		public virtual HttpClient HttpClient
		{
			get
			{
				return httpClient;
			}
			set
			{
				this.httpClient = value;
			}
		}


		/// <summary>
		/// Gets the Json serializer.
		/// </summary>
		/// <returns> the Json serializer </returns>
		public virtual JsonSerializer JsonSerializer
		{
			get
			{
				return jsonSerializer;
			}
			set
			{
				this.jsonSerializer = value;
			}
		}


		/// <summary>
		/// Gets the client Id.
		/// </summary>
		/// <returns> the client Id </returns>
		public virtual string ClientId
		{
			get
			{
				return clientId;
			}
			set
			{
				this.clientId = value;
			}
		}


		/// <summary>
		/// Gets the client secret.
		/// </summary>
		/// <returns> the client secret </returns>
		public virtual string ClientSecret
		{
			get
			{
				return clientSecret;
			}
			set
			{
				this.clientSecret = value;
			}
		}


		/// <summary>
		/// Gets the redirect Url.
		/// </summary>
		/// <returns> the redirect Url </returns>
		public virtual string RedirectURL
		{
			get
			{
				return redirectURL;
			}
			set
			{
				this.redirectURL = value;
			}
		}


		/// <summary>
		/// Gets the authorization Url.
		/// </summary>
		/// <returns> the authorization Url </returns>
		public virtual string AuthorizationURL
		{
			get
			{
				return authorizationURL;
			}
			set
			{
				this.authorizationURL = value;
			}
		}


		/// <summary>
		/// Gets the token Url.
		/// </summary>
		/// <returns> the token Url </returns>
		public virtual string TokenURL
		{
			get
			{
				return tokenURL;
			}
			set
			{
				this.tokenURL = value;
			}
		}

		private string getHash(string str)
		{
			string doHash = string.Concat(this.clientSecret, "|", str);
			SHA256 sha = new SHA256Managed();
			byte[] hash = sha.ComputeHash(Encoding.UTF8.GetBytes(doHash));
			string hashStr = "";
			for (int i = 0; i < (int)hash.Length; i++)
			{
				hashStr = string.Concat(hashStr, string.Format("{0:x2}", hash[i]));
			}

			return hashStr;
		}

	}

}