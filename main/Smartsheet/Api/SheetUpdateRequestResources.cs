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

namespace Smartsheet.Api
{
	public interface SheetUpdateRequestResources
	{
		/// <summary>
		/// <para>Gets a list of all Update Requests that have future schedules associated with the specified Sheet.</para>
		/// 
		/// <para>It mirrors To the following Smartsheet REST API method: GET /sheets/{sheetId}/updaterequests</para>
		/// </summary>
		/// <returns> A list of all UpdateRequests (note that an empty list will be returned if there are none). </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		PaginatedResult<UpdateRequest> ListUpdateRequests(long sheetId, PaginationParameters paging);

		/// <summary>
		/// <para>Gets the specified Update Request for the Sheet that has a future schedule.</para>
		/// 
		/// <para>It mirrors To the following Smartsheet REST API method: GET /sheets/{sheetId}/updaterequests/{updateRequestId}</para>
		/// </summary>
		/// <param name="sheetId"> the Id of the sheet </param>
		/// <param name="updateRequestId"> the update request Id </param>
		/// <returns> the update request resource (note that if there is no such resource, this method will throw 
		/// ResourceNotFoundException rather than returning null). </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		UpdateRequest GetUpdateRequest(long sheetId, long updateRequestId);

		/// <summary>
		/// <para>Creates an Update Request for the specified Row(s) within the Sheet. An email notification
		/// (containing a link to the update request) will be asynchronously sent to the specified recipient(s).</para>
		/// <para>It mirrors To the following Smartsheet REST API method: POST /sheets/{sheetId}/updaterequests</para>
		/// </summary>
		/// <param name="sheetId"> the sheetId </param>
		/// <param name="updateRequest"> the UpdateRequest object </param>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		UpdateRequest CreateUpdateRequest(long sheetId, UpdateRequest updateRequest);

		/// <summary>
		/// <para>Terminates the future scheduled delivery of the Update Request specified in the URL.</para>
		/// 
		/// <para>It mirrors To the following Smartsheet REST API method: DELETE /sheets/{sheetId}/updaterequests/{updateRequestId}</para>
		/// </summary>
		/// <param name="sheetId"> the sheetId </param>
		/// <param name="updateRequestId"> the updateRequestId </param>,
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		void DeleteUpdateRequest(long sheetId, long updateRequestId);

		/// <summary>
		/// <para>Changes the specified Update Request for the Sheet.</para>
		/// <para>It mirrors To the following Smartsheet REST API method: PUT /sheets/{sheetId}/updaterequests/{updateRequestId}</para>
		/// </summary>
		/// <param name="sheetId"> the sheet Id </param>
		/// <param name="updateRequest"> the UpdateRequest to update</param>
		/// <returns> the updated updateRequest </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		UpdateRequest UpdateUpdateRequest(long sheetId, UpdateRequest updateRequest);

		/// <summary>
		/// <para>Gets a list of all Sent Update Requests that have future schedules associated with the specified Sheet.</para>
		/// 
		/// <para>It mirrors To the following Smartsheet REST API method: GET /sheets/{sheetId}/sentupdaterequests</para>
		/// </summary>
		/// <param name="sheetId"> the Id of the sheet </param>
		/// <param name="paging">paging parameters for the list</param>
		/// <returns> A list of all SentUpdateRequests (note that an empty list will be returned if there are none). </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		PaginatedResult<SentUpdateRequest> ListSentUpdateRequests(long sheetId, PaginationParameters paging);

		/// <summary>
		/// <para>Gets the specified sent update request on the Sheet.</para>
		/// 
		/// <para>It mirrors To the following Smartsheet REST API method: GET /sheets/{sheetId}/sentupdaterequests/{updateRequestId}</para>
		/// </summary>
		/// <param name="sheetId"> the Id of the sheet </param>
		/// <param name="sentUpdateRequestId"> the sent update request Id </param>
		/// <returns> the sent update request resource (note that if there is no such resource, this method will throw 
		/// ResourceNotFoundException rather than returning null). </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		SentUpdateRequest GetSentUpdateRequest(long sheetId, long sentUpdateRequestId);

		/// <summary>
		/// <para>Deletes the specified sent update request.</para>
		/// 
		/// <para>It mirrors To the following Smartsheet REST API method: DELETE /sheets/{sheetId}/sentupdaterequests/{sentUpdateRequestId}</para>
		/// </summary>
		/// <param name="sheetId"> the Id of the sheet </param>
		/// <param name="sentUpdateRequestId"> the sent update request Id </param>,
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		void DeleteSentUpdateRequest(long sheetId, long sentUupdateRequestId);
	}
}
