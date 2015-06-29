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
	using Smartsheet.Api.Internal.Utility;
	using Group = Api.Models.Group;
	using DataWrapper = Api.Models.DataWrapper<Api.Models.Group>;
	using Smartsheet.Api.Models;

	/// <summary>
	/// This is the implementation of the FolderResources.
	/// 
	/// Thread Safety: This class is thread safe because it is immutable and its base class is thread safe.
	/// </summary>
	public class GroupResourcesImpl : AbstractResources, GroupResources
	{
		private GroupMemberResources groupMemberResources;


		/// <summary>
		/// Constructor.
		/// 
		/// Parameters: - Smartsheet : the SmartsheetImpl
		/// 
		/// Exceptions: - IllegalArgumentException : if any argument is null
		/// </summary>
		/// <param name="smartsheet"> the Smartsheet </param>
		public GroupResourcesImpl(SmartsheetImpl smartsheet)
			: base(smartsheet)
		{
			this.groupMemberResources = new GroupMemberResourcesImpl(smartsheet, "groups");
		}

		/// <summary>
		/// <para>Gets the Group specified in the URL.</para>
		/// <para>It mirrors To the following Smartsheet REST API method: GET /groups/{groupId}</para>
		/// </summary>
		/// <param name="groupId"> the groupId</param>
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
		/// <para>Updates a Group.</para>
		/// <para>It mirrors To the following Smartsheet REST API method: PUT /folders/{folderId}</para>
		/// <remarks>This operation is only available to group administrators and system administrators.</remarks>
		/// </summary>
		/// <param name="groupId"> the group Id </param>
		/// <param name="group"> the group To update </param>
		/// <returns>  Group object for the updated group </returns>
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
		/// <para>Deletes a Group.</para>
		/// <para>It mirrors To the following Smartsheet REST API method:<br />
		/// DELETE /groups/{groupId}</para>
		/// <remarks>This operation is only available to group administrators and system administrators.</remarks>
		/// </summary>
		/// <param name="groupId"> the groupId</param>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public void DeleteGroup(long groupId)
		{
			this.DeleteResource<Group>("groups/" + groupId, typeof(Group));
		}


		/// <summary>
		/// <para>Gets the list of all Groups in an organization. To fetch the members of an individual group, use the Get Group operation.</para>
		/// <remarks>This operation supports pagination of results. For more information, see Paging.</remarks>
		/// <para>It mirrors To the following Smartsheet REST API method:<br /> GET /groups</para>
		/// </summary>
		/// <param name="includeAll"> If true, include all results (i.e. do not paginate).  </param>
		/// <param name="pageSize"> The maximum number of items to return per page. Defaults to 100 </param>
		/// <param name="page"> Which page to return. Defaults to 1 </param>
		/// <returns> list of Group objects </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public DataWrapper ListGroups(PaginationParameters paging)
		{
			return this.ListResourcesWithWrapper<Group>("groups" + paging.ToQueryString());
		}


		/// <summary>
		/// <para>Creates a new Group.</para>
		/// <para>It mirrors To the following Smartsheet REST API method:<br />
		/// POST /groups</para>
		/// <remarks>This operation is only available to group administrators and system administrators.</remarks>
		/// </summary>
		/// <param name="group"> the group To create </param>
		/// <returns> the created group </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public Group CreateGroup(Group group)
		{
			return this.CreateResource<Group>("groups/", typeof(Group), group);
		}

		/// <summary>
		/// Returns access to GroupMemberResources.
		/// </summary>
		/// <returns></returns>
		public GroupMemberResources GroupMemberResources()
		{
			return this.groupMemberResources;
		}
	}
}