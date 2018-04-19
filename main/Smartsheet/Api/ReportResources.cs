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
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//    %[license]
using System.Collections.Generic;
using Smartsheet.Api.Models;
using System.IO;
using System;

namespace Smartsheet.Api
{
	/// <summary>
	/// <para>This interface provides methods to access Report resources.</para>
	/// 
	/// <para>Thread Safety: Implementation of this interface must be thread safe.</para>
	/// </summary>
	public interface ReportResources
	{

		/// <summary>
		/// <para>Gets the Report, including one page of Rows, and optionally populated with Discussions, Attachments, and source Sheets.</para>
		/// <para>It mirrors to the following Smartsheet REST API method: GET /reports/{reportId}</para>
		/// </summary>
		/// <remarks>This method returns the top 100 rows. To get more or less rows please use the other overloaded versions of this method</remarks>
		/// <param name="reportId"> the Id of the report </param>
		/// <param name="include"> used to specify the optional objects to include. </param>
		/// <param name="pageSize">(optional): Number of rows per page. If not specified, the default value is 100.
		/// This operation can return a maximum of 500 rows per page.</param>
		/// <param name="page">(optional): Which page number (1-based) to return. 
		/// If not specified, the default value is 1. If a page number is specified that is greater than the number of total pages, the last page will be returned.</param>
		/// <returns> the report resource (note that if there is no such resource, this method will throw 
		/// ResourceNotFoundException rather than returning null). </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		Report GetReport(long reportId, IEnumerable<ReportInclusion> include, int? pageSize, int? page);

        /// <summary>
        /// <para>Gets the list of all Reports that the User has access to, in alphabetical order, by name.</para>
        /// <para>It mirrors to the following Smartsheet REST API method: GET /reports</para>
        /// </summary>
        /// <param name="paging">the pagination</param>
        /// <param name="modifiedSince">restrict results to reports modified on or after the specified date</param>
        /// <returns>A list of Report objects limited to the following attributes:
        /// <list type="bullet">
        /// <item><description>id</description></item>
        /// <item><description>name</description></item>
        /// <item><description>accessLevel</description></item>
        /// <item><description>permalink</description></item>
        /// </list></returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        PaginatedResult<Report> ListReports(PaginationParameters paging, DateTime? modifiedSince = null);

		/// <summary>
		/// <para>Gets the Report in the format specified, based on the Report ID.</para>
		/// <para>It mirrors to the following Smartsheet REST API method:<br />
		/// GET /reports/{reportId} with "application/vnd.ms-excel" Accept HTTP header</para>
		/// </summary>
		/// <param name="reportId"> the Id of the report </param>
		/// <param name="outputStream"> the output stream to which the Excel file will be written. </param>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		void GetReportAsExcel(long reportId, BinaryWriter outputStream);

		/// <summary>
		/// <para>Get a report as a CSV file.</para>
		/// 
		/// <para>It mirrors to the following Smartsheet REST API method:<br />
		/// GET /reports/{reportId} with "text/csv" Accept HTTP header</para>
		/// </summary>
		/// <param name="reportId"> the Id of the report </param>
		/// <param name="outputStream"> the output stream to which the Excel file will be written. </param>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		void GetReportAsCSV(long reportId, BinaryWriter outputStream);

		/// <summary>
		/// <para>Send a report as a PDF attachment via Email to the designated recipients.</para>
		/// 
		/// <para>It mirrors to the following Smartsheet REST API method: POST /reports/{reportId}/emails</para>
		/// </summary>
		/// <param name="reportId"> the reportId </param>
		/// <param name="email"> the Email </param>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		void SendReport(long reportId, SheetEmail email);

		/// <summary>
		/// <para>Get the publish status of a report.</para>
		/// 
		/// <para>It mirrors to the following Smartsheet REST API method: GET /reports/{id}/publish</para>
		/// </summary>
		/// <param name="reportId"> the reportId </param>
		/// <returns>
		/// The report publish status (note that if there is no such resource, this method will 
		/// throw ResourceNotFoundException rather than returning null).
		/// </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		ReportPublish GetPublishStatus(long reportId);

		/// <summary>
		/// <para>
		/// Sets the publish status of a report and returns the new status, including the URLs of any enabled publishing.
		/// </para>
		/// 
		/// <para>It mirrors to the following Smartsheet REST API method: PUT /reports/{id}/publish</para>
		/// </summary>
		/// <param name="reportId"> the reportId </param>
		/// <param name="reportPublish"> the ReportPublish object</param>
		/// <returns>
		/// The report publish status (note that if there is no such resource, this method will 
		/// throw ResourceNotFoundException rather than returning null).
		/// </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		ReportPublish UpdatePublishStatus(long reportId, ReportPublish reportPublish);

		/// <summary>
		/// <para>Return the ShareResources object that provides access to Share resources associated with Report resources.</para>
		/// </summary>
		/// <returns> the share resources object </returns>
		ShareResources ShareResources { get; }
	}
}
