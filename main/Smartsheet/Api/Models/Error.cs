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

namespace Smartsheet.Api.Models
{
	/// <summary>
	/// Represents Error object.
	/// </summary>
	public class Error
	{
		/// <summary>
		/// Represents the error code.
		/// </summary>
		private int? errorCode;

		/// <summary>
		/// Represents the message.
		/// </summary>
		private string message;

		/// <summary>
		/// Reference Id of the specific error occurrence. 
		/// </summary>
		private string refId;

		/// <summary>
		/// Additional error detail if it is available
		/// </summary>
		private object detail;

		/// <summary>
		/// Gets the error code.
		/// </summary>
		/// <returns> the error code </returns>
		public virtual int? ErrorCode
		{
			get
			{
				return errorCode;
			}
			set
			{
				this.errorCode = value;
			}
		}

		/// <summary>
		/// Gets the message.
		/// </summary>
		/// <returns> the message </returns>
		public virtual string Message
		{
			get
			{
				return message;
			}
			set
			{
				this.message = value;
			}
		}

		/// <summary>
		/// Gets the refId
		/// </summary>
		/// <returns> the refId </returns>
		public virtual string RefId
		{
			get
			{
				return refId;
			}
			set
			{
				this.refId = value;
			}
		}

		/// <summary>
		/// Gets additional error detail if available
		/// </summary>
		/// <returns> error detail </returns>
		public virtual object Detail
		{
			get
			{
				return detail;
			}
			set
			{
				this.detail = value;
			}
		}
	}
}
