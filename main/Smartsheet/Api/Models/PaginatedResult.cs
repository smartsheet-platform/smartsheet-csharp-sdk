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

using System;
using System.Collections.Generic;

namespace Smartsheet.Api.Models
{

	/// <summary>
	/// <para>Object returned for all GET operations against index endpoints.</para>
	/// This object provides metadata which can be used to perform paging on potentially
	/// large data sets.
	/// </summary>
	public class PaginatedResult<T>
	{
		private int? pageNumber;

		private int? pageSize;

		private int? totalCount;

		private int? totalPages;

		private IList<T> data;

		/// <summary>
		/// The current page in the full result set that the data array represents.
		/// </summary>
		public int? PageNumber
		{
			get { return pageNumber; }
			set { pageNumber = value; }
		}

		/// <summary>
		/// The number of items in a page. Omitted if there is no limit to page size (and hence, all results are included).
		/// Unless otherwise specified, this defaults to 100 for most endpoints.
		/// </summary>
		public int? PageSize
		{
			get { return pageSize; }
			set { pageSize = value; }
		}

		/// <summary>
		/// The total number of pages in the full result set.
		/// </summary>
		public int? TotalCount
		{
			get { return totalCount; }
			set { totalCount = value; }
		}

		/// <summary>
		/// The total number of items in the full result set.
		/// </summary>
		public int? TotalPages
		{
			get { return totalPages; }
			set { totalPages = value; }
		}

		/// <summary>
		/// A list of objects representing the current page of data in the result set.
		/// </summary>
		public IList<T> Data
		{
			get { return data; }
			set { data = value; }
		}
	}
}