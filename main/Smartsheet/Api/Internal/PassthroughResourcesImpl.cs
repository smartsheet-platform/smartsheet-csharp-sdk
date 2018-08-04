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
using System.Net;
using System.IO;
using System.Linq;
using System.Text;

namespace Smartsheet.Api.Internal
{
    using HttpEntity = Api.Internal.Http.HttpEntity;
    using HttpMethod = Api.Internal.Http.HttpMethod;
    using HttpRequest = Api.Internal.Http.HttpRequest;
    using HttpResponse = Api.Internal.Http.HttpResponse;
    using Utils = Api.Internal.Utility.Utility;
    using Api.Internal.Util;

    public class PassthroughResourcesImpl : AbstractResources, PassthroughResources
    {

        public PassthroughResourcesImpl(SmartsheetImpl smartsheet)
            : base(smartsheet)
        {

        }

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
        public virtual string GetRequest(string endpoint, IDictionary<string, string> parameters = null)
        {
            return PassthroughRequest(HttpMethod.GET, endpoint, null, parameters);
        }

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
        public virtual string PostRequest(string endpoint, string payload, IDictionary<string, string> parameters = null)
        {
            Utils.ThrowIfNull(payload);
            return PassthroughRequest(HttpMethod.POST, endpoint, payload, parameters);
        }

        /// <summary>
        /// <para>Issue an HTTP PUT request</para>
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
        public virtual string PutRequest(string endpoint, string payload, IDictionary<string, string> parameters = null)
        {
            Utils.ThrowIfNull(payload);
            return PassthroughRequest(HttpMethod.PUT, endpoint, payload, parameters);
        }

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
        public virtual string DeleteRequest(string endpoint)
        {
            return PassthroughRequest(HttpMethod.DELETE, endpoint, null, null);
        }

        private string PassthroughRequest(HttpMethod method, string endpoint, string payload, IDictionary<string, string> parameters)
        {
            Utils.ThrowIfNull(endpoint);
            Utils.ThrowIfEmpty(endpoint);

            if (parameters != null)
            {
                endpoint += QueryUtil.GenerateUrl(null, parameters);
            }

            HttpRequest request = null;
            try
            {
                request = CreateHttpRequest(new Uri(this.smartsheet.BaseURI, endpoint), method);
            }
            catch (Exception e)
            {
                throw new SmartsheetException(e);
            }

            if (payload != null)
            {
                HttpEntity entity = new HttpEntity();
                entity.ContentType = "application/json";
                byte[] bytes = Encoding.UTF8.GetBytes(payload);
                entity.Content = bytes;
                entity.ContentLength = bytes.Length;
                request.Entity = entity;
            }

            HttpResponse response = this.smartsheet.HttpClient.Request(request);

            string res = null;
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    StreamReader sr = response.Entity.GetContent();
                    MemoryStream ms = new MemoryStream();
                    sr.BaseStream.CopyTo(ms);
                    byte[] bytes = ms.ToArray();
                    res = Encoding.UTF8.GetString(bytes);
                    break;
                default:
                    HandleError(response);
                    break;
            }

            smartsheet.HttpClient.ReleaseConnection();

            return res;
        }
    }
}
