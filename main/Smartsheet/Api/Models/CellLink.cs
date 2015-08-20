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

using System;

namespace Smartsheet.Api.Models
{
	/// <summary>
	/// Represents a link to a Cell in a different Sheet.
	/// <remarks>If status is not “OK” (i.e. there is a problem with the link),
	/// any or all of the following attributes may be null: sheetId, rowId, columnId</remarks>
	/// <para>You can create and modify cell links by using any API operation that creates or updates cell data.
	/// Creating or updating cell links via the cell.linkInFromCell attribute is a special operation.
	/// A given row or cell update operation may contain only link updates, or no link updates.
	/// Attempting to mix row/cell updates with cell link updates will result in error code 1115.</para>
	/// <para>When creating a cell link, cell.value must be null (the data will be pulled from the linked cell).</para>
	/// <para>A cell may not contain both a hyperlink and a cell link, so hyperlink and linkInFromCell may never both be non-null at the same time.</para>
	/// <para>A cell link can only be added to an existing cell, so the cell.linkInFromCell attribute is not allowed when POSTing a new row to a sheet.</para>
	/// </summary>
	public class CellLink
	{
		private string status;

		private long? sheetId;

		private long? rowId;

		private long? columnId;

		private string sheetname;

		/// <summary>
		/// One of the following values:
		/// <list type="bullet">
		/// <item><term>OK:</term><description>the link is in a good state</description></item>
		/// <item><term>BROKEN:</term><description>the row or sheet linked to was deleted</description></item>
		/// <item><term>INACCESSIBLE:</term><description>the sheet linked to cannot be viewed by this user</description></item>
		/// <item><description>Several other values indicating unusual error conditions: 
		/// NOT_SHARED, BLOCKED, CIRCULAR, INVALID, and DISABLED.</description></item>
		/// </list>
		/// </summary>
		public string Status
		{
			get { return status; }
			set { status = value; }
		}

		/// <summary>
		/// Sheet ID of the sheet that the linked cell belongs to
		/// </summary>
		public long? SheetId
		{
			get { return sheetId; }
			set { sheetId = value; }
		}

		/// <summary>
		/// Row ID of the linked cell
		/// </summary>
		public long? RowId
		{
			get { return rowId; }
			set { rowId = value; }
		}

		/// <summary>
		/// Column ID of the linked cell
		/// </summary>
		public long? ColumnId
		{
			get { return columnId; }
			set { columnId = value; }
		}

		/// <summary>
		/// Sheet name of the linked cell
		/// </summary>
		public string Sheetname
		{
			get { return sheetname; }
			set { sheetname = value; }
		}
	}
}