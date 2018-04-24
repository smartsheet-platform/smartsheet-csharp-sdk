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
    /// Represents CellHistory object. </summary>
    /// <seealso href="http://help.Smartsheet.com/customer/portal/articles/518314-viewing-cell-history">Cell History Documentation </seealso>
    public class CellHistory : Cell
    {
        /// <summary>
        /// Represents the user that modified the cell.
        /// </summary>
        private User modifiedBy;

        /// <summary>
        /// The date the cell was modified. </summary>
        private DateTime? modifiedAt;

        /// <summary>
        /// Gets the date the cell was modified.
        /// </summary>
        /// <returns> the modified at </returns>
        public virtual DateTime? ModifiedAt
        {
            get { return modifiedAt; }
            set { this.modifiedAt = value; }
        }

        /// <summary>
        /// Gets the user that modified the cell.
        /// </summary>
        /// <returns> the modified by </returns>
        public virtual User ModifiedBy
        {
            get { return modifiedBy; }
            set { this.modifiedBy = value; }
        }
    }
}