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

using Smartsheet.Api.Models;
using System.Collections.Generic;

namespace Smartsheet.Api
{
	/// <summary>
	/// <para>This interface provides methods To access Versioning resources that are associated To an Attachment resource.</para>
	/// 
	/// <para>Thread Safety: Implementation of this interface must be thread safe.</para>
	/// </summary>
	public interface AttachmentVersioningResources
	{
		/// <summary>
		/// <para>Uploads a new version of a file to a Sheet or Row.
		/// This operation can be performed using a simple upload or a multipart upload. For more information, see Posting an Attachment.</para>
		/// <para>It mirrors To the following Smartsheet REST API method:<br />
		///  POST /sheets/{sheetId}/attachments/{attachmentId}/versions</para>
		///  <remarks><para>Uploading new versions is not supported for attachments on Comments or for URL attachments.</para>
		///  <para>This is a resource-intensive operation and incurs 10 additional requests against the rate limit.</para></remarks>
		/// </summary>
		/// <param name="sheetId"> the sheet id </param>
		/// <param name="attachmentId"> the attachment id </param>
		/// <param name="file"> the file path </param>
		/// <param name="fileType"> the file type </param>
		/// <returns> Attachment object for the newly created attachment </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		Attachment AttachNewVersion(long sheetId, long attachmentId, string file, string fileType);

		/// <summary>
		/// <para>Deletes all versions of the attachment corresponding to the specified Attachment ID.
		/// For attachments with multiple versions, this will effectively delete the attachment from the object that it’s attached to.</para>
		/// <para>It mirrors To the following Smartsheet REST API method: DELETE /sheets/{sheetId}/attachments/{attachmentId}/versions</para>
		/// </summary>
		/// <param name="sheetId"> the sheetId </param>
		/// <param name="attachmentId"> the attachment id </param>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		void DeleteAllVersions(long sheetId, long attachmentId);

		/// <summary>
		/// <para>Gets a list of all versions of the given Attachment ID, in order from newest to oldest.</para>
		/// <remarks><para>This operation supports pagination of results. For more information, see Paging.</para>
		/// <para>To retrieve a download URL for a file attachment, use the Get Attachment operation for the specific version you want to download.</para></remarks>
		/// <para>It mirrors To the following Smartsheet REST API method: GET /sheets/{sheetId}/attachments/{attachmentId}/versions</para>
		/// </summary>
		/// <param name="sheetId"> the sheet id </param>
		/// <param name="attachmentId"> the attachment id </param>
		/// <param name="paging">the pagination</param>
		/// <returns>  list of all versions of the given Attachment ID. </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		DataWrapper<Attachment> ListVersions(long sheetId, long attachmentId, PaginationParameters paging);
	}
}