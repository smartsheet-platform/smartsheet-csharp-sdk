//    #[license]
//    Smartsheet SDK for C#
//    %%
//    Copyright (C) 2014 Smartsheet
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

namespace Smartsheet.Api.OAuth
{


	/// <summary>
	/// Represents OAuth token.
	/// </summary>
	public class Token
	{
		/// <summary>
		/// Represents the access token.
		/// </summary>
		private string accessToken;

		/// <summary>
		/// Represents the token Type.
		/// </summary>
		private string tokenType;

		/// <summary>
		/// Represents the refresh token.
		/// </summary>
		private string refreshToken;

		/// <summary>
		/// Represents the expiration time in seconds.
		/// </summary>
		private long? expiresInSeconds;

		/// <summary>
		/// Gets the access token.
		/// </summary>
		/// <returns> the access token </returns>
		public virtual string AccessToken
		{
			get
			{
				return accessToken;
			}
			set
			{
				this.accessToken = value;
			}
		}


		/// <summary>
		/// Gets the token Type.
		/// </summary>
		/// <returns> the token Type </returns>
		public virtual string TokenType
		{
			get
			{
				return tokenType;
			}
			set
			{
				this.tokenType = value;
			}
		}


		/// <summary>
		/// Gets the refresh token.
		/// </summary>
		/// <returns> the refresh token </returns>
		public virtual string RefreshToken
		{
			get
			{
				return refreshToken;
			}
			set
			{
				this.refreshToken = value;
			}
		}


		/// <summary>
		/// Gets the expires in seconds.
		/// </summary>
		/// <returns> the expires in seconds </returns>
		public virtual long? ExpiresInSeconds
		{
			get
			{
				return expiresInSeconds;
			}
			set
			{
				this.expiresInSeconds = value;
			}
		}


	}

}