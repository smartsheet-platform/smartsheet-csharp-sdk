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

using Smartsheet.Api.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smartsheet.Api.Internal.Utility
{
	public sealed class PathAndQueryWrapper
	{

		private const string IncludeAllParameterName = "includeAll";
		private const string PageSizeParameterName = "pageSize";
		private const string PageNumberParameterName = "page";
		private const string IncludeParameterName = "include";

		private readonly QueryStringBuilder queryStringBuilder;

		public PathAndQueryWrapper()
		{
			queryStringBuilder = new QueryStringBuilder();
		}

		/// <summary>
		/// Creates the path and query of a Smartsheet request with Indlude elements and Paging
		/// </summary>
		/// <param name="path"> Such as "/folders/{folderId}" </param>
		/// <param name="includes"> the elements to include into the query </param>
		/// <param name="includeAll"> whether to append includeAll=true to the query or not </param>
		/// <param name="page"> appends the page number to the query </param>
		/// <param name="pageSize"> appends the page size to the query </param>
		public static string CreatePathAndQueryWithIncludeAndPaging<T>(string path, IEnumerable<T> includes, bool? includeAll, long? page, long? pageSize)
		{
			StringBuilder pathAndQuery = new StringBuilder(path);
			QueryStringBuilder queryStringBuilder = new QueryStringBuilder();
			if (includes != null)
			{
				queryStringBuilder.AddParameter(IncludeParameterName, FormatIncludeValue(includes));
			}
			if (includeAll.HasValue && includeAll.Value)
			{
				queryStringBuilder.AddParameter(IncludeAllParameterName, includeAll);
			}
			else
			{
				if (page.HasValue)
				{
					queryStringBuilder.AddParameter(PageNumberParameterName, page);
				}
				if (pageSize.HasValue)
				{
					queryStringBuilder.AddParameter(PageSizeParameterName, pageSize);
				}
			}
			return pathAndQuery.Append(queryStringBuilder.QueryString).ToString();
		}

		/// <summary>
		/// Creates the path and query of a Smartsheet request with Paging
		/// </summary>
		/// <param name="path"> Such as "/folders/{folderId}" </param>
		/// <param name="includeAll"> whether to append includeAll=true to the query or not </param>
		/// <param name="page"> appends the page number to the query </param>
		/// <param name="pageSize"> appends the page size to the query </param>
		/// <returns> path and query </returns>
		public static string CreatePathAndQueryWithPaging(string path, bool? includeAll, long? page, long? pageSize)
		{
			StringBuilder pathAndQuery = new StringBuilder(path);
			QueryStringBuilder queryStringBuilder = new QueryStringBuilder();
			
			if (includeAll.HasValue && includeAll.Value)
			{
				queryStringBuilder.AddParameter(IncludeAllParameterName, includeAll);
			}
			else
			{
				if (page.HasValue)
				{
					queryStringBuilder.AddParameter(PageNumberParameterName, page);
				}
				if (pageSize.HasValue)
				{
					queryStringBuilder.AddParameter(PageSizeParameterName, pageSize);
				}
			}
			return pathAndQuery.Append(queryStringBuilder.QueryString).ToString();
		}

		/// <summary>
		/// Creates a comma-separated list of optional objects to include in the response
		/// </summary>
		/// <param name="inclusions"> Elements to be stringed together by commas. </param>
		/// <returns> Newly formated string to be appended in the query. </returns>
		public static string FormatIncludeValue<T>(IEnumerable<T> inclusions)
		{
			var includesArray = new List<string>();
			foreach (T element in inclusions)
			{
				includesArray.Add(element.ToString().ToLower());
			}
			return string.Join(",", includesArray);
		}
	}
}