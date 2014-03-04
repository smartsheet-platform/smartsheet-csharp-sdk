using System.Collections.Generic;

namespace com.smartsheet.api.@internal
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
	/// This is the implementation of the RowResources.
	/// 
	/// Thread Safety: This class is thread safe because it is immutable and its base class is thread safe.
	/// </summary>
	public class RowResourcesImpl : AbstractResources, RowResources
	{
		/// <summary>
		/// Represents the AssociatedAttachmentResources.
		/// 
		/// It will be initialized in constructor and will not change afterwards.
		/// </summary>
		private AssociatedAttachmentResources attachments;
		/// <summary>
		/// Represents the AssociatedDiscussionResources.
		/// 
		/// It will be initialized in constructor and will not change afterwards.
		/// </summary>
		private AssociatedDiscussionResources discussions;

		/// <summary>
		/// Constructor.
		/// 
		/// Exceptions: - IllegalArgumentException : if any argument is null
		/// </summary>
		/// <param name="smartsheet"> the smartsheet </param>
		public RowResourcesImpl(SmartsheetImpl smartsheet) : base(smartsheet)
		{
			this.attachments = new AssociatedAttachmentResourcesImpl(smartsheet, "row");
			this.discussions = new AssociatedDiscussionResourcesImpl(smartsheet, "row");
		}

		/// <summary>
		/// Get a row.
		/// 
		/// It mirrors to the following Smartsheet REST API method: GET /row/{id}
		/// 
		/// Exceptions:
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ResourceNotFoundException : if the resource can not be found
		///   ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="id"> the id </param>
		/// <param name="includes"> used to specify the optional objects to include, currently DISCUSSSIONS and ATTACHMENTS are 
		/// supported. </param>
		/// <returns> the resource (note that if there is no such resource, this method will throw ResourceNotFoundException
		/// rather than returning null). </returns>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		public virtual Row GetRow(long id, IEnumerable<ObjectInclusion?> includes)
		{
			string path = "row/" + id;
			if (includes != null)
			{
				path += "?include=";
				foreach (ObjectInclusion oi in includes)
				{
					path += oi.ToString().ToLower() + ",";
				}
			}

			return this.GetResource<Row>(path, typeof(Row));
		}

		/// <summary>
		/// Move a row.
		/// 
		/// It mirrors to the following Smartsheet REST API method: PUT /row/{id}
		/// 
		/// Exceptions:
		///   IllegalArgumentException : if any argument is null
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ResourceNotFoundException : if the resource can not be found
		///   ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="id"> the id </param>
		/// <param name="rowWrapper"> the the RowWrapper with one of the following attributes: 
		///   - toTop : Moves the row (and children rows, if any) to the top of the sheet. 
		///   - toBottom : Moves the row to the bottom of the sheet 
		///   - parentId : Moves the row as the first child row of the parent.
		///   - toBottom=true can also be set to add the row as the last child of the parent.
		///   - siblingId : Moves the row as the next sibling of the row ID provided.
		/// </param>
		/// <returns> the rows that have been moved by the operation </returns>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		public virtual IList<Row> MoveRow(long id, RowWrapper rowWrapper)
		{
			return this.PutAndReceiveList<RowWrapper, Row>("row/" + id, rowWrapper, typeof(Row));
		}

		/// <summary>
		/// Delete a row.
		/// 
		/// It mirrors to the following Smartsheet REST API method: DELETE /row{id}
		/// 
		/// Parameters: - id : the ID of the row
		/// 
		/// Returns: None
		/// 
		/// Exceptions:
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ResourceNotFoundException : if the resource can not be found
		///   ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="id"> the id </param>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		public virtual void DeleteRow(long id)
		{
			this.DeleteResource<Row>("row/" + id, typeof(Row));
		}

		/// <summary>
		/// Send a row via email to the designated recipients.
		/// 
		/// It mirrors to the following Smartsheet REST API method: POST /row/{id}/emails
		/// 
		/// Exceptions:
		///   IllegalArgumentException : if any argument is null
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="id"> the id of the row </param>
		/// <param name="email"> the row email </param>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		public virtual void SendRow(long id, RowEmail email)
		{
			this.CreateResource("row/" + id + "/emails", typeof(RowEmail), email);
		}

		/// <summary>
		/// Update the values of the Cells in a Row.
		/// 
		/// It mirrors to the following Smartsheet REST API method: PUT /row/{id}/cells 
		/// 
		/// Exceptions: 
		///   IllegalArgumentException : if any argument is null
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ResourceNotFoundException : if the resource can not be found
		///   ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="rowId"> the row id </param>
		/// <param name="cells"> the cells to update (Cells must have the following attributes set: *
		/// columnId * value * strict (optional) </param>
		/// <returns> the updated cells (note that if there is no such resource, this method will throw
		/// ResourceNotFoundException rather than returning null). </returns>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		public virtual IList<Cell> UpdateCells(long rowId, IList<Cell> cells)
		{
			return this.PutAndReceiveList<IList<Cell>,Cell>("row/" + rowId + "/cells", cells, typeof(Cell));
		}

		/// <summary>
		/// Get the cell modification history.
		/// 
		/// It mirrors to the following Smartsheet REST API method: GET /row/{rowId}/column/{columnId}/history
		/// 
		/// Exceptions:
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ResourceNotFoundException : if the resource can not be found
		///   ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="rowId"> the row id </param>
		/// <param name="columnId"> the column id </param>
		/// <returns> the modification history (note that if there is no such resource, this method will throw
		/// ResourceNotFoundException rather than returning null). </returns>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		public virtual IList<CellHistory> GetCellHistory(long rowId, long columnId)
		{
			return this.ListResources<CellHistory>("row/" + rowId + "/column/" + columnId + "/history", typeof(CellHistory));
		}

		/// <summary>
		/// Return the AssociatedAttachmentResources object that provides access to attachment resources associated with Row
		/// resources.
		/// </summary>
		/// <returns> the associated attachment resources </returns>
		public virtual AssociatedAttachmentResources Attachments()
		{
			return this.attachments;
		}

		/// <summary>
		/// Return the AssociatedDiscussionResources object that provides access to discussion resources associated with Row
		/// resources.
		/// </summary>
		/// <returns> the associated discussion resources </returns>
		public virtual AssociatedDiscussionResources Discussions()
		{
			return this.discussions;
		}

    }

}