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

using System;
using System.Collections.Generic;

namespace Smartsheet.Api.Models
{

	/// <summary>
	/// Represents the Discussion object. </summary>
	/// <seealso href="http://help.Smartsheet.com/customer/portal/articles/504767-using-Discussions">Help Using Discussions</seealso>
	public class Discussion : IdentifiableModel
	{
		/// <summary>
		/// Represents the Title for the discussion. </summary>
		private string title;

		/// <summary>
		/// Represents the Comments for the discussion. </summary>
		private IList<Comment> comments;
		private Comment comment;

		/// <summary>
		/// Represents the Comment Attachments. </summary>
		private IList<Attachment> commentAttachments;

		/// <summary>
		/// Represents the date a Comment was last added To a discussion. </summary>
		private DateTime? lastCommentedAt;

		/// <summary>
		/// Represents the last user that left a Comment in the discussion. </summary>
		private User lastCommentedUser;

		private AccessLevel? accessLevel;

		private long? parentId;

		private DiscussionParentType? parentType;

		private User createdBy;

		private bool? readOnly;


		/// <summary>
		/// the Title for the discussion.
		/// </summary>
		/// <returns> the Title </returns>
		public virtual string Title
		{
			get
			{
				return title;
			}
			set
			{
				this.title = value;
			}
		}


		/// <summary>
		/// The Comments for the discussion.
		/// </summary>
		/// <returns> the Comments </returns>
		public virtual IList<Comment> Comments
		{
			get
			{
				return comments;
			}
			set
			{
				this.comments = value;
			}
		}

		/// <summary>
		/// The Comment for the discussion.
		/// </summary>
		/// <returns> the Comment </returns>
		public virtual Comment Comment
		{
			get
			{
				return comment;
			}
			set
			{
				// To keep the Comments variable in sync
				IList<Comment> comments = new List<Comment>();
				comments.Add(value);
				this.comments = comments;

				this.comment = value;
			}
		}

		/// <summary>
		/// The Comment Attachments.
		/// </summary>
		/// <returns> the Comment Attachments </returns>
		public virtual IList<Attachment> CommentAttachments
		{
			get
			{
				return commentAttachments;
			}
			set
			{
				this.commentAttachments = value;
			}
		}


		/// <summary>
		/// Time of most recent comment
		/// </summary>
		/// <returns> the last commented at </returns>
		public virtual DateTime? LastCommentedAt
		{
			get
			{
				return lastCommentedAt;
			}
			set
			{
				this.lastCommentedAt = value;
			}
		}


		/// <summary>
		/// User object containing name and email of the author of the most recent Comment
		/// </summary>
		/// <returns> the last commented user </returns>
		public virtual User LastCommentedUser
		{
			get
			{
				return lastCommentedUser;
			}
			set
			{
				this.lastCommentedUser = value;
			}
		}


		/// <summary>
		/// User's permissions on the Discussion
		/// </summary>
		/// <returns> the access level </returns>
		public virtual AccessLevel? AccessLevel
		{
			get
			{
				return accessLevel;
			}
			set
			{
				this.accessLevel = value;
			}
		}

		/// <summary>
		/// ID of the directly associated row or sheet: present only when the direct association is not clear (see Get All Discussions)
		/// </summary>
		public long? ParentId
		{
			get { return parentId; }
			set { parentId = value; }
		}

		/// <summary>
		/// "SHEET" or "ROW": present only when the direct association is not clear (see Get All Discussions)
		/// </summary>
		public virtual DiscussionParentType? ParentType
		{
			get { return parentType; }
			set { parentType = value; }
		}

		/// <summary>
		/// User object containing name and email of the creator of the Discussion
		/// </summary>
		public virtual User CreatedBy
		{
			get { return createdBy; }
			set { createdBy = value; }
		}

		/// <summary>
		/// Flag to indicate if the User can modify the Discussion
		/// </summary>
		public bool? ReadOnly
		{
			get { return readOnly; }
			set { readOnly = value; }
		}


		/// <summary>
		/// A convenience class To help generate discussion object with the appropriate fields for adding a discussion To 
		/// a sheet or row.
		/// </summary>
		public class CreateDiscussionBuilder
		{
			private string title;
			private Comment comment;

			/// <summary>
			/// Sets the required properties for creating a Discussion.
			/// </summary>
			/// <param name="title"> the Discussion title </param>
			/// <param name="comment"> the Comment of the Discussion </param>
			public CreateDiscussionBuilder(string title, Comment comment)
			{
				this.title = title;
				this.comment = comment;
			}

			/// <summary>
			/// Sets the Title for the discussion.
			/// </summary>
			/// <param name="title"> the Title </param>
			/// <returns> the creates the discussion builder </returns>
			public virtual CreateDiscussionBuilder SetTitle(string title)
			{
				this.title = title;
				return this;
			}

			/// <summary>
			/// Sets the Comments for the discussion.
			/// </summary>
			/// <param name="comment"> the Comments </param>
			/// <returns> the creates the discussion builder </returns>
			public virtual CreateDiscussionBuilder SetComment(Comment comment)
			{
				this.comment = comment;
				return this;
			}

			/// <summary>
			/// Gets the Title.
			/// </summary>
			/// <returns> the Title </returns>
			public virtual string GetTitle()
			{
				return title;
			}

			/// <summary>
			/// Gets the Comments.
			/// </summary>
			/// <returns> the Comments </returns>
			public virtual Comment GetComment()
			{
				return comment;
			}

			/// <summary>
			/// Builds the.
			/// </summary>
			/// <returns> the discussion </returns>
			public virtual Discussion Build()
			{
				//if (title == null || comment == null)
				//{
				//	throw new MemberAccessException("A title and comment is required.");
				//}

				Discussion discussion = new Discussion();
				discussion.title = title;
				discussion.comment = comment;
				return discussion;
			}
		}
	}

}