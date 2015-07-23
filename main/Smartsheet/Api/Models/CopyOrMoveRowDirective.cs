using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smartsheet.Api.Models
{
	public class CopyOrMoveRowDirective
	{
		private IList<long> rowIds;

		private CopyOrMoveRowDestination to;

		public IList<long> RowIds
		{
			get { return rowIds; }
			set { rowIds = value; }
		}

		public CopyOrMoveRowDestination To
		{
			get { return to; }
			set { to = value; }
		}

	}
}
