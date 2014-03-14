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
	/// Represents the Column object.
	/// </summary>
	public class Column : IdentifiableModel
	{
		/// <summary>
		/// Represents the position.
		/// </summary>
		private int? index;

		/// <summary>
		/// Represents the Title.
		/// </summary>
		private string title;

		/// <summary>
		/// Represents the Primary flag.
		/// </summary>
		private bool? primary;

		/// <summary>
		/// Represents the column Type.
		/// </summary>
		private ColumnType? type;

		/// <summary>
		/// Represents the list of Options for the column.
		/// </summary>
		private IList<string> options;

		/// <summary>
		/// Represents the Hidden flag for the column.
		/// </summary>
		private bool? hidden;

		/// <summary>
		/// Represents the Symbol used for the column.
		/// </summary>
		private Symbol? symbol;

		/// <summary>
		/// Represents the system column Type.
		/// </summary>
		private SystemColumnType? systemColumnType;

		/// <summary>
		/// Represents the Format for the auto generated numbers (if the SystemColumnType is an AUTO_NUMBER).
		/// </summary>
		private AutoNumberFormat autoNumberFormat;

		/// <summary>
		/// Represents the Tags To indicate a special Type of column.
		/// </summary>
		private IList<ColumnTag> tags;

		/// <summary>
		/// Represents the sheet ID.
		/// </summary>
		private long? sheetId;

		/// <summary>
		/// Gets or Sets the position of the column.
		/// </summary>
		/// <returns> the Index </returns>
		public virtual int? Index
		{
            get 
            {
                return index;
            }
            set
            {
                this.index = value;
            }
		}

		/// <summary>
		/// Gets the Title for the column.
		/// </summary>
		/// <returns> the Title </returns>
		public virtual string Title
		{
			get
			{
				return title;
			}
			set
			{
				this.title = value;
			}
		}


		/// <summary>
		/// Gets the Primary flag for the column.
		/// </summary>
		/// <returns> the Primary flag </returns>
		public virtual bool? Primary
		{
			get
			{
				return primary;
			}
			set
			{
				this.primary = value;
			}
		}


		/// <summary>
		/// Gets the column Type.
		/// </summary>
		/// <returns> the Type </returns>
		public virtual ColumnType? Type
		{
			get
			{
				return type;
			}
			set
			{
				this.type = value;
			}
		}


		/// <summary>
		/// Gets the list of Options for the column.
		/// </summary>
		/// <returns> the Options </returns>
		public virtual IList<string> Options
		{
			get
			{
				return options;
			}
			set
			{
				this.options = value;
			}
		}


		/// <summary>
		/// Gets the Hidden flag.
		/// </summary>
		/// <returns> the Hidden flag </returns>
		public virtual bool? Hidden
		{
			get
			{
				return hidden;
			}
			set
			{
				this.hidden = value;
			}
		}


		/// <summary>
		/// Gets the Symbol for the column.
		/// </summary>
		/// <returns> the Symbol </returns>
		public virtual Symbol? Symbol
		{
			get
			{
				return symbol;
			}
			set
			{
				this.symbol = value;
			}
		}


		/// <summary>
		/// Gets the system column Type.
		/// </summary>
		/// <returns> the system column Type </returns>
		public virtual SystemColumnType? SystemColumnType
		{
			get
			{
				return systemColumnType;
			}
			set
			{
				this.systemColumnType = value;
			}
		}


		/// <summary>
		/// Gets the Format for the auto generated numbers.
		/// </summary>
		/// <returns> the auto number Format </returns>
		public virtual AutoNumberFormat AutoNumberFormat
		{
			get
			{
				return autoNumberFormat;
			}
			set
			{
				this.autoNumberFormat = value;
			}
		}


		/// <summary>
		/// Gets the Tags that indicate a special Type of column.
		/// </summary>
		/// <returns> the Tags </returns>
		public virtual IList<ColumnTag> Tags
		{
			get
			{
				return tags;
			}
			set
			{
				this.tags = value;
			}
		}


		/// <summary>
		/// Gets the sheet Id.
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
		/// A convenience class To help create a column object with the appropriate fields for adding To a sheet.
		/// </summary>
		public class AddColumnToSheetBuilder
		{
			/// <summary>
			/// The Title. </summary>
			internal string title;

			/// <summary>
			/// The Type. </summary>
			internal ColumnType? type;

			/// <summary>
			/// The Options. </summary>
			internal IList<string> options;

			/// <summary>
			/// The Symbol. </summary>
			internal Symbol? symbol;

			/// <summary>
			/// The system column Type. </summary>
			internal SystemColumnType? systemColumnType;

			/// <summary>
			/// The auto number Format. </summary>
			internal AutoNumberFormat autoNumberFormat;

			internal bool? primary;

			/// <summary>
			/// Gets the Primary flag for the column.
			/// </summary>
			/// <returns> the Primary flag </returns>
			public virtual bool? Primary
			{
				get
				{
					return primary;
				}
			}

			/// <summary>
			/// Sets the Primary flag for the column.
			/// </summary>
			/// <param name="primary"> the new Primary flag </param>
			public virtual AddColumnToSheetBuilder SetPrimary(bool? primary)
			{
				this.primary = primary;
				return this;
			}

			/// <summary>
			/// Sets the Title for the column.
			/// </summary>
			/// <param name="title"> the Title </param>
			/// <returns> the adds the column To sheet builder </returns>
			public virtual AddColumnToSheetBuilder SetTitle(string title)
			{
				this.title = title;
				return this;
			}

			/// <summary>
			/// Gets the Title. </summary>
			/// <returns> the Title </returns>
			public virtual string Title
			{
				get
				{
					return title;
				}
			}

			/// <summary>
			/// Sets the Type for the column.
			/// </summary>
			/// <param name="type"> the Type </param>
			/// <returns> the adds the column To sheet builder </returns>
			public virtual AddColumnToSheetBuilder SetType(ColumnType? type)
			{
				this.type = type;
				return this;
			}

			/// <summary>
			/// Gets the Type for the column. </summary>
			/// <returns> the Type </returns>
			public virtual ColumnType? Type
			{
				get
				{
					return type;
				}
			}

			/// <summary>
			/// Sets the Options for the column.
			/// </summary>
			/// <param name="options"> the Options </param>
			/// <returns> the adds the column To sheet builder </returns>
			public virtual AddColumnToSheetBuilder SetOptions(IList<string> options)
			{
				this.options = options;
				return this;
			}

			/// <summary>
			/// Gets the option for the column. </summary>
			/// <returns> the option </returns>
			public virtual IList<string> Options
			{
				get
				{
					return options;
				}
			}

			/// <summary>
			/// Sets the Symbol for the column.
			/// </summary>
			/// <param name="symbol"> the Symbol </param>
			/// <returns> the adds the column To sheet builder </returns>
			public virtual AddColumnToSheetBuilder SetSymbol(Symbol? symbol)
			{
				this.symbol = symbol;
				return this;
			}

			/// <summary>
			/// Gets the Symbol for the column. </summary>
			/// <returns> the Symbol </returns>
			public virtual Symbol? Symbol
			{
				get
				{
					return symbol;
				}
			}

			/// <summary>
			/// Sets the system column Type.
			/// </summary>
			/// <param name="systemColumnType"> the system column Type </param>
			/// <returns> the adds the column To sheet builder </returns>
			public virtual AddColumnToSheetBuilder SetSystemColumnType(SystemColumnType? systemColumnType)
			{
				this.systemColumnType = systemColumnType;
				return this;
			}

			/// <summary>
			/// Gets the system column Type. </summary>
			/// <returns> the system column Type </returns>
			public virtual SystemColumnType? SystemColumnType
			{
				get
				{
					return systemColumnType;
				}
			}

			/// <summary>
			/// Sets the Format for an auto number column.
			/// </summary>
			/// <param name="autoNumberFormat"> the auto number Format </param>
			/// <returns> the adds the column To sheet builder </returns>
			public virtual AddColumnToSheetBuilder SetAutoNumberFormat(AutoNumberFormat autoNumberFormat)
			{
				this.autoNumberFormat = autoNumberFormat;
				return this;
			}

			/// <summary>
			/// Gets the Format for an auto number column. </summary>
			/// <returns> the Format for an auto number column </returns>
			public virtual AutoNumberFormat AutoNumberFormat
			{
				get
				{
					return autoNumberFormat;
				}
			}

			/// <summary>
			/// Builds the column.
			/// </summary>
			/// <returns> the column </returns>
			public virtual Column Build()
			{
				if (title == null || type == null)
				{
					throw new MemberAccessException();
				}

				Column column = new Column();
				column.title = title;
				column.type = type;
				column.options = options;
				column.symbol = symbol;
				column.primary = primary;
				column.systemColumnType = systemColumnType;
				column.autoNumberFormat = autoNumberFormat;
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
			internal int index;

			/// <summary>
			/// The Title for the column. </summary>
			internal string title;

			/// <summary>
			/// The Type of the column. </summary>
			internal ColumnType? type;

			/// <summary>
			/// The Options for the column. </summary>
			internal IList<string> options;

			/// <summary>
			/// The Symbol for the column. </summary>
			internal Symbol? symbol;

			/// <summary>
			/// The system column Type. </summary>
			internal SystemColumnType? systemColumnType;

			/// <summary>
			/// The Format for an auto number column. </summary>
			internal AutoNumberFormat autoNumberFormat
                ;

			/// <summary>
			/// The sheet Id. </summary>
			internal long? sheetId;

			/// <summary>
			/// Sets the position for the column.
			/// </summary>
			/// <param name="index"> the position </param>
			/// <returns> the modify column builder </returns>
			public virtual ModifyColumnBuilder SetIndex(int index)
			{
				this.index = index;
				return this;
			}

			/// <summary>
			/// Sets the Title for the column.
			/// </summary>
			/// <param name="title"> the Title </param>
			/// <returns> the modify column builder </returns>
			public virtual ModifyColumnBuilder SetTitle(string title)
			{
				this.title = title;
				return this;
			}

			/// <summary>
			/// Sets the Type for the column.
			/// </summary>
			/// <param name="type"> the Type </param>
			/// <returns> the modify column builder </returns>
			public virtual ModifyColumnBuilder SetType(ColumnType? type)
			{
				this.type = type;
				return this;
			}

			/// <summary>
			/// Sets the Options for the column.
			/// </summary>
			/// <param name="options"> the Options </param>
			/// <returns> the modify column builder </returns>
			public virtual ModifyColumnBuilder SetOptions(IList<string> options)
			{
				this.options = options;
				return this;
			}

			/// <summary>
			/// Sets the Symbol for the column.
			/// </summary>
			/// <param name="symbol"> the Symbol </param>
			/// <returns> the modify column builder </returns>
			public virtual ModifyColumnBuilder SetSymbol(Symbol? symbol)
			{
				this.symbol = symbol;
				return this;
			}

			/// <summary>
			/// Sets the system column Type for the column.
			/// </summary>
			/// <param name="systemColumnType"> the system column Type </param>
			/// <returns> the modify column builder </returns>
			public virtual ModifyColumnBuilder SetSystemColumnType(SystemColumnType? systemColumnType)
			{
				this.systemColumnType = systemColumnType;
				return this;
			}

			/// <summary>
			/// Sets the Format for an auto number column.
			/// </summary>
			/// <param name="autoNumberFormat"> the auto number Format </param>
			/// <returns> the modify column builder </returns>
			public virtual ModifyColumnBuilder SetAutoNumberFormat(AutoNumberFormat autoNumberFormat)
			{
				this.autoNumberFormat = autoNumberFormat;
				return this;
			}

			/// <summary>
			/// Sets the sheet Id.
			/// </summary>
			/// <param name="sheetId"> the sheet Id </param>
			/// <returns> the modify column builder </returns>
			public virtual ModifyColumnBuilder SetSheetId(long? sheetId)
			{
				this.sheetId = sheetId;
				return this;
			}

			/// <summary>
			/// Gets the Index.
			/// </summary>
			/// <returns> the Index </returns>
			public virtual int Index
			{
				get
				{
					return index;
				}
			}

			/// <summary>
			/// Gets the Title.
			/// </summary>
			/// <returns> the Title </returns>
			public virtual string Title
			{
				get
				{
					return title;
				}
			}

			/// <summary>
			/// Gets the Type.
			/// </summary>
			/// <returns> the Type </returns>
			public virtual ColumnType? Type
			{
				get
				{
					return type;
				}
			}

			/// <summary>
			/// Gets the Options.
			/// </summary>
			/// <returns> the Options </returns>
			public virtual IList<string> Options
			{
				get
				{
					return options;
				}
			}

			/// <summary>
			/// Gets the Symbol.
			/// </summary>
			/// <returns> the Symbol </returns>
			public virtual Symbol? Symbol
			{
				get
				{
					return symbol;
				}
			}

			/// <summary>
			/// Gets the system column Type.
			/// </summary>
			/// <returns> the system column Type </returns>
			public virtual SystemColumnType? SystemColumnType
			{
				get
				{
					return systemColumnType;
				}
			}

			/// <summary>
			/// Gets the auto number Format.
			/// </summary>
			/// <returns> the auto number Format </returns>
			public virtual AutoNumberFormat AutoNumberFormat
			{
				get
				{
					return autoNumberFormat;
				}
			}

			/// <summary>
			/// Gets the sheet Id.
			/// </summary>
			/// <returns> the sheet Id </returns>
			public virtual long? SheetId
			{
				get
				{
					return sheetId;
				}
			}

			/// <summary>
			/// Builds the column.
			/// </summary>
			/// <returns> the column </returns>
			public virtual Column Build()
			{
				if (title == null || sheetId == null)
				{
					throw new MemberAccessException("A title and sheetId are required");
				}

				Column column = new Column();
				column.index = index;
				column.title = title;
				column.type = type;
				column.options = options;
				column.symbol = symbol;
				column.systemColumnType = systemColumnType;
				column.autoNumberFormat = autoNumberFormat;
				column.sheetId = sheetId;
				return column;
			}
		}
	}

}