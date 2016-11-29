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
using System.Linq;
using System.Text;

namespace Smartsheet.Api.Models
{
	/// <summary>
	/// Represents the Row object.
	/// </summary>
	public abstract class AbstractRow<TColumn, TCell> : IdentifiableModel
		where TColumn : Column
		where TCell : Cell
	{
		/// <summary>
		/// Represents the Sheet ID. </summary>
		private long? sheetId;

		/// <summary>
		/// Represents the row number. </summary>
		private int? rowNumber;

		/// <summary>
		/// Represents the parent row number. </summary>
		private int? parentRowNumber;

		/// <summary>
		/// Represents the parent row number. </summary>
		private long? parentId;

		/// <summary>
		/// Represents the parent row number. </summary>
		private long? siblingId;

		private bool? filteredOut;

		private bool? inCriticalPath;

		private bool? locked;

		private bool? lockedForUser;

		private string format;

		private string conditionalFormat;

		private bool? toTop;

		private bool? toBottom;

		private bool? above;

		/// <summary>
		/// User object containing the name and email of the creator of this row.</summary>
		private User createdBy;

		/// <summary>
		/// User object containing the name and email of the last user to modify this row.</summary>
		private User modifiedBy;

		/// <summary>
		/// Represents the Cells for this row. </summary>
		private IList<TCell> cells;

		/// <summary>
		/// Represents the Discussions for this row. </summary>
		private IList<Discussion> discussions;

		/// <summary>
		/// Represents the Attachments for this row. </summary>
		private IList<Attachment> attachments;

		/// <summary>
		/// Represents the Columns for this row. </summary>
		private IList<TColumn> columns;

		/// <summary>
		/// Represents the date and time the row was created. </summary>
		private DateTime? createdAt;

		/// <summary>
		/// Represents the date and time the row was modified. </summary>
		private DateTime? modifiedAt;

		/// <summary>
		/// A read-only flag To indicate if the row is Expanded or collapsed. </summary>
		private bool? expanded;

		/// <summary>
		/// The Version number that is incremented every time a sheet is modified. </summary>
		private int? version;

		/// <summary>
		/// The user's permissions on the sheet. </summary>
		private AccessLevel? accessLevel;

		private string permalink;


		/// <summary>
		/// Gets the user's permissions on the sheet.
		/// </summary>
		/// <returns> the access level </returns>
		public virtual AccessLevel? AccessLevel
		{
			get
			{
				return accessLevel;
			}
			set
			{
				this.accessLevel = value;
			}
		}


		/// <summary>
		/// Gets the Version number that is incremented every time a sheet is modified.
		/// </summary>
		/// <returns> the Version </returns>
		public virtual int? Version
		{
			get
			{
				return version;
			}
			set
			{
				this.version = value;
			}
		}


		/// <summary>
		/// Checks if the row is Expanded.
		/// </summary>
		/// <returns> true, if is Expanded </returns>
		public virtual bool? Expanded
		{
			get
			{
				return expanded;
			}
			set
			{
				this.expanded = value;
			}
		}


		/// <summary>
		/// Get a column by it's Index.
		/// </summary>
		/// <param name="index"> the column Index </param>
		/// <returns> the column by Index </returns>
		public virtual TColumn GetColumnByIndex(int index)
		{
			if (columns == null)
			{
				return null;
			}

			TColumn result = null;
			foreach (TColumn column in columns)
			{
				if (column.Index == index)
				{
					result = column;
					break;
				}
			}

			return result;
		}

		/// <summary>
		/// Get a column by it's ID.
		/// </summary>
		/// <param name="columnId"> the column Id </param>
		/// <returns> the column by Id </returns>
		public virtual TColumn GetColumnById(long columnId)
		{
			if (columns == null)
			{
				return null;
			}

			TColumn result = null;
			foreach (TColumn column in columns)
			{
				if (column.Id == columnId)
				{
					result = column;
					break;
				}
			}

			return result;
		}

		/// <summary>
		/// Gets the Id of the sheet.
		/// </summary>
		/// <returns> the sheet Id </returns>
		public virtual long? SheetId
		{
			get
			{
				return sheetId;
			}
			set
			{
				this.sheetId = value;
			}
		}


		/// <summary>
		/// Gets the row number.
		/// </summary>
		/// <returns> the row number </returns>
		public virtual int? RowNumber
		{
			get
			{
				return rowNumber;
			}
			set
			{
				this.rowNumber = value;
			}
		}


		/// <summary>
		/// Gets the parent row number.
		/// </summary>
		/// <returns> the parent row number </returns>
		public virtual int? ParentRowNumber
		{
			get
			{
				return parentRowNumber;
			}
			set
			{
				this.parentRowNumber = value;
			}
		}

		/// <summary>
		/// If this is a child row, the ID of the parent row, else omitted from response
		/// </summary>
		/// <returns> the ParentId </returns>
		public long? ParentId
		{
			get { return parentId; }
			set { parentId = value; }
		}

		/// <summary>
		/// The ID of the previous sibling row at the same hierarchical level of this row, if any, else omitted from response
		/// </summary>
		/// <returns> the SiblingId </returns>
		public long? SiblingId
		{
			get { return siblingId; }
			set { siblingId = value; }
		}


		/// <summary>
		/// Gets the Cells.
		/// </summary>
		/// <returns> the Cells </returns>
		public virtual IList<TCell> Cells
		{
			get
			{
				return cells;
			}
			set
			{
				this.cells = value;
			}
		}


		/// <summary>
		/// Gets the Discussions.
		/// </summary>
		/// <returns> the Discussions </returns>
		public virtual IList<Discussion> Discussions
		{
			get
			{
				return discussions;
			}
			set
			{
				this.discussions = value;
			}
		}


		/// <summary>
		/// Gets the Attachments.
		/// </summary>
		/// <returns> the Attachments </returns>
		public virtual IList<Attachment> Attachments
		{
			get
			{
				return attachments;
			}
			set
			{
				this.attachments = value;
			}
		}


		/// <summary>
		/// Gets the Columns.
		/// </summary>
		/// <returns> the Columns </returns>
		public virtual IList<TColumn> Columns
		{
			get
			{
				return columns;
			}
			set
			{
				this.columns = value;
			}
		}


		/// <summary>
		/// Gets the date and time a row was created.
		/// </summary>
		/// <returns> the created at </returns>
		public virtual DateTime? CreatedAt
		{
			get
			{
				return createdAt;
			}
			set
			{
				this.createdAt = value;
			}
		}


		/// <summary>
		/// Gets and Sets the date and time a row was last modified.
		/// </summary>
		/// <returns> the modified at </returns>
		public virtual DateTime? ModifiedAt
		{
			get
			{
				return modifiedAt;
			}
			set
			{
				this.modifiedAt = value;
			}
		}

		/// <summary>
		/// true if this row is filtered out by a column filter (and thus is not displayed in the Smartsheet app), 
		/// false if the row is not filtered out.
		/// Only returned if the include query string parameter contains filters.
		/// </summary>
		/// <returns> true if row is filtered out </returns>
		public bool? FilteredOut
		{
			get { return filteredOut; }
			set { filteredOut = value; }
		}

		/// <summary>
		/// true if the row is locked by the sheet owner or the admin. 
		/// Returned if the row is locked.
		/// </summary>
		/// <returns> true if row is locked </returns>
		public bool? Locked
		{
			get { return locked; }
			set { locked = value; }
		}

		/// <summary>
		/// True if the row is locked for the requesting user. 
		/// Returned if the row is locked.
		/// </summary>
		/// <returns> true if row is locked for user </returns>
		public bool? LockedForUser
		{
			get { return lockedForUser; }
			set { lockedForUser = value; }
		}

		/// <summary>
		/// Only returned if the include query string parameter contains format and 
		/// this row has a non-default format applied.
		/// </summary>
		/// <returns> the format </returns>
		public string Format
		{
			get { return format; }
			set { format = value; }
		}

		/// <summary>
		/// Format descriptor describing this row’s conditional format (see Formatting)
		///	Only returned if the include query string parameter contains format and this 
		///	row has a conditional format applied.
		/// </summary>
		/// <returns> the conditional format </returns>
		public string ConditionalFormat
		{
			get { return conditionalFormat; }
			set { conditionalFormat = value; }
		}

		/// <summary>
		/// Flag used to specify the location at which to create or move a row. 
		/// Indicates that the row should be added to the top of the sheet. 
		/// This attribute can be specified in a request, but will never be present in a response.
		/// </summary>
		/// <returns> true if row should be added to top </returns>
		public bool? ToTop
		{
			get { return toTop; }
			set { toTop = value; }
		}

		/// <summary>
		/// Flag used to specify the location at which to create or move a row. 
		/// Indicates that the row should be added to the bottom of the sheet, 
		/// or, if used in conjunction with parentId, added as the last child of the parent. 
		/// This attribute can be specified in a request, but will never be present in a response.
		/// </summary>
		/// <returns> true if row should be added to bottom </returns>
		public bool? ToBottom
		{
			get { return toBottom; }
			set { toBottom = value; }
		}

		/// <summary>
		/// Flag used to specify the location at which to create or move a row. 
		/// Optionally used in conjunction with siblingId with a value of true to 
		/// indicate that the row should be added above the specified sibling row. 
		/// This attribute can be specified in a request, but will never be present in a response.
		/// </summary>
		/// <returns> true if to be added above sibling row </returns>
		public bool? Above
		{
			get { return above; }
			set { above = value; }
		}

		/// <summary>
		/// User object containing name and email of the creator of this row
		/// </summary>
		/// <returns>User object</returns>
		public User CreatedBy
		{
			get { return createdBy; }
			set { createdBy = value; }
		}

		/// <summary>
		/// User object containing name and email of the last person to modify this row
		/// </summary>
		/// <returns>User object</returns>
		public User ModifiedBy
		{
			get { return modifiedBy; }
			set { modifiedBy = value; }
		}
		
		/// <summary>
		/// Only returned, with a value of true, 
		/// if the sheet is a project sheet with dependencies enabled 
		/// and this row is in the critical path.
		/// </summary>
		/// <returns> true if is in critical path </returns>
		public bool? InCriticalPath
		{
			get { return inCriticalPath; }
			set { inCriticalPath = value; }
		}

		/// <summary>
		/// URL that represents a direct link to the Row in Smartsheet 
		/// Only returned if the include query string parameter contains rowPermalink.
		/// </summary>
		public string Permalink
		{
			get { return permalink; }
			set { permalink = value; }
		}
	}
}