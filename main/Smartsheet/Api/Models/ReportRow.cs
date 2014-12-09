using Smartsheet.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smartsheet_csharp_sdk.main.Smartsheet.Api.Models
{
	public class ReportRow : AbstractRow<ReportColumn, ReportCell>
	{
		/// <summary>
		/// The ID of the sheet that this row originates from.
		/// </summary>
		public long SheetId { get; set; }
	}
}
