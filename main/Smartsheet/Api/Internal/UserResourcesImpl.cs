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

namespace Smartsheet.Api.Internal
{
	using Api.Models;
	using System.Text;

	/// <summary>
	/// This is the implementation of the UserResources.
	/// 
	/// Thread Safety: This class is thread safe because it is immutable and its base class is thread safe.
	/// </summary>
	public class UserResourcesImpl : AbstractResources, UserResources
	{
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
			this.sheets = new UserSheetResourcesImpl(smartsheet);
		}

		/// <summary>
		/// <para>List all Users.</para>
		/// <para>It mirrors To the following Smartsheet REST API method: GET /Users</para>
		/// </summary>
		/// <param name="emails">list of emails</param>
		/// <param name="paging"> the pagination</param>
		/// <returns> the list of all Users </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual DataWrapper<User> ListUsers(IEnumerable<string> emails, PaginationParameters paging)
		{
			StringBuilder path = new StringBuilder("users");
			if (paging != null)
			{
				path.Append(paging.ToQueryString());
			}
			return this.ListResourcesWithWrapper<User>(path.ToString());
		}

		///// <summary>
		///// Add a user To the organization, without sending Email.
		///// 
		///// It mirrors To the following Smartsheet REST API method: POST /Users
		///// 
		///// Exceptions: 
		/////   - IllegalArgumentException : if any argument is null 
		/////   - InvalidRequestException : if there is any problem with the REST API request 
		/////   - AuthorizationException : if there is any problem with the REST API authorization(access token) 
		/////   - ResourceNotFoundException : if the resource can not be found 
		/////   - ServiceUnavailableException : if the REST API service is not available (possibly due To rate limiting) 
		/////   - SmartsheetRestException : if there is any other REST API related error occurred during the operation 
		/////   - SmartsheetException : if there is any other error occurred during the operation
		///// </summary>
		///// <param name="user"> the user object limited To the following attributes: * Admin * Email * LicensedSheetCreator </param>
		///// <returns> the user </returns>
		///// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
		//public virtual User AddUser(User user)
		//{
		//	return this.CreateResource<User>("users", typeof(User), user);
		//}

		/// <summary>
		/// <para>Add a user To the organization, without sending Email.</para>
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
		public virtual User AddUser(User user, bool? sendEmail)
		{
			StringBuilder path = new StringBuilder("users");
			if (sendEmail.HasValue)
			{
				path.Append("?sendEmail=" + sendEmail);
			}
			return this.CreateResource<User>(path.ToString(), typeof(User), user);
		}

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
		public virtual UserProfile GetCurrentUser()
		{
			return this.GetResource<UserProfile>("users/me", typeof(UserProfile));
		}

		/// <summary>
		/// <para>Update a user.</para>
		/// <para>It mirrors To the following Smartsheet REST API method: PUT /users/{userId}</para>
		/// </summary>
		/// <param name="userId"> the userId </param>
		/// <param name="user"> the user To update </param>
		/// <returns> the updated user </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual User UpdateUser(long userId, User user)
		{
			return this.UpdateResource<User>("users/" + userId, typeof(User), user);
		}

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
		public virtual void RemoveUser(long userId, long? transferTo, bool? transferSheets, bool? removeFromSharing)
		{
			IDictionary<string, string> parameters = new Dictionary<string, string>();
			if (transferTo != null)
			{
				parameters.Add("pageSize", transferTo.ToString());
			}
			if (transferSheets != null)
			{
				parameters.Add("pageSize", transferSheets.ToString());
			}
			if (removeFromSharing != null)
			{
				parameters.Add("pageSize", removeFromSharing.ToString());
			}
			this.DeleteResource<User>("users/" + userId + QueryUtil.GenerateUrl(null, parameters), typeof(User));
		}

		public virtual UserSheetResources SheetResources()
		{
			return this.sheets;
		} 
	}
}