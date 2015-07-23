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
//    Unless required by applicable law or agreed To in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//    %[license]

using System.Collections.Generic;
using Smartsheet.Api.Internal.Http;
namespace Smartsheet.Api.Internal.Http
{
	using Util = Api.Internal.Utility.Utility;
	using RestSharp;
	using System.Reflection;
	using System;
	using System.IO;

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
		private readonly RestClient httpClient;

		/// <summary>
		/// The http request. </summary>
		private RestRequest restRequest;

		/// <summary>
		/// The http response. </summary>
		private IRestResponse restResponse;

		/// <summary>
		/// Constructor.
		/// </summary>
		public DefaultHttpClient()
			: this(new RestClient())
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
		public DefaultHttpClient(RestClient httpClient)
		{
			Util.ThrowIfNull(httpClient);

			this.httpClient = httpClient;
			this.httpClient.FollowRedirects = true;
			this.httpClient.UserAgent = buildUserAgent();
		}

		/// <summary>
		/// Make a multipart HTTP request and return the response.
		/// </summary>
		/// <param name="smartsheetRequest"> the Smartsheet request </param>
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
				restRequest.AddParameter(objectType, System.Text.Encoding.Default.GetString(smartsheetRequest.Entity.Content), "application/json",
					ParameterType.RequestBody);
			}

			restRequest.AlwaysMultipartFormData = true;

			// Set the client base Url.
			httpClient.BaseUrl = new Uri(smartsheetRequest.Uri.GetLeftPart(UriPartial.Authority));

			// Make the HTTP request
			restResponse = httpClient.Execute(restRequest);

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

			HttpResponse smartsheetResponse = new HttpResponse();

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
				restRequest.AddParameter("application/json", Util.ReadAllBytes(smartsheetRequest.Entity.GetBinaryContent()),
					ParameterType.RequestBody);
			}

			// Set the client base Url.
			httpClient.BaseUrl = new Uri(smartsheetRequest.Uri.GetLeftPart(UriPartial.Authority));

			// Make the HTTP request
			restResponse = httpClient.Execute(restRequest);

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
		/// Close the HttpClient.
		/// </summary>
		public virtual void Close()
		{
			// Not necessary with restsharp
		}

		/// <summary>
		/// Release connection - not currently used.
		/// </summary>
		public virtual void ReleaseConnection()
		{
			// Not necessary with restsharp
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