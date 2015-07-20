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

using System.Collections.Generic;

namespace Smartsheet.Api
{
	using Api.Models;

	/// <summary>
	/// <para>This interface provides methods To access Folder resources.</para>
	/// 
	/// <para>Thread Safety: Implementation of this interface must be thread safe.</para>
	/// </summary>
	public interface FolderResources
	{
		/// <summary>
		/// <para>Gets the specified Folder (and lists its contents).</para>
		/// <para>It mirrors To the following Smartsheet REST API method: GET /folders/{folderId}</para>
		/// </summary>
		/// <param name="folderId"> the folder Id </param>
		/// <param name="include"> (optional) – comma-separated list of elements to include in the respons</param>
		/// <returns> the folder (note that if there is no such resource, this method will throw ResourceNotFoundException 
		/// rather than returning null) </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		Folder GetFolder(long folderId, IEnumerable<SourceInclusion> include);

		/// <summary>
		/// <para>Updates a folder.</para>
		/// <para>It mirrors To the following Smartsheet REST API method: PUT /folders/{folderId}</para>
		/// </summary>
		/// <param name="folderId"> the folder Id </param>
		/// <param name="folder"> the folder To update </param>
		/// <returns> the updated folder (note that if there is no such folder, this method will throw Resource Not Found 
		/// Exception rather than returning null). </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		Folder UpdateFolder(long folderId, Folder folder);

		/// <summary>
		/// <para>Deletes a folder.</para>
		/// <para>It mirrors To the following Smartsheet REST API method:<br />
		/// DELETE /folders/{folderId}</para>
		/// </summary>
		/// <param name="folderId"> the folder Id </param>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		void DeleteFolder(long folderId);

		/// <summary>
		/// <para>Gets a list of the top-level child Folders within the specified Folder.</para>
		/// <remarks>This operation supports pagination of results. For more information, see Paging.</remarks>
		/// <para>It mirrors To the following Smartsheet REST API method:<br /> GET /folders/{folderId}/folders</para>
		/// </summary>
		/// <param name="folderId"> the folderId</param>
		/// <returns> the child Folders (note that an empty list will be returned if no child folder is found). </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		DataWrapper<Folder> ListFolders(long folderId, PaginationParameters paging);

		/// <summary>
		/// <para>Creates a Folder in the specified Folder.</para>
		/// <para>It mirrors To the following Smartsheet REST API method:<br />
		/// POST /folders/{folderId}/folders</para>
		/// </summary>
		/// <param name="folderId"> the parent folder Id </param>
		/// <param name="folder"> the folder To create </param>
		/// <returns> the created folder </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		Folder CreateFolder(long folderId, Folder folder);
	}

}