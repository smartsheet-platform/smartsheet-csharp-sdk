namespace com.smartsheet.api.@internal
{

	/*
	 * #[license]
	 * Smartsheet SDK for C#
	 * %%
	 * Copyright (C) 2014 Smartsheet
	 * %%
	 * Licensed under the Apache License, Version 2.0 (the "License");
	 * you may not use this file except in compliance with the License.
	 * You may obtain a copy of the License at
	 * 
	 *      http://www.apache.org/licenses/LICENSE-2.0
	 * 
	 * Unless required by applicable law or agreed to in writing, software
	 * distributed under the License is distributed on an "AS IS" BASIS,
	 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
	 * See the License for the specific language governing permissions and
	 * limitations under the License.
	 * %[license]
	 */



	using Comment = com.smartsheet.api.models.Comment;
	using Discussion = com.smartsheet.api.models.Discussion;

	/// <summary>
	/// This is the implementation of the DiscussionResources.
	/// 
	/// Thread Safety: This class is thread safe because it is immutable and its base class is thread safe.
	/// </summary>
	public class DiscussionResourcesImpl : AbstractResources, DiscussionResources
	{
		/// <summary>
		/// Represents the AssociatedAttachmentResources.
		/// 
		/// It will be initialized in constructor and will not change afterwards.
		/// </summary>
		private AssociatedAttachmentResources attachments;

		/// <summary>
		/// Constructor.
		/// 
		/// Exceptions: - IllegalArgumentException : if any argument is null
		/// </summary>
		/// <param name="smartsheet"> the smartsheet </param>
		public DiscussionResourcesImpl(SmartsheetImpl smartsheet) : base(smartsheet)
		{
		}

		/// <summary>
		/// Get a discussion.
		/// 
		/// It mirrors to the following Smartsheet REST API method: GET /discussion/{id}
		/// 
		/// Parameters: - id : the ID
		/// 
		/// Returns: the resource (note that if there is no such resource, this method will throw ResourceNotFoundException
		/// rather than returning null).
		/// 
		/// Exceptions:
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ResourceNotFoundException : if the resource can not be found
		///   ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="id"> the id </param>
		/// <returns> the discussion </returns>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		public virtual Discussion GetDiscussion(long id)
		{
			return this.GetResource<Discussion>("discussion/" + id, typeof(Discussion));
		}

		/// <summary>
		/// Add a comment to a discussion.
		/// 
		/// It mirrors to the following Smartsheet REST API method: POST /discussion/{discussionId}/comments
		/// 
		/// Exceptions:
		///   IllegalArgumentException : if any argument is null
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="id"> the discussion ID </param>
		/// <param name="comment"> the comment to add, limited to the following required attributes: text </param>
		/// <returns> the created comment </returns>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		public virtual Comment AddDiscussionComment(long id, Comment comment)
		{
			return this.CreateResource("discussion/" + id + "/comments", typeof(Comment), comment);
		}

		/// <summary>
		/// Return the AssociatedAttachmentResources object that provides access to attachment resources associated with
		/// Discussion resources.
		/// </summary>
		/// <returns> the associated attachment resources </returns>
		public virtual AssociatedAttachmentResources Attachments()
		{
			return this.attachments;
		}
	}

}