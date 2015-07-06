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

using RestSharp.Contrib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smartsheet.Api.Internal.Util
{
	public class QueryUtil
	{
		public QueryUtil() { }

		public static string GenerateCommaSeparatedList<T>(IEnumerable<T> include)
		{
			if (include == null)
			{
				return string.Empty;
			}

			List<string> includesList = new List<string>();
			foreach (T element in include)
			{
				includesList.Add(element.ToString());
			}
			return string.Join(",", includesList);
		}

		public static string GenerateUrl(string baseUrl, IDictionary<string, string> parameters)
		{
			if (baseUrl == null)
			{
				baseUrl = string.Empty;
			}

			StringBuilder result = new StringBuilder();
			result.Append(baseUrl);
			result.Append(GenerateQueryString(parameters));

			return result.ToString();
		}

		/**
		 * Returns a query string.
		 *
		 * @param parameters the map of query string keys and values
		 * @return the query string
		 */
		protected static string GenerateQueryString(IDictionary<string, string> parameters)
		{
			StringBuilder result = new StringBuilder();

			if (parameters == null)
			{
				return result.ToString();
			}
			else
			{
				try
				{
					foreach (KeyValuePair<string, string> entry in parameters)
					{
						if (result.Length == 0)
						{
							result.Append("?");
						}
						else
						{
							result.Append("&");
						}
						result.Append(HttpUtility.UrlEncode(entry.Key, Encoding.UTF8));
						result.Append("=");

						if (entry.Value != null)
						{
							result.Append(HttpUtility.UrlEncode(entry.Value, Encoding.UTF8));
						}
					}
				}
				catch (EncoderFallbackException e)
				{
					throw new SystemException(e.Message);
				}

				return result.ToString();
			}
		}
	}
}
