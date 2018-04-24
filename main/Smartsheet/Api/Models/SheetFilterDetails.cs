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
using System.Runtime.Serialization;

namespace Smartsheet.Api.Models
{
    public class SheetFilterDetails
    {
        /// <summary>
        /// Represents the list of criteria
        /// </summary>
        private IList<Criteria> criteria;

        /// <summary>
        /// Include parent rows whose children are included in this filter
        /// </summary>
        private bool? includeParent;

        /// <summary>
        /// How to combine criteria in this filter
        /// </summary>
        [DataMember(Name = "operator")] 
        private SheetFilterOperator? _operator;

        /// <summary>
        /// Get the list of criteria
        /// </summary>
        /// <returns> list of criteria </returns>
        public IList<Criteria> Criteria
        {
            get { return criteria; }
            set { this.criteria = value; }
        }

        /// <summary>
        /// Gets flag indicating whether to include parent rows whose children are included in this filter
        /// </summary>
        /// <returns> flag indicating whether to include parent </returns>
        public bool? IncludeParent
        {
            get { return includeParent; }
            set { this.includeParent = value; }
        }

        /// <summary>
        /// Gets how to combine criteria in this filter
        /// </summary>
        /// <returns> the operator </returns>
        public SheetFilterOperator? Operator
        {
            get { return _operator; }
            set { this._operator = value; }
        }
    }
}
