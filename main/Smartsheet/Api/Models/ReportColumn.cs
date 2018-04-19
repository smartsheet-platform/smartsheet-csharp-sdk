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
using Smartsheet.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smartsheet.Api.Models
{
	/// <summary>
	/// A report column is a "virtual" column, in that it appears identical to source sheet column(s), but is in fact a different column belonging to the report.  
	/// Cells in the report refer to this column via their virtualColumnId attribute, and their actual column from their source sheet via their columnId attribute.
	/// </summary>
	public class ReportColumn : Column
	{
		/// <summary>
		/// The virtual ID of this report column
		/// </summary>
		public long? VirtualId { get; set; }

		/// <summary>
		/// Only included for the special "Sheet Name" report column
		/// </summary>
		public bool? SheetNameColumn { get; set; }

	}
}
