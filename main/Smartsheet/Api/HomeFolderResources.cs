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
//    Unless required by applicable law or agreed to in writing, software
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
    /// <para>This interface provides methods to access Folder resources under home.</para>
    /// 
    /// <para>Thread Safety: Implementation of this interface must be thread safe.</para>
    /// </summary>
    public interface HomeFolderResources
    {
        /// <summary>
        /// <para>List Folders under home.</para>
        /// 
        /// <para>It mirrors to the following Smartsheet REST API method:<br />
        /// GET /home/Folders</para>
        /// </summary>
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
        PaginatedResult<Folder> ListFolders(PaginationParameters paging = null);

        /// <summary>
        /// <para>Create a folder in home.</para>
        /// 
        /// <para>It mirrors to the following Smartsheet REST API method:<br />
        /// POST /home/Folders</para>
        /// </summary>
        /// <param name="folder"> the folder to create </param>
        /// <returns> the folder </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        Folder CreateFolder(Folder folder);
    }

}