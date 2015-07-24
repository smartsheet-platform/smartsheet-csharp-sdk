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

	using System.IO;
	using Api.Models;

	/// <summary>
	/// <para>This interface provides methods To access Sheet resources.</para>
	/// 
	/// <para>Thread Safety: Implementation of this interface must be thread safe.</para>
	/// </summary>
	public interface SheetResources
	{
		/// <summary>
		/// <para>Gets the list of all Sheets that the User has access to, in alphabetical order, by name.</para>
		/// 
		/// <para>It mirrors To the following Smartsheet REST API method: GET /Sheets</para>
		/// </summary>
		/// <param name="includes">elements to include in response</param>
		/// <param name="paging">the pagination</param>
		/// <returns> A list of all Sheets (note that an empty list will be returned if there are none). </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		PaginatedResult<Sheet> ListSheets(IEnumerable<SourceInclusion> includes, PaginationParameters paging);

		/// <summary>
		/// <para>List all Sheets in the organization.</para>
		/// 
		/// <para>It mirrors To the following Smartsheet REST API method: GET /Users/Sheets</para>
		/// </summary>
		/// <param name="paging">the pagination</param>
		/// <returns> the list of all Sheets (note that an empty list will be returned if there are none) </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		PaginatedResult<Sheet> ListOrganizationSheets(PaginationParameters paging);

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
		Sheet GetSheet(
					long sheetId,
					IEnumerable<SheetInclusion> includes,
					IEnumerable<ObjectExclusion> excludes,
					IEnumerable<long> rowIds,
					IEnumerable<int> rowNumbers,
					IEnumerable<long> columnIds,
					long? pageSize,
					long? page);

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
		void GetSheetAsExcel(long sheetId, BinaryWriter outputStream);

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
		void GetSheetAsPDF(long sheetId, BinaryWriter outputStream, PaperSize? paperSize);

		/// <summary>
		/// <para>Get a sheet as a CSV file.</para>
		/// 
		/// <para>It mirrors To the following Smartsheet REST API method:<br />
		/// GET /sheets/{sheetId} with "text/csv" Accept HTTP header</para>
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
		void GetSheetAsCSV(long sheetId, BinaryWriter outputStream);

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
		Sheet CreateSheet(Sheet sheet);

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
		Sheet CreateSheetFromTemplate(Sheet sheet, IEnumerable<TemplateInclusion> include);

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
		//Sheet CreateSheetInFolder(long folderId, Sheet sheet);

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
		//Sheet CreateSheetInFolderFromTemplate(long folderID, Sheet sheet, IEnumerable<ObjectInclusion> includes);

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
		void DeleteSheet(long sheetId);

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
		Sheet UpdateSheet(long sheetId, Sheet sheet);

		/// <summary>
		/// <para>Gets the Sheet version without loading the entire Sheet.</para>
		/// 
		/// <para>It mirrors To the following Smartsheet REST API method: GET /sheets/{sheetId}/version</para>
		/// </summary>
		/// <param name="sheetId"> the sheetId </param>
		/// <returns> the sheet Version (note that if there is no such resource, this method will throw
		/// ResourceNotFoundException) </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		int? GetSheetVersion(long sheetId);

		/// <summary>
		/// <para>Send a sheet as a PDF attachment via Email To the designated recipients.</para>
		/// 
		/// <para>It mirrors To the following Smartsheet REST API method: POST /sheets/{sheetId}/emails</para>
		/// </summary>
		/// <param name="sheetId"> the sheetId </param>
		/// <param name="email"> the Email </param>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		void SendSheet(long sheetId, SheetEmail email);

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
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		SheetPublish GetPublishStatus(long sheetId);

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
		SheetPublish UpdatePublishStatus(long sheetId, SheetPublish publish);

		/// <summary>
		/// <para>Return the ShareResources object that provides access To Share resources associated with Sheet resources.</para>
		/// </summary>
		/// <returns> the share resources object </returns>
		ShareResources ShareResources();

		/// <summary>
		/// <para>Return the SheetRowResources object that provides access To Row resources associated with Sheet resources.</para>
		/// </summary>
		/// <returns> the sheet row resources </returns>
		SheetRowResources RowResources();

		/// <summary>
		/// <para>Return the SheetColumnResources object that provides access To Column resources associated with Sheet resources.</para>
		/// </summary>
		/// <returns> the sheet column resources </returns>
		SheetColumnResources ColumnResources();

		/// <summary>
		/// <para>Return the SheetAttachmentResources object that provides access To attachment resources associated with
		/// Sheet resources.</para>
		/// </summary>
		/// <returns> the associated attachment resources </returns>
		SheetAttachmentResources AttachmentResources();

		/// <summary>
		/// <para>Return the SheetDiscussionResources object that provides access To discussion resources associated with
		/// Sheet resources.</para>
		/// </summary>
		/// <returns> the associated discussion resources </returns>
		SheetDiscussionResources DiscussionResources();

		/// <summary>
		/// <para>Return the SheetCommentResources object that provides access To discussion resources associated with
		/// Sheet resources.</para>
		/// </summary>
		/// <returns> the associated discussion resources </returns>
		SheetCommentResources CommentResources();
	}

}