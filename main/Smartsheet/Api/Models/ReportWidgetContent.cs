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
    /// Represents the ReportWidgetContent object.</summary>
    /// <seealso href="http://smartsheet-platform.github.io/api-docs/#reportwidgetcontent-object">ReportWidgetContent Object Help</seealso>    
    public class ReportWidgetContent : IWidgetContent
    {
        /// <summary>
        /// Report Id denoting container source
        /// </summary>
        private long? reportId;

        /// <summary>
        /// HTML snippet to render report
        /// </summary>
        private string htmlContent;

        /// <summary>
        /// The widget has when clicked attribute set to that hyperlink (if present and non-null). Hyperlinks will have interactionType.
        /// </summary>
        private WidgetHyperlink hyperlink;

        /// <summary>
        /// Returns the type for this widget content object
        /// </summary>
        public WidgetType WidgetType
        {
            get { return WidgetType.GRIDGANTT; }
        }

        /// <summary>
        /// Report Id denoting container source
        /// </summary>
        /// <returns>the report id</returns>
        public long? ReportId
        {
            get { return reportId; }
            set { reportId = value; }
        }

        /// <summary>
        /// HTML snippet to render Report.
        /// </summary>
        /// <returns> the HTML string </returns>
        public string HtmlContent
        {
            get { return htmlContent; }
            set { htmlContent = value; }
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
    }
}
