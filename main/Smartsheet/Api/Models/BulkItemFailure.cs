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

using System;
using System.Collections.Generic;

namespace Smartsheet.Api.Models
{
    /// <summary>
    /// Represents the BulkItemFailure object. </summary>
    /// <seealso href="http://smartsheet-platform.github.io/api-docs/#bulkitemfailure-object">BulkItemFailure Object Help</seealso>
    public class BulkItemFailure
    {
        /// <summary>
        /// The index of the failed item in the bulk request array. </summary>
        private long? index;

        /// <summary>
        /// The error caused by the failed item.</summary>
        private Error error;

        /// <summary>
        /// The id of the Row that failed. Applicable only to bulk row operations. </summary>
        private long? rowId;

        /// <summary>
        /// The index of the failed item in the bulk request array.
        /// </summary>
        public long? Index
        {
            get { return index; }
            set { index = value; }
        }

        /// <summary>
        /// Gets the error caused by the failed item.
        /// </summary>
        /// <returns> the Error </returns>
        public Error Error
        {
            get { return error; }
            set { error = value; }
        }
        
        /// <summary>
        /// Get the id of the Row that failed.
        /// </summary>
        public long? RowId
        {
            get { return rowId; }
            set { rowId = value; }
        }
    }
}
