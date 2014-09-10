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
	/// This is the exception To indicate a resource can not be found.
	/// 
	/// Basically this exception will be thrown when the Smartsheet REST API responds with "404 NOT FOUND".
	/// 
	/// Thread safety: Exceptions are not thread safe.
	/// </summary>
	public class ResourceNotFoundException : SmartsheetRestException
	{



		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="error"> the Error object from Smartsheet REST API </param>
		public ResourceNotFoundException(Error error) : base(error)
		{
		}
	}

}