//    #[license]
//    Smartsheet SDK for C#
//    %%
//    Copyright (C) 2014 Smartsheet
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
using System.Collections.Generic;

namespace Smartsheet.Api.Models
{

	/// <summary>
	/// Represents the Sheet object.
	/// </summary>
	public class Sheet : NamedModel
	{
		/// <summary>
		/// Represents the Columns for the sheet.
		/// </summary>
		private IList<Column> columns;

		/// <summary>
		/// Represents the Rows for the sheet.
		/// </summary>
		private IList<Row> rows;

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
		public virtual Column GetColumnByIndex(int index)
		{
			if (columns == null)
			{
				return null;
			}

			Column result = null;
			foreach (Column column in columns)
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
		/// Get a <seealso cref="Column"/> by ID.
		/// </summary>
		/// <param name="columnId"> the column Id </param>
		/// <returns> the column by Id </returns>
		public virtual Column GetColumnById(long columnId)
		{
			if (columns == null)
			{
				return null;
			}

			Column result = null;
			foreach (Column column in columns)
			{
				if (column.ID == columnId)
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
		public virtual Row GetRowByRowNumber(int rowNumber)
		{
			if (rows == null)
			{
				return null;
			}

			Row result = null;
			foreach (Row row in rows)
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
		public virtual IList<Column> Columns
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
		public virtual IList<Row> Rows
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
		/// A convenience class To make a <seealso cref="Sheet"/> object with the necessary fields To create the sheet by posting it 
		/// To Smartsheet.
		/// </summary>
		public class CreateSheetBuilder
		{
			internal IList<Column> columns;
			internal string name;

			/// <summary>
			/// Sets the Columns for the sheet being created.
			/// </summary>
			/// <param name="columns"> The Columns To create with this sheet. </param>
			/// <returns> the creates the builder </returns>
			public virtual CreateSheetBuilder SetColumns(IList<Column> columns)
			{
				this.columns = columns;
				return this;
			}

			/// <summary>
			/// Sets the Name for the sheet being created.
			/// </summary>
			/// <param name="name"> The Name for the sheet being created. </param>
			/// <returns> the creates the builder </returns>
			public virtual CreateSheetBuilder SetName(string name)
			{
				this.name = name;
				return this;
			}

			/// <summary>
			/// Returns the list of Columns.
			/// </summary>
			/// <returns> the Columns </returns>
			public virtual IList<Column> Columns
			{
				get
				{
					return columns;
				}
			}

			/// <summary>
			/// Returns the Name for the sheet.
			/// </summary>
			/// <returns> the Name </returns>
			public virtual string Name
			{
				get
				{
					return name;
				}
			}

			/// <summary>
			/// Creates a sheet by using the values from setters in this builder.
			/// </summary>
			/// <returns> the sheet </returns>
			public virtual Sheet Build()
			{
				Sheet sheet = new Sheet();

				if (columns == null || name == null)
				{
					throw new InvalidOperationException();
				}

				sheet.columns = columns;
				sheet.Name = name;
				return sheet;
			}
		}


		/// <summary>
		/// A class To simplify the creation of a sheet from another sheet or another template.
		/// @author brett
		/// 
		/// </summary>
		public class CreateFromTemplateOrSheetBuilder
		{
			internal string name;
			internal long? fromId;

			/// <summary>
			/// Sets the Name for the sheet being created.
			/// </summary>
			/// <param name="name"> The Name for the sheet being created. </param>
			/// <returns> the creates the from template or sheet builder </returns>
			public virtual CreateFromTemplateOrSheetBuilder SetName(string name)
			{
				this.name = name;
				return this;
			}

			/// <summary>
			/// Returns the Name for the sheet.
			/// </summary>
			/// <returns> the Name </returns>
			public virtual string Name
			{
				get
				{
					return name;
				}
			}

			/// <summary>
			/// Set the from Id.
			/// </summary>
			/// <param name="id"> the Id </param>
			/// <returns> the creates the from template or sheet builder </returns>
			public virtual CreateFromTemplateOrSheetBuilder SetFromId(long? id)
			{
				this.fromId = id;
				return this;
			}

			/// <summary>
			/// Gets the from Id.
			/// </summary>
			/// <returns> the from Id </returns>
			public virtual long? FromId
			{
				get
				{
					return fromId;
				}
			}

			/// <summary>
			/// Creates a sheet by using the values from setters in this builder.
			/// </summary>
			/// <returns> the sheet </returns>
			public virtual Sheet Build()
			{
				Sheet sheet = new Sheet();

				if (fromId == null || name == null)
				{
					throw new InvalidOperationException();
				}

				sheet.fromId = fromId;
				sheet.Name = name;
				return sheet;
			}
		}


		/// <summary>
		/// The Class UpdateSheetBuilder.
		/// </summary>
		public class UpdateSheetBuilder
		{
			internal string sheetName;
			internal long? id;

			/// <summary>
			/// Get the Id of the sheet
			/// @return
			/// </summary>
			public virtual long? ID
			{
				get
				{
					return id;
				}
			}

			/// <summary>
			/// Set the sheet Id </summary>
			/// <param name="id"> </param>
			/// <returns> the updateSheetBuilder object </returns>
			public virtual UpdateSheetBuilder SetID(long? id)
			{
				this.id = id;
				return this;
			}

			/// <summary>
			/// Name.
			/// </summary>
			/// <param name="name"> the Name </param>
			/// <returns> the update sheet builder </returns>
			public virtual UpdateSheetBuilder SetName(string name)
			{
				this.sheetName = name;
				return this;
			}

			/// <summary>
			/// Gets the sheet Name.
			/// </summary>
			/// <returns> the sheet Name </returns>
			public virtual string Name
			{
				get
				{
					return sheetName;
				}
			}


			/// <summary>
			/// Builds the.
			/// </summary>
			/// <returns> the sheet </returns>
			public virtual Sheet Build()
			{
				if (sheetName == null)
				{
					throw new InvalidOperationException();
				}

				Sheet sheet = new Sheet();
				sheet.Name = sheetName;
				sheet.ID = id;
				return sheet;
			}
		}
	}

}