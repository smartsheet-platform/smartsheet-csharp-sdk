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

using Smartsheet.Api.Models;

namespace Smartsheet.Api
{
    public interface EventResources
    {
        /// <summary>
        /// <para>List all events</para>
        /// </summary>
        /// <param name="since"> Starting time for events to return. You must pass in a value for either since or
        ///     streamPosition and never both. </param>
        /// <param name="streamPosition"> Indicates next set of events to return. Use value of nextStreamPosition returned
        ///     from the previous call.You must pass in a value for either since or streamPosition
        ///     and never both.optional list of resource parameters </param>
        /// <param name="maxCount"> Maximum number of events to return as response to this call. Must be between
        ///     1 through 10,000 (inclusive). </param>
        /// <param name="numericDates"> If true, dates are accepted and returned in Unix epoch time (milliseconds since midnight
        ///     on January 1, 1970 in UTC time). Default is false, which means ISO-8601 format </param>
        /// <returns> A list of all events (note that an empty list will be returned if there are none). </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        EventResult ListEvents(object since, string streamPosition, int? maxCount, bool? numericDates);
    }
}

