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
using System.Collections.Generic;

namespace Smartsheet.Api.Models
{
	/// <summary>
	/// Specifies the recipient of an Email.<br />
	/// The recipient may be either an individual or a group.<br />
	/// To specify an individual, set the email attribute; to specify a group, set the groupId attribute.<br />
	/// Either email and groupId may be set, but not both.
	/// </summary>
	public class Recipient
	{
		private string email;

		private long? groupId;

		/// <summary>
		/// The email address of an individual recipient. If set, GroupId should not be set.
		/// </summary>
		public string Email
		{
			get { return email; }
			set { email = value; }
		}

		/// <summary>
		/// The ID of a group recipient. If set, Email should not be set.
		/// </summary>
		public long? GroupId
		{
			get { return groupId; }
			set { groupId = value; }
		}
	}
}