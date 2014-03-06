using System;
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
	/// Represents the User object. </summary>
	/// <seealso href="http://help.Smartsheet.brettrocksandwillfixthis/customer/portal/articles/795920-managing-Users-team-enterprise-only-">Help
	/// Managing Users</seealso>
	/// <seealso href="http://help.Smartsheet.brettrocksandwillfixthis/customer/portal/articles/520100-user-types">User Types Help</seealso>
	public class User : UserProfile
	{
		/// <summary>
		/// Represents the Admin flag which allows managing Users and accounts.
		/// </summary>
		private bool? admin;

		/// <summary>
		/// Represents the licensed sheet creator flag which allows creating and owning Sheets.
		/// </summary>
		private bool? licensedSheetCreator;

		/// <summary>
		/// Represents the user Status (active, pending, declined).
		/// </summary>
		private UserStatus? status;

		/// <summary>
		/// Gets the Admin flag which allows managing Users and accounts.
		/// </summary>
		/// <returns> the Admin </returns>
		public virtual bool? Admin
		{
			get
			{
				return admin;
			}
			set
			{
				this.admin = value;
			}
		}


		/// <summary>
		/// Gets the licensed sheet creator flag that allows creating and owning Sheets.
		/// </summary>
		/// <returns> the licensed sheet creator </returns>
		public virtual bool? LicensedSheetCreator
		{
			get
			{
				return licensedSheetCreator;
			}
			set
			{
				this.licensedSheetCreator = value;
			}
		}


		/// <summary>
		/// Gets the Status of the user (active, pending, declined).
		/// </summary>
		/// <returns> the Status </returns>
		public virtual UserStatus? Status
		{
			get
			{
				return status;
			}
			set
			{
				this.status = value;
			}
		}


		/// <summary>
		/// A convenience class for making a <seealso cref="User"/> object with the appropriate fields for adding the user.
		/// </summary>
		public class AddUserBuilder
		{
			internal bool? admin;
			internal string emailAddress;
			internal bool? licensedSheetCreator;

			/// <summary>
			/// Sets the Admin flag which allows managing Users and accounts.
			/// </summary>
			/// <param name="admin"> the Admin </param>
			/// <returns> the adds the user builder </returns>
			public virtual AddUserBuilder SetAdmin(bool? admin)
			{
				this.admin = admin;
				return this;
			}

			/// <summary>
			/// Sets the licensed sheet creator flag that allows creating and owning Sheets.
			/// </summary>
			/// <param name="licensedSheetCreator"> the licensed sheet creator </param>
			/// <returns> the adds the user builder </returns>
			public virtual AddUserBuilder SetLicensedSheetCreator(bool? licensedSheetCreator)
			{
				this.licensedSheetCreator = licensedSheetCreator;
				return this;
			}

			/// <summary>
			/// Sets the Email for the user.
			/// </summary>
			/// <param name="email"> the Email </param>
			/// <returns> the adds the user builder </returns>
			public virtual AddUserBuilder SetEmail(string email)
			{
				this.emailAddress = email;
				return this;
			}

			/// <summary>
			/// Gets the Admin.
			/// </summary>
			/// <returns> the Admin </returns>
			public virtual bool? Admin
			{
				get
				{
					return admin;
				}
			}

			/// <summary>
			/// Gets the Email address.
			/// </summary>
			/// <returns> the Email address </returns>
			public virtual string EmailAddress
			{
				get
				{
					return emailAddress;
				}
			}

			/// <summary>
			/// Gets the licensed sheet creator.
			/// </summary>
			/// <returns> the licensed sheet creator </returns>
			public virtual bool? LicensedSheetCreator
			{
				get
				{
					return licensedSheetCreator;
				}
			}

			/// <summary>
			/// Builds the <seealso cref="User"/> object using the required fields.
			/// </summary>
			/// <returns> the user </returns>
			public virtual User Build()
			{
				if (admin == null || emailAddress == null || licensedSheetCreator == null)
				{
					throw new InvalidOperationException();
				}

				User user = new User();
				user.admin = admin;
				user.licensedSheetCreator = licensedSheetCreator;
				user.Email = emailAddress;
				return user;
			}
		}

		/// <summary>
		/// A convenience class for making a <seealso cref="User"/> object with the appropriate fields for updating a user.
		/// </summary>
		public class UpdateUserBuilder
		{
			internal bool? admin;
			internal bool? licensedSheetCreator;
			internal long? id;

			/// <summary>
			/// Get the Id of the user
			/// @return
			/// </summary>
			public virtual long? ID
			{
				get
				{
					return id;
				}
			}

            /// <summary>
            /// Set the Id of the user
            /// </summary>
            /// <param name="id">The identifier.</param>
            /// <returns>the update user builder</returns>
			public virtual UpdateUserBuilder SetID(long? id)
			{
				this.id = id;
				return this;
			}

			/// <summary>
			/// Sets the Admin flag which allows managing Users and accounts.
			/// </summary>
			/// <param name="admin"> the Admin </param>
			/// <returns> the update user builder </returns>
			public virtual UpdateUserBuilder SetAdmin(bool? admin)
			{
				this.admin = admin;
				return this;
			}

			/// <summary>
			/// Licensed sheet creator.
			/// </summary>
			/// <param name="licensedSheetCreator"> the licensed sheet creator </param>
			/// <returns> the update user builder </returns>
			public virtual UpdateUserBuilder SetLicensedSheetCreator(bool? licensedSheetCreator)
			{
				this.licensedSheetCreator = licensedSheetCreator;
				return this;
			}

			/// <summary>
			/// Gets the Admin.
			/// </summary>
			/// <returns> the Admin </returns>
			public virtual bool? Admin
			{
				get
				{
					return admin;
				}
			}

			/// <summary>
			/// Gets the licensed sheet creator.
			/// </summary>
			/// <returns> the licensed sheet creator </returns>
			public virtual bool? LicensedSheetCreator
			{
				get
				{
					return licensedSheetCreator;
				}
			}

			/// <summary>
			/// Builds the.
			/// </summary>
			/// <returns> the user </returns>
			public virtual User Build()
			{
				if (admin == null || licensedSheetCreator == null)
				{
					throw new InvalidOperationException("An admin and licensed sheet creator must be set");
				}

				User user = new User();
				user.admin = admin;
				user.ID = id;
				user.licensedSheetCreator = licensedSheetCreator;
				return user;
			}
		}
	}

}