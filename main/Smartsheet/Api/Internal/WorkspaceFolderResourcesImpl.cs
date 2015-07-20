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

	/// <summary>
	/// This is the implementation of the WorkspaceFolderResources.
	/// 
	/// Thread Safety: This class is thread safe because it is immutable and its base class is thread safe.
	/// </summary>
	public class WorkspaceFolderResourcesImpl : AbstractResources, WorkspaceFolderResources
	{
		/// <summary>
		/// Constructor.
		/// 
		/// Exceptions: - IllegalArgumentException : if any argument is
		/// </summary>
		/// <param name="smartsheet"> the Smartsheet </param>
		public WorkspaceFolderResourcesImpl(SmartsheetImpl smartsheet)
			: base(smartsheet)
		{
		}

		/// <summary>
		/// <para>List Folders of a given workspace.</para>
		/// 
		/// <para>It mirrors To the following Smartsheet REST API method: GET /workspaces/{workspaceId}/Folders</para>
		/// </summary>
		/// <param name="workspaceId"> the workspace Id </param>
		/// <returns> the list of Folders (note that an empty list will be returned if there are none) </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual DataWrapper<Folder> ListFolders(long workspaceId, PaginationParameters paging)
		{
			return this.ListResourcesWithWrapper<Folder>("workspaces/" + workspaceId + "/folders" + paging.ToQueryString());
		}

		/// <summary>
		/// <para>Create a folder in the workspace.</para>
		/// 
		/// <para>It mirrors To the following Smartsheet REST API method: POST /workspaces/{workspaceId}/Folders</para>
		/// </summary>
		/// <param name="workspaceId"> the workspace Id </param>
		/// <param name="folder"> the folder To create </param>
		/// <returns> the created folder </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual Folder CreateFolder(long workspaceId, Folder folder)
		{
			return this.CreateResource<Folder>("workspaces/" + workspaceId + "/folders", typeof(Folder), folder);
		}
	}
}