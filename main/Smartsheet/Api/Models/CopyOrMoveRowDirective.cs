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
using System.Linq;
using System.Text;

namespace Smartsheet.Api.Models
{
    /// <summary>
    /// A CopyOrMoveRowDirective object that holds information on the direction of the rows being copied or moved to.
    /// </summary>
    public class CopyOrMoveRowDirective
    {
        private IList<long> rowIds;

        private CopyOrMoveRowDestination to;

        /// <summary>
        /// The IDs of the rows to move or copy from the source sheet
        /// </summary>
        /// <remarks>
        /// Up to 5,000 row IDs can be specified in the request,
        /// but if the total number of rows in the destination sheet after the copy exceeds the Smartsheet row limit,
        /// an error response will be returned.
        /// </remarks>
        public IList<long> RowIds
        {
            get { return rowIds; }
            set { rowIds = value; }
        }

        /// <summary>
        /// A CopyOrMoveRowDestination object that identifies the destination sheet
        /// </summary>
        public CopyOrMoveRowDestination To
        {
            get { return to; }
            set { to = value; }
        }

    }
}
