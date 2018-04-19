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
	/// Represents the system column types. </summary>
	/// <seealso href="http://help.Smartsheet.com/customer/portal/articles/504619-column-types">Column Types Help</seealso>
	public enum SystemColumnType
	{
		/// <summary>
		/// Represents the AUTO_NUMBER system column Type.
		/// </summary>
		AUTO_NUMBER,

		/// <summary>
		/// Represents the MODIFIED_DATE system column Type.
		/// </summary>
		MODIFIED_DATE,

		/// <summary>
		/// Represents the MODIFIED_BY system column Type.
		/// </summary>
		MODIFIED_BY,

		/// <summary>
		/// Represents the CREATED_DATE system column Type.
		/// </summary>
		CREATED_DATE,

		/// <summary>
		/// Represents the CREATED_BY system column Type.
		/// </summary>
		CREATED_BY


	}

}