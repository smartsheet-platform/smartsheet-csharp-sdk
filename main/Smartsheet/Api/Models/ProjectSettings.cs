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
//    %[license]using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smartsheet.Api.Models
{
    /// <summary>
    /// Represents the Sight Publish object (see http://smartsheet-platform.github.io/api-docs/?shell#sightpublish-object
    /// </summary>
    public class ProjectSettings
    {
        /// <summary>
        /// Working days of a week for a project sheet. 
        /// </summary>
        private IList<string> workingDays;

        /// <summary>
        /// Non-working days for a project sheet. The format for the timestamp array must be an array of strings that are valid ISO-8601 dates ('YYYY-MM-DD’).
        /// </summary>
        private IList<DateTime> nonWorkingDays;

        /// <summary>
        /// Length of a workday for a project sheet. Valid value must be above or equal to 1 hour, and less than or equal to 24 hours.
        /// </summary>
        private float? lengthOfDay;

        /// <summary>
        /// Get a list of working days in the week.
        /// </summary>
        public IList<string> WorkingDays
        {
            get { return workingDays; }
            set { workingDays = value; }
        }

        /// <summary>
        /// Get a list of non working days in the year.
        /// </summary>
        public IList<DateTime> NonWorkingDays
        {
            get { return nonWorkingDays; }
            set { nonWorkingDays = value; }
        }

        /// <summary>
        /// Get the length of the workday for a project seheet.
        /// </summary>
        public float? LengthOfDay
        {
            get { return lengthOfDay; }
            set { lengthOfDay = value; }
        }
    }
}
