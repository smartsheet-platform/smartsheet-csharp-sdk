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
    /// Represents the User object. </summary>
    /// <seealso href="http://help.Smartsheet.com/customer/portal/articles/795920-managing-Users-team-enterprise-only-">Help
    /// Managing Users</seealso>
    /// <seealso href="http://help.Smartsheet.com/customer/portal/articles/520100-user-types">User Types Help</seealso>
    public class User : UserModelWithName
    {
        /// <summary>
        /// A convenience class for making a <seealso cref="User"/> object with the appropriate fields for adding the user.
        /// </summary>
        public class AddUserBuilder
        {
            private bool? admin;
            private string emailAddress;
            private bool? licensedSheetCreator;
            private string firstName;
            private string lastName;
            private bool? resourceViewer;

            /// <summary>
            /// User object with required attributes
            /// </summary>
            /// <param name="email">email (required)</param>
            /// <param name="admin">admin (required)</param>
            /// <param name="licensedSheetCreator">licensedSheetCreator (required)</param>
            public AddUserBuilder(string email, bool? admin, bool? licensedSheetCreator)
            {
                this.emailAddress = email;
                this.admin = admin;
                this.licensedSheetCreator = licensedSheetCreator;
            }

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
            /// Sets the user's first name.
            /// </summary>
            /// <param name="firstName"> the firstName </param>
            /// <returns> the adds the user builder </returns>
            public virtual AddUserBuilder SetFirstName(string firstName)
            {
                this.firstName = firstName;
                return this;
            }

            /// <summary>
            /// Sets the user's last name.
            /// </summary>
            /// <param name="lastName"> the lastName </param>
            /// <returns> the adds the user builder </returns>
            public virtual AddUserBuilder SetLastName(string lastName)
            {
                this.lastName = lastName;
                return this;
            }

            /// <summary>
            /// Sets the Flag indicating whether the user is a resource viewer (can access resource views)
            /// </summary>
            /// <param name="resourceViewer"> the resourceViewer </param>
            /// <returns> the adds the user builder </returns>
            public virtual AddUserBuilder SetResourceViewer(bool? resourceViewer)
            {
                this.resourceViewer = resourceViewer;
                return this;
            }

            /// <summary>
            /// Gets the Admin.
            /// </summary>
            /// <returns> the Admin </returns>
            public virtual bool? GetAdmin()
            {
                return admin;
            }

            /// <summary>
            /// Gets the Email address.
            /// </summary>
            /// <returns> the Email address </returns>
            public virtual string GetEmailAddress()
            {
                return emailAddress;
            }

            /// <summary>
            /// Gets the licensed sheet creator.
            /// </summary>
            /// <returns> the licensed sheet creator </returns>
            public virtual bool? GetLicensedSheetCreator()
            {
                return licensedSheetCreator;
            }

            /// <summary>
            /// Gets the user's first name.
            /// </summary>
            /// <returns> the firstName </returns>
            public virtual string GetFirstName()
            {
                return firstName;
            }

            /// <summary>
            /// Gets the user's last name.
            /// </summary>
            /// <returns> the lastName </returns>
            public virtual string GetLastName()
            {
                return lastName;
            }

            /// <summary>
            /// Gets the Flag indicating whether the user is a resource viewer (can access resource views).
            /// </summary>
            /// <returns> the resourceViewer </returns>
            public virtual bool? GetResourceViewer()
            {
                return resourceViewer;
            }

            /// <summary>
            /// Builds the <seealso cref="User"/> object using the required fields.
            /// </summary>
            /// <returns> the user </returns>
            public virtual User Build()
            {
                //if (admin == null || emailAddress == null || licensedSheetCreator == null)
                //{
                //    throw new InvalidOperationException();
                //}

                User user = new User();
                user.Admin = admin;
                user.LicensedSheetCreator = licensedSheetCreator;
                user.Email = emailAddress;
                user.FirstName = firstName;
                user.LastName = lastName;
                user.ResourceViewer = resourceViewer;
                return user;
            }
        }

        /// <summary>
        /// A convenience class for making a <seealso cref="User"/> object with the appropriate fields for updating a user.
        /// </summary>
        public class UpdateUserBuilder
        {
            private long? id;
            private bool? admin;
            private bool? licensedSheetCreator;
            private string firstName;
            private string lastName;
            private bool? resourceViewer;

            /// <summary>
            /// User object containing the required attributes:
            /// </summary>
            /// <param name="id">the user id</param>
            /// <param name="admin">admin (required)</param>
            /// <param name="licensedSheetCreator">licensedSheetCreator (required)</param>
            public UpdateUserBuilder(long? id, bool? admin, bool? licensedSheetCreator)
            {
                this.id = id;
                this.admin = admin;
                this.licensedSheetCreator = licensedSheetCreator;
            }

            /// <summary>
            /// Sets the Admin flag which allows managing Users and accounts.
            /// </summary>
            /// <param name="admin"> the Admin </param>
            /// <returns> the UpdateUserBuilder </returns>
            public virtual UpdateUserBuilder SetAdmin(bool? admin)
            {
                this.admin = admin;
                return this;
            }

            /// <summary>
            /// Sets the licensed sheet creator flag that allows creating and owning Sheets.
            /// </summary>
            /// <param name="licensedSheetCreator"> the licensed sheet creator </param>
            /// <returns> the UpdateUserBuilder </returns>
            public virtual UpdateUserBuilder SetLicensedSheetCreator(bool? licensedSheetCreator)
            {
                this.licensedSheetCreator = licensedSheetCreator;
                return this;
            }

            /// <summary>
            /// Sets the user's first name.
            /// </summary>
            /// <param name="firstName"> the firstName </param>
            /// <returns> the UpdateUserBuilder </returns>
            public virtual UpdateUserBuilder SetFirstName(string firstName)
            {
                this.firstName = firstName;
                return this;
            }

            /// <summary>
            /// Sets the user's last name.
            /// </summary>
            /// <param name="lastName"> the lastName </param>
            /// <returns> the UpdateUserBuilder </returns>
            public virtual UpdateUserBuilder SetLastName(string lastName)
            {
                this.lastName = lastName;
                return this;
            }

            /// <summary>
            /// Sets the Flag indicating whether the user is a resource viewer (can access resource views)
            /// </summary>
            /// <param name="resourceViewer"> the resourceViewer </param>
            /// <returns> the UpdateUserBuilder </returns>
            public virtual UpdateUserBuilder SetResourceViewer(bool? resourceViewer)
            {
                this.resourceViewer = resourceViewer;
                return this;
            }

            /// <summary>
            /// Gets the Admin.
            /// </summary>
            /// <returns> the Admin </returns>
            public virtual bool? GetAdmin()
            {
                return admin;
            }

            /// <summary>
            /// Gets the licensed sheet creator.
            /// </summary>
            /// <returns> the licensed sheet creator </returns>
            public virtual bool? GetLicensedSheetCreator()
            {
                return licensedSheetCreator;
            }

            /// <summary>
            /// Gets the user's first name.
            /// </summary>
            /// <returns> the firstName </returns>
            public virtual string GetFirstName()
            {
                return firstName;
            }

            /// <summary>
            /// Gets the user's last name.
            /// </summary>
            /// <returns> the lastName </returns>
            public virtual string GetLastName()
            {
                return lastName;
            }

            /// <summary>
            /// Gets the Flag indicating whether the user is a resource viewer (can access resource views).
            /// </summary>
            /// <returns> the resourceViewer </returns>
            public virtual bool? GetResourceViewer()
            {
                return resourceViewer;
            }

            /// <summary>
            /// Builds the <seealso cref="User"/> object using the required fields.
            /// </summary>
            /// <returns> the user </returns>
            public virtual User Build()
            {
                User user = new User();
                user.Id = id;
                user.Admin = admin;
                user.LicensedSheetCreator = licensedSheetCreator;
                user.FirstName = firstName;
                user.LastName = lastName;
                user.ResourceViewer = resourceViewer;
                return user;
            }
        }
    }

}