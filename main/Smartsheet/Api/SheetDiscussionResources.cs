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
    /// <para>This interface provides methods to access discussion resources that are associated to a Sheet object.</para>
    /// 
    /// <para>Thread Safety: Implementation of this interface must be thread safe.</para>
    /// </summary>
    public interface SheetDiscussionResources
    {
        /// <summary>
        /// <para>Creates a new discussion on a sheet.</para>
        /// <para>Mirrors to the following Smartsheet REST API method: POST /sheets/{sheetId}/discussions</para>
        /// </summary>
        /// <param name="sheetId"> the Id of the sheet </param>
        /// <param name="discussion"> the discussion to add </param>
        /// <returns> the created discussion </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        Discussion CreateDiscussion(long sheetId, Discussion discussion);

        /// <summary>
        /// <para>Creates a new discussion with an attachment on a sheet.</para>
        /// <para>Mirrors to the following Smartsheet REST API method: POST /sheets/{sheetId}/discussions</para>
        /// </summary>
        /// <param name="sheetId"> the Id of the sheet </param>
        /// <param name="discussion"> the discussion to add </param>
        /// <param name="file"> the file path </param>
        /// <param name="fileType"> the file type, can be null </param>
        /// <returns> the created discussion </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        Discussion CreateDiscussionWithAttachment(long sheetId, Discussion discussion, string file, string fileType = null);

        /// <summary>
        /// <para>Deletes a discussion</para>
        /// <para>Mirrors to the following Smartsheet REST API method: DELETE /sheets/{sheetId}/discussions/{discussionId}</para>
        /// </summary>
        /// <param name="sheetId"> the sheet Id </param>
        /// <param name="discussionId"> the discussion Id</param>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        void DeleteDiscussion(long sheetId, long discussionId);

        /// <summary>
        /// <para>Gets a list of all discussions associated with the specified sheet (both sheet-level discussions and row-level discussions).</para>
        /// <para>Mirrors to the following Smartsheet REST API method: GET /sheets/{sheetId}/discussions</para>
        /// <remarks>This operation supports pagination of results. For more information, see Paging.</remarks>
        /// </summary>
        /// <param name="sheetId"> the sheet Id </param>
        /// <param name="include">elements to include in the response</param>
        /// <param name="paging">the pagination</param>
        /// <returns> list of all discussions </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        PaginatedResult<Discussion> ListDiscussions(long sheetId, IEnumerable<DiscussionInclusion> include = null, PaginationParameters paging = null);


        /// <summary>
        /// <para>Gets the discussion specified in the URL.</para>
        /// <para>Mirrors to the following Smartsheet REST API method: GET /sheets/{sheetId}/discussions/{discussionId}</para>
        /// </summary>
        /// <param name="sheetId"> the Id of the sheet </param>
        /// <param name="discussionId"> the ID of the discussion </param>
        /// <returns> the discussion </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        Discussion GetDiscussion(long sheetId, long discussionId);

        /// <summary>
        /// <para>Return the DiscussionAttachmentResources object that provides access
        /// to attachment resources associated with discussion resources.</para>
        /// </summary>
        /// <returns> the DiscussionAttachmentResources object </returns>
        DiscussionAttachmentResources AttachmentResources { get; }

        /// <summary>
        /// <para>Returns the DiscussionCommentResources object that provides access
        /// to comment resources associated with discussion resources.</para>
        /// </summary>
        /// <returns> the DiscussionCommentResources object </returns>
        DiscussionCommentResources CommentResources { get; }
    }
}
