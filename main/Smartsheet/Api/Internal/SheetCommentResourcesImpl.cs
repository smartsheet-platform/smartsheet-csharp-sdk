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
using System.Collections.Generic;

namespace Smartsheet.Api.Internal
{
	/// <summary>
	/// This is the implementation of the SheetCommentResources.
	/// Thread Safety: This class is thread safe because it is immutable and its base class is thread safe.
	/// </summary>
	public class SheetCommentResourcesImpl : AbstractResources, SheetCommentResources
	{
		private CommentAttachmentResources attachments;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="smartsheet"> the Smartsheet </param>
        /// <exception cref="InvalidOperationException">if any argument is null</exception>
        public SheetCommentResourcesImpl(SmartsheetImpl smartsheet)
			: base(smartsheet)
		{
			this.attachments = new CommentAttachmentResourcesImpl(smartsheet);
		}

		/// <summary>
		/// <para>Deletes the Comment specified in the URL.</para>
		/// <para>It mirrors to the following Smartsheet REST API method: DELETE /sheets/{sheetId}/comments/{commentId}</para>
		/// </summary>
		/// <param name="sheetId"> the sheetId </param>
		/// <param name="commentId">the commentId</param>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual void DeleteComment(long sheetId, long commentId)
		{
			this.DeleteResource<Comment>("sheets/" + sheetId + "/comments/" + commentId, typeof(Comment));
		}

		/// <summary>
		/// <para>Gets the Comment specified in the URL.</para>
		/// <para>It mirrors to the following Smartsheet REST API method: GET /sheets/{sheetId}/comments/{commentId}</para>
		/// </summary>
		/// <param name="sheetId">the id of the sheet</param>
		/// <param name="commentId">the id the of the comment</param>
		/// <returns> the comment object </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual Comment GetComment(long sheetId, long commentId)
		{
			return this.GetResource<Comment>("sheets/" + sheetId + "/comments/" + commentId, typeof(Comment));
		}

		/// <summary>
		/// Return the CommentAttachmentResources object that provides access to Attachment resources associated with Comment resources.
		/// </summary>
		/// <returns> the Attachment resources </returns>
		public virtual CommentAttachmentResources AttachmentResources
		{
			get
			{
				return this.attachments;
			}
		}
	}
}