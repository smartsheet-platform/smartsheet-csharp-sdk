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

using System.Collections.Generic;

namespace Smartsheet.Api.Models
{
    /// <summary>
    /// Represents individual user settings for a specific sheet. 
    /// User settings may be updated even on sheets where the current user only has read access (e.g. viewer permissions or a read-only sheet). </summary>

    public class Scope
    {
        /// <summary>
        /// Array of Sheet object Ids of any sheets that the requestor has access to that make up the report
        /// </summary>
        private IList<Sheet> sheets;

        /// <summary>
        /// Array of Workspace object Ids that the requestor has access to that make up the report
        /// </summary>
        private IList<Workspace> workspaces;

        /// <summary>
        /// Gets the array of any sheets the requestor has access to that make up the report
        /// </summary>
        /// <returns>the array of sheet objects</returns>
        public IList<Sheet> Sheets
        {
            get { return sheets; }
            set { sheets = value; }
        }

        /// <summary>
        /// Gets the array of any workspaces the requestor has access to that make up the report
        /// </summary>
        /// <returns>the array of workspace objects</returns>
        public IList<Workspace> Workspaces
        {
            get { return workspaces; }
            set { workspaces = value; }
        }
    }
}
