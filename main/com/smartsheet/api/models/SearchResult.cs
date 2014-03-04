using System.Collections.Generic;

namespace com.smartsheet.api.models
{

	/*
	 * #[license]
	 * Smartsheet SDK for C#
	 * %%
	 * Copyright (C) 2014 Smartsheet
	 * %%
	 * Licensed under the Apache License, Version 2.0 (the "License");
	 * you may not use this file except in compliance with the License.
	 * You may obtain a copy of the License at
	 * 
	 *      http://www.apache.org/licenses/LICENSE-2.0
	 * 
	 * Unless required by applicable law or agreed to in writing, software
	 * distributed under the License is distributed on an "AS IS" BASIS,
	 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
	 * See the License for the specific language governing permissions and
	 * limitations under the License.
	 * %[license]
	 */

	/// <summary>
	/// Represents the results of a search. </summary>
	/// <seealso cref= <a href="http://help.smartsheet.com/customer/portal/articles/522231-searching-in-smartsheet">Help Searching in 
	/// Smartsheet</a> </seealso>
	public class SearchResult
	{
		/// <summary>
		/// Represents total count of results.
		/// </summary>
		private int? totalCount_Renamed;

		/// <summary>
		/// A list of items returned from the search results.
		/// </summary>
		private IList<SearchResultItem> results_Renamed;

		/// <summary>
		/// Gets the total count of results.
		/// </summary>
		/// <returns> the total count </returns>
		public virtual int? totalCount
		{
			get
			{
				return totalCount_Renamed;
			}
			set
			{
				this.totalCount_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the list of results from the search.
		/// </summary>
		/// <returns> the results </returns>
		public virtual IList<SearchResultItem> results
		{
			get
			{
				return results_Renamed;
			}
			set
			{
				this.results_Renamed = value;
			}
		}

	}

}