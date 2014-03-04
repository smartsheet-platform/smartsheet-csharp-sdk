namespace com.smartsheet.api.oauth
{

    using System.Collections.Generic;
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




    using HttpClientException = com.smartsheet.api.@internal.http.HttpClientException;
    using JSONSerializationException = com.smartsheet.api.@internal.json.JSONSerializationException;

	/// <summary>
	/// <para>OAuthFlow interface provides methods to do the OAuth2 authorization.</para>
	/// 
	/// <para>Thread Safety: Implementation of this interface must be thread safe.</para>
	/// </summary>
	public interface OAuthFlow
	{

		/// <summary>
		/// <para>Generate a new authorization URL.</para>
		/// </summary>
		/// <param name="scopes"> the requested scopes </param>
		/// <param name="state"> an arbitrary string that will be returned to your app; intended to be used by you to ensure that 
		/// this redirect is indeed from an OAuth flow that you initiated. </param>
		/// <returns> the authorization URL </returns>
		/// <exception cref="InvalidOperationException"> if scopes is null or empty </exception>
		string NewAuthorizationURL(IEnumerable<AccessScope> scopes, string state);

		/// <summary>
		/// Extract AuthorizationResult from the authorization response URL (i.e. the redirectURL with the response
		/// parameters from Smartsheet OAuth server).
		/// </summary>
		/// <param name="authorizationResponseURL"> the authorization response url </param>
		/// <returns> the authorization result </returns>
		/// <exception cref="UriFormatException"> the URI syntax exception </exception>
		/// <exception cref="AccessDeniedException"> the access denied exception </exception>
		/// <exception cref="UnsupportedResponseTypeException"> the unsupported response type exception </exception>
		/// <exception cref="InvalidScopeException"> the invalid scope exception </exception>
		/// <exception cref="OAuthAuthorizationCodeException"> the o auth authorization code exception </exception>
		/// <exception cref="InvalidOperationException"> if any other error occurred during the operation </exception>
		AuthorizationResult ExtractAuthorizationResult(string authorizationResponseURL);

		/// <summary>
		/// Obtain a new token using AuthorizationResult.
		/// </summary>
		/// <param name="authorizationResult"> the authorization result </param>
		/// <returns> the token </returns>
		/// <exception cref="OAuthTokenException"> the o auth token exception </exception>
		/// <exception cref="JSONSerializationException"> the JSON serializer exception </exception>
		/// <exception cref="UriFormatException"> the URI syntax exception </exception>
		/// <exception cref="InvalidRequestException"> the invalid request exception </exception>
		/// <exception cref="InvalidOperationException"> if any other error occurred during the operation </exception>
		Token ObtainNewToken(AuthorizationResult authorizationResult);

		/// <summary>
		/// Refresh token.
		/// </summary>
		/// <param name="token"> the token to refresh </param>
		/// <returns> the refreshed token </returns>
		/// <exception cref="OAuthTokenException"> the o auth token exception </exception>
		/// <exception cref="JSONSerializationException"> the JSON serializer exception </exception>
		/// <exception cref="UriFormatException"> the URI syntax exception </exception>
		/// <exception cref="InvalidRequestException"> the invalid request exception </exception>
		/// <exception cref="InvalidOperationException"> if any other error occurred during the operation </exception>
		Token RefreshToken(Token token);
	}

}