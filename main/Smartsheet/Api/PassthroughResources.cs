//    #[license]
//    SmartsheetClient SDK for C#
//    %%
//    Copyright (C) 2018 SmartsheetClient
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
using System.Linq;
using System.Text;

namespace Smartsheet.Api
{
    public interface PassthroughResources
    {
        /// <summary>
        /// <para>Issue an HTTP GET request</para>
        /// </summary>
        /// <param name="endpoint"> the API endpoint </param>
        /// <param name="parameters"> optional list of resource parameters </param>
        /// <returns> a JSON response string </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        string GetRequest(string endpoint, IDictionary<string, string> parameters = null);

        /// <summary>
        /// <para>Issue an HTTP POST request</para>
        /// </summary>
        /// <param name="endpoint"> the API endpoint </param>
        /// <param name="payload"> a JSON payload string </param>
        /// <param name="parameters"> optional list of resource parameters </param>
        /// <returns> a JSON response string </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        string PostRequest(string endpoint, string payload, IDictionary<string, string> parameters = null);
    
        /// <summary>
        /// <para>Issue an HTTP PUT request</para>
        /// </summary>
        /// <param name="endpoint"> the API endpoint </param>
        /// <param name="payload"> a JSON payload string </param>
        /// <param name="parameters"> optional list of resource parameters </param>
        /// <returns> a JSON response string </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        string PutRequest(string endpoint, string payload, IDictionary<string, string> parameters = null);

        /// <summary>
        /// <para>Issue an HTTP DELETE request</para>
        /// </summary>
        /// <param name="endpoint"> the API endpoint </param>
        /// <returns> a JSON response string </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        string DeleteRequest(string endpoint);
    }
}
