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
using Smartsheet.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smartsheet.Api.Models
{
    /// <summary>
    /// Represents an UserModel.
    /// </summary>
    public abstract class UserModel : IdentifiableModel
    {
        /// <summary>
        /// Represents the email address.
        /// </summary>
        private string email;

        /// <summary>
        /// Represents the user's first name.
        /// </summary>
        private string firstName;

        /// <summary>
        /// Represents the user's last name.
        /// </summary>
        private string lastName;

        /// <summary>
        /// Represents the Admin flag which allows managing users and accounts.
        /// </summary>
        private bool? admin;

        /// <summary>
        /// Represents the licensed sheet creator flag which allows creating and owning sheets.
        /// </summary>
        private bool? licensedSheetCreator;

        /// <summary>
        /// Flag indicating whether the user is a resource viewer (can access resource views)
        /// </summary>
        private bool? resourceViewer;

        /// <summary>
        /// Flag indicating whether the user is a group admin (can create and edit groups)
        /// </summary>
        private bool? groupAdmin;

        /// <summary>
        /// Represents the user status (active, pending, declined).
        /// </summary>
        private UserStatus? status;

        /// <summary>
        /// An array of AlternateEmail objects representing the alternate email addresses associated with the user account
        /// </summary>
        private IList<AlternateEmail> alternateEmails;

        /// <summary>
        /// The number of sheets owned by the current user within the organization
        /// </summary>
        private int? sheetCount;

        /// <summary>
        /// Last login time of the current user
        /// </summary>
        private DateTime? lastLogin;

        /// <summary>
        /// Timestamp of viewing an Enterprise Custom Welcome Screen by the current user
        /// </summary>
        private DateTime? customWelcomeScreenViewed;

        /// <summary>
        /// Company name from the user's profile
        /// </summary>
        private string company;

        /// <summary>
        /// Department name from the user's profile
        /// </summary>
        private string department;

        /// <summary>
        /// User's mobile phone number from the profile
        /// </summary>
        private string mobilePhone;

        /// <summary>
        /// Link to the user's profile image
        /// </summary>
        private Image profileImage;

        /// <summary>
        /// User's role
        /// </summary>
        private string role;

        /// <summary>
        /// User's title
        /// </summary>
        private string title;

        /// <summary>
        /// Work phone number for the user's profile
        /// </summary>
        private string workPhone;

        /// <summary>
        /// Current user’s email address
        /// </summary>
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        /// <summary>
        /// Current user’s first name
        /// </summary>
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        /// <summary>
        /// Current user’s last name
        /// </summary>
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        /// <summary>
        /// Gets the Admin flag which allows managing users and accounts.
        /// </summary>
        /// <returns> the admin </returns>
        public bool? Admin
        {
            get { return admin; }
            set { this.admin = value; }
        }

        /// <summary>
        /// Gets the licensed sheet creator flag that allows creating and owning sheets.
        /// </summary>
        /// <returns> the licensed sheet creator </returns>
        public bool? LicensedSheetCreator
        {
            get { return licensedSheetCreator; }
            set { this.licensedSheetCreator = value; }
        }

        /// <summary>
        /// Flag indicating whether the user is a resource viewer (can access resource views)
        /// </summary>
        public bool? ResourceViewer
        {
            get { return resourceViewer; }
            set { resourceViewer = value; }
        }

        /// <summary>
        /// Flag indicating whether the user is a group admin (can create and edit groups)
        /// </summary>
        public bool? GroupAdmin
        {
            get { return groupAdmin; }
            set { groupAdmin = value; }
        }

        /// <summary>
        /// Gets the status of the user (active, pending, declined).
        /// </summary>
        /// <returns> the Status </returns>
        public UserStatus? Status
        {
            get { return status; }
            set { this.status = value; }
        }
        
        /// <summary>
        /// Get list of alternate email addresses associated with this user account
        /// </summary>
        public IList<AlternateEmail> AlternateEmails
        {
            get { return alternateEmails; }
            set { alternateEmails = value;  }
        }

        /// <summary>
        /// Get the number of sheets owned by the current user within the organization
        /// </summary>
        public int? SheetCount
        {
            get { return sheetCount; }
            set { sheetCount = value; }
        }

        /// <summary>
        /// Get the last login time of the current user
        /// </summary>
        public DateTime? LastLogin
        {
            get { return lastLogin; }
            set { lastLogin = value; }
        }

        /// <summary>
        /// Get the timestamp of the viewing of an Enterprise Custom Welcome Screen by the current user
        /// </summary>
        public DateTime? CustomWelcomeScreenViewed
        {
            get { return customWelcomeScreenViewed; }
            set { customWelcomeScreenViewed = value; }
        }

        /// <summary>
        /// Gets the user's company name
        /// </summary>
        public string Company
        {
            get { return company; }
            set { this.company = value; }
        }

        /// <summary>
        /// Gets the user's department
        /// </summary>
        public string Department
        {
            get { return department; }
            set { this.department = value; }
        }

        /// <summary>
        /// Gets the user's mobile phone number
        /// </summary>
        public string MobilePhone
        {
            get { return mobilePhone; }
            set { this.mobilePhone = value; }
        }

        /// <summary>
        /// Gets a link to the user's profile image
        /// </summary>
        public Image ProfileImage
        {
            get { return profileImage; }
            set { this.profileImage = value; }
        }

        /// <summary>
        /// Gets the user's role
        /// </summary>
        public string Role
        {
            get { return role; }
            set { this.role = value; }
        }

        /// <summary>
        /// Get the user's title
        /// </summary>
        public string Title
        {
            get { return title; }
            set { this.title = value; }
        }

        /// <summary>
        /// Gets the user's work phone
        /// </summary>
        public string WorkPhone
        {
            get { return workPhone; }
            set { this.workPhone = value; }
        }
    }
}
