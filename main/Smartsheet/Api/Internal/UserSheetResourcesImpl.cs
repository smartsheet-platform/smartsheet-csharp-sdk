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
    /// This is the implementation of the UserResources.
    /// 
    /// Thread Safety: This class is thread safe because it is immutable and its base class is thread safe.
    /// </summary>
    public class UserSheetResourcesImpl : AbstractResources, UserSheetResources
    {
        /// <summary>
        /// Constructor.
        /// 
        /// Exceptions: - IllegalArgumentException : if any argument is null
        /// </summary>
        /// <param name="smartsheet"> the Smartsheet </param>
        public UserSheetResourcesImpl(SmartsheetImpl smartsheet)
            : base(smartsheet)
        {
        }

        /// <summary>
        /// <para>List of all Sheets owned by the members of the account (organization).</para>
        /// <para>It mirrors to the following Smartsheet REST API method: GET /users/sheets</para>
        /// </summary>
        /// <returns> the list of all Sheets owned by the members of the account (organization). </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual PaginatedResult<Sheet> ListOrgSheets(PaginationParameters paging, DateTime? modifiedSince)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            if (paging != null)
            {
                parameters = paging.toDictionary();
            }
            if (modifiedSince != null)
            {
                parameters.Add("modifiedSince", ((DateTime)modifiedSince).ToUniversalTime().ToString("o"));
            }
            return this.ListResourcesWithWrapper<Sheet>("users/sheets" + QueryUtil.GenerateUrl(null, parameters));
        }
    }
}