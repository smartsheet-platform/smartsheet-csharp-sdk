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

namespace Smartsheet.Api.Models
{


	/// <summary>
	/// Represents Error object.
	/// </summary>
	public class Error
	{
		/// <summary>
		/// Represents the error Code.
		/// </summary>
		private int? errorCode;

		/// <summary>
		/// Represents the Message.
		/// </summary>
		private string message;

		/// <summary>
		/// Gets the Message.
		/// </summary>
		/// <returns> the Message </returns>
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
		/// Gets the error Code.
		/// </summary>
		/// <returns> the error Code </returns>
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

	}

}