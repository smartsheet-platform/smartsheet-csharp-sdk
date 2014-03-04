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
	/// Represents the Sheet object.
	/// </summary>
	public class Sheet : NamedModel
	{
		/// <summary>
		/// Represents the columns for the sheet.
		/// </summary>
		private IList<Column> columns_Renamed;

		/// <summary>
		/// Represents the rows for the sheet.
		/// </summary>
		private IList<Row> rows_Renamed;

		/// <summary>
		/// Represents the access level for the sheet.
		/// </summary>
		private AccessLevel? accessLevel_Renamed;

		/// <summary>
		/// Represents the discussions for the sheet.
		/// </summary>
		private IList<Discussion> discussions_Renamed;

		/// <summary>
		/// Represents the attachments for the sheet.
		/// </summary>
		private IList<Attachment> attachments_Renamed;

		/// <summary>
		/// Represents the read only flag for the sheet.
		/// </summary>
		private bool? readOnly_Renamed;

		/// <summary>
		/// Represents the creation timestamp for the sheet.
		/// </summary>
		private DateTime? createdAt_Renamed;

		/// <summary>
		/// Represents the modification timestamp for the sheet.
		/// </summary>
		private DateTime? modifiedAt_Renamed;

		/// <summary>
		/// Represents the direct URL to the sheet.
		/// </summary>
		private string permalink_Renamed;

		/// <summary>
		/// Represents the Gantt enabled flag.
		/// </summary>
		private bool? ganttEnabled_Renamed;

		/// <summary>
		/// Represents the dependencies enabled flag. </summary>
		/// <seealso cref= <a href="http://help.smartsheet.com/customer/portal/articles/765727-using-the-dependencies-functionality">
		/// Dependencies Functionality</a> </seealso>
		private bool? dependenciesEnabled_Renamed;

		/// <summary>
		/// Represents the version for the sheet
		/// </summary>
		private int? version_Renamed;

		/// <summary>
		/// Represents the ID of the sheet/template from which the sheet was created.
		/// </summary>
		private long? fromId_Renamed;

		/// <summary>
		/// Gets the dependencies enabled flag.
		/// </summary>
		/// <returns> the dependencies enabled </returns>
		public virtual bool? dependenciesEnabled
		{
			get
			{
				return dependenciesEnabled_Renamed;
			}
			set
			{
				this.dependenciesEnabled_Renamed = value;
			}
		}


		/// <summary>
		/// Get a column by index.
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
		/// Get a <seealso cref="Column"/> by ID.
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
		/// Get a <seealso cref="Row"/> by row number.
		/// </summary>
		/// <param name="rowNumber"> the row number </param>
		/// <returns> the row by row number </returns>
		public virtual Row GetRowByRowNumber(int rowNumber)
		{
			if (rows_Renamed == null)
			{
				return null;
			}

			Row result = null;
			foreach (Row row in rows_Renamed)
			{
				if (row.rowNumber == rowNumber)
				{
					result = row;
					break;
				}
			}
			return result;
		}

		/// <summary>
		/// Gets the columns for the sheet.
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
		/// Gets the rows for the sheet.
		/// </summary>
		/// <returns> the rows </returns>
		public virtual IList<Row> rows
		{
			get
			{
				return rows_Renamed;
			}
			set
			{
				this.rows_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the access level for the sheet.
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
		/// Gets the discussions for the sheet.
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
		/// Gets the attachments for the sheet.
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
		/// Gets the read only flag for the sheet.
		/// </summary>
		/// <returns> the read only </returns>
		public virtual bool? readOnly
		{
			get
			{
				return readOnly_Renamed;
			}
			set
			{
				this.readOnly_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the date and time the sheet was created.
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
		/// Gets the date and time the sheet was last modified.
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


		/// <summary>
		/// Gets the permalink for the sheet.
		/// </summary>
		/// <returns> the permalink </returns>
		public virtual string permalink
		{
			get
			{
				return permalink_Renamed;
			}
			set
			{
				this.permalink_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the gantt enabled flag.
		/// </summary>
		/// <returns> the gantt enabled flag </returns>
		public virtual bool? ganttEnabled
		{
			get
			{
				return ganttEnabled_Renamed;
			}
			set
			{
				this.ganttEnabled_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the version for the sheet.
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
		/// Gets the ID of the sheet/template from which the sheet was created.
		/// </summary>
		/// <returns> the from id </returns>
		public virtual long? fromId
		{
			get
			{
				return fromId_Renamed;
			}
			set
			{
				this.fromId_Renamed = value;
			}
		}


		/// <summary>
		/// A convenience class to make a <seealso cref="Sheet"/> object with the necessary fields to create the sheet by posting it 
		/// to smartsheet.
		/// </summary>
		public class CreateSheetBuilder
		{
			internal IList<Column> columns_Renamed;
			internal string name_Renamed;

			/// <summary>
			/// Sets the columns for the sheet being created.
			/// </summary>
			/// <param name="columns"> The columns to create with this sheet. </param>
			/// <returns> the creates the builder </returns>
			public virtual CreateSheetBuilder SetColumns(IList<Column> columns)
			{
				this.columns_Renamed = columns;
				return this;
			}

			/// <summary>
			/// Sets the name for the sheet being created.
			/// </summary>
			/// <param name="name"> The name for the sheet being created. </param>
			/// <returns> the creates the builder </returns>
			public virtual CreateSheetBuilder SetName(string name)
			{
				this.name_Renamed = name;
				return this;
			}

			/// <summary>
			/// Returns the list of columns.
			/// </summary>
			/// <returns> the columns </returns>
			public virtual IList<Column> columns
			{
				get
				{
					return columns_Renamed;
				}
			}

			/// <summary>
			/// Returns the name for the sheet.
			/// </summary>
			/// <returns> the name </returns>
			public virtual string name
			{
				get
				{
					return name_Renamed;
				}
			}

			/// <summary>
			/// Creates a sheet by using the values from setters in this builder.
			/// </summary>
			/// <returns> the sheet </returns>
			public virtual Sheet Build()
			{
				Sheet sheet = new Sheet();

				if (columns_Renamed == null || name_Renamed == null)
				{
					throw new InvalidOperationException();
				}

				sheet.columns = columns_Renamed;
				sheet.name = name_Renamed;
				return sheet;
			}
		}


		/// <summary>
		/// A class to simplify the creation of a sheet from another sheet or another template.
		/// @author brett
		/// 
		/// </summary>
		public class CreateFromTemplateOrSheetBuilder
		{
			internal string name_Renamed;
			internal long? fromId_Renamed;

			/// <summary>
			/// Sets the name for the sheet being created.
			/// </summary>
			/// <param name="name"> The name for the sheet being created. </param>
			/// <returns> the creates the from template or sheet builder </returns>
			public virtual CreateFromTemplateOrSheetBuilder SetName(string name)
			{
				this.name_Renamed = name;
				return this;
			}

			/// <summary>
			/// Returns the name for the sheet.
			/// </summary>
			/// <returns> the name </returns>
			public virtual string name
			{
				get
				{
					return name_Renamed;
				}
			}

			/// <summary>
			/// Set the from Id.
			/// </summary>
			/// <param name="id"> the id </param>
			/// <returns> the creates the from template or sheet builder </returns>
			public virtual CreateFromTemplateOrSheetBuilder SetFromId(long? id)
			{
				this.fromId_Renamed = id;
				return this;
			}

			/// <summary>
			/// Gets the from id.
			/// </summary>
			/// <returns> the from id </returns>
			public virtual long? fromId
			{
				get
				{
					return fromId_Renamed;
				}
			}

			/// <summary>
			/// Creates a sheet by using the values from setters in this builder.
			/// </summary>
			/// <returns> the sheet </returns>
			public virtual Sheet Build()
			{
				Sheet sheet = new Sheet();

				if (fromId_Renamed == null || name_Renamed == null)
				{
					throw new InvalidOperationException();
				}

				sheet.fromId = fromId_Renamed;
				sheet.name = name_Renamed;
				return sheet;
			}
		}


		/// <summary>
		/// The Class UpdateSheetBuilder.
		/// </summary>
		public class UpdateSheetBuilder
		{
			internal string sheetName;
			internal long? id_Renamed;

			/// <summary>
			/// Get the id of the sheet
			/// @return
			/// </summary>
			public virtual long? id
			{
				get
				{
					return id_Renamed;
				}
			}

			/// <summary>
			/// Set the sheet id </summary>
			/// <param name="id"> </param>
			/// <returns> the updateSheetBuilder object </returns>
			public virtual UpdateSheetBuilder SetId(long? id)
			{
				this.id_Renamed = id;
				return this;
			}

			/// <summary>
			/// Name.
			/// </summary>
			/// <param name="name"> the name </param>
			/// <returns> the update sheet builder </returns>
			public virtual UpdateSheetBuilder SetName(string name)
			{
				this.sheetName = name;
				return this;
			}

			/// <summary>
			/// Gets the sheet name.
			/// </summary>
			/// <returns> the sheet name </returns>
			public virtual string name
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
				sheet.name = sheetName;
				sheet.id = id_Renamed;
				return sheet;
			}
		}
	}

}