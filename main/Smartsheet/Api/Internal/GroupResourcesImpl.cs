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
	using Smartsheet.Api.Internal.Util;
	using System.Text;

	/// <summary>
	/// This is the implementation of the UserResources.
	/// 
	/// Thread Safety: This class is thread safe because it is immutable and its base class is thread safe.
	/// </summary>
	public class GroupResourcesImpl : AbstractResources, GroupResources
	{
		/// <summary>
		/// Constructor.
		/// 
		/// Exceptions: - IllegalArgumentException : if any argument is null
		/// </summary>
		/// <param name="smartsheet"> the Smartsheet </param>
		public GroupResourcesImpl(SmartsheetImpl smartsheet)
			: base(smartsheet)
		{
		}

		/// <summary>
		/// <para>List all Users.</para>
		/// <para>It mirrors To the following Smartsheet REST API method: GET /groups</para>
		/// <remarks>This operation supports pagination of results. For more information, see Paging.</remarks>
		/// </summary>
		/// <param name="paging"> the pagination</param>
		/// <returns> the list of all Users </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual PaginatedResult<Group> ListGroups(PaginationParameters paging)
		{
			StringBuilder path = new StringBuilder("groups");
			if (paging != null)
			{
				path.Append(paging.ToQueryString());
			}
			return this.ListResourcesWithWrapper<Group>(path.ToString());
		}

		/// <summary>
		/// <para>Creates a new Group.</para>
		/// <para>It mirrors To the following Smartsheet REST API method: POST /groups</para>
		/// <remarks>This operation is only available to group administrators and system administrators.</remarks>
		/// </summary>
		/// <param name="group"> the group object </param>
		/// <returns> the created group </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual Group CreateGroup(Group group)
		{
			return this.CreateResource<Group>("groups", typeof(Group), group);
		}

		/// <summary>
		/// <para>Gets the Group specified in the URL.</para>
		/// <para>It mirrors To the following Smartsheet REST API method: GET /groups/{groupId}</para>
		/// </summary>
		/// <returns> Group object that includes the list of GroupMembers </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual Group GetGroup(long groupId)
		{
			return this.GetResource<Group>("groups/" + groupId, typeof(Group));
		}

		/// <summary>
		/// <para>Updates the Group specified in the URL.</para>
		/// <para>It mirrors To the following Smartsheet REST API method: PUT /groups/{groupId}</para>
		/// <remarks>This operation is only available to group administrators and system administrators.</remarks>
		/// </summary>
		/// <param name="groupId"> the groupId </param>
		/// <param name="group"> the group To update </param>
		/// <returns> the updated user </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual Group UpdateGroup(long groupId, Group group)
		{
			return this.UpdateResource<Group>("groups/" + groupId, typeof(Group), group);
		}

		/// <summary>
		/// <para>Deletes the Group specified in the URL.</para>
		/// <remarks>This operation is only available to system administrators.</remarks>
		/// <para>It mirrors To the following Smartsheet REST API method: DELETE /groups/{groupId}</para>
		/// </summary>
		/// <param name="groupId"> the Id of the group </param>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual void DeleteGroup(long groupId)
		{
			this.DeleteResource<Group>("groups/" + groupId, typeof(Group));
		}
	}
}