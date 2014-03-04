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
	/// Represents Sheet Email object used for sending a sheet by email. </summary>
	/// <seealso cref= <a href="http://help.smartsheet.com/customer/portal/articles/504773-sending-sheets-rows-via-email">Help Sending
	/// Sheets & Rows via Email</a> </seealso>
	public class SheetEmail : Email
	{
		/// <summary>
		/// Represents the sheet email format (PDF or Excel).
		/// </summary>
		private SheetEmailFormat? format_Renamed;

		/// <summary>
		/// Represents the format details (paper dimensions).
		/// </summary>
		private FormatDetails formatDetails_Renamed;

		/// <summary>
		/// Gets the sheet email format (PDF or Excel).
		/// </summary>
		/// <returns> the format </returns>
		public virtual SheetEmailFormat? format
		{
			get
			{
				return format_Renamed;
			}
			set
			{
				this.format_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the format details (paper dimensions).
		/// </summary>
		/// <returns> the format details </returns>
		public virtual FormatDetails formatDetails
		{
			get
			{
				return formatDetails_Renamed;
			}
			set
			{
				this.formatDetails_Renamed = value;
			}
		}



	}

}