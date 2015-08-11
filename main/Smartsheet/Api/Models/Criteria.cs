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
//    Unless required by applicable law or agreed To in writing, software
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
		/// Represents the Text for the Comment. </summary>
		[DataMember(Name="operator")]
		private CriteriaOperator? operatorCriteria;

		/// <summary>
		/// Optional. Present if a custom filter criteria’s operator has two arguments.
		/// </summary>
		private object value1;

		/// <summary>
		/// Optional. Present if a custom filter criteria’s operator has two arguments.
		/// </summary>
		private object value2;

		/// <summary>
		/// The Criteria Operator
		/// </summary>
		public CriteriaOperator? Operator
		{
			get { return operatorCriteria; }
			set { operatorCriteria = value; }
		}

		/// <summary>
		/// Present if a custom filter criteria’s operator has one or more arguments.
		/// </summary>
		public object Value1
		{
			get { return value1; }
			set { value1 = value; }
		}

		/// <summary>
		/// Present if a custom filter criteria’s operator has two arguments.
		/// </summary>
		public object Value2
		{
			get { return value2; }
			set { value2 = value; }
		}
	}
}