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

using System.Collections.Generic;
using Smartsheet.Api.Internal;
using Smartsheet.Api.Internal.Http;
using Smartsheet.Api.Internal.Json;

namespace Smartsheet.Api.Internal.Http
{
    using Util = Api.Internal.Utility.Utility;
    using RestSharp;
    using System;
    using System.IO;
    using System.Net;
    using System.Linq;
    using System.Diagnostics;
    using System.Text;
    using System.Threading;
    using NLog;

    /// <summary>
    /// This is the RestSharp based HttpClient implementation.
    /// 
    /// Thread Safety: This class is thread safe because it is immutable and the underlying http client is
    /// thread safe.
    /// </summary>

    public class DefaultHttpClient : HttpClient
    {
        /// <summary>
        /// Represents the underlying http client.
        /// 
        /// It will be initialized in constructor and will not change afterwards.
        /// </summary>
        protected readonly RestClient httpClient;

        /// <summary>
        /// static logger 
        /// </summary>
        protected static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The JSON serializer (used to deserialize errors for ShouldRetry
        /// </summary>
        protected JsonSerializer jsonSerializer;

        /// <summary>
        /// maximum retry timeout used by ShouldRetry
        /// </summary>
        protected long maxRetryTimeout = 15000;

        /// <summary>
        /// The http request. </summary>
        private RestRequest restRequest;

        /// <summary>
        /// The http response. </summary>
        private IRestResponse restResponse;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="previousAttempts"></param>
        /// <param name="totalElapsedTime"></param>
        /// <param name="response"></param>
        /// <returns></returns>
        private static bool DefaultShouldRetry(int previousAttempts, long totalElapsedTime, HttpResponse response)
        {
            return false;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public DefaultHttpClient()
            : this(new RestClient(), new JsonNetSerializer())
        {
        }

        /// <summary>
        /// Constructor.
        /// 
        /// Parameters: - HttpClient : the http client to use
        /// 
        /// Exceptions: - IllegalArgumentException : if any argument is null
        /// </summary>
        /// <param name="httpClient"> the http client </param>
        /// <param name="jsonSerializer"> custom JSON serializer </param>
        public DefaultHttpClient(RestClient httpClient, JsonSerializer jsonSerializer)
        {
            Util.ThrowIfNull(httpClient);

            this.httpClient = httpClient;
            this.httpClient.FollowRedirects = true;
            this.jsonSerializer = jsonSerializer;
        }

        /// <summary>
        /// Make a multipart HTTP request and return the response.
        /// </summary>
        /// <param name="smartsheetRequest"> the Smartsheet request </param>
        /// <param name="file">the full file path</param>
        /// <param name="fileType">the file type, or also called the conent type of the file</param>
        /// <param name="objectType">the object name, for example 'comment', or 'discussion'</param>
        /// <returns> the HTTP response </returns>
        /// <exception cref="HttpClientException"> the HTTP client exception </exception>
        public virtual HttpResponse Request(HttpRequest smartsheetRequest, string objectType, string file, string fileType)
        {
            Util.ThrowIfNull(smartsheetRequest);
            if (smartsheetRequest.Uri == null)
            {
                throw new System.ArgumentException("A Request URI is required.");
            }

            HttpResponse smartsheetResponse = new HttpResponse();

            restRequest = CreateRestRequest(smartsheetRequest);

            // Set HTTP Headers
            if (smartsheetRequest.Headers != null)
            {
                foreach (KeyValuePair<string, string> header in smartsheetRequest.Headers)
                {
                    restRequest.AddHeader(header.Key, header.Value);
                }
            }

            restRequest.AddFile("file", File.ReadAllBytes(file), new FileInfo(file).Name, fileType);
            if (smartsheetRequest.Entity != null && smartsheetRequest.Entity.GetContent() != null)
            {
                restRequest.AddParameter(objectType.ToLower(), System.Text.Encoding.Default.GetString(smartsheetRequest.Entity.Content),
                    smartsheetRequest.Entity.ContentType, ParameterType.RequestBody);
            }

            restRequest.AlwaysMultipartFormData = true;

            // Set the client base Url.
            httpClient.BaseUrl = new Uri(smartsheetRequest.Uri.GetLeftPart(UriPartial.Authority));

            Stopwatch timer = new Stopwatch();

            // Make the HTTP request
            timer.Start();
            restResponse = httpClient.Execute(restRequest);
            timer.Stop();

            LogRequest(restRequest, restResponse, timer.ElapsedMilliseconds);

            if (restResponse.ResponseStatus == ResponseStatus.Error)
            {
                throw new HttpClientException("There was an issue connecting.");
            }

            // Set returned Headers
            smartsheetResponse.Headers = new Dictionary<string, string>();
            foreach (var header in restResponse.Headers)
            {
                smartsheetResponse.Headers[header.Name] = (String)header.Value;
            }
            smartsheetResponse.StatusCode = restResponse.StatusCode;

            // Set returned entities
            if (restResponse.Content != null)
            {
                HttpEntity entity = new HttpEntity();
                entity.ContentType = restResponse.ContentType;
                entity.ContentLength = restResponse.ContentLength;

                entity.Content = restResponse.RawBytes;
                smartsheetResponse.Entity = entity;
            }

            return smartsheetResponse;
        }

        /// <summary>
        /// Make an HTTP request and return the response.
        /// </summary>
        /// <param name="smartsheetRequest"> the Smartsheet request </param>
        /// <returns> the HTTP response </returns>
        /// <exception cref="HttpClientException"> the HTTP client exception </exception>
        public virtual HttpResponse Request(HttpRequest smartsheetRequest)
        {
            Util.ThrowIfNull(smartsheetRequest);
            if (smartsheetRequest.Uri == null)
            {
                 throw new System.ArgumentException("A Request URI is required.");
            }

            int attempt = 0;
            HttpResponse smartsheetResponse = null;

            Stopwatch totalElapsed = new Stopwatch();
            totalElapsed.Start();

            while (true)
            {
                smartsheetResponse = new HttpResponse();

                restRequest = CreateRestRequest(smartsheetRequest);

                // Set HTTP Headers
                if (smartsheetRequest.Headers != null)
                {
                    foreach (KeyValuePair<string, string> header in smartsheetRequest.Headers)
                    {
                        restRequest.AddHeader(header.Key, header.Value);
                    }
                }

                if (smartsheetRequest.Entity != null && smartsheetRequest.Entity.GetContent() != null)
                {
                    restRequest.AddParameter(smartsheetRequest.Entity.ContentType, Util.ReadAllBytes(smartsheetRequest.Entity.GetBinaryContent()), 
                        smartsheetRequest.Entity.ContentType, ParameterType.RequestBody);
                }

                // Set the client base Url.
                httpClient.BaseUrl = new Uri(smartsheetRequest.Uri.GetLeftPart(UriPartial.Authority));

                Stopwatch timer = new Stopwatch();

                // Make the HTTP request
                timer.Start();
                restResponse = httpClient.Execute(restRequest);
                timer.Stop();

                LogRequest(restRequest, restResponse, timer.ElapsedMilliseconds);

                if (restResponse.ResponseStatus == ResponseStatus.Error)
                {
                    throw new HttpClientException("There was an issue connecting.");
                }

                // Set returned Headers
                smartsheetResponse.Headers = new Dictionary<string, string>();
                foreach (var header in restResponse.Headers)
                {
                    smartsheetResponse.Headers[header.Name] = (String)header.Value;
                }
                smartsheetResponse.StatusCode = restResponse.StatusCode;

                // Set returned entities
                if (restResponse.Content != null)
                {
                    HttpEntity entity = new HttpEntity();
                    entity.ContentType = restResponse.ContentType;
                    entity.ContentLength = restResponse.ContentLength;

                    entity.Content = restResponse.RawBytes;
                    smartsheetResponse.Entity = entity;
                }

                if (smartsheetResponse.StatusCode == HttpStatusCode.OK)
                {
                    break;
                }

                if (!ShouldRetry(++attempt, totalElapsed.ElapsedMilliseconds, smartsheetResponse))
                {
                    break;
                }
            }
            return smartsheetResponse;
        }

        /// <summary>
        /// Create the RestSharp request. Override this function to inject additional
        /// headers in the request or use a proxy.
        /// </summary>
        /// <param name="smartsheetRequest"></param>
        /// <returns> the RestSharp request </returns>
        public virtual RestRequest CreateRestRequest(HttpRequest smartsheetRequest)
        {
            RestRequest restRequest;

            // Create HTTP request based on the smartsheetRequest request Type
            if (HttpMethod.GET == smartsheetRequest.Method)
            {
                restRequest = new RestRequest(smartsheetRequest.Uri, Method.GET);
            }
            else if (HttpMethod.POST == smartsheetRequest.Method)
            {
                restRequest = new RestRequest(smartsheetRequest.Uri, Method.POST);
            }
            else if (HttpMethod.PUT == smartsheetRequest.Method)
            {
                restRequest = new RestRequest(smartsheetRequest.Uri, Method.PUT);
            }
            else if (HttpMethod.DELETE == smartsheetRequest.Method)
            {
                restRequest = new RestRequest(smartsheetRequest.Uri, Method.DELETE);
            }
            else
            {
                throw new System.NotSupportedException("Request method " + smartsheetRequest.Method + " is not supported!");
            }
            return restRequest;
        }

        /// <summary>
        /// Sets the max retry timeout from the Smartsheet client
        /// </summary>
        /// <param name="maxRetryTimeout"> the retry timeout </param>
        public void SetMaxRetryTimeout(long maxRetryTimeout)
        {
            this.maxRetryTimeout = maxRetryTimeout;
        }

        /// <summary>
        /// The default CalcBackoff implementation. Uses exponential backoff. If the maximum elapsed time
        /// has expired, this calculation returns -1 causing the caller to fall out of the retry loop.
        /// </summary>
        /// <param name="previousAttempts"></param>
        /// <param name="totalElapsedTime"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public virtual long CalcBackoff(int previousAttempts, long totalElapsedTime, Api.Models.Error error)
        {
            long backoffMillis = (long)((Math.Pow(2, previousAttempts) * 1000) + new Random().Next(0, 1000));

            if (totalElapsedTime + backoffMillis > this.maxRetryTimeout)
            {
                logger.Info("Total elapsed timeout exceeded, exiting retry loop");
                return -1;
            }
            return backoffMillis;
        }

        /// <summary>
        /// Called by DefaultHttpClient when a request fails to determine if we can retry the request. Calls
        /// calcBackoff to determine time in between retries.
        /// </summary>
        /// <param name="previousAttempts"></param>
        /// <param name="totalElapsedTime"></param>
        /// <param name="response"></param>
        /// <returns>true if this error code can be retried</returns>
        public virtual bool ShouldRetry(int previousAttempts, long totalElapsedTime, HttpResponse response)
        {
            string contentType = response.Entity.ContentType;
            if (contentType != null && !contentType.StartsWith("application/json"))
            {
                // it's not JSON; don't try to parse it
                return false;
            }

            Api.Models.Error error;
            try
            {
                error = jsonSerializer.deserialize<Api.Models.Error>(
                    response.Entity.GetContent());
            }
            catch (JsonSerializationException ex)
            {
                throw new SmartsheetException(ex);
            }
            catch (Newtonsoft.Json.JsonException ex)
            {
                throw new SmartsheetException(ex);
            }
            catch (IOException ex)
            {
                throw new SmartsheetException(ex);
            }

            switch (error.ErrorCode)
            {
                case 4001:
                case 4002:
                case 4003:
                case 4004:
                    break;
                default:
                    return false;
            }

            long backoff = CalcBackoff(previousAttempts, totalElapsedTime, error);
            if (backoff < 0)
                return false;

            logger.Info(string.Format("HttpError StatusCode={0}: Retrying in {1} milliseconds", response.StatusCode, backoff));
            Thread.Sleep(TimeSpan.FromMilliseconds(backoff));
            return true;
        }

        /// <summary>
        /// Set the User-Agent in the RestClient since RestSharp won't pick it up at request time
        /// </summary>
        /// <param name="userAgent"></param>
        public void SetUserAgent(string userAgent)
        {
            this.httpClient.UserAgent = userAgent;
        }

        /// <summary>
        /// Close the HttpClient.
        /// </summary>
        public virtual void Close()
        {
            LogManager.Flush();
        }

        /// <summary>
        /// Release connection - not currently used.
        /// </summary>
        public virtual void ReleaseConnection()
        {
            // Not necessary with restsharp
        }

        /// <summary>
        /// Log URL and response code to INFO, message bodies to DEBUG
        /// </summary>
        /// <param name="request"></param>
        /// <param name="response"></param>
        /// <param name="durationMs"></param>
        public virtual void LogRequest(IRestRequest request, IRestResponse response, long durationMs)
        {
            logger.Info(() =>
            {
                return string.Format("{0} {1}, Response Code:{2}, Request completed in {3} ms", 
                    request.Method.ToString(), httpClient.BuildUri(request), response.StatusCode, durationMs);
            });
            logger.Debug(() =>
            {
                var headers_list = request.Parameters.Where(parameter => parameter.Type == ParameterType.HttpHeader).ToList();
                StringBuilder builder = new StringBuilder();
                foreach(RestSharp.Parameter header in headers_list)
                {
                    if(header.Name == "Authorization")
                    {
                        builder.Append("\"" + header.Name + "\"").Append(":").Append("\"[Redacted]\" ");
                    }
                    else
                        builder.Append("\"" + header.Name + "\"").Append(":").Append("\"" + header.Value + "\" ");
                }
                string body = "N/A";
                var body_element = request.Parameters.Where(parameter => parameter.Type == ParameterType.RequestBody).ToList();
                if (body_element.Count() > 0)
                {
                    if (body_element[0].ContentType != null && body_element[0].ContentType.Contains("application/json"))
                    {
                        if(body_element[0].Value.GetType() == typeof(string)) 
                        {
                            body = (string)body_element[0].Value;
                        }
                        else 
                        {
                            body = System.Text.Encoding.UTF8.GetString((byte[])body_element[0].Value);
                        }
                    }
                    else
                    {
                        body = string.Format("<< {0} content type suppressed >>", body_element[0].ContentType);
                    }
                }
                return string.Format("Request Headers {0}Request Body: {1}", builder.ToString(), body);
            });
            logger.Debug(() =>
            {
                StringBuilder builder = new StringBuilder();
                foreach(RestSharp.Parameter header in response.Headers)
                {
                    builder.Append("\"" + header.Name + "\"").Append(":").Append("\"" + header.Value + "\" ");
                }
                string body = "N/A";
                if (response.ContentType != null && response.ContentType.Contains("application/json"))
                {
                    body = response.Content.ToString();
                }
                else
                {
                    body = string.Format("<< {0} content type suppressed >>", response.ContentType);
                }
                return string.Format("Response Headers: {0}Response Body: {1}", builder.ToString(), body);
            });
        }
    }
}