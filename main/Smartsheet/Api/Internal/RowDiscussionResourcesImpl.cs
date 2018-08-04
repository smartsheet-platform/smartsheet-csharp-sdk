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
    using Smartsheet.Api.Models;

    /// <summary>
    /// This is the implementation of the RowDiscussionResources.
    /// 
    /// Thread Safety: This class is thread safe because it is immutable and its base class is thread safe.
    /// </summary>
    public class RowDiscussionResourcesImpl : AbstractResources, RowDiscussionResources
    {
        /// <summary>
        /// Constructor.
        /// 
        /// Exceptions: - IllegalArgumentException : if any argument is null
        /// </summary>
        /// <param name="smartsheet"> the Smartsheet </param>
        public RowDiscussionResourcesImpl(SmartsheetImpl smartsheet)
            : base(smartsheet)
        {
        }
        /// <summary>
        /// <para>Creates a new Discussion on a Row.</para>
        /// <para>It mirrors to the following Smartsheet REST API method:<br />
        /// POST /sheets/{sheetId}/rows/{rowId}/discussions</para>
        /// </summary>
        /// <param name="sheetId"> the id of the sheet </param>
        /// <param name="rowId"> the id of the row </param>
        /// <param name="discussion"> the discussion to add </param>
        /// <returns> the created discussion </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual Discussion CreateDiscussion(long sheetId, long rowId, Discussion discussion)
        {
            return this.CreateResource("sheets/" + sheetId + "/rows/" + rowId + "/discussions", typeof(Discussion), discussion);
        }

        /// <summary>
        /// <para>Creates a new Discussion attached with an Attachment on a Row.</para>
        /// <para>It mirrors to the following Smartsheet REST API method:<br />
        /// POST /sheets/{sheetId}/rows/{rowId}/discussions</para>
        /// </summary>
        /// <param name="sheetId"> the id of the sheet </param>
        /// <param name="rowId"> the id of the row </param>
        /// <param name="discussion"> the discussion to add </param>
        /// <param name="file"> the file path </param>
        /// <param name="fileType"> the file type, can be null </param>
        /// <returns> the created discussion </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual Discussion CreateDiscussionWithAttachment(long sheetId, long rowId, Discussion discussion, string file, string fileType = null)
        {
            return this.CreateResourceWithAttachment("sheets/" + sheetId + "/rows/" + rowId + "/discussions", discussion, "discussion", file, fileType);
        }

        /// <summary>
        /// <para>Gets a list of all Discussions associated with the specified Row.</para>
        /// <para>It mirrors to the following Smartsheet REST API method: GET /sheets/{sheetId}/rows/{rowId}/discussions</para>
        /// <remarks>This operation supports pagination of results. For more information, see Paging.</remarks>
        /// </summary>
        /// <param name="sheetId"> the sheet Id </param>
        /// <param name="rowId"> the row Id </param>
        /// <param name="include">elements to include in response</param>
        /// <param name="paging">the pagination</param>
        /// <returns> list of all Discussions </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual PaginatedResult<Discussion> ListDiscussions(long sheetId, long rowId, IEnumerable<DiscussionInclusion> include = null, PaginationParameters paging = null)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            if (paging != null)
            {
                parameters = paging.toDictionary();
            }
            parameters.Add("include", Util.QueryUtil.GenerateCommaSeparatedList(include));
            return this.ListResourcesWithWrapper<Discussion>("sheets/" + sheetId + "/rows/" + rowId + "/discussions" + Util.QueryUtil.GenerateUrl(null, parameters));
        }
    }
}