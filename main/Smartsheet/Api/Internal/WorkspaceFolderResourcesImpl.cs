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
    using System.Text;

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
        /// <para>It mirrors to the following Smartsheet REST API method: GET /workspaces/{workspaceId}/Folders</para>
        /// </summary>
        /// <param name="workspaceId">the workspace Id</param>
        /// <param name="paging">the pagination information</param>
        /// <returns>the list of Folders (note that an empty list will be returned if no child folder is found), limited to the following attributes:
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
        public virtual PaginatedResult<Folder> ListFolders(long workspaceId, PaginationParameters paging = null)
        {
            StringBuilder path = new StringBuilder("workspaces/" + workspaceId + "/folders");
            if (paging != null)
            {
                path.Append(paging.ToQueryString());
            }
            return this.ListResourcesWithWrapper<Folder>(path.ToString());
        }

        /// <summary>
        /// <para>Create a folder in the workspace.</para>
        /// 
        /// <para>It mirrors to the following Smartsheet REST API method: POST /workspaces/{workspaceId}/Folders</para>
        /// </summary>
        /// <param name="workspaceId"> the workspace Id </param>
        /// <param name="folder"> the folder to create </param>
        /// <returns> the created folder </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual Folder CreateFolder(long workspaceId, Folder folder)
        {
            return this.CreateResource<Folder>("workspaces/" + workspaceId + "/folders", typeof(Folder), folder);
        }
    }
}