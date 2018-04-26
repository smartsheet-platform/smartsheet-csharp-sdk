//    #[license]
//    SmartsheetClient SDK for C#
//    %%
//    Copyright (C) 2014-2018 SmartsheetClient
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
using System.Runtime.Serialization;

namespace Smartsheet.Api.Models
{
    /// <summary>
    /// Represents the Criteria object.
    /// </summary>
    public class Criteria
    {
        /// <summary>
        /// column ID
        /// </summary>
        private long? columnId;

        /// <summary>
        /// Represents the Text for the Comment. </summary>
        [DataMember(Name = "operator")]
        private CriteriaOperator? operatorCriteria;

        /// <summary>
        /// The target for the filter query (currently only ROW for row filters)
        /// </summary>
        private CriteriaTarget? target;

        /// <summary>
        /// Present if a custom filter criteria's operator has one or more arguments
        /// </summary>
        private IList<object> values;

        /// <summary>
        /// Gets the column ID
        /// </summary>
        public long? ColumnId
        {
            get { return columnId;  }
            set { columnId = value; }
        }

        /// <summary>
        /// The Criteria Operator
        /// </summary>
        public CriteriaOperator? Operator
        {
            get { return operatorCriteria; }
            set { operatorCriteria = value; }
        }

        /// <summary>
        /// Gets the criteria target
        /// </summary>
        public CriteriaTarget? Target
        {
            get { return target; }
            set { target = value; }
        }

        /// <summary>
        /// Gets the values if this criteria's operator has arguments
        /// </summary>
        public IList<object> Values
        {
            get { return values; }
            set { values = value; }
        }
    }
}