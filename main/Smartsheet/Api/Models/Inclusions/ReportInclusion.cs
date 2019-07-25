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

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Smartsheet.Api.Models
{
    /// <summary>
    /// Represents specific elements to include in a response.
    /// </summary>
    public enum ReportInclusion
    {
        /// <summary>
        /// Includes the attachments.
        /// </summary>
        ATTACHMENTS,

        /// <summary>
        /// Includes the discussions.
        /// </summary>
        DISCUSSIONS,

        /// <summary>
        /// Includes the format.
        /// </summary>
        FORMAT,

        /// <summary>
        /// when used in combination with a level query parameter, includes the email addresses for multi-contact data
        /// </summary>
        OBJECT_VALUE,

        /// <summary>
        /// Adds the report's scope to the response
        /// </summary>
        SCOPE,

        /// <summary>
        /// Adds the Source object indicating which report the report was created from, if any
        /// </summary>
        SOURCE,

        /// <summary>
        /// Includes the source.
        /// </summary>
        SOURCE_SHEETS,

        /// <summary>
        /// Includes the sheet version for any source sheet returned by Report.
        /// </summary>
        SHEET_VERSION
    }
}