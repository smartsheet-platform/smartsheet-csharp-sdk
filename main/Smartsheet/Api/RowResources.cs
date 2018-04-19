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

using Smartsheet.Api.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Smartsheet.Api
{
	/// <summary>
	/// <para>Use SheetRowResources instead.</para>
	/// </summary>
	[Obsolete("Deprecated", true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface RowResources
	{
		[Obsolete("Deprecated", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		Row GetRow(long id, IEnumerable<ObjectInclusion> includes);

		[Obsolete("Deprecated", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		IList<Row> MoveRow(long id, RowWrapper rowWrapper);

		[Obsolete("Deprecated", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void DeleteRow(long id);

		[Obsolete("Deprecated", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void SendRow(long id, RowEmail email);

		[Obsolete("Deprecated", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		IList<Cell> UpdateCells(long rowId, IList<Cell> cells);

		[Obsolete("Deprecated", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		IList<CellHistory> GetCellHistory(long rowId, long columnId);

		[Obsolete("Deprecated", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		AssociatedAttachmentResources Attachments();

		[Obsolete("Deprecated", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		AssociatedDiscussionResources Discussions();
	}

}