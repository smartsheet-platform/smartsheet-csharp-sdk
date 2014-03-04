using System.Collections.Generic;

namespace com.smartsheet.api
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



	using Workspace = com.smartsheet.api.models.Workspace;

	/// <summary>
	/// <para>This interface provides methods to access Workspace resources.</para>
	/// 
	/// <para>Thread Safety: Implementation of this interface must be thread safe.</para>
	/// </summary>
	public interface WorkspaceResources
	{

		/// <summary>
		/// <para>List all workspaces.</para>
		/// 
		/// <para>It mirrors to the following Smartsheet REST API method: GET /workspaces</para>
		/// </summary>
		/// <returns> the list of workspaces (note that an empty list will be returned if there are none) </returns>
		/// <exception cref="InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		IList<Workspace> ListWorkspaces();

		/// <summary>
		/// <para>Get a workspace.</para>
		/// 
		/// <para>It mirrors to the following Smartsheet REST API method: GET /workspace/{id}</para>
		/// </summary>
		/// <param name="id"> the id </param>
		/// <returns> the workspace (note that if there is no such resource, this method will throw ResourceNotFoundException
		/// rather than returning null) </returns>
		/// <exception cref="InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		Workspace GetWorkspace(long id);

		/// <summary>
		/// <para>Create a workspace.</para>
		/// 
		/// <para>It mirrors to the following Smartsheet REST API method: POST /workspaces</para>
		/// 
		/// </summary>
		/// <param name="workspace"> the workspace to create </param>
		/// <returns> the created workspace </returns>
		/// <exception cref="InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		Workspace CreateWorkspace(Workspace workspace);

		/// <summary>
		/// <para>Update a workspace.</para>
		/// 
		/// <para>It mirrors to the following Smartsheet REST API method: PUT /workspace/{id}</para>
		/// </summary>
		/// <param name="workspace"> the workspace to update </param>
		/// <returns> the updated workspace (note that if there is no such resource, this method will throw
		/// ResourceNotFoundException rather than returning null) </returns>
		/// <exception cref="InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		Workspace UpdateWorkspace(Workspace workspace);

		/// <summary>
		/// <para>Delete a workspace.</para>
		/// 
		/// <para>It mirrors to the following Smartsheet REST API method: DELETE /workspace{id}</para>
		/// </summary>
		/// <param name="id"> the id of the workspace </param>
		/// <exception cref="InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		void DeleteWorkspace(long id);

		/// <summary>
		/// <para>Return the WorkspaceFolderResources object that provides access to Folder resources associated with Workspace
		/// resources.</para>
		/// </summary>
		/// <returns> the workspace folder resources </returns>
		WorkspaceFolderResources Folders();

		/// <summary>
		/// <para>Return the ShareResources object that provides access to Share resources associated with Workspace 
		/// resources.</para>
		/// </summary>
		/// <returns> the share resources object </returns>
		ShareResources Shares();
	}

}