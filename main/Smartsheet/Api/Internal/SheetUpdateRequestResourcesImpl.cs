using Smartsheet.Api.Internal.Util;
using Smartsheet.Api.Models;
using System.Collections.Generic;

namespace Smartsheet.Api.Internal
{
	public class SheetUpdateRequestResourcesImpl: AbstractResources, SheetUpdateRequestResources
	{
		public SheetUpdateRequestResourcesImpl(SmartsheetImpl smartsheet)
			: base(smartsheet)
		{

		}

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
		public virtual PaginatedResult<UpdateRequest> ListUpdateRequests(long sheetId, PaginationParameters paging)
		{
			IDictionary<string, string> parameters = new Dictionary<string, string>();
			if (paging != null)
			{
				parameters = paging.toDictionary();
			}
			return this.ListResourcesWithWrapper<UpdateRequest>("sheets/" + sheetId + "/updaterequests" + QueryUtil.GenerateUrl(null, parameters));
		}

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
		public virtual UpdateRequest GetUpdateRequest(long sheetId, long updateRequestId)
		{
			return this.GetResource<UpdateRequest>("sheets/" + sheetId + "/updaterequests/" + updateRequestId, typeof(UpdateRequest));
		}
	
		/// <summary>
		/// <para>Creates an Update Request for the specified Row(s) within the Sheet. An email notification
		/// (containing a link to the update request) will be asynchronously sent to the specified recipient(s).</para>
		/// <para>It mirrors To the following Smartsheet REST API method: POST /sheets/{sheetId}/updaterequests</para>
		/// </summary>
		/// <param name="sheetId"> the sheetId </param>
		/// <param name="email"> the Email </param>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual UpdateRequest CreateUpdateRequest(long sheetId, UpdateRequest updateRequest)
		{
			return this.CreateResource<RequestResult<UpdateRequest>, UpdateRequest>("sheets/" + sheetId + "/updaterequests", updateRequest).Result;
		}

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
		public virtual void DeleteUpdateRequest(long sheetId, long updateRequestId)
		{
			this.DeleteResource<UpdateRequest>("sheets/" + sheetId + "/updaterequests/" + updateRequestId, typeof(UpdateRequest));
		}

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
		public virtual UpdateRequest UpdateUpdateRequest(long sheetId, UpdateRequest updateRequest)
		{
			return this.UpdateResource("sheets/" + sheetId + "/updaterequests/" + updateRequest.Id, typeof(UpdateRequest), updateRequest);
		}

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
		public virtual PaginatedResult<SentUpdateRequest> ListSentUpdateRequests(long sheetId, PaginationParameters paging)
		{
			IDictionary<string, string> parameters = new Dictionary<string, string>();
			if (paging != null)
			{
				parameters = paging.toDictionary();
			}
			return this.ListResourcesWithWrapper<SentUpdateRequest>("sheets/" + sheetId + "/sentupdaterequests" + QueryUtil.GenerateUrl(null, parameters));
		}

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
		public virtual SentUpdateRequest GetSentUpdateRequest(long sheetId, long sentUpdateRequestId)
		{
			return this.GetResource<SentUpdateRequest>("sheets/" + sheetId + "/sentupdaterequests/" + sentUpdateRequestId, typeof(SentUpdateRequest));
		}

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
		public virtual void DeleteSentUpdateRequest(long sheetId, long sentUupdateRequestId)
		{
			this.DeleteResource<SentUpdateRequest>("sheets/" + sheetId + "/sentupdaterequests/" + sentUupdateRequestId, typeof(SentUpdateRequest));
		}
	}
}
