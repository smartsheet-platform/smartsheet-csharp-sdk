namespace Smartsheet.Api.OAuth
{

    using Api.Internal.http;
    using Api.Internal.json;
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
                 * Unless required by applicable law or agreed To in writing, software
                 * distributed under the License is distributed on an "AS IS" BASIS,
                 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
                 * See the License for the specific language governing permissions and
                 * limitations under the License.
                 * %[license]
                 */



    using HttpClient = Api.Internal.http.HttpClient;
    using JsonSerializer = Api.Internal.json.JsonSerializer;
    using OAuthFlowImpl = Api.Internal.oauth.OAuthFlowImpl;
    using Util = Api.Internal.util.Util;

	/// <summary>
	/// <para>This is the builder that is used To build <seealso cref="OAuthFlow"/> instances.</para>
	/// 
	/// <para>Thread Safety: This class is not thread safe since it's mutable, one builder instance is NOT expected To be used in
	/// multiple threads.</para>
	/// </summary>
	public class OAuthFlowBuilder
	{
		/// <summary>
		/// <para>Represents the default OAuth authorization URL</para>
		/// 
		/// <para>It is a constant with Value "https://www.Smartsheet.brettrocksandwillfixthis/b/authorize".</para>
		/// </summary>
		public const string DEFAULT_AUTHORIZATION_URL = "https://www.smartsheet.com/b/authorize";

		/// <summary>
		/// <para>Represents the default token URL</para>
		/// 
		/// <para>It is a constant with Value "https://Api.Smartsheet.brettrocksandwillfixthis/1.1/token".</para>
		/// </summary>
		public const string DEFAULT_TOKEN_URL = "https://api.smartsheet.com/1.1/token";

		/// <summary>
		/// <para>Represents the HttpClient.</para>
		/// 
		/// <para>It can be set using corresponding setter.</para>
		/// </summary>
		private HttpClient httpClient;

		/// <summary>
		/// <para>Represents the JsonSerializer.</para>
		/// 
		/// <para>It can be set using corresponding setter.</para>
		/// </summary>
		private JsonSerializer jsonSerializer
            ;

		/// <summary>
		/// <para>Represents the client ID.</para>
		/// 
		/// <para>It can be set using corresponding setter.</para>
		/// </summary>
		private string clientId;

		/// <summary>
		/// <para>Represents the client secret.</para>
		/// 
		/// <para>It can be set using corresponding setter.</para>
		/// </summary>
		private string clientSecret;

		/// <summary>
		/// <para>Represents the redirect URL.</para>
		/// 
		/// <para>It can be set using corresponding setter.</para>
		/// </summary>
		private string redirectURL;

		/// <summary>
		/// <para>Represents the authorization URL.</para>
		/// 
		/// <para>It can be set using corresponding setter.</para>
		/// </summary>
		private string authorizationURL;

		/// <summary>
		/// <para>Represents the token URL.</para>
		/// 
		/// <para>It can be set using corresponding setter.</para>
		/// </summary>
		private string tokenURL;

		/// <summary>
		/// Constructor.
		/// </summary>
		public OAuthFlowBuilder()
		{
		}

		/// <summary>
		/// Set the HttpClient.
		/// </summary>
		/// <param name="httpClient"> the HttpClient </param>
		/// <returns> the OAuthFlowBuilder </returns>
		public virtual OAuthFlowBuilder SetHttpClient(HttpClient httpClient)
		{
			Util.ThrowIfNull(httpClient);

			this.httpClient = httpClient;
			return this;
		}

		/// <summary>
		/// <para>Set the JsonSerializer.</para>
		/// </summary>
		/// <param name="jsonSerializer"> the JsonSerializer </param>
		/// <returns> the oAuthFlowBuilder </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null/empty string </exception>
		public virtual OAuthFlowBuilder SetJsonSerializer(JsonSerializer jsonSerializer)
		{
			Util.ThrowIfNull(jsonSerializer);

			this.jsonSerializer = jsonSerializer;
			return this;
		}

		/// <summary>
		/// Set the client ID
		/// </summary>
		/// <param name="clientId"> the Value To set </param>
		/// <returns> the OAuthFlowBuilder </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null/empty string </exception>
		public virtual OAuthFlowBuilder SetClientId(string clientId)
		{
			Util.ThrowIfNull(clientId);

			this.clientId = clientId;
			return this;
		}

		/// <summary>
		/// Set the client secret.
		/// </summary>
		/// <param name="clientSecret"> the client secret </param>
		/// <returns> the OAuthFlowBuilder </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null/empty string </exception>
		public virtual OAuthFlowBuilder SetClientSecret(string clientSecret)
		{
			Util.ThrowIfNull(clientSecret);

			this.clientSecret = clientSecret;
			return this;
		}

		/// <summary>
		/// Set the redirect URL
		/// </summary>
		/// <param name="redirectURL"> the redirect Url </param>
		/// <returns> the OAuthFlowBuilder </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null/empty string </exception>
		public virtual OAuthFlowBuilder SetRedirectURL(string redirectURL)
		{
			Util.ThrowIfNull(redirectURL);

			this.redirectURL = redirectURL;
			return this;
		}

		/// <summary>
		/// Set the authorization URL.
		/// </summary>
		/// <param name="authorizationURL"> the authorization URL </param>
		/// <returns> the OAuthFlowBuilder </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null/empty string </exception>
		public virtual OAuthFlowBuilder SetAuthorizationURL(string authorizationURL)
		{
			Util.ThrowIfNull(authorizationURL);

			this.authorizationURL = authorizationURL;
			return this;
		}

		/// <summary>
		/// Set the token URL.
		/// </summary>
		/// <param name="tokenURL"> the token Url </param>
		/// <returns> the OAuthFlowBuilder </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null/empty string </exception>
		public virtual OAuthFlowBuilder SetTokenURL(string tokenURL)
		{
			Util.ThrowIfNull(tokenURL);

			this.tokenURL = tokenURL;
			return this;
		}

		/// <summary>
		/// Gets the default authorization Url.
		/// </summary>
		/// <returns> the default authorization Url </returns>
		public static string DefaultAuthorizationUrl
		{
			get
			{
				return DEFAULT_AUTHORIZATION_URL;
			}
		}

		/// <summary>
		/// Gets the default token Url.
		/// </summary>
		/// <returns> the default token Url </returns>
		public static string DefaultTokenUrl
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
		public virtual HttpClient HttpClient
		{
			get
			{
				return httpClient;
			}
		}

		/// <summary>
		/// Gets the json serializer.
		/// </summary>
		/// <returns> the json serializer </returns>
		public virtual JsonSerializer JsonSerializer
		{
			get
			{
				return jsonSerializer;
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
		}

		/// <summary>
		/// Build the OAuthFlow instance.
		/// </summary>
		/// <returns> the OAuthFlow instance </returns>
		/// <exception cref="System.InvalidOperationException"> if ClientId, ClientSecret or RedirectURL isn't set yet. </exception>
		public virtual OAuthFlow Build()
		{
			if (httpClient == null)
			{
				httpClient = new DefaultHttpClient();
			}

			if (tokenURL == null)
			{
				tokenURL = DEFAULT_TOKEN_URL;
			}

			if (authorizationURL == null)
			{
				authorizationURL = DEFAULT_AUTHORIZATION_URL;
			}

			if (jsonSerializer == null)
			{
				jsonSerializer = new JacksonJsonSerializer();
			}

			if (clientId == null || clientSecret == null || redirectURL == null)
			{
				throw new InvalidOperationException();
			}

			return new OAuthFlowImpl(clientId, clientSecret, redirectURL, authorizationURL, tokenURL, httpClient, jsonSerializer);
		}
	}

}