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
using GroupMemberResources = Smartsheet.Api.GroupMemberResources;
using GroupMember = Smartsheet.Api.Models.GroupMember;


namespace Smartsheet.Api.Internal
{
	/// <summary>
	/// This is the implementation of the GroupMemberResources.
	/// 
	/// Thread Safety: This class is thread safe because it is immutable and its base class is thread safe.
	/// </summary>
	public class GroupMemberResourcesImpl : AbstractAssociatedResources, GroupMemberResources
	{

		/// <summary>
		/// Constructor.
		/// 
		/// Exceptions:
		///   IllegalArgumentException : if any argument is null or empty string
		/// </summary>
		/// <param name="smartsheet"> the Smartsheet </param>
		/// <param name="masterResourceType"> the master resource Type (e.g. "sheet", "workspace") </param>
		public GroupMemberResourcesImpl(SmartsheetImpl smartsheet, string masterResourceType)
			: base(smartsheet, masterResourceType)
		{
		}


		/// <summary>
		/// <para>Adds one or more members to a Group.</para>
		/// <para>It mirrors To the following Smartsheet REST API method: POST /groups/{groupId}/members</para>
		/// <para>If called with a single GroupMember object, and that group member already exists, error code 1129 will be returned. 
		/// If called with an array of GroupMember objects any users specified in the array that are already group members 
		/// will be ignored and omitted from the response.</para>
		/// <remarks>This operation is only available to group administrators and system administrators.</remarks>
		/// </summary>
		/// <param name="groupId"> the groupId</param>
		/// <param name="member"> the group member to add </param>
		/// <returns>  either a single group member or array of group member objects </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public IList<GroupMember> AddGroupMembers(long groupId, IList<GroupMember> members)
		{
			//return PostAndReceiveList<GroupMember>(MasterResourceType + "/" + groupId + "/members", members);
			return PostAndReceiveList<IList<GroupMember>, GroupMember>(MasterResourceType + "/" + groupId + "/members", members, typeof(GroupMember));

		}

		/// <summary>
		/// <para>Removes a member from a Group.</para>
		/// <para>It mirrors To the following Smartsheet REST API method: DELETE /groups/{groupId}/members/{userId}</para>
		/// <remarks>This operation is only available to group administrators and system administrators.</remarks>
		/// </summary>
		/// <param name="groupId"> the groupId</param>
		/// <returns> Group object that includes the list of GroupMembers </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public void RemoveGroupMember(long groupId, long userId)
		{
			DeleteResource<GroupMember>(MasterResourceType + "/" + groupId + "/members" + userId, typeof(GroupMember));
		}
	}

}