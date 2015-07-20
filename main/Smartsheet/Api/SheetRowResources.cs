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
	/// This interface provides methods To access row resources that are associated To a sheet object.
	/// 
	/// Thread Safety: Implementation of this interface must be thread safe.
	/// </summary>
	public interface SheetRowResources
	{
		/// <summary>
		/// <para>Inserts one or more rows into the Sheet specified in the URL.</para>
		/// <para>It mirrors To the following Smartsheet REST API method: POST /sheets/{sheetId}/rows</para>
		/// <remarks>If multiple rows are specified in the request, all rows must be inserted at the same location 
		/// (i.e. the toTop, toBottom, parentId, siblingId, and above attributes must be the same for all rows in the request).</remarks>
		/// </summary>
		/// <param name="sheetId"> the sheet Id </param>
		/// <param name="rows"> one or more rows </param>
		/// <returns> the list of created Rows </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		IList<Row> AddRows(long sheetId, IEnumerable<Row> rows);

		/// <summary>
		/// <para>Gets the Row specified in the URL.</para>
		/// <para>It mirrors To the following Smartsheet REST API method: GET /sheets/{sheetId}/rows/{rowId}</para>
		/// </summary>
		/// <param name="include"> comma-separated list of elements to include in the response. </param>
		/// <param name="exclude"> a comma-separated list of optional objects to exclude in the response. </param>
		/// <param name="sheetId"> the sheetId </param>
		/// <param name="rowId"> the rowId </param>
		/// <returns> the row object </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		Row GetRow(long sheetId, long rowId, IEnumerable<RowIncludeFlags> include, IEnumerable<ObjectExclusion> exclude);

		/// <summary>
		/// <para>Copies Row(s) from the Sheet specified in the URL to (the bottom of) another sheet.</para>
		/// 
		/// <para>It mirrors To the following Smartsheet REST API method: POST /sheets/{sheetId}/rows/copy</para>
		/// <remarks>Up to 5,000 row IDs can be specified in the request, 
		/// but if the total number of rows in the destination sheet after the copy exceeds the Smartsheet row limit, 
		/// an error response will be returned.</remarks>
		/// </summary>
		/// <param name="sheetId"> the sheet Id </param>
		/// <param name="include"> objects to include </param>
		/// <param name="ignoreRowsNotFound"> ignoreRowsNotFound </param>
		/// <param name="directive"> directive </param>
		/// <returns> CopyOrMoveRowResult object </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		CopyOrMoveRowResult CopyRowsToAnotherSheet(long sheetId, IEnumerable<ObjectInclusion> include, bool? ignoreRowsNotFound, CopyOrMoveRowDirective directive);

		/// <summary>
		/// <para>Deletes the Row specified in the URL.</para>
		/// <para>It mirrors To the following Smartsheet REST API method: DELETE /sheets/{sheetId}/rows/{rowId}</para>
		/// <remarks>This operation will delete ALL child Rows of the specified Row.</remarks>
		/// </summary>
		/// <param name="sheetId"> the sheetId </param>
		/// <param name="rowId"> the rowId </param>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		void DeleteRow(long sheetId, long rowId);

		/// <summary>
		/// <para>Moves Row(s) from the Sheet specified in the URL to (the bottom of) another sheet.</para>
		/// <para>It mirrors To the following Smartsheet REST API method: POST /sheets/{sheetId}/rows/copy</para>
		/// <remarks><para>Up to 5,000 row IDs can be specified in the request, 
		/// but if the total number of rows in the destination sheet after the copy exceeds the Smartsheet row limit, 
		/// an error response will be returned.</para>
		/// <para>Any child rows of the rows specified in the request will also be moved. 
		/// Parent-child relationships amongst rows will be preserved within the destination sheet.</para></remarks>
		/// </summary>
		/// <param name="sheetId"> the sheet Id </param>
		/// <param name="ignoreRowsNotFound"> ignoreRowsNotFound </param>
		/// <param name="directive"> directive </param>
		/// <returns> CopyOrMoveRowResult object </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		CopyOrMoveRowResult MoveRowsToAnotherSheet(long sheetId, IEnumerable<ObjectInclusion> include, bool? ignoreRowsNotFound, CopyOrMoveRowDirective directive);

		///// <summary>
		///// <para>Sends a Row via email.</para>
		///// <para>It mirrors To the following Smartsheet REST API method: POST /sheets/{sheetId}/rows/{rowId}/emails</para>
		///// </summary>
		///// <param name="sheetId"> the sheetId </param>
		///// <param name="rowId"> the rowId </param>
		///// <param name="email"> the email </param>
		///// <returns> the row object </returns>
		///// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		///// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		///// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		///// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		///// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		///// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		//void SendRow(long sheetId, long rowId, RowEmail email);

		/// <summary>
		/// <para>Updates cell values in the specified row(s), expands/collapses the specified row(s), 
		/// and/or modifies the position of specified rows (including indenting/outdenting).</para>
		/// <para>It mirrors To the following Smartsheet REST API method: PUT /sheets/{sheetId}/rows</para>
		/// <remarks>If a row’s position is updated, all child rows are moved with the row.</remarks>
		/// </summary>
		/// <param name="sheetId"> the sheetId </param>
		/// <param name="rowId"> the rowId </param>
		/// <param name="email"> the email </param>
		/// <returns> the row object </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		IList<Row> UpdateRows(long sheetId, IEnumerable<Row> rows);

		RowAttachmentResources AttachmentResources();

		RowDiscussionResources DiscussionResources();
	}
}