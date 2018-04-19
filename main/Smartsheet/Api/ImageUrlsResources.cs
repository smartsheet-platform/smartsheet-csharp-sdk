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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smartsheet.Api
{
	using Api.Models;

	/// <summary>
	/// This interface provides methods to access image URLs.
	/// 
	/// Thread Safety: Implementation of this interface must be thread safe.
	/// </summary>
	public interface ImageUrlsResources
	{
		/// <summary>
		/// <para>Gets URLs that can be used to retrieve the specified cell images.</para>
		/// <para>It mirrors to the following Smartsheet REST API method: POST /imageurls</para>
		/// </summary>
		/// <param name="requestUrls"> array of requested Images and sizes </param>
		/// <returns> the ImageUrlMap object </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		ImageUrlMap GetImageUrls(IEnumerable<ImageUrl> requestUrls);
	}
}
