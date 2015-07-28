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
	/// <summary>
	/// Represents the Column object.
	/// </summary>
	public class Column : IdentifiableModel
	{
		/// <summary>
		/// Represents the position, (zero-based).
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

		private long? width;

		private string format;

		private Filter filter;


		/// <summary>
		/// Gets or Sets the position of the column (zero-based).
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


		public long? Width
		{
			get { return width; }
			set { width = value; }
		}

		public string Format
		{
			get { return format; }
			set { format = value; }
		}
		public Filter Filter
		{
			get { return filter; }
			set { filter = value; }
		}


		/// <summary>
		/// A convenience class To help create a column object with the appropriate fields for adding To a sheet.
		/// </summary>
		public class AddColumnBuilder
		{
			/// <summary>
			/// Sets the required properties for adding a Column to a Sheet.
			/// </summary>
			/// <param name="title"> the Column title </param>
			/// <param name="index"> the Column index (zero-based) </param>
			/// <param name="type"> the Column Type </param>
			public AddColumnBuilder(string title, int? index, ColumnType? type)
			{
				this.title = title;
				this.index = index;
				this.type = type;
			}

			/// <summary>
			/// The position of the column. </summary>
			private int? index;

			/// <summary>
			/// The Title. </summary>
			private string title;

			/// <summary>
			/// The Type. </summary>
			private ColumnType? type;

			/// <summary>
			/// The Options. </summary>
			private IList<string> options;

			/// <summary>
			/// The Symbol. </summary>
			private Symbol? symbol;

			/// <summary>
			/// The system column Type. </summary>
			private SystemColumnType? systemColumnType;

			/// <summary>
			/// The auto number Format. </summary>
			private AutoNumberFormat autoNumberFormat;

			private long? width;


			/// <summary>
			/// Sets the position for the column.
			/// </summary>
			/// <param name="index"> the position </param>
			/// <returns> the add column builder </returns>
			public virtual AddColumnBuilder SetIndex(int index)
			{
				this.index = index;
				return this;
			}

			/// <summary>
			/// Sets the Primary flag for the column.
			/// </summary>
			/// <param name="primary"> the new Primary flag </param>
			/// <returns> the add column builder </returns>
			public virtual AddColumnBuilder SetWidth(long? width)
			{
				this.width = width;
				return this;
			}

			/// <summary>
			/// Sets the Title for the column.
			/// </summary>
			/// <param name="title"> the Title </param>
			/// <returns> the adds the column To sheet builder </returns>
			public virtual AddColumnBuilder SetTitle(string title)
			{
				this.title = title;
				return this;
			}

			/// <summary>
			/// Sets the Type for the column.
			/// </summary>
			/// <param name="type"> the Type </param>
			/// <returns> the adds the column To sheet builder </returns>
			public virtual AddColumnBuilder SetType(ColumnType? type)
			{
				this.type = type;
				return this;
			}

			/// <summary>
			/// Sets the Options for the column.
			/// </summary>
			/// <param name="options"> the Options </param>
			/// <returns> the adds the column To sheet builder </returns>
			public virtual AddColumnBuilder SetOptions(IList<string> options)
			{
				this.options = options;
				return this;
			}

			/// <summary>
			/// Sets the system column Type.
			/// </summary>
			/// <param name="systemColumnType"> the system column Type </param>
			/// <returns> the adds the column To sheet builder </returns>
			public virtual AddColumnBuilder SetSystemColumnType(SystemColumnType? systemColumnType)
			{
				this.systemColumnType = systemColumnType;
				return this;
			}

			/// <summary>
			/// Sets the Format for an auto number column.
			/// </summary>
			/// <param name="autoNumberFormat"> the auto number Format </param>
			/// <returns> the adds the column To sheet builder </returns>
			public virtual AddColumnBuilder SetAutoNumberFormat(AutoNumberFormat autoNumberFormat)
			{
				this.autoNumberFormat = autoNumberFormat;
				return this;
			}

			/// <summary>
			/// Gets the Index.
			/// </summary>
			/// <returns> the Index </returns>
			public virtual int? GetIndex()
			{
				return index;
			}

			/// <summary>
			/// Gets the Title. </summary>
			/// <returns> the Title </returns>
			public virtual string GetTitle()
			{
				return title;
			}


			/// <summary>
			/// Gets the Type for the column. </summary>
			/// <returns> the Type </returns>
			public virtual ColumnType? GetType()
			{
				return type;
			}


			/// <summary>
			/// Gets the option for the column. </summary>
			/// <returns> the option </returns>
			public virtual IList<string> GetOptions()
			{
				return options;
			}

			/// <summary>
			/// Sets the Symbol for the column.
			/// </summary>
			/// <param name="symbol"> the Symbol </param>
			/// <returns> the adds the column To sheet builder </returns>
			public virtual AddColumnBuilder SetSymbol(Symbol? symbol)
			{
				this.symbol = symbol;
				return this;
			}

			/// <summary>
			/// Gets the Symbol for the column. </summary>
			/// <returns> the Symbol </returns>
			public virtual Symbol? GetSymbol()
			{
				return symbol;
			}


			/// <summary>
			/// Gets the system column Type. </summary>
			/// <returns> the system column Type </returns>
			public virtual SystemColumnType? GetSystemColumnType()
			{
				return systemColumnType;
			}


			/// <summary>
			/// Gets the Format for an auto number column. </summary>
			/// <returns> the Format for an auto number column </returns>
			public virtual AutoNumberFormat GetAutoNumberFormat()
			{
				return autoNumberFormat;
			}

			/// <summary>
			/// Gets the display width. </summary>
			/// <returns> the display width </returns>
			public virtual long? GetWidth()
			{
				return width;
			}

			/// <summary>
			/// Builds the column.
			/// </summary>
			/// <returns> the column </returns>
			public virtual Column Build()
			{
				//if (title == null || type == null || index == null)
				//{
				//	throw new MemberAccessException("A title, type, and index must be set.");
				//}

				Column column = new Column();
				column.index = index;
				column.title = title;
				column.type = type;
				column.options = options;
				column.symbol = symbol;
				column.width = width;
				column.systemColumnType = systemColumnType;
				column.autoNumberFormat = autoNumberFormat;
				return column;
			}
		}

		/// <summary>
		/// A convenience class To help create a column object with the appropriate fields for adding To a Sheet being created.
		/// </summary>
		public class CreateSheetColumnBuilder
		{
			/// <summary>
			/// Sets the required properties for a Column.
			/// </summary>
			/// <param name="title"> must be unique within the Sheet </param>
			/// <param name="primary"> one and only one Column may be a Primary column </param>
			/// <param name="type"> must be set to TEXT_NUMBER if column is primary </param>
			public CreateSheetColumnBuilder(string title, bool? primary, ColumnType? type)
			{
				this.title = title;
				this.primary = primary;
				this.type = type;
			}

			/// <summary>
			/// The Title. </summary>
			private string title;

			/// <summary>
			/// The Type. </summary>
			private ColumnType? type;

			/// <summary>
			/// The Options. </summary>
			private IList<string> options;

			/// <summary>
			/// The Symbol. </summary>
			private Symbol? symbol;

			/// <summary>
			/// The system column Type. </summary>
			private SystemColumnType? systemColumnType;

			/// <summary>
			/// The auto number Format. </summary>
			private AutoNumberFormat autoNumberFormat;

			private long? width;

			private bool? primary;

			/// <summary>
			/// Sets whether the column is the Primary Column.
			/// </summary>
			/// <param name="primary"> the primary </param>
			/// <returns> the CreateSheetColumnBuilder </returns>
			public virtual CreateSheetColumnBuilder SetPrimary(bool? primary)
			{
				this.primary = primary;
				return this;
			}

			/// <summary>
			/// Sets the Primary flag for the column.
			/// </summary>
			/// <param name="primary"> the new Primary flag </param>
			/// <returns> the CreateSheetColumnBuilder </returns>
			public virtual CreateSheetColumnBuilder SetWidth(long? width)
			{
				this.width = width;
				return this;
			}

			/// <summary>
			/// Sets the Title for the column.
			/// </summary>
			/// <param name="title"> the Title </param>
			/// <returns> the adds the column To sheet builder </returns>
			public virtual CreateSheetColumnBuilder SetTitle(string title)
			{
				this.title = title;
				return this;
			}

			/// <summary>
			/// Sets the Type for the column.
			/// </summary>
			/// <param name="type"> the Type </param>
			/// <returns> the CreateSheetColumnBuilder </returns>
			public virtual CreateSheetColumnBuilder SetType(ColumnType? type)
			{
				this.type = type;
				return this;
			}

			/// <summary>
			/// Sets the Options for the column.
			/// </summary>
			/// <param name="options"> the Options </param>
			/// <returns> the CreateSheetColumnBuilder </returns>
			public virtual CreateSheetColumnBuilder SetOptions(IList<string> options)
			{
				this.options = options;
				return this;
			}

			/// <summary>
			/// Sets the system column Type.
			/// </summary>
			/// <param name="systemColumnType"> the system column Type </param>
			/// <returns> the CreateSheetColumnBuilder </returns>
			public virtual CreateSheetColumnBuilder SetSystemColumnType(SystemColumnType? systemColumnType)
			{
				this.systemColumnType = systemColumnType;
				return this;
			}

			/// <summary>
			/// Sets the Format for an auto number column.
			/// </summary>
			/// <param name="autoNumberFormat"> the auto number Format </param>
			/// <returns> the CreateSheetColumnBuilder </returns>
			public virtual CreateSheetColumnBuilder SetAutoNumberFormat(AutoNumberFormat autoNumberFormat)
			{
				this.autoNumberFormat = autoNumberFormat;
				return this;
			}

			/// <summary>
			/// Gets the whether the Column is the Primary Column.
			/// </summary>
			/// <returns> the primary </returns>
			public virtual bool? GetPrimary()
			{
				return primary;
			}


			/// <summary>
			/// Gets the Title. </summary>
			/// <returns> the Title </returns>
			public virtual string GetTitle()
			{
				return title;
			}


			/// <summary>
			/// Gets the Type for the column. </summary>
			/// <returns> the Type </returns>
			public virtual ColumnType? GetType()
			{
				return type;
			}


			/// <summary>
			/// Gets the option for the column. </summary>
			/// <returns> the option </returns>
			public virtual IList<string> GetOptions()
			{
				return options;
			}

			/// <summary>
			/// Sets the Symbol for the column.
			/// </summary>
			/// <param name="symbol"> the Symbol </param>
			/// <returns> the CreateSheetColumnBuilder </returns>
			public virtual CreateSheetColumnBuilder SetSymbol(Symbol? symbol)
			{
				this.symbol = symbol;
				return this;
			}

			/// <summary>
			/// Gets the Symbol for the column. </summary>
			/// <returns> the Symbol </returns>
			public virtual Symbol? GetSymbol()
			{
				return symbol;
			}


			/// <summary>
			/// Gets the system column Type. </summary>
			/// <returns> the system column Type </returns>
			public virtual SystemColumnType? GetSystemColumnType()
			{
				return systemColumnType;
			}


			/// <summary>
			/// Gets the Format for an auto number column. </summary>
			/// <returns> the Format for an auto number column </returns>
			public virtual AutoNumberFormat GetAutoNumberFormat()
			{
				return autoNumberFormat;
			}

			/// <summary>
			/// Gets the display width. </summary>
			/// <returns> the display width </returns>
			public virtual long? GetWidth()
			{
				return width;
			}

			/// <summary>
			/// Builds the column.
			/// </summary>
			/// <returns> the column </returns>
			public virtual Column Build()
			{
				//if (title == null || type == null || index == null)
				//{
				//	throw new MemberAccessException("A title, type, and index must be set.");
				//}

				Column column = new Column();
				column.title = title;
				column.type = type;
				column.options = options;
				column.symbol = symbol;
				column.width = width;
				column.systemColumnType = systemColumnType;
				column.autoNumberFormat = autoNumberFormat;
				column.primary = primary;
				return column;
			}
		}

		/// <summary>
		/// The convenience Class UpdateColumnBuilder to build a Column object to be updated, moved, and/or renamed.
		/// The Column's index, title, and sheetId properties must be set.
		/// </summary>
		public class UpdateColumnBuilder
		{

			/// <summary>
			/// The position of the column. </summary>
			private int? index;

			/// <summary>
			/// The Title for the column. </summary>
			private string title;

			/// <summary>
			/// The Type of the column. </summary>
			private ColumnType? type;

			/// <summary>
			/// The Options for the column. </summary>
			internal IList<string> options;

			/// <summary>
			/// The Symbol for the column. </summary>
			private Symbol? symbol;

			/// <summary>
			/// The system column Type. </summary>
			private SystemColumnType? systemColumnType;

			/// <summary>
			/// The Format for an auto number column. </summary>
			private AutoNumberFormat autoNumberFormat;

			///// <summary>
			///// The sheet Id. </summary>
			//private long? sheetId;

			/// <summary>
			/// The Display width of the column in pixels. </summary>
			private long? width;

			private string format;

			///// <summary> The Column Id</summary>
			//internal long? columnId;

			/// <summary>
			/// Sets the required properties for updating a column.
			/// </summary>
			/// <param name="title"> the new Column title </param>
			/// <param name="index"> the new Column index (zero-based) </param>
			public UpdateColumnBuilder(string title, int index)
			{
				this.title = title;
				this.index = index;
			}

			/// <summary>
			/// Sets the position for the column.
			/// </summary>
			/// <param name="index"> the position </param>
			/// <returns> the modify column builder </returns>
			public virtual UpdateColumnBuilder SetIndex(int index)
			{
				this.index = index;
				return this;
			}

			/// <summary>
			/// Sets the format descriptor.
			/// </summary>
			/// <param name="format"> the format </param>
			/// <returns> the modify column builder </returns>
			public virtual UpdateColumnBuilder SetFormat(string format)
			{
				this.format = format;
				return this;
			}

			/// <summary>
			/// Sets the Title for the column.
			/// </summary>
			/// <param name="title"> the Title </param>
			/// <returns> the modify column builder </returns>
			public virtual UpdateColumnBuilder SetTitle(string title)
			{
				this.title = title;
				return this;
			}

			/// <summary>
			/// Sets the Type for the column.
			/// </summary>
			/// <param name="type"> the Type </param>
			/// <returns> the modify column builder </returns>
			public virtual UpdateColumnBuilder SetType(ColumnType? type)
			{
				this.type = type;
				return this;
			}

			/// <summary>
			/// Sets the Options for the column.
			/// </summary>
			/// <param name="options"> the Options </param>
			/// <returns> the modify column builder </returns>
			public virtual UpdateColumnBuilder SetOptions(IList<string> options)
			{
				this.options = options;
				return this;
			}

			/// <summary>
			/// Sets the Symbol for the column.
			/// </summary>
			/// <param name="symbol"> the Symbol </param>
			/// <returns> the modify column builder </returns>
			public virtual UpdateColumnBuilder SetSymbol(Symbol symbol)
			{
				this.symbol = symbol;
				return this;
			}

			/// <summary>
			/// Sets the system column Type for the column.
			/// </summary>
			/// <param name="systemColumnType"> the system column Type </param>
			/// <returns> the modify column builder </returns>
			public virtual UpdateColumnBuilder SetSystemColumnType(SystemColumnType systemColumnType)
			{
				this.systemColumnType = systemColumnType;
				return this;
			}

			/// <summary>
			/// Sets the Format for an auto number column.
			/// </summary>
			/// <param name="autoNumberFormat"> the auto number Format </param>
			/// <returns> the modify column builder </returns>
			public virtual UpdateColumnBuilder SetAutoNumberFormat(AutoNumberFormat autoNumberFormat)
			{
				this.autoNumberFormat = autoNumberFormat;
				return this;
			}

			///// <summary>
			///// Sets the sheet Id.
			///// </summary>
			///// <param name="sheetId"> the sheet Id </param>
			///// <returns> the modify column builder </returns>
			//public virtual UpdateColumnBuilder SetSheetId(long sheetId)
			//{
			//	this.sheetId = sheetId;
			//	return this;
			//}


			///// <summary>
			///// Sets the column Id.
			///// </summary>
			///// <param name="sheetId">The column Id </param>
			///// <returns> the modify column builder </returns>
			//public virtual UpdateColumnBuilder SetColumnId(long? columnId)
			//{
			//	this.columnId = columnId;
			//	return this;
			//}

			/// <summary>
			/// Sets the display width.
			/// </summary>
			/// <param name="sheetId">The column Id </param>
			/// <returns> the modify column builder </returns>
			public virtual UpdateColumnBuilder SetWidth(long width)
			{
				this.width = width;
				return this;
			}

			/// <summary>
			/// Gets the Format.
			/// </summary>
			/// <returns> the Index </returns>
			public virtual int? GetFormat()
			{
				return index;
			}

			/// <summary>
			/// Gets the Index.
			/// </summary>
			/// <returns> the Index </returns>
			public virtual int? GetIndex()
			{
				return index;
			}

			/// <summary>
			/// Gets the Title.
			/// </summary>
			/// <returns> the Title </returns>
			public virtual string GetTitle()
			{
				return title;
			}

			/// <summary>
			/// Gets the Type.
			/// </summary>
			/// <returns> the Type </returns>
			public virtual ColumnType? GetType()
			{
				return type;
			}

			/// <summary>
			/// Gets the Options.
			/// </summary>
			/// <returns> the Options </returns>
			public virtual IList<string> GetOptions()
			{
				return options;
			}

			/// <summary>
			/// Gets the Symbol.
			/// </summary>
			/// <returns> the Symbol </returns>
			public virtual Symbol? GetSymbol()
			{
				return symbol;
			}

			/// <summary>
			/// Gets the system column Type.
			/// </summary>
			/// <returns> the system column Type </returns>
			public virtual SystemColumnType? GetSystemColumnType()
			{
				return systemColumnType;
			}

			/// <summary>
			/// Gets the auto number Format.
			/// </summary>
			/// <returns> the auto number Format </returns>
			public virtual AutoNumberFormat GetAutoNumberFormat()
			{
				return autoNumberFormat;
			}

			///// <summary>
			///// Gets the sheet Id.
			///// </summary>
			///// <returns> the sheet Id </returns>
			//public virtual long? GetSheetId()
			//{
			//	return sheetId;
			//}

			///// <summary>
			///// Gets the column Id.
			///// </summary>
			///// <returns> the sheet Id </returns>
			//public virtual long? ColumnId
			//{
			//	get
			//	{
			//		return columnId;
			//	}
			//}

			/// <summary>
			/// Builds the column.
			/// </summary>
			/// <returns> the column </returns>
			public virtual Column Build()
			{
				//if (title == null || sheetId == null || index == null)
				//{
				//	throw new MemberAccessException("A title, sheetId, and index are required");
				//}

				Column column = new Column();
				column.index = index;
				column.title = title;
				//column.sheetId = sheetId;
				column.type = type;
				column.options = options;
				column.symbol = symbol;
				column.systemColumnType = systemColumnType;
				column.autoNumberFormat = autoNumberFormat;
				column.width = width;
				column.format = format;
				//column.ID = columnId;
				return column;
			}
		}
	}
}