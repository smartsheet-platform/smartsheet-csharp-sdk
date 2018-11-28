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
using System;
using System.Collections.Generic;
using System.Text;
using Smartsheet.Api.Internal.Utility;
using Smartsheet.Api.Models;
using Smartsheet.Api.Internal.Util;
using System.IO;
using Smartsheet.Api.Internal.Http;
using System.Net;

namespace Smartsheet.Api.Internal
{
    /// <summary>
    ///     This is the implementation of the ReportResources.
    ///     Thread Safety: This class is thread safe because it is immutable and its base class is thread safe.
    /// </summary>
    public class ReportResourcesImpl : AbstractResources, ReportResources
    {
        /// <summary>
        /// Represents the ShareResources.
        /// 
        /// It will be initialized in constructor and will not change afterwards.
        /// </summary>
        private ShareResources shares;

        /// <summary>
        /// Constructor.
        /// 
        /// Exceptions: - IllegalArgumentException : if any argument is null
        /// </summary>
        /// <param name="smartsheet"> the Smartsheet </param>
        public ReportResourcesImpl(SmartsheetImpl smartsheet)
            : base(smartsheet)
        {
            this.shares = new ShareResourcesImpl(smartsheet, "reports");
        }

        /// <summary>
        /// <para>Gets the Report, including one page of Rows, and optionally populated with Discussions, Attachments, and source Sheets.</para>
        /// <para>It mirrors to the following Smartsheet REST API method: GET /reports/{reportId}</para>
        /// </summary>
        /// <remarks>This method returns the top 100 rows. To get more or less rows please use the other overloaded versions of this method</remarks>
        /// <param name="reportId"> the Id of the report </param>
        /// <param name="includes"> used to specify the optional objects to include. </param>
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
        public virtual Report GetReport(long reportId, IEnumerable<ReportInclusion> includes, int? pageSize, int? page)
        {
            return GetReport(reportId, includes, pageSize, page, null);
        }

        /// <summary>
        /// <para>Gets the Report, including one page of Rows, and optionally populated with Discussions, Attachments, and source Sheets.</para>
        /// <para>It mirrors to the following Smartsheet REST API method: GET /reports/{reportId}</para>
        /// </summary>
        /// <remarks>This method returns the top 100 rows. To get more or less rows please use the other overloaded versions of this method</remarks>
        /// <param name="reportId"> the Id of the report </param>
        /// <param name="includes"> used to specify the optional objects to include. </param>
        /// <param name="pageSize">(optional): Number of rows per page. If not specified, the default value is 100.
        /// This operation can return a maximum of 500 rows per page.</param>
        /// <param name="page">(optional): Which page number (1-based) to return. 
        /// If not specified, the default value is 1. If a page number is specified that is greater than the number of total pages, the last page will be returned.</param>
        /// <param name="level"> compatibility level </param>
        /// <returns> the report resource (note that if there is no such resource, this method will throw 
        /// ResourceNotFoundException rather than returning null). </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual Report GetReport(long reportId, IEnumerable<ReportInclusion> includes, int? pageSize, int? page, int? level)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            if (includes != null)
            {
                parameters.Add("include", QueryUtil.GenerateCommaSeparatedList(includes));
            }
            if (pageSize != null)
            {
                parameters.Add("pageSize", pageSize.ToString());
            }
            if (page != null)
            {
                parameters.Add("page", page.ToString());
            }
            if (level != null)
            {
                parameters.Add("level", level.ToString());
            }

            return this.GetResource<Report>(QueryUtil.GenerateUrl("reports/" + reportId, parameters), typeof(Report));
        }

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
        public virtual PaginatedResult<Report> ListReports(PaginationParameters paging, DateTime? modifiedSince)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            if (paging != null)
            {
                parameters = paging.toDictionary();
            }
            if (modifiedSince != null)
            {
                parameters.Add("modifiedSince", ((DateTime)modifiedSince).ToUniversalTime().ToString("o"));
            }

            return this.ListResourcesWithWrapper<Report>("reports" + QueryUtil.GenerateUrl(null, parameters));
        }

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
        public virtual void GetReportAsExcel(long reportId, BinaryWriter outputStream)
        {
            GetReportAsFile("reports/" + reportId, outputStream, "application/vnd.ms-excel");
        }

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
        public virtual void GetReportAsCSV(long reportId, BinaryWriter outputStream)
        {
            GetReportAsFile("reports/" + reportId, outputStream, "text/csv");
        }

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
        public virtual void SendReport(long reportId, SheetEmail email)
        {
            this.CreateResource<SheetEmail>("reports/" + reportId + "/emails", typeof(SheetEmail), email);
        }

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
        public ReportPublish GetPublishStatus(long reportId)
        {
            return this.GetResource<ReportPublish>("reports/" + reportId + "/publish", typeof(ReportPublish));
        }

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
        public ReportPublish UpdatePublishStatus(long reportId, ReportPublish reportPublish)
        {
            return this.UpdateResource<ReportPublish>("reports/" + reportId + "/publish", typeof(ReportPublish), reportPublish);
        }

        /// <summary>
        /// <para>Return the ShareResources object that provides access to Share resources associated with Report resources.</para>
        /// </summary>
        /// <returns> the ShareResources object </returns>
        public virtual ShareResources ShareResources
        {
            get
            {
                return this.shares;
            }
        }

        /// <summary>
        /// <para>Get a sheet as a file.</para>
        /// 
        /// <para>It mirrors to the following Smartsheet REST API method:<br />
        /// GET /reports/{reportId} with "application/pdf", "application/vnd.ms-excel", or "text/csv" as Accept HTTP header</para>
        /// </summary>
        /// <param name="path">the path of the file</param>
        /// <param name="outputStream"> the output stream to which the CSV file will be written. </param>
        /// <param name="contentType"> the Accept header </param>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        private void GetReportAsFile(string path, BinaryWriter outputStream, string contentType)
        {
            Utility.Utility.ThrowIfNull(path, outputStream, contentType);

            HttpRequest request = null;

            request = CreateHttpRequest(new Uri(this.Smartsheet.BaseURI, path), HttpMethod.GET);
            request.Headers["Accept"] = contentType;

            Api.Internal.Http.HttpResponse response = Smartsheet.HttpClient.Request(request);

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    try
                    {
                        response.Entity.GetBinaryContent().BaseStream.CopyTo(outputStream.BaseStream);
                    }
                    catch (IOException e)
                    {
                        throw new SmartsheetException(e);
                    }
                    break;
                default:
                    HandleError(response);
                    break;
            }

            Smartsheet.HttpClient.ReleaseConnection();
        }
    }
}