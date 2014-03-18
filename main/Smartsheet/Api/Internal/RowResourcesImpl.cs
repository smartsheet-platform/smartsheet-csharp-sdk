//    #[license]
//    Smartsheet SDK for C#
//    %%
//    Copyright (C) 2014 Smartsheet
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

namespace Smartsheet.Api.Internal
{
	using Cell = Api.Models.Cell;
	using CellHistory = Api.Models.CellHistory;
	using ObjectInclusion = Api.Models.ObjectInclusion;
	using Row = Api.Models.Row;
	using RowEmail = Api.Models.RowEmail;
	using RowWrapper = Api.Models.RowWrapper;

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
		/// <param name="smartsheet"> the Smartsheet </param>
		public RowResourcesImpl(SmartsheetImpl smartsheet) : base(smartsheet)
		{
			this.attachments = new AssociatedAttachmentResourcesImpl(smartsheet, "row");
			this.discussions = new AssociatedDiscussionResourcesImpl(smartsheet, "row");
		}

		/// <summary>
		/// Get a row.
		/// 
		/// It mirrors To the following Smartsheet REST API method: GET /row/{Id}
		/// 
		/// Exceptions:
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ResourceNotFoundException : if the resource can not be found
		///   ServiceUnavailableException : if the REST API service is not available (possibly due To rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="id"> the Id </param>
		/// <param name="includes"> used To specify the optional objects To include, currently DISCUSSSIONS and ATTACHMENTS are 
		/// supported. </param>
		/// <returns> the resource (note that if there is no such resource, this method will throw ResourceNotFoundException
		/// rather than returning null). </returns>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
		public virtual Row GetRow(long id, IEnumerable<ObjectInclusion> includes)
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
		/// It mirrors To the following Smartsheet REST API method: PUT /row/{Id}
		/// 
		/// Exceptions:
		///   IllegalArgumentException : if any argument is null
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ResourceNotFoundException : if the resource can not be found
		///   ServiceUnavailableException : if the REST API service is not available (possibly due To rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="id"> the Id </param>
		/// <param name="rowWrapper"> the the RowWrapper with one of the following attributes: 
		///   - ToTop : Moves the row (and children Rows, if any) To the top of the sheet. 
		///   - ToBottom : Moves the row To the bottom of the sheet 
		///   - ParentId : Moves the row as the first child row of the parent.
		///   - ToBottom=true can also be set To add the row as the last child of the parent.
		///   - SiblingId : Moves the row as the next sibling of the row ID provided.
		/// </param>
		/// <returns> the Rows that have been moved by the operation </returns>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
		public virtual IList<Row> MoveRow(long id, RowWrapper rowWrapper)
		{
			return this.PutAndReceiveList<RowWrapper, Row>("row/" + id, rowWrapper, typeof(Row));
		}

		/// <summary>
		/// Delete a row.
		/// 
		/// It mirrors To the following Smartsheet REST API method: DELETE /row{Id}
		/// 
		/// Parameters: - Id : the ID of the row
		/// 
		/// Returns: None
		/// 
		/// Exceptions:
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ResourceNotFoundException : if the resource can not be found
		///   ServiceUnavailableException : if the REST API service is not available (possibly due To rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="id"> the Id </param>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
		public virtual void DeleteRow(long id)
		{
			this.DeleteResource<Row>("row/" + id, typeof(Row));
		}

		/// <summary>
		/// Send a row via Email To the designated recipients.
		/// 
		/// It mirrors To the following Smartsheet REST API method: POST /row/{Id}/emails
		/// 
		/// Exceptions:
		///   IllegalArgumentException : if any argument is null
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ServiceUnavailableException : if the REST API service is not available (possibly due To rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="id"> the Id of the row </param>
		/// <param name="email"> the row Email </param>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
		public virtual void SendRow(long id, RowEmail email)
		{
			this.CreateResource("row/" + id + "/emails", typeof(RowEmail), email);
		}

		/// <summary>
		/// Update the values of the Cells in a Row.
		/// 
		/// It mirrors To the following Smartsheet REST API method: PUT /row/{Id}/Cells 
		/// 
		/// Exceptions: 
		///   IllegalArgumentException : if any argument is null
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ResourceNotFoundException : if the resource can not be found
		///   ServiceUnavailableException : if the REST API service is not available (possibly due To rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="rowId"> the row Id </param>
		/// <param name="cells"> the Cells To update (Cells must have the following attributes set: *
		/// ColumnId * Value * Strict (optional) </param>
		/// <returns> the updated Cells (note that if there is no such resource, this method will throw
		/// ResourceNotFoundException rather than returning null). </returns>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
		public virtual IList<Cell> UpdateCells(long rowId, IList<Cell> cells)
		{
			return this.PutAndReceiveList<IList<Cell>,Cell>("row/" + rowId + "/cells", cells, typeof(Cell));
		}

		/// <summary>
		/// Get the cell modification history.
		/// 
		/// It mirrors To the following Smartsheet REST API method: GET /row/{RowId}/column/{ColumnId}/history
		/// 
		/// Exceptions:
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ResourceNotFoundException : if the resource can not be found
		///   ServiceUnavailableException : if the REST API service is not available (possibly due To rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="rowId"> the row Id </param>
		/// <param name="columnId"> the column Id </param>
		/// <returns> the modification history (note that if there is no such resource, this method will throw
		/// ResourceNotFoundException rather than returning null). </returns>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
		public virtual IList<CellHistory> GetCellHistory(long rowId, long columnId)
		{
			return this.ListResources<CellHistory>("row/" + rowId + "/column/" + columnId + "/history", typeof(CellHistory));
		}

		/// <summary>
		/// Return the AssociatedAttachmentResources object that provides access To attachment resources associated with Row
		/// resources.
		/// </summary>
		/// <returns> the associated attachment resources </returns>
		public virtual AssociatedAttachmentResources Attachments()
		{
			return this.attachments;
		}

		/// <summary>
		/// Return the AssociatedDiscussionResources object that provides access To discussion resources associated with Row
		/// resources.
		/// </summary>
		/// <returns> the associated discussion resources </returns>
		public virtual AssociatedDiscussionResources Discussions()
		{
			return this.discussions;
		}
	 }

}