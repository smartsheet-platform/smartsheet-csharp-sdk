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
    /// Represents a Share Object. </summary>
    /// <seealso href="http://help.Smartsheet.com/customer/portal/articles/520104-sharing-Sheets">Sharing Sheets</seealso>
    public class Share : NamedModel
    {
        //Since ID is alphanumeric.
        // We can either overide the ID of the NamedModel interface. 
        //Or
        // Update IdentifiableModel to IdentifiableModel<T> to accept either a long or string type.
        //For now, we are overiding ID.
        private string id;

        /// <summary>
        /// Indicates what type of share this is
        /// </summary>
        private ShareType? type;

        /// <summary>
        /// Represents the userId if the share is of type USER
        /// </summary>
        private long? userId;

        /// <summary>
        /// Represents the groupId if the share is of type GROUP
        /// </summary>
        private long? groupId;

        /// <summary>
        /// Represents the subject of the email that will optionally be sent to notify the recipient
        /// </summary>
        private string subject;

        /// <summary>
        /// Represents the message to be included in the body of the email
        /// </summary>
        private string message;

        /// <summary>
        /// Represents the flag to indicate whether or not to send a copy of the email to the sharer
        /// </summary>
        private bool? ccMe;

        /// <summary>
        /// Represents the access level for this specific share.
        /// </summary>
        private AccessLevel? accessLevel;

        /// <summary>
        /// The scope of this share. One of the following values:
        ///        ITEM: an item-level share (i.e., the specific object to which the Share applies is shared with the user or group)
        ///        WORKSPACE: a workspace-level share (i.e., the workspace that contains the object to which the Share applies is shared with the user or group)
        /// </summary>
        private string scope;

        /// <summary>
        /// Time that the share was created.
        /// </summary>
        private DateTime? createdAt;

        /// <summary>
        /// Time that the share was modified.
        /// </summary>
        private DateTime? modifiedAt;

        /// <summary>
        /// Represents the Email for this specific share.
        /// </summary>
        private string email;

        /// <summary>
        /// Gets the access level for this specific share.
        /// </summary>
        /// <returns> the access level </returns>
        public virtual AccessLevel? AccessLevel
        {
            get { return accessLevel; }
            set { this.accessLevel = value; }
        }

        /// <summary>
        /// Gets the Email for this specific share.
        /// </summary>
        /// <returns> the Email </returns>
        public virtual string Email
        {
            get { return email; }
            set { this.email = value; }
        }

        /// <summary>
        /// Share ID, unlike other Smartsheet object ids, this id is an alphanumeric string.
        /// </summary>
        public virtual new string Id
        {
            // This should hide inherited member "Id".
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// The type of this share. One of USER or GROUP.
        /// </summary>
        public ShareType? Type
        {
            get { return type; }
            set { type = value; }
        }

        /// <summary>
        /// User ID if the share is a user share, else null.
        /// </summary>
        public long? UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        /// <summary>
        /// Group ID if the share is a group share, else null.
        /// </summary>
        public long? GroupId
        {
            get { return groupId; }
            set { groupId = value; }
        }

        /// <summary>
        /// The subject of the email that will optionally be sent to notify the recipient.
        /// This attribute can be specified in a request, but will never be present in a response.
        /// </summary>
        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }

        /// <summary>
        /// The message to be included in the body of the email that will optionally be sent to the recipient.
        /// This attribute can be specified in a request, but will never be present in a response.
        /// </summary>
        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        /// <summary>
        /// Flag to indicate whether or not to send a copy of the email to the sharer of the sheet.
        /// This attribute can be specified in a request, but will never be present in a response.
        /// </summary>
        public bool? CcMe
        {
            get { return ccMe; }
            set { ccMe = value; }
        }

        /// <summary>
        /// The scop of this share. One of ITEM or WORKSPACE.
        /// </summary>
        public string Scope
        {
            get { return scope; }
            set { scope = value; }
        }

        /// <summary>
        /// Gets the Time that the share was created.
        /// </summary>
        /// <returns> the DateTime </returns>
        public virtual DateTime? CreatedAt
        {
            get { return createdAt;    }
            set { this.createdAt = value; }
        }

        /// <summary>
        /// Gets the time that the share was modified.
        /// </summary>
        /// <returns> the DateTime </returns>
        public virtual DateTime? ModifiedAt
        {
            get { return modifiedAt; }
            set { this.modifiedAt = value; }
        }

        /// <summary>
        /// A convenience class for creating a <seealso cref="Share"/> with the necessary fields for sharing the sheet to one user.
        /// </summary>
        public class CreateShareBuilder
        {
            private AccessLevel? accessLevel;
            private string email;
            private long? groupId;
            private string subject;
            private string message;
            private bool? ccMe;

            /// <summary>
            /// Sets the required properties for sharing to a User.
            /// </summary>
            /// <param name="email">the email of the User</param>
            /// <param name="accessLevel">the Access Level</param>
            public CreateShareBuilder(string email, AccessLevel? accessLevel)
            {
                this.email = email;
                this.accessLevel = accessLevel;
            }
            
            /// <summary>
            /// Sets the required properties for sharing to a Group.
            /// </summary>
            /// <param name="groupId">the group ID</param>
            /// <param name="accessLevel">the Access Level</param>
            public CreateShareBuilder(long? groupId, AccessLevel? accessLevel)
            {
                this.groupId = groupId;
                this.accessLevel = accessLevel;
            }

            /// <summary>
            /// (required) Access level for this specific share.
            /// </summary>
            /// <param name="accessLevel"> the access level </param>
            /// <returns> the share to one builder </returns>
            public virtual CreateShareBuilder SetAccessLevel(AccessLevel? accessLevel)
            {
                this.accessLevel = accessLevel;
                return this;
            }

            /// <summary>
            ///  (optional) Email address for this specific share.
            ///  NOTE: One of email or groupId must be specified, but not both.
            /// </summary>
            /// <param name="email"> the Email </param>
            /// <returns> the share to one builder </returns>
            public virtual CreateShareBuilder SetEmail(string email)
            {
                this.email = email;
                return this;
            }

            /// <summary>
            /// the group share recipient’s group ID.
            /// NOTE: One of email or groupId must be specified, but not both.
            /// </summary>
            /// <param name="groupId"> the groupId </param>
            /// <returns> the share to one builder </returns>
            public virtual CreateShareBuilder SetGroupId(long? groupId)
            {
                this.groupId = groupId;
                return this;
            }

            /// <summary>
            /// (optional): The subject of the email that will optionally be sent to notify the recipient.
            /// </summary>
            /// <param name="subject"> the subject </param>
            /// <returns> the share to one builder </returns>
            public virtual CreateShareBuilder SetSubject(string subject)
            {
                this.subject = subject;
                return this;
            }

            /// <summary>
            /// (optional): The message to be included in the body of the email that will optionally be sent to the recipient.
            /// </summary>
            /// <param name="message"> the message </param>
            /// <returns> the share to one builder </returns>
            public virtual CreateShareBuilder SetAccessLevel(string message)
            {
                this.message = message;
                return this;
            }

            /// <summary>
            /// (optional): Boolean flag to indicate whether or not to CC the user sharing the sheet.
            /// </summary>
            /// <param name="ccMe"> the ccMe </param>
            /// <returns> the share to one builder </returns>
            public virtual CreateShareBuilder SetCcMe(bool? ccMe)
            {
                this.ccMe = ccMe;
                return this;
            }

            /// <summary>
            /// Gets the access level.
            /// </summary>
            /// <returns> the access level </returns>
            public virtual AccessLevel? GetAccessLevel()
            {
                return accessLevel;
            }

            /// <summary>
            /// Gets the Email.
            /// </summary>
            /// <returns> the Email </returns>
            public virtual string GetEmail()
            {
                return email;
            }

            /// <summary>
            /// Gets the GroupId.
            /// </summary>
            /// <returns> the GroupId </returns>
            public virtual long? GetGroupId()
            {
                return groupId;
            }

            /// <summary>
            /// Gets the Subject.
            /// </summary>
            /// <returns> the Subject </returns>
            public virtual string GetSubject()
            {
                return subject;
            }

            /// <summary>
            /// Gets the Message.
            /// </summary>
            /// <returns> the Message </returns>
            public virtual string GetMessage()
            {
                return message;
            }

            /// <summary>
            /// Gets the CcMe.
            /// </summary>
            /// <returns> the CcMe </returns>
            public virtual bool? GetCcMe()
            {
                return ccMe;
            }

            /// <summary>
            /// Builds the <seealso cref="Share"/> object.
            /// </summary>
            /// <returns> the share </returns>
            public virtual Share Build()
            {
                return new Share()
                {
                    AccessLevel = accessLevel,
                    Email = email,
                    GroupId = groupId,
                    Subject = subject,
                    Message = message,
                    CcMe = ccMe
                };
            }
        }

        /// <summary>
        /// A convenience class for creating a <seealso cref="Share"/> with the necessary fields to update a specific share.
        /// </summary>
        public class UpdateShareBuilder
        {
            private string shareId;
            private AccessLevel? accessLevel;

            /// <summary>
            /// Sets the required properties for updating a share object.
            /// </summary>
            /// <param name="shareId">the share Id</param>
            /// <param name="accessLevel">the Access Level</param>
            public UpdateShareBuilder(string shareId, AccessLevel? accessLevel)
            {
                this.shareId = shareId;
                this.accessLevel = accessLevel;
            }

            /// <summary>
            /// Access level for the share.
            /// </summary>
            /// <param name="accessLevel"> the access level </param>
            /// <returns> the update share builder </returns>
            public virtual UpdateShareBuilder SetAccessLevel(AccessLevel? accessLevel)
            {
                this.accessLevel = accessLevel;
                return this;
            }

            /// <summary>
            /// Gets the access level.
            /// </summary>
            /// <returns> the access level </returns>
            public virtual AccessLevel? GetAccessLevel()
            {
                return accessLevel;
            }

            /// <summary>
            /// Builds the <seealso cref="Share"/> object.
            /// </summary>
            /// <returns> the share </returns>
            public virtual Share Build()
            {
                Share share = new Share();
                share.id = shareId;
                share.accessLevel = accessLevel;
                return share;
            }
        }
    }
}