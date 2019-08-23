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
    public enum SheetInclusion
    {
        /// <summary>
        /// Includes the owner’s email address and user ID for each sheet.
        /// </summary>
        OWNER_INFO,

        /// <summary>
        /// Includes the sheet version.
        /// </summary>
        SHEET_VERSION,

        /// <summary>
        /// Includes the source for any sheet that was created from another sheet or template.
        /// </summary>
        SOURCE
    }
}