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

namespace Smartsheet.Api.Internal.Http
{
	/// <summary>
	/// This interface defines methods To make an HTTP request.
	/// 
	/// Thread Safety: Implementation of this interface must be thread safe.
	/// </summary>
	public interface HttpClient
	{

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