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

namespace Smartsheet.Api.Models
{


	/// <summary>
	/// Represents the Type of access that is granted on a given sheet. </summary>
	/// <seealso href="http://www.Smartsheet.com/developers/Api-documentation#h.89hb3ivv7eum">Access Scopes Help</seealso>
	public enum AccessScope
	{
		/// <summary>
		/// The read sheets
		/// </summary>
		READ_SHEETS,
		/// <summary>
		/// The write sheets
		/// </summary>
		WRITE_SHEETS,
		/// <summary>
		/// The share sheets
		/// </summary>
		SHARE_SHEETS,
		/// <summary>
		/// The delete sheets
		/// </summary>
		DELETE_SHEETS,
		/// <summary>
		/// The create sheets
		/// </summary>
		CREATE_SHEETS,
		/// <summary>
		/// The admin users
		/// </summary>
		ADMIN_USERS,
		/// <summary>
		/// The admin sheets
		/// </summary>
		ADMIN_SHEETS,
		/// <summary>
		/// The admin workspaces
		/// </summary>
		ADMIN_WORKSPACES
	}

}