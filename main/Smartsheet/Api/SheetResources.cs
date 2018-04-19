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
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//    %[license]

using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace Smartsheet.Api
{
	using System.IO;
	using Api.Models;

	/// <summary>
	/// <para>This interface provides methods to access sheet resources.</para>
	/// 
	/// <para>Thread Safety: Implementation of this interface must be thread safe.</para>
	/// </summary>
	public interface SheetResources
	{
        /// <summary>
        /// <para>Gets the list of all sheets that the user has access to, in alphabetical order, by name.</para>
        /// 
        /// <para>Mirrors to the following Smartsheet REST API method: GET /Sheets</para>
        /// </summary>
        /// <param name="includes">elements to include in response</param>
        /// <param name="paging">the pagination</param>
        /// <param name="modifiedSince">only return sheets modified on or after the specified date</param>
        /// <returns> A list of all sheets (note that an empty list will be returned if there are none) limited to the following attributes:
        /// <list type="bullet">
        /// <item><description>id</description></item>
        /// <item><description>name</description></item>
        /// <item><description>accessLevel</description></item>
        /// <item><description>permalink</description></item>
        /// <item><description>source (included only if "source" is specified with the include parameter)</description></item>
        /// <item><description>owner (included only if "ownerInfo" is specified with the include parameter)</description></item>
        /// <item><description>ownerId (included only if "ownerInfo" is specified with the include parameter)</description></item>
        /// <item><description>createdAt</description></item>
        /// <item><description>modifiedAt</description></item>
        /// </list>
        /// </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        PaginatedResult<Sheet> ListSheets(IEnumerable<SheetInclusion> includes, PaginationParameters paging, DateTime? modifiedSince = null);

		/// <summary>
		/// <para>Lists all sheets in the organization.</para>
		/// 
		/// <para>Mirrors to the following Smartsheet REST API method: GET /users/sheets</para>
		/// </summary>
		/// <param name="paging">the pagination</param>
		/// <returns> the list of all sheets (note that an empty list will be returned if there are none) </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		[Obsolete("use Smartsheet.UserResources.SheetResources.ListOrgSheets", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		PaginatedResult<Sheet> ListOrganizationSheets(PaginationParameters paging);

		/// <summary>
		/// <para>Gets a sheet.</para>
		/// 
		/// <para>Mirrors to the following Smartsheet REST API method: GET /sheets/{sheetId}</para>
		/// </summary>
		/// <param name="sheetId"> the Id of the sheet </param>
		/// <param name="includes"> used to specify the optional objects to include. </param>
		/// <param name="excludes"> used to specify the optional objects to include. </param>
		/// <param name="rowIds"> used to specify the optional objects to include. </param>
		/// <param name="rowNumbers"> used to specify the optional objects to include. </param>
		/// <param name="columnIds"> used to specify the optional objects to include. </param>
		/// <param name="pageSize"> used to specify the optional objects to include. </param>
		/// <param name="page"> used to specify the optional objects to include. </param>
		/// <returns> the sheet resource (note that if there is no such resource, this method will throw 
		/// ResourceNotFoundException rather than returning null). </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		Sheet GetSheet(
					long sheetId,
					IEnumerable<SheetLevelInclusion> includes,
					IEnumerable<SheetLevelExclusion> excludes,
					IEnumerable<long> rowIds,
					IEnumerable<int> rowNumbers,
					IEnumerable<long> columnIds,
					long? pageSize,
					long? page);

		/// <summary>
		/// <para>Gets a sheet.</para>
		/// 
		/// <para>Mirrors to the following Smartsheet REST API method: GET /sheets/{sheetId}</para>
		/// </summary>
		/// <param name="sheetId"> the Id of the sheet </param>
		/// <param name="includes"> used to specify the optional objects to include. </param>
		/// <param name="excludes"> used to specify the optional objects to include. </param>
		/// <param name="rowIds"> used to specify the optional objects to include. </param>
		/// <param name="rowNumbers"> used to specify the optional objects to include. </param>
		/// <param name="columnIds"> used to specify the optional objects to include. </param>
		/// <param name="pageSize"> used to specify the optional objects to include. </param>
		/// <param name="page"> used to specify the optional objects to include. </param>
		/// <param name="ifVersionAfter"> only fetch sheet if more recent version available </param>
		/// <returns> the sheet resource (note that if there is no such resource, this method will throw 
		/// ResourceNotFoundException rather than returning null). </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		Sheet GetSheet(
					long sheetId,
					IEnumerable<SheetLevelInclusion> includes,
					IEnumerable<SheetLevelExclusion> excludes,
					IEnumerable<long> rowIds,
					IEnumerable<int> rowNumbers,
					IEnumerable<long> columnIds,
					long? pageSize,
					long? page,
					long? ifVersionAfter);

		/// <summary>
		/// <para>Gets a sheet as an Excel file.</para>
		/// 
		/// <para>Mirrors to the following Smartsheet REST API method:<br />
		/// GET /sheets/{sheetId} with "application/vnd.ms-excel" Accept HTTP header</para>
		/// </summary>
		/// <param name="sheetId"> the Id of the sheet </param>
		/// <param name="outputStream"> the output stream to which the Excel file will be written. </param>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		void GetSheetAsExcel(long sheetId, BinaryWriter outputStream);

		/// <summary>
		/// <para>Gets a sheet as a PDF file.</para>
		/// 
		/// <para>Mirrors to the following Smartsheet REST API method:<br />
		/// GET /sheets/{sheetId} with "application/pdf" Accept HTTP header</para>
		/// </summary>
		/// <param name="sheetId"> the Id of the sheet </param>
		/// <param name="outputStream"> the output stream to which the PDF file will be written. </param>
		/// <param name="paperSize"> the paper size </param>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		void GetSheetAsPDF(long sheetId, BinaryWriter outputStream, PaperSize? paperSize);

		/// <summary>
		/// <para>Gets a sheet as a CSV file.</para>
		/// 
		/// <para>Mirrors to the following Smartsheet REST API method:<br />
		/// GET /sheets/{sheetId} with "text/csv" Accept HTTP header</para>
		/// </summary>
		/// <param name="sheetId"> the Id of the sheet </param>
		/// <param name="outputStream"> the output stream to which the PDF file will be written. </param>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		void GetSheetAsCSV(long sheetId, BinaryWriter outputStream);

		/// <summary>
		/// <para>Creates a sheet in default "Sheets" collection.</para>
		/// 
		/// <para>Mirrors to the following Smartsheet REST API method:<br />
		///  POST /Sheets</para>
		/// </summary>
		/// <param name="sheet"> the sheet to create </param>
		/// <returns> the created sheet </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		Sheet CreateSheet(Sheet sheet);

		/// <summary>
		/// <para>Creates a sheet (from existing sheet or template) in default "Sheets" collection.</para>
		/// 
		/// <para>Mirrors to the following Smartsheet REST API method: POST /Sheets</para>
		/// </summary>
		/// <param name="sheet"> the sheet to create </param>
		/// <param name="include"> used to specify the optional objects to include. </param>
		/// <returns> the created sheet </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		Sheet CreateSheetFromTemplate(Sheet sheet, IEnumerable<TemplateInclusion> include);

		///// <summary>
		///// <para>Creates a sheet in given folder.</para>
		///// 
		///// <para>Mirrors to the following Smartsheet REST API method: POST /folders/{folderId}/Sheets</para>
		///// </summary>
		///// <param name="folderId"> the folder Id </param>
		///// <param name="sheet"> the sheet to create </param>
		///// <returns> the created sheet </returns>
		///// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
		///// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		///// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
		///// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		///// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		///// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		//Sheet CreateSheetInFolder(long folderId, Sheet sheet);

		///// <summary>
		///// <para>Creates a sheet (from existing sheet or template) in a given folder.</para>
		///// 
		///// <para>Mirrors to the following Smartsheet REST API method: POST /folders/{folderId}/Sheets</para>
		///// </summary>
		///// <param name="folderID"> the folder Id </param>
		///// <param name="sheet"> the sheet to create </param>
		///// <param name="includes"> To specify the optional objects to include. </param>
		///// <returns> the created sheet </returns>
		///// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
		///// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		///// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
		///// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		///// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		///// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		//Sheet CreateSheetInFolderFromTemplate(long folderID, Sheet sheet, IEnumerable<ObjectInclusion> includes);

		/// <summary>
		/// <para>Deletes a sheet.</para>
		/// 
		/// <para>Mirrors to the following Smartsheet REST API method: DELETE /sheets/{sheetId}</para>
		/// </summary>
		/// <param name="sheetId"> the sheet Id </param>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		void DeleteSheet(long sheetId);

		/// <summary>
		/// <para>Updates a sheet.</para>
		/// <para>To modify sheet contents, see Add Rows, Update Rows, and Update Column.</para>
		/// <para>This operation can be used to update an individual users sheet settings. 
		/// If the request body contains only the userSettings attribute, 
		/// this operation may be performed even if the user only has read-only access to the sheet 
		/// (i.e., the user has viewer permissions, or the sheet is read-only).</para>
		/// <para>Mirrors to the following Smartsheet REST API method: PUT /sheets/{sheetId}</para>
		/// </summary>
		/// <param name="sheet"> the sheet to update </param>
		/// <returns> the updated sheet </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		Sheet UpdateSheet(Sheet sheet);

		/// <summary>
		/// <para>Gets the sheet version without loading the entire sheet.</para>
		/// 
		/// <para>Mirrors to the following Smartsheet REST API method: GET /sheets/{sheetId}/version</para>
		/// </summary>
		/// <param name="sheetId"> the sheet Id </param>
		/// <returns> the sheet version (note that if there is no such resource, this method will throw
		/// ResourceNotFoundException) </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		int? GetSheetVersion(long sheetId);

		/// <summary>
		/// <para>Sends a sheet as a PDF attachment via email to the designated recipients.</para>
		/// 
		/// <para>Mirrors to the following Smartsheet REST API method: POST /sheets/{sheetId}/emails</para>
		/// </summary>
		/// <param name="sheetId"> the sheet Id </param>
		/// <param name="email"> the email </param>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		void SendSheet(long sheetId, SheetEmail email);

		/// <summary>
		/// <para>Creates an update request for the specified rows within the sheet. An email notification
		/// (containing a link to the update request) will be asynchronously sent to the specified recipients.</para>
		/// <para>Mirrors to the following Smartsheet REST API method: POST /sheets/{sheetId}/updaterequests</para>
		/// </summary>
		/// <param name="sheetId"> the sheet Id </param>
		/// <param name="email"> the email </param>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		[Obsolete("use Smartsheet.SheetResources.UpdateRequestResources.CreateUpdateRequest", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		UpdateRequest SendUpdateRequest(long sheetId, MultiRowEmail email);

		/// <summary>
		/// <para>Gets the status of the publish settings of the sheet, including the URLs of any enabled publishings.</para>
		/// 
		/// <para>Mirrors to the following Smartsheet REST API method: GET /sheets/{sheetId}/publish</para>
		/// </summary>
		/// <param name="sheetId"> the sheet Id </param>
		/// <returns> the publish status (note that if there is no such resource, this method will throw ResourceNotFoundException rather than returning null) </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		SheetPublish GetPublishStatus(long sheetId);

		/// <summary>
		/// <para>Sets the publish status of a sheet and returns the new status, including the URLs of any enabled publishings.</para>
		/// 
		/// <para>Mirrors to the following Smartsheet REST API method: PUT /sheets/{sheetId}/publish</para>
		/// </summary>
		/// <param name="sheetId"> the sheet Id </param>
		/// <param name="publish"> the SheetPublish object limited. </param>
		/// <returns> the update SheetPublish object (note that if there is no such resource, this method will throw a 
		/// ResourceNotFoundException rather than returning null). </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		SheetPublish UpdatePublishStatus(long sheetId, SheetPublish publish);

		/// <summary>
		/// <para>Creates a copy of the specified sheet.</para>
		/// <para>Mirrors to the following Smartsheet REST API method:<br />
		/// POST /sheets/{sheetId}/copy</para>
		/// </summary>
		/// <param name="sheetId"> the sheet Id </param>
		/// <param name="destination"> the destination to copy to </param>
		/// <param name="include"> the elements to copy. Note: Cell history will not be copied, regardless of which include parameter values are specified.</param>
		/// <returns> the created folder </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		Sheet CopySheet(long sheetId, ContainerDestination destination, IEnumerable<SheetCopyInclusion> include);

		/// <summary>
		/// <para>Moves the specified sheet to a new location.</para>
		/// <para>Mirrors to the following Smartsheet REST API method:<br />
		/// POST /sheets/{sheetId}/move</para>
		/// </summary>
		/// <param name="sheetId"> the sheet Id </param>
		/// <param name="destination"> the destination to copy to </param>
		/// <returns> the moved sheet </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		Sheet MoveSheet(long sheetId, ContainerDestination destination);

		/// <summary>
		/// <para>Sorts a sheet according to the sort criteria.</para>
		/// 
		/// <para>Mirrors to the following Smartsheet REST API method: POST /sheets/{sheetId}/sort</para>
		/// </summary>
		/// <param name="id"> the sheet Id </param>
		/// <param name="sortSpecifier"> the sort criteria </param>
		/// <returns> the Sheet (note that if there is no such resource, this method will throw a ResourceNotFoundException rather than returning null). </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		Sheet SortSheet(long sheetId, SortSpecifier sortSpecifier);

		/// <summary>
		/// <para>Imports a sheet (from CSV). </para>
		/// <para>Mirrors to the following Smartsheet REST API method: POST /sheets/import</para>
		/// </summary>
		/// <param name="file"> path to the CSV file</param>
        /// <param name="sheetName"> destination sheet name </param>
        /// <param name="headerRowIndex"> index (0 based) of row to be used for column names </param>
        /// <param name="primaryColumnIndex"> index (0 based) of primary column </param>
        /// <returns> the created sheet </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		Sheet ImportCsvSheet(string file, string sheetName, int? headerRowIndex, int? primaryColumnIndex);

		/// <summary>
		/// <para>Imports a sheet (from XLSX). </para>
		/// <para>Mirrors to the following Smartsheet REST API method: POST /sheets/import</para>
		/// </summary>
		/// <param name="file"> path to the XLSX file</param>
        /// <param name="sheetName"> destination sheet name </param>
        /// <param name="headerRowIndex"> index (0 based) of row to be used for column names </param>
        /// <param name="primaryColumnIndex"> index (0 based) of primary column </param>
        /// <returns> the created sheet </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		Sheet ImportXlsSheet(string file, string sheetName, int? headerRowIndex, int? primaryColumnIndex);

		/// <summary>
		/// <para>Returns the ShareResources object that provides access to share resources associated with sheet resources.</para>
		/// </summary>
		/// <returns> the ShareResources object </returns>
		ShareResources ShareResources { get; }

		/// <summary>
		/// <para>Returns the SheetRowResources object that provides access to row resources associated with sheet resources.</para>
		/// </summary>
		/// <returns> the SheetRowResources object </returns>
		SheetRowResources RowResources { get; }

		/// <summary>
		/// <para>Returns the SheetColumnResources object that provides access to column resources associated with sheet resources.</para>
		/// </summary>
		/// <returns> the SheetColumnResources object </returns>
		SheetColumnResources ColumnResources { get; }

		/// <summary>
		/// <para>Returns the SheetAttachmentResources object that provides access to attachment resources associated with
		/// sheet resources.</para>
		/// </summary>
		/// <returns> the SheetAttachmentResources object </returns>
		SheetAttachmentResources AttachmentResources { get; }

		/// <summary>
		/// <para>Returns the SheetDiscussionResources object that provides access to discussion resources associated with
		/// sheet resources.</para>
		/// </summary>
		/// <returns> the SheetDiscussionResources object </returns>
		SheetDiscussionResources DiscussionResources { get; }

		/// <summary>
		/// <para>Returns the SheetCommentResources object that provides access to comment resources associated with
		/// sheet resources.</para>
		/// </summary>
		/// <returns> the SheetCommentResources object </returns>
		SheetCommentResources CommentResources { get; }

		/// <summary>
		/// <para>Returns the SheetUpdateRequestResources object that provides access to update request resources associated with
		/// sheet resources.</para>
		/// </summary>
		/// <returns> the SheetUpdateRequestResources object </returns>
		SheetUpdateRequestResources UpdateRequestResources { get; }

		/// <summary>
		/// <para>Returns the FilterResources object that provides access to filter resources associated with sheet resources.</para>
		/// </summary>
		/// <returns> the FilterResources object </returns>
		SheetFilterResources FilterResources { get; }

		/// <summary>
		/// <para>Returns the AutomationRuleResources object that provides access to automation rules resources associated with 
		/// sheet resources.</para>
		/// </summary>
		/// <returns> the AutomationRuleResources object </returns>
		SheetAutomationRuleResources AutomationRuleResources { get; }

		/// <summary>
		/// Returns the CrossSheetReferenceResources object that provides access to cross-sheet reference resources associated 
		/// with sheet resources.
		/// </summary>
		/// <returns> the CrossSheetReferenceResources object </returns>
		SheetCrossSheetReferenceResources CrossSheetReferenceResources { get; }
	}
}
