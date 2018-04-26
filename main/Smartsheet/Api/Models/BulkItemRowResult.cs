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
    /// Represents the BulkItemRowResult object. </summary>
    /// <seealso href="http://smartsheet-platform.github.io/api-docs/?shell#partial-success">Partial Success</seealso>
    public class BulkItemRowResult
    {
        /// <summary>
        /// 0 if successful, 3 for partial success of a bulk operation
        /// </summary>
        private int? resultCode;

        /// <summary>
        /// Message that indicates the outcome of the request
        /// </summary>
        private string message;

        /// <summary>
        /// Row object(s) created or updated
        /// </summary>
        private IList<Row> result;

        /// <summary>
        /// Array of BulkItemFailure objects which represents the items that failed to be added or updated
        /// </summary>
        private IList<BulkItemFailure> failedItems;

        /// <summary>
        /// Gets the result Code.
        /// </summary>
        /// <returns> the result Code </returns>
        public int? ResultCode
        {
            get { return resultCode; }
            set { resultCode = value; }
        }

        /// <summary>
        /// Gets the Message.
        /// </summary>
        /// <returns> the Message </returns>
        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        /// <summary>
        /// Row results created or updated.
        /// </summary>
        /// <returns> Array of Row objects </returns>
        public IList<Row> Result
        {
            get { return result; }
            set { result = value; }
        }

        /// <summary>
        /// Array of BulkItemFailure objects which represents the items that failed to be added or updated. 
        /// </summary>
        /// <returns> the Description </returns>
        public IList<BulkItemFailure> FailedItems
        {
            get { return failedItems; }
            set { failedItems = value; }
        }
    }
}
