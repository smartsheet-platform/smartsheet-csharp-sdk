using System.Collections.Generic;

namespace com.smartsheet.api
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
	/// <para>This interface provides methods to access User resources.</para>
	/// 
	/// <para>Thread Safety: Implementation of this interface must be thread safe.</para>
	/// </summary>
	public interface UserResources
	{

		/// <summary>
		/// <para>List all users.</para>
		/// 
		/// <para>It mirrors to the following Smartsheet REST API method: GET /users</para>
		/// </summary>
		/// <returns> the list of all users </returns>
		/// <exception cref="InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		IList<User> ListUsers();

		/// <summary>
		/// <para>Add a user to the organization, without sending email.</para>
		/// 
		/// <para>It mirrors to the following Smartsheet REST API method: POST /users</para>
		/// </summary>
		/// <param name="user"> the user object </param>
		/// <returns> the user </returns>
		/// <exception cref="InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		User AddUser(User user);

		/// <summary>
		/// <para>Add a user to the organization, without sending email.</para>
		/// 
		/// <para>It mirrors to the following Smartsheet REST API method: POST /users</para>
		/// </summary>
		/// <param name="user"> the user </param>
		/// <param name="sendEmail"> the send email flag </param>
		/// <returns> the created user </returns>
		/// <exception cref="InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		User AddUser(User user, bool sendEmail);

		/// <summary>
		/// <para>Get the current user.</para>
		/// 
		/// <para>It mirrors to the following Smartsheet REST API method: GET /user/me</para>
		/// </summary>
		/// <returns> the current user </returns>
		/// <exception cref="InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		UserProfile currentUser {get;}

		/// <summary>
		/// <para>Update a user.</para>
		/// 
		/// <para>It mirrors to the following Smartsheet REST API method: PUT /user/{id}</para>
		/// </summary>
		/// <param name="user"> the user to update </param>
		/// <returns> the updated user </returns>
		/// <exception cref="InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		User UpdateUser(User user);

		/// <summary>
		/// <para>Delete a user in the organization.</para>
		/// 
		/// <para>It mirrors to the following Smartsheet REST API method: DELETE /user{id}</para>
		/// </summary>
		/// <param name="id"> the id of the user </param>
		/// <exception cref="InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		void DeleteUser(long id);
	}

}