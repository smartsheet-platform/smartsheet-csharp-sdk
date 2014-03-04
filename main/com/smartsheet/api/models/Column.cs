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
	/// Represents the Column object.
	/// </summary>
	public class Column : IdentifiableModel
	{
		/// <summary>
		/// Represents the position.
		/// </summary>
		private int? index_Renamed;

		/// <summary>
		/// Represents the title.
		/// </summary>
		private string title_Renamed;

		/// <summary>
		/// Represents the primary flag.
		/// </summary>
		private bool? primary_Renamed;

		/// <summary>
		/// Represents the column type.
		/// </summary>
		private ColumnType? type_Renamed;

		/// <summary>
		/// Represents the list of options for the column.
		/// </summary>
		private IList<string> options_Renamed;

		/// <summary>
		/// Represents the hidden flag for the column.
		/// </summary>
		private bool? hidden_Renamed;

		/// <summary>
		/// Represents the symbol used for the column.
		/// </summary>
		private Symbol? symbol_Renamed;

		/// <summary>
		/// Represents the system column type.
		/// </summary>
		private SystemColumnType? systemColumnType_Renamed;

		/// <summary>
		/// Represents the format for the auto generated numbers (if the SystemColumnType is an AUTO_NUMBER).
		/// </summary>
		private AutoNumberFormat autoNumberFormat_Renamed;

		/// <summary>
		/// Represents the tags to indicate a special type of column.
		/// </summary>
		private IList<ColumnTag> tags_Renamed;

		/// <summary>
		/// Represents the sheet ID.
		/// </summary>
		private long? sheetId_Renamed;

		/// <summary>
		/// Gets the position of the column.
		/// </summary>
		/// <returns> the index </returns>
		public virtual int? GetIndex()
		{
			return index_Renamed;
		}

		/// <summary>
		/// Sets the position of the column.
		/// </summary>
		/// <param name="index"> the new index </param>
		public virtual void SetIndex(int index)
		{
			this.index_Renamed = index;
		}

		/// <summary>
		/// Gets the title for the column.
		/// </summary>
		/// <returns> the title </returns>
		public virtual string title
		{
			get
			{
				return title_Renamed;
			}
			set
			{
				this.title_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the primary flag for the column.
		/// </summary>
		/// <returns> the primary flag </returns>
		public virtual bool? primary
		{
			get
			{
				return primary_Renamed;
			}
			set
			{
				this.primary_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the column type.
		/// </summary>
		/// <returns> the type </returns>
		public virtual ColumnType? type
		{
			get
			{
				return type_Renamed;
			}
			set
			{
				this.type_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the list of options for the column.
		/// </summary>
		/// <returns> the options </returns>
		public virtual IList<string> options
		{
			get
			{
				return options_Renamed;
			}
			set
			{
				this.options_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the hidden flag.
		/// </summary>
		/// <returns> the hidden flag </returns>
		public virtual bool? hidden
		{
			get
			{
				return hidden_Renamed;
			}
			set
			{
				this.hidden_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the symbol for the column.
		/// </summary>
		/// <returns> the symbol </returns>
		public virtual Symbol? symbol
		{
			get
			{
				return symbol_Renamed;
			}
			set
			{
				this.symbol_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the system column type.
		/// </summary>
		/// <returns> the system column type </returns>
		public virtual SystemColumnType? systemColumnType
		{
			get
			{
				return systemColumnType_Renamed;
			}
			set
			{
				this.systemColumnType_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the format for the auto generated numbers.
		/// </summary>
		/// <returns> the auto number format </returns>
		public virtual AutoNumberFormat autoNumberFormat
		{
			get
			{
				return autoNumberFormat_Renamed;
			}
			set
			{
				this.autoNumberFormat_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the tags that indicate a special type of column.
		/// </summary>
		/// <returns> the tags </returns>
		public virtual IList<ColumnTag> tags
		{
			get
			{
				return tags_Renamed;
			}
			set
			{
				this.tags_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the sheet id.
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
		/// A convenience class to help create a column object with the appropriate fields for adding to a sheet.
		/// </summary>
		public class AddColumnToSheetBuilder
		{
			/// <summary>
			/// The title. </summary>
			internal string title_Renamed;

			/// <summary>
			/// The type. </summary>
			internal ColumnType? type_Renamed;

			/// <summary>
			/// The options. </summary>
			internal IList<string> options_Renamed;

			/// <summary>
			/// The symbol. </summary>
			internal Symbol? symbol_Renamed;

			/// <summary>
			/// The system column type. </summary>
			internal SystemColumnType? systemColumnType_Renamed;

			/// <summary>
			/// The auto number format. </summary>
			internal AutoNumberFormat autoNumberFormat_Renamed;

			internal bool? primary_Renamed;

			/// <summary>
			/// Gets the primary flag for the column.
			/// </summary>
			/// <returns> the primary flag </returns>
			public virtual bool? primary
			{
				get
				{
					return primary_Renamed;
				}
			}

			/// <summary>
			/// Sets the primary flag for the column.
			/// </summary>
			/// <param name="primary"> the new primary flag </param>
			public virtual AddColumnToSheetBuilder SetPrimary(bool? primary)
			{
				this.primary_Renamed = primary;
				return this;
			}

			/// <summary>
			/// Sets the title for the column.
			/// </summary>
			/// <param name="title"> the title </param>
			/// <returns> the adds the column to sheet builder </returns>
			public virtual AddColumnToSheetBuilder SetTitle(string title)
			{
				this.title_Renamed = title;
				return this;
			}

			/// <summary>
			/// Gets the title. </summary>
			/// <returns> the title </returns>
			public virtual string title
			{
				get
				{
					return title_Renamed;
				}
			}

			/// <summary>
			/// Sets the type for the column.
			/// </summary>
			/// <param name="type"> the type </param>
			/// <returns> the adds the column to sheet builder </returns>
			public virtual AddColumnToSheetBuilder SetType(ColumnType? type)
			{
				this.type_Renamed = type;
				return this;
			}

			/// <summary>
			/// Gets the type for the column. </summary>
			/// <returns> the type </returns>
			public virtual ColumnType? type
			{
				get
				{
					return type_Renamed;
				}
			}

			/// <summary>
			/// Sets the options for the column.
			/// </summary>
			/// <param name="options"> the options </param>
			/// <returns> the adds the column to sheet builder </returns>
			public virtual AddColumnToSheetBuilder SetOptions(IList<string> options)
			{
				this.options_Renamed = options;
				return this;
			}

			/// <summary>
			/// Gets the option for the column. </summary>
			/// <returns> the option </returns>
			public virtual IList<string> options
			{
				get
				{
					return options_Renamed;
				}
			}

			/// <summary>
			/// Sets the symbol for the column.
			/// </summary>
			/// <param name="symbol"> the symbol </param>
			/// <returns> the adds the column to sheet builder </returns>
			public virtual AddColumnToSheetBuilder SetSymbol(Symbol? symbol)
			{
				this.symbol_Renamed = symbol;
				return this;
			}

			/// <summary>
			/// Gets the symbol for the column. </summary>
			/// <returns> the symbol </returns>
			public virtual Symbol? symbol
			{
				get
				{
					return symbol_Renamed;
				}
			}

			/// <summary>
			/// Sets the system column type.
			/// </summary>
			/// <param name="systemColumnType"> the system column type </param>
			/// <returns> the adds the column to sheet builder </returns>
			public virtual AddColumnToSheetBuilder SetSystemColumnType(SystemColumnType? systemColumnType)
			{
				this.systemColumnType_Renamed = systemColumnType;
				return this;
			}

			/// <summary>
			/// Gets the system column type. </summary>
			/// <returns> the system column type </returns>
			public virtual SystemColumnType? systemColumnType
			{
				get
				{
					return systemColumnType_Renamed;
				}
			}

			/// <summary>
			/// Sets the format for an auto number column.
			/// </summary>
			/// <param name="autoNumberFormat"> the auto number format </param>
			/// <returns> the adds the column to sheet builder </returns>
			public virtual AddColumnToSheetBuilder SetAutoNumberFormat(AutoNumberFormat autoNumberFormat)
			{
				this.autoNumberFormat_Renamed = autoNumberFormat;
				return this;
			}

			/// <summary>
			/// Gets the format for an auto number column. </summary>
			/// <returns> the format for an auto number column </returns>
			public virtual AutoNumberFormat autoNumberFormat
			{
				get
				{
					return autoNumberFormat_Renamed;
				}
			}

			/// <summary>
			/// Builds the column.
			/// </summary>
			/// <returns> the column </returns>
			public virtual Column Build()
			{
				if (title_Renamed == null || type_Renamed == null)
				{
					throw new MemberAccessException();
				}

				Column column = new Column();
				column.title_Renamed = title_Renamed;
				column.type_Renamed = type_Renamed;
				column.options_Renamed = options_Renamed;
				column.symbol_Renamed = symbol_Renamed;
				column.primary_Renamed = primary_Renamed;
				column.systemColumnType_Renamed = systemColumnType_Renamed;
				column.autoNumberFormat_Renamed = autoNumberFormat_Renamed;
				return column;
			}
		}

		/// <summary>
		/// The Class ModifyColumnBuilder.
		/// </summary>
		public class ModifyColumnBuilder
		{
			/// <summary>
			/// The position of the column. </summary>
			internal int index_Renamed;

			/// <summary>
			/// The title for the column. </summary>
			internal string title_Renamed;

			/// <summary>
			/// The type of the column. </summary>
			internal ColumnType? type_Renamed;

			/// <summary>
			/// The options for the column. </summary>
			internal IList<string> options_Renamed;

			/// <summary>
			/// The symbol for the column. </summary>
			internal Symbol? symbol_Renamed;

			/// <summary>
			/// The system column type. </summary>
			internal SystemColumnType? systemColumnType_Renamed;

			/// <summary>
			/// The format for an auto number column. </summary>
			internal AutoNumberFormat autoNumberFormat_Renamed;

			/// <summary>
			/// The sheet id. </summary>
			internal long? sheetId_Renamed;

			/// <summary>
			/// Sets the position for the column.
			/// </summary>
			/// <param name="index"> the position </param>
			/// <returns> the modify column builder </returns>
			public virtual ModifyColumnBuilder SetIndex(int index)
			{
				this.index_Renamed = index;
				return this;
			}

			/// <summary>
			/// Sets the title for the column.
			/// </summary>
			/// <param name="title"> the title </param>
			/// <returns> the modify column builder </returns>
			public virtual ModifyColumnBuilder SetTitle(string title)
			{
				this.title_Renamed = title;
				return this;
			}

			/// <summary>
			/// Sets the type for the column.
			/// </summary>
			/// <param name="type"> the type </param>
			/// <returns> the modify column builder </returns>
			public virtual ModifyColumnBuilder SetType(ColumnType? type)
			{
				this.type_Renamed = type;
				return this;
			}

			/// <summary>
			/// Sets the options for the column.
			/// </summary>
			/// <param name="options"> the options </param>
			/// <returns> the modify column builder </returns>
			public virtual ModifyColumnBuilder SetOptions(IList<string> options)
			{
				this.options_Renamed = options;
				return this;
			}

			/// <summary>
			/// Sets the symbol for the column.
			/// </summary>
			/// <param name="symbol"> the symbol </param>
			/// <returns> the modify column builder </returns>
			public virtual ModifyColumnBuilder SetSymbol(Symbol? symbol)
			{
				this.symbol_Renamed = symbol;
				return this;
			}

			/// <summary>
			/// Sets the system column type for the column.
			/// </summary>
			/// <param name="systemColumnType"> the system column type </param>
			/// <returns> the modify column builder </returns>
			public virtual ModifyColumnBuilder SetSystemColumnType(SystemColumnType? systemColumnType)
			{
				this.systemColumnType_Renamed = systemColumnType;
				return this;
			}

			/// <summary>
			/// Sets the format for an auto number column.
			/// </summary>
			/// <param name="autoNumberFormat"> the auto number format </param>
			/// <returns> the modify column builder </returns>
			public virtual ModifyColumnBuilder SetAutoNumberFormat(AutoNumberFormat autoNumberFormat)
			{
				this.autoNumberFormat_Renamed = autoNumberFormat;
				return this;
			}

			/// <summary>
			/// Sets the sheet id.
			/// </summary>
			/// <param name="sheetId"> the sheet id </param>
			/// <returns> the modify column builder </returns>
			public virtual ModifyColumnBuilder SetSheetId(long? sheetId)
			{
				this.sheetId_Renamed = sheetId;
				return this;
			}

			/// <summary>
			/// Gets the index.
			/// </summary>
			/// <returns> the index </returns>
			public virtual int index
			{
				get
				{
					return index_Renamed;
				}
			}

			/// <summary>
			/// Gets the title.
			/// </summary>
			/// <returns> the title </returns>
			public virtual string title
			{
				get
				{
					return title_Renamed;
				}
			}

			/// <summary>
			/// Gets the type.
			/// </summary>
			/// <returns> the type </returns>
			public virtual ColumnType? type
			{
				get
				{
					return type_Renamed;
				}
			}

			/// <summary>
			/// Gets the options.
			/// </summary>
			/// <returns> the options </returns>
			public virtual IList<string> options
			{
				get
				{
					return options_Renamed;
				}
			}

			/// <summary>
			/// Gets the symbol.
			/// </summary>
			/// <returns> the symbol </returns>
			public virtual Symbol? symbol
			{
				get
				{
					return symbol_Renamed;
				}
			}

			/// <summary>
			/// Gets the system column type.
			/// </summary>
			/// <returns> the system column type </returns>
			public virtual SystemColumnType? systemColumnType
			{
				get
				{
					return systemColumnType_Renamed;
				}
			}

			/// <summary>
			/// Gets the auto number format.
			/// </summary>
			/// <returns> the auto number format </returns>
			public virtual AutoNumberFormat autoNumberFormat
			{
				get
				{
					return autoNumberFormat_Renamed;
				}
			}

			/// <summary>
			/// Gets the sheet id.
			/// </summary>
			/// <returns> the sheet id </returns>
			public virtual long? sheetId
			{
				get
				{
					return sheetId_Renamed;
				}
			}

			/// <summary>
			/// Builds the column.
			/// </summary>
			/// <returns> the column </returns>
			public virtual Column Build()
			{
				if (title_Renamed == null || sheetId_Renamed == null)
				{
					throw new MemberAccessException("A title and sheetId are required");
				}

				Column column = new Column();
				column.index_Renamed = index_Renamed;
				column.title_Renamed = title_Renamed;
				column.type_Renamed = type_Renamed;
				column.options_Renamed = options_Renamed;
				column.symbol_Renamed = symbol_Renamed;
				column.systemColumnType_Renamed = systemColumnType_Renamed;
				column.autoNumberFormat_Renamed = autoNumberFormat_Renamed;
				column.sheetId_Renamed = sheetId_Renamed;
				return column;
			}
		}
	}

}