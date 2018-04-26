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

namespace Smartsheet.Api
{
    using Smartsheet.Api.Models;
    using Column = Api.Models.Column;

    /// <summary>
    /// <para>This interface provides methods to access column resources that are associated to a sheet object.</para>
    /// 
    /// <para>Thread Safety: Implementation of this interface must be thread safe.</para>
    /// </summary>
    public interface SheetColumnResources
    {
        /// <summary>
        /// <para>Gets a list of all Columns belonging to the Sheet specified in the URL.</para>
        /// <para>It mirrors to the following Smartsheet REST API method: GET /sheets/{sheetId}/columns</para>
        /// <remarks>This operation supports pagination of results. For more information, see Paging.</remarks>
        /// </summary>
        /// <param name="sheetId"> the sheet Id </param>
        /// <param name="include">elements to include in response</param>
        /// <param name="paging">the paging</param>
        /// <returns> the list of Columns (note that an empty list will be returned if there is none) </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        PaginatedResult<Column> ListColumns(long sheetId, IEnumerable<ColumnInclusion> include, PaginationParameters paging);

        /// <summary>
        /// <para>Inserts one or more columns into the Sheet specified in the URL.</para>
        /// 
        /// <para>It mirrors to the following Smartsheet REST API method: POST /sheets/{sheetId}/Columns</para>
        /// </summary>
        /// <param name="sheetId"> the sheet Id </param>
        /// <param name="columns"> the column object(s) </param>
        /// <returns> the created column </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        IList<Column> AddColumns(long sheetId, IEnumerable<Column> columns);

        /// <summary>
        /// <para>Deletes the Column specified in the URL.</para>
        /// 
        /// <para>It mirrors to the following Smartsheet REST API method: DELETE /sheets/{sheetId}/columns/{columnId}</para>
        /// </summary>
        /// <param name="sheetId"> the sheet Id </param>
        /// <param name="columnId"> the column object </param>
        /// <returns> the created column </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        void DeleteColumn(long sheetId, long columnId);

        /// <summary>
        /// <para>Gets the Column specified in the URL.</para>
        /// 
        /// <para>It mirrors to the following Smartsheet REST API method: GET /sheets/{sheetId}/columns/{columnId}</para>
        /// </summary>
        /// <param name="sheetId"> the sheet Id </param>
        /// <param name="columnId"> the columnId </param>
        /// <param name="include"> elements to include in response </param>
        /// <returns> the created column </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        Column GetColumn(long sheetId, long columnId, IEnumerable<ColumnInclusion> include);


        /// <summary>
        /// <para>Updates properties of the column, moves the column, and/or renames the column.</para>
        /// <para>You cannot change the type of a Primary column.</para>
        /// <para>While dependencies are enabled on a sheet, you can’t change the type of any special calendar/Gantt columns.</para>        
        /// <para>If the column type is changed, all cells in the column will be converted to the new column type.</para>
        /// <para>Type is optional when moving or renaming, but required when changing type or dropdown values.</para>
        /// <para>It mirrors to the following Smartsheet REST API method: GET /sheets/{sheetId}/columns/{columnId}</para>
        /// </summary>
        /// <param name="sheetId"> the sheet Id </param>
        /// <param name="column"> column object to update </param>
        /// <returns> the updated column </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        Column UpdateColumn(long sheetId, Column column);
    }

}