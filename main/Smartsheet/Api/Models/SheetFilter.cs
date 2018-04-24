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
    public class SheetFilter : NamedModel
    {
        /// <summary>
        /// Represents the filter type
        /// </summary>
        private SheetFilterType? filterType;

        /// <summary>
        /// Represents the details that make up the filter query
        /// </summary>
        private SheetFilterDetails query;

        /// <summary>
        /// the filter version
        /// </summary>
        private int? version;
        
        /// <summary>
        /// Gets the filter type
        /// </summary>
        public SheetFilterType? FilterType
        {
            get { return filterType; }
            set { this.filterType = value; }
        }

        /// <summary>
        /// Gets the details that make up the filter query
        /// </summary>
        public SheetFilterDetails Query
        {
            get { return query; }
            set { this.query = value; }
        }

        /// <summary>
        /// Gets the sheet filter version
        /// </summary>
        public int? Version
        {
            get { return version; }
            set { this.version = value; }
        }
    }
}
