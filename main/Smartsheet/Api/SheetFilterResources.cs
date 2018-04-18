//    #[license]
//    SmartsheetClient SDK for C#
//    %%
//    Copyright (C) 2018 SmartsheetClient
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
	/// <para>This interface provides methods to access sheet filter resources.</para>
	/// 
	/// <para>Thread Safety: Implementation of this interface must be thread safe.</para>
	/// </summary>
	public interface SheetFilterResources
	{
		/// <summary>
		/// <para>Gets the list of all sheet filters.</para>
		/// 
		/// <para>Mirrors to the following Smartsheet REST API method: GET /sheets/{sheetId}/filters</para>
		/// </summary>
		/// <param name="sheetId">the sheet Id</param>
		/// <param name="paging">the pagination</param>
		/// <returns> A list of all sheet filters (note that an empty list will be returned if there are none) </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		PaginatedResult<SheetFilter> ListFilters(long sheetId, PaginationParameters paging);

		/// <summary>
		/// <para>Gets a filter.</para>
		/// 
		/// <para>Mirrors to the following Smartsheet REST API method: GET /sheets/{sheetId}/filters/{filterId}</para>
		/// </summary>
		/// <param name="sheetId"> the sheet Id </param>
		/// <param name="filterId"> the filter Id </param>
		/// <returns> the sheet filter (note that if there is no such resource, this method will throw 
		/// ResourceNotFoundException rather than returning null). </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		SheetFilter GetFilter(long sheetId, long filterId);

		/// <summary>
		/// <para>Deletes a filter.</para>
		/// 
		/// <para>Mirrors to the following Smartsheet REST API method: DELETE /sheets/{sheetId}/filters/{filterId}</para>
		/// </summary>
		/// <param name="sheetId"> the sheet Id </param>
		/// <param name="filterId"> the filter Id </param>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		void DeleteFilter(long sheetId, long filterId);
	}
}
