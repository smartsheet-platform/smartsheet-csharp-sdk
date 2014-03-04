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
	/// Represents the Comment object.
	/// </summary>
	public class Comment : IdentifiableModel
	{

		/// <summary>
		/// Represents the text for the comment. </summary>
		private string text_Renamed;

		/// <summary>
		/// Represents the user that created the comment. </summary>
		private User createdBy_Renamed;

		/// <summary>
		/// Represents the date the comment was modified. </summary>
		private DateTime? modifiedDate_Renamed;

		/// <summary>
		/// Represents the attachments for the comment. </summary>
		private IList<Attachment> attachments_Renamed;

		/// <summary>
		/// Represents the discussion ID. </summary>
		private long? discussionId_Renamed;

		/// <summary>
		/// The date the comment was created. </summary>
		private DateTime? createdAt_Renamed;

		/// <summary>
		/// The date the comment was last modified. </summary>
		private DateTime? modifiedAt_Renamed;

		/// <summary>
		/// Gets the text for the comment.
		/// </summary>
		/// <returns> the text </returns>
		public virtual string text
		{
			get
			{
				return text_Renamed;
			}
			set
			{
				this.text_Renamed = value;
			}
		}


		/// <summary>
		/// Gets user that created the comment.
		/// </summary>
		/// <returns> the created by </returns>
		public virtual User createdBy
		{
			get
			{
				return createdBy_Renamed;
			}
			set
			{
				this.createdBy_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the date the comment was last modified.
		/// </summary>
		/// <returns> the modified date </returns>
		public virtual DateTime? modifiedDate
		{
			get
			{
				return modifiedDate_Renamed;
			}
			set
			{
				this.modifiedDate_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the comment attachments.
		/// </summary>
		/// <returns> the attachments </returns>
		public virtual IList<Attachment> attachments
		{
			get
			{
				return attachments_Renamed;
			}
			set
			{
				this.attachments_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the discussion id.
		/// </summary>
		/// <returns> the discussion id </returns>
		public virtual long? discussionId
		{
			get
			{
				return discussionId_Renamed;
			}
			set
			{
				this.discussionId_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the date the comment was created.
		/// </summary>
		/// <returns> the created at </returns>
		public virtual DateTime? createdAt
		{
			get
			{
				return createdAt_Renamed;
			}
			set
			{
				this.createdAt_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the date the comment was modified.
		/// </summary>
		/// <returns> the modified at </returns>
		public virtual DateTime? modifiedAt
		{
			get
			{
				return modifiedAt_Renamed;
			}
			set
			{
				this.modifiedAt_Renamed = value;
			}
		}


		/// <summary>
		/// A convenience class to generate a comment with the appropriate fields for adding it to a sheet.
		/// </summary>
		public class AddCommentBuilder
		{

			/// <summary>
			/// The text. </summary>
			internal string text_Renamed;

			/// <summary>
			/// The text for the comment.
			/// </summary>
			/// <param name="text"> the text </param>
			/// <returns> the adds the comment builder </returns>
			public virtual AddCommentBuilder SetText(string text)
			{
				this.text_Renamed = text;
				return this;
			}

			/// <summary>
			/// Gets the text for the comment. </summary>
			/// <returns> the text </returns>
			public virtual string text
			{
				get
				{
					return text_Renamed;
				}
			}

			/// <summary>
			/// Builds the comment.
			/// </summary>
			/// <returns> the comment </returns>
			public virtual Comment Build()
			{
				if (text_Renamed == null)
				{
					throw new MemberAccessException("The comment text is required.");
				}

				Comment comment = new Comment();
				comment.text_Renamed = text_Renamed;
				return comment;
			}
		}
	}

}