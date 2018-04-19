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


	using Smartsheet.Api.Models;
	using Workspace = Api.Models.Workspace;

	/// <summary>
	/// <para>This interface provides methods to access Workspace resources.</para>
	/// 
	/// <para>Thread Safety: Implementation of this interface must be thread safe.</para>
	/// </summary>
	public interface WorkspaceResources
	{

		/// <summary>
		/// <para>List all Workspaces.</para>
		/// <para>It mirrors to the following Smartsheet REST API method: GET /Workspaces</para>
		/// <remarks>This operation supports pagination of results. For more information, see Paging.</remarks>
		/// </summary>
		/// <returns> the list of Workspaces (note that an empty list will be returned if there are none) </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		PaginatedResult<Workspace> ListWorkspaces(PaginationParameters paging);

		/// <summary>
		/// <para>Gets the specified Workspace (and lists its contents).</para>
		/// <para>It mirrors to the following Smartsheet REST API method: GET /workspaces/{workspaceid}</para>
		/// <remarks><para>By default, this operation only returns the top-level items in the Workspace. To load all of the contents, 
		/// including nested Folders, include the loadAll query string parameter with a value of true.</para>
		/// <para>If no Folders, Sheets, Reports, or Templates are present in the Workspace, the corresponding attribute 
		/// (e.g., "folders", "sheets") will not be present in the response object.</para></remarks>
		/// </summary>
		/// <param name="workspaceid">the workspace id</param>
		/// <param name="loadAll"> Defaults to false. If true, loads all of the contents, including nested Folders. </param>
		/// <param name="include"> When specified with a value of "source", response will include the source for any sheet that was created from another sheet or template</param>
		/// <returns> the workspace (note that if there is no such resource, this method will throw ResourceNotFoundException
		/// rather than returning null) </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		Workspace GetWorkspace(long workspaceid, bool? loadAll, IEnumerable<WorkspaceInclusion> include);

		/// <summary>
		/// <para>Create a workspace.</para>
		/// <para>It mirrors to the following Smartsheet REST API method: POST /Workspaces</para>
		/// </summary>
		/// <param name="workspace"> the workspace to create </param>
		/// <returns> the created workspace </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		Workspace CreateWorkspace(Workspace workspace);

		/// <summary>
		/// <para>Update a workspace.</para>
		/// <para>It mirrors to the following Smartsheet REST API method: PUT /workspaces/{workspaceId}</para>
		/// </summary>
		/// <param name="workspace"> the workspace to update </param>
		/// <returns> the updated workspace (note that if there is no such resource, this method will throw
		/// ResourceNotFoundException rather than returning null) </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		Workspace UpdateWorkspace(Workspace workspace);

		/// <summary>
		/// <para>Creates a copy of the specified Workspace.</para>
		/// <para>It mirrors to the following Smartsheet REST API method:<br />
		/// POST /workspaces/{workspaceId}/copy</para>
		/// </summary>
		/// <param name="workspaceId"> the workspace Id </param>
		/// <param name="destination"> the destination to copy to </param>
		/// <param name="include"> the elements to copy. Note: Cell history will not be copied, regardless of which include parameter values are specified.</param>
		/// <param name="skipRemap"> the references to NOT re-map for the newly created folder
		/// <para>
		/// If "cellLinks" is specified in the skipRemap parameter value, the cell links within the newly created folder will continue to point to the original source sheets.
		/// If "reports" is specified in the skipRemap parameter value, the reports within the newly created folder will continue to point to the original source sheets.
		/// </para>
		/// </param>
		/// <returns> the created workspace </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		Workspace CopyWorkspace(long workspaceId, ContainerDestination destination, IEnumerable<WorkspaceCopyInclusion> include, IEnumerable<WorkspaceRemapExclusion> skipRemap);

		/// <summary>
		/// <para>Deletes the specified Workspace (and its contents).</para>
		/// <para>It mirrors to the following Smartsheet REST API method: DELETE /workspaces{workspaceId}</para>
		/// </summary>
		/// <param name="workspaceId"> the Id of the workspace </param>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		void DeleteWorkspace(long workspaceId);

		/// <summary>
		/// <para>Return the WorkspaceFolderResources object that provides access to Folder resources associated with Workspace
		/// resources.</para>
		/// </summary>
		/// <returns> the workspace folder resources </returns>
		WorkspaceFolderResources FolderResources { get; }

		/// <summary>
		/// <para>Return the WorkspaceFolderResources object that provides access to Folder resources associated with Workspace
		/// resources.</para>
		/// </summary>
		/// <returns> the workspace folder resources </returns>
		WorkspaceSheetResources SheetResources { get; }

		/// <summary>
		/// <para>Return the ShareResources object that provides access to Share resources associated with Workspace 
		/// resources.</para>
		/// </summary>
		/// <returns> the share resources object </returns>
		ShareResources ShareResources { get; }
	}

}