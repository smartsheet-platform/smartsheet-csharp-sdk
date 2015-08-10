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
using System.Collections.Generic;

namespace Smartsheet.Api.Models
{
	public class Sheet : AbstractSheet<Row, Column, Cell>
	{
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
				if (column.Id == columnId)
				{
					result = column;
					break;
				}
			}
			return result;
		}

		/// <summary>
		/// A convenience class To make a <seealso cref="Sheet"/> object with the necessary fields To create the sheet by posting it 
		/// To Smartsheet.
		/// </summary>
		public class CreateSheetBuilder
		{
			private IList<Column> columns;
			private string name;

			/// <summary>
			/// Sets the required properties for creating a Sheet.
			/// </summary>
			/// <param name="name"> the name of the Sheet, need not be unique </param>
			/// <param name="columns"> list of columns </param>
			public CreateSheetBuilder(string name, IList<Column> columns)
			{
				this.name = name;
				this.columns = columns;
			}

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
			public virtual IList<Column> GetColumns()
			{

				return columns;

			}

			/// <summary>
			/// Returns the Name for the sheet.
			/// </summary>
			/// <returns> the Name </returns>
			public virtual string GetName()
			{

				return name;

			}

			/// <summary>
			/// Creates a sheet by using the values from setters in this builder.
			/// </summary>
			/// <returns> the sheet </returns>
			public virtual Sheet Build()
			{
				Sheet sheet = new Sheet();

				//if (columns == null || name == null)
				//{
				//	throw new InvalidOperationException();
				//}

				sheet.columns = columns;
				sheet.Name = name;
				return sheet;
			}
		}


		/// <summary>
		/// A class To simplify the creation of a Sheet from another Sheet or another Template.
		/// </summary>
		public class CreateSheetFromTemplateBuilder
		{
			private string name;
			private long? fromId;

			/// <summary>
			/// Sets the required propeties for creating a Sheet from a Sheet or Template.
			/// </summary>
			/// <param name="fromId">the ID of the Sheet or Template from which to create the Sheet</param>
			/// <param name="name"> the name of the Sheet, need not be unique </param>
			public CreateSheetFromTemplateBuilder(string name, long? fromId)
			{
				this.fromId = fromId;
				this.name = name;
			}

			/// <summary>
			/// Sets the Name for the sheet being created.
			/// </summary>
			/// <param name="name"> The Name for the sheet being created. </param>
			/// <returns> the creates the from template or sheet builder </returns>
			public virtual CreateSheetFromTemplateBuilder SetName(string name)
			{
				this.name = name;
				return this;
			}

			/// <summary>
			/// Returns the Name for the sheet.
			/// </summary>
			/// <returns> the Name </returns>
			public virtual string GetName()
			{
				return name;
			}

			/// <summary>
			/// Set the from Id.
			/// </summary>
			/// <param name="id"> the Id </param>
			/// <returns> the creates the from template or sheet builder </returns>
			public virtual CreateSheetFromTemplateBuilder SetFromId(long? id)
			{
				this.fromId = id;
				return this;
			}

			/// <summary>
			/// Gets the from Id.
			/// </summary>
			/// <returns> the from Id </returns>
			public virtual long? GetFromId()
			{
				return fromId;
			}

			/// <summary>
			/// Creates a sheet by using the values from setters in this builder.
			/// </summary>
			/// <returns> the sheet </returns>
			public virtual Sheet Build()
			{
				Sheet sheet = new Sheet();

				//if (fromId == null || name == null)
				//{
				//	throw new InvalidOperationException();
				//}

				sheet.FromId = fromId;
				sheet.Name = name;
				return sheet;
			}
		}


		/// <summary>
		/// The Class UpdateSheetBuilder.
		/// </summary>
		public class UpdateSheetBuilder
		{
			private string sheetName;
			private SheetUserSettings userSettings;

			/// <summary>
			/// Sets the Sheet Name.
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
			public virtual string GetName()
			{
				return sheetName;
			}

			/// <summary>
			/// Sets the Sheet's user settings.
			/// </summary>
			/// <param name="name"> the Name </param>
			/// <returns> the update sheet builder </returns>
			public virtual UpdateSheetBuilder SetUserSettings(SheetUserSettings userSettings)
			{
				this.userSettings = userSettings;
				return this;
			}

			/// <summary>
			/// Gets the sheet's user settings.
			/// </summary>
			/// <returns> the sheet Name </returns>
			public virtual SheetUserSettings GetUserSettings()
			{
				return userSettings;
			}

			/// <summary>
			/// Builds the Sheet.
			/// </summary>
			/// <returns> the sheet </returns>
			public virtual Sheet Build()
			{
				//if (sheetName == null)
				//{
				//	throw new InvalidOperationException();
				//}

				Sheet sheet = new Sheet();
				sheet.Name = this.sheetName;
				sheet.UserSettings = this.userSettings;
				//sheet.ID = id;
				return sheet;
			}
		}
	}
}