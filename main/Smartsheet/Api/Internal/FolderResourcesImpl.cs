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

namespace Smartsheet.Api.Internal
{
	using Smartsheet.Api.Internal.Utility;
using Folder = Api.Models.Folder;
using FolderInclude = Api.Models.FolderInclude;

	/// <summary>
	/// This is the implementation of the FolderResources.
	/// 
	/// Thread Safety: This class is thread safe because it is immutable and its base class is thread safe.
	/// </summary>
	public class FolderResourcesImpl : AbstractResources, FolderResources
	{

		/// <summary>
		/// Constructor.
		/// 
		/// Parameters: - Smartsheet : the SmartsheetImpl
		/// 
		/// Exceptions: - IllegalArgumentException : if any argument is null
		/// </summary>
		/// <param name="smartsheet"> the Smartsheet </param>
		public FolderResourcesImpl(SmartsheetImpl smartsheet) : base(smartsheet)
		{
		}

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
		public virtual Folder GetFolder(long folderId, IEnumerable<FolderInclude> include)
		{
			string pathAndQuery = PathAndQueryWrapper.CreatePathAndQueryWithIncludeAndPaging<FolderInclude>("folders/" + folderId, include, null, null, null);
			return this.GetResource<Folder>(pathAndQuery, typeof(Folder));
		}

		/// <summary>
		/// <para>Updates a folder.</para>
		/// <para>It mirrors To the following Smartsheet REST API method: PUT /folders/{folderId}</para>
		/// </summary>
		/// <param name="folder"> the folder To update </param>
		/// <returns> the updated folder (note that if there is no such folder, this method will throw Resource Not Found 
		/// Exception rather than returning null). </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual Folder UpdateFolder(Folder folder)
		{

			return this.UpdateResource<Folder>("folder/" + folder.ID, typeof(Folder), folder);
		}

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
		public virtual void DeleteFolder(long folderId)
		{

			this.DeleteResource<Folder>("folders/" + folderId, typeof(Folder));
		}

		/// <summary>
		/// <para>Gets a list of the top-level child Folders within the specified Folder.</para>
		/// <remarks>This operation supports pagination of results. For more information, see Paging.</remarks>
		/// <para>It mirrors To the following Smartsheet REST API method:<br /> GET /folders/{folderId}/folders</para>
		/// </summary>
		/// <param name="folderId"> the folderId </param>
		/// <param name="includeAll"> If true, include all results (i.e. do not paginate). </param>
		/// <param name="pageSize"> The maximum number of items to return per page. Defaults to 100 if null.</param>
		/// <param name="page"> Which page to return. Defaults to 1 if null. </param>
		/// <returns> the child Folders (note that an empty list will be returned if no child folder is found). </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual IList<Folder> ListFolders(long folderId, bool includeAll, long? pageSize, long? page)
		{
			string pathAndQuery = PathAndQueryWrapper.CreatePathAndQueryWithPaging("folders/" + folderId + "/folders", includeAll, pageSize, page);
			return this.ListResources<Folder>(pathAndQuery, typeof(Folder));
		}


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
		public virtual Folder CreateFolder(long folderId, Folder folder)
		{
			return this.CreateResource<Folder>("folders/" + folderId + "/folders", typeof(Folder), folder);
		}
	}
}