//    #[license]
//    Smartsheet SDK for C#
//    %%
//    Copyright (C) 2014 Smartsheet
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

namespace Smartsheet.Api.Internal
{


    using Utils = Api.Internal.Utility.Utility;
	using Discussion = Api.Models.Discussion;

	/// <summary>
	/// This is the implementation of the AssociatedDiscussionResources.
	/// 
	/// Thread Safety: This class is thread safe because it is immutable and its base class is thread safe.
	/// </summary>
	public class AssociatedDiscussionResourcesImpl : AbstractAssociatedResources, AssociatedDiscussionResources
	{

		/// <summary>
		/// Constructor.
		/// 
		/// Exceptions:
		///   IllegalArgumentException : if any argument is null or empty string
		/// </summary>
		/// <param name="smartsheet"> the Smartsheet </param>
		/// <param name="masterResourceType"> the master resource Type (e.g. "sheet", "workspace") </param>
		public AssociatedDiscussionResourcesImpl(SmartsheetImpl smartsheet, string masterResourceType) : 
            base(smartsheet,masterResourceType)
		{
		}

		/// <summary>
		/// Create a discussion.
		/// 
		/// It mirrors To the following Smartsheet REST API method: POST /sheet/{Id}/Discussions POST /row/{Id}/Discussions
		/// 
		/// Returns: the created discussion
		/// 
		/// Exceptions: 
		///   IllegalArgumentException : if any argument is null
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ResourceNotFoundException : if the resource can not be found
		///   ServiceUnavailableException : if the REST API service is not available (possibly due To rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="objectId"> the ID of the object </param>
		/// <param name="discussion"> the discussion object limited To the following attributes: Title, Comment </param>
		/// <returns> the created discussion </returns>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
		public virtual Discussion CreateDiscussion(long objectId, Discussion discussion)
		{
            Utils.ThrowIfNull(objectId, discussion);
			return this.CreateResource<Discussion>(MasterResourceType + "/" + objectId + "/discussions", 
                typeof(Discussion), discussion);
		}
	}

}