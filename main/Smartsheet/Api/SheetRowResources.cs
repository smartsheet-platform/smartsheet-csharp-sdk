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
	using System;
	using System.ComponentModel;

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
		Row GetRow(long sheetId, long rowId, IEnumerable<RowInclusion> include, IEnumerable<RowExclusion> exclude);


		/// <summary>
		/// <para>Copies Row(s) from the Sheet specified in the URL to (the bottom of) another sheet.</para>
		/// 
		/// <para>It mirrors To the following Smartsheet REST API method: POST /sheets/{sheetId}/rows/copy</para>
		/// <remarks>Up to 5,000 row IDs can be specified in the request, 
		/// but if the total number of rows in the destination sheet after the copy exceeds the Smartsheet row limit, 
		/// an error response will be returned.</remarks>
		/// </summary>
		/// <param name="sheetId"> the sheet Id to copy from </param>
		/// <param name="include"> objects to include </param>
		/// <param name="ignoreRowsNotFound"> default is false. If set to true, specifying row Ids that do not exist within the source sheet will not cause an error response.
		/// If omitted or set to false, specifying row Ids that do not exist within the source sheet will cause an error response (and no rows will be copied). </param>
		/// <param name="directive"> directive </param>
		/// <returns> CopyOrMoveRowResult object </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		CopyOrMoveRowResult CopyRowsToAnotherSheet(long sheetId, CopyOrMoveRowDirective directive, IEnumerable<CopyRowInclusion> include, bool? ignoreRowsNotFound);

		/// <summary>
		/// <para>Deletes the Row specified in the URL.</para>
		/// <para>It mirrors To the following Smartsheet REST API method: DELETE /sheets/{sheetId}/rows/{rowId}</para>
		/// <remarks>This operation will delete ALL child Rows of the specified Row.</remarks>
		/// </summary>
		/// <param name="sheetId"> the sheetId </param>
		/// <param name="ids"> the row IDs </param>
		/// <param name="ignoreRowsNotFound">If set to true, specifying row Ids that do not exist within the source sheet will not cause an error response.
		/// If omitted or set to false, specifying row Ids that do not exist within the source sheet will cause an error response (and no rows will be copied).</param>
		/// <returns>Row IDs corresponding to all rows that were successfully deleted (including any child rows of rows specified in the URL).</returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		IList<long> DeleteRows(long sheetId, IEnumerable<long> ids, bool? ignoreRowsNotFound);

		/// <summary>
		/// <para>Moves Row(s) from the Sheet specified in the URL to (the bottom of) another sheet.</para>
		/// <para>It mirrors To the following Smartsheet REST API method: POST /sheets/{sheetId}/rows/copy</para>
		/// <remarks><para>Up to 5,000 row IDs can be specified in the request, 
		/// but if the total number of rows in the destination sheet after the copy exceeds the Smartsheet row limit, 
		/// an error response will be returned.</para>
		/// <para>Any child rows of the rows specified in the request will also be moved. 
		/// Parent-child relationships amongst rows will be preserved within the destination sheet.</para></remarks>
		/// </summary>
		/// <param name="sheetId"> the sheet Id to move from </param>
		/// <param name="ignoreRowsNotFound"> default is false. If set to true, specifying row Ids that do not exist within the source sheet will not cause an error response.
		/// If omitted or set to false, specifying row Ids that do not exist within the source sheet will cause an error response (and no rows will be copied). </param>
		/// <param name="directive"> directive </param>
		/// <param name="include">the elements to include</param>
		/// <returns> CopyOrMoveRowResult object </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		CopyOrMoveRowResult MoveRowsToAnotherSheet(long sheetId, CopyOrMoveRowDirective directive, IEnumerable<MoveRowInclusion> include, bool? ignoreRowsNotFound);

		/// <summary>
		/// <para>Sends one or more Rows via email.</para>
		/// <para>It mirrors To the following Smartsheet REST API method: POST /sheets/{sheetId}/rows/emails</para>
		/// </summary>
		/// <param name="sheetId"> The sheet Id </param>
		/// <param name="email"> The email. The columns included for each row in the email will be populated according to the following rules:
		/// <list type="bullet">
		/// <item><description>
		/// If the columnIds attribute of the MultiRowEmail object is specified as an array of column IDs, those specific columns will be included.
		/// </description></item>
		/// <item><description>
		/// If the columnIds attribute of the MultiRowEmail object is omitted, all columns except hidden columns shall be included.
		/// </description></item>
		/// <item><description>
		/// If the columnIds attribute of the MultiRowEmail object is specified as empty, no columns shall be included.
		/// (Note: In this case, either includeAttachments:true or includeDiscussions:true must be specified.)
		/// </description></item>
		/// </list>
		/// </param>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		void SendRows(long sheetId, MultiRowEmail email);

		/// <summary>
		/// <para>Updates cell values in the specified row(s), expands/collapses the specified row(s), 
		/// and/or modifies the position of specified rows (including indenting/outdenting).</para>
		/// <para>It mirrors To the following Smartsheet REST API method: PUT /sheets/{sheetId}/rows</para>
		/// <remarks>If a row’s position is updated, all child rows are moved with the row.</remarks>
		/// </summary>
		/// <param name="sheetId">the sheetId</param>
		/// <param name="rows">the list of rows to update</param>
		/// <returns> the row object </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		IList<Row> UpdateRows(long sheetId, IEnumerable<Row> rows);

		/// <summary>
		/// Returns the RowAttachmentResources object that provides access To attachment resources associated with Row Resources.
		/// </summary>
		/// <returns> the RowAttachmentResources </returns>
		RowAttachmentResources AttachmentResources { get; }

		/// <summary>
		/// Returns the RowDiscussionResources object that provides access To discussion resources associated with Row Resources.
		/// </summary>
		/// <returns> the RowDiscussionResources </returns>
		RowDiscussionResources DiscussionResources { get; }

		/// <summary>
		/// Returns the RowColumnResources object that provides access To column resources associated with Row Resources (Cell Resources).
		/// </summary>
		/// <returns> the RowColumnResources </returns>
		RowColumnResources CellResources { get; }

		[Obsolete("use DeleteRows intead", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void DeleteRow(long sheetId, long rowId);

		[Obsolete("use SendRows intead", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void SendRow(long sheetId, long rowId, RowEmail email);
	}
}