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

	using HttpMethod = Api.Internal.Http.HttpMethod;
	using HttpRequest = Api.Internal.Http.HttpRequest;
	using Utils = Api.Internal.Utility.Utility;
	using ObjectInclusion = Api.Models.ObjectInclusion;
	using PaperSize = Api.Models.PaperSize;
	using Sheet = Api.Models.Sheet;
	using SheetEmail = Api.Models.SheetEmail;
	using SheetPublish = Api.Models.SheetPublish;
	using System.IO;
	using System.Net;
	using System;
	using Smartsheet.Api.Models;
	using Smartsheet.Api.Internal.Util;
	using System.Text;

	/// <summary>
	/// This is the implementation of the SheetResources.
	/// 
	/// Thread Safety: This class is thread safe because it is immutable and its base class is thread safe.
	/// </summary>
	public class SheetResourcesImpl : AbstractResources, SheetResources
	{

		/// <summary>
		/// The Constant BUFFER_SIZE. </summary>
		private const int BUFFER_SIZE = 4098;

		/// <summary>
		/// Represents the ShareResources.
		/// 
		/// It will be initialized in constructor and will not change afterwards.
		/// </summary>
		private ShareResources shares;
		/// <summary>
		/// Represents the SheetRowResources.
		/// 
		/// It will be initialized in constructor and will not change afterwards.
		/// </summary>
		private SheetRowResources rows;
		/// <summary>
		/// Represents the SheetColumnResources.
		/// 
		/// It will be initialized in constructor and will not change afterwards.
		/// </summary>
		private SheetColumnResources columns;
		/// <summary>
		/// Represents the AssociatedAttachmentResources.
		/// 
		/// It will be initialized in constructor and will not change afterwards.
		/// </summary>
		private SheetAttachmentResources attachments;
		/// <summary>
		/// Represents the AssociatedDiscussionResources.
		/// 
		/// It will be initialized in constructor and will not change afterwards.
		/// </summary>
		private SheetDiscussionResources discussions;
		/// <summary>
		/// Represents the AssociatedDiscussionResources.
		/// 
		/// It will be initialized in constructor and will not change afterwards.
		/// </summary>
		private SheetCommentResources comments;

		/// <summary>
		/// Constructor.
		/// 
		/// Exceptions: - IllegalArgumentException : if any argument is null
		/// </summary>
		/// <param name="smartsheet"> the Smartsheet </param>
		public SheetResourcesImpl(SmartsheetImpl smartsheet)
			: base(smartsheet)
		{
			this.shares = new ShareResourcesImpl(smartsheet, "sheet");
			this.rows = new SheetRowResourcesImpl(smartsheet);
			this.columns = new SheetColumnResourcesImpl(smartsheet);
			this.attachments = new SheetAttachmentResourcesImpl(smartsheet);
			this.discussions = new SheetDiscussionResourcesImpl(smartsheet);
			this.comments = new SheetCommentResourcesImpl(smartsheet);
		}

		/// <summary>
		/// <para>Gets the list of all Sheets that the User has access to, in alphabetical order, by name.</para>
		/// 
		/// <para>It mirrors To the following Smartsheet REST API method: GET /Sheets</para>
		/// </summary>
		/// <returns> A list of all Sheets (note that an empty list will be returned if there are none). </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual DataWrapper<Sheet> ListSheets(PaginationParameters paging)
		{
			StringBuilder path = new StringBuilder("sheets");
			if (paging != null)
			{
				path.Append(paging.ToQueryString());
			}
			return this.ListResourcesWithWrapper<Sheet>(path.ToString());
		}

		/// <summary>
		/// <para>List all Sheets in the organization.</para>
		/// 
		/// <para>It mirrors To the following Smartsheet REST API method: GET /Users/Sheets</para>
		/// </summary>
		/// <returns> the list of all Sheets (note that an empty list will be returned if there are none) </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual DataWrapper<Sheet> ListOrganizationSheets(PaginationParameters paging)
		{
			StringBuilder path = new StringBuilder("users/sheets");
			if (paging != null)
			{
				path.Append(paging.ToQueryString());
			}
			return this.ListResourcesWithWrapper<Sheet>(path.ToString());
		}

		/// <summary>
		/// <para>Get a sheet.</para>
		/// 
		/// <para>It mirrors To the following Smartsheet REST API method: GET /sheets/{sheetId}</para>
		/// </summary>
		/// <param name="sheetId"> the Id of the sheet </param>
		/// <param name="includes"> used To specify the optional objects To include. </param>
		/// <param name="excludes"> used To specify the optional objects To include. </param>
		/// <param name="rowIds"> used To specify the optional objects To include. </param>
		/// <param name="rowNumbers"> used To specify the optional objects To include. </param>
		/// <param name="columnIds"> used To specify the optional objects To include. </param>
		/// <param name="pageSize"> used To specify the optional objects To include. </param>
		/// <param name="page"> used To specify the optional objects To include. </param>
		/// <returns> the sheet resource (note that if there is no such resource, this method will throw 
		/// ResourceNotFoundException rather than returning null). </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual Sheet GetSheet(long sheetId, IEnumerable<SheetInclusion> includes, IEnumerable<ObjectExclusion> excludes, IEnumerable<long> rowIds, IEnumerable<int> rowNumbers, IEnumerable<long> columnIds, long? pageSize, long? page)
		{
			IDictionary<string, string> parameters = new Dictionary<string, string>();
			if (includes != null)
			{
				parameters.Add("include", QueryUtil.GenerateCommaSeparatedList(includes));
			}
			if (excludes != null)
			{
				parameters.Add("exclude", QueryUtil.GenerateCommaSeparatedList(excludes));
			}
			if (rowIds != null)
			{
				parameters.Add("rowIds", QueryUtil.GenerateCommaSeparatedList(rowIds));
			}
			if (rowNumbers != null)
			{
				parameters.Add("rowNumbers", QueryUtil.GenerateCommaSeparatedList(rowNumbers));
			}
			if (columnIds != null)
			{
				parameters.Add("columnIds", QueryUtil.GenerateCommaSeparatedList(columnIds));
			}
			if (pageSize != null)
			{
				parameters.Add("pageSize", pageSize.ToString());
			}
			if (page != null)
			{
				parameters.Add("page", page.ToString());
			}

			return this.GetResource<Sheet>("sheets/" + sheetId + QueryUtil.GenerateUrl(null, parameters), typeof(Sheet));
		}


		/// <summary>
		/// <para>Get a sheet as an Excel file.</para>
		/// 
		/// <para>It mirrors To the following Smartsheet REST API method:<br />
		/// GET /sheets/{sheetId} with "application/vnd.ms-excel" Accept HTTP header</para>
		/// </summary>
		/// <param name="sheetId"> the Id of the sheet </param>
		/// <param name="outputStream"> the output stream To which the Excel file will be written. </param>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual void GetSheetAsExcel(long id, BinaryWriter outputStream)
		{
			GetSheetAsFile(id, null, outputStream, "application/vnd.ms-excel");
		}

		/// <summary>
		/// <para>Get a sheet as a PDF file.</para>
		/// 
		/// <para>It mirrors To the following Smartsheet REST API method:<br />
		/// GET /sheets/{sheetId} with "application/pdf" Accept HTTP header</para>
		/// </summary>
		/// <param name="id"> the Id of the sheet </param>
		/// <param name="outputStream"> the output stream To which the PDF file will be written. </param>
		/// <param name="paperSize"> the paper size </param>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual void GetSheetAsPDF(long sheetId, BinaryWriter outputStream, PaperSize? paperSize)
		{
			GetSheetAsFile(sheetId, paperSize, outputStream, "application/pdf");
		}

		/// <summary>
		/// <para>Get a sheet as a CSV file.</para>
		/// 
		/// <para>It mirrors To the following Smartsheet REST API method:<br />
		/// GET /sheets/{sheetId} with "text/csv" Accept HTTP header</para>
		/// </summary>
		/// <param name="id"> the Id of the sheet </param>
		/// <param name="outputStream"> the output stream To which the CSV file will be written. </param>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public void GetSheetAsCSV(long sheetId, BinaryWriter outputStream)
		{
			GetSheetAsFile(sheetId, null, outputStream, "text/csv");
		}

		/// <summary>
		/// <para>Create a sheet in default "Sheets" collection.</para>
		/// 
		/// <para>It mirrors To the following Smartsheet REST API method:<br />
		///  POST /Sheets</para>
		/// </summary>
		/// <param name="sheet"> the sheet To created </param>
		/// <returns> the created sheet </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual Sheet CreateSheet(Sheet sheet)
		{
			return this.CreateResource("sheets", typeof(Sheet), sheet);
		}

		/// <summary>
		/// <para>Create a sheet (from existing sheet or template) in default "Sheets" collection.</para>
		/// 
		/// <para>It mirrors To the following Smartsheet REST API method: POST /Sheets</para>
		/// </summary>
		/// <param name="sheet"> the sheet To create </param>
		/// <param name="includes"> used To specify the optional objects To include. </param>
		/// <returns> the created sheet </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual Sheet CreateSheetFromTemplate(Sheet sheet, IEnumerable<ObjectInclusion> includes)
		{
			StringBuilder path = new StringBuilder("sheets");
			if (includes != null)
			{
				path.Append("?include=" + QueryUtil.GenerateCommaSeparatedList<ObjectInclusion>(includes));
			}
			return this.CreateResource(path.ToString(), typeof(Sheet), sheet);
		}

		///// <summary>
		///// <para>Create a sheet in given folder.</para>
		///// 
		///// <para>It mirrors To the following Smartsheet REST API method: POST /folders/{folderId}/Sheets</para>
		///// </summary>
		///// <param name="folderId"> the folder Id </param>
		///// <param name="sheet"> the sheet To create </param>
		///// <returns> the created sheet </returns>
		///// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		///// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		///// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		///// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		///// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		///// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		//public virtual Sheet CreateSheetInFolder(long folderId, Sheet sheet)
		//{
		//	return this.CreateResource("folders/" + folderId + "/sheets", typeof(Sheet), sheet);
		//}

		///// <summary>
		///// <para>Create a sheet (from existing sheet or template) in given folder.</para>
		///// 
		///// <para>It mirrors To the following Smartsheet REST API method: POST /folders/{folderId}/Sheets</para>
		///// </summary>
		///// <param name="folderID"> the folder Id </param>
		///// <param name="sheet"> the sheet To create </param>
		///// <param name="includes"> To specify the optional objects To include. </param>
		///// <returns> the created sheet </returns>
		///// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		///// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		///// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		///// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		///// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		///// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		//public virtual Sheet CreateSheetInFolderFromTemplate(long folderId, Sheet sheet, IEnumerable<ObjectInclusion> includes)
		//{
		//	return this.CreateResource("folders/" + folderId + "sheets?include=" + QueryUtil.GenerateCommaSeparatedList<ObjectInclusion>(includes), typeof(Sheet), sheet);
		//}

		///// <summary>
		///// <para>Create a sheet in given workspace.</para>
		///// 
		///// <para>It mirrors To the following Smartsheet REST API method: POST /workspaces/{workspaceId}/Sheets</para>
		///// </summary>
		///// <param name="workspaceId"> the workspace Id </param>
		///// <param name="sheet"> the sheet To create </param>
		///// <returns> the created sheet </returns>
		///// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		///// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		///// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		///// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		///// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		///// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		//public virtual Sheet CreateSheetInWorkspace(long workspaceId, Sheet sheet)
		//{
		//	return this.CreateResource("workspaces/" + workspaceId + "/sheets", typeof(Sheet), sheet);
		//}

		///// <summary>
		///// <para>Create a sheet (from existing sheet or template) in given workspace.</para>
		///// 
		///// <para>It mirrors To the following Smartsheet REST API method: POST /workspaces/{workspaceId}/sheets</para>
		///// </summary>
		///// <param name="workspaceId"> the workspace Id </param>
		///// <param name="sheet"> the sheet To create </param>
		///// <param name="includes"> used To specify the optional objects To include </param>
		///// <returns> the created sheet </returns>
		///// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		///// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		///// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		///// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		///// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		///// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		//public virtual Sheet CreateSheetInWorkspaceFromTemplate(long workspaceId, Sheet sheet, IEnumerable<ObjectInclusion> includes)
		//{
		//	return this.CreateResource("workspaces/" + workspaceId + "sheets?include=" + QueryUtil.GenerateCommaSeparatedList<ObjectInclusion>(includes), typeof(Sheet), sheet);
		//}

		/// <summary>
		/// <para>Delete a sheet.</para>
		/// 
		/// <para>It mirrors To the following Smartsheet REST API method: DELETE /sheets/{sheetId}</para>
		/// </summary>
		/// <param name="sheetId"> the sheetId </param>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual void DeleteSheet(long sheetId)
		{
			this.DeleteResource<Sheet>("sheets/" + sheetId, typeof(Sheet));
		}

		/// <summary>
		/// <para>Update a sheet.</para>
		/// <para>To modify Sheet contents, see Add Row(s), Update Row(s), and Update Column.</para>
		/// <para>This operation can be used to update an individual user’s sheet settings. 
		/// If the request body contains only the userSettings attribute, 
		/// this operation may be performed even if the user only has read-only access to the sheet 
		/// (i.e. the user has viewer permissions, or the sheet is read-only).</para>
		/// <para>It mirrors To the following Smartsheet REST API method: PUT /sheets/{sheetId}</para>
		/// </summary>
		/// <param name="sheetId"> the sheetId </param>
		/// <param name="sheet"> the sheet To update </param>
		/// <returns> the updated sheet </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual Sheet UpdateSheet(long sheetId, Sheet sheet)
		{
			return this.UpdateResource("sheets/" + sheetId, typeof(Sheet), sheet);
		}

		///// <summary>
		///// <para>Gets the Sheet version without loading the entire Sheet.</para>
		///// 
		///// <para>It mirrors To the following Smartsheet REST API method: GET /sheets/{sheetId}/version</para>
		///// </summary>
		///// <param name="sheetId"> the sheetId </param>
		///// <returns> the sheet Version (note that if there is no such resource, this method will throw
		///// ResourceNotFoundException) </returns>
		///// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		///// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		///// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		///// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		///// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		///// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		//public virtual int? GetSheetVersion(long sheetId)
		//{
		//	return this.GetResource<Sheet>("sheets/" + sheetId + "/version", typeof(Sheet)).Version;
		//}

		///// <summary>
		///// <para>Send a sheet as a PDF attachment via Email To the designated recipients.</para>
		///// 
		///// <para>It mirrors To the following Smartsheet REST API method: POST /sheets/{sheetId}/emails</para>
		///// </summary>
		///// <param name="sheetId"> the sheetId </param>
		///// <param name="email"> the Email </param>
		///// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		///// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		///// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		///// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		///// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		///// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		//public virtual void SendSheet(long sheetId, SheetEmail email)
		//{
		//	this.CreateResource<SheetEmail>("sheets/" + sheetId + "/emails", typeof(SheetEmail), email);
		//}

		/// <summary>
		/// Return the ShareResources object that provides access To Share resources associated with Sheet resources.
		/// </summary>
		/// <returns> the ShareResources object </returns>
		public virtual ShareResources ShareResources()
		{
			return this.shares;
		}

		/// <summary>
		/// Return the SheetRowResources object that provides access To Row resources associated with Sheet resources.
		/// </summary>
		/// <returns> the sheet row resources </returns>
		public virtual SheetRowResources RowResources()
		{
			return this.rows;
		}

		/// <summary>
		/// Return the SheetColumnResources object that provides access To Column resources associated with Sheet resources.
		/// </summary>
		/// <returns> the sheet column resources </returns>
		public virtual SheetColumnResources ColumnResources()
		{
			return this.columns;
		}

		/// <summary>
		/// Return the SheetAttachmentResources object that provides access To attachment resources associated with
		/// Sheet resources.
		/// </summary>
		/// <returns> the associated attachment resources </returns>
		public virtual SheetAttachmentResources AttachmentResources()
		{
			return this.attachments;
		}

		/// <summary>
		/// Return the SheetDiscussionResources object that provides access To discussion resources associated with
		/// Sheet resources.
		/// </summary>
		/// <returns> the associated discussion resources </returns>
		public virtual SheetDiscussionResources DiscussionResources()
		{
			return this.discussions;
		}

		/// <summary>
		/// Return the SheetCommentResources object that provides access To discussion resources associated with
		/// Sheet resources.
		/// </summary>
		/// <returns> the associated discussion resources </returns>
		public SheetCommentResources CommentResources()
		{
			return this.comments;
		}

		/// <summary>
		/// <para>Get the Status of the Publish settings of the sheet, including the URLs of any enabled publishings.</para>
		/// 
		/// <para>It mirrors To the following Smartsheet REST API method: GET /sheets/{sheetId}/publish</para>
		/// </summary>
		/// <param name="sheetId"> the sheetId </param>
		/// <returns> the publish Status (note that if there is no such resource, this method will throw ResourceNotFoundException rather than returning null) </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To
		public virtual SheetPublish GetPublishStatus(long id)
		{
			return this.GetResource<SheetPublish>("sheets/" + id + "/publish", typeof(SheetPublish));
		}

		/// <summary>
		/// <para>Sets the publish Status of a sheet and returns the new Status, including the URLs of any enabled publishings.</para>
		/// 
		/// <para>It mirrors To the following Smartsheet REST API method: PUT /sheets/{sheetId}/publish</para>
		/// </summary>
		/// <param name="id"> the sheetId </param>
		/// <param name="publish"> the SheetPublish object limited. </param>
		/// <returns> the update SheetPublish object (note that if there is no such resource, this method will throw a 
		/// ResourceNotFoundException rather than returning null). </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual SheetPublish UpdatePublishStatus(long id, SheetPublish publish)
		{
			return this.UpdateResource("sheets/" + id + "/publish", typeof(SheetPublish), publish);
		}

		/// <summary>
		/// <para>Get a sheet as a file.</para>
		/// 
		/// <para>It mirrors To the following Smartsheet REST API method:<br />
		/// GET /sheets/{sheetId} with "application/pdf", "application/vnd.ms-excel", or "text/csv" as Accept HTTP header</para>
		/// </summary>
		/// <param name="sheetId"> the Id of the sheet </param>
		/// <param name="paperSize"> the size of the PDF file </param>
		/// <param name="outputStream"> the output stream To which the CSV file will be written. </param>
		/// <param name="contentType"> the Accept header </param>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		private void GetSheetAsFile(long sheetId, PaperSize? paperSize, BinaryWriter outputStream, string contentType)
		{
			Utils.ThrowIfNull(outputStream, contentType);

			StringBuilder path = new StringBuilder("sheets/" + sheetId);
			if (paperSize.HasValue)
			{
				path.Append("?paperSize=" + paperSize.Value);
			}

			HttpRequest request = null;

			request = CreateHttpRequest(new Uri(this.Smartsheet.BaseURI, path.ToString()), HttpMethod.GET);
			request.Headers["Accept"] = contentType;

			Api.Internal.Http.HttpResponse response = Smartsheet.HttpClient.Request(request);

			switch (response.StatusCode)
			{
				case HttpStatusCode.OK:
					try
					{
						response.Entity.GetBinaryContent().BaseStream.CopyTo(outputStream.BaseStream);
					}
					catch (IOException e)
					{
						throw new SmartsheetException(e);
					}
					break;
				default:
					HandleError(response);
					break;
			}

			Smartsheet.HttpClient.ReleaseConnection();
		}

		/*
		 * Copy an input stream To an output stream.
		 * 
		 * @param input The input stream To copy.
		 * 
		 * @param output the output stream To write To.
		 * 
		 * @throws IOException if there is trouble reading or writing To the streams.
		 */
		/// <summary>
		/// Copy stream.
		/// </summary>
		/// <param name="input"> the input </param>
		/// <param name="output"> the output </param>
		/// <exception cref="IOException"> Signals that an I/O exception has occurred. </exception>
		private static void CopyStream(Stream input, Stream output)
		{
			byte[] buffer = new byte[BUFFER_SIZE];
			int len;
			while ((len = input.Read(buffer, 0, buffer.Length)) > 0)
			{
				output.Write(buffer, 0, len);
			}
		}
	}
}