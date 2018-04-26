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

using System;
using System.Collections.Generic;

namespace Smartsheet.Api.Models
{
    /// <summary>
    /// Represents the Schedule object.</summary>
    /// <seealso href="http://smartsheet-platform.github.io/api-docs/#schedule-object">Schedule Object Help</seealso>    
    public class Schedule
    {
        /// <summary>
        /// Schedule type
        /// </summary>
        private ScheduleType? type;

        /// <summary>
        /// The date, time and time zone at which the first delivery will start.
        /// </summary>
        private DateTime startAt;

        /// <summary>
        /// The date, time and time zone at which the delivery schedule will end.
        /// </summary>
        private DateTime endAt;

        /// <summary>
        /// The day within the month
        /// </summary>
        private int? dayOfMonth;

        /// <summary>
        /// It must be one of the following values
        /// </summary>
        private DayOrdinal dayOrdinal;

        /// <summary>
        /// A string array of day descriptors
        /// </summary>
        private IList<DayDescriptor> dayDescriptors;

        /// <summary>
        /// Frequency on which the request will be delivered. 
        /// </summary>
        private int? repeatEvery;

        /// <summary>
        /// The date and time for when the last request was sent. Read-only.
        /// </summary>
        private DateTime lastSentAt;

        /// <summary>
        /// The date and time for when the next request is scheduled to send. Read-only.
        /// </summary>
        private DateTime nextSendAt;

        /// <summary>
        /// Gets the scheudle type
        /// </summary>
        /// <returns> the ScheduleType </returns>
        public ScheduleType? Type
        {
            get { return type; }
            set { type = value; }
        }

        /// <summary>
        /// Gets the date, time and time zone at which the first delivery will start
        /// </summary>
        /// <returns> the timestamp </returns>
        public DateTime StartAt
        {
            get { return startAt; }
            set { startAt = value; }
        }

        /// <summary>
        /// Gets the date, time and time zone at which the delivery schedule will end.
        /// </summary>
        /// <returns> the timestamp </returns>
        public DateTime EndAt
        {
            get { return endAt; }
            set { endAt = value; }
        }
        
        /// <summary>
        /// Get the day within the month.
        /// </summary>
        /// <returns> the day </returns>
        public int? DayOfMonth
        {
            get { return dayOfMonth; }
            set { dayOfMonth = value; }
        }

        /// <summary>
        /// A string with the day ordinal.
        /// </summary>
        /// <returns> the day ordinal </returns>
        public DayOrdinal DayOrdinal
        {
            get { return dayOrdinal; }
            set { dayOrdinal = value; }
        }

        /// <summary>
        /// A string array of day descriptors.
        /// </summary>
        /// <returns> the array of day descriptors </returns>
        public IList<DayDescriptor> DayDescriptors
        {
            get { return dayDescriptors; }
            set { dayDescriptors = value; }
        }

        /// <summary>
        /// Gets the frequency on which the request will be delivered.
        /// </summary>
        /// <returns> the repeat frequency </returns>
        public int? RepeatEvery
        {
            get { return repeatEvery; }
            set { repeatEvery = value; }
        }

        /// <summary>
        /// Gets the The date and time for when the last request was sent. Read-only
        /// </summary>
        /// <returns> the timestamp </returns>
        public DateTime LastSentAt
        {
            get { return lastSentAt; }
            set { lastSentAt = value; }
        }

        /// <summary>
        /// The date and time for when the next request is scheduled to send. Read-only.
        /// </summary>
        /// <returns> the timestamp </returns>
        public DateTime NextSendAt
        {
            get { return nextSendAt; }
            set { nextSendAt = value; }
        }
    }
}
