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
    using Smartsheet.Api.Models;
    using System.Text;
    using MultiShare = Api.Models.MultiShare;
    using Share = Api.Models.Share;
    using Smartsheet.Api.Internal.Util;

    /// <summary>
    /// This is the implementation of the ShareResources.
    /// 
    /// Thread Safety: This class is thread safe because it is immutable and its base class is thread safe.
    /// </summary>
    public class ShareResourcesImpl : AbstractAssociatedResources, ShareResources
    {

        /// <summary>
        /// Constructor.
        /// 
        /// Exceptions: - IllegalArgumentException : if any argument is null or empty string
        /// </summary>
        /// <param name="smartsheet"> the Smartsheet </param>
        /// <param name="masterResourceType"> the master resource Type (e.g. "sheets", "workspaces", "reports") </param>
        public ShareResourcesImpl(SmartsheetImpl smartsheet, string masterResourceType)
            : base(smartsheet, masterResourceType)
        {
        }

        /// <summary>
        /// <para>List shares of a given object.</para>
        /// <para>It mirrors to the following Smartsheet REST API method:<br />
        /// GET /workspaces/{workspaceId}/shares <br />
        /// GET /sheets/{sheetId}/shares <br />
        /// GET /sights/{sightId}/shares <br />
        /// GET /reports/{reportId}/shares</para>
        /// </summary>
        /// <param name="objectId"> the object Id </param>
        /// <param name="paging"> the pagination request </param>
        /// <param name="shareScope"> when specified with a value of <see cref="ShareScope.Workspace"/>, the response will contain both item-level shares (scope=‘ITEM’) and workspace-level shares (scope='WORKSPACE’). </param>
        /// <returns> the list of Share objects (note that an empty list will be returned if there is none). </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual PaginatedResult<Share> ListShares(long objectId, PaginationParameters paging = null, ShareScope? shareScope = null)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            if (paging != null)
            {
                parameters = paging.toDictionary();
            }
            if (ShareScope.Workspace.Equals(shareScope))
            {
                parameters.Add("include", "workspaceShares");
            }

            return this.ListResourcesWithWrapper<Share>(MasterResourceType + "/" + objectId + "/shares" + QueryUtil.GenerateUrl(null, parameters));
        }


        /// <summary>
        /// <para>Get a Share.</para>
        /// <para>It mirrors to the following Smartsheet REST API method:<br />
        /// GET /workspaces/{workspaceId}/shares/{shareId}<br />
        /// GET /sheets/{sheetId}/shares/{shareId}<br />
        /// GET /sights/{sightId}/shares/{shareId}<br />
        /// GET /reports/{reportId}/shares/{shareId}</para>
        /// </summary>
        /// <param name="objectId"> the ID of the object to share </param>
        /// <param name="shareId"> the ID of the share instance </param>
        /// <returns> the share (note that if there is no such resource, this method will throw ResourceNotFoundException
        /// rather than returning null). </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual Share GetShare(long objectId, string shareId)
        {
            return this.GetResource<Share>(MasterResourceType + "/" + objectId + "/shares/" + shareId, typeof(Share));
        }


        /// <summary>
        /// <para>Shares a Sheet with the specified Users and Groups.</para>
        /// 
        /// <para>It mirrors to the following Smartsheet REST API method:<br />
        /// POST /workspaces/{workspaceId}/shares<br />
        /// POST /sheets/{sheetId}/shares<br />
        /// POST /sights/{sightsId}/shares<br />
        /// POST /reports/{reportId}/shares</para>
        /// </summary>
        /// <param name="objectId"> the Id of the object </param>
        /// <param name="shares"> the share objects </param>
        /// <param name="sendEmail">(optional): Either true or false to indicate whether or not
        /// to notify the user by email. Default is false.</param>
        /// <returns> the created share </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual IList<Share> ShareTo(long objectId, IEnumerable<Share> shares, bool? sendEmail = null)
        {
            StringBuilder path = new StringBuilder(MasterResourceType + "/" + objectId + "/shares");
            if (sendEmail != null)
            {
                path.Append("?sendEmail=" + sendEmail.ToString().ToLower());
            }
            return this.PostAndReceiveList<IEnumerable<Share>, Share>(path.ToString(), shares, typeof(Share));
        }


        /// <summary>
        /// <para>Updates the access level of a User or Group for the specified Object.</para>
        /// <para>It mirrors to the following Smartsheet REST API method:<br />
        /// PUT /workspaces/{workspaceId}/shares/{shareId}<br />
        /// PUT /sheets/{sheetId}/shares/{shareId}<br />
        /// PUT /sights/{sightId}/shares/{shareId}<br />
        /// PUT /reports/{reportId}/shares/{shareId}</para>
        /// </summary>
        /// <param name="objectId"> the ID of the object to share </param>
        /// <param name="share"> the share </param>
        /// <returns> the updated share (note that if there is no such resource, this method will throw
        ///  ResourceNotFoundException rather than returning null). </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual Share UpdateShare(long objectId, Share share)
        {
            return this.UpdateResource<Share>(MasterResourceType + "/" + objectId + "/shares/" + share.Id, typeof(Share), share);
        }

        /// <summary>
        /// <para>Delete a share.</para>
        /// <para>It mirrors to the following Smartsheet REST API method:<br />
        /// DELETE /workspaces/{workspaceId}/shares/{shareId}<br />
        /// DELETE /sheets/{sheetId}/shares/{shareId}<br />
        /// DELETE /sight/{sightId}/shares/{shareId}<br />
        /// DELETE /reports/{reportId}/shares/{shareId}</para>
        /// </summary>
        /// <param name="objectId"> the ID of the object to share </param>
        /// <param name="shareId"> the ID of the user to whom the object is shared </param>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual void DeleteShare(long objectId, string shareId)
        {
            this.DeleteResource<Share>(MasterResourceType + "/" + objectId + "/shares/" + shareId, typeof(Share));
        }
    }

}