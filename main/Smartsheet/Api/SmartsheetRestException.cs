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
		/// <para>Constructor.</para>
		/// </summary>
		/// <param name="error"> the Error object from Smartsheet REST API </param>
		public SmartsheetRestException(Error error) : base(error.Message)
		{
				errorCode = error.ErrorCode;
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
	}

}