using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smartsheet.Api.Models
{
	public class CopyOrMoveRowResult
	{
		private long destinationSheetId;

		private IList<RowMapping> rowMappings;

		public IList<RowMapping> RowMappings
		{
			get { return rowMappings; }
			set { rowMappings = value; }
		}

		public long DestinationSheetId
		{
			get { return destinationSheetId; }
			set { destinationSheetId = value; }
		}
	}

}
