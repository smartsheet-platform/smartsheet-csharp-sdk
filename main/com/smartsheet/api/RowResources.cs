using System.Collections.Generic;

namespace com.smartsheet.api
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
	 * Unless required by applicable law or agreed to in writing, software
	 * distributed under the License is distributed on an "AS IS" BASIS,
	 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
	 * See the License for the specific language governing permissions and
	 * limitations under the License.
	 * %[license]
	 */




	using Cell = com.smartsheet.api.models.Cell;
	using CellHistory = com.smartsheet.api.models.CellHistory;
	using ObjectInclusion = com.smartsheet.api.models.ObjectInclusion;
	using Row = com.smartsheet.api.models.Row;
	using RowEmail = com.smartsheet.api.models.RowEmail;
	using RowWrapper = com.smartsheet.api.models.RowWrapper;

	/// <summary>
	/// <para>This interface provides methods to access Row resources.</para>
	/// 
	/// <para>Thread Safety: Implementation of this interface must be thread safe.</para>
	/// </summary>
	public interface RowResources
	{

		/// <summary>
		/// <para>Get a row.</para>
		/// 
		/// <para>It mirrors to the following Smartsheet REST API method:<br />
		/// GET /row/{id}</para>
		/// </summary>
		/// <param name="id"> the id </param>
		/// <param name="includes"> used to specify the optional objects to include. </param>
		/// <returns> the row resource (note that if there is no such resource, this method will throw 
		/// ResourceNotFoundException rather than returning null). </returns>
		/// <exception cref="InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		Row GetRow(long id, IEnumerable<ObjectInclusion?> includes);

		/// <summary>
		/// <para>Move a row.</para>
		/// 
		/// <para>It mirrors to the following Smartsheet REST API method:<br />
		///  PUT /row/{id}</para>
		/// </summary>
		/// <param name="id"> the id of the row to move </param>
		/// <param name="rowWrapper"> the row wrapper that specifies where to move the row. </param>
		/// <returns> the list of rows that have been moved by this operation. </returns>
		/// <exception cref="InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		IList<Row> MoveRow(long id, RowWrapper rowWrapper);

		/// <summary>
		/// <para>Delete a row.</para>
		/// 
		/// <para>It mirrors to the following Smartsheet REST API method:<br />
		/// DELETE /row{id}</para>
		/// </summary>
		/// <param name="id"> the id of the row </param>
		/// <exception cref="InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		void DeleteRow(long id);

		/// <summary>
		/// <para>Send a row via email to the designated recipients.</para>
		/// 
		/// <para>It mirrors to the following Smartsheet REST API method:<br />
		///  POST /row/{id}/emails</para>
		/// </summary>
		/// <param name="id"> the id </param>
		/// <param name="email"> the email </param>
		/// <exception cref="InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		void SendRow(long id, RowEmail email);

		/// <summary>
		/// <para>Update the values of the Cells in a Row.</para>
		/// 
		/// <para>It mirrors to the following Smartsheet REST API method: PUT /row/{id}/cells</para>
		/// </summary>
		/// <param name="rowId"> the row id </param>
		/// <param name="cells"> the cells to update </param>
		/// <returns> the list </returns>
		/// <exception cref="InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		IList<Cell> UpdateCells(long rowId, IList<Cell> cells);

		/// <summary>
		/// <para>Get the cell modification history.</para>
		/// 
		/// <para>It mirrors to the following Smartsheet REST API method:<br />
		/// GET /row/{rowId}/column/{columnId}/history</para>
		/// </summary>
		/// <param name="rowId"> the row id </param>
		/// <param name="columnId"> the column id </param>
		/// <returns> the cell modification history (note that if there is no such resource, this method will throw 
		/// ResourceeNotFoundException rather than returning null). </returns>
		/// <exception cref="InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		IList<CellHistory> GetCellHistory(long rowId, long columnId);

		/// <summary>
		/// <para>Return the AssociatedAttachmentResources object that provides access to attachment resources associated with Row
		/// resources.</para>
		/// </summary>
		/// <returns> the associated attachment resources </returns>
		AssociatedAttachmentResources Attachments();

		/// <summary>
		/// <para>Return the AssociatedDiscussionResources object that provides access to discussion resources associated with 
		/// Row resources.</para>
		/// </summary>
		/// <returns> the associated discussion resources </returns>
		AssociatedDiscussionResources Discussions();
	}

}