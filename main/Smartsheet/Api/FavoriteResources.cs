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

    using System.IO;
    using Api.Models;

    /// <summary>
    /// <para>This interface provides methods to access Favorite resources.</para>
    /// 
    /// <para>Thread Safety: Implementation of this interface must be thread safe.</para>
    /// </summary>
    public interface FavoriteResources
    {
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
        IList<Favorite> AddFavorites(IEnumerable<Favorite> favorites);

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
        PaginatedResult<Favorite> ListFavorites(PaginationParameters paging = null);

        /// <summary>
        /// <para>Removes one or multiple objects from the user’s list of Favorite items.</para>
        /// <para>It mirrors to the following Smartsheet REST API methods: 
        /// <list type="bullet">
        /// <item><description>DELETE /favorites/folder</description></item>
        /// <item><description>DELETE /favorites/report</description></item>
        /// <item><description>DELETE /favorites/sheet</description></item>
        /// <item><description>DELETE /favorites/template</description></item>
        /// <item><description>DELETE /favorites/workspace</description></item>
        /// </list>
        /// </para>
        /// </summary>
        /// <param name="objectIds">(required): object IDs representing the items to remove from Favorites. If type is "template", only private sheet-type template ID is allowed.</param>
        /// <param name="type">the object type to remove </param>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        void RemoveFavorites(ObjectType type, IList<long> objectIds);
    }

}