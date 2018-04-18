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
		/// Represents the title for the discussion. </summary>
		private string title;

		/// <summary>
		/// Represents the comments for the discussion. </summary>
		private IList<Comment> comments;

		/// <summary>
		/// Represents the comment for the discussion (outbound only - singular "comment") </summary>
		private Comment comment;

		/// <summary>
		/// Represents the comment attachments. </summary>
		private IList<Attachment> commentAttachments;

		/// <summary>
		/// The number of comments in the discussion
		/// </summary>
		private int? commentCount;

		/// <summary>
		/// Represents the date a comment was last added to a discussion. </summary>
		private DateTime? lastCommentedAt;

		/// <summary>
		/// Represents the last user that left a comment in the discussion. </summary>
		private User lastCommentedUser;

		/// <summary>
		/// Users permission on the discussion </summary>
		private AccessLevel? accessLevel;

		/// <summary>
		/// Represents the Id of the directly associated row or sheet </summary>
		private long? parentId;

		/// <summary>
		/// Represents the "SHEET" or "ROW": present only when the direct association is not clear </summary>
		private DiscussionParentType? parentType;

		/// <summary>
		/// Represents the User object containing name and email of the creator of the discussion </summary>
		private User createdBy;

		/// <summary>
		/// Represents the read only status of the discussion </summary>
		private bool? readOnly;


		/// <summary>
		/// the title for the discussion.
		/// </summary>
		/// <returns> the title </returns>
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
		/// The comments for the discussion.
		/// </summary>
		/// <returns> the comments </returns>
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
		/// The comment for the discussion.
		/// </summary>
		/// <returns> the comment </returns>
		public virtual Comment Comment
		{
			get
			{
				return comment;
			}
			set
			{
				this.comment = value;
			}
		}

		/// <summary>
		/// The comment attachments.
		/// </summary>
		/// <returns> the comment attachments </returns>
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
		/// Get the number of comments in the discussion
		/// </summary>
		public virtual int? CommentCount
		{
			get
			{
				return commentCount;
			}
			set
			{
				this.commentCount = value;
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
		/// User object containing name and email of the author of the most recent comment
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
		/// User's permissions on the discussion
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
		/// Id of the directly associated row or sheet: present only when the direct association is not clear (see Get All Discussions)
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
		/// User object containing name and email of the creator of the discussion
		/// </summary>
		public virtual User CreatedBy
		{
			get { return createdBy; }
			set { createdBy = value; }
		}

		/// <summary>
		/// Indicates whether the user can modify the discussion
		/// </summary>
		public bool? ReadOnly
		{
			get { return readOnly; }
			set { readOnly = value; }
		}


		/// <summary>
		/// A convenience class to help generate discussion object with the appropriate fields for adding a discussion to 
		/// a sheet or row.
		/// </summary>
		public class CreateDiscussionBuilder
		{
			private string title;
			private Comment comment;

			/// <summary>
			/// Sets the required properties for creating a discussion.
			/// </summary>
			/// <param name="title"> the discussion title </param>
			/// <param name="comment"> the comment of the discussion </param>
			public CreateDiscussionBuilder(string title, Comment comment)
			{
				this.title = title;
				this.comment = comment;
			}

			/// <summary>
			/// Sets the title for the discussion.
			/// </summary>
			/// <param name="title"> the title </param>
			/// <returns> the creates the discussion builder </returns>
			public virtual CreateDiscussionBuilder SetTitle(string title)
			{
				this.title = title;
				return this;
			}

			/// <summary>
			/// Sets the comments for the discussion.
			/// </summary>
			/// <param name="comment"> the comments </param>
			/// <returns> the creates the discussion builder </returns>
			public virtual CreateDiscussionBuilder SetComment(Comment comment)
			{
				this.comment = comment;
				return this;
			}

			/// <summary>
			/// Gets the title.
			/// </summary>
			/// <returns> the title </returns>
			public virtual string GetTitle()
			{
				return title;
			}

			/// <summary>
			/// Gets the comments.
			/// </summary>
			/// <returns> the comments </returns>
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
				Discussion discussion = new Discussion();
				discussion.title = title;
				discussion.comment = comment;
				return discussion;
			}
		}
	}
}
