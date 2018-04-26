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
    /// Represents the Results of a search. </summary>
    /// <seealso href="http://help.Smartsheet.com/customer/portal/articles/522231-searching-in-Smartsheet">Help Searching in 
    /// Smartsheet</seealso>
    public class SearchResult
    {
        /// <summary>
        /// A list of items returned from the search Results.
        /// </summary>
        private IList<SearchResultItem> results;

        /// <summary>
        /// Represents total count of Results.
        /// </summary>
        private int? totalCount;

        /// <summary>
        /// Gets the list of Results from the search.
        /// </summary>
        /// <returns> the Results </returns>
        public IList<SearchResultItem> Results
        {
            get { return results; }
            set { results = value; }
        }

        /// <summary>
        /// Gets the total count of Results.
        /// </summary>
        /// <returns> the total count </returns>
        public int? TotalCount
        {
            get { return totalCount; }
            set { totalCount = value; }
        }
    }
}