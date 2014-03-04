namespace com.smartsheet.api.models
{

	/*
	 * #[license]
	 * Smartsheet SDK for C#
	 * %%
	 * Copyright (C) 2014 Smartsheet
	 * %%
	 * Licensed under the Apache License, Version 2.0 (the "License");
	 * you may not use this file except in compliance with the License.
	 * You may obtain a copy of the License at
	 * 
	 *      http://www.apache.org/licenses/LICENSE-2.0
	 * 
	 * Unless required by applicable law or agreed to in writing, software
	 * distributed under the License is distributed on an "AS IS" BASIS,
	 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
	 * See the License for the specific language governing permissions and
	 * limitations under the License.
	 * %[license]
	 */

	/// <summary>
	/// Represents RowEmail object. </summary>
	/// <seealso cref= <a href="http://help.smartsheet.com/customer/portal/articles/504773-sending-sheets-rows-via-email">Help Sending 
	/// Sheets & Rows via Email</a> </seealso>
	public class RowEmail : Email
	{
		/// <summary>
		/// A flag to indicate if attachments should be included in the email.
		/// </summary>
		private bool? includeAttachments_Renamed;

		/// <summary>
		/// A flag to indicate if discussions should be included in the email.
		/// </summary>
		private bool? includeDiscussions_Renamed;

		/// <summary>
		/// Gets the flag that indicates if attachments should be included in the email.
		/// </summary>
		/// <returns> the include attachments </returns>
		public virtual bool? includeAttachments
		{
			get
			{
				return includeAttachments_Renamed;
			}
			set
			{
				this.includeAttachments_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the flag that indicates if discussions should be included in the email.
		/// </summary>
		/// <returns> the include discussions </returns>
		public virtual bool? includeDiscussions
		{
			get
			{
				return includeDiscussions_Renamed;
			}
			set
			{
				this.includeDiscussions_Renamed = value;
			}
		}

	}

}