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
//    Unless required by applicable law or agreed to in writing, software
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
        /// Represents the system column Type.
        /// </summary>
        private SystemColumnType? systemColumnType;

        /// <summary>
        /// Represents the column Type.
        /// </summary>
        private ColumnType? type;

        /// <summary>
        /// Represents the format for the auto-generated numbers (if the SystemColumnType is an AUTO_NUMBER).
        /// </summary>
        private AutoNumberFormat autoNumberFormat;

        /// <summary>
        /// List containing contact options
        /// </summary>
        private IList<Contact> contactOptions;

        /// <summary>
        /// The format descriptor. Only returned if the include query string parameter contains format and this column 
        /// has a non-default format applied to it.
        /// </summary>
        private string format;

        /// <summary>
        /// Represents the hidden flag for the column.
        /// </summary>
        private bool? hidden;

        /// <summary>
        /// Represents the position, (zero-based).
        /// </summary>
        private int? index;

        /// <summary>
        /// Indicates whether the column is locked. In a response, a value of true indicates that the column has 
        /// been locked by the sheet owner or the admin.
        /// </summary>
        private bool? locked;

        /// <summary>
        /// Indicates whether the column is locked for the requesting user. This attribute may be present in a 
        /// response, but cannot be specified in a request.
        /// </summary>
        private bool? lockedForUser;

        /// <summary>
        /// Represents the list of options for the column.
        /// </summary>
        private IList<string> options;

        /// <summary>
        /// Represents the primary flag.
        /// </summary>
        private bool? primary;

        /// <summary>
        /// Represents the symbol used for the column.
        /// </summary>
        private Symbol? symbol;

        /// <summary>
        /// Represents the tags to indicate a special Type of column.
        /// </summary>
        private IList<ColumnTag> tags;

        /// <summary>
        /// Represents the title.
        /// </summary>
        private string title;

        /// <summary>
        /// Indicates whether validation has been enabled for the column (value = true)
        /// </summary>
        private bool? validation;

        /// <summary>
        /// Determines the compatibility level of this client, 0 for existing types, 1 for multi-assign,
        /// greather than 1 for future types.
        /// </summary>
        private int? version;

        /// <summary>
        /// Display width of the column in pixels
        /// </summary>
        private long? width;

        /// <summary>
        /// Gets the system column Type.
        /// </summary>
        /// <returns> the system column Type </returns>
        public SystemColumnType? SystemColumnType
        {
            get { return systemColumnType; }
            set { systemColumnType = value; }
        }

        /// <summary>
        /// Gets the column Type.
        /// </summary>
        /// <returns> the Type </returns>
        public ColumnType? Type
        {
            get { return type; }
            set { type = value; }
        }

        /// <summary>
        /// Gets the format for the auto-generated numbers.
        /// </summary>
        /// <returns> the auto number format </returns>
        public AutoNumberFormat AutoNumberFormat
        {
            get { return autoNumberFormat; }
            set { autoNumberFormat = value; }
        }

        /// <summary>
        /// Gets array of ContactOption objects to specify a pre-defined list of values for the column. 
        /// Column type must be CONTACT_LIST
        /// </summary>
        /// <returns> the contact options list </returns>
        public IList<Contact> ContactOptions
        {
            get { return contactOptions; }
            set { contactOptions = value; }
        }

        /// <summary>
        /// <para>The format descriptor.</para>
        /// Only returned if the include query string parameter contains format and this
        /// column has a non-default format applied to it.
        /// </summary>
        public string Format
        {
            get { return format; }
            set { format = value; }
        }

        /// <summary>
        /// Gets the hidden flag.
        /// </summary>
        /// <returns> the hidden flag </returns>
        public bool? Hidden
        {
            get { return hidden; }
            set { hidden = value; }
        }

        /// <summary>
        /// Gets or sets the position of the column (zero-based).
        /// </summary>
        /// <returns> the index </returns>
        public int? Index
        {
            get { return index; }
            set { index = value; }
        }

        /// <summary>
        /// Flag indicating whether the column is locked. In a response,
        /// a value of true indicates that the column has been locked by the sheet owner or the admin.
        /// </summary>
        public bool? Locked
        {
            get { return locked; }
            set { locked = value; }
        }

        /// <summary>
        /// Flag indicating whether the column is locked for the requesting user.
        /// This attribute may be present in a response, but cannot be specified in a request.
        /// </summary>
        public bool? LockedForUser
        {
            get { return lockedForUser; }
            set { lockedForUser = value; }
        }

        /// <summary>
        /// Gets the list of options for the column.
        /// </summary>
        /// <returns> the options </returns>
        public IList<string> Options
        {
            get { return options; }
            set { options = value; }
        }

        /// <summary>
        /// Gets the primary flag for the column.
        /// </summary>
        /// <returns> the primary flag </returns>
        public bool? Primary
        {
            get { return primary; }
            set { primary = value; }
        }

        /// <summary>
        /// Gets the symbol for the column.
        /// </summary>
        /// <returns> the symbol </returns>
        public Symbol? Symbol
        {
            get { return symbol; }
            set { symbol = value; }
        }

        /// <summary>
        /// Gets the tags that indicate a special Type of column.
        /// </summary>
        /// <returns> the tags </returns>
        public IList<ColumnTag> Tags
        {
            get { return tags; }
            set { tags = value; }
        }

        /// <summary>
        /// Gets the title for the column.
        /// </summary>
        /// <returns> the title </returns>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        /// <summary>
        /// Indicates whether validation has been enabled for the column (value = true)
        /// </summary>
        public bool? Validation
        {
            get { return validation; }
            set { validation = value; }
        }

        /// <summary>
        /// Gets the column compatiblity version, 0 for existing types, 1 for multi-assign, > 1 future use
        /// </summary>
        public int? Version
        {
            get { return version;  }
            set { version = value; }
        }

        /// <summary>
        /// Display width of the column in pixels
        /// </summary>
        public long? Width
        {
            get { return width; }
            set { width = value; }
        }

        /// <summary>
        /// A convenience class to help create a column object with the appropriate fields for adding to a sheet.
        /// </summary>
        public class AddColumnBuilder
        {
            /// <summary>
            /// Sets the required properties for adding a column to a sheet.
            /// </summary>
            /// <param name="title"> the column title </param>
            /// <param name="index"> the column index (zero-based) </param>
            /// <param name="type"> the column type </param>
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
            /// The title. </summary>
            private string title;

            /// <summary>
            /// The type. </summary>
            private ColumnType? type;

            /// <summary>
            /// The options. </summary>
            private IList<string> options;

            /// <summary>
            /// The symbol. </summary>
            private Symbol? symbol;

            /// <summary>
            /// The system column type. </summary>
            private SystemColumnType? systemColumnType;

            /// <summary>
            /// The auto number format. </summary>
            private AutoNumberFormat autoNumberFormat;

            /// <summary>
            /// Display width of the column in pixels
            /// </summary>
            private long? width;

            /// <summary>
            /// Indicates whether the column is locked. In a response, a value of true indicates that the column has been locked 
            /// by the sheet owner or the admin.
            /// </summary>
            private bool? locked;

            /// <summary>
            /// Sets the position for the column.
            /// </summary>
            /// <param name="index"> the position </param>
            /// <returns> the add column builder </returns>
            public AddColumnBuilder SetIndex(int index)
            {
                this.index = index;
                return this;
            }

            /// <summary>
            /// Sets the primary flag for the column.
            /// </summary>
            /// <param name="width"> the width </param>
            /// <returns> the add column builder </returns>
            public AddColumnBuilder SetWidth(long? width)
            {
                this.width = width;
                return this;
            }

            /// <summary>
            /// Sets the title for the column.
            /// </summary>
            /// <param name="title"> the title </param>
            /// <returns> the adds the column to sheet builder </returns>
            public AddColumnBuilder SetTitle(string title)
            {
                this.title = title;
                return this;
            }

            /// <summary>
            /// Sets the type for the column.
            /// </summary>
            /// <param name="type"> the type </param>
            /// <returns> the adds the column to sheet builder </returns>
            public AddColumnBuilder SetType(ColumnType? type)
            {
                this.type = type;
                return this;
            }

            /// <summary>
            /// Sets the options for the column.
            /// </summary>
            /// <param name="options"> the options </param>
            /// <returns> the adds the column to sheet builder </returns>
            public AddColumnBuilder SetOptions(IList<string> options)
            {
                this.options = options;
                return this;
            }

            /// <summary>
            /// Sets the system column type.
            /// </summary>
            /// <param name="systemColumnType"> the system column type </param>
            /// <returns> the adds the column to sheet builder </returns>
            public AddColumnBuilder SetSystemColumnType(SystemColumnType? systemColumnType)
            {
                this.systemColumnType = systemColumnType;
                return this;
            }

            /// <summary>
            /// Sets the format for an auto number column.
            /// </summary>
            /// <param name="autoNumberFormat"> the auto number format </param>
            /// <returns> the adds the column to sheet builder </returns>
            public AddColumnBuilder SetAutoNumberFormat(AutoNumberFormat autoNumberFormat)
            {
                this.autoNumberFormat = autoNumberFormat;
                return this;
            }

            /// <summary>
            /// Sets whether the column is locked.
            /// </summary>
            /// <param name="locked"> the flag </param>
            /// <returns> the add column builder </returns>
            public AddColumnBuilder SetLocked(bool locked)
            {
                this.locked = locked;
                return this;
            }

            /// <summary>
            /// Gets the index.
            /// </summary>
            /// <returns> the index </returns>
            public int? GetIndex()
            {
                return index;
            }

            /// <summary>
            /// Gets the title. </summary>
            /// <returns> the title </returns>
            public string GetTitle()
            {
                return title;
            }

            /// <summary>
            /// Gets the type for the column. </summary>
            /// <returns> the type </returns>
            public new ColumnType? GetType()
            {
                return type;
            }

            /// <summary>
            /// Gets the option for the column. </summary>
            /// <returns> the option </returns>
            public IList<string> GetOptions()
            {
                return options;
            }

            /// <summary>
            /// Sets the symbol for the column.
            /// </summary>
            /// <param name="symbol"> the symbol </param>
            /// <returns> the adds the column to sheet builder </returns>
            public AddColumnBuilder SetSymbol(Symbol? symbol)
            {
                this.symbol = symbol;
                return this;
            }

            /// <summary>
            /// Gets the symbol for the column. </summary>
            /// <returns> the symbol </returns>
            public Symbol? GetSymbol()
            {
                return symbol;
            }

            /// <summary>
            /// Gets the system column type. </summary>
            /// <returns> the system column type </returns>
            public SystemColumnType? GetSystemColumnType()
            {
                return systemColumnType;
            }

            /// <summary>
            /// Gets the format for an auto number column. </summary>
            /// <returns> the format for an auto number column </returns>
            public AutoNumberFormat GetAutoNumberFormat()
            {
                return autoNumberFormat;
            }

            /// <summary>
            /// Gets the display width. </summary>
            /// <returns> the display width </returns>
            public long? GetWidth()
            {
                return width;
            }

            /// <summary>
            /// Gets the flag whether column is locked or not. </summary>
            /// <returns> the locked flag </returns>
            public bool? GetLocked()
            {
                return locked;
            }

            /// <summary>
            /// Builds the column.
            /// </summary>
            /// <returns> the column </returns>
            public Column Build()
            {
                //if (title == null || type == null || index == null)
                //{
                //    throw new MemberAccessException("A title, type, and index must be set.");
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
                column.locked = locked;
                return column;
            }
        }

        /// <summary>
        /// A convenience class to help create a column object with the appropriate fields for adding to a sheet being created.
        /// </summary>
        public class CreateSheetColumnBuilder
        {
            /// <summary>
            /// Sets the required properties for a column.
            /// </summary>
            /// <param name="title"> must be unique within the sheet </param>
            /// <param name="primary"> one and only one column may be a primary column </param>
            /// <param name="type"> must be set to TEXT_NUMBER if column is primary </param>
            public CreateSheetColumnBuilder(string title, bool? primary, ColumnType? type)
            {
                this.title = title;
                this.primary = primary;
                this.type = type;
            }

            /// <summary>
            /// The title. </summary>
            private string title;

            /// <summary>
            /// The type. </summary>
            private ColumnType? type;

            /// <summary>
            /// The options. </summary>
            private IList<string> options;

            /// <summary>
            /// The symbol. </summary>
            private Symbol? symbol;

            /// <summary>
            /// The system column type. </summary>
            private SystemColumnType? systemColumnType;

            /// <summary>
            /// The auto number format. </summary>
            private AutoNumberFormat autoNumberFormat;

            /// <summary>
            /// Display width of the column in pixels
            /// </summary>
            private long? width;

            /// <summary>
            /// Returned only if the column is the primary column (value = true)
            /// </summary>
            private bool? primary;

            /// <summary>
            /// Sets whether the column is the primary column.
            /// </summary>
            /// <param name="primary"> the primary </param>
            /// <returns> the CreateSheetColumnBuilder </returns>
            public CreateSheetColumnBuilder SetPrimary(bool? primary)
            {
                this.primary = primary;
                return this;
            }

            /// <summary>
            /// Sets the primary flag for the column.
            /// </summary>
            /// <param name="width"> the width </param>
            /// <returns> the CreateSheetColumnBuilder </returns>
            public CreateSheetColumnBuilder SetWidth(long? width)
            {
                this.width = width;
                return this;
            }

            /// <summary>
            /// Sets the title for the column.
            /// </summary>
            /// <param name="title"> the title </param>
            /// <returns> the adds the column to sheet builder </returns>
            public CreateSheetColumnBuilder SetTitle(string title)
            {
                this.title = title;
                return this;
            }

            /// <summary>
            /// Sets the type for the column.
            /// </summary>
            /// <param name="type"> the type </param>
            /// <returns> the CreateSheetColumnBuilder </returns>
            public CreateSheetColumnBuilder SetType(ColumnType? type)
            {
                this.type = type;
                return this;
            }

            /// <summary>
            /// Sets the options for the column.
            /// </summary>
            /// <param name="options"> the options </param>
            /// <returns> the CreateSheetColumnBuilder </returns>
            public CreateSheetColumnBuilder SetOptions(IList<string> options)
            {
                this.options = options;
                return this;
            }

            /// <summary>
            /// Sets the system column type.
            /// </summary>
            /// <param name="systemColumnType"> the system column type </param>
            /// <returns> the CreateSheetColumnBuilder </returns>
            public CreateSheetColumnBuilder SetSystemColumnType(SystemColumnType? systemColumnType)
            {
                this.systemColumnType = systemColumnType;
                return this;
            }

            /// <summary>
            /// Sets the format for an auto number column.
            /// </summary>
            /// <param name="autoNumberFormat"> the auto number format </param>
            /// <returns> the CreateSheetColumnBuilder </returns>
            public CreateSheetColumnBuilder SetAutoNumberFormat(AutoNumberFormat autoNumberFormat)
            {
                this.autoNumberFormat = autoNumberFormat;
                return this;
            }

            /// <summary>
            /// Gets the whether the column is the primary column.
            /// </summary>
            /// <returns> the primary </returns>
            public bool? GetPrimary()
            {
                return primary;
            }

            /// <summary>
            /// Gets the title. </summary>
            /// <returns> the title </returns>
            public string GetTitle()
            {
                return title;
            }

            /// <summary>
            /// Gets the type for the column. </summary>
            /// <returns> the type </returns>
            public new ColumnType? GetType()
            {
                return type;
            }

            /// <summary>
            /// Gets the option for the column. </summary>
            /// <returns> the option </returns>
            public IList<string> GetOptions()
            {
                return options;
            }

            /// <summary>
            /// Sets the symbol for the column.
            /// </summary>
            /// <param name="symbol"> the symbol </param>
            /// <returns> the CreateSheetColumnBuilder </returns>
            public CreateSheetColumnBuilder SetSymbol(Symbol? symbol)
            {
                this.symbol = symbol;
                return this;
            }

            /// <summary>
            /// Gets the symbol for the column. </summary>
            /// <returns> the symbol </returns>
            public Symbol? GetSymbol()
            {
                return symbol;
            }

            /// <summary>
            /// Gets the system column type. </summary>
            /// <returns> the system column type </returns>
            public SystemColumnType? GetSystemColumnType()
            {
                return systemColumnType;
            }

            /// <summary>
            /// Gets the format for an auto number column. </summary>
            /// <returns> the format for an auto number column </returns>
            public AutoNumberFormat GetAutoNumberFormat()
            {
                return autoNumberFormat;
            }

            /// <summary>
            /// Gets the display width. </summary>
            /// <returns> the display width </returns>
            public long? GetWidth()
            {
                return width;
            }

            /// <summary>
            /// Builds the column.
            /// </summary>
            /// <returns> the column </returns>
            public Column Build()
            {
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
        /// The convenience class UpdateColumnBuilder to build a Column object to be updated, moved, and/or renamed.
        /// The column's index and title properties must be set.
        /// </summary>
        public class UpdateColumnBuilder
        {
            private long? id;

            /// <summary>
            /// The position of the column. </summary>
            private int? index;

            /// <summary>
            /// The title for the column. </summary>
            private string title;

            /// <summary>
            /// The type of the column. </summary>
            private ColumnType? type;

            /// <summary>
            /// The options for the column. </summary>
            internal IList<string> options;

            /// <summary>
            /// The symbol for the column. </summary>
            private Symbol? symbol;

            /// <summary>
            /// The system column type. </summary>
            private SystemColumnType? systemColumnType;

            /// <summary>
            /// The format for an auto number column. </summary>
            private AutoNumberFormat autoNumberFormat;

            /// <summary>
            /// The display width of the column in pixels. </summary>
            private long? width;

            /// <summary>
            /// The format descriptor. Only returned if the include query string parameter contains format and this column 
            /// has a non-default format applied to it.
            /// </summary>
            private string format;

            /// <summary>
            /// Indicates whether the column is locked. In a response, a value of true indicates that the column has been locked 
            /// by the sheet owner or the admin.
            /// </summary>
            private bool? locked;

            /// <summary>
            /// Sets the required properties for updating a column.
            /// </summary>
            /// <param name="id"> the id of the column </param>
            /// <param name="title"> the new column title </param>
            /// <param name="index"> the new column index (zero-based) </param>
            public UpdateColumnBuilder(long id, string title, int index)
            {
                this.id = id;
                this.title = title;
                this.index = index;
            }

            /// <summary>
            /// Sets the position for the column.
            /// </summary>
            /// <param name="index"> the position </param>
            /// <returns> the modify column builder </returns>
            public UpdateColumnBuilder SetIndex(int index)
            {
                this.index = index;
                return this;
            }

            /// <summary>
            /// Sets the format descriptor.
            /// </summary>
            /// <param name="format"> the format </param>
            /// <returns> the modify column builder </returns>
            public UpdateColumnBuilder SetFormat(string format)
            {
                this.format = format;
                return this;
            }

            /// <summary>
            /// Sets the title for the column.
            /// </summary>
            /// <param name="title"> the title </param>
            /// <returns> the modify column builder </returns>
            public UpdateColumnBuilder SetTitle(string title)
            {
                this.title = title;
                return this;
            }

            /// <summary>
            /// Sets the type for the column.
            /// </summary>
            /// <param name="type"> the type </param>
            /// <returns> the modify column builder </returns>
            public UpdateColumnBuilder SetType(ColumnType? type)
            {
                this.type = type;
                return this;
            }

            /// <summary>
            /// Sets the options for the column.
            /// </summary>
            /// <param name="options"> the options </param>
            /// <returns> the modify column builder </returns>
            public UpdateColumnBuilder SetOptions(IList<string> options)
            {
                this.options = options;
                return this;
            }

            /// <summary>
            /// Sets the symbol for the column.
            /// </summary>
            /// <param name="symbol"> the symbol </param>
            /// <returns> the modify column builder </returns>
            public UpdateColumnBuilder SetSymbol(Symbol symbol)
            {
                this.symbol = symbol;
                return this;
            }

            /// <summary>
            /// Sets the system column type for the column.
            /// </summary>
            /// <param name="systemColumnType"> the system column type </param>
            /// <returns> the modify column builder </returns>
            public UpdateColumnBuilder SetSystemColumnType(SystemColumnType systemColumnType)
            {
                this.systemColumnType = systemColumnType;
                return this;
            }

            /// <summary>
            /// Sets the format for an auto number column.
            /// </summary>
            /// <param name="autoNumberFormat"> the auto number format </param>
            /// <returns> the modify column builder </returns>
            public UpdateColumnBuilder SetAutoNumberFormat(AutoNumberFormat autoNumberFormat)
            {
                this.autoNumberFormat = autoNumberFormat;
                return this;
            }

            /// <summary>
            /// Sets the display width.
            /// </summary>
            /// <param name="width">the width</param>
            /// <returns>the updated column builder</returns>
            public UpdateColumnBuilder SetWidth(long width)
            {
                this.width = width;
                return this;
            }

            /// <summary>
            /// Sets whether the column is locked.
            /// </summary>
            /// <param name="locked"> the flag </param>
            /// <returns> the modify column builder </returns>
            public UpdateColumnBuilder SetLocked(bool locked)
            {
                this.locked = locked;
                return this;
            }

            /// <summary>
            /// Gets the format.
            /// </summary>
            /// <returns> the index </returns>
            public int? GetFormat()
            {
                return index;
            }

            /// <summary>
            /// Gets the index.
            /// </summary>
            /// <returns> the index </returns>
            public int? GetIndex()
            {
                return index;
            }

            /// <summary>
            /// Gets the title.
            /// </summary>
            /// <returns> the title </returns>
            public string GetTitle()
            {
                return title;
            }

            /// <summary>
            /// Gets the type.
            /// </summary>
            /// <returns> the type </returns>
            public new ColumnType? GetType()
            {
                return type;
            }

            /// <summary>
            /// Gets the options.
            /// </summary>
            /// <returns> the options </returns>
            public IList<string> GetOptions()
            {
                return options;
            }

            /// <summary>
            /// Gets the symbol.
            /// </summary>
            /// <returns> the symbol </returns>
            public Symbol? GetSymbol()
            {
                return symbol;
            }

            /// <summary>
            /// Gets the system column type.
            /// </summary>
            /// <returns> the system column type </returns>
            public SystemColumnType? GetSystemColumnType()
            {
                return systemColumnType;
            }

            /// <summary>
            /// Gets the auto number format.
            /// </summary>
            /// <returns> the auto number format </returns>
            public AutoNumberFormat GetAutoNumberFormat()
            {
                return autoNumberFormat;
            }

            /// <summary>
            /// Builds the column.
            /// </summary>
            /// <returns> the column </returns>
            public Column Build()
            {
                Column column = new Column();
                column.Id = id;
                column.index = index;
                column.title = title;
                column.type = type;
                column.options = options;
                column.symbol = symbol;
                column.systemColumnType = systemColumnType;
                column.autoNumberFormat = autoNumberFormat;
                column.width = width;
                column.format = format;
                column.locked = locked;
                return column;
            }
        }
    }
}
