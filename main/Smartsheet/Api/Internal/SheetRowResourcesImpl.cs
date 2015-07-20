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
		public virtual Row GetRow(long sheetId, long rowId, IEnumerable<RowIncludeFlags> include, IEnumerable<ObjectExclusion> exclude)
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
		public CopyOrMoveRowResult CopyRowsToAnotherSheet(long sheetId, IEnumerable<ObjectInclusion> include, bool? ignoreRowsNotFound, CopyOrMoveRowDirective directive)
		{
			Utility.Utility.ThrowIfNull(directive);
			string path = "sheets/" + sheetId + "/rows/copy?" + QueryUtil.GenerateCommaSeparatedList<ObjectInclusion>(include);
			if (ignoreRowsNotFound.HasValue)
			{
				if (ignoreRowsNotFound.Value)
				{
					path += "&ignoreRowsNotFound=true";
				}
				else
				{
					path += "&ignoreRowsNotFound=false";
				}
			}
			return CopyOrMoveRowsToAnotherSheet(directive, path);
		}


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
		public void DeleteRow(long sheetId, long rowId)
		{
			this.DeleteResource<Row>("sheets/" + sheetId + "/rows/" + rowId, typeof(Row));
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
		/// <returns> CopyOrMoveRowResult object </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public CopyOrMoveRowResult MoveRowsToAnotherSheet(long sheetId, IEnumerable<ObjectInclusion> include, bool? ignoreRowsNotFound, CopyOrMoveRowDirective directive)
		{
			Utility.Utility.ThrowIfNull(directive);
			string path = "sheets/" + sheetId + "/rows/move?" + QueryUtil.GenerateCommaSeparatedList<ObjectInclusion>(include);
			if (ignoreRowsNotFound.HasValue)
			{
				if (ignoreRowsNotFound.Value)
				{
					path += "&ignoreRowsNotFound=true";
				}
				else
				{
					path += "&ignoreRowsNotFound=false";
				}
			}
			return CopyOrMoveRowsToAnotherSheet(directive, path);
		}

		/// <summary>
		/// <para>Sends a Row via email.</para>
		/// <para>It mirrors To the following Smartsheet REST API method: POST /sheets/{sheetId}/rows/{rowId}/emails</para>
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
		public virtual void SendRow(long sheetId, long rowId, RowEmail email)
		{
			this.CreateResource<RowEmail>("sheets/" + sheetId + "/rows/" + rowId + "/emails", typeof(RowEmail), email);
		}

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
		public IList<Row> UpdateRows(long sheetId, IEnumerable<Row> rows)
		{
			return this.PutAndReceiveList<IEnumerable<Row>, Row>("sheets/" + sheetId + "/rows", rows, typeof(Row));
		}

		public RowAttachmentResources AttachmentResources()
		{
			return this.attachments;
		}

		public RowDiscussionResources DiscussionResources()
		{
			return this.discussions;
		}

		public RowColumnResources CellResources()
		{
			return this.cells;
		}

		private CopyOrMoveRowResult CopyOrMoveRowsToAnotherSheet(CopyOrMoveRowDirective directive, string path)
		{
			HttpRequest request = null;
			try
			{
				request = CreateHttpRequest(new Uri(this.Smartsheet.BaseURI, path), HttpMethod.POST);
			}
			catch (Exception e)
			{
				throw new SmartsheetException(e);
			}

			request.Entity = serializeToEntity<CopyOrMoveRowDirective>(directive);

			HttpResponse response = this.Smartsheet.HttpClient.Request(request);

			CopyOrMoveRowResult result = null;
			switch (response.StatusCode)
			{
				case HttpStatusCode.OK:
					result = this.Smartsheet.JsonSerializer.DeserializeRowResult(
						response.Entity.GetContent());
					break;
				default:
					HandleError(response);
					break;
			}

			this.Smartsheet.HttpClient.ReleaseConnection();

			return result;
		}
	}
}