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

		private ShareType type;

		private long? userId;

		private long? groupId;

		private string subject;

		private string message;

		private bool? ccMe;

		/// <summary>
		/// Represents the access level for this specific share.
		/// </summary>
		private AccessLevel? accessLevel;

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
		/// Gets the Email for this specific share.
		/// </summary>
		/// <returns> the Email </returns>
		public virtual string Email
		{
			get
			{
				return email;
			}
			set
			{
				this.email = value;
			}
		}

		/// <summary>
		/// Share ID, unlike other Smartsheet object ids, this id is an alphanumeric string.
		/// </summary>
		public virtual string Id
		{
			// This should hide inherited member "Id".
			get { return id; }
			set { id = value; }
		}

		/// <summary>
		/// The type of this share. One of USER or GROUP.
		/// </summary>
		public ShareType Type
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
		/// A convenience class for creating a <seealso cref="Share"/> with the necessary fields for sharing the sheet To one user.
		/// </summary>
		public class ShareToOneBuilder
		{
			private AccessLevel? accessLevel;
			private string email;
			private long? groupId;
			private string subject;
			private string message;
			private bool? ccMe;


			public ShareToOneBuilder(string email, AccessLevel? accessLevel)
			{
				this.email = email;
				this.accessLevel = accessLevel;
			}

			public ShareToOneBuilder(long? groupId, AccessLevel? accessLevel)
			{
				this.groupId = groupId;
				this.accessLevel = accessLevel;
			}

			/// <summary>
			/// (required) Access level for this specific share.
			/// </summary>
			/// <param name="accessLevel"> the access level </param>
			/// <returns> the share To one builder </returns>
			public virtual ShareToOneBuilder SetAccessLevel(AccessLevel? accessLevel)
			{
				this.accessLevel = accessLevel;
				return this;
			}

			/// <summary>
			///  (optional) Email address for this specific share.
			///  NOTE: One of email or groupId must be specified, but not both.
			/// </summary>
			/// <param name="email"> the Email </param>
			/// <returns> the share To one builder </returns>
			public virtual ShareToOneBuilder SetEmail(string email)
			{
				this.email = email;
				return this;
			}

			/// <summary>
			/// the group share recipient’s group ID.
			/// NOTE: One of email or groupId must be specified, but not both.
			/// </summary>
			/// <param name="groupId"> the groupId </param>
			/// <returns> the share To one builder </returns>
			public virtual ShareToOneBuilder SetGroupId(long? groupId)
			{
				this.groupId = groupId;
				return this;
			}

			/// <summary>
			/// (optional): The subject of the email that will optionally be sent to notify the recipient.
			/// </summary>
			/// <param name="subject"> the subject </param>
			/// <returns> the share To one builder </returns>
			public virtual ShareToOneBuilder SetSubject(string subject)
			{
				this.subject = subject;
				return this;
			}

			/// <summary>
			/// (optional): The message to be included in the body of the email that will optionally be sent to the recipient.
			/// </summary>
			/// <param name="message"> the message </param>
			/// <returns> the share To one builder </returns>
			public virtual ShareToOneBuilder SetAccessLevel(string message)
			{
				this.message = message;
				return this;
			}

			/// <summary>
			/// (optional): Boolean flag to indicate whether or not to CC the user sharing the sheet.
			/// </summary>
			/// <param name="ccMe"> the ccMe </param>
			/// <returns> the share To one builder </returns>
			public virtual ShareToOneBuilder SetCcMe(bool? ccMe)
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
				//if (email == null || accessLevel == null)
				//{
				//	throw new InvalidOperationException("The email and accessLevel are required.");
				//}

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
		/// A convenience class for creating a <seealso cref="Share"/> with the necessary fields To update a specific share.
		/// </summary>
		public class UpdateShareBuilder
		{
			internal AccessLevel? accessLevel;

			public UpdateShareBuilder(AccessLevel? accessLevel)
			{
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
				//if (accessLevel == null)
				//{
				//	throw new InvalidOperationException("The access level must be specified.");
				//}

				Share share = new Share();
				share.accessLevel = accessLevel;
				return share;
			}
		}
	}

}