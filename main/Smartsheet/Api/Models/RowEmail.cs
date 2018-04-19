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
	/// Represents RowEmail object. </summary>
	/// <seealso href="http://help.Smartsheet.com/customer/portal/articles/504773-sending-Sheets-Rows-via-Email">Help Sending 
	/// Sheets &amp; Rows via Email</seealso>
	public class RowEmail : Email
	{
		/// <summary>
		/// IDs of the columns to be included.
		/// </summary>
		private IList<long> columnIds;

		/// <summary>
		/// A flag to indicate if Attachments should be included in the Email.
		/// </summary>
		private bool? includeAttachments;

		/// <summary>
		/// A flag to indicate if Discussions should be included in the Email.
		/// </summary>
		private bool? includeDiscussions;

		/// <summary>
		/// One of the following values: HORIZONTAL, VERTICAL.
		/// </summary>
		private string layout;

		/// <summary>
		/// IDs of the columns to be included.
		/// </summary>
		public virtual IList<long> ColumnIds
		{
			get { return columnIds; }
			set { columnIds = value; }
		}

		/// <summary>
		/// Gets the flag that indicates if Attachments should be included in the Email.
		/// </summary>
		/// <returns> the include Attachments </returns>
		public virtual bool? IncludeAttachments
		{
			get
			{
				return includeAttachments;
			}
			set
			{
				this.includeAttachments = value;
			}
		}


		/// <summary>
		/// Gets the flag that indicates if Discussions should be included in the Email.
		/// </summary>
		/// <returns> the include Discussions </returns>
		public virtual bool? IncludeDiscussions
		{
			get
			{
				return includeDiscussions;
			}
			set
			{
				this.includeDiscussions = value;
			}
		}


		/// <summary>
		/// Gets the layout value: HORIZONTAL, VERTICAL.
		/// </summary>
		/// <returns> the layout </returns>
		public virtual string Layout
		{
			get
			{
				return layout;
			}
			set
			{
				this.layout = value;
			}
		}
	}

}