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
//    Unless required by applicable law or agreed To in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//    %[license]

namespace Smartsheet.Api
{
	using Error = Api.Models.Error;

	/// <summary>
	/// <para>This is the exception To indicate errors (Error objects of Smartsheet REST API) returned from Smartsheet REST API.</para>
	/// 
	/// <para>Thread safety: Exceptions are not thread safe.</para>
	/// </summary>
	public class SmartsheetRestException : SmartsheetException
	{
		/// <summary>
		/// <para>Represents the error Code.</para>
		/// 
		/// <para>It will be initialized in constructor and will not change afterwards.</para>
		/// </summary>
		private readonly int? errorCode;

		/// <summary>
		/// <para>Represents the reference ID.</para>
		/// 
		/// <para>It will be initialized in constructor and will not change afterwards.</para>
		/// </summary>
		private readonly string refId;

		/// <summary>
		/// <para>Represents any error detail provided by the API</para>
		/// 
		/// <para>It will be initialized in constructor and will not change afterwards.</para>
		/// </summary>
		private readonly object detail;

		/// <summary>
		/// <para>Constructor.</para>
		/// </summary>
		/// <param name="error"> the Error object from Smartsheet REST API </param>
		public SmartsheetRestException(Error error) : base(error.Message)
		{
			errorCode = error.ErrorCode;
			refId = error.RefId;
			detail = error.Detail;
		}

		/// <summary>
		/// <para>Returns the error Code.</para>
		/// </summary>
		/// <returns> the error Code </returns>
		public virtual int? ErrorCode
		{
			get
			{
				return this.errorCode;
			}
		}

		/// <summary>
		/// <para>Returns the refId.</para>
		/// </summary>
		/// <returns> the refId </returns>
		public virtual string RefId
		{
			get
			{
				return this.refId;
			}
		}

		/// <summary>
		/// <para>Returns the error detail</para>
		/// </summary>
		/// <returns> the error detail </returns>
		public virtual object Detail
		{
			get
			{
				return this.detail;
			}
		}
	}

}