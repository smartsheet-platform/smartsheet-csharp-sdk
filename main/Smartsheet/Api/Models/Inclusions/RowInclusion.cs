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

using System.Collections.Generic;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Smartsheet.Api.Models
{
	/// <summary>
	/// Represents specific elements to include in a response.
	/// </summary>
	public enum RowInclusion
	{
		/// <summary>
		/// <para>Includes row discussions array.</para>
		/// <para>To include discussion attachments, both attachments and discussions must be present in the include list.</para>
		/// </summary>
		DISCUSSIONS,

		/// <summary>
		/// <para>Includes row attachments array.</para>
		/// <para>To include discussion attachments, both attachments and discussions must be present in the include list.</para>
		/// </summary>
		ATTACHMENTS,

		/// <summary>
		/// <para>Includes format attribute on the row and its cells.</para>
		/// </summary>
		FORMAT,

		/// <summary>
		/// <para>Includes filteredOut attribute indicating if the row should be displayed or hidden according to the sheet’s filters.</para>
		/// <para>May be used in conjunction with columns to include the user’s column filters with the columns.</para>
		/// </summary>
		FILTERS,

		/// <summary>
		/// <para>Includes columnType attribute in the row’s cells indicating the type of the column the cell resides in.</para>
		/// </summary>
		COLUMN_TYPE,

		/// <summary>
		/// Includes a columns list that specifies all of the columns for the sheet. 
		/// <para>May be used in conjunction with filters to include the user’s column filters with the columns.</para>
		/// </summary>
		COLUMNS,

		/// <summary>
		/// Includes a permalink attribute for each Row. A Row permalink represents a direct link to the Row in the Smartsheet application.
		/// </summary>
		ROW_PERMALINK,

		/// <summary>
		/// Includes createdBy and modifiedBy attributes on the row, indicating the row’s creator, and last modifier.
		/// </summary>
		ROW_WRITER_INFO,

		/// <summary>
		/// Includes objectValue attribute on cells containing values.
		/// </summary>
		OBJECT_VALUE
	}
}