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
	/// Represents the MultiShare object. </summary>
	/// <seealso href="http://help.Smartsheet.com/customer/portal/articles/520104-sharing-Sheets">Help Sharing Sheets</seealso>
	public class MultiShare
	{
		/// <summary>
		/// The list of Users that will be shared with. The Email address must be defined for each user. </summary>
		private IList<User> users;

		/// <summary>
		/// Represents the access level for this share. </summary>
		private AccessLevel? accessLevel;

		/// <summary>
		/// The Subject of the Email that sent to notify the Users. </summary>
		private string subject;

		/// <summary>
		/// The Message to be included in the body of the Email that will be sent to the user. </summary>
		private string message;

		/// <summary>
		/// A flag to indicate whether or not to carbon copy the user sharing the sheet. </summary>
		private bool? ccMe;

		/// <summary>
		/// Gets the Users.
		/// </summary>
		/// <returns> the Users </returns>
		public virtual IList<User> Users
		{
			get
			{
				return users;
			}
			set
			{
				this.users = value;
			}
		}


		/// <summary>
		/// Gets the access level.
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
		/// Gets the Subject of the Email that sent to notify the Users.
		/// </summary>
		/// <returns> the Subject </returns>
		public virtual string Subject
		{
			get
			{
				return subject;
			}
			set
			{
				this.subject = value;
			}
		}


		/// <summary>
		/// Gets the Message to be included in the body of the Email that will be sent to the use.
		/// </summary>
		/// <returns> the Message </returns>
		public virtual string Message
		{
			get
			{
				return message;
			}
			set
			{
				this.message = value;
			}
		}


		/// <summary>
		/// Gets the flag to indicate whether or not to carbon copy the user sharing the sheet.
		/// </summary>
		/// <returns> the carbon copy me flag </returns>
		public virtual bool? CCMe
		{
			get
			{
				return ccMe;
			}
			set
			{
				this.ccMe = value;
			}
		}


		/// <summary>
		/// A convenience class for creating a MultiShare object with the necessary fields for sharing a sheet with
		/// many Users.
		/// </summary>
		public class ShareToManyBuilder
		{
			internal IList<User> users;
			internal AccessLevel? accessLevel;
			internal string subject;
			internal string message;
			internal bool? ccMe;

			/// <summary>
			/// Sets the Users that will be shared with. The Email address must be defined for each user.
			/// </summary>
			/// <param name="users"> the Users </param>
			/// <returns> the share to many builder </returns>
			public virtual ShareToManyBuilder SetUsers(IList<User> users)
			{
				this.users = users;
				return this;
			}

			/// <summary>
			/// Sets the access level.
			/// </summary>
			/// <param name="accessLevel"> the access level </param>
			/// <returns> the share to many builder </returns>
			public virtual ShareToManyBuilder SetAccessLevel(AccessLevel? accessLevel)
			{
				this.accessLevel = accessLevel;
				return this;
			}

			/// <summary>
			/// Sets the Subject of the Email that sent to notify the Users.
			/// </summary>
			/// <param name="subject"> the Subject </param>
			/// <returns> the share to many builder </returns>
			public virtual ShareToManyBuilder SetSubject(string subject)
			{
				this.subject = subject;
				return this;
			}

			/// <summary>
			/// Sets the Message to be included in the body of the Email that will be sent to the use.
			/// </summary>
			/// <param name="message"> the Message </param>
			/// <returns> the share to many builder </returns>
			public virtual ShareToManyBuilder SetMessage(string message)
			{
				this.message = message;
				return this;
			}

			/// <summary>
			/// Set the carbon copy me flag.
			/// </summary>
			/// <param name="ccMe"> the carbon copy me flag. </param>
			/// <returns> the share to many builder </returns>
			public virtual ShareToManyBuilder SetCCMe(bool? ccMe)
			{
				this.ccMe = ccMe;
				return this;
			}

			/// <summary>
			/// Gets the Users.
			/// </summary>
			/// <returns> the Users </returns>
			public virtual IList<User> Users
			{
				get
				{
					return users;
				}
			}

			/// <summary>
			/// Gets the access level.
			/// </summary>
			/// <returns> the access level </returns>
			public virtual AccessLevel? AccessLevel
			{
				get
				{
					return accessLevel;
				}
			}

			/// <summary>
			/// Gets the Subject.
			/// </summary>
			/// <returns> the Subject </returns>
			public virtual string Subject
			{
				get
				{
					return subject;
				}
			}

			/// <summary>
			/// Gets the Message.
			/// </summary>
			/// <returns> the Message </returns>
			public virtual string Message
			{
				get
				{
					return message;
				}
			}

			/// <summary>
			/// Gets the cc me.
			/// </summary>
			/// <returns> the cc me </returns>
			public virtual bool? CCMe
			{
				get
				{
					return ccMe;
				}
			}

			/// <summary>
			/// Builds the Multishare object with the set fields.
			/// </summary>
			/// <returns> the multi share </returns>
			public virtual MultiShare Build()
			{
				if (users == null || accessLevel == null)
				{
					throw new MemberAccessException("A user, access level and message are required.");
				}

				MultiShare multiShare = new MultiShare();
				multiShare.users = users;
				multiShare.accessLevel = accessLevel;
				multiShare.subject = subject;
				multiShare.message = message;
				multiShare.ccMe = ccMe;
				return multiShare;
			}
		}
	}

}