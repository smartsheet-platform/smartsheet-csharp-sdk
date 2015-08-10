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
	using Smartsheet.Api.Models;

	public interface DiscussionAttachmentResources
	{
		/// <summary>
		/// <para>Gets a list of all Attachments that are in the Discussion</para>
		/// <para>It mirrors To the following Smartsheet REST API method: <br />
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
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		PaginatedResult<Attachment> ListAttachments(long sheetId, long discussionId, PaginationParameters paging);
	}
}