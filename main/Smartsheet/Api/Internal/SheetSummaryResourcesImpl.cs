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
    using Smartsheet.Api.Internal.Util;
    using Smartsheet.Api.Internal.Http;
    using Smartsheet.Api.Models;
    using System.Net;
    using System.IO;
    using System;

    /// <summary>
    /// This is the implementation of the SheetSummaryResources.
    /// 
    /// Thread Safety: This class is thread safe because it is immutable and its base class is thread safe.
    /// </summary>
    public class SheetSummaryResourcesImpl : AbstractResources, SheetSummaryResources
    {
        /// <summary>
        /// Constructor.
        /// 
        /// Parameters: - Smartsheet : the SmartsheetImpl
        /// 
        /// Exceptions: - IllegalArgumentException : if any argument is null
        /// </summary>
        /// <param name="smartsheet"> the Smartsheet </param>
        public SheetSummaryResourcesImpl(SmartsheetImpl smartsheet)
            : base(smartsheet)
        {
        }

        /// <summary>
        /// <para>Gets the sheet summary</para>
        /// <para>It mirrors to the following Smartsheet REST API method: GET /sheets/{sheetId}/summary</para>
        /// </summary>
        /// <param name="sheetId"> the sheet Id </param>
        /// <param name="include"> optional objects to include </param>
        /// <param name="exclude"> optional object to exclude </param>
        /// <returns> the sheet summary </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual SheetSummary GetSheetSummary(long sheetId, IEnumerable<SummaryFieldInclusion> include, IEnumerable<SummaryFieldExclusion> exclude)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            if (include != null)
            {
                parameters.Add("include", QueryUtil.GenerateCommaSeparatedList(include));
            }
            if (exclude != null)
            {
                parameters.Add("exclude", QueryUtil.GenerateCommaSeparatedList(exclude));
            }
            return this.GetResource<SheetSummary>("sheets/" + sheetId + "/summary" + QueryUtil.GenerateUrl(null, parameters), typeof(SheetSummary));
        }

        /// <summary>
        /// <para>Gets the sheet summary fields</para>
        /// <para>It mirrors to the following Smartsheet REST API method: GET /sheets/{sheetId}/summary/fields</para>
        /// </summary>
        /// <param name="sheetId"> the sheet Id </param>
        /// <param name="include"> optional objects to include </param>
        /// <param name="exclude"> optional object to exclude </param>
        /// <returns> the paged list of sheet summary fields </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual PaginatedResult<SummaryField> GetSheetSummaryFields(long sheetId, IEnumerable<SummaryFieldInclusion> include, IEnumerable<SummaryFieldExclusion> exclude, PaginationParameters paging)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            if (paging != null)
            {
                parameters = paging.toDictionary();
            }
            if (include != null)
            {
                parameters.Add("include", QueryUtil.GenerateCommaSeparatedList(include));
            }
            if (exclude != null)
            {
                parameters.Add("exclude", QueryUtil.GenerateCommaSeparatedList(exclude));
            }

            return this.ListResourcesWithWrapper<SummaryField>("sheets/" + sheetId + "/summary/fields" + QueryUtil.GenerateUrl(null, parameters));
        }

        /// <summary>
        /// <para>Insert fields into a sheet summary</para>
        /// <para>It mirrors to the following Smartsheet REST API method: POST /sheets/{sheetId}/summary/fields</para>
        /// </summary>
        /// <param name="sheetId"> the sheet Id </param>
        /// <param name="fields"> list of fields to be added </param>
        /// <param name="renameIfConflict"> true if the call should rename conflicting field titles </param>
        /// <returns> a list of created fields </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual IList<SummaryField> AddSheetSummaryFields(long sheetId, IEnumerable<SummaryField> fields, bool? renameIfConflict)
        {
            foreach (SummaryField field in fields)
            {
                field.Id = null;
            }

            IDictionary<string, string> parameters = new Dictionary<string, string>();
            if (renameIfConflict.HasValue)
            {
                parameters.Add("renameIfConflict", renameIfConflict.Value.ToString());
            }

            return this.PostAndReceiveList<IEnumerable<SummaryField>, SummaryField>("sheets/" + sheetId + "/summary/fields" + QueryUtil.GenerateUrl(null, parameters),
                fields, typeof(SummaryField));
        }

        /// <summary>
        /// <para>Insert fields into a sheet summary</para>
        /// <para>It mirrors to the following Smartsheet REST API method: POST /sheets/{sheetId}/summary/fields</para>
        /// </summary>
        /// <param name="sheetId"> the sheet Id </param>
        /// <param name="fields"> list of fields to be added </param>
        /// <param name="renameIfConflict"> true if the call should rename conflicting field titles </param>
        /// <returns> a list of created fields </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual BulkItemResult<SummaryField> AddSheetSummaryFieldsAllowPartialSuccess(long sheetId, IEnumerable<SummaryField> fields, bool? renameIfConflict)
        {
            foreach (SummaryField field in fields)
            {
                field.Id = null;
            }

            return doBulkUpdate(sheetId, fields, renameIfConflict, HttpMethod.POST);
        }

        /// <summary>
        /// <para>Update fields in the sheet summary</para>
        /// <para>It mirrors to the following Smartsheet REST API method: PUT /sheets/{sheetId}/summary/fields</para>
        /// </summary>
        /// <param name="sheetId"> the sheet Id </param>
        /// <param name="fields"> list of fields to be updated </param>
        /// <param name="renameIfConflict"> true if the call should rename conflicting field titles </param>
        /// <returns> a list of updated fields </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual IList<SummaryField> UpdateSheetSummaryFields(long sheetId, IEnumerable<SummaryField> fields, bool? renameIfConflict)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            if (renameIfConflict.HasValue)
            {
                parameters.Add("renameIfConflict", renameIfConflict.Value.ToString());
            }

            return this.PutAndReceiveList<IEnumerable<SummaryField>, SummaryField>("sheets/" + sheetId + "/summary/fields" + QueryUtil.GenerateUrl(null, parameters),
                fields, typeof(SummaryField));
        }

        /// <summary>
        /// <para>Update fields in the sheet summary</para>
        /// <para>It mirrors to the following Smartsheet REST API method: PUT /sheets/{sheetId}/summary/fields</para>
        /// </summary>
        /// <param name="sheetId"> the sheet Id </param>
        /// <param name="fields"> list of fields to be updated </param>
        /// <param name="renameIfConflict"> true if the call should rename conflicting field titles </param>
        /// <returns> a list of updated fields </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual BulkItemResult<SummaryField> UpdateSheetSummaryFieldsAllowPartialSuccess(long sheetId, IEnumerable<SummaryField> fields, bool? renameIfConflict)
        {
            return doBulkUpdate(sheetId, fields, renameIfConflict, HttpMethod.PUT);
        }

        /// <summary>
        /// <para>Delete fields in a sheet summary.</para>
        /// <para>It mirrors to the following Smartsheet REST API method: DELETE /sheets/{sheetId}/summary/fields</para>
        /// </summary>
        /// <param name="sheetId"> the sheetId </param>
        /// <param name="fieldIds"> the field IDs </param>
        /// <param name="ignoreSummaryFieldsNotFound"> true if the call should ignore fields not found </param>
        /// <returns>List of field Ids deleted.</returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual IList<long> DeleteSheetSummaryFields(long sheetId, IEnumerable<long> fieldIds, bool? ignoreSummaryFieldsNotFound)
        {
            Utility.Utility.ThrowIfNull(fieldIds);
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("ids", QueryUtil.GenerateCommaSeparatedList(fieldIds));
            if (ignoreSummaryFieldsNotFound.HasValue)
            {
                parameters.Add("ignoreSummaryFieldsNotFound", ignoreSummaryFieldsNotFound.Value.ToString());
            }
            return this.DeleteResource<IList<long>>(QueryUtil.GenerateUrl("sheets/" + sheetId + "/summary/fields", parameters));
        }

        /// <summary>
        /// <para>Adds an image to the sheet summary field.</para>
        /// <para>Mirrors to the following Smartsheet REST API method: POST /sheets/{sheetId}/summary/fields/{fieldId}/images</para>
        /// </summary>
        /// <param name="sheetId"> the sheet id </param>
        /// <param name="fieldId"> the summary field id </param>
        /// <param name="file"> the file path </param>
        /// <param name="fileType"> the file type </param>
        /// <param name="altText"> image alternate text </param>
        /// <returns> Result </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual SummaryField AddSheetSummaryFieldImage(long sheetId, long fieldId, string file, string fileType, string altText)
        {
            string path = "sheets/" + sheetId + "/summary/fields/" + fieldId + "/images";

            Utility.Utility.ThrowIfNull(file);

            if (fileType == null)
            {
                fileType = "application/octet-stream";
            }

            IDictionary<string, string> parameters = new Dictionary<string, string>();
            if (altText != null)
            {
                parameters.Add("altText", altText);
            }

            path = QueryUtil.GenerateUrl(path, parameters);

            FileInfo fi = new FileInfo(file);
            HttpRequest request = CreateHttpRequest(new Uri(this.Smartsheet.BaseURI, path), HttpMethod.POST);

            request.Headers["Content-Disposition"] = "attachment; filename=\"" + fi.Name + "\"";

            HttpEntity entity = new HttpEntity();
            entity.ContentType = fileType;

            entity.Content = File.ReadAllBytes(file);
            entity.ContentLength = fi.Length;
            request.Entity = entity;

            HttpResponse response = this.Smartsheet.HttpClient.Request(request);

            SummaryField summaryField = null;
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    summaryField = this.smartsheet.JsonSerializer.deserializeResult<SummaryField>(response.Entity.GetContent()).Result;
                    break;
                default:
                    HandleError(response);
                    break;
            }

            this.Smartsheet.HttpClient.ReleaseConnection();
            return summaryField;
        }

        private BulkItemResult<SummaryField> doBulkUpdate(long sheetId, IEnumerable<SummaryField> fields, bool? renameIfConflict, HttpMethod httpMethod)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("allowPartialSuccess", "true");
            if (renameIfConflict.HasValue)
            {
                parameters.Add("renameIfConflict", renameIfConflict.Value.ToString());
            }

            HttpRequest request = null;
            try
            {
                request = CreateHttpRequest(new Uri(this.Smartsheet.BaseURI, QueryUtil.GenerateUrl("sheets/" + sheetId + "/summary/fields", parameters)), httpMethod);
            }
            catch (Exception e)
            {
                throw new SmartsheetException(e);
            }

            request.Entity = serializeToEntity<IEnumerable<SummaryField>>(fields);

            HttpResponse response = this.Smartsheet.HttpClient.Request(request);

            BulkItemResult<SummaryField> bulkItemResult = null;
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    bulkItemResult = this.Smartsheet.JsonSerializer.deserialize<BulkItemResult<SummaryField>>(response.Entity.GetContent());
                    break;
                default:
                    HandleError(response);
                    break;
            }

            Smartsheet.HttpClient.ReleaseConnection();

            return bulkItemResult;
        }
    }
}
