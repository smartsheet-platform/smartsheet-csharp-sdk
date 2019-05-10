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
    public class Event
    {
        /// <summary>
        /// Name of the access token embedded in the request.
        /// </summary>
        private string accessTokenName;

        /// <summary>
        /// The action applied to the specified object
        /// </summary>
        private EventAction action;

        /// <summary>
        /// Container object for additional event-specific properties.
        /// </summary>
        private Dictionary<string, object> additionalDetails;

        /// <summary>
        /// Unique event identifier
        /// </summary>
        private string eventId;

        /// <summary>
        /// Date and time of the event
        /// </summary>
        private object eventTimestamp;

        /// <summary>
        /// The identifier of the object impacted by the event
        /// </summary>
        private object objectId;

        /// <summary>
        /// The Smartsheet resource impacted by the event
        /// </summary>
        private EventObjectType objectType;

        /// <summary>
        /// User whose authentication credential is embedded in the request that initiated the event
        /// </summary>
        private long? requestUserId;

        /// <summary>
        /// Identifies the type of action that triggered the event
        /// </summary>
        private EventSource source;

        /// <summary>
        /// User assumed as the one who initiated the event.
        /// </summary>
        private long? userId;

        /// <summary>
        /// Gets the access token name associated with the event, can be null
        /// </summary>
        /// <returns>the access token name associated with the event</returns>
        public string AccessTokenName
        {
            get { return accessTokenName; }
            set { accessTokenName = value; }
        }

        /// <summary>
        /// Gets the action associated with the event (EventAction enumeration)
        /// </summary>
        /// <returns>the event action</returns>
        public EventAction Action
        {
            get { return action; }
            set { action = value; }
        }

        /// <summary>
        /// Returns a dictionary of additional details associated with the event
        /// </summary>
        /// <returns>the dictionary</returns>
        public Dictionary<string, object> AdditionalDetails
        {
            get { return additionalDetails; }
            set { additionalDetails = value; }
        }

        /// <summary>
        /// Gets a unique event ID
        /// </summary>
        /// <returns>the event ID</returns>
        public string EventId
        {
            get { return eventId; }
            set { eventId = value; }
        }

        /// <summary>
        /// Gets an event timestamp, either a Date object, or Long if numericDates parameter is true on API call.
        /// </summary>
        public object EventTimestamp
        {
            get { return eventTimestamp; }
            set { eventTimestamp = value; }
        }

        /// <summary>
        /// Get the object ID of the object associated with the event
        /// </summary>
        /// <returns>the object ID</returns>
        public object ObjectId
        {
            get { return objectId; }
            set { objectId = value; }
        }

        /// <summary>
        /// Gets the object type of the object associated with the event (EventObjectType enumeration)
        /// </summary>
        /// <returns>the object type</returns>
        public EventObjectType ObjectType
        {
            get { return objectType; }
            set { objectType = value; }
        }

        /// <summary>
        /// Get the user ID of the user whose credential initiated the request
        /// </summary>
        /// <returns>the request user ID</returns>
        public long? RequestUserId
        {
            get { return requestUserId; }
            set { requestUserId = value; }
        }

        /// <summary>
        /// Gets the source of the event request (EventSource enumeration)
        /// </summary>
        /// <returns>the event source</returns>
        public EventSource Source
        {
            get { return source; }
            set { source = value; }
        }

        /// <summary>
        /// Gets the assumed user ID for the event request
        /// </summary>
        /// <returns>the assumed user ID</returns>
        public long? UserId
        {
            get { return userId; }
            set { userId = value; }
        }
    }
}
