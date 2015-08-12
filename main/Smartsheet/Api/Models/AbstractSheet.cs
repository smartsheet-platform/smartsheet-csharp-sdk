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
	/// Represents the Sheet object.
	/// </summary>
	public abstract class AbstractSheet<TRow, TColumn, TCell> : NamedModel
		where TRow : AbstractRow<TColumn, TCell>
		where TColumn : Column
		where TCell : Cell
	{
		/// <summary>
		/// Represents the Columns for the sheet.
		/// </summary>
		protected IList<TColumn> columns;

		/// <summary>
		/// Represents the Rows for the sheet.
		/// </summary>
		protected IList<TRow> rows;

		/// <summary>
		/// Represents the access level for the sheet.
		/// </summary>
		private AccessLevel? accessLevel;

		/// <summary>
		/// Represents the Discussions for the sheet.
		/// </summary>
		private IList<Discussion> discussions;

		/// <summary>
		/// Represents the Attachments for the sheet.
		/// </summary>
		private IList<Attachment> attachments;

		/// <summary>
		/// Represents the read only flag for the sheet.
		/// </summary>
		private bool? readOnly;

		/// <summary>
		/// Represents the creation timestamp for the sheet.
		/// </summary>
		private DateTime? createdAt;

		/// <summary>
		/// Represents the modification timestamp for the sheet.
		/// </summary>
		private DateTime? modifiedAt;

		/// <summary>
		/// Represents the direct URL To the sheet.
		/// </summary>
		private string permalink;

		/// <summary>
		/// Represents the Gantt enabled flag.
		/// </summary>
		private bool? ganttEnabled;

		/// <summary>
		/// Represents the dependencies enabled flag. </summary>
		/// <seealso href="http://help.Smartsheet.com/customer/portal/articles/765727-using-the-dependencies-functionality">
		/// Dependencies Functionality</seealso>
		private bool? dependenciesEnabled;

		/// <summary>
		/// Represents the Version for the sheet
		/// </summary>
		private int? version;

		/// <summary>
		/// Represents the ID of the sheet/template from which the sheet was created.
		/// </summary>
		private long? fromId;

		/// <summary>
		/// Represents the ID of the sheet/template from which the sheet was created.
		/// </summary>
		private long? totalRowCount;

		private IList<AttachmentType> effectiveAttachmentOptions;

		private bool? resourceManagementEnabled;

		private bool? favorite;

		private bool? showParentRowsForFilters;

		private SheetUserSettings userSettings;

		private Source source;

		private string owner;

		private long? ownerId;


		/// <summary>
		/// Represents the email of the owner
		/// </summary>
		public string Owner
		{
			get { return owner; }
			set { owner = value; }
		}

		/// <summary>
		/// Represents the Id of the Owner
		/// </summary>
		public long? OwnerId
		{
			get { return ownerId; }
			set { ownerId = value; }
		}


		/// <summary>
		/// Gets the dependencies enabled flag.
		/// </summary>
		/// <returns> the dependencies enabled </returns>
		public virtual bool? DependenciesEnabled
		{
			get
			{
				return dependenciesEnabled;
			}
			set
			{
				this.dependenciesEnabled = value;
			}
		}


		/// <summary>
		/// Get a column by Index.
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
		/// Get a <seealso cref="Row"/> by row number.
		/// </summary>
		/// <param name="rowNumber"> the row number </param>
		/// <returns> the row by row number </returns>
		public virtual TRow GetRowByRowNumber(int rowNumber)
		{
			if (rows == null)
			{
				return null;
			}

			TRow result = null;
			foreach (TRow row in rows)
			{
				if (row.RowNumber == rowNumber)
				{
					result = row;
					break;
				}
			}
			return result;
		}

		/// <summary>
		/// Gets the Columns for the sheet.
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
		/// Gets the Rows for the sheet.
		/// </summary>
		/// <returns> the Rows </returns>
		public virtual IList<TRow> Rows
		{
			get
			{
				return rows;
			}
			set
			{
				this.rows = value;
			}
		}


		/// <summary>
		/// Gets the access level for the sheet.
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
		/// Gets the Discussions for the sheet.
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
		/// Gets the Attachments for the sheet.
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
		/// Gets the read only flag for the sheet.
		/// </summary>
		/// <returns> the read only </returns>
		public virtual bool? ReadOnly
		{
			get
			{
				return readOnly;
			}
			set
			{
				this.readOnly = value;
			}
		}


		/// <summary>
		/// Gets the date and time the sheet was created.
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
		/// Gets the date and time the sheet was last modified.
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
		/// Gets the Permalink for the sheet.
		/// </summary>
		/// <returns> the Permalink </returns>
		public virtual string Permalink
		{
			get
			{
				return permalink;
			}
			set
			{
				this.permalink = value;
			}
		}


		/// <summary>
		/// Gets the gantt enabled flag.
		/// </summary>
		/// <returns> the gantt enabled flag </returns>
		public virtual bool? GanttEnabled
		{
			get
			{
				return ganttEnabled;
			}
			set
			{
				this.ganttEnabled = value;
			}
		}


		/// <summary>
		/// Gets the Version for the sheet.
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
		/// Gets the ID of the sheet/template from which the sheet was created.
		/// </summary>
		/// <returns> the from Id </returns>
		public virtual long? FromId
		{
			get
			{
				return fromId;
			}
			set
			{
				this.fromId = value;
			}
		}


		/// <summary>
		/// The total number of rows in the Sheet.
		/// </summary>
		/// <returns> The total number of rows in the Sheet </returns>
		public virtual long? TotalRowCount
		{
			get { return totalRowCount; }
			set { totalRowCount = value; }
		}


		/// <summary>
		/// Array of enum strings (see Attachment.attachmentType) indicating the allowable attachment options for the current User and Sheet
		/// </summary>
		/// <returns> list tof attachment types </returns>
		public virtual IList<AttachmentType> EffectiveAttachmentOptions
		{
			get { return effectiveAttachmentOptions; }
			set { effectiveAttachmentOptions = value; }
		}


		/// <summary>
		/// Flag to indicate that resource management is enabled.
		/// </summary>
		/// <returns> true if enabled, false otherwise </returns>
		public virtual bool? ResourceManagementEnabled
		{
			get { return resourceManagementEnabled; }
			set { resourceManagementEnabled = value; }
		}


		/// <summary>
		/// Returned only if the User has marked this sheet as a favorite in their Home tab (value = “true”).
		/// </summary>
		/// <returns> true if marked as favorite, false otherwise </returns>
		public virtual bool? Favorite
		{
			get { return favorite; }
			set { favorite = value; }
		}


		/// <summary>
		/// Returned only if there are column filters on the Sheet. Value = “true” if “show parent rows” is enabled for the filters.
		/// </summary>
		/// <returns> “true” if “show parent rows” is enabled for the filters </returns>
		public virtual bool? ShowParentRowsForFilters
		{
			get { return showParentRowsForFilters; }
			set { showParentRowsForFilters = value; }
		}


		/// <summary>
		/// A SheetUserSettings object containing the current user’s sheet-specific settings..
		/// </summary>
		/// <returns> SheetUserSettings object </returns>
		public virtual SheetUserSettings UserSettings
		{
			get { return userSettings; }
			set { userSettings = value; }
		}


		/// <summary>
		/// A Source object indicating the Sheet or Template from which this sheet was created.
		/// </summary>
		/// <returns> source of sheet </returns>
		public virtual Source Source
		{
			get { return source; }
			set { source = value; }
		}
	}
}