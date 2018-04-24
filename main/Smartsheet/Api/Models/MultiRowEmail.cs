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

using System.Collections.Generic;
namespace Smartsheet.Api.Models
{
    /// <summary>
    /// Represents MultiRowEmail object. </summary>
    /// <seealso href="http://help.Smartsheet.com/customer/portal/articles/504773-sending-Sheets-Rows-via-Email">Help Sending 
    /// Sheets &amp; Rows via Email</seealso>
    public class MultiRowEmail : RowEmail
    {
        private IList<long> rowIds;

        /// <summary>
        /// IDs of rows to be included.
        /// </summary>
        public virtual IList<long> RowIds
        {
            get { return rowIds; }
            set { rowIds = value; }
        }
    }
}