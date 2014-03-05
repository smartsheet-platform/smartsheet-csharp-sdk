using System;
using System.Collections.Generic;

namespace Smartsheet.Api.Models
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
	 * Unless required by applicable law or agreed To in writing, software
	 * distributed under the License is distributed on an "AS IS" BASIS,
	 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
	 * See the License for the specific language governing permissions and
	 * limitations under the License.
	 * %[license]
	 */


	/// <summary>
	/// Represents the Comment object.
	/// </summary>
	public class Comment : IdentifiableModel
	{

		/// <summary>
		/// Represents the Text for the Comment. </summary>
		private string text;

		/// <summary>
		/// Represents the user that created the Comment. </summary>
		private User createdBy;

		/// <summary>
		/// Represents the date the Comment was modified. </summary>
		private DateTime? modifiedDate;

		/// <summary>
		/// Represents the Attachments for the Comment. </summary>
		private IList<Attachment> attachments;

		/// <summary>
		/// Represents the discussion ID. </summary>
		private long? discussionId;

		/// <summary>
		/// The date the Comment was created. </summary>
		private DateTime? createdAt;

		/// <summary>
		/// The date the Comment was last modified. </summary>
		private DateTime? modifiedAt;

		/// <summary>
		/// Gets the Text for the Comment.
		/// </summary>
		/// <returns> the Text </returns>
		public virtual string Text
		{
			get
			{
				return text;
			}
			set
			{
				this.text = value;
			}
		}


		/// <summary>
		/// Gets user that created the Comment.
		/// </summary>
		/// <returns> the created by </returns>
		public virtual User CreatedBy
		{
			get
			{
				return createdBy;
			}
			set
			{
				this.createdBy = value;
			}
		}


		/// <summary>
		/// Gets the date the Comment was last modified.
		/// </summary>
		/// <returns> the modified date </returns>
		public virtual DateTime? ModifiedDate
		{
			get
			{
				return modifiedDate;
			}
			set
			{
				this.modifiedDate = value;
			}
		}


		/// <summary>
		/// Gets the Comment Attachments.
		/// </summary>
		/// <returns> the Attachments </returns>
		public virtual IList<Attachment> Attachments
		{
			get
			{
				return attachments;
			}
			set
			{
				this.attachments = value;
			}
		}


		/// <summary>
		/// Gets the discussion Id.
		/// </summary>
		/// <returns> the discussion Id </returns>
		public virtual long? DiscussionId
		{
			get
			{
				return discussionId;
			}
			set
			{
				this.discussionId = value;
			}
		}


		/// <summary>
		/// Gets the date the Comment was created.
		/// </summary>
		/// <returns> the created at </returns>
		public virtual DateTime? CreatedAt
		{
			get
			{
				return createdAt;
			}
			set
			{
				this.createdAt = value;
			}
		}


		/// <summary>
		/// Gets the date the Comment was modified.
		/// </summary>
		/// <returns> the modified at </returns>
		public virtual DateTime? ModifiedAt
		{
			get
			{
				return modifiedAt;
			}
			set
			{
				this.modifiedAt = value;
			}
		}


		/// <summary>
		/// A convenience class To generate a Comment with the appropriate fields for adding it To a sheet.
		/// </summary>
		public class AddCommentBuilder
		{

			/// <summary>
			/// The Text. </summary>
			internal string text;

			/// <summary>
			/// The Text for the Comment.
			/// </summary>
			/// <param Name="Text"> the Text </param>
			/// <returns> the adds the Comment builder </returns>
			public virtual AddCommentBuilder SetText(string text)
			{
				this.text = text;
				return this;
			}

			/// <summary>
			/// Gets the Text for the Comment. </summary>
			/// <returns> the Text </returns>
			public virtual string Text
			{
				get
				{
					return text;
				}
			}

			/// <summary>
			/// Builds the Comment.
			/// </summary>
			/// <returns> the Comment </returns>
			public virtual Comment Build()
			{
				if (text == null)
				{
					throw new MemberAccessException("The comment text is required.");
				}

				Comment comment = new Comment();
				comment.text = text;
				return comment;
			}
		}
	}

}