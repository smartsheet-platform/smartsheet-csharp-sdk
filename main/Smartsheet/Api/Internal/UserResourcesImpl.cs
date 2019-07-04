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

using System;
using System.Collections.Generic;

namespace Smartsheet.Api.Internal
{
    using Api.Models;
    using Smartsheet.Api.Internal.Util;
    using System.Text;
    using System.Net;
    using System.IO;
    using Smartsheet.Api.Internal.Http;
    using HttpMethod = Api.Internal.Http.HttpMethod;
    using HttpRequest = Api.Internal.Http.HttpRequest;
    using HttpResponse = Api.Internal.Http.HttpResponse;

    /// <summary>
    /// This is the implementation of the UserResources.
    /// 
    /// Thread Safety: This class is thread safe because it is immutable and its base class is thread safe.
    /// </summary>
    public class UserResourcesImpl : AbstractResources, UserResources
    {
        /// <summary>
        /// Represents the SmartsheetImpl.
        /// 
        /// It will be initialized in the constructor and will not change afterwards.
        /// </summary>
        private SmartsheetImpl smartsheet;

        private UserSheetResources sheets;

        /// <summary>
        /// Constructor.
        /// 
        /// Exceptions: - IllegalArgumentException : if any argument is null
        /// </summary>
        /// <param name="smartsheet"> the Smartsheet </param>
        public UserResourcesImpl(SmartsheetImpl smartsheet)
            : base(smartsheet)
        {
            this.smartsheet = smartsheet;
            this.sheets = new UserSheetResourcesImpl(smartsheet);
        }

        /// <summary>
        /// <para>Lists all users.</para>
        /// <para>Mirrors to the following Smartsheet REST API method: GET /Users</para>
        /// </summary>
        /// <param name="emails">list of emails</param>
        /// <param name="paging"> the pagination</param>
        /// <returns> the list of all users </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual PaginatedResult<User> ListUsers(IEnumerable<string> emails, PaginationParameters paging)
        {
            return this.ListUsers(emails, null, paging);
        }

        /// <summary>
        /// <para>Lists all users.</para>
        /// <para>Mirrors to the following Smartsheet REST API method: GET /Users</para>
        /// </summary>
        /// <param name="emails">list of emails</param>
        /// <param name="includes">elements to include in response</param>
        /// <param name="paging"> the pagination</param>
        /// <returns> the list of all users </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual PaginatedResult<User> ListUsers(IEnumerable<string> emails, IEnumerable<ListUserInclusion> includes, PaginationParameters paging)
        {
            StringBuilder path = new StringBuilder("users");

            IDictionary<string, string> parameters = new Dictionary<string,string>();

            if (paging != null)
            {
                parameters = paging.toDictionary();
            }
            if (emails != null)
            {
                parameters.Add("email", string.Join(",", emails));
            }
            if (includes != null)
            {
                parameters.Add("include", QueryUtil.GenerateCommaSeparatedList(includes));
            }

            path.Append(QueryUtil.GenerateUrl(null, parameters));
            
            return this.ListResourcesWithWrapper<User>(path.ToString());
        }

        /// <summary>
        /// <para>Adds a user to the organization</para>
        /// <para>Mirrors to the following Smartsheet REST API method: POST /Users</para>
        /// </summary>
        /// <param name="user"> the user </param>
        /// <param name="sendEmail"> indicates whether to send a welcome email. Defaults to false. </param>
        /// <param name="allowInviteAccountAdmin">if user is an admin in another organization, setting to true will invite their entire organization.</param>
        /// <returns> the created user </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual User AddUser(User user, bool? sendEmail, bool? allowInviteAccountAdmin)
        {
            StringBuilder path = new StringBuilder("users");
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            if (sendEmail.HasValue)
            {
                parameters.Add("sendEmail", sendEmail.Value.ToString());
            }
            if (allowInviteAccountAdmin.HasValue)
            {
                parameters.Add("allowInviteAccountAdmin", allowInviteAccountAdmin.Value.ToString());
            }
            return this.CreateResource<User>(QueryUtil.GenerateUrl("users", parameters), typeof(User), user);
        }

        /// <summary>
        /// <para>Gets the current user.</para>
        /// <para>Mirrors to the following Smartsheet REST API method: GET /users/me</para>
        /// </summary>
        /// <returns> the current user </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual UserProfile GetCurrentUser()
        {
            return this.GetResource<UserProfile>("users/me", typeof(UserProfile));
        }

        /// <summary>
        /// <para>Get the current user.</para>
        /// <para>It mirrors to the following Smartsheet REST API method: GET /users/me</para>
        /// </summary>
        /// <param name="includes">used to specify the optional objects to include.</param>
        /// <returns> the current user </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual UserProfile GetCurrentUser(IEnumerable<UserInclusion> includes)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            if (includes != null)
            {
                parameters.Add("include", QueryUtil.GenerateCommaSeparatedList(includes));
            }

            return this.GetResource<UserProfile>("users/me" + QueryUtil.GenerateUrl(null, parameters), typeof(UserProfile));
        }

        /// <summary>
        /// <para>Gets the user.</para>
        /// <para>Mirrors to the following Smartsheet REST API method: GET /users/{userId}</para>
        /// </summary>
        /// <param name="userId"> the user Id </param>
        /// <returns> the user </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual UserProfile GetUser(long userId)
        {
            return this.GetResource<UserProfile>("users/" + userId, typeof(UserProfile));
        }

        /// <summary>
        /// <para>Updates a user.</para>
        /// <para>Mirrors to the following Smartsheet REST API method: PUT /users/{userId}</para>
        /// </summary>
        /// <param name="user"> the user to update </param>
        /// <returns> the updated user </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual User UpdateUser(User user)
        {
            return this.UpdateResource<User>("users/" + user.Id, typeof(User), user);
        }

        /// <summary>
        /// <para>Removes a user from an organization. User is transitioned to a free collaborator with read-only access to owned sheets (unless those are optionally transferred to another user).</para>
        /// <remarks>This operation is only available to system administrators.</remarks>
        /// <para>Mirrors to the following Smartsheet REST API method: DELETE /user{Id}</para>
        /// </summary>
        /// <param name="userId"> the Id of the user </param>
        /// <param name="transferTo">(required if user owns groups): The Id of the user to transfer ownership to. 
        /// If the user being deleted owns groups, they will be transferred to this user. 
        /// If the user owns sheets, and transferSheets is true, then the deleted user’s sheets will be transferred to this user.</param>
        /// <param name="transferSheets">If true, and transferTo is specified, the deleted user’s sheets will be transferred. Else, sheets will not be transferred. Defaults to false.</param>
        /// <param name="removeFromSharing">Set to true to remove the user from sharing for all sheets/workspaces in the organization. If not specified, user will not be removed from sharing.</param>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual void RemoveUser(long userId, long? transferTo, bool? transferSheets, bool? removeFromSharing)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            if (transferTo != null)
            {
                parameters.Add("transferTo", transferTo.ToString());
            }
            if (transferSheets != null)
            {
                parameters.Add("transferSheets", transferSheets.ToString());
            }
            if (removeFromSharing != null)
            {
                parameters.Add("removeFromSharing", removeFromSharing.ToString());
            }
            this.DeleteResource<User>("users/" + userId + QueryUtil.GenerateUrl(null, parameters), typeof(User));
        }

        /// <summary>
        /// <para>Lists all user alternate emails.</para>
        /// <para>Mirrors to the following Smartsheet REST API method: GET /users/{userId}/alternateemails</para>
        /// </summary>
        /// <param name="userId"> the Id of the user </param>
        /// <param name="pagination"> the pagination</param>
        /// <returns> the list of all AlternateEmails </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public PaginatedResult<AlternateEmail> ListAlternateEmails(long userId, PaginationParameters pagination)
        {
            StringBuilder path = new StringBuilder("users/" + userId + "/alternateemails");

            IDictionary<string, string> parameters = new Dictionary<string,string>();

            if (pagination != null)
            {
                parameters = pagination.toDictionary();
            }
            path.Append(QueryUtil.GenerateUrl(null, parameters));

            return this.ListResourcesWithWrapper<AlternateEmail>(path.ToString());
        }

        /// <summary>
        /// <para>Gets alternate email.</para>
        /// <para>Mirrors to the following Smartsheet REST API method: GET /users/{userId}/alternateemails/{alternateEmailId}</para>
        /// </summary>
        /// <param name="userId"> the Id of the user </param>
        /// <param name="altEmailId"> the alternate email Id</param>
        /// <returns>
        /// Return the AlternateEmail (note that if there is no such resource, this method will throw 
        /// ResourceNotFoundException rather than returning null) 
        /// </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public AlternateEmail GetAlternateEmail(long userId, long altEmailId)
        {
            return this.GetResource<AlternateEmail>("users/" + userId + "/alternateemails/" + altEmailId, typeof(AlternateEmail));
        }

        /// <summary>
        /// <para>Adds alternate emails.</para>
        /// <para>Mirrors to the following Smartsheet REST API method: POST /users/{userId}/alternateemails</para>
        /// </summary>
        /// <param name="userId"> the Id of the user </param>
        /// <param name="altEmails"> list of AlternateEmails</param>
        /// <returns>
        /// Return the list of AlternateEmails (note that if there is no such resource, this method will throw 
        /// ResourceNotFoundException rather than returning null) 
        /// </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public IList<AlternateEmail> AddAlternateEmail(long userId, IEnumerable<AlternateEmail> altEmails)
        {
            Utility.Utility.ThrowIfNull(altEmails);

            return this.PostAndReceiveList<IEnumerable<AlternateEmail>,AlternateEmail>("users/" + userId + "/alternateemails", altEmails, typeof(AlternateEmail));
        }

        /// <summary>
        /// <para>Deletes alternate email.</para>
        /// <para>Mirrors to the following Smartsheet REST API method: DELETE /users/{userId}/alternateemails/{alternateEmailId}</para>
        /// </summary>
        /// <param name="userId"> the Id of the user </param>
        /// <param name="altEmailId"> the alternate email Id</param>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public void DeleteAlternateEmail(long userId, long altEmailId)
        {
            this.DeleteResource<AlternateEmail>("users/" + userId + "/alternateemails/" + altEmailId, typeof(AlternateEmail));
        }

        /// <summary>
        /// <para>Promotes an alternate email to primary.</para>
        /// <para>Mirrors to the following Smartsheet REST API method: POST /users/{userId}/alternateemails/{alternateEmailId}/makeprimary</para>
        /// </summary>
        /// <param name="userId"> the Id of the user </param>
        /// <param name="altEmailId"> the alternate email Id</param>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual AlternateEmail PromoteAlternateEmail(long userId, long altEmailId)
        {
            HttpRequest request = null;
            try
            {
                request = CreateHttpRequest(new Uri(this.smartsheet.BaseURI, "users/" + userId + "/alternateemails/" + altEmailId + "/makeprimary"), HttpMethod.POST);
            }
            catch (Exception e)
            {
                throw new SmartsheetException(e);
            }

            HttpResponse response = this.smartsheet.HttpClient.Request(request);

            Object obj = null;
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    obj = this.smartsheet.JsonSerializer.deserializeResult<AlternateEmail>(
                        response.Entity.GetContent()).Result;
                    break;
                default:
                    HandleError(response);
                    break;
            }

            smartsheet.HttpClient.ReleaseConnection();

            return (AlternateEmail)obj;
        }

        /// <summary>
        /// <para>Uploads a profile image for the specified user.</para>
        /// </summary>
        /// <param name="userId"> the Id of the user </param>
        /// <param name="file"> path to the image file</param>
        /// <param name="fileType">fileType content type of the image file</param>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual User AddProfileImage(long userId, string file, string fileType)
        {
            return AttachProfileImage("users/" + userId + "/profileimage", file, fileType);
        }

        /// <summary>
        /// Attaches file.
        /// </summary>
        /// <param name="path"> the url path </param>
        /// <param name="file"> the file </param>
        /// <param name="contentType"> the content Type </param>
        /// <returns> the attachment </returns>
        /// <exception cref="FileNotFoundException"> the file not found exception </exception>
        /// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
        private User AttachProfileImage(string path, string file, string contentType)
        {
            Utility.Utility.ThrowIfNull(file);

            if (contentType == null)
            {
                contentType = "application/octet-stream";
            }

            FileInfo fi = new FileInfo(file);
            HttpRequest request = CreateHttpRequest(new Uri(this.Smartsheet.BaseURI, path), HttpMethod.POST);

            request.Headers["Content-Disposition"] = "attachment; filename=\"" + fi.Name + "\"";

            HttpEntity entity = new HttpEntity();
            entity.ContentType = contentType;

            entity.Content = File.ReadAllBytes(file);
            entity.ContentLength = fi.Length;
            request.Entity = entity;

            User obj = null;
            HttpResponse response = this.Smartsheet.HttpClient.Request(request);

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    obj = this.smartsheet.JsonSerializer.deserializeResult<User>(
                        response.Entity.GetContent()).Result;
                    break;
                default:
                    HandleError(response);
                    break;
            }

            this.Smartsheet.HttpClient.ReleaseConnection();
            return obj;
        }

        /// <summary>
        /// <para>Returns the UserSheetResources object that provides access to sheets resources associated with
        /// user resources.</para>
        /// </summary>
        /// <returns> the associated discussion resources </returns>
        public virtual UserSheetResources SheetResources
        {
            get { return this.sheets; }
        }
    }
}
