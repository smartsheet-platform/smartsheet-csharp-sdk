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

namespace Smartsheet.Api.Models
{
    /// <summary>
    /// Represents the Attachment object. </summary>
    /// <seealso href="http://help.Smartsheet.com/customer/portal/articles/518408-uploading-Attachments">Help Uploading 
    /// Attachments</seealso>
    public class Attachment : NamedModel
    {
        /// <summary>
        /// Represents the URL.
        /// </summary>
        private string url;

        /// <summary>
        /// Represents the URL expiration time.
        /// </summary>
        private long? urlExpiresInMillis;

        /// <summary>
        /// Represents the attachment Type.
        /// </summary>
        private AttachmentType? attachmentType;

        /// <summary>
        /// Represents the attachment sub Type.
        /// </summary>
        private AttachmentSubType? attachmentSubType;

        /// <summary>
        /// Represents the creation timestamp.
        /// </summary>
        private DateTime? createdAt;

        /// <summary>
        /// Represents the MIME Type. </summary>
        private string mimeType;

        /// <summary>
        /// Represents the parent Type.
        /// </summary>
        private AttachmentParentType? parentType;

        /// <summary>
        /// Represents the parent ID. </summary>
        private long? parentId;

        /// <summary>
        /// Represents the attachment size.
        /// </summary>
        private long? sizeInKb;

        /// <summary>
        /// User object containing name and email of the creator of this attachment
        /// </summary>
        private User createdBy;

        /// <summary>
        /// attachment description
        /// </summary>
        private string description;

        /// <summary>
        /// Applicable when attaching to sheet or row only
        /// </summary>
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        /// <summary>
        /// User object containing name and email of the creator of this attachment
        /// </summary>
        public User CreatedBy
        {
            get { return createdBy; }
            set { createdBy = value; }
        }

        /// <summary>
        /// Gets the URL.
        /// </summary>
        /// <returns> The Url. </returns>
        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        /// <summary>
        /// Gets the Url expires in millis.
        /// </summary>
        /// <returns> the Url expires in millis </returns>
        public long? UrlExpiresInMillis
        {
            get { return urlExpiresInMillis; }
            set { urlExpiresInMillis = value; }
        }

        /// <summary>
        /// Gets the attachment Type.
        /// </summary>
        /// <returns> the attachment Type </returns>
        public AttachmentType? AttachmentType
        {
            get { return attachmentType; }
            set { attachmentType = value; }
        }

        /// <summary>
        /// Gets the attachment sub Type.
        /// </summary>
        /// <returns> the attachment sub Type </returns>
        public AttachmentSubType? AttachmentSubType
        {
            get { return attachmentSubType; }
            set { attachmentSubType = value; }
        }

        /// <summary>
        /// Gets the created at.
        /// </summary>
        /// <returns> the created at </returns>
        public DateTime? CreatedAt
        {
            get { return createdAt; }
            set { createdAt = value; }
        }

        /// <summary>
        /// Gets the mime Type.
        /// </summary>
        /// <returns> the mime Type </returns>
        public string MimeType
        {
            get { return mimeType; }
            set { mimeType = value; }
        }

        /// <summary>
        /// Gets the parent Type.
        /// </summary>
        /// <returns> the parent Type </returns>
        public AttachmentParentType? ParentType
        {
            get { return parentType; }
            set { parentType = value; }
        }

        /// <summary>
        /// Gets the parent Id.
        /// </summary>
        /// <returns> the parent Id </returns>
        public long? ParentId
        {
            get { return parentId; }
            set { parentId = value; }
        }

        /// <summary>
        /// Gets the size in kb.
        /// </summary>
        /// <returns> the size in kb </returns>
        public long? SizeInKb
        {
            get { return sizeInKb; }
            set { sizeInKb = value; }
        }

        /// <summary>
        /// A convenience class for quickly creating an Attachment to a URL.
        /// </summary>
        public class CreateAttachmentBuilder
        {
            private string name;
            private string description;
            private string url;
            private AttachmentType? attachmentType;
            private AttachmentSubType? attachmentSubType;

            /// <summary>
            /// Sets the required attributes for creating an Attachment.
            /// </summary>
            /// <param name="url">Attachment temporary URL (files only)</param>
            /// <param name="attachmentType">Attachment type (one of FILE, GOOGLE_DRIVE,
            /// LINK, BOX_COM, DROPBOX, or EVERNOTE)</param>
            public CreateAttachmentBuilder(string url, AttachmentType? attachmentType)
            {
                this.url = url;
                this.attachmentType = attachmentType;
            }

            /// <summary>
            /// Attachment name
            /// </summary>
            /// <param name="name">Attachment name</param>
            /// <returns> the CreateAttachmentBuilder object </returns>
            public CreateAttachmentBuilder SetName(string name)
            {
                this.name = name;
                return this;
            }

            /// <summary>
            /// Applicable when attaching to sheet or row only
            /// </summary>
            /// <param name="description"> the description </param>
            /// <returns> the CreateAttachmentBuilder object </returns>
            public CreateAttachmentBuilder SetDescription(string description)
            {
                this.description = description;
                return this;
            }

            /// <summary>
            /// Attachment temporary URL (files only)
            /// </summary>
            /// <param name="url"> the url </param>
            /// <returns> the CreateAttachmentBuilder object </returns>
            public CreateAttachmentBuilder SetUrl(string url)
            {
                this.url = url;
                return this;
            }

            /// <summary>
            /// Attachment sub type, only
            /// for GOOGLE_DRIVE type attachments; one of
            /// (DOCUMENT, SPREADSHEET, PRESENTATION, PDF, DRAWING)
            /// </summary>
            /// <param name="attachmentSubType"> the attachmentSubType </param>
            /// <returns> the CreateAttachmentBuilder object </returns>
            public CreateAttachmentBuilder SetAttachmentSubType(AttachmentSubType? attachmentSubType)
            {
                this.attachmentSubType = attachmentSubType;
                return this;
            }

            /// <summary>
            /// Returns the Attachment.
            /// </summary>
            /// <returns> the attachment </returns>
            public Attachment Build()
            {
                return new Attachment
                {
                    Name = name,
                    Description = description,
                    Url = url,
                    AttachmentType = attachmentType,
                    AttachmentSubType = attachmentSubType
                };
            }
        }
    }
}