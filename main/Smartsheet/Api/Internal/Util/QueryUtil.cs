using RestSharp.Contrib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Smartsheet.Api.Internal.Util
{
	/// <summary>
	/// Generates string queries.
	/// </summary>
	public static class QueryUtil
	{
		//public QueryUtil() { }

		/// <summary>
		/// <para>
		/// Generates a string of camelCase words each separated by a comma.
		/// </para>
		/// <para>
		/// For example, an input array of {DISCUSSIONS, COLUMN_TYPE} would output a string of "discussions,columnType".
		/// </para>
		/// </summary>
		/// <typeparam name="T">The Type of the list</typeparam>
		/// <param name="include">the list of object</param>
		/// <returns>the comma separated list of words</returns>
		public static string GenerateCommaSeparatedList<T>(IEnumerable<T> include)
		{
			if (include == null)
			{
				return string.Empty;
			}

			Regex regex = new Regex(@"[^_]+");
			List<string> includesList = new List<string>();
			foreach (T element in include)
			{
				// Converts the enum members to camel case to be passed in the url as a parameter.
				// For example, 'COLUMN_TYPE' becomes 'columnType' and is appended to the path.
				// Different from JsonEnymTypeConverter because this does not involve serialization/deserialization.
				MatchCollection matches = regex.Matches(element.ToString());
				List<string> values = new List<string>();
				foreach (Match match in matches)
				{
					if (values.Count == 0)
					{
						values.Add(match.Value.ToLower());
					}
					else
					{
						values.Add(match.Value.Substring(0, 1).ToUpper() + match.Value.Substring(1).ToLower());
					}
				}
				includesList.Add(string.Join(string.Empty, values));
			}
			return string.Join(",", includesList);
		}

		/// <summary>
		/// Generates a url based on the baseUrl and parameters.
		/// </summary>
		/// <param name="baseUrl">the baseUrl</param>
		/// <param name="parameters">the parameters</param>
		/// <returns>the generated url</returns>
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
		
		/// <summary>
		/// Generates a query string.
		/// </summary>
		/// <param name="parameters">the map of query string keys and values</param>
		/// <returns>the qery string</returns>
		public static string GenerateQueryString(IDictionary<string, string> parameters)
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
