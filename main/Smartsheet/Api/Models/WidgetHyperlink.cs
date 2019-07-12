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
using System.Linq;
using System.Text;

namespace Smartsheet.Api.Models
{
    /// <summary>
    /// Represents the widget hyperlink object. </summary>
    /// <seealso href="https://smartsheet-platform.github.io/api-docs/?ruby#widgethyperlink-object">WidgetHyperlink Object Help</seealso>
    public class WidgetHyperlink : Hyperlink
    {
        /// <summary>
        /// Specifies what happens when a user clicks the widget.
        /// </summary>
        private string interactionType;

        /// <summary>
        /// If interactionType = SMARTSHEET_ITEM this is the folder to open
        /// </summary>
        private long? folderId;

        /// <summary>
        /// If interactionType = SMARTSHEET_ITEM this is the workspace to open
        /// </summary>
        private long? workspaceId;

        /// <summary>
        /// Specifies what happens when a user clicks the widget.
        /// </summary>
        /// <returns>the interaction type </returns>
        public string InteractionType
        {
            get { return interactionType; }
            set { interactionType = value; }
        }

        /// <summary>
        /// If interactionType = SMARTSHEET_ITEM this is the folder to open
        /// </summary>
        /// <returns>the folder id</returns>
        public long? FolderId
        {
            get { return folderId; }
            set { folderId = value; }
        }

        /// <summary>
        /// If interactionType = SMARTSHEET_ITEM this is the workspace to open
        /// </summary>
        /// <returns>the workspace id</returns>
        public long? WorkspaceId
        {
            get { return workspaceId; }
            set { workspaceId = value; }
        }
    }
}
