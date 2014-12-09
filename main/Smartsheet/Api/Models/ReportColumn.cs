using Smartsheet.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smartsheet_csharp_sdk.main.Smartsheet.Api.Models
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
		public long VirtualId { get; set; }

		/// <summary>
		/// Only included for the special "Sheet Name" report column
		/// </summary>
		public bool SheetNameColumn { get; set; }

	}
}
