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

using Smartsheet.Api.Internal.Util;
using Smartsheet.Api.Internal.Http;
using Smartsheet.Api.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;

namespace Smartsheet.Api.Internal
{
    /// <summary>
    /// This is the implementation of the RowColumnResources.
    /// 
    /// Thread Safety: This class is thread safe because it is immutable and its base class is thread safe.
    /// </summary>
    public class RowColumnResourcesImpl : AbstractResources, RowColumnResources
    {
        /// <summary>
        /// Constructor.
        /// 
        /// Exceptions: - IllegalArgumentException : if any argument is null
        /// </summary>
        /// <param name="smartsheet"> the Smartsheet </param>
        public RowColumnResourcesImpl(SmartsheetImpl smartsheet)
            : base(smartsheet)
        {
        }

        /// <summary>
        /// <para>Gets the cell modification history.</para>
        /// <para>Mirrors to the following Smartsheet REST API method: GET /sheets/{sheetId}/rows/{rowId}/columns/{columnId}/history</para>
        /// <remarks><para>This operation supports pagination of results. For more information, see Paging.</para>
        /// <para>This is a resource-intensive operation and incurs 10 additional requests against the rate limit.</para></remarks>
        /// </summary>
        /// <param name="sheetId"> the sheet Id </param>
        /// <param name="rowId"> the row Id </param>
        /// <param name="columnId"> the column Id</param>
        /// <param name="include"> the elements to include in the response </param>
        /// <param name="paging"> the pagination </param>
        /// <returns> the row object </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual PaginatedResult<CellHistory> GetCellHistory(long sheetId, long rowId, long columnId, IEnumerable<CellInclusion> include, PaginationParameters paging)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            if (paging != null)
            {
                parameters = paging.toDictionary();
            }
            if (include != null)
            {
                parameters.Add("include", Util.QueryUtil.GenerateCommaSeparatedList(include));
            }
            return this.ListResourcesWithWrapper<CellHistory>(QueryUtil.GenerateUrl("sheets/" + sheetId + "/rows/" + rowId + "/columns/" + columnId + "/history", parameters));
        }

        /// <summary>
        /// <para>Uploads an image to the specified cell within a sheet.</para>
        /// <para>Mirrors to the following Smartsheet REST API method: POST /sheets/{sheetId}/rows/{rowId}/columns/{columnId}/cellimages</para>
        /// </summary>
        /// <param name="sheetId"> the sheet Id </param>
        /// <param name="rowId"> the row Id </param>
        /// <param name="columnId"> the column Id</param>
        /// <param name="file"> the file path </param>
        /// <param name="fileType"> the file type </param>
        /// <returns> the Row object </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual void AddImageToCell(long sheetId, long rowId, long columnId, string file, string fileType)
        {
            AddImage("sheets/" + sheetId + "/rows/" + rowId + "/columns/" + columnId + "/cellimages", file, fileType, false, null);
        }

        /// <summary>
        /// <para>Uploads an image to the specified cell within a sheet.</para>
        /// <para>Mirrors to the following Smartsheet REST API method: POST /sheets/{sheetId}/rows/{rowId}/columns/{columnId}/cellimages</para>
        /// </summary>
        /// <param name="sheetId"> the sheet Id </param>
        /// <param name="rowId"> the row Id </param>
        /// <param name="columnId"> the column Id</param>
        /// <param name="file"> the file path </param>
        /// <param name="fileType"> the file type </param>
        /// <param name="overrideValidation"></param>
        /// <param name="altText"> alt text for image </param>
        /// <returns> the Row object </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual void AddImageToCell(long sheetId, long rowId, long columnId, string file, string fileType, 
            bool overrideValidation, string altText)
        {
            AddImage("sheets/" + sheetId + "/rows/" + rowId + "/columns/" + columnId + "/cellimages", file, fileType,
                overrideValidation, altText);
        }

        /// <summary>
        /// Attach file.
        /// </summary>
        /// <param name="path"> the url path </param>
        /// <param name="file"> the file </param>
        /// <param name="contentType"> the content Type </param>
        /// <param name="overrideValidation"> override column validation </param>
        /// <param name="altText"> image alternate text </param>
        /// <returns> the attachment </returns>
        /// <exception cref="FileNotFoundException"> the file not found exception </exception>
        /// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
        private void AddImage(string path, string file, string contentType, bool overrideValidation, string altText)
        {
            Utility.Utility.ThrowIfNull(file);

            if (contentType == null)
            {
                contentType = "application/octet-stream";
            }

            IDictionary<string, string> parameters = new Dictionary<string, string>();
            if (altText != null)
            {
                parameters.Add("altText", altText);
            }
            if(overrideValidation)
            {
                parameters.Add("overrideValidation", "true");
            }

            path = QueryUtil.GenerateUrl(path, parameters);

            FileInfo fi = new FileInfo(file);
            HttpRequest request = CreateHttpRequest(new Uri(this.Smartsheet.BaseURI, path), HttpMethod.POST);

            request.Headers["Content-Disposition"] = "attachment; filename=\"" + fi.Name + "\"";

            HttpEntity entity = new HttpEntity();
            entity.ContentType = contentType;

            entity.Content = File.ReadAllBytes(file);
            entity.ContentLength = fi.Length;
            request.Entity = entity;

            HttpResponse response = this.Smartsheet.HttpClient.Request(request);

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    break;
                default:
                    HandleError(response);
                    break;
            }

            this.Smartsheet.HttpClient.ReleaseConnection();
        }
    }
}
