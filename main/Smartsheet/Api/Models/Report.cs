using Smartsheet_csharp_sdk.main.Smartsheet.Api.Models;
using System.Collections.Generic;

namespace Smartsheet.Api.Models
{
	/// <summary>
	/// Represents the Report object.
	/// </summary>
	public class Report:AbstractSheet<ReportRow, ReportColumn, ReportCell>
	{
		private IList<Sheet> _sourceSheet;

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
