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
	using Smartsheet.Api.Models;
	using Smartsheet.Api.Internal.Util;
	using System;

	public class SightResourcesImpl : AbstractResources, SightResources
	{
		/// <summary>
		/// Represents the ShareResources.
		/// 
		/// It will be initialized in constructor and will not change afterwards.
		/// </summary>
		private ShareResources shares;

		/// <summary>
		/// Constructor.
		/// 
		/// Exceptions: - IllegalArgumentException : if any argument is null
		/// </summary>
		/// <param name="smartsheet"> the Smartsheet </param>
		public SightResourcesImpl(SmartsheetImpl smartsheet)
			: base(smartsheet)
		{
			this.shares = new ShareResourcesImpl(smartsheet, "sights");
		}

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
		public virtual PaginatedResult<Sight> ListSights(PaginationParameters paging, DateTime? modifiedSince)
		{
			IDictionary<string, string> parameters = new Dictionary<string, string>();
			if (paging != null)
			{
				parameters = paging.toDictionary();
			}

			return this.ListResourcesWithWrapper<Sight>("sights" + QueryUtil.GenerateUrl(null, parameters));
		}

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
		public virtual Sight GetSight(long sightId)
		{
			return this.GetResource<Sight>("sights/" + sightId, typeof(Sight));
		}

		/// <summary>
		/// <para>Updates (renames) the specified Sight.</para>
		/// <para>The request body is limited to the name attribute.</para>
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
		public virtual Sight UpdateSight(Sight sight)
		{
			return this.UpdateResource("sights/" + sight.Id, typeof(Sight), sight);
		}

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
		public virtual void DeleteSight(long sightId)
		{
			this.DeleteResource<Sight>("sights/" + sightId, typeof(Sight));
		}

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
		public virtual Sight CopySight(long sightId, ContainerDestination destination)
		{
			return this.CreateResource<RequestResult<Sight>, ContainerDestination>("sights/" + sightId + "/copy", destination).Result;
		}

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
		public virtual Sight MoveSight(long sightId, ContainerDestination destination)
		{
			return this.CreateResource<RequestResult<Sight>, ContainerDestination>("sights/" + sightId + "/move", destination).Result;
		}

		/// <summary>
		/// <para>Get the publish status of a sight.</para>
		/// 
		/// <para>It mirrors to the following Smartsheet REST API method: GET /sights/{id}/publish</para>
		/// </summary>
		/// <param name="sightId"> the sightId </param>
		/// <returns>
		/// The sights publish status (note that if there is no such resource, this method will 
		/// throw ResourceNotFoundException rather than returning null).
		/// </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public SightPublish GetPublishStatus(long sightId)
		{
			return this.GetResource<SightPublish>("sights/" + sightId + "/publish", typeof(SightPublish));
		}

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
		public SightPublish UpdatePublishStatus(long sightId, SightPublish sightPublish)
		{
			return this.UpdateResource<SightPublish>("sights/" + sightId + "/publish", typeof(SightPublish), sightPublish);
		}

		/// <summary>
		/// Returns the ShareResources object that provides access To Share resources associated with Sight resources.
		/// </summary>
		/// <returns> the ShareResources object </returns>
		public virtual ShareResources ShareResources
		{
			get
			{
				return this.shares;
			}
		}
	}
}
