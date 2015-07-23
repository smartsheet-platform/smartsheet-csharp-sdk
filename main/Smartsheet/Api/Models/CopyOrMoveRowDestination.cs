using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smartsheet.Api.Models
{
	public class CopyOrMoveRowDestination
	{
		private long sheetId;

		public long SheetId
		{
			get { return sheetId; }
			set { sheetId = value; }
		}
	}
}
