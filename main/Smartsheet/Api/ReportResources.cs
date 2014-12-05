//    #[license]
//    SmartsheetClient SDK for C#
//    %%
//    Copyright (C) 2014 Dumitru-Bogdan Sireteanu
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
using System.Collections.Generic;
using Smartsheet.Api.Models;

namespace Smartsheet.Api
{
    public interface ReportResources
    {

        /// <summary>
        /// <para>List all Reports.</para>
        /// 
        /// <para>It mirrors To the following Smartsheet REST API method: GET /Reports</para>
        /// </summary>
        /// <returns> A list of all Reports (note that an empty list will be returned if there are none). </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        IList<Report> ListReports();


        /// <summary>
        /// <para>Get a report.</para>
        /// 
        /// <para>It mirrors To the following Smartsheet REST API method: GET GET /report/{reportId}</para>
        /// </summary>
        /// <remarks>This method returns the top 100 rows. To get more or less rows please use the other overloaded versions of this method</remarks>
        /// <param name="id"> the Id of the report </param>
        /// <param name="includes"> used To specify the optional objects To include. </param>
        /// <returns> the report resource (note that if there is no such resource, this method will throw 
        /// ResourceNotFoundException rather than returning null). </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        Report GetReport(long id, IEnumerable<ObjectInclusion> includes);


        /// <summary>
        /// <para>Get a report.</para>
        /// 
        /// <para>It mirrors To the following Smartsheet REST API method: GET GET /report/{reportId}</para>
        /// </summary>
        /// <param name="id"> the Id of the report </param>
        /// <param name="includes"> used To specify the optional objects To include. </param>
        /// <param name="pageSize">This operation will return a minimum of 1 row, and a maximum of 500.  If not specified, the default value is 100.</param>
        /// <returns> the report resource (note that if there is no such resource, this method will throw 
        /// ResourceNotFoundException rather than returning null). </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        Report GetReport(long id, IEnumerable<ObjectInclusion> includes, int pageSize);

        /// <summary>
        /// <para>Get a report.</para>
        /// 
        /// <para>It mirrors To the following Smartsheet REST API method: GET GET /report/{reportId}</para>
        /// </summary>
        /// <param name="id"> the Id of the report </param>
        /// <param name="includes"> used To specify the optional objects To include. </param>
        /// <param name="pageNo">Which page number (0-based) to return. If a page number is specified that is greater than the number of total pages, the last page will be returned</param>
        /// <param name="pageSize">This operation will return a minimum of 1 row, and a maximum of 500.  If not specified, the default value is 100.</param>
        /// <returns> the report resource (note that if there is no such resource, this method will throw 
        /// ResourceNotFoundException rather than returning null). </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        Report GetReport(long id, IEnumerable<ObjectInclusion> includes, int pageNo, int pageSize);

    }
}
