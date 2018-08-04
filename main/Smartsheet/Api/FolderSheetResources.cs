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
    using Api.Models;

    /// <summary>
    /// <para>This interface provides methods to access sheet resources that are associated to a Folder object.</para>
    /// 
    /// <para>Thread Safety: Implementation of this interface must be thread safe.</para>
    /// </summary>
    public interface FolderSheetResources
    {
        /// <summary>
        /// <para>Creates a sheet from scratch in the specified folder.</para>
        /// 
        /// <para>Mirrors to the following Smartsheet REST API method: POST /folders/{folderId}/sheets</para>
        /// </summary>
        /// <param name="folderId"> the folder Id </param>
        /// <param name="sheet"> the sheet to create </param>
        /// <returns> the created sheet </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        Sheet CreateSheet(long folderId, Sheet sheet);

        /// <summary>
        /// <para> Creates a sheet in the specified folder, from the specified template. </para>
        /// <para>Mirrors to the following Smartsheet REST API method: POST /folders/{folderId}/sheets</para>
        /// </summary>
        /// <param name="folderId"> the folder Id </param>
        /// <param name="sheet"> the sheet to create </param>
        /// <param name="includes"> used to specify the optional objects to include </param>
        /// <returns> the created sheet </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        Sheet CreateSheetFromTemplate(long folderId, Sheet sheet, IEnumerable<TemplateInclusion> includes = null);

        /// <summary>
        /// <para>Imports a sheet in the specified folder (from CSV). </para>
        /// <para>Mirrors to the following Smartsheet REST API method: POST /folders/{folderId}/sheets/import</para>
        /// </summary>
        /// <param name="folderId"> the folder Id </param>
        /// <param name="file"> path to the CSV file</param>
        /// <param name="sheetName"> destination sheet name </param>
        /// <param name="headerRowIndex"> index (0 based) of row to be used for column names </param>
        /// <param name="primaryColumnIndex"> index (0 based) of primary column </param>
        /// <returns> the created sheet </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        Sheet ImportCsvSheet(long folderId, string file, string sheetName = null, int? headerRowIndex = null, int? primaryColumnIndex = null);

        /// <summary>
        /// <para>Imports a sheet in the specified folder (from XLSX). </para>
        /// <para>Mirrors to the following Smartsheet REST API method: POST /folders/{folderId}/sheets/import</para>
        /// </summary>
        /// <param name="folderId"> the folder Id </param>
        /// <param name="file"> path to the XLSX file</param>
        /// <param name="sheetName"> destination sheet name </param>
        /// <param name="headerRowIndex"> index (0 based) of row to be used for column names </param>
        /// <param name="primaryColumnIndex"> index (0 based) of primary column </param>
        /// <returns> the created sheet </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        Sheet ImportXlsSheet(long folderId, string file, string sheetName = null, int? headerRowIndex = null, int? primaryColumnIndex = null);
    }
}
