namespace Smartsheet.Api.Models
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
	 * Unless required by applicable law or agreed To in writing, software
	 * distributed under the License is distributed on an "AS IS" BASIS,
	 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
	 * See the License for the specific language governing permissions and
	 * limitations under the License.
	 * %[license]
	 */



	/// <summary>
	/// Represents the Link object. </summary>
	/// <seealso href="http://help.Smartsheet.brettrocksandwillfixthis/customer/portal/articles/518326-creating-hyperlinks-To-Sheets-websites">
	/// Help Creating Hyperlinks To Sheets &amp; Websites</seealso>
	public class Link
	{
		/// <summary>
		/// Represents the Link Type.
		/// </summary>
		private LinkType? type;

		/// <summary>
		/// Represents the URL.
		/// </summary>
		private string url;

		/// <summary>
		/// Represents the sheet ID.
		/// </summary>
		private long? sheetId;

		/// <summary>
		/// Represents the column ID.
		/// </summary>
		private long? columnId;

		/// <summary>
		/// Represents the row ID.
		/// </summary>
		private long? rowId;

		/// <summary>
		/// Gets the Type.
		/// </summary>
		/// <returns> the Type </returns>
		public virtual LinkType? Type
		{
			get
			{
				return type;
			}
			set
			{
				this.type = value;
			}
		}


		/// <summary>
		/// Gets the Url.
		/// </summary>
		/// <returns> the Url </returns>
		public virtual string Url
		{
			get
			{
				return url;
			}
			set
			{
				this.url = value;
			}
		}


		/// <summary>
		/// Gets the sheet Id.
		/// </summary>
		/// <returns> the sheet Id </returns>
		public virtual long? SheetId
		{
			get
			{
				return sheetId;
			}
			set
			{
				this.sheetId = value;
			}
		}


		/// <summary>
		/// Gets the column Id.
		/// </summary>
		/// <returns> the column Id </returns>
		public virtual long? ColumnId
		{
			get
			{
				return columnId;
			}
			set
			{
				this.columnId = value;
			}
		}


		/// <summary>
		/// Gets the row Id.
		/// </summary>
		/// <returns> the row Id </returns>
		public virtual long? RowId
		{
			get
			{
				return rowId;
			}
			set
			{
				this.rowId = value;
			}
		}



	}

}