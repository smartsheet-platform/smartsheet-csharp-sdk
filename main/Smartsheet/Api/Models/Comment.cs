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

        ///// <summary>
        ///// Represents the date the Comment was modified. </summary>
        //private DateTime? modifiedDate;

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
        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        /// <summary>
        /// Gets user that created the Comment.
        /// </summary>
        /// <returns> the created by </returns>
        public User CreatedBy
        {
            get { return createdBy; }
            set { createdBy = value; }
        }

        /// <summary>
        /// Gets the Comment Attachments.
        /// </summary>
        /// <returns> the Attachments </returns>
        public IList<Attachment> Attachments
        {
            get { return attachments; }
            set { attachments = value; }
        }

        /// <summary>
        /// Gets the discussion Id.
        /// </summary>
        /// <returns> the discussion Id </returns>
        public long? DiscussionId
        {
            get { return discussionId; }
            set { discussionId = value; }
        }

        /// <summary>
        /// Gets the date the Comment was created.
        /// </summary>
        /// <returns> the created at </returns>
        public DateTime? CreatedAt
        {
            get { return createdAt; }
            set { createdAt = value; }
        }

        /// <summary>
        /// Gets the date the Comment was modified.
        /// </summary>
        /// <returns> the modified at </returns>
        public DateTime? ModifiedAt
        {
            get { return modifiedAt; }
            set { modifiedAt = value; }
        }

        /// <summary>
        /// A convenience class to generate a Comment with the appropriate fields for adding it to a sheet.
        /// </summary>
        public class AddCommentBuilder
        {
            public AddCommentBuilder(string text)
            {
                this.text = text;
            }

            /// <summary>
            /// The Text. </summary>
            internal string text;

            /// <summary>
            /// The Text for the Comment.
            /// </summary>
            /// <param name="text"> the Text </param>
            /// <returns> the adds the Comment builder </returns>
            public AddCommentBuilder SetText(string text)
            {
                this.text = text;
                return this;
            }

            /// <summary>
            /// Gets the Text for the Comment. </summary>
            /// <returns> the Text </returns>
            public string Text
            {
                get { return text; }
            }

            /// <summary>
            /// Builds the Comment.
            /// </summary>
            /// <returns> the Comment </returns>
            public Comment Build()
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