﻿//    #[license]
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

namespace Smartsheet.Api
{
    using NLog;
    using System;
    using SmartsheetImpl = Api.Internal.SmartsheetImpl;
    using DefaultHttpClient = Api.Internal.Http.DefaultHttpClient;
    using HttpClient = Api.Internal.Http.HttpClient;
    using JsonNetSerializer = Api.Internal.Json.JsonNetSerializer;
    using JsonSerializer = Api.Internal.Json.JsonSerializer;

    /// <summary>
    /// <para>A convenience class to help create a <seealso cref="SmartsheetClient"/> instance with the appropriate fields.</para>
    /// 
    /// <para>Thread Safety: This class is not thread safe since it's mutable, one builder instance is NOT expected to be used in
    /// multiple threads.</para>
    /// </summary>
    public class SmartsheetBuilder
    {
        /// <summary>
        /// <para>Represents the HttpClient.</para>
        /// 
        /// <para>It can be set using corresponding setter.</para>
        /// </summary>
        private HttpClient httpClient;

        /// <summary>
        /// <para>Represents the JsonSerializer.</para>
        /// 
        /// <para>It can be set using corresponding setter.</para>
        /// </summary>
        private JsonSerializer jsonSerializer;

        /// <summary>
        /// <para>Represents the base URI.</para>
        /// 
        /// <para>It can be set using corresponding setter.</para>
        /// </summary>
        private string baseURI;

        /// <summary>
        /// <para>Represents the access token.</para>
        /// 
        /// <para>It can be set using corresponding setter.</para>
        /// </summary>
        private string accessToken;

        /// <summary>
        /// <para>Represents the max retry timeout period.</para>
        /// 
        /// <para>It can be set using corresponding setter.</para>
        /// </summary>
        private long? maxRetryTimeout;

        /// <summary>
        /// <para>Represents the assumed user.</para>
        /// 
        /// <para>It can be set using corresponding setter.</para>
        /// </summary>
        private string assumedUser;

        /// <summary>
        /// <para>Represents the Smartsheet change agent.</para>
        /// 
        /// <para>It can be set using corresponding setter.</para>
        /// </summary>
        private string changeAgent;

        /// <summary>
        /// Optional setting to re-enable the JSON serializers string to C# DateTime conversion
        /// </summary>
        private bool dateTimeFixOptOut = false;

        /// <summary>
        /// <para>Represents the default base URI of the Smartsheet REST API.</para>
        /// 
        /// <para>It is a constant with Value "https://api.smartsheet.com/2.0".</para>
        /// </summary>
        public const string DEFAULT_BASE_URI = "https://api.smartsheet.com/2.0/";

        /// <summary>
        /// <para>Represents the base URI of the Smartsheetgov REST API.</para>
        /// 
        /// <para>It is a constant with Value "https://api.smartsheetgov.com/2.0".</para>
        /// </summary>
        public const string GOV_BASE_URI = "https://api.smartsheetgov.com/2.0/";

        /// <summary>
        /// <para>Represents the base URI of the SmartsheetEurope REST API.</para>
        /// 
        /// <para>It is a constant with Value "https://api.smartsheet.eu/2.0".</para>
        /// </summary>
        public const string EU_BASE_URI = "https://api.smartsheet.eu/2.0/";
        
        /// <summary>
        /// Constructor.
        /// </summary>
        public SmartsheetBuilder()
        {
        }

        /// <summary>
        /// <para>Set the HttpClient.</para>
        /// </summary>
        /// <param name="httpClient"> the http client </param>
        /// <returns> the SmartsheetClient builder </returns>
        public SmartsheetBuilder SetHttpClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            return this;
        }

        /// <summary>
        /// <para>Set the JsonSerializer.</para>
        /// </summary>
        /// <param name="jsonSerializer"> the JsonSerializer </param>
        /// <returns> the SmartsheetBuilder </returns>
        public SmartsheetBuilder SetJsonSerializer(JsonSerializer jsonSerializer)
        {
            this.jsonSerializer = jsonSerializer;
            return this;
        }

        /// <summary>
        /// <para>Set the base URI.</para>
        /// </summary>
        /// <param name="baseURI"> the base uri </param>
        /// <returns> the SmartsheetClient builder </returns>
        public SmartsheetBuilder SetBaseURI(string baseURI)
        {
            this.baseURI = baseURI;
            return this;
        }

        /// <summary>
        /// <para>Set the access token.</para>
        /// </summary>
        /// <param name="accessToken"> the access token </param>
        /// <returns> the SmartsheetClient builder </returns>
        public SmartsheetBuilder SetAccessToken(string accessToken)
        {
            this.accessToken = accessToken;
            return this;
        }

        /// <summary>
        /// <para>Set the assumed user.</para>
        /// </summary>
        /// <param name="assumedUser"> the assumed user </param>
        /// <returns> the SmartsheetClient builder </returns>
        public SmartsheetBuilder SetAssumedUser(string assumedUser)
        {
            this.assumedUser = assumedUser;
            return this;
        }

        /// <summary>
        /// <para>Set the Smartsheet change agent.</para>
        /// </summary>
        /// <param name="changeAgent"> the change agent </param>
        /// <returns> the SmartsheetClient builder </returns>
        public SmartsheetBuilder SetChangeAgent(string changeAgent)
        {
            this.changeAgent = changeAgent;
            return this;
        }

        /// <summary>
        /// Create a DefaultCalcBackoff with a max elapsed timeout specified by the user. This interface 
        /// is only valid when the DefaultHttpClient is used.
        /// </summary>
        /// <param name="maxRetryTimeout"></param>
        /// <returns></returns>
        public SmartsheetBuilder SetMaxRetryTimeout(long maxRetryTimeout)
        {
            this.maxRetryTimeout = maxRetryTimeout;
            return this;
        }

        /// <summary>
        /// Set optional flag to re-enable JSON deserializers conversion from string to C# DateTime
        /// </summary>
        /// <param name="dateTimeFixOptOut"></param>
        /// <returns></returns>
        public SmartsheetBuilder SetDateTimeFixOptOut(bool dateTimeFixOptOut)
        {
            this.dateTimeFixOptOut = dateTimeFixOptOut;
            return this;
        }

        /// <summary>
        /// <para>Gets the http client.</para>
        /// </summary>
        /// <returns> the http client </returns>
        public HttpClient HttpClient
        {
            get { return httpClient; }
        }

        /// <summary>
        /// <para>Gets the Json serializer.</para>
        /// </summary>
        /// <returns> the Json serializer </returns>
        public JsonSerializer JsonSerializer
        {
            get { return jsonSerializer; }
        }

        /// <summary>
        /// <para>Gets the base uri.</para>
        /// </summary>
        /// <returns> the base uri </returns>
        public string BaseURI
        {
            get { return baseURI; }
        }

        /// <summary>
        /// <para>Gets the access token.</para>
        /// </summary>
        /// <returns> the access token </returns>
        public string AccessToken
        {
            get { return accessToken; }
        }

        /// <summary>
        /// <para>Gets the assumed user.</para>
        /// </summary>
        /// <returns> the assumed user </returns>
        public string AssumedUser
        {
            get { return assumedUser; }
        }

        /// <summary>
        /// <para>Gets the default base uri.</para>
        /// </summary>
        /// <returns> the default base uri </returns>
        public static string DefaultBaseUri
        {
            get { return DEFAULT_BASE_URI; }
        }

        /// <summary>
        /// <para>Build the SmartsheetClient instance.</para>
        /// </summary>
        /// <returns> the SmartsheetClient instance </returns>
        public SmartsheetClient Build()
        {
            if (baseURI == null)
            {
                baseURI = DEFAULT_BASE_URI;
            }

            if (accessToken == null)
            {
                accessToken = Environment.GetEnvironmentVariable("SMARTSHEET_ACCESS_TOKEN");
            }

            SmartsheetImpl smartsheet = new SmartsheetImpl(baseURI, accessToken, httpClient, jsonSerializer, dateTimeFixOptOut);

            if (changeAgent != null)
            {
                smartsheet.ChangeAgent = changeAgent;
            }

            if (assumedUser != null)
            {
                smartsheet.AssumedUser = assumedUser;
            }

            if (maxRetryTimeout != null)
            {
                smartsheet.MaxRetryTimeout = maxRetryTimeout.Value;
            }

            return smartsheet;
        }
    }

}
