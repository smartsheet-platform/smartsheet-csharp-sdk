using System.Collections.Generic;
using Smartsheet.Api.Internal.http;
namespace Smartsheet.Api.Internal.http
{

    /*
     * #[license]
     * Smartsheet SDK for C#
     * %%
     * Copyright (C) 2014 Smartsheet
     * %%
     * Licensed under the Apache License, Version 2.0 (the "License");
     * you may not use this file except in compliance with the License.
     * You may obtain a copy of the License at
     * 
     *      http://www.apache.org/licenses/LICENSE-2.0
     * 
     * Unless required by applicable law or agreed To in writing, software
     * distributed under the License is distributed on an "AS IS" BASIS,
     * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
     * See the License for the specific language governing permissions and
     * limitations under the License.
     * %[license]
     */


    //using HttpHeaders = org.apache.http.HttpHeaders;
    //using ClientProtocolException = org.apache.http.client.ClientProtocolException;
    //using RequestConfig = org.apache.http.client.config.RequestConfig;
    //using CloseableHttpResponse = org.apache.http.client.methods.CloseableHttpResponse;
    //using HttpDelete = org.apache.http.client.methods.HttpDelete;
    //using HttpEntityEnclosingRequestBase = org.apache.http.client.methods.HttpEntityEnclosingRequestBase;
    //using HttpGet = org.apache.http.client.methods.HttpGet;
    //using HttpPost = org.apache.http.client.methods.HttpPost;
    //using HttpPut = org.apache.http.client.methods.HttpPut;
    //using InputStreamEntity = org.apache.http.Entity.InputStreamEntity;
    //using CloseableHttpClient = org.apache.http.impl.client.CloseableHttpClient;
    //using HttpClients = org.apache.http.impl.client.HttpClients;

    using Util = Api.Internal.util.Util;
    using RestSharp;
    using System.Reflection;
    using System;

    /// <summary>
    /// This is the Apache HttpClient (http://hc.apache.org/httpcomponents-client-ga/Index.html) based HttpClient
    /// implementation.
    /// 
    /// Thread Safety: This class is thread safe because it is immutable and the underlying Apache CloseableHttpClient is
    /// thread safe.
    /// </summary>

    public class DefaultHttpClient : HttpClient
    {
        /// <summary>
        /// Represents the underlying Apache CloseableHttpClient.
        /// 
        /// It will be initialized in constructor and will not change afterwards.
        /// </summary>
        private readonly RestClient httpClient;

        /// <summary>
        /// The apache http request. </summary>
        private RestRequest apacheHttpRequest;

        /// <summary>
        /// The apache http response. </summary>
        private IRestResponse apacheHttpResponse;

        ///// <summary>
        ///// Constructor.
        ///// </summary>
        public DefaultHttpClient()
            : this(new RestClient())
        {
        }

        /// <summary>
        /// Constructor.
        /// 
        /// Parameters: - HttpClient : the Apache CloseableHttpClient To use
        /// 
        /// Exceptions: - IllegalArgumentException : if any argument is null
        /// </summary>
        /// <param Name="HttpClient"> the http client </param>
        public DefaultHttpClient(RestClient httpClient)
        {
            Util.ThrowIfNull(httpClient);

            this.httpClient = httpClient;
            this.httpClient.FollowRedirects = true;
            this.httpClient.UserAgent = buildUserAgent();
            
            
        }

        /// <summary>
        /// Make an HTTP request and return the response.
        /// </summary>
        /// <param Name="smartsheetRequest"> the Smartsheet request </param>
        /// <returns> the HTTP response </returns>
        /// <exception cref="HttpClientException"> the HTTP client exception </exception>
        public virtual HttpResponse Request(HttpRequest smartsheetRequest)
        {
            Util.ThrowIfNull(smartsheetRequest);
            if (smartsheetRequest.Uri == null)
            {
                throw new System.ArgumentException("A Request URI is required.");
            }

            HttpResponse smartsheetResponse = new HttpResponse();

            // Create Apache HTTP request based on the smartsheetRequest request Type
            if (HttpMethod.GET == smartsheetRequest.Method)
            {
                apacheHttpRequest = new RestRequest(smartsheetRequest.Uri, Method.GET);
            }
            else if (HttpMethod.POST == smartsheetRequest.Method)
            {
                apacheHttpRequest = new RestRequest(smartsheetRequest.Uri, Method.POST);
            }
            else if (HttpMethod.PUT == smartsheetRequest.Method)
            {
                apacheHttpRequest = new RestRequest(smartsheetRequest.Uri, Method.PUT);
            }
            else if (HttpMethod.DELETE == smartsheetRequest.Method)
            {
                apacheHttpRequest = new RestRequest(smartsheetRequest.Uri, Method.DELETE);
            }
            else
            {
                throw new System.NotSupportedException("Request method " + smartsheetRequest.Method + " is not supported!");
            }

            // Set HTTP Headers
            if (smartsheetRequest.Headers != null)
            {
                foreach (KeyValuePair<string, string> header in smartsheetRequest.Headers)
                {
                    apacheHttpRequest.AddHeader(header.Key, header.Value);
                }
            }
            
            if (smartsheetRequest.Entity != null && smartsheetRequest.Entity.getContent() != null)
            {
                apacheHttpRequest.AddParameter("application/json", smartsheetRequest.Entity.getContent(), ParameterType.RequestBody);
            }

            // Set the client base Url.
            httpClient.BaseUrl = smartsheetRequest.Uri.GetLeftPart(UriPartial.Authority);

            // Make the HTTP request
            apacheHttpResponse = httpClient.Execute(apacheHttpRequest);

            //FIXME: example that writes the response To a stream.
            //string tempFile = Path.GetTempFileName();
            //using (var writer = File.OpenWrite(tempFile))
            //{
            //    var client = new RestClient(baseUrl);
            //    var request = new RestRequest("Assets/LargeFile.7z");
            //    request.ResponseWriter = (responseStream) => responseStream.CopyTo(writer);
            //    var response = client.DownloadData(request);
            //}
            

            if (apacheHttpResponse.ResponseStatus == ResponseStatus.Error)
            {
                throw new HttpClientException("There was an issue connecting.");
            }

            // Set returned Headers
            smartsheetResponse.Headers = new Dictionary<string, string>();
            foreach (var header in apacheHttpResponse.Headers)
            {
                smartsheetResponse.Headers[header.Name] = (String)header.Value;
            }
            smartsheetResponse.StatusCode = apacheHttpResponse.StatusCode;

            // Set returned entities
            if (apacheHttpResponse.Content != null)
            {
                HttpEntity entity = new HttpEntity();
                entity.ContentType = apacheHttpResponse.ContentType;
                entity.ContentLength = apacheHttpResponse.ContentLength;

                entity.Content = apacheHttpResponse.Content;
                smartsheetResponse.Entity = entity;
            }

            return smartsheetResponse;
        }

        /// <summary>
        /// Close the HttpClient.
        /// </summary>
        public virtual void Close()
        {
            // Not necessary with restsharp
        }

        public virtual void ReleaseConnection()
        {
            // Not necessar with restsharp
        }

        private string buildUserAgent()
        {
            // Set User Agent
            string thisVersion = "";
            string title = "";
            Assembly assembly = Assembly.GetEntryAssembly();
            if (assembly != null)
            {
                thisVersion = assembly.GetName().Version.ToString();
                title = assembly.GetName().Name;
            }
            return "smartsheet-csharp-sdk("+title + ")/" + thisVersion + " " + Util.GetOSFriendlyName();
        }
    }

}