//    #[license]
//    SmartsheetClient SDK for C#
//    %%
//    Copyright (C) 2018 SmartsheetClient
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
using System.Linq;
using System.Text;
using Smartsheet.Api.Models;

namespace Smartsheet.Api
{
    public interface SheetCrossSheetReferenceResources
    {
        /// <summary>
        /// <para>Gets all cross-sheet references for this sheet.</para>
        /// <para>Mirrors to the following Smartsheet REST API method: POST /sheets/{sheetId}/crosssheetreferences</para>
        /// </summary>
        /// <param name="sheetId"> the Id of the sheet </param>
        /// <param name="pagination"> the pagination parameters </param>
        /// <returns> a list of cross-sheet references </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        PaginatedResult<CrossSheetReference> ListCrossSheetReferences(long sheetId, PaginationParameters paging);

        /// <summary>
        /// <para>Gets a cross-sheet reference for this sheet.</para>
        /// <para>Mirrors to the following Smartsheet REST API method: 
        /// GET /sheets/{sheetId}/crosssheetreferences/{crosssheetreferenceId}</para>
        /// </summary>
        /// <param name="sheetId"> the Id of the sheet </param>
        /// <param name="crossSheetReferenceId"> the cross-sheet reference Id </param>
        /// <returns> the cross-sheet reference </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        CrossSheetReference GetCrossSheetReference(long sheetId, long crossSheetReferenceId);

        /// <summary>
        /// <para>Creates a cross-sheet reference in the given sheet.</para>
        /// <para>Mirrors to the following Smartsheet REST API method: POST /sheets/{sheetId}/crosssheetreferences</para>
        /// </summary>
        /// <param name="sheetId"> the Id of the sheet </param>
        /// <param name="crossSheetReference"> the cross-sheet reference </param>
        /// <returns> the cross-sheet reference </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        CrossSheetReference CreateCrossSheetReference(long sheetId, CrossSheetReference crossSheetReference);
    }
}
