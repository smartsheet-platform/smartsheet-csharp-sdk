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
using System.Text;
using Smartsheet.Api.Internal.Utility;
using Smartsheet.Api.Models;

namespace Smartsheet.Api.Internal
{
	/// <summary>
	///     This is the implementation of the ReportResources.
	///     Thread Safety: This class is thread safe because it is immutable and its base class is thread safe.
	/// </summary>
	public class ReportResourcesImpl : AbstractResources, ReportResources
	{
		private const string PageSizeParameterName = "pageSize";
		private const string PageNumberParameterName = "page";
		private const string IncludeParameterName = "include";
		private const string ReportBaseUri = "report/";


		/// <summary>
		///     Constructor.
		///     Exceptions: - IllegalArgumentException : if any argument is
		/// </summary>
		/// <param name="smartsheet"> the Smartsheet </param>
		public ReportResourcesImpl(SmartsheetImpl smartsheet) : base(smartsheet)
		{
		}

		/// <summary>
		///     Get a sheet.
		///     It mirrors To the following Smartsheet REST API method: GET /report/{reportId}
		///     Exceptions:
		///     - InvalidRequestException : if there is any problem with the REST API request
		///     - AuthorizationException : if there is any problem with the REST API authorization(access token)
		///     - ResourceNotFoundException : if the resource can not be found
		///     - ServiceUnavailableException : if the REST API service is not available (possibly due To rate limiting)
		///     - SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///     - SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="id"> the Id of the report </param>
		/// <param name="includes">
		///     used To specify the optional objects To include, currently DISCUSSIONS and
		///     ATTACHMENTS are supported.
		/// </param>
		/// <returns>
		///     the resource (note that if there is no such resource, this method will throw ResourceNotFoundException
		///     rather than returning null).
		/// </returns>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
		public virtual Report GetReport(long id, IEnumerable<ObjectInclusion> includes)
		{
			StringBuilder path = GetReportUri(id);
			if (includes != null)
			{
				var queryStringBuilder = new QueryStringBuilder();
				queryStringBuilder.AddParameter(IncludeParameterName, FormatIncludeValue(includes));
				path.Append(queryStringBuilder.QueryString);
			}
			return GetResource<Report>(path.ToString(), typeof (Report));
		}


		/// <summary>
		///     <para>Get a report.</para>
		///     <para>It mirrors To the following Smartsheet REST API method: GET GET /report/{reportId}</para>
		/// </summary>
		/// <param name="id"> the Id of the report </param>
		/// <param name="includes"> used To specify the optional objects To include. </param>
		/// <param name="pageSize">
		///     This operation will return a minimum of 1 row, and a maximum of 500.  If not specified, the
		///     default value is 100.
		/// </param>
		/// <returns>
		///     the report resource (note that if there is no such resource, this method will throw
		///     ResourceNotFoundException rather than returning null).
		/// </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual Report GetReport(long id, IEnumerable<ObjectInclusion> includes, int pageSize)
		{
			if (pageSize <= 0 && pageSize > 500)
			{
				throw new SmartsheetException(new ArgumentOutOfRangeException("pageSize", "Must be between 1 and 500"));
			}

			StringBuilder path = GetReportUri(id);
			var queryStringBuilder = new QueryStringBuilder();
			if (includes != null)
			{
				queryStringBuilder.AddParameter(IncludeParameterName, FormatIncludeValue(includes));
			}
			queryStringBuilder.AddParameter(PageSizeParameterName, pageSize);
			path.Append(queryStringBuilder.QueryString);
			return GetResource<Report>(path.ToString(), typeof (Report));
		}


		/// <summary>
		///     <para>Get a report.</para>
		///     <para>It mirrors To the following Smartsheet REST API method: GET GET /report/{reportId}</para>
		/// </summary>
		/// <param name="id"> the Id of the report </param>
		/// <param name="includes"> used To specify the optional objects To include. </param>
		/// <param name="pageNo">
		///     Which page number (0-based) to return. If a page number is specified that is greater than the
		///     number of total pages, the last page will be returned
		/// </param>
		/// <param name="pageSize">
		///     This operation will return a minimum of 1 row, and a maximum of 500.  If not specified, the
		///     default value is 100.
		/// </param>
		/// <returns>
		///     the report resource (note that if there is no such resource, this method will throw
		///     ResourceNotFoundException rather than returning null).
		/// </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual Report GetReport(long id, IEnumerable<ObjectInclusion> includes, int pageNo, int pageSize)
		{
			if (pageNo <=0)
			{
				throw new SmartsheetException(new ArgumentOutOfRangeException("pageNo", "Must be greather than 0"));
			}
			if (pageSize <= 0 && pageSize > 500)
			{
				throw new SmartsheetException(new ArgumentOutOfRangeException("pageSize", "Must be between 1 and 500")); 
			}
			StringBuilder path = GetReportUri(id);
			var queryStringBuilder = new QueryStringBuilder();
			if (includes != null)
			{
				queryStringBuilder.AddParameter(IncludeParameterName, FormatIncludeValue(includes));
			}
			queryStringBuilder.AddParameter(PageSizeParameterName, pageSize);
			queryStringBuilder.AddParameter(PageNumberParameterName, pageNo);
			path.Append(queryStringBuilder.QueryString);
			return GetResource<Report>(path.ToString(), typeof (Report));
		}

		private static StringBuilder GetReportUri(long id)
		{
			return new StringBuilder(ReportBaseUri + id);
		}

		/// <summary>
		/// Creates a comma-separated list of optional objects to include in the response
		/// </summary>
		/// <param name="inclusions"></param>
		/// <returns></returns>
		private static string FormatIncludeValue(IEnumerable<ObjectInclusion> inclusions)
		{
			var includesArray = new List<string>();
			foreach (ObjectInclusion objectInclusion in inclusions)
			{
				includesArray.Add(objectInclusion.ToString().ToLower());
			}
			return string.Join(",", includesArray);
		}

	}
}