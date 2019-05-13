//    #[license]
//    SmartsheetClient SDK for C#
//    %%
//    Copyright (C) 2019 SmartsheetClient
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
    public class EventResult
    {
        /// <summary>
        /// Array of event information. See event reference documentation for details on each event type.
        /// </summary>
        private IList<Event> data;

        /// <summary>
        /// rue if more results are available. This is typically due to event counts exceeding the maxCount parameter passed in
        /// </summary>
        private bool? moreAvailable;

        /// <summary>
        /// This string should be passed back to the next GET events call to obtain subsequent events
        /// </summary>
        private string nextStreamPosition;

        /// <summary>
        /// Gets the list of events
        /// </summary>
        /// <returns>the list of events</returns>
        public IList<Event> Data
        {
            get { return data; }
            set { data = value; }
        }

        /// <summary>
        /// Returns if more events are available for retrieval
        /// </summary>
        /// <returns>true if more events are available, false otherwise</returns>
        public bool? MoreAvailable
        {
            get { return moreAvailable; }
            set { moreAvailable = value; }
        }

        /// <summary>
        /// Gets a string indicating the streamPosition of the next set of events
        /// </summary>
        /// <returns>the string streamPosition</returns>
        public string NextStreamPosition
        {
            get { return nextStreamPosition; }
            set { nextStreamPosition = value; }
        }
    }
}
