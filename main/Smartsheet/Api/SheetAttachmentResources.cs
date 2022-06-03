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

using Smartsheet.Api.Models;
using System.Collections.Generic;

namespace Smartsheet.Api
{
    /// <summary>
    /// <para>This interface provides methods to access Attachment resources that are associated to a sheet object.</para>
    ///
    /// <para>Thread Safety: Implementation of this interface must be thread safe.</para>
    /// </summary>
    public interface SheetAttachmentResources
    {
        /// <summary>
        /// <para>Attaches a file to the Sheet.</para>
        /// <para>This operation will always create a new attachment.
        /// To upload a new version of the same attachment, use the Attach New Version operation.</para>
        /// <para>It mirrors to the following Smartsheet REST API method:
        /// POST /sheets/{sheetId}/attachments</para>
        /// </summary>
        /// <param name="sheetId"> the sheetId </param>
        /// <param name="file"> the file path </param>
        /// <param name="fileType"> the file type </param>
        /// <returns> the newly created Attachment </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        Attachment AttachFile(long sheetId, string file, string fileType);

        /// <summary>
        /// <para>Attaches a file to the Sheet.</para>
        /// <para>This operation will always create a new attachment.
        /// To upload a new version of the same attachment, use the Attach New Version operation.</para>
        /// <para>It mirrors to the following Smartsheet REST API method:
        /// POST /sheets/{sheetId}/attachments</para>
        /// </summary>
        /// <param name="sheetId"> the sheetId </param>
        /// <param name="file"> the file path </param>
        /// <param name="fileBinary"></param>
        /// <param name="fileType"> the file type </param>
        /// <param name="fileName"></param>
        /// <returns> the newly created Attachment </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        Attachment AttachFile(long sheetId, string fileName,
            byte[] fileBinary, string fileType);

        /// <summary>
        /// <para>Attaches a URL to the Sheet.</para>
        /// <para>It mirrors to the following Smartsheet REST API method:
        /// POST /sheets/{sheetId}/attachments</para>
        /// <remarks><para>attachmentSubType is valid only for GOOGLE_DRIVE attachments which are Google Docs.
        /// It can optionally be included to indicate the type of a file.
        /// The following attachmentSubTypes are valid for GOOGLE_DRIVE attachments "DOCUMENT", "SPREADSHEET", "PRESENTATION", "PDF", "DRAWING".</para>
        /// <para>When the attachment type is BOX_COM, DROPBOX, or GOOGLE_DRIVE (without an attachmentSubType specified),
        /// the mimeType will be derived by the file extension specified on the “name”.</para>
        /// </remarks>
        /// </summary>
        /// <param name="sheetId"> the sheetId </param>
        /// <param name="attachment"> the attachment object </param>
        /// <returns> the newly created Attachment </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        Attachment AttachUrl(long sheetId, Attachment attachment);

        /// <summary>
        /// <para>Deletes the Attachment.</para>
        /// <remarks>If the Attachment has multiple versions this deletes only
        /// the specific version specified by the attachmentId (each version has a different attachment ID).</remarks>
        /// <para>It mirrors to the following Smartsheet REST API method: DELETE /sheets/{sheetId}/attachments/{attachmentId}</para>
        /// </summary>
        /// <param name="sheetId"> the sheetId </param>
        /// <param name="attachmentId"> the attachmentId </param>
        /// <returns> the newly created Attachment </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        void DeleteAttachment(long sheetId, long attachmentId);

        /// <summary>
        /// <para>Fetches the Attachment.</para>
        /// <para>It mirrors to the following Smartsheet REST API method: GET /sheets/{sheetId}/attachments/{attachmentId}</para>
        /// </summary>
        /// <param name="sheetId"> the sheetId </param>
        /// <param name="attachmentId"> the attachmentId </param>
        /// <returns> the Attachment object. For File attachments, this will include a temporary URL for downloading the file.
        /// Currently, the temporary URL is set to expire in 120000 milliseconds, or 2 minutes.</returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        Attachment GetAttachment(long sheetId, long attachmentId);

        /// <summary>
        /// <para>Gets a list of all Attachments that are on the Sheet, including Sheet, Row, and Discussion level Attachments.</para>
        /// <remarks>This operation supports pagination of results. For more information, see Paging.</remarks>
        /// </summary>
        /// <param name="sheetId"> the sheetId </param>
        /// <param name="paging"> the pagination </param>
        /// <returns> list of Attachment objects </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        PaginatedResult<Attachment> ListAttachments(long sheetId, PaginationParameters paging);

        /// <summary>
        /// Return the AttachmentVersioningResources object that provides access to Versioning resources associated with Attachment resources.
        /// </summary>
        /// <returns> the attachment versioning resources </returns>
        AttachmentVersioningResources VersioningResources { get; }
    }
}