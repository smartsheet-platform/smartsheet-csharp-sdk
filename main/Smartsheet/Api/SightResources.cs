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
	using System;

	public interface SightResources
	{
		/// <summary>
		/// <para>Gets the list of all Sights that the User has access to.</para>
		/// 
		/// <para>It mirrors To the following Smartsheet REST API method: GET /sights</para>
		/// </summary>
		/// <returns>IndexResult object containing an array of Sight objects limited to the following attributes:
		///		id, name, accessLevel, permalink, createdAt, modifiedAt 
		/// </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		PaginatedResult<Sight> ListSights(PaginationParameters paging, DateTime? modifiedSince = null);

		/// <summary>
		/// <para>Get a specified Sight.</para>
		/// 
		/// <para>It mirrors To the following Smartsheet REST API method: GET /sights/{sightId}</para>
		/// </summary>
		/// <param name="sightId"> the Id of the sight </param>
		/// <returns> the sight resource (note that if there is no such resource, this method will throw 
		/// ResourceNotFoundException rather than returning null). </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		Sight GetSight(long sightId);

		/// <summary>
		/// <para>Updates (renames) the specified Sight.</para>
		/// The request body is limited to the name attribute.</para>
		/// <para>It mirrors To the following Smartsheet REST API method: PUT /sights/{sightId}</para>
		/// </summary>
		/// <param name="sight"> the sight To update </param>
		/// <returns> the updated sight </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		Sight UpdateSight(Sight sight);

		/// <summary>
		/// <para>Delete a sight.</para>
		/// 
		/// <para>It mirrors To the following Smartsheet REST API method: DELETE /sights/{sightId}</para>
		/// </summary>
		/// <param name="sightId"> the sightId </param>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		void DeleteSight(long sightId);

		/// <summary>
		/// <para>Creates a copy of the specified Sight.</para>
		/// <para>It mirrors To the following Smartsheet REST API method:<br />
		/// POST /sights/{sightId}/copy</para>
		/// </summary>
		/// <param name="sightId"> the sightId </param>
		/// <param name="destination"> the destination to copy to </param>
		/// <returns>Result object containing a Sight for the newly created Sight, limited to the following attributes:
		///		id, name, accessLevel, permalink.</returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		Sight CopySight(long sightId, ContainerDestination destination);

		/// <summary>
		/// <para>Moves the specified Sight to a new location.</para>
		/// <para>It mirrors To the following Smartsheet REST API method:<br />
		/// POST /sights/{sightId}/move</para>
		/// </summary>
		/// <param name="sightId"> the sightId </param>
		/// <param name="destination"> the destination to copy to </param>
		/// <returns> the moved sight </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		Sight MoveSight(long sightId, ContainerDestination destination);

		/// <summary>
		/// <para>Get the publish status of a sight.</para>
		/// 
		/// <para>It mirrors to the following Smartsheet REST API method: GET /sights/{id}/publish</para>
		/// </summary>
		/// <param name="sightId"> the sightId </param>
		/// <returns>
		/// The sight publish status (note that if there is no such resource, this method will 
		/// throw ResourceNotFoundException rather than returning null).
		/// </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		SightPublish GetPublishStatus(long sightId);

		/// <summary>
		/// <para>
		/// Sets the publish status of a sight and returns the new status, including the URLs of any enabled publishing.
		/// </para>
		/// 
		/// <para>It mirrors to the following Smartsheet REST API method: PUT /sights/{id}/publish</para>
		/// </summary>
		/// <param name="sightId"> the sightId </param>
		/// <param name="sightPublish"> the SightPublish object</param>
		/// <returns>
		/// The sight publish status (note that if there is no such resource, this method will 
		/// throw ResourceNotFoundException rather than returning null).
		/// </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		SightPublish UpdatePublishStatus(long sightId, SightPublish sightPublish);
		
		/// <summary>
		/// <para>Returns the ShareResources object that provides access To Share resources associated with Sight resources.</para>
		/// </summary>
		/// <returns> the share resources object </returns>
		ShareResources ShareResources { get; }
	}
}
