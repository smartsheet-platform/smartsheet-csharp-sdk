namespace com.smartsheet.api.oauth
{

    using com.smartsheet.api.@internal.http;
    using com.smartsheet.api.@internal.json;
    using System;
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
    using JsonSerializer = com.smartsheet.api.@internal.json.JsonSerializer;
    using OAuthFlowImpl = com.smartsheet.api.@internal.oauth.OAuthFlowImpl;
    using Util = com.smartsheet.api.@internal.util.Util;

	/// <summary>
	/// <para>This is the builder that is used to build <seealso cref="OAuthFlow"/> instances.</para>
	/// 
	/// <para>Thread Safety: This class is not thread safe since it's mutable, one builder instance is NOT expected to be used in
	/// multiple threads.</para>
	/// </summary>
	public class OAuthFlowBuilder
	{
		/// <summary>
		/// <para>Represents the default OAuth authorization URL</para>
		/// 
		/// <para>It is a constant with value "https://www.smartsheet.com/b/authorize".</para>
		/// </summary>
		public const string DEFAULT_AUTHORIZATION_URL = "https://www.smartsheet.com/b/authorize";

		/// <summary>
		/// <para>Represents the default token URL</para>
		/// 
		/// <para>It is a constant with value "https://api.smartsheet.com/1.1/token".</para>
		/// </summary>
		public const string DEFAULT_TOKEN_URL = "https://api.smartsheet.com/1.1/token";

		/// <summary>
		/// <para>Represents the HttpClient.</para>
		/// 
		/// <para>It can be set using corresponding setter.</para>
		/// </summary>
		private HttpClient httpClient_Renamed;

		/// <summary>
		/// <para>Represents the JsonSerializer.</para>
		/// 
		/// <para>It can be set using corresponding setter.</para>
		/// </summary>
		private JsonSerializer jsonSerializer_Renamed;

		/// <summary>
		/// <para>Represents the client ID.</para>
		/// 
		/// <para>It can be set using corresponding setter.</para>
		/// </summary>
		private string clientId_Renamed;

		/// <summary>
		/// <para>Represents the client secret.</para>
		/// 
		/// <para>It can be set using corresponding setter.</para>
		/// </summary>
		private string clientSecret_Renamed;

		/// <summary>
		/// <para>Represents the redirect URL.</para>
		/// 
		/// <para>It can be set using corresponding setter.</para>
		/// </summary>
		private string redirectURL_Renamed;

		/// <summary>
		/// <para>Represents the authorization URL.</para>
		/// 
		/// <para>It can be set using corresponding setter.</para>
		/// </summary>
		private string authorizationURL_Renamed;

		/// <summary>
		/// <para>Represents the token URL.</para>
		/// 
		/// <para>It can be set using corresponding setter.</para>
		/// </summary>
		private string tokenURL_Renamed;

		/// <summary>
		/// Constructor.
		/// </summary>
		public OAuthFlowBuilder()
		{
		}

		/// <summary>
		/// Set the HttpClient.
		/// </summary>
		/// <param name="httpClient"> the httpClient </param>
		/// <returns> the OAuthFlowBuilder </returns>
		public virtual OAuthFlowBuilder SetHttpClient(HttpClient httpClient)
		{
			Util.ThrowIfNull(httpClient);

			this.httpClient_Renamed = httpClient;
			return this;
		}

		/// <summary>
		/// <para>Set the JsonSerializer.</para>
		/// </summary>
		/// <param name="jsonSerializer"> the JsonSerializer </param>
		/// <returns> the oAuthFlowBuilder </returns>
		/// <exception cref="InvalidOperationException"> if any argument is null/empty string </exception>
		public virtual OAuthFlowBuilder SetJsonSerializer(JsonSerializer jsonSerializer)
		{
			Util.ThrowIfNull(jsonSerializer);

			this.jsonSerializer_Renamed = jsonSerializer;
			return this;
		}

		/// <summary>
		/// Set the client ID
		/// </summary>
		/// <param name="clientId"> the value to set </param>
		/// <returns> the OAuthFlowBuilder </returns>
		/// <exception cref="InvalidOperationException"> if any argument is null/empty string </exception>
		public virtual OAuthFlowBuilder SetClientId(string clientId)
		{
			Util.ThrowIfNull(clientId);

			this.clientId_Renamed = clientId;
			return this;
		}

		/// <summary>
		/// Set the client secret.
		/// </summary>
		/// <param name="clientSecret"> the client secret </param>
		/// <returns> the OAuthFlowBuilder </returns>
		/// <exception cref="InvalidOperationException"> if any argument is null/empty string </exception>
		public virtual OAuthFlowBuilder SetClientSecret(string clientSecret)
		{
			Util.ThrowIfNull(clientSecret);

			this.clientSecret_Renamed = clientSecret;
			return this;
		}

		/// <summary>
		/// Set the redirect URL
		/// </summary>
		/// <param name="redirectURL"> the redirect url </param>
		/// <returns> the OAuthFlowBuilder </returns>
		/// <exception cref="InvalidOperationException"> if any argument is null/empty string </exception>
		public virtual OAuthFlowBuilder SetRedirectURL(string redirectURL)
		{
			Util.ThrowIfNull(redirectURL);

			this.redirectURL_Renamed = redirectURL;
			return this;
		}

		/// <summary>
		/// Set the authorization URL.
		/// </summary>
		/// <param name="authorizationURL"> the authorization URL </param>
		/// <returns> the OAuthFlowBuilder </returns>
		/// <exception cref="InvalidOperationException"> if any argument is null/empty string </exception>
		public virtual OAuthFlowBuilder SetAuthorizationURL(string authorizationURL)
		{
			Util.ThrowIfNull(authorizationURL);

			this.authorizationURL_Renamed = authorizationURL;
			return this;
		}

		/// <summary>
		/// Set the token URL.
		/// </summary>
		/// <param name="tokenURL"> the token url </param>
		/// <returns> the OAuthFlowBuilder </returns>
		/// <exception cref="InvalidOperationException"> if any argument is null/empty string </exception>
		public virtual OAuthFlowBuilder SetTokenURL(string tokenURL)
		{
			Util.ThrowIfNull(tokenURL);

			this.tokenURL_Renamed = tokenURL;
			return this;
		}

		/// <summary>
		/// Gets the default authorization url.
		/// </summary>
		/// <returns> the default authorization url </returns>
		public static string defaultAuthorizationUrl
		{
			get
			{
				return DEFAULT_AUTHORIZATION_URL;
			}
		}

		/// <summary>
		/// Gets the default token url.
		/// </summary>
		/// <returns> the default token url </returns>
		public static string defaultTokenUrl
		{
			get
			{
				return DEFAULT_TOKEN_URL;
			}
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
		}

		/// <summary>
		/// Build the OAuthFlow instance.
		/// </summary>
		/// <returns> the OAuthFlow instance </returns>
		/// <exception cref="InvalidOperationException"> if clientId, clientSecret or redirectURL isn't set yet. </exception>
		public virtual OAuthFlow Build()
		{
			if (httpClient_Renamed == null)
			{
				httpClient_Renamed = new DefaultHttpClient();
			}

			if (tokenURL_Renamed == null)
			{
				tokenURL_Renamed = DEFAULT_TOKEN_URL;
			}

			if (authorizationURL_Renamed == null)
			{
				authorizationURL_Renamed = DEFAULT_AUTHORIZATION_URL;
			}

			if (jsonSerializer_Renamed == null)
			{
				jsonSerializer_Renamed = new JacksonJsonSerializer();
			}

			if (clientId_Renamed == null || clientSecret_Renamed == null || redirectURL_Renamed == null)
			{
				throw new InvalidOperationException();
			}

			return new OAuthFlowImpl(clientId_Renamed, clientSecret_Renamed, redirectURL_Renamed, authorizationURL_Renamed, tokenURL_Renamed, httpClient_Renamed, jsonSerializer_Renamed);
		}
	}

}