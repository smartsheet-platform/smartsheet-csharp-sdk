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
    public class Predecessor
    {
        /// <summary>
        /// The ID of the predecessor row
        /// </summary>
        private long? rowId;

        /// <summary>
        /// The type of the predecessor. One of FS, FF, SS, or SF.
        /// </summary>
        private string type;

        /// <summary>
        /// True if this predecessor is in the critical path.
        /// </summary>
        private bool? inCriticalPath;

        /// <summary>
        /// True if the row referenced by rowId is not a valid row in this sheet, or there is a circular reference 
        /// </summary>
        private bool? invalid;

        /// <summary>
        /// The lag value of this predecessor. Omitted if there is no lag.
        /// </summary>
        private Duration lag;
        
        /// <summary>
        /// The row number of the predecessor row.
        /// </summary>
        private int? rowNumber;

        /// <summary>
        /// The ID of the predecessor row.
        /// </summary>
        /// <returns> the rowId </returns>
        public long? RowId
        {
            get { return rowId; }
            set { rowId = value; }
        }

        /// <summary>
        /// The type of the predecessor. 
        /// </summary>
        /// <returns> One of FS, FF, SS, or SF </returns>
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        /// <summary>
        /// True if this predecessor is in the critical path.
        /// </summary>
        /// <returns> the value of the inCriticalPath flag </returns>
        public bool? InCriticalPath
        {
            get { return inCriticalPath; }
            set { inCriticalPath = value; }
        }

        /// <summary>
        /// True if the row referenced by rowId is not a valid row in this sheet, or there is a circular reference.  
        /// </summary>
        /// <returns> the value of the invalid flag </returns>
        public bool? Invalid
        {
            get { return invalid; }
            set { invalid = value; }
        }

        /// <summary>
        /// The lag value of this predecessor.  
        /// </summary>
        /// <returns> the lag </returns>
        public Duration Lag
        {
            get { return lag; }
            set { lag = value; }
        }

        /// <summary>
        /// The number of the predecessor row.
        /// </summary>
        /// <returns> the rowNumber </returns>
        public int? RowNumber
        {
            get { return rowNumber; }
            set { rowNumber = value; }
        }
    }
}
