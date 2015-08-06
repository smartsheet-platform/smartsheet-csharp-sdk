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

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Smartsheet.Api.Models
{
	/// <summary>
	/// Represents specific elements to include in a response.
	/// </summary>
	public enum SheetLevelInclusion
	{
		/// <summary>
		/// Includes sheet-level and row-level discussions.
		/// </summary>
		DISCUSSIONS,

		/// <summary>
		/// Includes sheet-level and row-level attachments.
		/// </summary>
		ATTACHMENTS,

		/// <summary>
		/// Includes column, row, and cell formatting.
		/// </summary>
		FORMAT,

		/// <summary>
		/// Includes column filters, and row.filteredOut attribute.
		/// </summary>
		FILTERS,

		/// <summary>
		/// Includes the owner’s email address and user ID for each sheet.
		/// </summary>
		OWNER_INFO,

		/// <summary>
		/// <para>
		/// Includes a URL that can be used to provision a Sheet or a Folder that exists in a distribution-enabled Workspace.
		/// </para>
		/// <para>
		/// It enables a user to create their own copy of the Sheet or Folder without having access to the Sheet or Folder being copied.
		/// </para>
		/// </summary>
		DISTRIBUTION_LINK,

		/// <summary>
		/// Includes the source object indicating which sheet or template the sheet was created from, if any.
		/// </summary>
		SOURCE,

		/// <summary>
		/// Includes a permalink attribute for each Row. A Row permalink represents a direct link to the Row in the Smartsheet application.
		/// </summary>
		ROW_PERMALINK
	}
}