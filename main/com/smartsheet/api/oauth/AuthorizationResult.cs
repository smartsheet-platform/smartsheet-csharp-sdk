using System.Text;

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
	/// Represents an OAuth authorization result.
	/// </summary>
	public class AuthorizationResult
	{
		/// <summary>
		/// Represents the authorization code which is required to obtain an access token. </summary>
		private string code_Renamed;

		/// <summary>
		/// Represents the total number of seconds that the authorization token is valid. This is always 4 minutes. </summary>
		private long? expiresInSeconds_Renamed;

		/// <summary>
		/// Represents the state string which is returned to the redirect URL for a registered application. </summary>
		private string state_Renamed;

		/// <summary>
		/// Gets the authorization code which is required to obtain an access token.
		/// </summary>
		/// <returns> the authorization code </returns>
		public virtual string code
		{
			get
			{
				return code_Renamed;
			}
			set
			{
				this.code_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the total number of seconds that the authorization token is valid. This is always 4 minutes.
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


		/// <summary>
		/// Gets the state string which is returned to the redirect URL for a registered application
		/// </summary>
		/// <returns> the state </returns>
		public virtual string state
		{
			get
			{
				return state_Renamed;
			}
			set
			{
				this.state_Renamed = value;
			}
		}


		public override string ToString()
		{
			StringBuilder builder = new StringBuilder();
			builder.Append("AuthorizationResult [code=");
			builder.Append(code_Renamed);
			builder.Append(", expiresInSeconds=");
			builder.Append(expiresInSeconds_Renamed);
			builder.Append(", state=");
			builder.Append(state_Renamed);
			builder.Append("]");
			return builder.ToString();
		}
	}

}