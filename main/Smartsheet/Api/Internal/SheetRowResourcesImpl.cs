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

namespace Smartsheet.Api.Internal
{

	using Smartsheet.Api.Internal.Util;
	using Smartsheet.Api.Internal.Http;
	using Smartsheet.Api.Models;
	using System.Net;
	using System;
	using System.Text;

	/// <summary>
	/// This is the implementation of the SheetRowResources.
	/// 
	/// Thread Safety: This class is thread safe because it is immutable and its base class is thread safe.
	/// </summary>
	public class SheetRowResourcesImpl : AbstractResources, SheetRowResources
	{
		private RowAttachmentResources attachments;

		private RowDiscussionResources discussions;

		private RowColumnResources cells;

		/// <summary>
		/// Constructor.
		/// 
		/// Parameters: - Smartsheet : the SmartsheetImpl
		/// 
		/// Exceptions: - IllegalArgumentException : if any argument is null
		/// </summary>
		/// <param name="smartsheet"> the Smartsheet </param>
		public SheetRowResourcesImpl(SmartsheetImpl smartsheet)
			: base(smartsheet)
		{
			this.attachments = new RowAttachmentResourcesImpl(smartsheet);
			this.discussions = new RowDiscussionResourcesImpl(smartsheet);
			this.cells = new RowColumnResourcesImpl(smartsheet);
		}

		/// <summary>
		/// <para>Inserts one or more rows into the Sheet specified in the URL.</para>
		/// 
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
		public virtual IList<Row> AddRows(long sheetId, IEnumerable<Row> rows)
		{
			foreach (Row row in rows)
			{
				row.Id = null;
			}
			return this.PostAndReceiveList<IEnumerable<Row>, Row>("sheets/" + sheetId + "/rows", rows, typeof(Row));
		}


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
		public virtual Row GetRow(long sheetId, long rowId, IEnumerable<RowInclusion> include, IEnumerable<RowExclusion> exclude)
		{
			return this.GetResource<Row>("sheets/" + sheetId + "/rows/" + rowId, typeof(Row));
		}

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
		public virtual CopyOrMoveRowResult CopyRowsToAnotherSheet(long sheetId, CopyOrMoveRowDirective directive, IEnumerable<CopyRowInclusion> include, bool? ignoreRowsNotFound)
		{
			Utility.Utility.ThrowIfNull(directive);
			StringBuilder path = new StringBuilder("sheets/" + sheetId + "/rows/copy?" + QueryUtil.GenerateCommaSeparatedList(include));
			if (ignoreRowsNotFound.HasValue)
			{
				if (ignoreRowsNotFound.Value)
				{
					path.Append("&ignoreRowsNotFound=true");
				}
				else
				{
					path.Append("&ignoreRowsNotFound=false");
				}
			}
			return this.CreateResource<CopyOrMoveRowResult, CopyOrMoveRowDirective>(path.ToString(), directive);
		}


		/// <summary>
		/// <para>Deletes one or more row(s) from the Sheet</para>
		/// <para>It mirrors To the following Smartsheet REST API method: DELETE /sheets/{sheetId}/rows?ids={rowId1},{rowId2},{rowId3}...</para>
		/// <remarks>This operation will delete ALL child Rows of the specified Row(s).</remarks>
		/// </summary>
		/// <param name="sheetId"> The sheet ID </param>
		/// <param name="ids"> The list of row IDs </param>
		/// <param name="ignoreRowsNotFound"> If set to false and any of the specified Row IDs are not found, no rows will be deleted, and the “not found” error will be returned.</param>
		/// <returns>Row IDs corresponding to all rows that were successfully deleted (including any child rows of rows specified in the URL).</returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual IList<long> DeleteRows(long sheetId, IEnumerable<long> ids, bool? ignoreRowsNotFound)
		{
			Utility.Utility.ThrowIfNull(ids);
			IDictionary<string, string> parameters = new Dictionary<string, string>();
			parameters.Add("ids", QueryUtil.GenerateCommaSeparatedList(ids));
			if (ignoreRowsNotFound.HasValue)
			{
				parameters.Add("ignoreRowsNotFound", ignoreRowsNotFound.Value.ToString());
			}
			return this.DeleteResource<IList<long>>(QueryUtil.GenerateUrl("sheets/" + sheetId + "/rows", parameters));
		}

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
		/// <param name="include">the elements to include.</param>
		/// <returns> CopyOrMoveRowResult object </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual CopyOrMoveRowResult MoveRowsToAnotherSheet(long sheetId, CopyOrMoveRowDirective directive, IEnumerable<MoveRowInclusion> include, bool? ignoreRowsNotFound)
		{
			Utility.Utility.ThrowIfNull(directive);
			StringBuilder path = new StringBuilder("sheets/" + sheetId + "/rows/move?" + QueryUtil.GenerateCommaSeparatedList(include));
			if (ignoreRowsNotFound.HasValue)
			{
				if (ignoreRowsNotFound.Value)
				{
					path.Append("&ignoreRowsNotFound=true");
				}
				else
				{
					path.Append("&ignoreRowsNotFound=false");
				}
			}
			return this.CreateResource<CopyOrMoveRowResult, CopyOrMoveRowDirective>(path.ToString(), directive);
		}


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
		public virtual void SendRows(long sheetId, MultiRowEmail email)
		{
			this.CreateResource<MultiRowEmail>("sheets/" + sheetId + "/rows/emails", typeof(MultiRowEmail), email);
		}

		/// <summary>
		/// <para>Updates cell values in the specified row(s), expands/collapses the specified row(s), 
		/// and/or modifies the position of specified rows (including indenting/outdenting).</para>
		/// <para>It mirrors To the following Smartsheet REST API method: PUT /sheets/{sheetId}/rows</para>
		/// <remarks>If a row’s position is updated, all child rows are moved with the row.</remarks>
		/// </summary>
		/// <param name="sheetId"> the sheetId </param>
		/// <param name="rows"> the list of rows to update </param>
		/// <returns> the row object </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual IList<Row> UpdateRows(long sheetId, IEnumerable<Row> rows)
		{
			return this.PutAndReceiveList<IEnumerable<Row>, Row>("sheets/" + sheetId + "/rows", rows, typeof(Row));
		}

		/// <summary>
		/// Gets the RowAttachmentResources object that provides access To Attachment resources associated with
		/// Row resources.
		/// </summary>
		public virtual RowAttachmentResources AttachmentResources
		{
			get
			{
				return this.attachments;
			}
		}

		/// <summary>
		/// Gets the RowDiscussionResources object that provides access To Discussion resources associated with
		/// Row resources.
		/// </summary>
		public virtual RowDiscussionResources DiscussionResources
		{
			get
			{
				return this.discussions;
			}
		}

		/// <summary>
		/// Gets the RowColumnResources object that provides access To Cell resources associated with
		/// Row resources.
		/// </summary>
		public virtual RowColumnResources CellResources
		{
			get
			{
				return this.cells;
			}
		}

		[Obsolete("Use DeleteRows instead", true)]
		public virtual void DeleteRow(long sheetId, long rowId)
		{
			throw new NotSupportedException();
		}

		[Obsolete("Use SendRows instead", true)]
		public virtual void SendRow(long sheetId, long rowId, RowEmail email)
		{
			throw new NotSupportedException();
		}
	}
}