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
    /// Represents the SheetSummary object.</summary>
    /// <seealso href="http://smartsheet-platform.github.io/api-docs/?shell#sheetsummary-object">SheetSummary Object Help</seealso>    
    public class SheetSummary
    {
        /// <summary>
        /// Array of summary (or metadata) fields defined on the sheet.
        /// </summary>
        private IList<SummaryField> fields;

        /// <summary>
        /// Get sheet summary fields
        /// </summary>
        /// <returns> fields </returns>
        public IList<SummaryField> Fields
        {
            get { return fields; }
            set { fields = value; }
        }
    }
}
