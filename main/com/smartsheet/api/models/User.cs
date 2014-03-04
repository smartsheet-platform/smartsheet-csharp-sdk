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
	/// Represents the User object. </summary>
	/// <seealso cref= <a href="http://help.smartsheet.com/customer/portal/articles/795920-managing-users-team-enterprise-only-">Help
	/// Managing Users</a> </seealso>
	/// <seealso cref= <a href="http://help.smartsheet.com/customer/portal/articles/520100-user-types">User Types Help</a> </seealso>
	public class User : UserProfile
	{
		/// <summary>
		/// Represents the admin flag which allows managing users and accounts.
		/// </summary>
		private bool? admin_Renamed;

		/// <summary>
		/// Represents the licensed sheet creator flag which allows creating and owning sheets.
		/// </summary>
		private bool? licensedSheetCreator_Renamed;

		/// <summary>
		/// Represents the user status (active, pending, declined).
		/// </summary>
		private UserStatus? status_Renamed;

		/// <summary>
		/// Gets the admin flag which allows managing users and accounts.
		/// </summary>
		/// <returns> the admin </returns>
		public virtual bool? admin
		{
			get
			{
				return admin_Renamed;
			}
			set
			{
				this.admin_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the licensed sheet creator flag that allows creating and owning sheets.
		/// </summary>
		/// <returns> the licensed sheet creator </returns>
		public virtual bool? licensedSheetCreator
		{
			get
			{
				return licensedSheetCreator_Renamed;
			}
			set
			{
				this.licensedSheetCreator_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the status of the user (active, pending, declined).
		/// </summary>
		/// <returns> the status </returns>
		public virtual UserStatus? status
		{
			get
			{
				return status_Renamed;
			}
			set
			{
				this.status_Renamed = value;
			}
		}


		/// <summary>
		/// A convenience class for making a <seealso cref="User"/> object with the appropriate fields for adding the user.
		/// </summary>
		public class AddUserBuilder
		{
			internal bool? admin_Renamed;
			internal string emailAddress_Renamed;
			internal bool? licensedSheetCreator_Renamed;

			/// <summary>
			/// Sets the admin flag which allows managing users and accounts.
			/// </summary>
			/// <param name="admin"> the admin </param>
			/// <returns> the adds the user builder </returns>
			public virtual AddUserBuilder SetAdmin(bool? admin)
			{
				this.admin_Renamed = admin;
				return this;
			}

			/// <summary>
			/// Sets the licensed sheet creator flag that allows creating and owning sheets.
			/// </summary>
			/// <param name="licensedSheetCreator"> the licensed sheet creator </param>
			/// <returns> the adds the user builder </returns>
			public virtual AddUserBuilder SetLicensedSheetCreator(bool? licensedSheetCreator)
			{
				this.licensedSheetCreator_Renamed = licensedSheetCreator;
				return this;
			}

			/// <summary>
			/// Sets the email for the user.
			/// </summary>
			/// <param name="email"> the email </param>
			/// <returns> the adds the user builder </returns>
			public virtual AddUserBuilder SetEmail(string email)
			{
				this.emailAddress_Renamed = email;
				return this;
			}

			/// <summary>
			/// Gets the admin.
			/// </summary>
			/// <returns> the admin </returns>
			public virtual bool? admin
			{
				get
				{
					return admin_Renamed;
				}
			}

			/// <summary>
			/// Gets the email address.
			/// </summary>
			/// <returns> the email address </returns>
			public virtual string emailAddress
			{
				get
				{
					return emailAddress_Renamed;
				}
			}

			/// <summary>
			/// Gets the licensed sheet creator.
			/// </summary>
			/// <returns> the licensed sheet creator </returns>
			public virtual bool? licensedSheetCreator
			{
				get
				{
					return licensedSheetCreator_Renamed;
				}
			}

			/// <summary>
			/// Builds the <seealso cref="User"/> object using the required fields.
			/// </summary>
			/// <returns> the user </returns>
			public virtual User Build()
			{
				if (admin_Renamed == null || emailAddress_Renamed == null || licensedSheetCreator_Renamed == null)
				{
					throw new InvalidOperationException();
				}

				User user = new User();
				user.admin_Renamed = admin_Renamed;
				user.licensedSheetCreator_Renamed = licensedSheetCreator_Renamed;
				user.email = emailAddress_Renamed;
				return user;
			}
		}

		/// <summary>
		/// A convenience class for making a <seealso cref="User"/> object with the appropriate fields for updating a user.
		/// </summary>
		public class UpdateUserBuilder
		{
			internal bool? admin_Renamed;
			internal bool? licensedSheetCreator_Renamed;
			internal long? id_Renamed;

			/// <summary>
			/// Get the id of the user
			/// @return
			/// </summary>
			public virtual long? id
			{
				get
				{
					return id_Renamed;
				}
			}

			/// <summary>
			/// Set the id of the user </summary>
			/// <param name="id"> </param>
			public virtual UpdateUserBuilder SetId(long? id)
			{
				this.id_Renamed = id;
				return this;
			}

			/// <summary>
			/// Sets the admin flag which allows managing users and accounts.
			/// </summary>
			/// <param name="admin"> the admin </param>
			/// <returns> the update user builder </returns>
			public virtual UpdateUserBuilder SetAdmin(bool? admin)
			{
				this.admin_Renamed = admin;
				return this;
			}

			/// <summary>
			/// Licensed sheet creator.
			/// </summary>
			/// <param name="licensedSheetCreator"> the licensed sheet creator </param>
			/// <returns> the update user builder </returns>
			public virtual UpdateUserBuilder SetLicensedSheetCreator(bool? licensedSheetCreator)
			{
				this.licensedSheetCreator_Renamed = licensedSheetCreator;
				return this;
			}

			/// <summary>
			/// Gets the admin.
			/// </summary>
			/// <returns> the admin </returns>
			public virtual bool? admin
			{
				get
				{
					return admin_Renamed;
				}
			}

			/// <summary>
			/// Gets the licensed sheet creator.
			/// </summary>
			/// <returns> the licensed sheet creator </returns>
			public virtual bool? licensedSheetCreator
			{
				get
				{
					return licensedSheetCreator_Renamed;
				}
			}

			/// <summary>
			/// Builds the.
			/// </summary>
			/// <returns> the user </returns>
			public virtual User Build()
			{
				if (admin_Renamed == null || licensedSheetCreator_Renamed == null)
				{
					throw new InvalidOperationException("An admin and licensed sheet creator must be set");
				}

				User user = new User();
				user.admin = admin_Renamed;
				user.id = id_Renamed;
				user.licensedSheetCreator = licensedSheetCreator_Renamed;
				return user;
			}
		}
	}

}