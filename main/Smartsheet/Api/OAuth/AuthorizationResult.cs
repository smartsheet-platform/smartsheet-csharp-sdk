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
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//    %[license]

using System.Text;

namespace Smartsheet.Api.OAuth
{


	/// <summary>
	/// Represents an OAuth authorization RequestResult.
	/// </summary>
	public class AuthorizationResult
	{
		/// <summary>
		/// Represents the authorization Code which is required to obtain an access token. </summary>
		private string code;

		/// <summary>
		/// Represents the total number of seconds that the authorization token is valid. This is always 4 minutes. </summary>
		private long? expiresInSeconds;

		/// <summary>
		/// Represents the State string which is returned to the redirect URL for a registered application. </summary>
		private string state;

		/// <summary>
		/// Gets the authorization Code which is required to obtain an access token.
		/// </summary>
		/// <returns> the authorization Code </returns>
		public virtual string Code
		{
			get
			{
				return code;
			}
			set
			{
				this.code = value;
			}
		}


		/// <summary>
		/// Gets the total number of seconds that the authorization token is valid. This is always 4 minutes.
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


		/// <summary>
		/// Gets the State string which is returned to the redirect URL for a registered application
		/// </summary>
		/// <returns> the State </returns>
		public virtual string State
		{
			get
			{
				return state;
			}
			set
			{
				this.state = value;
			}
		}


		/// <summary>
		/// Returns a <see cref="System.String" /> that represents this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String" /> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			StringBuilder builder = new StringBuilder();
			builder.Append("AuthorizationResult [code=");
			builder.Append(code);
			builder.Append(", expiresInSeconds=");
			builder.Append(expiresInSeconds);
			builder.Append(", state=");
			builder.Append(state);
			builder.Append("]");
			return builder.ToString();
		}
	}

}