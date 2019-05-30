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

using System.Collections.Generic;

namespace Smartsheet.Api.Internal
{
    using HttpMethod = Api.Internal.Http.HttpMethod;
    using HttpRequest = Api.Internal.Http.HttpRequest;
    using Utils = Api.Internal.Utility.Utility;
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
    using Smartsheet.Api.Internal.Http;

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
        /// It will be initialized in the constructor and will not change afterwards.
        /// </summary>
        private ShareResources shares;
        /// <summary>
        /// Represents the SheetRowResources.
        /// 
        /// It will be initialized in the constructor and will not change afterwards.
        /// </summary>
        private SheetRowResources rows;
        /// <summary>
        /// Represents the SheetColumnResources.
        /// 
        /// It will be initialized in the constructor and will not change afterwards.
        /// </summary>
        private SheetColumnResources columns;
        /// <summary>
        /// Represents the AssociatedAttachmentResources.
        /// 
        /// It will be initialized in the constructor and will not change afterwards.
        /// </summary>
        private SheetAttachmentResources attachments;
        /// <summary>
        /// Represents the AssociatedDiscussionResources.
        /// 
        /// It will be initialized in the constructor and will not change afterwards.
        /// </summary>
        private SheetDiscussionResources discussions;
        /// <summary>
        /// Represents the AssociatedDiscussionResources.
        /// 
        /// It will be initialized in the constructor and will not change afterwards.
        /// </summary>
        private SheetCommentResources comments;
        /// <summary>
        /// Represents the associated SheetUpdateRequestResources.
        /// 
        /// It will be initialized in the constructor and will not change afterwards.
        /// </summary>
        private SheetUpdateRequestResources updateRequests;
        /// <summary>
        /// Represents the associated SheetFilterResources.
        /// 
        /// It will be initialized in the constructor and will not change afterwards.
        /// </summary>
        private SheetFilterResources filters;
        /// <summary>
        /// Represents the associated SheetAutomationRulesResources.
        /// 
        /// It will be initialized in the constructor and will not change afterwards.
        /// </summary>
        private SheetAutomationRuleResources automationRules;
        /// <summary>
        /// Represents the associated SheetCrossSheetReferenceResources.
        /// 
        /// It will be initialized in the constructor and will not change afterwards.
        /// </summary>
        private SheetCrossSheetReferenceResources crossSheetReferences;

        /// <summary>
        /// Constructor.
        /// 
        /// Exceptions: - IllegalArgumentException : if any argument is null
        /// </summary>
        /// <param name="smartsheet"> the Smartsheet </param>
        public SheetResourcesImpl(SmartsheetImpl smartsheet)
            : base(smartsheet)
        {
            this.shares = new ShareResourcesImpl(smartsheet, "sheets");
            this.rows = new SheetRowResourcesImpl(smartsheet);
            this.columns = new SheetColumnResourcesImpl(smartsheet);
            this.attachments = new SheetAttachmentResourcesImpl(smartsheet);
            this.discussions = new SheetDiscussionResourcesImpl(smartsheet);
            this.comments = new SheetCommentResourcesImpl(smartsheet);
            this.updateRequests = new SheetUpdateRequestResourcesImpl(smartsheet);
            this.filters = new SheetFilterResourcesImpl(smartsheet);
            this.automationRules = new SheetAutomationRuleResourcesImpl(smartsheet);
            this.crossSheetReferences = new SheetCrossSheetReferencesResourcesImpl(smartsheet);
        }

        /// <summary>
        /// <para>Gets the list of all sheets that the user has access to, in alphabetical order, by name.</para>
        /// 
        /// <para>Mirrors to the following Smartsheet REST API method: GET /Sheets</para>
        /// </summary>
        /// <returns> A list of all sheets (note that an empty list will be returned if there are none). </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual PaginatedResult<Sheet> ListSheets(IEnumerable<SheetInclusion> includes, PaginationParameters paging, DateTime? modifiedSince)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            if (paging != null)
            {
                parameters = paging.toDictionary();
            }
            if (includes != null)
            {
                parameters.Add("include", QueryUtil.GenerateCommaSeparatedList(includes));
            }
            if (modifiedSince != null)
            {
                parameters.Add("modifiedSince", ((DateTime)modifiedSince).ToUniversalTime().ToString("o"));
            }

            return this.ListResourcesWithWrapper<Sheet>("sheets" + QueryUtil.GenerateUrl(null, parameters));
        }

        /// <summary>
        /// <para>Lists all sheets in the organization.</para>
        /// <para>Mirrors to the following Smartsheet REST API method: GET /users/sheets</para>
        /// </summary>
        /// <returns> the list of all sheets (note that an empty list will be returned if there are none) </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual PaginatedResult<Sheet> ListOrganizationSheets(PaginationParameters paging)
        {
            StringBuilder path = new StringBuilder("users/sheets");
            if (paging != null)
            {
                path.Append(paging.ToQueryString());
            }
            return this.ListResourcesWithWrapper<Sheet>(path.ToString());
        }

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
        public virtual Sheet GetSheet(long sheetId, IEnumerable<SheetLevelInclusion> includes, IEnumerable<SheetLevelExclusion> excludes, 
            IEnumerable<long> rowIds, IEnumerable<int> rowNumbers, IEnumerable<long> columnIds, long? pageSize, long? page)
        {
            return GetSheet(sheetId, includes, excludes, rowIds, rowNumbers, columnIds, pageSize, page, null, null);
        }

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
        public virtual Sheet GetSheet(long sheetId, IEnumerable<SheetLevelInclusion> includes, IEnumerable<SheetLevelExclusion> excludes, 
            IEnumerable<long> rowIds, IEnumerable<int> rowNumbers, IEnumerable<long> columnIds, long? pageSize, long? page, long? ifVersionAfter)
        {
            return GetSheet(sheetId, includes, excludes, rowIds, rowNumbers, columnIds, pageSize, page, ifVersionAfter, null);
        }

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
        /// <param name="level"> compatibility level </param>
        /// <returns> the sheet resource (note that if there is no such resource, this method will throw 
        /// ResourceNotFoundException rather than returning null). </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual Sheet GetSheet(long sheetId, IEnumerable<SheetLevelInclusion> includes, IEnumerable<SheetLevelExclusion> excludes,
            IEnumerable<long> rowIds, IEnumerable<int> rowNumbers, IEnumerable<long> columnIds, long? pageSize, long? page, long? ifVersionAfter, int? level)
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
            if (ifVersionAfter != null)
            {
                parameters.Add("ifVersionAfter", ifVersionAfter.ToString());
            }
            if (level != null)
            {
                parameters.Add("level", level.ToString());
            }

            return this.GetResource<Sheet>("sheets/" + sheetId + QueryUtil.GenerateUrl(null, parameters), typeof(Sheet));
        }

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
        public virtual void GetSheetAsExcel(long sheetId, BinaryWriter outputStream)
        {
            GetSheetAsFile(sheetId, null, outputStream, "application/vnd.ms-excel");
        }

        /// <summary>
        /// <para>Gets a sheet as a PDF file.</para>
        /// 
        /// <para>Mirrors to the following Smartsheet REST API method:<br />
        /// GET /sheets/{sheetId} with "application/pdf" Accept HTTP header</para>
        /// </summary>
        /// <param name="sheetId">the Id of the sheet</param>
        /// <param name="outputStream">the output stream to which the PDF file will be written.</param>
        /// <param name="paperSize">the paper size</param>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual void GetSheetAsPDF(long sheetId, BinaryWriter outputStream, PaperSize? paperSize)
        {
            GetSheetAsFile(sheetId, paperSize, outputStream, "application/pdf");
        }

        /// <summary>
        /// <para>Gets a sheet as a CSV file.</para>
        /// 
        /// <para>Mirrors to the following Smartsheet REST API method:<br />
        /// GET /sheets/{sheetId} with "text/csv" Accept HTTP header</para>
        /// </summary>
        /// <param name="sheetId">the Id of the sheet</param>
        /// <param name="outputStream"> the output stream to which the CSV file will be written. </param>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public void GetSheetAsCSV(long sheetId, BinaryWriter outputStream)
        {
            GetSheetAsFile(sheetId, null, outputStream, "text/csv");
        }

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
        public virtual Sheet CreateSheet(Sheet sheet)
        {
            return this.CreateResource("sheets", typeof(Sheet), sheet);
        }

        /// <summary>
        /// <para>Creates a sheet (from existing sheet or template) in default "Sheets" collection.</para>
        /// 
        /// <para>Mirrors to the following Smartsheet REST API method: POST /Sheets</para>
        /// </summary>
        /// <param name="sheet"> the sheet to create </param>
        /// <param name="includes"> used to specify the optional objects to include. </param>
        /// <returns> the created sheet </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual Sheet CreateSheetFromTemplate(Sheet sheet, IEnumerable<TemplateInclusion> includes)
        {
            StringBuilder path = new StringBuilder("sheets");
            if (includes != null)
            {
                path.Append("?include=" + QueryUtil.GenerateCommaSeparatedList(includes));
            }
            return this.CreateResource(path.ToString(), typeof(Sheet), sheet);
        }

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
        public virtual void DeleteSheet(long sheetId)
        {
            this.DeleteResource<Sheet>("sheets/" + sheetId, typeof(Sheet));
        }

        /// <summary>
        /// <para>Updates a sheet.</para>
        /// <para>to modify sheet contents, see Add Rows, Update Rows, and Update Column.</para>
        /// <para>This operation can be used to update an individual users sheet settings. 
        /// If the request body contains only the userSettings attribute, 
        /// this operation may be performed even if the user only has read-only access to the sheet 
        /// (i.e., the user has viewer permissions, or the sheet is read-only).</para>
        /// <para>Mirrors to the following Smartsheet REST API method: PUT /sheets/{sheetId}</para>
        /// </summary>
        /// <param name="sheet"> the sheet to update </param>
        /// <returns> the updated sheet </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual Sheet UpdateSheet(Sheet sheet)
        {
            return this.UpdateResource("sheets/" + sheet.Id, typeof(Sheet), sheet);
        }

        /// <summary>
        /// <para>Gets the sheet version without loading the entire sheet.</para>
        /// 
        /// <para>Mirrors to the following Smartsheet REST API method: GET /sheets/{sheetId}/version</para>
        /// </summary>
        /// <param name="sheetId"> the sheet Id </param>
        /// <returns> the sheet version (note that if there is no such resource, this method will throw
        /// ResourceNotFoundException) </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual int? GetSheetVersion(long sheetId)
        {
            return this.GetResource<Sheet>("sheets/" + sheetId + "/version", typeof(Sheet)).Version;
        }

        /// <summary>
        /// <para>Sends a sheet as a PDF attachment via email to the designated recipients.</para>
        /// 
        /// <para>Mirrors to the following Smartsheet REST API method: POST /sheets/{sheetId}/emails</para>
        /// </summary>
        /// <param name="sheetId"> the sheet Id </param>
        /// <param name="email"> the email </param>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual void SendSheet(long sheetId, SheetEmail email)
        {
            this.CreateResource<SheetEmail>("sheets/" + sheetId + "/emails", typeof(SheetEmail), email);
        }

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
        public virtual UpdateRequest SendUpdateRequest(long sheetId, MultiRowEmail email)
        {
            return this.CreateResource<RequestResult<UpdateRequest>, MultiRowEmail>("sheets/" + sheetId + "/updaterequests", email).Result;
        }

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
        public virtual Sheet CopySheet(long sheetId, ContainerDestination destination, IEnumerable<SheetCopyInclusion> include)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            if (include != null)
            {
                parameters.Add("include", QueryUtil.GenerateCommaSeparatedList(include));
            }
            return this.CreateResource<RequestResult<Sheet>, ContainerDestination>(QueryUtil.GenerateUrl("sheets/" + sheetId + "/copy", parameters), destination).Result;
        }

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
        public virtual Sheet MoveSheet(long sheetId, ContainerDestination destination)
        {
            return this.CreateResource<RequestResult<Sheet>, ContainerDestination>("sheets/" + sheetId + "/move", destination).Result;
        }

        /// <summary>
        /// <para>Get the status of the publish settings of the sheet, including the URLs of any enabled publishings.</para>
        /// 
        /// <para>Mirrors to the following Smartsheet REST API method: GET /sheets/{sheetId}/publish</para>
        /// </summary>
        /// <param name="sheetId"> the sheet Id </param>
        /// <returns> the publish status (note that if there is no such resource, this method will throw ResourceNotFoundException rather than returning null) </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual SheetPublish GetPublishStatus(long sheetId)
        {
            return this.GetResource<SheetPublish>("sheets/" + sheetId + "/publish", typeof(SheetPublish));
        }

        /// <summary>
        /// <para>Sets the publish status of a sheet and returns the new status, including the URLs of any enabled publishings.</para>
        /// 
        /// <para>Mirrors to the following Smartsheet REST API method: PUT /sheets/{sheetId}/publish</para>
        /// </summary>
        /// <param name="id"> the sheet Id </param>
        /// <param name="publish"> the SheetPublish object limited. </param>
        /// <returns> the updated SheetPublish object (note that if there is no such resource, this method will throw a 
        /// ResourceNotFoundException rather than returning null). </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual SheetPublish UpdatePublishStatus(long id, SheetPublish publish)
        {
            return this.UpdateResource("sheets/" + id + "/publish", typeof(SheetPublish), publish);
        }

        /// <summary>
        /// <para>Sorts a sheet according to the sort criteria.</para>
        /// 
        /// <para>Mirrors to the following Smartsheet REST API method: POST /sheets/{sheetId}/sort</para>
        /// </summary>
        /// <param name="id"> the sheet Id </param>
        /// <param name="sortSpecifier"> the sort criteria </param>
        /// <returns> the sheet (note that if there is no such resource, this method will throw a ResourceNotFoundException rather than returning null). </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual Sheet SortSheet(long id, SortSpecifier sortSpecifier)
        {
            return SortSheet(id, sortSpecifier, null);
        }

        /// <summary>
        /// <para>Sorts a sheet according to the sort criteria.</para>
        /// 
        /// <para>Mirrors to the following Smartsheet REST API method: POST /sheets/{sheetId}/sort</para>
        /// </summary>
        /// <param name="id"> the sheet Id </param>
        /// <param name="sortSpecifier"> the sort criteria </param>
        /// <param name="level"> compatibility level </param>
        /// <returns> the sheet (note that if there is no such resource, this method will throw a ResourceNotFoundException rather than returning null). </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual Sheet SortSheet(long id, SortSpecifier sortSpecifier, int? level)
        {
            HttpRequest request = null;
            try
            {
                string path = "sheets/" + id + "/sort";
                if (level != null)
                {
                    path += "?level=" + level.ToString();
                }
                    
                request = CreateHttpRequest(new Uri(this.Smartsheet.BaseURI, path), HttpMethod.POST);
            }
            catch (Exception e)
            {
                throw new SmartsheetException(e);
            }

            request.Entity = serializeToEntity<SortSpecifier>(sortSpecifier);

            HttpResponse response = this.Smartsheet.HttpClient.Request(request);

            Object obj = null;
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    obj = this.Smartsheet.JsonSerializer.deserialize<Sheet>(
                        response.Entity.GetContent());
                    break;
                default:
                    HandleError(response);
                    break;
            }

            this.Smartsheet.HttpClient.ReleaseConnection();

            return (Sheet)obj;
        }

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
        public virtual Sheet ImportCsvSheet(string file, string sheetName, int? headerRowIndex, int? primaryColumnIndex)
        {
            if (sheetName == null)
            {
                FileInfo fi = new FileInfo(file);
                sheetName = fi.Name;
            }
            return ImportSheet("sheets/import", file, sheetName, headerRowIndex, primaryColumnIndex, "text/csv");
        }

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
        public virtual Sheet ImportXlsSheet(string file, string sheetName, int? headerRowIndex, int? primaryColumnIndex)
        {
            if(sheetName == null)
            {
                FileInfo fi = new FileInfo(file);
                sheetName = fi.Name;
            }
            return ImportSheet("sheets/import", file, sheetName, headerRowIndex, primaryColumnIndex, 
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        /// <summary>
        /// Returns the ShareResources object that provides access to share resources associated with sheet resources.
        /// </summary>
        /// <returns> the ShareResources object </returns>
        public virtual ShareResources ShareResources
        {
            get { return this.shares; }
        }

        /// <summary>
        /// Returns the SheetRowResources object that provides access to row resources associated with sheet resources.
        /// </summary>
        /// <returns> the sheet row resources </returns>
        public virtual SheetRowResources RowResources
        {
            get { return this.rows; }
        }

        /// <summary>
        /// Returns the SheetColumnResources object that provides access to column resources associated with sheet resources.
        /// </summary>
        /// <returns> the sheet column resources </returns>
        public virtual SheetColumnResources ColumnResources
        {
            get { return this.columns; }
        }

        /// <summary>
        /// Returns the SheetAttachmentResources object that provides access to attachment resources associated with
        /// sheet resources.
        /// </summary>
        /// <returns> the associated attachment resources </returns>
        public virtual SheetAttachmentResources AttachmentResources
        {
            get { return this.attachments; }
        }

        /// <summary>
        /// Returns the SheetDiscussionResources object that provides access to discussion resources associated with
        /// sheet resources.
        /// </summary>
        /// <returns> the associated discussion resources </returns>
        public virtual SheetDiscussionResources DiscussionResources
        {
            get { return this.discussions; }
        }

        /// <summary>
        /// Returns the SheetCommentResources object that provides access to discussion resources associated with
        /// sheet resources.
        /// </summary>
        /// <returns> the associated comment resources </returns>
        public SheetCommentResources CommentResources
        {
            get { return this.comments; }
        }

        /// <summary>
        /// Returns the UpdateRequestResources object that provides access to update request resources associated with
        /// sheet resources.
        /// </summary>
        /// <returns> the associated update request resources </returns>
        public SheetUpdateRequestResources UpdateRequestResources
        {
            get { return this.updateRequests; }
        }

        /// <summary>
        /// Returns the FilterResources object that provides access to filter resources associated with sheet resources.
        /// </summary>
        /// <returns> the associated filter resources </returns>
        public SheetFilterResources FilterResources
        {
            get { return this.filters; }
        }

        /// <summary>
        /// Returns the AutomationRuleResources object that provides access to automation rule resources associated 
        /// with sheet resources.
        /// </summary>
        /// <returns> the associated automation rule resources </returns>
        public SheetAutomationRuleResources AutomationRuleResources
        {
            get { return this.automationRules; }
        }

        /// <summary>
        /// Returns the CrossSheetReferenceResources object that provides access to cross-sheet reference resources associated 
        /// with sheet resources.
        /// </summary>
        /// <returns> the associated cross-sheet reference resources </returns>
        public SheetCrossSheetReferenceResources CrossSheetReferenceResources
        {
            get { return this.crossSheetReferences; }
        }

        /// <summary>
        /// <para>Gets a sheet as a file.</para>
        /// 
        /// <para>Mirrors to the following Smartsheet REST API method:<br />
        /// GET /sheets/{sheetId} with "application/pdf", "application/vnd.ms-excel", or "text/csv" as Accept HTTP header</para>
        /// </summary>
        /// <param name="sheetId"> the Id of the sheet </param>
        /// <param name="paperSize"> the size of the PDF file </param>
        /// <param name="outputStream"> the output stream to which the CSV file will be written. </param>
        /// <param name="contentType"> the Accept header </param>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
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

        /// <summary>
        /// Private routine to import a sheet of contentType
        /// </summary>
        /// <param name="path"></param>
        /// <param name="file"></param>
        /// <param name="sheetName"></param>
        /// <param name="headerRowIndex"></param>
        /// <param name="primaryColumnIndex"></param>
        /// <param name="contentType"></param>
        /// <returns> the created sheet </returns>
        private Sheet ImportSheet(string path, string file, string sheetName, int? headerRowIndex, int? primaryColumnIndex, string contentType)
        {
            Utility.Utility.ThrowIfNull(file);

            IDictionary<string, string> parameters = new Dictionary<string, string>();

            if (sheetName != null)
            {
                parameters.Add("sheetName", sheetName);
            }
            if (headerRowIndex != null)
            {
                parameters.Add("headerRowIndex", headerRowIndex.ToString());
            }
            if (primaryColumnIndex != null)
            {
                parameters.Add("primaryColumnIndex", primaryColumnIndex.ToString());
            }
            path += QueryUtil.GenerateUrl(null, parameters);

            return this.ImportFile<Sheet>(path, file, contentType);
        }

        /*
         * Copy an input stream to an output stream.
         * 
         * @param input The input stream to copy.
         * 
         * @param output the output stream to write to.
         * 
         * @throws IOException if there is trouble reading or writing to the streams.
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
