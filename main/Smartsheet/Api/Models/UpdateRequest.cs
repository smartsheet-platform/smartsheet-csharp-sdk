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

namespace Smartsheet.Api.Models
{
	/// <summary>
	/// Represents the UpdateRequest object.
	/// </summary>
	public class UpdateRequest : MultiRowEmail
	{
		/// <summary>
		/// ID of the update request.
		/// </summary>
		private long? id;

		/// <summary>
		/// User object containing name and email of the sender.
		/// </summary>
		private User sentBy;

		/// <summary>
		/// The schedule for which update requests will be sent out.
		/// </summary>
		private Schedule schedule;

		/// <summary>
		/// The date and time for when this request was originally created. Read-only.
		/// </summary>
		private DateTime createdAt;

		/// <summary>
		/// The date and time for when the last change was made to this request. Read-only.
		/// </summary>
		private DateTime modifiedAt;

		/// <summary>
		/// ID of the update request.
		/// </summary>
		public long? Id
		{
			get
			{
				return id;
			}
			set
			{
				this.id = value;
			}
		}

		/// <summary>
		/// Gets the User object containing name and email of the sender.
		/// </summary>
		/// <returns> the User </returns>
		public virtual User SentBy
		{
			get
			{
				return sentBy;
			}
			set
			{
				this.sentBy = value;
			}
		}

		/// <summary>
		/// Gets the schedule for which update requests will be sent out.
		/// </summary>
		/// <returns> the Schedule </returns>
		public virtual Schedule Schedule
		{
			get
			{
				return schedule;
			}
			set
			{
				this.schedule = value;
			}
		}

		/// <summary>
		/// Gets the date and time for when this request was originally created. Read-only
		/// </summary>
		/// <returns> the timestamp </returns>
		public virtual DateTime CreatedAt
		{
			get
			{
				return createdAt;
			}
			set
			{
				this.createdAt = value;
			}
		}

		/// <summary>
		/// Gets the date and time for when the last change was made to this request. Read-only.
		/// </summary>
		/// <returns> the timestamp </returns>
		public virtual DateTime ModifiedAt
		{
			get
			{
				return modifiedAt;
			}
			set
			{
				this.modifiedAt = value;
			}
		}
	}
}