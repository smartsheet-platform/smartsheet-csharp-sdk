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
	/// Represents the Group object. </summary>
	public class Group : NamedModel
	{
		private string description;

		private string owner;

		private long? ownerId;

		private IList<GroupMember> members;

		private DateTime? createdAt;

		private DateTime? modifiedAt;

		/// <summary>
		/// Group owner’s email address
		/// </summary>
		public string Owner
		{
			get { return owner; }
			set { owner = value; }
		}

		/// <summary>
		/// Group owner’s User ID
		/// </summary>
		public long? OwnerId
		{
			get { return ownerId; }
			set { ownerId = value; }
		}

		/// <summary>
		/// List of GroupMember objects
		/// </summary>
		public IList<GroupMember> Members
		{
			get { return members; }
			set { members = value; }
		}

		/// <summary>
		/// Time of creation
		/// </summary>
		public DateTime? CreatedAt
		{
			get { return createdAt; }
			set { createdAt = value; }
		}

		/// <summary>
		/// Time of last modification
		/// </summary>
		public DateTime? ModifiedAt
		{
			get { return modifiedAt; }
			set { modifiedAt = value; }
		}

		/// <summary>
		/// Group description
		/// </summary>
		public string Description
		{
			get { return description; }
			set { description = value; }
		}

		/// <summary>
		/// A convenience class for making a Group object with the appropriate fields for creating the group.
		/// </summary>
		public class CreateGroupBuilder
		{
			private string name;
			private string description;
			private IList<GroupMember> members;

			/// <summary>
			/// Sets the required attributes for creating a Group.
			/// </summary>
			/// <param name="name"> name of group, must be unique within the organization </param>
			/// <param name="description">description of group </param>
			public CreateGroupBuilder(string name, string description)
			{
				this.name = name;
				this.description = description;
			}

			public CreateGroupBuilder SetName(string name)
			{
				this.name = name;
				return this;
			}

			public CreateGroupBuilder SetDescription(string description)
			{
				this.description = description;
				return this;
			}

			public CreateGroupBuilder SetMembers(IList<GroupMember> members)
			{
				this.members = members;
				return this;
			}

			public string getName()
			{
				return this.name;
			}

			public string getDescription()
			{
				return this.description;
			}

			public IList<GroupMember> getMembers()
			{
				return this.members;
			}

			/// <summary>
			/// Builds and returns the Group object
			/// </summary>
			/// <returns> the Group object built. </returns>
			public Group Build()
			{
				Group group = new Group
				{
					Name = this.name,
					Description = this.description,
					Members = this.members
				};
				return group;
			}
		}

		/// <summary>
		/// A convenience class for making a Group object with the appropriate fields for updating the group.
		/// </summary>
		public class UpdateGroupBuilder
		{
			private string name;
			private string description;
			private long? ownerId;

			public UpdateGroupBuilder SetName(string name)
			{
				this.name = name;
				return this;
			}

			public UpdateGroupBuilder SetDescription(string description)
			{
				this.description = description;
				return this;
			}

			public UpdateGroupBuilder SetOwnerId(long? ownerId)
			{
				this.ownerId = ownerId;
				return this;
			}

			public string getName()
			{
				return this.name;
			}

			public string getDescription()
			{
				return this.description;
			}

			public long? GetOwnerId()
			{
				return this.ownerId;
			}

			public Group Build()
			{
				Group group = new Group
				{
					Name = this.name,
					Description = this.description,
					OwnerId = this.ownerId
				};
				return group;
			}
		}
	}
}