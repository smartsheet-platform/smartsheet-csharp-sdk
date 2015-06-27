using Smartsheet.Api.Internal.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smartsheet.Api.Models
{
	public class PaginationParameters
	{
		private bool includeAll;

		private int? pageSize;

		private int? page;

		public PaginationParameters(bool includeAll, int? pageSize, int? page)
		{
			this.includeAll = includeAll;
			this.pageSize = pageSize;
			this.page = page;
		}

		public bool IncludeAll
		{
			get { return includeAll; }
			set { includeAll = value; }
		}
		public int? PageSize
		{
			get { return pageSize; }
			set { pageSize = value; }
		}
		public int? Page
		{
			get { return page; }
			set { page = value; }
		}


		public string ToQueryString()
		{
			Dictionary<string, string> parameters = new Dictionary<string, string>();

			parameters.Add("includeAll", includeAll.ToString());

			if (!includeAll)
			{
				if (pageSize.HasValue)
				{
					parameters.Add("pageSize", pageSize.ToString());
				}
				if (page.HasValue)
				{
					parameters.Add("page", page.ToString());
				}
			} 
			return QueryUtil.GenerateUrl(null, parameters);
		}
	}
}
