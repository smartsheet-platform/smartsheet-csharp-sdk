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

namespace Smartsheet.Api.Models
{
	/// <summary>
	/// Represents operator.
	/// </summary>
	public enum CriteriaOperator
	{
		/// <summary>
		/// EQUAL
		/// </summary>
		EQUAL,

		/// <summary>
		/// NOT_EQUAL
		/// </summary>
		NOT_EQUAL,

		/// <summary>
		/// GREATER_THAN
		/// </summary>
		GREATER_THAN,

		/// <summary>
		/// 
		/// </summary>
		LESS_THAN,

		/// <summary>
		/// CONTAINS
		/// </summary>
		CONTAINS,

		/// <summary>
		/// BETWEEN
		/// </summary>
		BETWEEN,

		/// <summary>
		/// TODAY
		/// </summary>
		TODAY,

		/// <summary>
		/// PAST
		/// </summary>
		PAST,

		/// <summary>
		/// FUTURE
		/// </summary>
		FUTURE,

		/// <summary>
		/// LAST_N_DAYS
		/// </summary>
		LAST_N_DAYS,

		/// <summary>
		/// NEXT_N_DAYS
		/// </summary>
		NEXT_N_DAYS,

		/// <summary>
		/// IS_BLANK
		/// </summary>
		IS_BLANK,

		/// <summary>
		/// IS_NOT_BLANK
		/// </summary>
		IS_NOT_BLANK,

		/// <summary>
		/// IS_NUMBER
		/// </summary>
		IS_NUMBER,

		/// <summary>
		/// IS_NOT_NUMBER
		/// </summary>
		IS_NOT_NUMBER,

		/// <summary>
		/// IS_DATE
		/// </summary>
		IS_DATE,

		/// <summary>
		/// IS_NOT_DATE
		/// </summary>
		IS_NOT_DATE,

		/// <summary>
		/// IS_CHECKED
		/// </summary>
		IS_CHECKED,


		/// <summary>
		/// IS_NOT_CHECKED
		/// </summary>
		IS_NOT_CHECKED
	}

}