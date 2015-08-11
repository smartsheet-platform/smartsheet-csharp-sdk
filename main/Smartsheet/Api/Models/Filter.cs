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
	/// <para>
	/// Smartsheet users can define and save personal column filters on sheets they can view.
	/// </para>
	/// <para>
	/// When any API operation that returns columns is invoked with the "include=filters" query string parameter,
	/// the column will include any active filters the user has defined for the sheet.
	/// </para>
	/// </summary>
	public class Filter
	{
		private FilterType? type;

		/// <summary>
		/// The Filter Type
		/// </summary>
		public FilterType? Type
		{
			get { return type; }
			set { type = value; }
		}

		private bool? excludeSelected;

		/// <summary>
		/// If true, rows containing cells matching the “values” or “criteria” items are excluded instead of included.
		/// </summary>
		public bool? ExcludeSelected
		{
			get { return excludeSelected; }
			set { excludeSelected = value; }
		}

		private IList<object> values;

		/// <summary>
		/// Only included if the filter is of type LIST.
		/// <para>
		/// An array of literal cell values that this filter will match against row cells in this column.
		/// The type of the objects in the array depend on the type of the cell values selected to be
		/// filtered on when the filter was created. These may be strings, numbers, booleans, or dates.
		/// </para>
		/// </summary>
		public IList<object> Values
		{
			get { return values; }
			set { values = value; }
		}

		private IList<Criteria> criteria;

		/// <summary>
		/// Only included if the filter is of type CUSTOM.
		/// <para>
		/// An array of Criteria objects specifying custom criteria against which to match cell values.
		/// </para>
		/// </summary>
		public IList<Criteria> Criteria
		{
			get { return criteria; }
			set { criteria = value; }
		}
	}
}