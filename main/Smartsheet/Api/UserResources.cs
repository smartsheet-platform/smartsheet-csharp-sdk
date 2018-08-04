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
    /// <para>This interface provides methods to access User resources.</para>
    /// 
    /// <para>Thread Safety: Implementation of this interface must be thread safe.</para>
    /// </summary>
    public interface UserResources
    {
        /// <summary>
        /// <para>Gets the list of Users in the organization. To filter by email, use the optional email query string
        /// parameter to specify a list of users’ email addresses.</para>
        /// <para>It mirrors to the following Smartsheet REST API method: GET /Users</para>
        /// </summary>
        /// <param name="emails">list of email addresses on which to filter the results</param>
        /// <param name="paging"> the pagination</param>
        /// <returns> the list of all Users </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        PaginatedResult<User> ListUsers(IEnumerable<string> emails = null, PaginationParameters paging = null);

        /// <summary>
        /// <para>Add a user to the organization</para>
        /// <para>It mirrors to the following Smartsheet REST API method: POST /Users</para>
        /// </summary>
        /// <param name="user"> the user </param>
        /// <param name="sendEmail"> flag indicating whether or not to send a welcome email. Defaults to false. </param>
        /// <param name="allowInviteAccountAdmin">if user is an admin in another organization, setting to true will invite their entire organization.</param>
        /// <returns> the created user </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        User AddUser(User user, bool? sendEmail = null, bool? allowInviteAccountAdmin = null);

        /// <summary>
        /// <para>Get the current user.</para>
        /// <para>It mirrors to the following Smartsheet REST API method: GET /users/me</para>
        /// </summary>
        /// <returns> the current user </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        UserProfile GetCurrentUser();

        /// <summary>
        /// <para>Gets the user.</para>
        /// <para>It mirrors to the following Smartsheet REST API method: GET /users/{userId}</para>
        /// </summary>
        /// <param name="userId"> the user Id </param>
        /// <returns> the user </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        UserProfile GetUser(long userId);

        /// <summary>
        /// <para>Update a user.</para>
        /// <para>It mirrors to the following Smartsheet REST API method: PUT /users/{userId}</para>
        /// </summary>
        /// <param name="user"> the user to update </param>
        /// <returns> the updated user </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        User UpdateUser(User user);

        /// <summary>
        /// <para>Removes a User from an organization. User is transitioned to a free collaborator with read-only access to owned sheets (unless those are optionally transferred to another user).</para>
        /// <remarks>This operation is only available to system administrators.</remarks>
        /// <para>It mirrors to the following Smartsheet REST API method: DELETE /user{Id}</para>
        /// </summary>
        /// <param name="userId"> the Id of the user </param>
        /// <param name="transferTo">(required if user owns groups): The ID of the user to transfer ownership to. 
        /// If the user being deleted owns groups, they will be transferred to this user. 
        /// If the user owns sheets, and transferSheets is true, then the deleted user’s sheets will be transferred to this user.</param>
        /// <param name="transferSheets">If true, and transferTo is specified, the deleted user’s sheets will be transferred. Else, sheets will not be transferred. Defaults to false.</param>
        /// <param name="removeFromSharing">Set to true to remove the user from sharing for all sheets/workspaces in the organization. If not specified, User will not be removed from sharing.</param>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        void RemoveUser(long userId, long? transferTo = null, bool? transferSheets = null, bool? removeFromSharing = null);

        /// <summary>
        /// <para>List all user alternate email(s).</para>
        /// <para>It mirrors to the following Smartsheet REST API method: GET /users/{userId}/alternateemails</para>
        /// </summary>
        /// <param name="userId"> the Id of the user </param>
        /// <param name="pagination"> the pagination</param>
        /// <returns> the list of all AlternateEmails </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        PaginatedResult<AlternateEmail> ListAlternateEmails(long userId, PaginationParameters pagination = null);

        /// <summary>
        /// <para>Get alternate email.</para>
        /// <para>It mirrors to the following Smartsheet REST API method: GET /users/{userId}/alternateemails/{alternateEmailId}</para>
        /// </summary>
        /// <param name="userId"> the Id of the user </param>
        /// <param name="altEmailId"> the alternate email Id</param>
        /// <returns>
        /// Return the AlternateEmail (note that if there is no such resource, this method will throw 
        /// ResourceNotFoundException rather than returning null) 
        /// </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        AlternateEmail GetAlternateEmail(long userId, long altEmailId);

        /// <summary>
        /// <para>Add alternate email(s).</para>
        /// <para>It mirrors to the following Smartsheet REST API method: POST /users/{userId}/alternateemails</para>
        /// </summary>
        /// <param name="userId"> the Id of the user </param>
        /// <param name="altEmails"> list of AlternateEmail(s)</param>
        /// <returns>
        /// Return the list of AlternateEmails (note that if there is no such resource, this method will throw 
        /// ResourceNotFoundException rather than returning null) 
        /// </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        IList<AlternateEmail> AddAlternateEmail(long userId, IEnumerable<AlternateEmail> altEmails);

        /// <summary>
        /// <para>Delete alternate email.</para>
        /// <para>It mirrors to the following Smartsheet REST API method: DELETE /users/{userId}/alternateemails/{alternateEmailId}</para>
        /// </summary>
        /// <param name="userId"> the Id of the user </param>
        /// <param name="altEmailId"> the alternate email Id</param>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        void DeleteAlternateEmail(long userId, long altEmailId);

        /// <summary>
        /// <para>Promote an alternate email to primary.</para>
        /// <para>It mirrors to the following Smartsheet REST API method: POST /users/{userId}/alternateemails/{alternateEmailId}/makeprimary</para>
        /// </summary>
        /// <param name="userId"> the Id of the user </param>
        /// <param name="altEmailId"> the alternate email Id</param>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        AlternateEmail PromoteAlternateEmail(long userId, long altEmailId);

        /// <summary>
        /// <para>Uploads a profile image for the specified user.</para>
        /// </summary>
        /// <param name="userId"> the Id of the user </param>
        /// <param name="file"> path to the image file</param>
        /// <param name="fileType"> content type of the image file</param>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        User AddProfileImage(long userId, string file, string fileType = null);

        /// <summary>
        /// <para>Return the UserSheetResources object that provides access to sheets resources associated with
        /// User resources.</para>
        /// </summary>
        /// <returns> the associated discussion resources </returns>
        UserSheetResources SheetResources { get; }
    }
}