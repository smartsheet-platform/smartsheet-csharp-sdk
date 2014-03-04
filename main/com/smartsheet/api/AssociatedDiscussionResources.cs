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



	using Discussion = com.smartsheet.api.models.Discussion;

	/// <summary>
	/// <para>This interface provides methods to access Discussion resources that are associated to a resource object. Currently 
	/// discussions can be added to sheets or rows.</para>
	/// 
	/// <para>Thread Safety: Implementation of this interface must be thread safe.</para>
	/// </summary>
	public interface AssociatedDiscussionResources
	{

		/// <summary>
		/// <para>Create a discussion.</para>
		/// 
		/// <para>It mirrors to the following Smartsheet REST API method:<br /> 
		/// POST /sheet/{id}/discussions <br />
		/// POST /row/{id}/discussions</para>
		/// </summary>
		/// <param name="objectId"> the object id (sheet id or row id) </param>
		/// <param name="discussion"> the discussion object </param>
		/// <returns> the created discussion </returns>
		/// <exception cref="InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		Discussion CreateDiscussion(long objectId, Discussion discussion);
	}

}