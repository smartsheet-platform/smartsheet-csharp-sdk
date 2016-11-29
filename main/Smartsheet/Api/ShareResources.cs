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
	using MultiShare = Api.Models.MultiShare;
	using Share = Api.Models.Share;

	/// <summary>
	/// <para>This interface provides methods To access Share resources.</para>
	/// 
	/// <para>Thread Safety: Implementation of this interface must be thread safe.</para>
	/// </summary>
	public interface ShareResources
	{
		/// <summary>
		/// <para>List shares of a given object.</para>
		/// <para>It mirrors To the following Smartsheet REST API method:<br />
		/// GET /workspaces/{workspaceId}/shares <br />
		/// GET /sheets/{sheetId}/shares <br />
		/// GET /reports/{reportId}/shares</para>
		/// </summary>
		/// <param name="objectId"> the object Id </param>
		/// <param name="paging"> the pagination request </param>
		/// <param name="shareScope"> when specified with a value of <see cref="ShareScope.Worksapce"/>, the response will contain both item-level shares (scope=‘ITEM’) and workspace-level shares (scope='WORKSPACE’). </param>
		/// <returns> the list of Share objects (note that an empty list will be returned if there is none). </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		PaginatedResult<Share> ListShares(long objectId, PaginationParameters paging, ShareScope shareScope);

		/// <summary>
		/// <para>Get a Share.</para>
		/// 
		/// <para>It mirrors To the following Smartsheet REST API method:<br />
		/// GET /workspaces/{workspaceId}/shares/{shareId}<br />
		/// GET /sheets/{sheetId}/shares/{shareId}<br />
		/// GET /reports/{reportId}/shares/{shareId}</para>
		/// </summary>
		/// <param name="objectId"> the ID of the object To share </param>
		/// <param name="shareId"> the ID of the share instance </param>
		/// <returns> the share (note that if there is no such resource, this method will throw ResourceNotFoundException
		/// rather than returning null). </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		Share GetShare(long objectId, string shareId);

		/// <summary>
		/// <para>Shares a Sheet with the specified Users and Groups.</para>
		/// 
		/// <para>It mirrors To the following Smartsheet REST API method:<br />
		/// POST /workspaces/{workspaceId}/shares<br />
		/// POST /sheets/{sheetId}/shares<br />
		/// POST /reports/{reportId}/shares</para>
		/// </summary>
		/// <param name="objectId"> the Id of the object, (report, sheet, or workspace) </param>
		/// <param name="shares"> the share objects </param>
		/// <param name="sendEmail">(optional): Either true or false to indicate whether or not
		/// to notify the user by email. Default is false.</param>
		/// <returns> the created share </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		IList<Share> ShareTo(long objectId, IEnumerable<Share> shares, bool? sendEmail);

		///// <summary>
		///// <para>Share the object.</para>
		///// 
		///// <para>It mirrors To the following Smartsheet REST API method:<br />
		///// POST /workspace/{Id}/shares<br />
		///// POST /sheet/{Id}/shares</para>
		///// </summary>
		///// <param name="objectId"> the ID of the object To share </param>
		///// <param name="share"> the share object </param>
		///// <param name="sendEmail"> the send Email flag </param>
		///// <returns> the created share </returns>
		///// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		///// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		///// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		///// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		///// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		///// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		//Share ShareTo(long objectId, Share share, bool sendEmail);

		///// <summary>
		///// <para>Share the object with multiple Users, without sending Email.</para>
		///// 
		///// <para>It mirrors To the following Smartsheet REST API method:<br />
		///// POST /workspace/{Id}/multishare<br />
		///// POST /sheet/{Id}/multishare</para>
		///// </summary>
		///// <param name="objectId"> the ID of the object To share </param>
		///// <param name="multiShare"> the multi share object </param>
		///// <returns> the list of created Shares </returns>
		///// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		///// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		///// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		///// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		///// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		///// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		//IList<Share> ShareTo(long objectId, MultiShare multiShare);

		///// <summary>
		///// <para>Share the object with multiple Users.</para>
		///// 
		///// <para>It mirrors To the following Smartsheet REST API method:<br />
		///// POST /workspace/{Id}/multishare<br />
		///// POST/sheet/{Id}/multishare</para>
		///// 
		///// Parameters: - ObjectId : the ID of the object To share - multiShare : the MultiShare object - sendEmail : whether
		///// To send Email
		///// </summary>
		///// <param name="objectId"> the object Id </param>
		///// <param name="multiShare"> the multi share </param>
		///// <param name="sendEmail"> the send Email flag </param>
		///// <returns> the list of shares that were created </returns>
		///// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		///// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		///// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		///// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		///// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		///// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		//IList<Share> ShareTo(long objectId, MultiShare multiShare, bool sendEmail);

		/// <summary>
		/// <para>Updates the access level of a User or Group for the specified Object.</para>
		/// <para>It mirrors To the following Smartsheet REST API method:<br />
		/// PUT /workspaces/{workspaceId}/shares/{shareId}<br />
		/// PUT /sheets/{sheetId}/shares/{shareId}<br />
		/// PUT /reports/{reportId}/shares/{shareId}</para>
		/// </summary>
		/// <param name="objectId"> the ID of the object To share, (report, sheet, or workspace)  </param>
		/// <param name="share"> the share </param>
		/// <returns> the updated share (note that if there is no such resource, this method will throw
		///  ResourceNotFoundException rather than returning null). </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		Share UpdateShare(long objectId, Share share);

		/// <summary>
		/// <para>Delete a share.</para>
		/// <para>It mirrors To the following Smartsheet REST API method:<br />
		/// DELETE /workspaces/{workspaceId}/shares/{shareId}<br />
		/// DELETE /sheets/{sheetId}/shares/{shareId}<br />
		/// DELETE /reports/{reportId}/shares/{shareId}</para>
		/// </summary>
		/// <param name="objectId"> the ID of the object To share, (report, sheet, or workspace)  </param>
		/// <param name="shareId"> the ID of the user To whome the object is shared </param>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		void DeleteShare(long objectId, string shareId);
	}

}