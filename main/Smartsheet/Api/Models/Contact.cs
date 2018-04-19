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

using System.Collections.Generic;

namespace Smartsheet.Api.Models
{

	/// <summary>
	/// Represents a user’s personal 
	/// in Smartsheet
	/// <seealso href="http://help.smartsheet.com/customer/portal/articles/796143-managing-contacts">Managing contacts</seealso>
	/// </summary>
	public class Contact : NamedModel
	{
		private string id;

		private string email;

		/// <summary>
		/// Contact’s email address
		/// </summary>
		public string Email
		{
			get { return email; }
			set { email = value; }
		}

		/// <summary>
		/// Contact ID, unlike other Smartsheet object ids, this id is an alphanumeric string.
		/// </summary>
		public virtual new string Id
		{
			// This should hide inherited member "Id".
			get { return id; }
			set { id = value; }
		}
	}
}