//    #[license]
//    SmartsheetClient SDK for C#
//    %%
//    Copyright (C) 2018 SmartsheetClient
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
    public class CrossSheetReference : NamedModel
    {

        /// <summary>
        /// the final column in the reference block
        /// </summary>
        private long? endColumnId;

        /// <summary>
        /// the last row in the reference block
        /// </summary>
        private long? endRowId;

        /// <summary>
        /// the source sheet Id for the reference block
        /// </summary>
        private long? sourceSheetId;

        /// <summary>
        /// the first row of the reference block
        /// </summary>
        private long? startColumnId;

        /// <summary>
        /// the first row of the reference block
        /// </summary>
        private long? startRowId;

        /// <summary>
        /// the status of the cross-sheet reference
        /// </summary>
        private CrossSheetReferenceStatus? status;

        /// <summary>
        /// Get the last column Id in the cross-sheet reference block
        /// </summary>
        public long? EndColumnId
        {
            get { return endColumnId; }
            set { endColumnId = value; }
        }

        /// <summary>
        /// Get the last row Id in the cross-sheet reference block
        /// </summary>
        public long? EndRowId
        {
            get { return endRowId; }
            set { endRowId = value; }
        }

        /// <summary>
        /// Get the source sheet Id in the cross-sheet reference block
        /// </summary>
        public long? SourceSheetId
        {
            get { return sourceSheetId; }
            set { sourceSheetId = value; }
        }

        /// <summary>
        /// Get the first column Id in the cross-sheet reference block
        /// </summary>
        public long? StartColumnId
        {
            get { return startColumnId; }
            set { startColumnId = value; }
        }

        /// <summary>
        /// Get the first row Id in the cross-sheet reference block
        /// </summary>
        public long? StartRowId
        {
            get { return startRowId; }
            set { startRowId = value; }
        }

        /// <summary>
        /// Get the status of the cross-sheet reference block
        /// </summary>
        public CrossSheetReferenceStatus? Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}
