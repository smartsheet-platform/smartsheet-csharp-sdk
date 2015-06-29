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

using System;
using System.Collections.Generic;

namespace Smartsheet.Api.Models
{
	public class Group : NamedModel
	{
		private string description;

        private string owner;

        private long? ownerId;

        private IList<GroupMember> members;

        private DateTime? createdAt;

        private DateTime? modifiedAt;

		/// <summary>
		/// Gets and sets the Group Description.
		/// </summary>
		/// <returns> the Group Description </returns>
		public string Description
        {
            get { return description; }
            set { description = value; }
        }

		/// <summary>
		/// Gets and sets the Group owner’s email address.
		/// </summary>
		/// <returns> Group owner’s email address </returns>
        public string Owner
        {
            get { return owner; }
            set { owner = value; }
        }

		/// <summary>
		/// Gets and sets the Group owner’s User ID.
		/// </summary>
		/// <returns> Group owner’s User ID </returns>
		public long? OwnerId
        {
            get { return ownerId; }
            set { ownerId = value; }
        }

		/// <summary>
		/// Gets and sets the list of Group Members.
		/// </summary>
		/// <returns> list of Group Members </returns>
		public IList<GroupMember> Members
        {
            get { return members; }
            set { members = value; }
        }

		/// <summary>
		/// Gets and sets the Time of creation.
		/// </summary>
		/// <returns> Time of creation </returns>
        public DateTime? CreatedAt
        {
            get { return createdAt; }
            set { createdAt = value; }
        }

		/// <summary>
		/// Gets and sets the Time of last modification.
		/// </summary>
		/// <returns> Time of last modification </returns>
        public DateTime? ModifiedAt
        {
            get { return modifiedAt; }
            set { modifiedAt = value; }
        }
    }
}
