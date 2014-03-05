using System.Collections.Generic;

namespace Smartsheet.Api
{

	/*
	 * #[license]
	 * Smartsheet SDK for C#
	 * %%
	 * Copyright (C) 2014 Smartsheet
	 * %%
	 * Licensed under the Apache License, Version 2.0 (the "License");
	 * you may not use this file except in compliance with the License.
	 * You may obtain a copy of the License at
	 * 
	 *      http://www.apache.org/licenses/LICENSE-2.0
	 * 
	 * Unless required by applicable law or agreed To in writing, software
	 * distributed under the License is distributed on an "AS IS" BASIS,
	 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
	 * See the License for the specific language governing permissions and
	 * limitations under the License.
	 * %[license]
	 */




	using Cell = Api.Models.Cell;
	using CellHistory = Api.Models.CellHistory;
	using ObjectInclusion = Api.Models.ObjectInclusion;
	using Row = Api.Models.Row;
	using RowEmail = Api.Models.RowEmail;
	using RowWrapper = Api.Models.RowWrapper;

	/// <summary>
	/// <para>This interface provides methods To access Row resources.</para>
	/// 
	/// <para>Thread Safety: Implementation of this interface must be thread safe.</para>
	/// </summary>
	public interface RowResources
	{

		/// <summary>
		/// <para>Get a row.</para>
		/// 
		/// <para>It mirrors To the following Smartsheet REST API method:<br />
		/// GET /row/{Id}</para>
		/// </summary>
		/// <param Name="Id"> the Id </param>
		/// <param Name="includes"> used To specify the optional objects To include. </param>
		/// <returns> the row resource (note that if there is no such resource, this method will throw 
		/// ResourceNotFoundException rather than returning null). </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		Row GetRow(long id, IEnumerable<ObjectInclusion?> includes);

		/// <summary>
		/// <para>Move a row.</para>
		/// 
		/// <para>It mirrors To the following Smartsheet REST API method:<br />
		///  PUT /row/{Id}</para>
		/// </summary>
		/// <param Name="Id"> the Id of the row To move </param>
		/// <param Name="rowWrapper"> the row wrapper that specifies where To move the row. </param>
		/// <returns> the list of Rows that have been moved by this operation. </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		IList<Row> MoveRow(long id, RowWrapper rowWrapper);

		/// <summary>
		/// <para>Delete a row.</para>
		/// 
		/// <para>It mirrors To the following Smartsheet REST API method:<br />
		/// DELETE /row{Id}</para>
		/// </summary>
		/// <param Name="Id"> the Id of the row </param>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		void DeleteRow(long id);

		/// <summary>
		/// <para>Send a row via Email To the designated recipients.</para>
		/// 
		/// <para>It mirrors To the following Smartsheet REST API method:<br />
		///  POST /row/{Id}/emails</para>
		/// </summary>
		/// <param Name="Id"> the Id </param>
		/// <param Name="Email"> the Email </param>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		void SendRow(long id, RowEmail email);

		/// <summary>
		/// <para>Update the values of the Cells in a Row.</para>
		/// 
		/// <para>It mirrors To the following Smartsheet REST API method: PUT /row/{Id}/Cells</para>
		/// </summary>
		/// <param Name="RowId"> the row Id </param>
		/// <param Name="Cells"> the Cells To update </param>
		/// <returns> the list </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		IList<Cell> UpdateCells(long rowId, IList<Cell> cells);

		/// <summary>
		/// <para>Get the cell modification history.</para>
		/// 
		/// <para>It mirrors To the following Smartsheet REST API method:<br />
		/// GET /row/{RowId}/column/{ColumnId}/history</para>
		/// </summary>
		/// <param Name="RowId"> the row Id </param>
		/// <param Name="ColumnId"> the column Id </param>
		/// <returns> the cell modification history (note that if there is no such resource, this method will throw 
		/// ResourceeNotFoundException rather than returning null). </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		IList<CellHistory> GetCellHistory(long rowId, long columnId);

		/// <summary>
		/// <para>Return the AssociatedAttachmentResources object that provides access To attachment resources associated with Row
		/// resources.</para>
		/// </summary>
		/// <returns> the associated attachment resources </returns>
		AssociatedAttachmentResources Attachments();

		/// <summary>
		/// <para>Return the AssociatedDiscussionResources object that provides access To discussion resources associated with 
		/// Row resources.</para>
		/// </summary>
		/// <returns> the associated discussion resources </returns>
		AssociatedDiscussionResources Discussions();
	}

}