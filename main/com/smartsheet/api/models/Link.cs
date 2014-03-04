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
	/// Represents the Link object. </summary>
	/// <seealso cref= <a href="http://help.smartsheet.com/customer/portal/articles/518326-creating-hyperlinks-to-sheets-websites">
	/// Help Creating Hyperlinks to Sheets & Websites</a> </seealso>
	public class Link
	{
		/// <summary>
		/// Represents the link type.
		/// </summary>
		private LinkType? type_Renamed;

		/// <summary>
		/// Represents the URL.
		/// </summary>
		private string url_Renamed;

		/// <summary>
		/// Represents the sheet ID.
		/// </summary>
		private long? sheetId_Renamed;

		/// <summary>
		/// Represents the column ID.
		/// </summary>
		private long? columnId_Renamed;

		/// <summary>
		/// Represents the row ID.
		/// </summary>
		private long? rowId_Renamed;

		/// <summary>
		/// Gets the type.
		/// </summary>
		/// <returns> the type </returns>
		public virtual LinkType? type
		{
			get
			{
				return type_Renamed;
			}
			set
			{
				this.type_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the url.
		/// </summary>
		/// <returns> the url </returns>
		public virtual string url
		{
			get
			{
				return url_Renamed;
			}
			set
			{
				this.url_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the sheet id.
		/// </summary>
		/// <returns> the sheet id </returns>
		public virtual long? sheetId
		{
			get
			{
				return sheetId_Renamed;
			}
			set
			{
				this.sheetId_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the column id.
		/// </summary>
		/// <returns> the column id </returns>
		public virtual long? columnId
		{
			get
			{
				return columnId_Renamed;
			}
			set
			{
				this.columnId_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the row id.
		/// </summary>
		/// <returns> the row id </returns>
		public virtual long? rowId
		{
			get
			{
				return rowId_Renamed;
			}
			set
			{
				this.rowId_Renamed = value;
			}
		}



	}

}