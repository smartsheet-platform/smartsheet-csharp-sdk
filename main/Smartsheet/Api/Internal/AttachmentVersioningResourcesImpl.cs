﻿//    #[license]
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

namespace Smartsheet.Api.Internal
{
    using Smartsheet.Api.Internal.Http;
    using Smartsheet.Api.Models;
    using System;
    using System.IO;
    using System.Net;
    using System.Text;

    /// <summary>
    /// This is the implementation of the AttachmentVersioningResources.
    /// 
    /// Thread Safety: This class is thread safe because it is immutable and its base class is thread safe.
    /// </summary>
    public class AttachmentVersioningResourcesImpl : AbstractResources, AttachmentVersioningResources
    {
        /// <summary>
        /// Constructor.
        /// 
        /// Parameters: - Smartsheet : the SmartsheetImpl
        /// 
        /// Exceptions: - IllegalArgumentException : if any argument is null
        /// </summary>
        /// <param name="smartsheet"> the Smartsheet </param>
        public AttachmentVersioningResourcesImpl(SmartsheetImpl smartsheet)
            : base(smartsheet)
        {
        }

        /// <summary>
        /// <para>Uploads a new version of a file to a Sheet or Row.
        /// This operation can be performed using a simple upload or a multipart upload. For more information, see Posting an Attachment.</para>
        /// <para>It mirrors to the following Smartsheet REST API method:<br />
        ///  POST /sheets/{sheetId}/attachments/{attachmentId}/versions</para>
        ///  <remarks><para>Uploading new versions is not supported for attachments on Comments or for URL attachments.</para>
        ///  <para>This is a resource-intensive operation and incurs 10 additional requests against the rate limit.</para></remarks>
        /// </summary>
        /// <param name="sheetId"> the sheet id </param>
        /// <param name="attachmentId"> the attachment id </param>
        /// <param name="file"> the file path </param>
        /// <param name="fileType"> the file type </param>
        /// <returns> Attachment object for the newly created attachment </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual Attachment AttachNewVersion(long sheetId, long attachmentId, string file, string fileType = null)
        {
            return AttachFile("sheets/" + sheetId + "/attachments/" + attachmentId + "/versions", file, fileType);
        }

        /// <summary>
        /// <para>Deletes all versions of the attachment corresponding to the specified Attachment ID.
        /// For attachments with multiple versions, this will effectively delete the attachment from the object that it’s attached to.</para>
        /// <para>It mirrors to the following Smartsheet REST API method: DELETE /sheets/{sheetId}/attachments/{attachmentId}/versions</para>
        /// </summary>
        /// <param name="sheetId"> the sheetId </param>
        /// <param name="attachmentId"> the attachment id </param>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual void DeleteAllVersions(long sheetId, long attachmentId)
        {
            this.DeleteResource<Attachment>("sheets/" + sheetId + "/attachments/" + attachmentId + "/versions", typeof(Attachment));
        }

        /// <summary>
        /// <para>Gets a list of all versions of the given Attachment ID, in order from newest to oldest.</para>
        /// <remarks><para>This operation supports pagination of results. For more information, see Paging.</para>
        /// <para>to retrieve a download URL for a file attachment, use the Get Attachment operation for the specific version you want to download.</para></remarks>
        /// <para>It mirrors to the following Smartsheet REST API method: GET /sheets/{sheetId}/attachments/{attachmentId}/versions</para>
        /// </summary>
        /// <param name="sheetId"> the sheet id </param>
        /// <param name="attachmentId"> the attachment id </param>
        /// <param name="paging">the pagination</param>
        /// <returns>  list of all versions of the given Attachment ID. </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual PaginatedResult<Attachment> ListVersions(long sheetId, long attachmentId, PaginationParameters paging = null)
        {
            StringBuilder path = new StringBuilder("sheets/" + sheetId + "/attachments/" + attachmentId + "/versions");
            if (paging != null)
            {
                path.Append(paging.ToQueryString());
            }
            return this.ListResourcesWithWrapper<Attachment>(path.ToString());
        }

        /// <summary>
        /// Attach file.
        /// </summary>
        /// <param name="path"> the url path </param>
        /// <param name="file"> the file </param>
        /// <param name="contentType"> the content Type </param>
        /// <returns> the attachment </returns>
        /// <exception cref="FileNotFoundException"> the file not found exception </exception>
        /// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
        private Attachment AttachFile(string path, string file, string contentType)
        {
            Utility.Utility.ThrowIfNull(file);
            if (contentType == null)
            {
                contentType = "application/octet-stream";
            }
            FileInfo fi = new FileInfo(file);
            HttpRequest request = CreateHttpRequest(new Uri(this.Smartsheet.BaseURI, path), HttpMethod.POST);

            request.Headers["Content-Disposition"] = "attachment; filename=\"" + fi.Name + "\"";

            HttpEntity entity = new HttpEntity();
            entity.ContentType = contentType;

            entity.Content = File.ReadAllBytes(file);
            entity.ContentLength = fi.Length;
            request.Entity = entity;

            HttpResponse response = this.Smartsheet.HttpClient.Request(request);

            Attachment attachment = null;
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    attachment = this.Smartsheet.JsonSerializer.deserializeResult<Attachment>(
                        response.Entity.GetContent()).Result;
                    break;
                default:
                    HandleError(response);
                    break;
            }

            this.Smartsheet.HttpClient.ReleaseConnection();

            return attachment;
        }
    }
}