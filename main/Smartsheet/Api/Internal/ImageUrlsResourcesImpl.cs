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

using Smartsheet.Api.Internal.Util;
using Smartsheet.Api.Internal.Http;
using Smartsheet.Api.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Net;

namespace Smartsheet.Api.Internal
{
	/// <summary>
	/// This interface provides methods to access image URLs.
	/// 
	/// Thread Safety: Implementation of this interface must be thread safe.
	/// </summary>
	class ImageUrlsResourcesImpl : AbstractResources, ImageUrlsResources
	{
		/// <summary>
		/// Constructor.
		/// 
		/// Parameters: - Smartsheet : the SmartsheetImpl
		/// 
		/// Exceptions: - IllegalArgumentException : if any argument is null
		/// </summary>
		/// <param name="smartsheet"> the Smartsheet </param>
		public ImageUrlsResourcesImpl(SmartsheetImpl smartsheet) : base(smartsheet)
		{
		}

		/// <summary>
		/// <para>Gets URLs that can be used to retrieve the specified cell images.</para>
		/// <para>It mirrors To the following Smartsheet REST API method: POST /imageurls</para>
		/// </summary>
		/// <param name="requestUrls"> array of requested Images and sizes </param>
		/// <returns> the ImageUrlMap object </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual ImageUrlMap GetImageUrls(IEnumerable<ImageUrl> requestUrls)
		{
			string path = "imageurls/";

			Utility.Utility.ThrowIfNull(requestUrls);

			HttpRequest request = null;
			try
			{
				request = CreateHttpRequest(new Uri(this.Smartsheet.BaseURI, path), HttpMethod.POST);
			}
			catch (Exception e)
			{
				throw new SmartsheetException(e);
			}

			request.Entity = serializeToEntity<IEnumerable<ImageUrl>>(requestUrls);

			HttpResponse response = this.Smartsheet.HttpClient.Request(request);

			ImageUrlMap obj = null;
			switch (response.StatusCode)
			{
				case HttpStatusCode.OK:
					obj = this.Smartsheet.JsonSerializer.deserialize<ImageUrlMap>(response.Entity.GetContent());
					break;
				default:
					HandleError(response);
					break;
			}

			Smartsheet.HttpClient.ReleaseConnection();

			return obj;
		}
	}
}
