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

namespace Smartsheet.Api.Models
{


	/// <summary>
	/// Represents the Tags to indicate a special column.
	/// </summary>
	public enum ColumnTag
	{
		/// <summary>
		/// Represents CALENDAR_START_DATE tag. </summary>
		CALENDAR_START_DATE,

		/// <summary>
		/// Represents CALENDAR_END_DATE tag. </summary>
		CALENDAR_END_DATE,

		/// <summary>
		/// Represents GANTT_START_DATE tag. </summary>
		GANTT_START_DATE,

		/// <summary>
		/// Represents GANTT_END_DATE tag. </summary>
		GANTT_END_DATE,

		/// <summary>
		/// Represents GANTT_PERCENT_COMPLETE tag. </summary>
		GANTT_PERCENT_COMPLETE,

		/// <summary>
		/// Represents GANTT_DISPLAY_LABEL tag. </summary>
		GANTT_DISPLAY_LABEL,

		/// <summary>
		/// Represents GANTT_PREDECESSOR tag. </summary>
		GANTT_PREDECESSOR,

		/// <summary>
		/// Represents GANTT_DURATION tag. </summary>
		GANTT_DURATION,

		/// <summary>
		/// Represents GANTT_ASSIGNED_RESOURCE. </summary>
		GANTT_ASSIGNED_RESOURCE,

		/// <summary>
		/// Represents GANTT_ALLOCATION. </summary>
		GANTT_ALLOCATION
	}

}