//    #[license]
//    SmartsheetClient SDK for C#
//    %%
//    Copyright (C) 2018 SmartsheetClient
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
using System.Linq;
using System.Text;

namespace Smartsheet.Api.Models
{
	public class SortCriterion
	{
		/// <summary>
		/// The column ID to sort on
		/// </summary>
		private long columnId;

		/// <summary>
		/// The direction of the sort
		/// </summary>
		private SortDirection direction;

		/// <summary>
		/// Get the column ID of the column to sort on
		/// </summary>
		/// <returns> the column ID </returns>
		public long ColumnId
		{
			get { return columnId; }
			set { columnId = value; }
		}

		/// <summary>
		/// Get the sort direction
		/// </summary>
		/// <returns> the sort direction </returns>
		public SortDirection Direction
		{
			get { return direction; }
			set { direction = value; }
		}
	}
}
