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

using Newtonsoft.Json;

namespace Smartsheet.Api.Models
{
	/// <summary>
	/// Represents a hyperlink to a URL, a sheet, or a report. 
	/// <remarks>If the sheet or report that is linked to was deleted, this object may be empty (i.e., all values null).</remarks>
	/// <para>You can create and modify hyperlinks by using any API operation that creates or updates cell data.
	/// When creating or updating a hyperlink, cell.value may be set to a string value or null.
	/// If null, the cell’s value will be derived from the hyperlink:
	/// <list type="bullet">
	/// <item>If the hyperlink is a URL link, the cell’s value will be set to the URL itself.</item>
	/// <item>If the hyperlink is a sheet or report link, the cell’s value will be set to the sheet or report’s name.</item>
	/// </list></para>
	/// </summary>
	public class Hyperlink
	{
		/// <summary>
		/// Represents the URL.
		/// </summary>
		private string url;

		/// <summary>
		/// Represents the sheet Id.
		/// </summary>
		private long? sheetId;

		/// <summary>
		/// If non-null, this hyperlink is a link to the report with this Id.
		/// </summary>
		private long? reportId;

		/// <summary>
		/// If non-null, this hyperlink is a link to the Sight with this Id.
		/// </summary>
		private long? sightId;

		/// <summary>
		/// If true, update will serialize a null to reset the hyperlink
		/// </summary>
		private bool isNull = true;

		/// <summary>
		/// If non-null, this hyperlink is a link to the report with this Id.
		/// </summary>
		public long? ReportId
		{
			get { return reportId; }
			set {
				isNull = false;
				reportId = value;
			}
		}

		/// <summary>
		/// If non-null, this hyperlink is a link to the Sight with this Id.
		/// </summary>
		public long? SightId
		{
			get { return sightId; }
			set {
				isNull = false;
				sightId = value;
			}
		}

		/// <summary>
		/// <para>When the hyperlink is a URL link, this property will contain the URL value.</para>
		/// <para>When the hyperlink is a sheet/report link (i.e., sheetId or reportId is non-null), 
		/// this property will contain the permalink to the sheet or report.</para>
		/// </summary>
		/// <returns> the Url </returns>
		public virtual string Url
		{
			get	{ return url; }
			set	{
				isNull = false;
				url = value;
			}
		}


		/// <summary>
		/// If non-null, this hyperlink is a link to the sheet with this Id.
		/// </summary>
		/// <returns> the sheet Id </returns>
		public virtual long? SheetId
		{
			get	{ return sheetId; }
			set	{
				isNull = false;
				sheetId = value; 
			}
		}

		/// <summary>
		/// Get the value of the isNull flag
		/// </summary>
		/// <returns> value of the isNull flag </returns>
		[JsonIgnore]
		public virtual bool IsNull
		{
			get { return isNull; }
		}
	
	}
}
