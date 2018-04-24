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
        CALENDAR_START_DATE,
        CALENDAR_END_DATE,
        GANTT_START_DATE,
        GANTT_END_DATE,
        GANTT_PERCENT_COMPLETE,
        GANTT_DISPLAY_LABEL,
        GANTT_PREDECESSOR,
        GANTT_DURATION,
        GANTT_ASSIGNED_RESOURCE,
        GANTT_ALLOCATION
    }

}