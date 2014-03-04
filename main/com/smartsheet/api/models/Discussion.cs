using System;
using System.Collections.Generic;

namespace com.smartsheet.api.models
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


	/// <summary>
	/// Represents the Discussion object. </summary>
	/// <seealso cref= <a href="http://help.smartsheet.com/customer/portal/articles/504767-using-discussions">Help Using Discussions</a> </seealso>
	public class Discussion : IdentifiableModel
	{
		/// <summary>
		/// Represents the title for the discussion. </summary>
		private string title_Renamed;

		/// <summary>
		/// Represents the comments for the discussion. </summary>
		private IList<Comment> comments_Renamed;
		private Comment comment_Renamed;

		/// <summary>
		/// Represents the comment attachments. </summary>
		private IList<Attachment> commentAttachments_Renamed;

		/// <summary>
		/// Represents the date a comment was last added to a discussion. </summary>
		private DateTime? lastCommentedAt_Renamed;

		/// <summary>
		/// Represents the last user that left a comment in the discussion. </summary>
		private User lastCommentedUser_Renamed;

		private string accessLevel_Renamed;

		/// <summary>
		/// Gets the title for the discussion.
		/// </summary>
		/// <returns> the title </returns>
		public virtual string title
		{
			get
			{
				return title_Renamed;
			}
			set
			{
				this.title_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the comments for the discussion.
		/// </summary>
		/// <returns> the comments </returns>
		public virtual IList<Comment> comments
		{
			get
			{
				return comments_Renamed;
			}
			set
			{
				this.comments_Renamed = value;
			}
		}

		/// <summary>
		/// Gets the comment for the discussion.
		/// </summary>
		/// <returns> the comment </returns>
		public virtual Comment comment
		{
			get
			{
				return comment_Renamed;
			}
			set
			{
				// To keep the comments variable in sync
				IList<Comment> comments = new List<Comment>();
				comments.Add(value);
				this.comments_Renamed = comments;
    
				this.comment_Renamed = value;
			}
		}



		/// <summary>
		/// Gets the comment attachments.
		/// </summary>
		/// <returns> the comment attachments </returns>
		public virtual IList<Attachment> commentAttachments
		{
			get
			{
				return commentAttachments_Renamed;
			}
			set
			{
				this.commentAttachments_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the date a comment was last added to a discussion..
		/// </summary>
		/// <returns> the last commented at </returns>
		public virtual DateTime? lastCommentedAt
		{
			get
			{
				return lastCommentedAt_Renamed;
			}
			set
			{
				this.lastCommentedAt_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the user that last commented in the discussion.
		/// </summary>
		/// <returns> the last commented user </returns>
		public virtual User lastCommentedUser
		{
			get
			{
				return lastCommentedUser_Renamed;
			}
			set
			{
				this.lastCommentedUser_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the access level.
		/// </summary>
		/// <returns> the access level </returns>
		public virtual string accessLevel
		{
			get
			{
				return accessLevel_Renamed;
			}
			set
			{
				this.accessLevel_Renamed = value;
			}
		}


		/// <summary>
		/// A convenience class to help generate discussion object with the appropriate fields for adding a discussion to 
		/// a sheet.
		/// </summary>
		public class CreateDiscussionBuilder
		{
			internal string title_Renamed;
			internal Comment comment_Renamed;

			/// <summary>
			/// Sets the title for the discussion.
			/// </summary>
			/// <param name="title"> the title </param>
			/// <returns> the creates the discussion builder </returns>
			public virtual CreateDiscussionBuilder SetTitle(string title)
			{
				this.title_Renamed = title;
				return this;
			}

			/// <summary>
			/// Sets the comments for the discussion.
			/// </summary>
			/// <param name="comments"> the comments </param>
			/// <returns> the creates the discussion builder </returns>
			public virtual CreateDiscussionBuilder SetComment(Comment comment)
			{
				this.comment_Renamed = comment;
				return this;
			}

			/// <summary>
			/// Gets the title.
			/// </summary>
			/// <returns> the title </returns>
			public virtual string title
			{
				get
				{
					return title_Renamed;
				}
			}

			/// <summary>
			/// Gets the comments.
			/// </summary>
			/// <returns> the comments </returns>
			public virtual Comment comment
			{
				get
				{
					return comment_Renamed;
				}
			}

			/// <summary>
			/// Builds the.
			/// </summary>
			/// <returns> the discussion </returns>
			public virtual Discussion Build()
			{
				if (title_Renamed == null || comment_Renamed == null)
				{
					throw new MemberAccessException("A title and comment is required.");
				}

				Discussion discussion = new Discussion();
				discussion.title_Renamed = title_Renamed;
				discussion.comment_Renamed = comment_Renamed;
				return discussion;
			}
		}
	}

}