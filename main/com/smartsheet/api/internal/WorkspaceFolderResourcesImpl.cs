using System.Collections.Generic;

namespace com.smartsheet.api.@internal
{

	/*
	 * #[license]
	 * Smartsheet SDK for C#
	 * %%
	 * Copyright (C) 2014 Smartsheet
	 * %%
	 * Licensed under the Apache License, Version 2.0 (the "License");
	 * you may not use this file except in compliance with the License.
	 * You may obtain a copy of the License at
	 * 
	 *      http://www.apache.org/licenses/LICENSE-2.0
	 * 
	 * Unless required by applicable law or agreed to in writing, software
	 * distributed under the License is distributed on an "AS IS" BASIS,
	 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
	 * See the License for the specific language governing permissions and
	 * limitations under the License.
	 * %[license]
	 */



	using Folder = com.smartsheet.api.models.Folder;

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
		/// <param name="smartsheet"> the smartsheet </param>
		public WorkspaceFolderResourcesImpl(SmartsheetImpl smartsheet) : base(smartsheet)
		{
		}

		/// <summary>
		/// List folders of a given workspace.
		/// 
		/// It mirrors to the following Smartsheet REST API method: GET /workspace/{id}/folders
		/// 
		/// Exceptions: 
		///   - InvalidRequestException : if there is any problem with the REST API request 
		///   - AuthorizationException : if there is any problem with the REST API authorization(access token) 
		///   - ResourceNotFoundException : if the resource can not be found 
		///   - ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting) 
		///   - SmartsheetRestException : if there is any other REST API related error occurred during the operation 
		///   - SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="workspaceId"> the ID of the workspace </param>
		/// <returns> the folders (note that empty list will be returned if there is none) </returns>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		public virtual IList<Folder> ListFolders(long workspaceId)
		{
			return this.ListResources<Folder>("workspace/" + workspaceId + "/folders", typeof(Folder));
		}

		/// <summary>
		/// Create a folder in the workspace.
		/// 
		/// It mirrors to the following Smartsheet REST API method: POST /workspace/{id}/folders
		/// 
		/// Exceptions: 
		///   - IllegalArgumentException : if folder is null 
		///   - InvalidRequestException : if there is any problem with the REST API request 
		///   - AuthorizationException : if there is any problem with the REST API authorization(access token) 
		///   - ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting) 
		///   - SmartsheetRestException : if there is any other REST API related error occurred during the operation 
		///   - SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="workspaceId"> the workspace id </param>
		/// <param name="folder"> the folder to create </param>
		/// <returns> the created folder </returns>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		public virtual Folder CreateFolder(long workspaceId, Folder folder)
		{
			return this.CreateResource<Folder>("workspace/" + workspaceId + "/folders", typeof(Folder), folder);
		}
	}

}