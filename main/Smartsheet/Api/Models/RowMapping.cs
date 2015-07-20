using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smartsheet.Api.Models
{
	public class RowMapping
	{
		private long from;

		private long to;

		public long From
		{
			get { return from; }
			set { from = value; }
		}

		public long To
		{
			get { return to; }
			set { to = value; }
		}
	}

}
