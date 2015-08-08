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
//    Unless required by applicable law or agreed To in writing, software
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
	/// <para>This interface provides methods To access User resources.</para>
	/// 
	/// <para>Thread Safety: Implementation of this interface must be thread safe.</para>
	/// </summary>
	public interface UserResources
	{
		/// <summary>
		/// <para>Gets the list of Users in the organization. To filter by email, use the optional email query string
		/// parameter to specify a list of users’ email addresses.</para>
		/// <para>It mirrors To the following Smartsheet REST API method: GET /Users</para>
		/// </summary>
		/// <param name="emails">list of email addresses on which to filter the results</param>
		/// <param name="paging"> the pagination</param>
		/// <returns> the list of all Users </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		PaginatedResult<User> ListUsers(IEnumerable<string> emails, PaginationParameters paging);

		/// <summary>
		/// <para>Add a user To the organization</para>
		/// <para>It mirrors To the following Smartsheet REST API method: POST /Users</para>
		/// </summary>
		/// <param name="user"> the user </param>
		/// <param name="sendEmail"> flag indicating whether or not to send a welcome email. Defaults to false. </param>
		/// <returns> the created user </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		User AddUser(User user, bool? sendEmail);

		/// <summary>
		/// <para>Get the current user.</para>
		/// <para>It mirrors To the following Smartsheet REST API method: GET /users/me</para>
		/// </summary>
		/// <returns> the current user </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		UserProfile GetCurrentUser();

		/// <summary>
		/// <para>Gets the user.</para>
		/// <para>It mirrors To the following Smartsheet REST API method: GET /users/{userId}</para>
		/// </summary>
		/// <param name="userId"> the user Id </param>
		/// <returns> the user </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		UserProfile GetUser(long userId);

		/// <summary>
		/// <para>Update a user.</para>
		/// <para>It mirrors To the following Smartsheet REST API method: PUT /users/{userId}</para>
		/// </summary>
		/// <param name="user"> the user To update </param>
		/// <returns> the updated user </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		User UpdateUser(User user);

		/// <summary>
		/// <para>Removes a User from an organization. User is transitioned to a free collaborator with read-only access to owned sheets (unless those are optionally transferred to another user).</para>
		/// <remarks>This operation is only available to system administrators.</remarks>
		/// <para>It mirrors To the following Smartsheet REST API method: DELETE /user{Id}</para>
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
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		void RemoveUser(long userId, long? transferTo, bool? transferSheets, bool? removeFromSharing);

		/// <summary>
		/// <para>Return the UserSheetResources object that provides access To sheets resources associated with
		/// User resources.</para>
		/// </summary>
		/// <returns> the associated discussion resources </returns>
		UserSheetResources SheetResources { get; }
	}
}