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
		EQUAL,
		NOT_EQUAL,
		GREATER_THAN,
		LESS_THAN,
		CONTAINS,
		BETWEEN,
		TODAY,
		PAST,
		FUTURE,
		LAST_N_DAYS,
		NEXT_N_DAYS,
		IS_BLANK,
		IS_NOT_BLANK,
		IS_NUMBER,
		IS_NOT_NUMBER,
		IS_DATE,
		IS_NOT_DATE,
		IS_CHECKED,
		IS_NOT_CHECKED
	}

}