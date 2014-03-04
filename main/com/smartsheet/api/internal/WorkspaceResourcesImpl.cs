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
	 *      http://www.apache.org/licenses/LICENSE
		 *   -2.0
	 * 
	 * Unless required by applicable law or agreed to in writing, software
	 * distributed under the License is distributed on an "AS IS" BASIS,
	 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
	 * See the License for the specific language governing permissions and
	 * limitations under the License.
	 * %[license]
	 */



	using Workspace = com.smartsheet.api.models.Workspace;

	/// <summary>
	/// This is the implementation of the WorkspaceResources.
	/// 
	/// Thread Safety: This class is thread safe because it is immutable and its base class is thread safe.
	/// </summary>
	public class WorkspaceResourcesImpl : AbstractResources, WorkspaceResources
	{
		/// <summary>
		/// Represents the WorkspaceFolderResources.
		/// 
		/// It will be initialized in constructor and will not change afterwards.
		/// </summary>
		private WorkspaceFolderResources folders;

		/// <summary>
		/// Represents the ShareResources.
		/// 
		/// It will be initialized in constructor and will not change afterwards.
		/// </summary>
		private ShareResources shares;

		/// <summary>
		/// Constructor.
		/// 
		/// Exceptions: 
		///   - IllegalArgumentException : if any argument is
		/// </summary>
		/// <param name="smartsheet"> the smartsheet </param>
		public WorkspaceResourcesImpl(SmartsheetImpl smartsheet) : base(smartsheet)
		{
		}

		/// <summary>
		/// List all workspaces.
		/// 
		/// It mirrors to the following Smartsheet REST API method: GET /workspaces
		/// 
		/// Exceptions: 
		///   
		///   - InvalidRequestException : if there is any problem with the REST API request 
		///   
		///   - AuthorizationException : if there is any problem with the REST API authorization(access token) 
		///   
		///   - ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting) 
		///   
		///   - SmartsheetRestException : if there is any other REST API related error occurred during the operation 
		///   
		///   - SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <returns> all workspaces (note that empty list will be returned if there is none) </returns>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		public virtual IList<Workspace> ListWorkspaces()
		{
			return this.ListResources<Workspace>("workspaces", typeof(Workspace));
		}

		/// <summary>
		/// Get a workspace.
		/// 
		/// It mirrors to the following Smartsheet REST API method: GET /workspace/{id}
		/// 
		/// Exceptions: 
		///   
		///   - InvalidRequestException : if there is any problem with the REST API request 
		///   
		///   - AuthorizationException : if there is any problem with the REST API authorization(access token) 
		///   
		///   - ResourceNotFoundException : if the resource can not be found 
		///   
		///   - ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting) 
		///   
		///   - SmartsheetRestException : if there is any other REST API related error occurred during the operation 
		///   
		///   - SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="id"> the id </param>
		/// <returns> the resource (note that if there is no such resource, this method will throw ResourceNotFoundException
		/// rather than returning null). </returns>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		public virtual Workspace GetWorkspace(long id)
		{
			return this.GetResource<Workspace>("workspace/" + id, typeof(Workspace));
		}

		/// <summary>
		/// Create a workspace.
		/// 
		/// It mirrors to the following Smartsheet REST API method: POST /workspaces
		/// 
		/// Exceptions: 
		///   
		///   - IllegalArgumentException : if any argument is null 
		///   
		///   - InvalidRequestException : if there is any problem with the REST API request 
		///   
		///   - AuthorizationException : if there is any problem with the REST API authorization(access token) 
		///   
		///   - ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting) 
		///   
		///   - SmartsheetRestException : if there is any other REST API related error occurred during the operation 
		///   
		///   - SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="workspace"> the workspace to create, limited to the following required attributes: * name (string) </param>
		/// <returns> the created workspace </returns>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		public virtual Workspace CreateWorkspace(Workspace workspace)
		{
			return this.CreateResource<Workspace>("workspaces", typeof(Workspace), workspace);
		}

		/// <summary>
		/// Update a workspace.
		/// 
		/// It mirrors to the following Smartsheet REST API method: PUT /workspace/{id}
		/// 
		/// Exceptions: 
		///   
		///   - IllegalArgumentException : if any argument is null 
		///   
		///   - InvalidRequestException : if there is any problem with the REST API request 
		///   
		///   - AuthorizationException : if there is any problem with the REST API authorization(access token) 
		///   
		///   - ResourceNotFoundException : if the resource can not be found 
		///   
		///   - ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting) 
		///   
		///   - SmartsheetRestException : if there is any other REST API related error occurred during the operation 
		///   
		///   - SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="workspace"> the workspace to update limited to the following attribute: * name (string) </param>
		/// <returns> the updated workspace (note that if there is no such resource, this method will throw
		/// ResourceNotFoundException rather than returning null). </returns>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		public virtual Workspace UpdateWorkspace(Workspace workspace)
		{
			return this.UpdateResource<Workspace>("workspace/" + workspace.id, typeof(Workspace), workspace);
		}

		/// <summary>
		/// Delete a workspace.
		/// 
		/// It mirrors to the following Smartsheet REST API method: DELETE /workspace{id}
		/// 
		/// Exceptions: 
		///   - InvalidRequestException : if there is any problem with the REST API request 
		///   - AuthorizationException : if there is any problem with the REST API authorization(access token) 
		///   - ResourceNotFoundException : if the resource can not be found 
		///   - ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting) 
		///   - SmartsheetRestException : if there is any other REST API related error occurred during the operation 
		///   - SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="id"> the ID of the workspace </param>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		public virtual void DeleteWorkspace(long id)
		{
            this.DeleteResource<Workspace>("workspace/" + id, typeof(Workspace));
		}

		/// <summary>
		/// Return the WorkspaceFolderResources object that provides access to Folder resources associated with Workspace
		/// resources.
		/// </summary>
		/// <returns> the workspace folder resources </returns>
		public virtual WorkspaceFolderResources Folders()
		{
			return this.folders;
		}

		/// <summary>
		/// Return the ShareResources object that provides access to Share resources associated with Workspace resources.
		/// </summary>
		/// <returns> the share resources </returns>
		public virtual ShareResources Shares()
		{
			return this.shares;
		}
	}

}