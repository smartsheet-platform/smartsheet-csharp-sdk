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
//    Unless required by applicable law or agreed To in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//    %[license]

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
