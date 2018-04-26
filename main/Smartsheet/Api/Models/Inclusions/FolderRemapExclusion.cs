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

namespace Smartsheet.Api.Models
{
    /// <summary>
    /// Represents specific references to NOT re-map for the newly created object.
    /// </summary>
    public enum FolderRemapExclusion
    {
        /// <summary>
        /// Excludes re-mapping of the cell links.
        /// </summary>
        CELL_LINKS,

        /// <summary>
        /// Excludes re-mapping of the reports.
        /// </summary>
        REPORTS,

        /// <summary>
        /// Excludes re-mapping of hyperlinks.
        /// </summary>
        SHEET_HYPERLINKS,

        /// <summary>
        /// Excludes re-mapping of Sights.
        /// </summary>
        SIGHTS
    }
}