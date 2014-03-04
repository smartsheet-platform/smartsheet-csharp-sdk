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
	/// Represents the MultiShare object. </summary>
	/// <seealso cref= <a href="http://help.smartsheet.com/customer/portal/articles/520104-sharing-sheets">Help Sharing Sheets</a> </seealso>
	public class MultiShare
	{
		/// <summary>
		/// The list of users that will be shared with. The email address must be defined for each user. </summary>
		private IList<User> users_Renamed;

		/// <summary>
		/// Represents the access level for this share. </summary>
		private AccessLevel? accessLevel_Renamed;

		/// <summary>
		/// The subject of the email that sent to notify the users. </summary>
		private string subject_Renamed;

		/// <summary>
		/// The message to be included in the body of the email that will be sent to the user. </summary>
		private string message_Renamed;

		/// <summary>
		/// A flag to indicate whether or not to carbon copy the user sharing the sheet. </summary>
		private bool? ccMe_Renamed;

		/// <summary>
		/// Gets the users.
		/// </summary>
		/// <returns> the users </returns>
		public virtual IList<User> users
		{
			get
			{
				return users_Renamed;
			}
			set
			{
				this.users_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the access level.
		/// </summary>
		/// <returns> the access level </returns>
		public virtual AccessLevel? accessLevel
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
		/// Gets the subject of the email that sent to notify the users.
		/// </summary>
		/// <returns> the subject </returns>
		public virtual string subject
		{
			get
			{
				return subject_Renamed;
			}
			set
			{
				this.subject_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the message to be included in the body of the email that will be sent to the use.
		/// </summary>
		/// <returns> the message </returns>
		public virtual string message
		{
			get
			{
				return message_Renamed;
			}
			set
			{
				this.message_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the flag to indicate whether or not to carbon copy the user sharing the sheet.
		/// </summary>
		/// <returns> the carbon copy me flag </returns>
		public virtual bool? ccMe
		{
			get
			{
				return ccMe_Renamed;
			}
			set
			{
				this.ccMe_Renamed = value;
			}
		}


		/// <summary>
		/// A convenience class for creating a MultiShare object with the necessary fields for sharing a sheet with
		/// many users.
		/// </summary>
		public class ShareToManyBuilder
		{
			internal IList<User> users_Renamed;
			internal AccessLevel? accessLevel_Renamed;
			internal string subject_Renamed;
			internal string message_Renamed;
			internal bool? ccMe_Renamed;

			/// <summary>
			/// Sets the users that will be shared with. The email address must be defined for each user.
			/// </summary>
			/// <param name="users"> the users </param>
			/// <returns> the share to many builder </returns>
			public virtual ShareToManyBuilder SetUsers(IList<User> users)
			{
				this.users_Renamed = users;
				return this;
			}

			/// <summary>
			/// Sets the access level.
			/// </summary>
			/// <param name="accessLevel"> the access level </param>
			/// <returns> the share to many builder </returns>
			public virtual ShareToManyBuilder SetAccessLevel(AccessLevel? accessLevel)
			{
				this.accessLevel_Renamed = accessLevel;
				return this;
			}

			/// <summary>
			/// Sets the subject of the email that sent to notify the users.
			/// </summary>
			/// <param name="subject"> the subject </param>
			/// <returns> the share to many builder </returns>
			public virtual ShareToManyBuilder SetSubject(string subject)
			{
				this.subject_Renamed = subject;
				return this;
			}

			/// <summary>
			/// Sets the message to be included in the body of the email that will be sent to the use.
			/// </summary>
			/// <param name="message"> the message </param>
			/// <returns> the share to many builder </returns>
			public virtual ShareToManyBuilder SetMessage(string message)
			{
				this.message_Renamed = message;
				return this;
			}

			/// <summary>
			/// Set the carbon copy me flag.
			/// </summary>
			/// <param name="ccMe"> the carbon copy me flag. </param>
			/// <returns> the share to many builder </returns>
			public virtual ShareToManyBuilder SetCCMe(bool? ccMe)
			{
				this.ccMe_Renamed = ccMe;
				return this;
			}

			/// <summary>
			/// Gets the users.
			/// </summary>
			/// <returns> the users </returns>
			public virtual IList<User> users
			{
				get
				{
					return users_Renamed;
				}
			}

			/// <summary>
			/// Gets the access level.
			/// </summary>
			/// <returns> the access level </returns>
			public virtual AccessLevel? accessLevel
			{
				get
				{
					return accessLevel_Renamed;
				}
			}

			/// <summary>
			/// Gets the subject.
			/// </summary>
			/// <returns> the subject </returns>
			public virtual string subject
			{
				get
				{
					return subject_Renamed;
				}
			}

			/// <summary>
			/// Gets the message.
			/// </summary>
			/// <returns> the message </returns>
			public virtual string message
			{
				get
				{
					return message_Renamed;
				}
			}

			/// <summary>
			/// Gets the cc me.
			/// </summary>
			/// <returns> the cc me </returns>
			public virtual bool? ccMe
			{
				get
				{
					return ccMe_Renamed;
				}
			}

			/// <summary>
			/// Builds the Multishare object with the set fields.
			/// </summary>
			/// <returns> the multi share </returns>
			public virtual MultiShare Build()
			{
				if (users_Renamed == null || accessLevel_Renamed == null)
				{
					throw new MemberAccessException("A user, access level and message are required.");
				}

				MultiShare multiShare = new MultiShare();
				multiShare.users_Renamed = users_Renamed;
				multiShare.accessLevel_Renamed = accessLevel_Renamed;
				multiShare.subject_Renamed = subject_Renamed;
				multiShare.message_Renamed = message_Renamed;
				multiShare.ccMe_Renamed = ccMe_Renamed;
				return multiShare;
			}
		}
	}

}