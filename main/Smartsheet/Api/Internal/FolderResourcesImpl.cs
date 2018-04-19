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

namespace Smartsheet.Api.Internal
{
	using Api.Models;
	using Smartsheet.Api.Internal.Util;
    using System;
    using System.Text;

	/// <summary>
	/// This is the implementation of the FolderResources.
	/// 
	/// Thread Safety: This class is thread safe because it is immutable and its base class is thread safe.
	/// </summary>
	public class FolderResourcesImpl : AbstractResources, FolderResources
	{
		private FolderSheetResources sheets;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="smartsheet"> the SmartsheetImpl </param>
        /// <exception cref="InvalidOperationException">if any argument is null</exception>
        public FolderResourcesImpl(SmartsheetImpl smartsheet)
			: base(smartsheet)
		{
			this.sheets = new FolderSheetResourcesImpl(smartsheet);
		}

		/// <summary>
		/// <para>Gets the specified Folder (and lists its contents).</para>
		/// <para>It mirrors to the following Smartsheet REST API method: GET /folders/{folderId}</para>
		/// </summary>
		/// <param name="folderId"> the folder Id </param>
		/// <param name="include"> (optional) – comma-separated list of elements to include in the respons</param>
		/// <returns> the folder (note that if there is no such resource, this method will throw ResourceNotFoundException 
		/// rather than returning null) </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual Folder GetFolder(long folderId, IEnumerable<FolderInclusion> include)
		{
			StringBuilder path = new StringBuilder("folders/" + folderId);
			if (include != null)
			{
				path.Append("?include=" + QueryUtil.GenerateCommaSeparatedList(include));
			}
			return this.GetResource<Folder>(path.ToString(), typeof(Folder));
		}

		/// <summary>
		/// <para>Updates a folder.</para>
		/// <para>It mirrors to the following Smartsheet REST API method: PUT /folders/{folderId}</para>
		/// </summary>
		/// <param name="folder"> the folder to update </param>
		/// <returns> the updated folder (note that if there is no such folder, this method will throw Resource Not Found 
		/// Exception rather than returning null). </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual Folder UpdateFolder(Folder folder)
		{
			return this.UpdateResource<Folder>("folders/" + folder.Id, typeof(Folder), folder);
		}

		/// <summary>
		/// <para>Deletes a folder.</para>
		/// <para>It mirrors to the following Smartsheet REST API method:<br />
		/// DELETE /folders/{folderId}</para>
		/// </summary>
		/// <param name="folderId"> the folder Id </param>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual void DeleteFolder(long folderId)
		{
			this.DeleteResource<Folder>("folders/" + folderId, typeof(Folder));
		}

		/// <summary>
		/// <para>Gets a list of the top-level child Folders within the specified Folder.</para>
		/// <remarks>This operation supports pagination of results. For more information, see Paging.</remarks>
		/// <para>It mirrors to the following Smartsheet REST API method:<br /> GET /folders/{folderId}/folders</para>
		/// </summary>
		/// <param name="folderId"> the folderId</param>
		/// <param name="paging">the pagination information</param>
		/// <returns>the child Folders (note that an empty list will be returned if no child folder is found), limited to the following attributes:
		/// <list type="bullet">
		/// <item><description>id</description></item>
		/// <item><description>name</description></item>
		/// <item><description>permalink</description></item>
		/// </list>
		/// </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual PaginatedResult<Folder> ListFolders(long folderId, PaginationParameters paging)
		{
			StringBuilder path = new StringBuilder("folders/" + folderId + "/folders");
			if (paging != null)
			{
				path.Append(paging.ToQueryString());
			}
			return this.ListResourcesWithWrapper<Folder>(path.ToString());
		}

		/// <summary>
		/// <para>Creates a Folder in the specified Folder.</para>
		/// <para>It mirrors to the following Smartsheet REST API method:<br />
		/// POST /folders/{folderId}/folders</para>
		/// </summary>
		/// <param name="folderId"> the parent folder Id </param>
		/// <param name="folder"> the folder to create </param>
		/// <returns> the created folder </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual Folder CreateFolder(long folderId, Folder folder)
		{
			return this.CreateResource<Folder>("folders/" + folderId + "/folders", typeof(Folder), folder);
		}

		/// <summary>
		/// <para>Creates a copy of the specified Folder.</para>
		/// <para>It mirrors to the following Smartsheet REST API method:<br />
		/// POST /folders/{folderId}/copy</para>
		/// </summary>
		/// <param name="folderId"> the folder Id </param>
		/// <param name="destination"> the destination to copy to </param>
		/// <param name="include"> the elements to copy. Note: Cell history will not be copied, regardless of which include parameter values are specified.</param>
		/// <param name="skipRemap"> the references to NOT re-map for the newly created folder
		/// <para>
		/// If “cellLinks” is specified in the skipRemap parameter value, the cell links within the newly created folder will continue to point to the original source sheets.
		/// If “reports” is specified in the skipRemap parameter value, the reports within the newly created folder will continue to point to the original source sheets.
		/// </para>
		/// </param>
		/// <returns> the created folder </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual Folder CopyFolder(long folderId, ContainerDestination destination, IEnumerable<FolderCopyInclusion> include, IEnumerable<FolderRemapExclusion> skipRemap)
		{
			IDictionary<string, string> parameters = new Dictionary<string, string>();
			if (include != null)
			{
				parameters.Add("include", QueryUtil.GenerateCommaSeparatedList(include));
			}
			if (skipRemap != null)
			{
				parameters.Add("skipRemap", QueryUtil.GenerateCommaSeparatedList(skipRemap));
			}
			return this.CreateResource<RequestResult<Folder>, ContainerDestination>(QueryUtil.GenerateUrl("folders/" + folderId + "/copy", parameters), destination).Result;
		}

		/// <summary>
		/// <para>Moves the specified Folder to another location.</para>
		/// <para>It mirrors to the following Smartsheet REST API method:<br />
		/// POST /folders/{folderId}/move</para>
		/// </summary>
		/// <param name="folderId"> the folder Id </param>
		/// <param name="destination"> the destination to copy to </param>
		/// <returns> the moved folder </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual Folder MoveFolder(long folderId, ContainerDestination destination)
		{
			return this.CreateResource<RequestResult<Folder>, ContainerDestination>("folders/" + folderId + "/move", destination).Result;
		}

		/// <summary>
		/// <para>Return the SheetResources object that provides access to Sheet resources associated with Folder resources.</para>
		/// </summary>
		/// <returns> the SheetResources object </returns>
		public virtual FolderSheetResources SheetResources
		{
			get
			{
				return this.sheets;
			}
		}
	}

}