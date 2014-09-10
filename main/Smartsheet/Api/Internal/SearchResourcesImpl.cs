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

namespace Smartsheet.Api.Internal
{

	 using System;

	 using SearchResult = Api.Models.SearchResult;

	/// <summary>
	/// This is the implementation of the SearchResources.
	/// 
	/// Thread Safety: This class is thread safe because it is immutable and its base class is thread safe.
	/// </summary>
	public class SearchResourcesImpl : AbstractResources, SearchResources
	{

		/// <summary>
		/// Constructor.
		/// 
		/// Exceptions: - IllegalArgumentException : if any argument is null
		/// </summary>
		/// <param name="smartsheet"> the Smartsheet </param>
		public SearchResourcesImpl(SmartsheetImpl smartsheet) : base(smartsheet)
		{
		}

		/// <summary>
		/// Performs a search across all Sheets To which user has access.
		/// 
		/// It mirrors To the following Smartsheet REST API method: GET /search
		/// 
		/// Exceptions:
		///   IllegalArgumentException : if query is null/empty string
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ServiceUnavailableException : if the REST API service is not available (possibly due To rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="query"> the query Text </param>
		/// <returns> the search RequestResult (note that if there is no such resource, this method will throw
		/// ResourceNotFoundException rather than returning null). </returns>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
		public virtual SearchResult Search(string query)
		{
			return this.GetResource<SearchResult>("search?query=" + Uri.EscapeDataString(query), typeof(SearchResult));
		}

		/// <summary>
		/// Performs a search within a sheet.
		/// 
		/// It mirrors To the following Smartsheet REST API method: GET /search/sheet/{SheetId}
		/// 
		/// Exceptions:
		///   IllegalArgumentException : if query is null/empty string
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ResourceNotFoundException : if the resource can not be found
		///   ServiceUnavailableException : if the REST API service is not available (possibly due To rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="sheetId"> the sheet Id </param>
		/// <param name="query"> the query </param>
		/// <returns> the search RequestResult (note that if there is no such resource, this method will throw
		/// ResourceNotFoundException rather than returning null). </returns>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
		public virtual SearchResult SearchSheet(long sheetId, string query)
		{
			return this.GetResource<SearchResult>("search/sheet/" + sheetId + "?query=" + Uri.EscapeDataString(query),
					typeof(SearchResult));
		}
	}

}