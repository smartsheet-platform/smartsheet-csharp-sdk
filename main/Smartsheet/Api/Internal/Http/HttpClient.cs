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

namespace Smartsheet.Api.Internal.Http
{
	/// <summary>
	/// This interface defines methods to make an HTTP request.
	/// 
	/// Thread Safety: Implementation of this interface must be thread safe.
	/// </summary>
	public interface HttpClient
	{

		/// <summary>
		/// Make a multipart HTTP request and return the response.
		/// </summary>
		/// <param name="request"> the Smartsheet request </param>
		/// <param name="file">the full file path</param>
		/// <param name="fileType">the file type, or also called the conent type of the file</param>
		/// <param name="objectType">the object name, for example 'comment', or 'discussion'</param>
		/// <returns> the HTTP response </returns>
		/// <exception cref="HttpClientException"> the HTTP client exception </exception>
		HttpResponse Request(HttpRequest request, string objectType, string file, string fileType);

		/// <summary>
		/// Make an HTTP request and return the response.
		/// 
		/// Parameters: - request : the HTTP request
		/// 
		/// Returns: the HTTP response
		/// 
		/// Exceptions: - IllegalArgumentException : if any argument is null - HttpClientException : if there is any other
		/// error occurred during the operation
		/// </summary>
		/// <param name="request"> the request </param>
		/// <returns> the http response </returns>
		/// <exception cref="HttpClientException"> the http client exception </exception>
		HttpResponse Request(HttpRequest request);

		/// <summary>
		/// Release connection.
		/// </summary>
		void ReleaseConnection();
		
		/// <summary>
		/// Closes this instance.
		/// </summary>
		void Close();
	}

}