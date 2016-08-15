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

namespace Smartsheet.Api.Models
{
	/// <summary>
	/// Represents a hyperlink to a URL, a Sheet, or a Report. 
	/// <remarks>If the Sheet or Report that is linked to was deleted, this object may be empty (i.e. all values null).</remarks>
	/// <para>You can create and modify hyperlinks by using any API operation that creates or updates cell data.
	/// When creating or updating a hyperlink, cell.value may be set to a string value or null.
	/// If null, the cell’s value will be derived from the hyperlink:
	/// <list type="bullet">
	/// <item>If the hyperlink is a URL link, the cell’s value will be set to the URL itself.</item>
	/// <item>If the hyperlink is a sheet or report link, the cell’s value will be set to the sheet or report’s name.</item>
	/// </list></para>
	/// </summary>
	public class Link
	{
		///// <summary>
		///// Represents the Link Type.
		///// </summary>
		//private LinkType? type;

		/// <summary>
		/// Represents the URL.
		/// </summary>
		private string url;

		/// <summary>
		/// Represents the sheet ID.
		/// </summary>
		private long? sheetId;

		/// <summary>
		/// If non-null, this hyperlink is a link to the Report with this ID.
		/// </summary>
		private long? reportId;

		/// <summary>
		/// If non-null, this hyperlink is a link to the Sight with this ID.
		/// </summary>
		private long? sightId;

		/// <summary>
		/// If non-null, this hyperlink is a link to the Report with this ID.
		/// </summary>
		public long? ReportId
		{
			get { return reportId; }
			set { reportId = value; }
		}

		/// <summary>
		/// If non-null, this hyperlink is a link to the Sight with this ID.
		/// </summary>
		public long? SightId
		{
			get { return sightId; }
			set { sightId = value; }
		}

		///// <summary>
		///// Represents the column ID.
		///// </summary>
		//private long? columnId;

		///// <summary>
		///// Represents the row ID.
		///// </summary>
		//private long? rowId;

		///// <summary>
		///// Gets the Type.
		///// </summary>
		///// <returns> the Type </returns>
		//public virtual LinkType? Type
		//{
		//	get
		//	{
		//		return type;
		//	}
		//	set
		//	{
		//		this.type = value;
		//	}
		//}


		/// <summary>
		/// <para>When the hyperlink is a URL link, this property will contain the URL value.</para>
		/// <para>When the hyperlink is a Sheet/Report link (i.e. sheetId or reportId is non-null), 
		/// this property will contain the permalink to the Sheet or Report.</para>
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
		/// If non-null, this hyperlink is a link to the Sheet with this ID.
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


		///// <summary>
		///// Gets the column Id.
		///// </summary>
		///// <returns> the column Id </returns>
		//public virtual long? ColumnId
		//{
		//	get
		//	{
		//		return columnId;
		//	}
		//	set
		//	{
		//		this.columnId = value;
		//	}
		//}


		///// <summary>
		///// Gets the row Id.
		///// </summary>
		///// <returns> the row Id </returns>
		//public virtual long? RowId
		//{
		//	get
		//	{
		//		return rowId;
		//	}
		//	set
		//	{
		//		this.rowId = value;
		//	}
		//}
	}
}