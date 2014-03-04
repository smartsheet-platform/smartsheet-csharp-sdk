using System.Collections.Generic;

namespace com.smartsheet.api.@internal
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
	 * Unless required by applicable law or agreed to in writing, software
	 * distributed under the License is distributed on an "AS IS" BASIS,
	 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
	 * See the License for the specific language governing permissions and
	 * limitations under the License.
	 * %[license]
	 */



	using User = com.smartsheet.api.models.User;
	using UserProfile = com.smartsheet.api.models.UserProfile;

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
		/// <param name="smartsheet"> the smartsheet </param>
		public UserResourcesImpl(SmartsheetImpl smartsheet) : base(smartsheet)
		{
		}

		/// <summary>
		/// List all users.
		/// 
		/// It mirrors to the following Smartsheet REST API method: GET /users
		/// 
		/// Exceptions: 
		///   - InvalidRequestException : if there is any problem with the REST API request 
		///   - AuthorizationException : if there is any problem with the REST API authorization(access token) 
		///   - ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting) 
		///   - SmartsheetRestException : if there is any other REST API related error occurred during the operation 
		///   - SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <returns> all users (note that empty list will be returned if there is none) </returns>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		public virtual IList<User> ListUsers()
		{
			return this.ListResources<User>("users", typeof(User));
		}

		/// <summary>
		/// Add a user to the organization, without sending email.
		/// 
		/// It mirrors to the following Smartsheet REST API method: POST /users
		/// 
		/// Exceptions: 
		///   - IllegalArgumentException : if any argument is null 
		///   - InvalidRequestException : if there is any problem with the REST API request 
		///   - AuthorizationException : if there is any problem with the REST API authorization(access token) 
		///   - ResourceNotFoundException : if the resource can not be found 
		///   - ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting) 
		///   - SmartsheetRestException : if there is any other REST API related error occurred during the operation 
		///   - SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="user"> the user object limited to the following attributes: * admin * email * licensedSheetCreator </param>
		/// <returns> the user </returns>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		public virtual User AddUser(User user)
		{
			return this.CreateResource<User>("users", typeof(User), user);
		}

		/// <summary>
		/// Add a user to the organization, without sending email.
		/// 
		/// It mirrors to the following Smartsheet REST API method: POST /users
		/// 
		/// Exceptions: 
		///   - IllegalArgumentException : if any argument is null 
		///   - InvalidRequestException : if there is any problem with the REST API request 
		///   - AuthorizationException : if there is any problem with the REST API authorization(access token) 
		///   - ResourceNotFoundException : if the resource can not be found 
		///   - ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting) 
		///   - SmartsheetRestException : if there is any other REST API related error occurred during the operation 
		///   - SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="user"> the created user </param>
		/// <param name="sendEmail"> whether to send email </param>
		/// <returns> the user object limited to the following attributes: * admin * email * licensedSheetCreator </returns>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		public virtual User AddUser(User user, bool sendEmail)
		{
			return this.CreateResource<User>("users?sendEmail=" + sendEmail, typeof(User), user);
		}

		/// <summary>
		/// Get the current user.
		/// 
		/// It mirrors to the following Smartsheet REST API method: GET /user/me 
		/// 
		/// Exceptions: 
		///   - InvalidRequestException : if there is any problem with the REST API request 
		///   - AuthorizationException : if there is any problem with the REST API authorization(access token) 
		///   - ResourceNotFoundException : if the resource can not be found 
		///   - ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting) 
		///   - SmartsheetRestException : if there is any other REST API related error occurred during the operation 
		///   - SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <returns> the resource (note that if there is no such resource, this method will throw ResourceNotFoundException
		/// rather than returning null). </returns>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
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
		/// It mirrors to the following Smartsheet REST API method: PUT /user/{id}
		///  
		/// Exceptions: 
		///   - IllegalArgumentException : if any argument is null 
		///   - InvalidRequestException : if there is any problem with the REST API request 
		///   - AuthorizationException : if there is any problem with the REST API authorization(access token) 
		///   - ResourceNotFoundException : if the resource can not be found 
		///   - ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting) 
		///   - SmartsheetRestException : if there is any other REST API related error occurred during the operation 
		///   - SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="user"> the user to update limited to the following attributes: * admin * licensedSheetCreator </param>
		/// <returns> the updated user (note that if there is no such resource, this method will throw 
		/// ResourceNotFoundException rather than returning null). </returns>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		public virtual User UpdateUser(User user)
		{
			return this.UpdateResource<User>("user/" + user.id, typeof(User), user);
		}

		/// <summary>
		/// Delete a user in the organization.
		/// 
		/// It mirrors to the following Smartsheet REST API method: DELETE /user{id}
		/// 
		/// Exceptions: 
		///   - InvalidRequestException : if there is any problem with the REST API request 
		///   - AuthorizationException : if there is any problem with the REST API authorization(access token) 
		///   - ResourceNotFoundException : if the resource can not be found 
		///   - ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting) 
		///   - SmartsheetRestException : if there is any other REST API related error occurred during the operation 
		///   - SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="id"> the id </param>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		public virtual void DeleteUser(long id)
		{
			this.DeleteResource<User>("user/" + id, typeof(User));
		}
	}

}