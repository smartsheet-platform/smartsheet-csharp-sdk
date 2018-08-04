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
    using HttpMethod = Api.Internal.Http.HttpMethod;
    using HttpRequest = Api.Internal.Http.HttpRequest;
    using Utils = Api.Internal.Utility.Utility;
    using System.IO;
    using System.Net;
    using System;
    using Smartsheet.Api.Models;
    using Smartsheet.Api.Internal.Util;
    using System.Text;

    /// <summary>
    /// This is the implementation of the FavoriteResources.
    /// 
    /// Thread Safety: This class is thread safe because it is immutable and its base class is thread safe.
    /// </summary>
    public class FavoriteResourcesImpl : AbstractResources, FavoriteResources
    {
        /// <summary>
        /// Constructor.
        /// 
        /// Exceptions: - IllegalArgumentException : if any argument is null
        /// </summary>
        /// <param name="smartsheet"> the Smartsheet </param>
        public FavoriteResourcesImpl(SmartsheetImpl smartsheet)
            : base(smartsheet)
        {
        }

        /// <summary>
        /// <para>Adds one or more items to the user’s list of Favorite items.</para>
        /// <para>It mirrors to the following Smartsheet REST API method: POST /favorites</para>
        /// <para>If called with a single Favorite object, and that favorite already exists, error code 1129 will be returned. 
        /// If called with an array of Favorite objects, any objects specified in the array that are already marked as favorites 
        /// will be ignored and omitted from the response.</para>
        /// </summary>
        /// <param name="favorites">list of favorite objects</param>
        /// <returns> the created favortie objects </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual IList<Favorite> AddFavorites(IEnumerable<Favorite> favorites)
        {
            return this.PostAndReceiveList<IEnumerable<Favorite>, Favorite>("favorites", favorites, typeof(Favorite));
        }

        /// <summary>
        /// <para>Gets a list of all of the user’s Favorite items.</para>
        /// <para>It mirrors to the following Smartsheet REST API method: GET /favorites</para>
        /// <remarks>This operation supports pagination of results. For more information, see Paging.</remarks>
        /// </summary>
        /// <param name="paging">the pagination</param>
        /// <returns> A list of all Favorites (note that an empty list will be returned if there are none). </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual PaginatedResult<Favorite> ListFavorites(PaginationParameters paging = null)
        {
            StringBuilder path = new StringBuilder("favorites");
            if (paging != null)
            {
                path.Append(paging.ToQueryString());
            }
            return this.ListResourcesWithWrapper<Favorite>(path.ToString());
        }

        /// <summary>
        /// <para>Removes one or multiple objects from the user’s list of Favorite items.</para>
        /// <para>objectIds must not be null or empty.</para>
        /// <para>It mirrors to the following Smartsheet REST API methods: 
        /// <list type="bullet">
        /// <item><description>DELETE /favorites/folder</description></item>
        /// <item><description>DELETE /favorites/report</description></item>
        /// <item><description>DELETE /favorites/sheet</description></item>
        /// <item><description>DELETE /favorites/sight</description></item>
        /// <item><description>DELETE /favorites/template</description></item>
        /// <item><description>DELETE /favorites/workspace</description></item>
        /// </list>
        /// </para>
        /// </summary>
        /// <param name="objectIds">(required): a comma-separated list of object IDs representing the items to remove from Favorites</param>
        /// <param name="type">the object type to remove </param>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual void RemoveFavorites(ObjectType type, IList<long> objectIds)
        {
            StringBuilder path = new StringBuilder("favorites/" + Enum.GetName(typeof(ObjectType), type).ToLower());
            if (objectIds != null)
            {
                path.Append("?objectIds=" + QueryUtil.GenerateCommaSeparatedList(objectIds));
            }
            this.DeleteResource<Favorite>(path.ToString(), typeof(Favorite));
        }
    }
}