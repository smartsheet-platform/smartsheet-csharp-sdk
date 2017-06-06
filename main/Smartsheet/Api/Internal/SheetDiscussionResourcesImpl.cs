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

using Smartsheet.Api.Internal.Util;
using Smartsheet.Api.Models;
using System;
using System.Collections.Generic;

namespace Smartsheet.Api.Internal
{
	/// <summary>
	/// This is the implementation of the SheetDiscussionResources.
	/// 
	/// Thread Safety: This class is thread safe because it is immutable and its base class is thread safe.
	/// </summary>
	public class SheetDiscussionResourcesImpl : AbstractResources, SheetDiscussionResources
	{
		private DiscussionAttachmentResources attachments;

		private DiscussionCommentResources comments;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="smartsheet"> the Smartsheet </param>
        /// <exception cref="InvalidOperationException">if any argument is null</exception>
        public SheetDiscussionResourcesImpl(SmartsheetImpl smartsheet)
			: base(smartsheet)
		{
			this.attachments = new DiscussionAttachmentResourcesImpl(smartsheet);
			this.comments = new DiscussionCommentResourcesImpl(smartsheet);
		}

		/// <summary>
		/// <para>Creates a new Discussion on a Sheet.</para>
		/// <para>It mirrors To the following Smartsheet REST API method:<br />
		/// POST /sheets/{sheetId}/discussions</para>
		/// </summary>
		/// <param name="sheetId"> the id of the sheet </param>
		/// <param name="discussion"> the discussion to add </param>
		/// <returns> the created discussion </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual Discussion CreateDiscussion(long sheetId, Discussion discussion)
		{
			return this.CreateResource("sheets/" + sheetId + "/discussions", typeof(Discussion), discussion);
		}

		/// <summary>
		/// <para>Creates a new Discussion attached with an Attachment on a Sheet.</para>
		/// <para>It mirrors To the following Smartsheet REST API method:<br />
		/// POST /sheets/{sheetId}/discussions</para>
		/// </summary>
		/// <param name="sheetId"> the id of the sheet </param>
		/// <param name="discussion"> the discussion to add </param>
		/// <param name="file"> the file path </param>
		/// <param name="fileType"> the file type, can be null </param>
		/// <returns> the created discussion </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual Discussion CreateDiscussionWithAttachment(long sheetId, Discussion discussion, string file, string fileType)
		{
			return this.CreateResourceWithAttachment("sheets/" + sheetId + "/discussions", discussion, "discussion", file, fileType);
		}

		/// <summary>
		/// <para>Delete a discussion</para>
		/// <para>It mirrors To the following Smartsheet REST API method: DELETE /sheets/{sheetId}/discussions/{discussionId}</para>
		/// </summary>
		/// <param name="sheetId"> the sheetId </param>
		/// <param name="discussionId"> the discussionId</param>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual void DeleteDiscussion(long sheetId, long discussionId)
		{
			this.DeleteResource<Discussion>("sheets/" + sheetId + "/discussions/" + discussionId, typeof(Discussion));
		}

		/// <summary>
		/// <para>Gets a list of all Discussions associated with the specified Sheet (both sheet-level discussions and row-level discussions).</para>
		/// <para>It mirrors To the following Smartsheet REST API method: GET /sheets/{sheetId}/discussions</para>
		/// <remarks>This operation supports pagination of results. For more information, see Paging.</remarks>
		/// </summary>
		/// <param name="sheetId"> the sheet Id </param>
		/// <param name="include">elements to include in response</param>
		/// <param name="paging">the pagination</param>
		/// <returns> list of all Discussions </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual PaginatedResult<Discussion> ListDiscussions(long sheetId, IEnumerable<DiscussionInclusion> include, PaginationParameters paging)
		{
			IDictionary<string, string> parameters = new Dictionary<string, string>();
			if (paging != null)
			{
				parameters = paging.toDictionary();
			}
			if (include != null)
			{
				parameters.Add("include", Util.QueryUtil.GenerateCommaSeparatedList(include));
			}
			return this.ListResourcesWithWrapper<Discussion>(QueryUtil.GenerateUrl("sheets/" + sheetId + "/discussions", parameters));
		}


		/// <summary>
		/// <para>Gets the Discussion specified in the URL.</para>
		/// <para>It mirrors To the following Smartsheet REST API method: GET /sheets/{sheetId}/discussions/{discussionId}</para>
		/// </summary>
		/// <param name="sheetId"> the Id of the sheet </param>
		/// <param name="discussionId"> the ID of the discussion </param>
		/// <returns> the discussion </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual Discussion GetDiscussion(long sheetId, long discussionId)
		{
			return this.GetResource<Discussion>("sheets/" + sheetId + "/discussions/" + discussionId, typeof(Discussion));
		}

		/// <summary>
		/// <para>Return the DiscussionAttachmentResources object that provides access
		/// To Attachment resources associated with Discussion resources.</para>
		/// </summary>
		/// <returns> the attachment resources object </returns>
		public virtual DiscussionAttachmentResources AttachmentResources
		{
			get
			{
				return this.attachments;
			}
		}

		/// <summary>
		/// <para>Return the DiscussionCommentResources object that provides access
		/// To Comment resources associated with Discussion resources.</para>
		/// </summary>
		/// <returns> the comment resources object </returns>
		public virtual DiscussionCommentResources CommentResources
		{
			get
			{
				return this.comments;
			}
		}
	}
}