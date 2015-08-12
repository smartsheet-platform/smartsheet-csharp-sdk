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

using Smartsheet.Api.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Smartsheet.Api.Internal
{
	/// <summary>
	/// This is the implementation of the RowResources.
	/// 
	/// Thread Safety: This class is thread safe because it is immutable and its base class is thread safe.
	/// </summary>
	[Obsolete("Deprecated", true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class RowResourcesImpl : AbstractResources, RowResources
	{
		/// <summary>
		/// Represents the AssociatedAttachmentResources.
		/// 
		/// It will be initialized in constructor and will not change afterwards.
		/// </summary>
		private AssociatedAttachmentResources attachments;
		/// <summary>
		/// Represents the AssociatedDiscussionResources.
		/// 
		/// It will be initialized in constructor and will not change afterwards.
		/// </summary>
		private AssociatedDiscussionResources discussions;

		/// <summary>
		/// Constructor.
		/// 
		/// Exceptions: - IllegalArgumentException : if any argument is null
		/// </summary>
		/// <param name="smartsheet"> the Smartsheet </param>
		[Obsolete("Deprecated", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public RowResourcesImpl(SmartsheetImpl smartsheet)
			: base(smartsheet)
		{
			this.attachments = new AssociatedAttachmentResourcesImpl(smartsheet, "row");
			this.discussions = new AssociatedDiscussionResourcesImpl(smartsheet, "row");
		}

		[Obsolete("Deprecated", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual Row GetRow(long id, IEnumerable<ObjectInclusion> includes)
		{
			throw new NotSupportedException();
		}

		[Obsolete("Deprecated", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual IList<Row> MoveRow(long id, RowWrapper rowWrapper)
		{
			throw new NotSupportedException();
		}

		[Obsolete("Deprecated", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void DeleteRow(long id)
		{
			throw new NotSupportedException();
		}

		[Obsolete("Deprecated", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void SendRow(long id, RowEmail email)
		{
			throw new NotSupportedException();
		}

		[Obsolete("Deprecated", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual IList<Cell> UpdateCells(long rowId, IList<Cell> cells)
		{
			throw new NotSupportedException();
		}

		[Obsolete("Deprecated", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual IList<CellHistory> GetCellHistory(long rowId, long columnId)
		{
			throw new NotSupportedException();
		}

		[Obsolete("Deprecated", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual AssociatedAttachmentResources Attachments()
		{
			throw new NotSupportedException();
		}

		[Obsolete("Deprecated", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual AssociatedDiscussionResources Discussions()
		{
			throw new NotSupportedException();
		}
	}

}