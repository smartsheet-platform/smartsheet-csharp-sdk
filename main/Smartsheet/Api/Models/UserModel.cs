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
		private string email;

		private string firstName;

		private string lastName;

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
		/// Flag indicating whether the user is a resource viewer (can access resource views)
		/// </summary>
		private bool? resourceViewer;

		/// <summary>
		/// Flag indicating whether the user is a group admin (can create and edit groups)
		/// </summary>
		private bool? groupAdmin;


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
		/// Flag indicating whether the user is a resource viewer (can access resource views)
		/// </summary>
		public virtual bool? ResourceViewer
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
	}
}