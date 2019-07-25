//    #[license]
//    SmartsheetClient SDK for C#
//    %%
//    Copyright (C) 2019 SmartsheetClient
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

using System.Collections.Generic;

namespace Smartsheet.Api.Models
{
    /// <summary>
    /// Represents the CellLinkWidgetContent object.</summary>
    /// <seealso href="http://smartsheet-platform.github.io/api-docs/#celllinkwidgetcontent-object">CellLinkWidget Object Help</seealso>        
    public class CellLinkWidgetContent : IWidgetContent
    {
        /// <summary>
        /// The Id of the sheet from which the cell data originates
        /// </summary>
        private long? sheetId;

        /// <summary>
        /// Array of CellDataItem objects
        /// </summary>
        private IList<CellDataItem> cellData;

        /// <summary>
        /// Array of Column objects
        /// </summary>
        private IList<Column> columns;

        /// <summary>
        /// The widget has when clicked attribute set to that hyperlink (if present and non-null)
        /// </summary>
        private WidgetHyperlink hyperlink;

        /// <summary>
        /// Returns the type for this widget content object
        /// </summary>
        public WidgetType WidgetType
        {
            get { return WidgetType.METRIC; }
        }

        /// <summary>
        /// The Id of the sheet from which the cell data originates
        /// </summary>
        /// <returns>the sheet id</returns>
        public long? SheetId
        {
            get { return sheetId; }
            set { sheetId = value; }
        }

        /// <summary>
        /// Array of cellDataItem objects.
        /// </summary>
        /// <returns> the array </returns>
        public IList<CellDataItem> CellData
        {
            get { return cellData; }
            set { cellData = value; }
        }

        /// <summary>
        /// Array of Column objects.
        /// </summary>
        /// <returns> the array </returns>
        public IList<Column> Columns
        {
            get { return columns; }
            set { columns = value; }
        }

        /// <summary>
        /// The widget has when clicked attribute set to that hyperlink (if present and non-null).
        /// </summary>
        /// <returns> the Link </returns>
        public WidgetHyperlink Hyperlink
        {
            get { return hyperlink; }
            set { hyperlink = value; }
        }
    }
}