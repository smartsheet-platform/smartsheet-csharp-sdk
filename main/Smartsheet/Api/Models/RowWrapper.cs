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
using System.Configuration;

namespace Smartsheet.Api.Models
{
    /// <summary>
    /// Represents the RowWrapper object that is used to specify the location for a <seealso cref="Row"/> or set of Rows.
    /// </summary>
    public class RowWrapper
    {
        /// <summary>
        /// Represents to-top flag that puts the row at the top of the sheet.
        /// </summary>
        private bool? toTop;

        /// <summary>
        /// Represents to-bottom flag that puts the row at the bottom of the sheet.
        /// </summary>
        private bool? toBottom;

        /// <summary>
        /// Represents the parent ID that puts the row as the first child of the specified Id.
        /// </summary>
        private long? parentId;

        /// <summary>
        /// Represents the sibling ID that puts the row as the next row at the same hierarchical level of this row.
        /// </summary>
        private long? siblingId;

        /// <summary>
        /// Represents the Rows.
        /// </summary>
        private IList<Row> rows;

        /// <summary>
        /// Gets the to top flag that puts the row at the top of the sheet.
        /// </summary>
        /// <returns> the to top </returns>
        public bool? ToTop
        {
            get { return toTop; }
            set { toTop = value; }
        }

        /// <summary>
        /// Gets the to bottom flag that puts the row at the bottom of the sheet.
        /// </summary>
        /// <returns> the to bottom </returns>
        public bool? ToBottom
        {
            get { return toBottom; }
            set { toBottom = value; }
        }

        /// <summary>
        /// Gets the parent Id that puts the row as the first child of the specified Id.
        /// </summary>
        /// <returns> the parent Id </returns>
        public long? ParentId
        {
            get { return parentId; }
            set { parentId = value; }
        }
        
        /// <summary>
        /// Gets the sibling Id that puts the row as the next row at the same hierarchical level of this row.
        /// </summary>
        /// <returns> the sibling Id </returns>
        public long? SiblingId
        {
            get { return siblingId; }
            set { siblingId = value; }
        }
        
        /// <summary>
        /// Gets the Rows.
        /// </summary>
        /// <returns> the Rows </returns>
        public IList<Row> Rows
        {
            get { return rows; }
            set { rows = value; }
        }

                /// <summary>
        /// A convenience class for creating a <seealso cref="RowWrapper"/> with the necessary fields for inserting a <seealso cref="Row"/> or 
        /// set of Rows.
        /// </summary>
        public class InsertRowsBuilder
        {
            internal bool? toTop;
            internal bool? toBottom;
            internal long? parentId;
            internal long? siblingId;
            internal IList<Row> rows;

            /// <summary>
            /// Sets the to top flag that puts the row at the top of the sheet.
            /// </summary>
            /// <param name="toTop"> the to top flag </param>
            /// <returns> the insert Rows builder </returns>
            public InsertRowsBuilder SetToTop(bool? toTop)
            {
                this.toTop = toTop;
                return this;
            }

            /// <summary>
            /// Sets the to bottom flag that puts the row at the bottom of the sheet.
            /// </summary>
            /// <param name="toBottom"> the to bottom </param>
            /// <returns> the insert Rows builder </returns>
            public InsertRowsBuilder SetToBottom(bool? toBottom)
            {
                this.toBottom = toBottom;
                return this;
            }

            /// <summary>
            /// Sets the parent Id that puts the row as the first child of the specified Id.
            /// </summary>
            /// <param name="parentId"> the parent Id </param>
            /// <returns> the insert Rows builder </returns>
            public InsertRowsBuilder SetParentId(long? parentId)
            {
                this.parentId = parentId;
                return this;
            }

            /// <summary>
            /// Sets the sibling Id that puts the row as the next row at the same hierarchical level of this row.
            /// </summary>
            /// <param name="siblingId"> the sibling Id </param>
            /// <returns> the insert Rows builder </returns>
            public InsertRowsBuilder SetSiblingId(long? siblingId)
            {
                this.siblingId = siblingId;
                return this;
            }

            /// <summary>
            /// Sets the Rows.
            /// </summary>
            /// <param name="rows"> the Rows </param>
            /// <returns> the insert Rows builder </returns>
            public InsertRowsBuilder SetRows(IList<Row> rows)
            {
                this.rows = rows;
                return this;
            }

            /// <summary>
            /// Gets the to top.
            /// </summary>
            /// <returns> the to top </returns>
            public bool? ToTop
            {
                get { return toTop; }
            }

            /// <summary>
            /// Gets the to bottom.
            /// </summary>
            /// <returns> the to bottom </returns>
            public bool? ToBottom
            {
                get { return toBottom; }
            }

            /// <summary>
            /// Gets the parent Id.
            /// </summary>
            /// <returns> the parent Id </returns>
            public long? ParentId
            {
                get { return parentId; }
            }

            /// <summary>
            /// Gets the sibling Id.
            /// </summary>
            /// <returns> the sibling Id </returns>
            public long? SiblingId
            {
                get { return siblingId; }
            }

            /// <summary>
            /// Gets the Rows.
            /// </summary>
            /// <returns> the Rows </returns>
            public IList<Row> Rows
            {
                get { return rows; }
            }

            /// <summary>
            /// Builds the RowWrapper.
            /// </summary>
            /// <returns> the row wrapper </returns>
            public RowWrapper Build()
            {
                if (toTop == null && toBottom == null && parentId == null && siblingId == null)
                {
                    new MemberAccessException("One of the following fields must be set toTop, toBottom, parentId or" + " sibling Id");
                }

                RowWrapper rowWrapper = new RowWrapper();
                rowWrapper.toTop = toTop;
                rowWrapper.toBottom = toBottom;
                rowWrapper.parentId = parentId;
                rowWrapper.siblingId = siblingId;
                rowWrapper.rows = rows;
                return rowWrapper;
            }
        }

        /// <summary>
        /// A convenience class for creating a <seealso cref="RowWrapper"/> with the necessary fields for moving a <seealso cref="Row"/> or set 
        /// of Rows.
        /// </summary>
        public class MoveRowBuilder
        {
            internal bool? toTop;
            internal bool? toBottom;
            internal long? parentId;
            internal long? siblingId;

            /// <summary>
            /// Sets the to top flag that puts the row at the top of the sheet.
            /// </summary>
            /// <param name="toTop"> the to top </param>
            /// <returns> the move row builder </returns>
            public MoveRowBuilder SetToTop(bool? toTop)
            {
                this.toTop = toTop;
                return this;
            }

            /// <summary>
            /// Sets the to bottom flag that puts the row at the bottom of the sheet.
            /// </summary>
            /// <param name="toBottom"> the to bottom </param>
            /// <returns> the move row builder </returns>
            public MoveRowBuilder SetToBottom(bool? toBottom)
            {
                this.toBottom = toBottom;
                return this;
            }

            /// <summary>
            /// Sets the parent Id that puts the row as the first child of the specified Id.
            /// </summary>
            /// <param name="parentId"> the parent Id </param>
            /// <returns> the move row builder </returns>
            public MoveRowBuilder SetParentId(long? parentId)
            {
                this.parentId = parentId;
                return this;
            }

            /// <summary>
            /// Sets the sibling Id that puts the row as the next row at the same hierarchical level of this row.
            /// </summary>
            /// <param name="siblingId"> the sibling Id </param>
            /// <returns> the move row builder </returns>
            public MoveRowBuilder SetSiblingId(long? siblingId)
            {
                this.siblingId = siblingId;
                return this;
            }

            /// <summary>
            /// Gets the to top.
            /// </summary>
            /// <returns> the to top </returns>
            public bool? ToTop
            {
                get { return toTop; }
            }

            /// <summary>
            /// Gets the to bottom.
            /// </summary>
            /// <returns> the to bottom </returns>
            public bool? ToBottom
            {
                get { return toBottom; }
            }

            /// <summary>
            /// Gets the parent Id.
            /// </summary>
            /// <returns> the parent Id </returns>
            public long? ParentId
            {
                get { return parentId; }
            }

            /// <summary>
            /// Gets the sibling Id.
            /// </summary>
            /// <returns> the sibling Id </returns>
            public long? SiblingId
            {
                get { return siblingId; }
            }

            /// <summary>
            /// Builds the RowWrapper.
            /// </summary>
            /// <returns> the row wrapper </returns>
            public RowWrapper Build()
            {
                if (toTop == null && toBottom == null && parentId == null && siblingId == null)
                {
                    throw new InvalidOperationException("One of the following must be defined to move a row: toTop, "+
                        "toBottom, parentId, siblingId.");
                }

                RowWrapper rowWrapper = new RowWrapper();
                rowWrapper.toTop = toTop;
                rowWrapper.toBottom = toBottom;
                rowWrapper.parentId = parentId;
                rowWrapper.siblingId = siblingId;
                return rowWrapper;
            }
        }
    }
}