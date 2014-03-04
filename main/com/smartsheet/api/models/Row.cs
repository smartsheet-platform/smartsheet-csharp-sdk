using System;
using System.Collections.Generic;

namespace com.smartsheet.api.models
{

	/*
	 * #[license]
	 * Smartsheet SDK for C#
	 * %%
	 * Copyright (C) 2014 Smartsheet
	 * %%
	 * Licensed under the Apache License, Version 2.0 (the "License");
	 * you may not use this file except in compliance with the License.
	 * You may obtain a copy of the License at
	 * 
	 *      http://www.apache.org/licenses/LICENSE-2.0
	 * 
	 * Unless required by applicable law or agreed to in writing, software
	 * distributed under the License is distributed on an "AS IS" BASIS,
	 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
	 * See the License for the specific language governing permissions and
	 * limitations under the License.
	 * %[license]
	 */


	/// <summary>
	/// Represents the Row object.
	/// </summary>
	public class Row : IdentifiableModel
	{
		/// <summary>
		/// Represents the Sheet ID. </summary>
		private long? sheetId_Renamed;

		/// <summary>
		/// Represents the row number. </summary>
		private int? rowNumber_Renamed;

		/// <summary>
		/// Represents the parent row number. </summary>
		private int? parentRowNumber_Renamed;

		/// <summary>
		/// Represents the cells for this row. </summary>
		private IList<Cell> cells_Renamed;

		/// <summary>
		/// Represents the discussions for this row. </summary>
		private IList<Discussion> discussions_Renamed;

		/// <summary>
		/// Represents the attachments for this row. </summary>
		private IList<Attachment> attachments_Renamed;

		/// <summary>
		/// Represents the columns for this row. </summary>
		private IList<Column> columns_Renamed;

		/// <summary>
		/// Represents the date and time the row was created. </summary>
		private DateTime? createdAt_Renamed;

		/// <summary>
		/// Represents the date and time the row was modified. </summary>
		private DateTime? modifiedAt_Renamed;

		/// <summary>
		/// A read-only flag to indicate if the row is expanded or collapsed. </summary>
		private bool? expanded_Renamed;

		/// <summary>
		/// The version number that is incremented every time a sheet is modified. </summary>
		private int? version_Renamed;

		/// <summary>
		/// The user's permissions on the sheet. </summary>
		private AccessLevel? accessLevel_Renamed;

		/// <summary>
		/// Gets the user's permissions on the sheet.
		/// </summary>
		/// <returns> the access level </returns>
		public virtual AccessLevel? accessLevel
		{
			get
			{
				return accessLevel_Renamed;
			}
			set
			{
				this.accessLevel_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the version number that is incremented every time a sheet is modified.
		/// </summary>
		/// <returns> the version </returns>
		public virtual int? version
		{
			get
			{
				return version_Renamed;
			}
			set
			{
				this.version_Renamed = value;
			}
		}


		/// <summary>
		/// Checks if the row is expanded.
		/// </summary>
		/// <returns> true, if is expanded </returns>
		public virtual bool? expanded
		{
			get
			{
				return expanded_Renamed;
			}
			set
			{
				this.expanded_Renamed = value;
			}
		}


		/// <summary>
		/// Get a column by it's index.
		/// </summary>
		/// <param name="index"> the column index </param>
		/// <returns> the column by index </returns>
		public virtual Column GetColumnByIndex(int index)
		{
			if (columns_Renamed == null)
			{
				return null;
			}

			Column result = null;
			foreach (Column column in columns_Renamed)
			{
				if (column.GetIndex() == index)
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
		/// <param name="columnId"> the column id </param>
		/// <returns> the column by id </returns>
		public virtual Column GetColumnById(long columnId)
		{
			if (columns_Renamed == null)
			{
				return null;
			}

			Column result = null;
			foreach (Column column in columns_Renamed)
			{
				if (column.id == columnId)
				{
					result = column;
					break;
				}
			}

			return result;
		}

		/// <summary>
		/// Gets the id of the sheet.
		/// </summary>
		/// <returns> the sheet id </returns>
		public virtual long? sheetId
		{
			get
			{
				return sheetId_Renamed;
			}
			set
			{
				this.sheetId_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the row number.
		/// </summary>
		/// <returns> the row number </returns>
		public virtual int? rowNumber
		{
			get
			{
				return rowNumber_Renamed;
			}
			set
			{
				this.rowNumber_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the parent row number.
		/// </summary>
		/// <returns> the parent row number </returns>
		public virtual int? parentRowNumber
		{
			get
			{
				return parentRowNumber_Renamed;
			}
			set
			{
				this.parentRowNumber_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the cells.
		/// </summary>
		/// <returns> the cells </returns>
		public virtual IList<Cell> cells
		{
			get
			{
				return cells_Renamed;
			}
			set
			{
				this.cells_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the discussions.
		/// </summary>
		/// <returns> the discussions </returns>
		public virtual IList<Discussion> discussions
		{
			get
			{
				return discussions_Renamed;
			}
			set
			{
				this.discussions_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the attachments.
		/// </summary>
		/// <returns> the attachments </returns>
		public virtual IList<Attachment> attachments
		{
			get
			{
				return attachments_Renamed;
			}
			set
			{
				this.attachments_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the columns.
		/// </summary>
		/// <returns> the columns </returns>
		public virtual IList<Column> columns
		{
			get
			{
				return columns_Renamed;
			}
			set
			{
				this.columns_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the date and time a row was created.
		/// </summary>
		/// <returns> the created at </returns>
		public virtual DateTime? createdAt
		{
			get
			{
				return createdAt_Renamed;
			}
			set
			{
				this.createdAt_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the date and time a row was modified.
		/// </summary>
		/// <returns> the modified at </returns>
		public virtual DateTime? modifiedAt
		{
			get
			{
				return modifiedAt_Renamed;
			}
			set
			{
				this.modifiedAt_Renamed = value;
			}
		}

	}

}