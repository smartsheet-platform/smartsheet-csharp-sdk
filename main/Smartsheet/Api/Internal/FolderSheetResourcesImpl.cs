﻿//    #[license]
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

using System.Collections.Generic;

namespace Smartsheet.Api.Internal
{
	using Api.Models;
	using Smartsheet.Api.Internal.Util;
	using System.Text;
	using System.IO;

	/// <summary>
	/// This is the implementation of the FolderSheetResources.
	/// 
	/// Thread Safety: This class is thread safe because it is immutable and its base class is thread safe.
	/// </summary>
	public class FolderSheetResourcesImpl : AbstractResources, FolderSheetResources
	{
		/// <summary>
		/// Constructor.
		/// 
		/// Exceptions: - IllegalArgumentException : if any argument is
		/// </summary>
		/// <param name="smartsheet"> the Smartsheet </param>
		public FolderSheetResourcesImpl(SmartsheetImpl smartsheet)
			: base(smartsheet)
		{
		}

		/// <summary>
		/// <para>Creates a Sheet from scratch in the specified Folder.</para>
		/// 
		/// <para>It mirrors To the following Smartsheet REST API method: POST /folders/{folderId}/sheets</para>
		/// </summary>
		/// <param name="folderId"> the folder Id </param>
		/// <param name="sheet"> the sheet To create </param>
		/// <returns> the created sheet </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual Sheet CreateSheet(long folderId, Sheet sheet)
		{
			return this.CreateResource<Sheet>("folders/" + folderId + "/sheets", typeof(Sheet), sheet);
		}

		/// <summary>
		/// <para> Creates a Sheet in the specified Folder, from the specified Template. </para>
		/// <para>It mirrors To the following Smartsheet REST API method: POST /folders/{folderId}/sheets</para>
		/// </summary>
		/// <param name="folderId"> the folder Id </param>
		/// <param name="sheet"> the sheet To create </param>
		/// <param name="includes"> used To specify the optional objects To include </param>
		/// <returns> the created sheet </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual Sheet CreateSheetFromTemplate(long folderId, Sheet sheet, IEnumerable<TemplateInclusion> includes)
		{
			StringBuilder path = new StringBuilder("folders/" + folderId + "/sheets");
			if (includes != null)
			{
				path.Append("?include=" + QueryUtil.GenerateCommaSeparatedList(includes));
			}
			return this.CreateResource(path.ToString(), typeof(Sheet), sheet);
		}

		/// <summary>
		/// <para>Imports a Sheet in the specified Folder (from CSV). </para>
		/// <para>It mirrors To the following Smartsheet REST API method: POST /folders/{folderId}/sheets/import</para>
		/// </summary>
		/// <param name="folderId"> the folder Id </param>
		/// <param name="file"> path to the image file</param>
		/// <param name="sheetName"></param>
		/// <param name="headerRowIndex"></param>
		/// <param name="primaryColumnIndex"></param>
		/// <returns> the created sheet </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual Sheet ImportCsvSheet(long folderId, string file, string sheetName, int? headerRowIndex, int? primaryColumnIndex)
		{
			return ImportSheet(folderId, file, sheetName, headerRowIndex, primaryColumnIndex, "text/csv");
		}

		/// <summary>
		/// <para>Imports a Sheet in the specified Folder (from XLSX). </para>
		/// <para>It mirrors To the following Smartsheet REST API method: POST /folders/{folderId}/sheets/import</para>
		/// </summary>
		/// <param name="folderId"> the folder Id </param>
		/// <param name="file"> path to the image file</param>
		/// <param name="sheetName"></param>
		/// <param name="headerRowIndex"></param>
		/// <param name="primaryColumnIndex"></param>
		/// <returns> the created sheet </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual Sheet ImportXlsSheet(long folderId, string file, string sheetName, int? headerRowIndex, int? primaryColumnIndex)
		{
			return ImportSheet(folderId, file, sheetName, headerRowIndex, primaryColumnIndex,
				"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
		}

		/// <summary>
		/// Private routine to import a Sheet of contentType into a Folder
		/// </summary>
		/// <param name="folderId"></param>
		/// <param name="file"></param>
		/// <param name="sheetName"></param>
		/// <param name="headerRowIndex"></param>
		/// <param name="primaryColumnIndex"></param>
		/// <param name="contentType"></param>
		/// <returns> the created sheet </returns>
		private Sheet ImportSheet(long folderId, string file, string sheetName, int? headerRowIndex, int? primaryColumnIndex, string contentType)
		{
			Utility.Utility.ThrowIfNull(file);

			IDictionary<string, string> parameters = new Dictionary<string, string>();

			if (sheetName == null)
			{
				FileInfo fi = new FileInfo(file);
				parameters.Add("sheetName", fi.Name);
			}
			else
			{
				parameters.Add("sheetName", sheetName);
			}
			if (headerRowIndex != null)
			{
				parameters.Add("headerRowIndex", headerRowIndex.ToString());
			}
			if (primaryColumnIndex != null)
			{
				parameters.Add("primaryColumnIndex", primaryColumnIndex.ToString());
			}
			string path = "folders/" + folderId + "/sheets/import" + QueryUtil.GenerateUrl(null, parameters);

			return this.ImportFile<Sheet>(path, file, contentType);
		}
	}
}