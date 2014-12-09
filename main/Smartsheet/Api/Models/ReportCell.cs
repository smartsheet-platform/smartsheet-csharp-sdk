using Smartsheet.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smartsheet.Api.Models
{
	public class ReportCell : Cell
	{
		/// <summary>
		/// The virtualId of this cell's column.  virtualColumnId refers to this cell's parent column in this report, 
		/// while columnId refers to the cell's parent column in its originating source sheet.
		/// </summary>
		public long VirtualColumnId { get; set; }
	}
}
