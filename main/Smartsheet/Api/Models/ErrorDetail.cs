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
    class ErrorDetail
    {
        /// <summary>
        /// User's alternate email address that was specified in the request.
        /// </summary>
        private string alternateEmailAddress;

        /// <summary>
        /// When allowPartialSuccess = false, index of the row that caused the error.
        /// </summary>
        private int? index;

        /// <summary>
        /// The server-side limit on the number of sheets allowed in a single folder/workspace copy operation.
        /// </summary>
        private int? maxSheetCount;

        /// <summary>
        /// User's primary email address that must instead by specified for the operation.
        /// </summary>
        private string primaryEmailAddress;

        /// <summary>
        /// When allowPartialSuccess = false, rowID of the row that caused the error.
        /// </summary>
        private long? rowId;

        /// <summary>
        /// The ID of the top level folder or workspace that was partially copied.
        /// </summary>
        private long? topContainerId;

        /// <summary>
        /// The destination type of the top-level folder or workspace that was partially copied.
        /// </summary>
        private DestinationType? topContainerType;

        /// <summary>
        /// Gets the alternate email address that was specified in the request.
        /// </summary>
        /// <returns> the alternate email address </returns>
        public string AlternateEmailAddress 
        {
            get { return alternateEmailAddress; }
            set { this.alternateEmailAddress = value; }
        }

        /// <summary>
        /// Gets the index of the row that caused the error.
        /// </summary>
        /// <returns> the index </returns>
        public int? Index
        {
            get { return index; }
            set { this.index = value; }
        }

        /// <summary>
        /// Gets the server-side limit on the number of sheets allowed in a single copy operation.
        /// </summary>
        /// <returns> the maximum sheet count </returns>
        public int? MaxSheetCount
        {
            get { return maxSheetCount; }
            set { this.maxSheetCount = value; }
        }

        /// <summary>
        /// Gets the primary email address that should be specified in the request.
        /// </summary>
        /// <returns> the primary email address </returns>
        public string PrimaryEmailAddress
        {
            get { return primaryEmailAddress; }
            set { this.primaryEmailAddress = value; }
        }

        /// <summary>
        /// Gets the row Id of the row that caused the error.
        /// </summary>
        /// <returns> the row Id </returns>
        public long? RowId
        {
            get { return rowId; }
            set { this.rowId = value; }
        }

        /// <summary>
        /// Gets the Id of the container that was partially copied.
        /// </summary>
        /// <returns> the container Id </returns>
        public long? TopContainerId
        {
            get { return topContainerId; }
            set { this.topContainerId = value; }
        }

        /// <summary>
        /// Gets the type of the container that was partially copied.
        /// </summary>
        /// <returns> the container type </returns>
        public DestinationType? TopContainerType
        {
            get { return topContainerType; }
            set { this.topContainerType = value; }
        }
    }
}
