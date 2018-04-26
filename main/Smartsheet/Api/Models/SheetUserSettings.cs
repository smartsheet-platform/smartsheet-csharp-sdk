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
namespace Smartsheet.Api.Models
{
    /// <summary>
    /// Represents individual user settings for a specific sheet. 
    /// User settings may be updated even on sheets where the current user only has read access (e.g., viewer permissions or a read-only sheet). </summary>

    public class SheetUserSettings
    {
        /// <summary>
        /// The Id of the filter currently applied to the sheet
        /// </summary>
        private long? appliedSheetFilterId;

        /// <summary>
        /// Does this user have “Show Critical Path” turned on for this sheet? Note this setting only has an effect on project sheets with dependencies enabled.
        /// </summary>
        private bool? criticalPathEnabled;

        /// <summary>
        /// Does this user have “Display Summary Tasks” turned on for this sheet? Applies only to sheets where Calendar View has been configured.
        /// </summary>
        private bool? displaySummaryTasks;

        /// <summary>
        /// Get the Id of the sheet filter currently applied to this sheet
        /// </summary>
        /// <returns> the sheet filter Id </returns>
        public long? AppliedSheetFilterId
        {
            get { return appliedSheetFilterId; }
            set { appliedSheetFilterId = value; }
        }

        /// <summary>
        /// Does this user have “Show Critical Path” turned on for this sheet? 
        /// Note this setting only has an effect on project sheets with dependencies enabled.
        /// </summary>
        /// <returns> true if this user has “Show Critical Path” turned on, false otherwise </returns>
        public bool? CriticalPathEnabled
        {
            get { return criticalPathEnabled; }
            set { criticalPathEnabled = value; }
        }

        /// <summary>
        /// Does this user have “Display Summary Tasks” turned on for this sheet? 
        /// Applies only to sheets where Calendar View has been configured.
        /// </summary>
        /// <returns> true if this user has “Display Summary Tasks” turned on, false otherwise </returns>
        public bool? DisplaySummaryTasks
        {
            get { return displaySummaryTasks; }
            set { displaySummaryTasks = value; }
        }
    }
}
