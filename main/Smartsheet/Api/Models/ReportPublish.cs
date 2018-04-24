//    #[license]
//    SmartsheetClient SDK for C#
//    %%
//    Copyright (C) 2016 SmartsheetClient
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
    /// Represents the Report Publish object (see http://smartsheet-platform.github.io/api-docs/?shell#reportpublish-object
    /// </summary>
    public class ReportPublish
    {
        /// <summary>
        /// If true, a rich version of the report is published with the ability to download row attachments and discussions.
        /// </summary>
        private bool? readOnlyFullEnabled;

        /// <summary>
        /// Flag to indicate who can access the 'Read-Only Full’ view of the published report:
        ///        if "ALL", report is available to anyone who has the link
        ///        if "ORG", report is available only to members of the report owner's organization
        /// </summary>
        private string readOnlyFullAccessibleBy;

        /// <summary>
        /// URL for 'Read-Only Full’ view of the published report
        /// </summary>
        private string readOnlyFullUrl;

        /// <summary>
        /// Flag to show or hide the left nav toolbar for the read only report
        /// </summary>
        private bool? readOnlyFullShowToolbar;

        /// <summary>
        /// Default view for published reort (GRID, CARDS, CALENDAR)
        /// </summary>
        private string readOnlyFullDefaultView;

        /// <summary>
        /// If true, a rich version of the report is published with the ability to download row attachments and discussions
        /// </summary>
        public bool? ReadOnlyFullEnabled
        {
            get { return readOnlyFullEnabled; }
            set { readOnlyFullEnabled = value; }
        }

        /// <summary>
        /// if "ALL", it is available to anyone who has the link.
        /// if "ORG", it is available only to members of the report owner’s Smartsheet organization.
        /// Only returned in a response if readOnlyFullEnabled = true.
        /// </summary>
        public string ReadOnlyFullAccessibleBy
        {
            get { return readOnlyFullAccessibleBy; }
            set { readOnlyFullAccessibleBy = value; }
        }

        /// <summary>
        /// URL for 'Read-Only Full’ view of the published report. Only returned in a response if readOnlyFullEnabled = true.
        /// </summary>
        public string ReadOnlyFullUrl
        {
            get { return readOnlyFullUrl; }
            set { readOnlyFullUrl = value; }
        }

        /// <summary>
        /// The read only full show toolbar flag
        /// </summary>
        public bool? ReadOnlyFullShowToolbar
        {
            get { return readOnlyFullShowToolbar; }
            set { readOnlyFullShowToolbar = value; }
        }

        /// <summary>
        /// The read only full default view
        /// </summary>
        public string ReadOnlyFullDefaultView
        {
            get { return readOnlyFullDefaultView; }
            set { readOnlyFullDefaultView = value; }
        }
    }
}
