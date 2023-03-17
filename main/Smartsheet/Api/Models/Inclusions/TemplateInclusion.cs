﻿//    #[license]
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

using System.Runtime.Serialization;

namespace Smartsheet.Api.Models
{
    /// <summary>
    /// Represents specific elements that can be copied from a Template or Sheet into a new Sheet.
    /// </summary>
    public enum TemplateInclusion
    {
        /// <summary>
        /// Includes the data.
        /// </summary>
        DATA,

        /// <summary>
        /// Includes the attachments.
        /// </summary>
        ATTACHMENTS,

        /// <summary>
        /// Includes the discussions.
        /// </summary>
        DISCUSSIONS,

        /// <summary>
        /// Includes the cell links.
        /// </summary>
        CELL_LINKS,

        /// <summary>
        /// Includes the forms.
        /// </summary>
        FORMS,

        /// <summary>
        /// Includes the rules.
        /// </summary>
        RULES,

        /// <summary>
        /// Includes the rule recipients.
        /// </summary>
        RULE_RECIPIENTS
    }
}