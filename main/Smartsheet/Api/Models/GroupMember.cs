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

namespace Smartsheet.Api.Models
{
	public class GroupMember : NamedModel
	{
		private string email;

		private string firstName;

		private string lastName;

		/// <summary>
		/// Gets and sets the Group Member’s email.
		/// </summary>
		/// <returns> the Email </returns>
		public string Email
		{
			get { return email; }
			set { email = value; }
		}

		/// <summary>
		/// Gets and sets the Group Member’s first name.
		/// </summary>
		/// <returns> the FirstName </returns>
		public string FirstName
		{
			get { return firstName; }
			set { firstName = value; }
		}

		/// <summary>
		/// Gets and sets the Group Member’s last name.
		/// </summary>
		/// <returns> the LastName </returns>
		public string LastName
		{
			get { return lastName; }
			set { lastName = value; }
		}
	}
}
