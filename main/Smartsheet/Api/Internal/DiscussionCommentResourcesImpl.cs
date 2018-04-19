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
using System;

namespace Smartsheet.Api.Internal
{
	public class DiscussionCommentResourcesImpl : AbstractResources, DiscussionCommentResources
	{
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="smartsheet"> the Smartsheet </param>
        /// <exception cref="InvalidOperationException">if any argument is null</exception>
        public DiscussionCommentResourcesImpl(SmartsheetImpl smartsheet)
			: base(smartsheet)
		{
		}

		/// <summary>
		/// <para>Adds a Comment to a Discussion.</para>
		/// <para>It mirrors to the following Smartsheet REST API method: POST /sheets/{sheetId}/discussions/{discussionId}/comments</para>
		/// </summary>
		/// <param name="sheetId"> the id of the sheet </param>
		/// <param name="discussionId"> the id of the discussion </param>
		/// <param name="comment"> Comment object </param>
		/// <returns> the created comment </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual Comment AddComment(long sheetId, long discussionId, Comment comment)
		{
			return this.CreateResource("sheets/" + sheetId + "/discussions/" + discussionId + "/comments", typeof(Comment), comment);
		}

		/// <summary>
		/// <para>Adds a Comment attached with an Attachment to a Discussion.</para>
		/// <para>It mirrors to the following Smartsheet REST API method: POST /sheets/{sheetId}/discussions/{discussionId}/comments</para>
		/// </summary>
		/// <param name="sheetId"> the id of the sheet </param>
		/// <param name="discussionId"> the id of the discussion </param>
		/// <param name="comment"> Comment object </param>
		/// <param name="file"> the file path </param>
		/// <param name="fileType"> the file type </param>
		/// <returns> the created comment </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual Comment AddCommentWithAttachment(long sheetId, long discussionId, Comment comment, string file, string fileType)
		{
			return this.CreateResourceWithAttachment("sheets/" + sheetId + "/discussions/" + discussionId + "/comments", comment, "comment", file, fileType);
		}

		/// <summary>
		/// <para>Update the specified comment.</para>
		/// <para>It mirrors to the following Smartsheet REST API method: PUT /sheets/{sheetId}/comments/{commentId}</para>
		/// </summary>
		/// <param name="sheetId"> the id of the sheet </param>
		/// <param name="comment"> Comment object </param>
		/// <returns> the updated comment </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual Comment UpdateComment(long sheetId, Comment comment)
		{
			return this.UpdateResource<Comment>("sheets/" + sheetId + "/comments/" + comment.Id, typeof(Comment), comment);
		}
	}
}
