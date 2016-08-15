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

namespace Smartsheet.Api.OAuth
{


	/// <summary>
	/// Represents the access scope. These are the scopes that are required To access an end user's Smartsheet data and 
	/// specifies the Type of operations that are permitted.
	/// </summary>
	public enum AccessScope
	{
		/// <summary>
		/// Read all sheet data, including comments, attachments and cell data
		/// </summary>
		READ_SHEETS,

		/// <summary>
		/// Insert and modify sheet data, including comments, attachments and cell data
		/// </summary>
		WRITE_SHEETS,

		/// <summary>
		/// Share sheets, including sending sheets as attachments
		/// </summary>
		SHARE_SHEETS,

		/// <summary>
		/// Delete sheets
		/// </summary>
		DELETE_SHEETS,

		/// <summary>
		/// Create new sheets
		/// </summary>
		CREATE_SHEETS,

		/// <summary>
		/// Create new sights
		/// </summary>
		CREATE_SIGHTS,

		/// <summary>
		/// Read all sight data
		/// </summary>
		READ_SIGHTS,

		/// <summary>
		/// Delete sight
		/// </summary>
		DELETE_SIGHTS,

		/// <summary>
		/// Share sight
		/// </summary>
		SHARE_SIGHTS,

		/// <summary>
		/// Retrieve users and groups for your Smartsheet organization
		/// </summary>
		READ_USERS,

		/// <summary>
		/// Retrieve contacts
		/// </summary>
		READ_CONTACTS,

		/// <summary>
		/// Add and remove users from your Smartsheet organization; create groups and manage membership
		/// </summary>
		ADMIN_USERS,

		/// <summary>
		/// Modify sheet structure, including column definition, publish state, etc.
		/// </summary>
		ADMIN_SHEETS,

		/// <summary>
		/// Create and manage workspaces and folders, including sharing
		/// </summary>
		ADMIN_WORKSPACES
	}
}