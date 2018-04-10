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

namespace Smartsheet.Api
{
	using Api.Models;

	/// <summary>
	/// This interface provides methods To access cell resources that are associated To a row and column.
	/// 
	/// Thread Safety: Implementation of this interface must be thread safe.
	/// </summary>
	public interface RowColumnResources
	{
		/// <summary>
		/// <para>Gets the cell modification history.</para>
		/// <para>It mirrors To the following Smartsheet REST API method: GET /sheets/{sheetId}/rows/{rowId}/columns/{columnId}/history</para>
		/// <remarks><para>This operation supports pagination of results. For more information, see Paging.</para>
		/// <para>This is a resource-intensive operation and incurs 10 additional requests against the rate limit.</para></remarks>
		/// </summary>
		/// <param name="sheetId"> the sheet Id </param>
		/// <param name="rowId"> the row Id </param>
		/// <param name="columnId"> the column id</param>
		/// <param name="include"> the elements to include in the response </param>
		/// <param name="paging"> the pagination </param>
		/// <returns> the row object </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		PaginatedResult<CellHistory> GetCellHistory(long sheetId, long rowId, long columnId, IEnumerable<CellInclusion> include, PaginationParameters paging);

		/// <summary>
		/// <para>Uploads an image to the specified Cell within a Sheet.</para>
		/// <para>It mirrors To the following Smartsheet REST API method: POST /sheets/{sheetId}/rows/{rowId}/columns/{columnId}/cellimages</para>
		/// </summary>
		/// <param name="sheetId"> the sheet Id </param>
		/// <param name="rowId"> the row Id </param>
		/// <param name="columnId"> the column id</param>
		/// <param name="file"> the file path </param>
		/// <param name="fileType"> the file type </param>
		/// <returns> the row object </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		void AddImageToCell(long sheetId, long rowId, long columnId, string file, string fileType);

		/// <summary>
		/// <para>Uploads an image to the specified Cell within a Sheet.</para>
		/// <para>It mirrors To the following Smartsheet REST API method: POST /sheets/{sheetId}/rows/{rowId}/columns/{columnId}/cellimages</para>
		/// </summary>
		/// <param name="sheetId"> the sheet Id </param>
		/// <param name="rowId"> the row Id </param>
		/// <param name="columnId"> the column id</param>
		/// <param name="file"> the file path </param>
		/// <param name="fileType"> the file type </param>
		/// <param name="overrideValidation"> override column type validation </param>
		/// <param name="altText"> image alternate text </param>
		/// <returns> the row object </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		void AddImageToCell(long sheetId, long rowId, long columnId, string file, string fileType, bool overrideValidation, string altText);
	}

}