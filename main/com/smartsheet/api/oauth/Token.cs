namespace com.smartsheet.api.oauth
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



	/// <summary>
	/// Represents OAuth token.
	/// </summary>
	public class Token
	{
		/// <summary>
		/// Represents the access token.
		/// </summary>
		private string accessToken_Renamed;

		/// <summary>
		/// Represents the token type.
		/// </summary>
		private string tokenType_Renamed;

		/// <summary>
		/// Represents the refresh token.
		/// </summary>
		private string refreshToken_Renamed;

		/// <summary>
		/// Represents the expiration time in seconds.
		/// </summary>
		private long? expiresInSeconds_Renamed;

		/// <summary>
		/// Gets the access token.
		/// </summary>
		/// <returns> the access token </returns>
		public virtual string accessToken
		{
			get
			{
				return accessToken_Renamed;
			}
			set
			{
				this.accessToken_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the token type.
		/// </summary>
		/// <returns> the token type </returns>
		public virtual string tokenType
		{
			get
			{
				return tokenType_Renamed;
			}
			set
			{
				this.tokenType_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the refresh token.
		/// </summary>
		/// <returns> the refresh token </returns>
		public virtual string refreshToken
		{
			get
			{
				return refreshToken_Renamed;
			}
			set
			{
				this.refreshToken_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the expires in seconds.
		/// </summary>
		/// <returns> the expires in seconds </returns>
		public virtual long? expiresInSeconds
		{
			get
			{
				return expiresInSeconds_Renamed;
			}
			set
			{
				this.expiresInSeconds_Renamed = value;
			}
		}


	}

}