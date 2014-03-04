using System;
using System.Collections.Generic;
using System.Text;

namespace com.smartsheet.api.@internal.oauth
{
	/*
	 * #[license]
	 * Smartsheet SDK for C#
	 * %%
	 * Copyright (C) 2014 Smartsheet
	 * %%
	 * Licensed under the Apache License, Version 2.0 (the "License");
	 * you may not use this file except in compliance with the License.
	 * You may obtain a copy of the License at
	 * 
	 *      http://www.apache.org/licenses/LICENSE-2.0
	 * 
	 * Unless required by applicable law or agreed to in writing, software
	 * distributed under the License is distributed on an "AS IS" BASIS,
	 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
	 * See the License for the specific language governing permissions and
	 * limitations under the License.
	 * %[license]
	 */

	using HttpClient = com.smartsheet.api.@internal.http.HttpClient;
	using HttpClientException = com.smartsheet.api.@internal.http.HttpClientException;
	using HttpMethod = com.smartsheet.api.@internal.http.HttpMethod;
	using HttpRequest = com.smartsheet.api.@internal.http.HttpRequest;
	using HttpResponse = com.smartsheet.api.@internal.http.HttpResponse;
	using JSONSerializationException = com.smartsheet.api.@internal.json.JSONSerializationException;
	using JsonSerializer = com.smartsheet.api.@internal.json.JsonSerializer;
	using Util = com.smartsheet.api.@internal.util.Util;
	using AccessDeniedException = com.smartsheet.api.oauth.AccessDeniedException;
	using AccessScope = com.smartsheet.api.oauth.AccessScope;
	using AuthorizationResult = com.smartsheet.api.oauth.AuthorizationResult;
	using InvalidOAuthClientException = com.smartsheet.api.oauth.InvalidOAuthClientException;
	using InvalidOAuthGrantException = com.smartsheet.api.oauth.InvalidOAuthGrantException;
	using InvalidScopeException = com.smartsheet.api.oauth.InvalidScopeException;
	using InvalidTokenRequestException = com.smartsheet.api.oauth.InvalidTokenRequestException;
	using OAuthAuthorizationCodeException = com.smartsheet.api.oauth.OAuthAuthorizationCodeException;
	using OAuthFlow = com.smartsheet.api.oauth.OAuthFlow;
	using OAuthTokenException = com.smartsheet.api.oauth.OAuthTokenException;
	using Token = com.smartsheet.api.oauth.Token;
	using UnsupportedOAuthGrantTypeException = com.smartsheet.api.oauth.UnsupportedOAuthGrantTypeException;
	using UnsupportedResponseTypeException = com.smartsheet.api.oauth.UnsupportedResponseTypeException;
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
		private HttpClient httpClient_Renamed;

		/// <summary>
		/// Represents the JsonSerializer.
		/// 
		/// It will be initialized in constructor and will not change afterwards.
		/// </summary>
		private JsonSerializer jsonSerializer_Renamed;

		/// <summary>
		/// Represents the Client ID.
		/// 
		/// It will be initialized in constructor and will not change afterwards.
		/// </summary>
		private string clientId_Renamed;

		/// <summary>
		/// Represents the Client Secret.
		/// 
		/// It will be initialized in constructor and will not change afterwards.
		/// </summary>
		private string clientSecret_Renamed;

		/// <summary>
		/// Represents the redirect URL.
		/// 
		/// It will be initialized in constructor and will not change afterwards.
		/// </summary>
		private string redirectURL_Renamed;

		/// <summary>
		/// Represents the authorization URL.
		/// 
		/// It will be initialized in constructor and will not change afterwards.
		/// </summary>
		private string authorizationURL_Renamed;

		/// <summary>
		/// Represents the token URL.
		/// 
		/// It will be initialized in constructor and will not change afterwards.
		/// </summary>
		private string tokenURL_Renamed;

		/// <summary>
		/// Constructor.
		/// 
		/// Exceptions: - 
		/// </summary>
		/// <param name="clientId"> the client id </param>
		/// <param name="clientSecret"> the client secret </param>
		/// <param name="redirectURL"> the redirect url </param>
		/// <param name="authorizationURL"> the authorization url </param>
		/// <param name="tokenURL"> the token url </param>
		/// <param name="httpClient"> the http client </param>
		/// <param name="jsonSerializer"> the json serializer </param>
		/// <exception cref="InvalidOperationException"> If any argument is null, or empty string. </exception>
		public OAuthFlowImpl(string clientId, string clientSecret, string redirectURL, string authorizationURL, 
            string tokenURL, HttpClient httpClient, JsonSerializer jsonSerializer)
		{
			Util.ThrowIfNull(clientId, clientSecret, redirectURL, authorizationURL, tokenURL, httpClient, jsonSerializer);
			Util.ThrowIfEmpty(clientId, clientSecret, redirectURL, authorizationURL, tokenURL);

			this.clientId_Renamed = clientId;
			this.clientSecret_Renamed = clientSecret;
			this.redirectURL_Renamed = redirectURL;
			this.authorizationURL_Renamed = authorizationURL;
			this.tokenURL_Renamed = tokenURL;
			this.httpClient_Renamed = httpClient;
			this.jsonSerializer_Renamed = jsonSerializer;
		}

		/// <summary>
		/// Generate a new authorization URL. 
		/// 
		/// Exceptions: - IllegalArgumentException : if scopes is null/empty
		/// </summary>
		/// <param name="scopes"> the scopes </param>
		/// <param name="state"> an arbitrary string that will be returned to your app; intended to be used by you to ensure that 
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
			@params["client_id"] = clientId_Renamed;
			@params["redirect_uri"] = redirectURL_Renamed;
			@params["state"] = state;

			StringBuilder scopeBuffer = new StringBuilder();
			foreach (AccessScope scope in scopes)
			{
                scopeBuffer.Append(scope.ToString() + ",");
			}
            @params["scope"] = scopeBuffer.ToString().Substring(scopeBuffer.Length - 1);

			// Generate the URL with the parameters
			return GenerateURL(authorizationURL_Renamed, @params);
		}

		/// <summary>
		/// Extract AuthorizationResult from the authorization response URL (i.e. the redirectURL with the response
		/// parameters from Smartsheet OAuth server).
		/// 
		/// Exceptions: 
		///   - IllegalArgumentException : if authorizationResponseURL is null/empty, or a malformed URL 
		///   - AccessDeniedException : if the user has denied the authorization request 
		///   - UnsupportedResponseTypeException : if the response type isn't supported (note that this won't really happen in current implementation) 
		///   - InvalidScopeException : if some of the specified scopes are invalid 
		///   - OAuthAuthorizationCodeException : if any other error occurred during the operation
		/// </summary>
		/// <param name="authorizationResponseURL"> the authorization response URL </param>
		/// <returns> the authorization result </returns>
		/// <exception cref="UriFormatException "> the URI syntax exception </exception>
		/// <exception cref="OAuthAuthorizationCodeException"> the o auth authorization code exception </exception>
		public virtual AuthorizationResult ExtractAuthorizationResult(string authorizationResponseURL)
		{
			Util.ThrowIfNull(authorizationResponseURL);
			Util.ThrowIfEmpty(authorizationResponseURL);


			// Get all of the parms from the URL
			Uri uri = new Uri(authorizationResponseURL);
			string query = uri.Query;
			if (query == null)
			{
				throw new OAuthAuthorizationCodeException("There must be a query string in the response URL");
			}

			IDictionary<string, string> map = new Dictionary<string, string>();
            string[] @params = query.Split(new Char[]{'&'});
            for (int i = 0; i < @params.Length; i++)
            {
                int index = @params[i].IndexOf('=');
                map[@params[i].Substring(0, index)] = @params[i].Substring(index + 1);
            }

			// Check for an error response in the URL and throw it.
			string error = map["error"];
			if (error != null && error.Length > 0)
			{
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
			authorizationResult.code = map["code"];
			authorizationResult.state = map["state"];
			long? expiresIn = 0L;
			try
			{
				expiresIn = Convert.ToInt64(map["expires_in"]);
			}
			catch (Exception)
			{
				expiresIn = 0L;
			}
			authorizationResult.expiresInSeconds = expiresIn;

			return authorizationResult;
		}

		/// <summary>
		/// Obtain a new token using AuthorizationResult.
		/// 
		/// Exceptions: 
		///   - IllegalArgumentException : if authorizationResult is null 
		///   - InvalidTokenRequestException : if the token request is invalid (note that this won't really happen in current implementation) 
		///   - InvalidOAuthClientException : if the client information is invalid 
		///   - InvalidOAuthGrantException : if the authorization code or refresh token is invalid or expired, the 
		///   redirect_uri does not match, or the hash value does not match the client secret and/or code 
		///   - UnsupportedOAuthGrantTypeException : if the grant type is invalid (note that this won't really happen in 
		///   current implementation) 
		///   - OAuthTokenException : if any other error occurred during the operation
		/// </summary>
		/// <param name="authorizationResult"> the authorization result </param>
		/// <returns> the token </returns>
		/// <exception cref="OAuthTokenException"> the o auth token exception </exception>
		/// <exception cref="JSONSerializationException"> the JSON serializer exception </exception>
		/// <exception cref="UriFormatException"> the URI syntax exception </exception>
		/// <exception cref="InvalidRequestException"> the invalid request exception </exception>
		public virtual Token ObtainNewToken(AuthorizationResult authorizationResult)
		{
			if (authorizationResult == null)
			{
				throw new System.ArgumentException();
			}

			 // Prepare the hash 
			string doHash = clientSecret_Renamed + "|" + authorizationResult.code;
            byte[] bytes = Encoding.UTF8.GetBytes(doHash);
            SHA256Managed sha = new SHA256Managed();
            byte[] hash = sha.ComputeHash(bytes);
            
			// create a Map of the parameters
			Dictionary<string, string> @params = new Dictionary<string, string>();
			@params["grant_type"] = "authorization_code";
			@params["client_id"] = clientId_Renamed;
			@params["code"] = authorizationResult.code;
			@params["redirect_uri"] = redirectURL_Renamed;
            @params["hash"] = getHash(authorizationResult.code);

			// Generate the URL and then get the token
			return RequestToken(GenerateURL(tokenURL_Renamed, @params));
		}

		/// <summary>
		/// Refresh token.
		/// 
		/// Exceptions: 
		///   - IllegalArgumentException : if token is null. 
		///   - InvalidTokenRequestException : if the token request is invalid 
		///   - InvalidOAuthClientException : if the client information is invalid 
		///   - InvalidOAuthGrantException : if the authorization code or refresh token is invalid or expired, 
		///   the redirect_uri does not match, or the hash value does not match the client secret and/or code 
		///   - UnsupportedOAuthGrantTypeException : if the grant type is invalid
		///   - OAuthTokenException : if any other error occurred during the operation
		/// </summary>
		/// <param name="token"> the token to refresh </param>
		/// <returns> the refreshed token </returns>
		/// <exception cref="OAuthTokenException"> the o auth token exception </exception>
		/// <exception cref="JSONSerializationException"> the JSON serializer exception </exception>
		/// <exception cref="UriFormatException"> the URI syntax exception </exception>
		/// <exception cref="InvalidRequestException"> the invalid request exception </exception>
		public virtual Token RefreshToken(Token token)
		{
			// Create a map of the parameters
			IDictionary<string, string> @params = new Dictionary<string, string>();
			@params["grant_type"] = "refresh_token";
			@params["client_id"] = clientId_Renamed;
			@params["refresh_token"] = token.refreshToken;
            @params["redirect_uri"] = Uri.EscapeDataString(redirectURL_Renamed);
			@params["hash"] = getHash(token.refreshToken);

			// Generate the URL and get the token
			return RequestToken(GenerateURL(tokenURL_Renamed, @params));
		}

		/// <summary>
		/// Request a token.
		/// 
		/// Exceptions: 
		///   - IllegalArgumentException : if url is null or empty 
		///   - InvalidTokenRequestException : if the token request is invalid 
		///   - InvalidOAuthClientException : if the client information is invalid 
		///   - InvalidOAuthGrantException : if the authorization code or refresh token is invalid or 
		///   expired, the redirect_uri does not match, or the hash value does not match the client secret and/or code 
		///   - UnsupportedOAuthGrantTypeException : if the grant type is invalid 
		///   - OAuthTokenException : if any other error occurred during the operation
		/// </summary>
		/// <param name="url"> the URL (with request parameters) from which the token will be requested </param>
		/// <returns> the token </returns>
		/// <exception cref="OAuthTokenException"> the o auth token exception </exception>
		/// <exception cref="JSONSerializationException"> the JSON serializer exception </exception>
		/// <exception cref="UriFormatException"> the URI syntax exception </exception>
		/// <exception cref="InvalidRequestException"> the invalid request exception </exception>
		private Token RequestToken(string url)
		{

			// Create the request and send it to get the response/token.
			HttpRequest request = new HttpRequest();
			request.Uri = new Uri(url);
			request.Method = HttpMethod.POST;
			request.headers = new Dictionary<string, string>();
			request.headers["Content-Type"] = "application/x-www-form-urlencoded";
			HttpResponse response = httpClient_Renamed.Request(request);

			// Create a map of the response
			StreamReader inputStream = response.entity.getContent();
			IDictionary<string, object> map = jsonSerializer_Renamed.DeserializeMap(inputStream);
			httpClient_Renamed.ReleaseConnection();

			// Check for a error response and throw it.
			if (response.StatusCode != HttpStatusCode.OK && map["error"] != null)
			{
				string errorType = map["error"].ToString();
				string errorDescription = map["message"] == null?"":(string)map["message"];
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

			// Another error by not getting a 200 result
			else if (response.StatusCode != HttpStatusCode.OK)
			{
				throw new OAuthTokenException("Token request failed with http error code: " + response.StatusCode);
			}

			// Create a token based on the response
			Token token = new Token();
			object tempObj = map["access_token"];
			token.accessToken = tempObj == null?"":(string)tempObj;
			tempObj = map["token_type"];
			token.tokenType = tempObj == null?"":(string)tempObj;
			tempObj = map["refresh_token"];
			token.refreshToken = tempObj == null?"":(string)tempObj;

			long? expiresIn = 0L;
			try
			{
				expiresIn = Convert.ToInt64(Convert.ToString(map["expires_in"]));
			}
            catch (Exception)
			{
				expiresIn = 0L;
			}
			token.expiresInSeconds = expiresIn;

			return token;
		}

		/// <summary>
		/// Helper function to generate a URL using the base URL and the given parameters. It will encode each of the 
		/// parameters as well.
		/// </summary>
		/// <param name="baseURL"> The base URL that the parameters will be appended to. </param>
		/// <param name="parameters"> The parameters that will be appended to the base URL. Each parameter will be URL encoded. </param>
		/// <returns> A string representing the full URL. </returns>
		protected internal virtual string GenerateURL(string baseURL, IDictionary<string, string> parameters)
		{
			// Supports handling a relative URL
			if (baseURL == null)
			{
				baseURL = "";
			}

			// Add a question mark to the URL if there isn't one already.
			if (!baseURL.Contains("?"))
			{
				baseURL += "?";
			}

			// Test to see if a & should be the next character in the URL
			bool needsAmpersand = true;
			if (baseURL.EndsWith("?") || baseURL.EndsWith("&"))
			{
				needsAmpersand = false;
			}

			// Add the parameters to the URL
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
		public virtual HttpClient httpClient
		{
			get
			{
				return httpClient_Renamed;
			}
			set
			{
				this.httpClient_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the json serializer.
		/// </summary>
		/// <returns> the json serializer </returns>
		public virtual JsonSerializer jsonSerializer
		{
			get
			{
				return jsonSerializer_Renamed;
			}
			set
			{
				this.jsonSerializer_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the client id.
		/// </summary>
		/// <returns> the client id </returns>
		public virtual string clientId
		{
			get
			{
				return clientId_Renamed;
			}
			set
			{
				this.clientId_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the client secret.
		/// </summary>
		/// <returns> the client secret </returns>
		public virtual string clientSecret
		{
			get
			{
				return clientSecret_Renamed;
			}
			set
			{
				this.clientSecret_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the redirect url.
		/// </summary>
		/// <returns> the redirect url </returns>
		public virtual string redirectURL
		{
			get
			{
				return redirectURL_Renamed;
			}
			set
			{
				this.redirectURL_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the authorization url.
		/// </summary>
		/// <returns> the authorization url </returns>
		public virtual string authorizationURL
		{
			get
			{
				return authorizationURL_Renamed;
			}
			set
			{
				this.authorizationURL_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the token url.
		/// </summary>
		/// <returns> the token url </returns>
		public virtual string tokenURL
		{
			get
			{
				return tokenURL_Renamed;
			}
			set
			{
				this.tokenURL_Renamed = value;
			}
		}



        private string getHash(string str)
        {
            // Prepare the hash 
            string doHash = clientSecret_Renamed + "|" + str;
            byte[] bytes = Encoding.UTF8.GetBytes(doHash);
            SHA256Managed sha = new SHA256Managed();
            byte[] hash = sha.ComputeHash(bytes);
            return Encoding.UTF8.GetString(hash, 0, hash.Length);
        }

	}

}