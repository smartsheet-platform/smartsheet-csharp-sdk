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
    /// Represents the SheetUserPermissions object.</summary>
    /// <seealso href="http://smartsheet-platform.github.io/api-docs/?shell#sheetuserpermissions-object">SheetUserPermissions Object Help</seealso>    
    public class SheetUserPermissions
    {
        /// <summary>
        /// ADMIN: full control over fields
        /// READ_DELETE: sheet is owned by an individual account that doesn't have summary capabilities. If a summary exists,
        ///     the only possible operations are GET and DELETE fields.
        /// READ_ONLY:
        /// READ_WRITE: can edit values of existing fields, but not create or delete fields, nor modify field type.
        /// </summary>
        private string summaryPermissions;

        /// <summary>
        /// Gets the sheet summary permissions
        /// </summary>
        /// <returns> summaryPermissions </returns>
        public string SummaryPermissions
        {
            get { return summaryPermissions; }
            set { summaryPermissions = value; }
        }
    }
}
