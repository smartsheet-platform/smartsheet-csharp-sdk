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

using System;
using System.Collections.Generic;

namespace Smartsheet.Api.Models
{
    /// <summary>
    /// Represents the ChartWidgetContent object. </summary>
    /// <seealso href="http://smartsheet-platform.github.io/api-docs/#chartwidgetcontent-object">ChartWidgetContent Object Help</seealso>        
    public class ChartWidgetContent : IWidgetContent
    {
        /// <summary>
        /// Report Id denoting container source, if applicable
        /// </summary>
        private long? reportId;

        /// <summary>
        /// Sheet Id denoting container source, if applicable
        /// </summary>
        private long? sheetId;

        /// <summary>
        /// Array of Axes objects
        /// </summary>
        private IList<Object> axes;

        /// <summary>
        /// The widget has when clicked attribute set to that hyperlink (if present and non-null)
        /// </summary>
        private WidgetHyperlink hyperlink;

        /// <summary>
        /// Array of columnIds if the range was selected through the UI
        /// </summary>
        private IList<long> includedColumnIds;

        /// <summary>
        /// The location in the widget where Smartsheet renders the legend, for example, RIGHT
        /// </summary>
        private Object legend;

        /// <summary>
        /// selection range if the source is a sheet
        /// </summary>
        private IList<SelectionRange> selectionRanges;
        
        /// <summary>
        /// Array of Series objects
        /// </summary>
        private IList<Object> series;

        /// <summary>
        /// Returns the type for this widget content object
        /// </summary>
        public WidgetType WidgetType
        {
            get { return WidgetType.CHART; }
        }

        /// <summary>
        /// Report Id denoting container source, if applicable
        /// </summary>
        /// <returns>the report id</returns>
        public long? ReportId
        {
            get { return reportId; }
            set { reportId = value; }
        }

        /// <summary>
        /// Sheet Id denoting container source, if applicable
        /// </summary>
        /// <returns>the sheet id</returns>
        public long? SheetId
        {
            get { return sheetId; }
            set { sheetId = value; }
        }

        /// <summary>
        /// Array of Axes objects
        /// </summary>
        /// <returns> the axes </returns>
        public IList<Object> Axes
        {
            get { return axes; }
            set { axes = value; }
        }

        /// <summary>
        /// The widget has when clicked attribute set to that hyperlink (if present and non-null)
        /// </summary>
        /// <returns> the Link </returns>
        public WidgetHyperlink Hyperlink
        {
            get { return hyperlink; }
            set { hyperlink = value; }
        }

        /// <summary>
        /// Array of columnIds if the range was selected through the UI
        /// </summary>
        /// <returns>the list of included column ids</returns>
        public IList<long> IncludedColumnIds
        {
            get { return includedColumnIds; }
            set { includedColumnIds = value; }
        }

        /// <summary>
        /// The location in the widget where Smartsheet renders the legend, for example, RIGHT
        /// </summary>
        /// <returns> chart lengend </returns>
        public Object Legend
        {
            get { return legend; }
            set { legend = value; }
        }

        /// <summary>
        /// Selection range if the source is a sheet
        /// </summary>
        /// <returns>the selection range list</returns>
        public IList<SelectionRange> SelectionRanges
        {
            get { return selectionRanges; }
            set { selectionRanges = value; }
        }

        /// <summary>
        /// Array of Series objects
        /// </summary>
        /// <returns> the series data </returns>
        public IList<Object> Series
        {
            get { return series; }
            set { series = value; }
        }
    }
}
