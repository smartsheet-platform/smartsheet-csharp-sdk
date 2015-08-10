﻿//    #[license]
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

using System;
using System.Collections.Generic;

namespace Smartsheet.Api.Models
{
	/// <summary>
	/// Represents the GroupMember object. </summary>
	public class GroupMember : UserModelWithName
	{
		public class AddGroupMemberBuilder
		{
			private string email;

			public AddGroupMemberBuilder(string email)
			{
				this.email = email;
			}

			public AddGroupMemberBuilder SetEmail(string email)
			{
				this.email = email;
				return this;
			}

			public string getEmail()
			{
				return this.email;
			}

			public GroupMember Build()
			{
				GroupMember groupMember = new GroupMember
				{
					Email = this.email
				};
				return groupMember;
			}
		}
	}
}