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

namespace Smartsheet.Api
{ 
    using Api.Models;

    /// <summary>
    /// This interface provides methods to access sheet summary resources that are associated to a sheet object.
    /// 
    /// Thread Safety: Implementation of this interface must be thread safe.
    /// </summary>
    public interface SheetSummaryResources
    {
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
        SheetSummary GetSheetSummary(long sheetId, IEnumerable<SummaryFieldInclusion> include, IEnumerable<SummaryFieldExclusion> exclude);

        /// <summary>
        /// <para>Gets the sheet summary fields</para>
        /// <para>It mirrors to the following Smartsheet REST API method: GET /sheets/{sheetId}/summary/fields</para>
        /// </summary>
        /// <param name="sheetId"> the sheet Id </param>
        /// <param name="include"> optional objects to include </param>
        /// <param name="exclude"> optional object to exclude </param>
        /// <param name="paging"> pagination parameters for the response </param>
        /// <returns> the paged list of sheet summary fields </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        PaginatedResult<SummaryField> GetSheetSummaryFields(long sheetId, IEnumerable<SummaryFieldInclusion> include, IEnumerable<SummaryFieldExclusion> exclude, PaginationParameters paging);

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
        IList<SummaryField> AddSheetSummaryFields(long sheetId, IEnumerable<SummaryField> fields, bool? renameIfConflict);

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
        BulkItemResult<SummaryField> AddSheetSummaryFieldsAllowPartialSuccess(long sheetId, IEnumerable<SummaryField> fields, bool? renameIfConflict);

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
        IList<SummaryField> UpdateSheetSummaryFields(long sheetId, IEnumerable<SummaryField> fields, bool? renameIfConflict);

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
        BulkItemResult<SummaryField> UpdateSheetSummaryFieldsAllowPartialSuccess(long sheetId, IEnumerable<SummaryField> fields, bool? renameIfConflict);

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
        IList<long> DeleteSheetSummaryFields(long sheetId, IEnumerable<long> fieldIds, bool? ignoreSummaryFieldsNotFound);

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
        SummaryField AddSheetSummaryFieldImage(long sheetId, long fieldId, string file, string fileType, string altText);
    }
}
