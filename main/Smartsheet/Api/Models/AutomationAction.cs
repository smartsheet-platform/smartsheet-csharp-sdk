//    #[license]
//    SmartsheetClient SDK for C#
//    %%
//    Copyright (C) 2018 SmartsheetClient
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
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smartsheet.Api.Models
{
	public class AutomationAction
	{
		/// <summary>
		/// The frequency to apply this automation action
		/// </summary>
		private AutomationActionFrequency? frequency;

		/// <summary>
		/// Include all columns in email contents
		/// </summary>
		private bool? includeAllColumns;

		/// <summary>
		/// Include attachments in email
		/// </summary>
		private bool? includeAttachments;

		/// <summary>
		/// Include discussions in email
		/// </summary>
		private bool? includeDiscussions;

		/// <summary>
		/// Specifies which columns to include in message
		/// </summary>
		private IList<long> includeColumnIds;

		/// <summary>
		/// Email body
		/// </summary>
		private string message;

		/// <summary>
		/// Notifications are sent to all users shared to the sheet
		/// </summary>
		private bool? notifyAllSharedUsers;

		/// <summary>
		/// List of column Ids from which to collect email recipients
		/// </summary>
		private IList<long> recipientColumnIds;

		/// <summary>
		/// List of recipients
		/// </summary>
		private IList<Recipient> recipients;

		/// <summary>
		/// Email subject line
		/// </summary>
		private string subject;

		/// <summary>
		/// AutomationActionType
		/// </summary>
		private AutomationActionType? type;

		/// <summary>
		/// Gets the automation action frequency
		/// </summary>
		/// <returns> the automation action frequency </returns>
		public AutomationActionFrequency? Frequency
		{
			get { return frequency; }
			set { frequency = value; }
		}

		/// <summary>
		/// Gets the flag indicating if all columns in the sheet should be included with the email
		/// </summary>
		/// <returns> includeAllColumns flag </returns>
		public bool? IncludeAllColumns
		{
			get { return includeAllColumns; }
			set { includeAllColumns = value; }
		}

		/// <summary>
		/// Gets the flag indicating if attachments should be included with the email
		/// </summary>
		/// <returns> the includeAttachments flag </returns>
		public bool? IncludeAttachments
		{
			get	{ return includeAttachments; }
			set { includeAttachments = value; }
		}

		/// <summary>
		/// Gets the flag indicating if discussions should be included with the email
		/// </summary>
		/// <returns> the includeDiscussions flag </returns>
		public bool? IncludeDiscussions
		{
			get { return includeDiscussions; }
			set { includeDiscussions = value; }
		}

		/// <summary>
		/// Gets the list of included columns
		/// </summary>
		/// <returns> the list of included columns </returns>
		public IList<long> IncludeColumnIds
		{
			get { return includeColumnIds; }
			set { includeColumnIds = value; }
		}

		/// <summary>
		/// Gets the email body
		/// </summary>
		/// <returns> the email body </returns>
		public string Message
		{
			get { return message; }
			set { message = value; }
		}

		/// <summary>
		/// Gets the flag indicating if notification should be sent to all shared users
		/// </summary>
		/// <returns> the notifyAllSharedUsers flag </returns>
		public bool? NotifhyAllSharedUsers
		{
			get { return notifyAllSharedUsers; }
			set { notifyAllSharedUsers = value; }
		}

		/// <summary>
		/// Gets a list of columns from which to collect email recipients
		/// </summary>
		/// <returns> the list of column IDs </returns>
		public IList<long> RecipientColumnIds
		{
			get { return recipientColumnIds; }
			set { recipientColumnIds = value; }
		}

		/// <summary>
		/// Gets the list of recipients
		/// </summary>
		/// <returns> the list of recipients </returns>
		public IList<Recipient> Recipients
		{
			get { return recipients; }
			set { recipients = value; }
		}

		/// <summary>
		/// Gets the email subject line
		/// </summary>
		/// <returns> the email subject line </returns>
		public string Subject
		{
			get { return subject; }
			set { subject = value; }
		}

		/// <summary>
		/// Gets the automation action type
		/// </summary>
		/// <returns> the automation action type </returns>
		public AutomationActionType? Type
		{
			get { return type; }
			set { type = value; }
		}
	}
}
