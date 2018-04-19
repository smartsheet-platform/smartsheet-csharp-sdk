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
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//    %[license]

namespace Smartsheet.Api.Internal
{
	using Smartsheet.Api.Models;
    using System;
    using System.Text;

	/// <summary>
	/// This is the implementation of the AssociatedAttachmentResources for Discussions.
	/// 
	/// It extends AssociatedAttachmentResourcesImpl and overrides attachFile/attachURL methods by throwing
	/// UnsupportedOperationException (since they're not supported for Discussions).
	/// 
	/// Thread Safety: This class is thread safe because it is immutable and its base class is thread safe.
	/// </summary>
	public class DiscussionAttachmentResourcesImpl : AbstractResources, DiscussionAttachmentResources
	{
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="smartsheet"> the Smartsheet </param>
        /// <exception cref="InvalidOperationException">if any argument is null</exception>
        public DiscussionAttachmentResourcesImpl(SmartsheetImpl smartsheet)
			: base(smartsheet)
		{
		}

		/// <summary>
		/// <para>Gets a list of all Attachments that are in the Discussion</para>
		/// <para>It mirrors to the following Smartsheet REST API method: <br />
		/// GET /sheets/{sheetId}/discussions/{discussionId}/attachments</para>
		/// </summary>
		/// <param name="sheetId"> the sheetId </param>
		/// <param name="discussionId"> the discussion Id </param>
		/// <param name="paging"> the paging </param>
		/// <returns> list of all Attachments that are in the Discussion. </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual PaginatedResult<Attachment> ListAttachments(long sheetId, long discussionId, PaginationParameters paging)
		{
			StringBuilder path = new StringBuilder("sheets/" + sheetId + "/discussions/" + discussionId + "/attachments");
			if (paging != null)
			{
				path.Append(paging.ToQueryString());
			}
			return this.ListResourcesWithWrapper<Attachment>(path.ToString());
		}
	}
}