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
using System.Collections.Generic;

namespace Smartsheet.Api.Models
{
	/// <summary>
	/// Represents the Report object.
	/// </summary>
	public class Report : AbstractSheet<ReportRow, ReportColumn, ReportCell>
	{
		private IList<Sheet> _sourceSheet;

		/// <summary>
		/// Array of Sheet objects (without rows), representing the sheets that rows in the report originated from.
		/// Only included in the Get Report response if the include parameter specifies “sourceSheets”.
		/// </summary>
		public IList<Sheet> SourceSheet
		{
			get { return _sourceSheet; }
			set { _sourceSheet = value; }
		}

		/// <summary>
		/// Get a <seealso cref="Column"/> by ID.
		/// </summary>
		/// <param name="columnId"> the column Id </param>
		/// <returns> the column by Id </returns>
		public virtual ReportColumn GetColumnById(long columnId)
		{
			if (columns == null)
			{
				return null;
			}

			ReportColumn result = null;
			foreach (ReportColumn column in columns)
			{
				if (column.VirtualId == columnId)
				{
					result = column;
					break;
				}
			}
			return result;
		}
	}
}
