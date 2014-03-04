using System;
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
	/// Represents a Share Object. </summary>
	/// <seealso cref= <a href="http://help.smartsheet.com/customer/portal/articles/520104-sharing-sheets">Sharing Sheets</a> </seealso>
	public class Share : NamedModel
	{
		/// <summary>
		/// Represents the access level for this specific share.
		/// </summary>
		private AccessLevel? accessLevel_Renamed;

		/// <summary>
		/// Represents the email for this specific share.
		/// </summary>
		private string email_Renamed;

		/// <summary>
		/// Gets the access level for this specific share.
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
		/// Gets the email for this specific share.
		/// </summary>
		/// <returns> the email </returns>
		public virtual string email
		{
			get
			{
				return email_Renamed;
			}
			set
			{
				this.email_Renamed = value;
			}
		}


		/// <summary>
		/// A convenience class for creating a <seealso cref="Share"/> with the necessary fields for sharing the sheet to one user.
		/// </summary>
		public class ShareToOneBuilder
		{
			internal AccessLevel? accessLevel_Renamed;
			internal string email_Renamed;

			/// <summary>
			/// Access level for this specific share.
			/// </summary>
			/// <param name="accessLevel"> the access level </param>
			/// <returns> the share to one builder </returns>
			public virtual ShareToOneBuilder SetAccessLevel(AccessLevel? accessLevel)
			{
				this.accessLevel_Renamed = accessLevel;
				return this;
			}

			/// <summary>
			/// Email address for this specific share.
			/// </summary>
			/// <param name="email"> the email </param>
			/// <returns> the share to one builder </returns>
			public virtual ShareToOneBuilder SetEmail(string email)
			{
				this.email_Renamed = email;
				return this;
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
			/// Gets the email.
			/// </summary>
			/// <returns> the email </returns>
			public virtual string email
			{
				get
				{
					return email_Renamed;
				}
			}

			/// <summary>
			/// Builds the <seealso cref="Share"/> object.
			/// </summary>
			/// <returns> the share </returns>
			public virtual Share Build()
			{
				if (email_Renamed == null || accessLevel_Renamed == null)
				{
					throw new InvalidOperationException("The email and accessLevel are required.");
				}

				Share share = new Share();
				share.accessLevel_Renamed = accessLevel_Renamed;
				share.email_Renamed = email_Renamed;

				return share;
			}
		}

		/// <summary>
		/// A convenience class for creating a <seealso cref="Share"/> with the necessary fields to update a specific share.
		/// </summary>
		public class UpdateShareBuilder
		{
			internal AccessLevel? accessLevel_Renamed;

			/// <summary>
			/// Access level for the share.
			/// </summary>
			/// <param name="accessLevel"> the access level </param>
			/// <returns> the update share builder </returns>
			public virtual UpdateShareBuilder SetAccessLevel(AccessLevel? accessLevel)
			{
				this.accessLevel_Renamed = accessLevel;
				return this;
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
			/// Builds the <seealso cref="Share"/> object.
			/// </summary>
			/// <returns> the share </returns>
			public virtual Share Build()
			{
				if (accessLevel_Renamed == null)
				{
					throw new InvalidOperationException("The access level must be specified.");
				}

				Share share = new Share();
				share.accessLevel_Renamed = accessLevel_Renamed;
				return share;
			}
		}
	}

}