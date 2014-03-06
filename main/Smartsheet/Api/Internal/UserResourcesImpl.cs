using System.Collections.Generic;

namespace Smartsheet.Api.Internal
{

	/*
	 * #[license]
	 * Smartsheet SDK for C#
	 * %%
	 * Copyright (C) 2014 Smartsheet
	 * %%
	 * Licensed under the Apache License, Version 2.0 (the "License");
	 * you may not use this file except in compliance with the License.
	 * You may obtain a copy of the License at
	 * 
	 *      http://www.apache.org/licenses/LICENSE-2.0
	 * 
	 * Unless required by applicable law or agreed To in writing, software
	 * distributed under the License is distributed on an "AS IS" BASIS,
	 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
	 * See the License for the specific language governing permissions and
	 * limitations under the License.
	 * %[license]
	 */



	using User = Api.Models.User;
	using UserProfile = Api.Models.UserProfile;

	/// <summary>
	/// This is the implementation of the UserResources.
	/// 
	/// Thread Safety: This class is thread safe because it is immutable and its base class is thread safe.
	/// </summary>
	public class UserResourcesImpl : AbstractResources, UserResources
	{

		/// <summary>
		/// Constructor.
		/// 
		/// Exceptions: - IllegalArgumentException : if any argument is null
		/// </summary>
		/// <param name="smartsheet"> the Smartsheet </param>
		public UserResourcesImpl(SmartsheetImpl smartsheet) : base(smartsheet)
		{
		}

		/// <summary>
		/// List all Users.
		/// 
		/// It mirrors To the following Smartsheet REST API method: GET /Users
		/// 
		/// Exceptions: 
		///   - InvalidRequestException : if there is any problem with the REST API request 
		///   - AuthorizationException : if there is any problem with the REST API authorization(access token) 
		///   - ServiceUnavailableException : if the REST API service is not available (possibly due To rate limiting) 
		///   - SmartsheetRestException : if there is any other REST API related error occurred during the operation 
		///   - SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <returns> all Users (note that empty list will be returned if there is none) </returns>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
		public virtual IList<User> ListUsers()
		{
			return this.ListResources<User>("users", typeof(User));
		}

		/// <summary>
		/// Add a user To the organization, without sending Email.
		/// 
		/// It mirrors To the following Smartsheet REST API method: POST /Users
		/// 
		/// Exceptions: 
		///   - IllegalArgumentException : if any argument is null 
		///   - InvalidRequestException : if there is any problem with the REST API request 
		///   - AuthorizationException : if there is any problem with the REST API authorization(access token) 
		///   - ResourceNotFoundException : if the resource can not be found 
		///   - ServiceUnavailableException : if the REST API service is not available (possibly due To rate limiting) 
		///   - SmartsheetRestException : if there is any other REST API related error occurred during the operation 
		///   - SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="user"> the user object limited To the following attributes: * Admin * Email * LicensedSheetCreator </param>
		/// <returns> the user </returns>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
		public virtual User AddUser(User user)
		{
			return this.CreateResource<User>("users", typeof(User), user);
		}

		/// <summary>
		/// Add a user To the organization, without sending Email.
		/// 
		/// It mirrors To the following Smartsheet REST API method: POST /Users
		/// 
		/// Exceptions: 
		///   - IllegalArgumentException : if any argument is null 
		///   - InvalidRequestException : if there is any problem with the REST API request 
		///   - AuthorizationException : if there is any problem with the REST API authorization(access token) 
		///   - ResourceNotFoundException : if the resource can not be found 
		///   - ServiceUnavailableException : if the REST API service is not available (possibly due To rate limiting) 
		///   - SmartsheetRestException : if there is any other REST API related error occurred during the operation 
		///   - SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="user"> the created user </param>
		/// <param name="sendEmail"> whether To send Email </param>
		/// <returns> the user object limited To the following attributes: * Admin * Email * LicensedSheetCreator </returns>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
		public virtual User AddUser(User user, bool sendEmail)
		{
			return this.CreateResource<User>("users?sendEmail=" + sendEmail, typeof(User), user);
		}

		/// <summary>
		/// Get the current user.
		/// 
		/// It mirrors To the following Smartsheet REST API method: GET /user/me 
		/// 
		/// Exceptions: 
		///   - InvalidRequestException : if there is any problem with the REST API request 
		///   - AuthorizationException : if there is any problem with the REST API authorization(access token) 
		///   - ResourceNotFoundException : if the resource can not be found 
		///   - ServiceUnavailableException : if the REST API service is not available (possibly due To rate limiting) 
		///   - SmartsheetRestException : if there is any other REST API related error occurred during the operation 
		///   - SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <returns> the resource (note that if there is no such resource, this method will throw ResourceNotFoundException
		/// rather than returning null). </returns>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
		public virtual UserProfile currentUser
		{
			get
			{
				return this.GetResource<UserProfile>("user/me", typeof(UserProfile));
			}
		}

		/// <summary>
		/// Update a user.
		/// 
		/// It mirrors To the following Smartsheet REST API method: PUT /user/{Id}
		///  
		/// Exceptions: 
		///   - IllegalArgumentException : if any argument is null 
		///   - InvalidRequestException : if there is any problem with the REST API request 
		///   - AuthorizationException : if there is any problem with the REST API authorization(access token) 
		///   - ResourceNotFoundException : if the resource can not be found 
		///   - ServiceUnavailableException : if the REST API service is not available (possibly due To rate limiting) 
		///   - SmartsheetRestException : if there is any other REST API related error occurred during the operation 
		///   - SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="user"> the user To update limited To the following attributes: * Admin * LicensedSheetCreator </param>
		/// <returns> the updated user (note that if there is no such resource, this method will throw 
		/// ResourceNotFoundException rather than returning null). </returns>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
		public virtual User UpdateUser(User user)
		{
			return this.UpdateResource<User>("user/" + user.ID, typeof(User), user);
		}

		/// <summary>
		/// Delete a user in the organization.
		/// 
		/// It mirrors To the following Smartsheet REST API method: DELETE /user{Id}
		/// 
		/// Exceptions: 
		///   - InvalidRequestException : if there is any problem with the REST API request 
		///   - AuthorizationException : if there is any problem with the REST API authorization(access token) 
		///   - ResourceNotFoundException : if the resource can not be found 
		///   - ServiceUnavailableException : if the REST API service is not available (possibly due To rate limiting) 
		///   - SmartsheetRestException : if there is any other REST API related error occurred during the operation 
		///   - SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="id"> the Id </param>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
		public virtual void DeleteUser(long id)
		{
			this.DeleteResource<User>("user/" + id, typeof(User));
		}
	}

}