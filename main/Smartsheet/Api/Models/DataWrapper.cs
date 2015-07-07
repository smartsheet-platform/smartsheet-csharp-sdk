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
	/// A wrapper object used to Wrap the data that comes back from the API. <br />
	/// It holds the paging info as well as a List of objects of the specified type.
	/// </summary>
	public class DataWrapper<T>
	{
		private int? pageNumber;

		private int? pageSize;

		private int? totalCount;

		private int? totalPages;

		private IList<T> data;

		public int? PageNumber
		{
			get { return pageNumber; }
			set { pageNumber = value; }
		}

		public int? PageSize
		{
			get { return pageSize; }
			set { pageSize = value; }
		}

		public int? TotalCount
		{
			get { return totalCount; }
			set { totalCount = value; }
		}

		public int? TotalPages
		{
			get { return totalPages; }
			set { totalPages = value; }
		}

		public IList<T> Data
		{
			get { return data; }
			set { data = value; }
		}
	}
}