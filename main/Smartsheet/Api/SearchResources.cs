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

namespace Smartsheet.Api
{


	using SearchResult = Api.Models.SearchResult;

	/// <summary>
	/// This interface provides methods To access search resources.
	/// 
	/// Thread Safety: Implementation of this interface must be thread safe.
	/// </summary>
	public interface SearchResources
	{

		/// <summary>
		/// <para>Searches all Sheets that the User can access, for the specified text.</para>
		/// <para>It mirrors To the following Smartsheet REST API method: GET /search</para>
		/// </summary>
		/// <param name="query"> (required): Text with which to perform the search. </param>
		/// <returns> SearchResult object that contains a maximum of 100 SearchResultems </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		SearchResult Search(string query);

		/// <summary>
		/// <para>Searches a Sheet for the specified text.</para>
		/// <para>It mirrors To the following Smartsheet REST API method: GET /search/sheets/{sheetId}</para>
		/// </summary>
		/// <param name="sheetId"> the sheet Id </param>
		/// <param name="query"> the query Text </param>
		/// <returns> SearchResult object that contains a maximum of 100 SearchResultems </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		SearchResult SearchSheet(long sheetId, string query);
	}
}