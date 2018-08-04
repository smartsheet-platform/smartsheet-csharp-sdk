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

namespace Smartsheet.Api
{

    using Smartsheet.Api.Models;
    using System.Collections.Generic;
    using Home = Api.Models.Home;

    /// <summary>
    /// <para>This interface provides methods to access Home resources.</para>
    /// 
    /// <para>Thread Safety: Implementation of this interface must be thread safe.</para>
    /// </summary>
    public interface HomeResources
    {
        /// <summary>
        /// <para>
        /// Gets a nested list of all Home objects, including folders, reports, sheets, templates, and workspaces as shown on the Home tab.
        /// </para>
        /// <para>
        /// Mirrors to the following Smartsheet REST API method: GET /home
        /// </para>
        /// </summary>
        /// <param name="includes"> used to specify the optional objects to include, currently TEMPLATES is supported. </param>
        /// <param name="excludes"> used to specify the optional object to exclude </param>
        /// <exception cref="InvalidRequestException">if there is any problem with the REST API request</exception>
        /// <exception cref="AuthorizationException">if there is any problem with the REST API authorization (access token)</exception>
        /// <exception cref="InvalidRequestException">if the resource cannot be found</exception>
        /// <exception cref="ResourceNotFoundException">if the REST API service is not available (possibly due to rate limiting)</exception>
        /// <exception cref="ServiceUnavailableException">if any other REST API related error occurred during the operation</exception>
        /// <exception cref="SmartsheetException">if any other error occurred during the operation</exception>
        /// <returns> the resource (note that if there is no such resource, this method will throw ResourceNotFoundException
        /// rather than returning null). </returns>
        Home GetHome(IEnumerable<HomeInclusion> includes = null, IEnumerable<HomeExclusion> excludes = null);

        /// <summary>
        /// <para>Returns the HomeFolderResources object that provides access to folder resources under home.</para>
        /// </summary>
        /// <returns> the home folder resources </returns>
        HomeFolderResources FolderResources { get; }
    }

}
