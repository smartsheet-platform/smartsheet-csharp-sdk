using System.Collections.Generic;

namespace Smartsheet.Api.Internal
{

	/*
	 * #[license]
	 * Smartsheet SDK for C#
	 * %%
	 * Copyright (C) 2014 Smartsheet
	 * %%
	 * Licensed under the Apache License, Version 2.0 (the "License");
	 * you may not use this file except in compliance with the License.
	 * You may obtain a copy of the License at
	 * 
	 *      http://www.apache.org/licenses/LICENSE-2.0
	 * 
	 * Unless required by applicable law or agreed To in writing, software
	 * distributed under the License is distributed on an "AS IS" BASIS,
	 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
	 * See the License for the specific language governing permissions and
	 * limitations under the License.
	 * %[license]
	 */

	using MultiShare = Api.Models.MultiShare;
	using Share = Api.Models.Share;

	/// <summary>
	/// This is the implementation of the ShareResources.
	/// 
	/// Thread Safety: This class is thread safe because it is immutable and its base class is thread safe.
	/// </summary>
	public class ShareResourcesImpl : AbstractAssociatedResources, ShareResources
	{

		/// <summary>
		/// Constructor.
		/// 
		/// Exceptions: - IllegalArgumentException : if any argument is null or empty string
		/// </summary>
		/// <param Name="Smartsheet"> the Smartsheet </param>
		/// <param Name="masterResourceType"> the master resource Type (e.g. "sheet", "workspace") </param>
		public ShareResourcesImpl(SmartsheetImpl smartsheet, string masterResourceType) : base(smartsheet, masterResourceType)
		{
		}

		/// <summary>
		/// List shares of a given object.
		/// 
		/// It mirrors To the following Smartsheet REST API method: GET /workspace/{Id}/shares GET /sheet/{Id}/shares
		/// 
		/// Exceptions:
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ResourceNotFoundException : if the resource can not be found
		///   ServiceUnavailableException : if the REST API service is not available (possibly due To rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param Name="ObjectId"> the Id of the object To share. </param>
		/// <returns> the shares (note that empty list will be returned if there is none) </returns>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
		public virtual IList<Share> ListShares(long objectId)
		{
			return this.ListResources<Share>(MasterResourceType + "/" + objectId + "/shares", typeof(Share));
		}

		/// <summary>
		/// Get a Share.
		/// 
		/// It mirrors To the following Smartsheet REST API method: GET /workspace/{Id}/share/{userId} GET
		/// /sheet/{Id}/share/{userId}
		/// 
		/// Exceptions:
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ResourceNotFoundException : if the resource can not be found
		///   ServiceUnavailableException : if the REST API service is not available (possibly due To rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param Name="ObjectId"> the ID of the object To share </param>
		/// <param Name="userId"> the ID of the user To whome the object is shared </param>
		/// <returns> the share (note that if there is no such resource, this method will throw ResourceNotFoundException
		/// rather than returning null). </returns>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
		public virtual Share GetShare(long objectId, long userId)
		{
			return this.GetResource<Share>(MasterResourceType + "/" + objectId + "/share/" + userId, typeof(Share));
		}

		/// <summary>
		/// Share the object, without sending Email.
		/// 
		/// It mirrors To the following Smartsheet REST API method: POST /workspace/{Id}/shares POST /sheet/{Id}/shares
		/// 
		/// Exceptions:
		///   IllegalArgumentException : if share is null
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ResourceNotFoundException : if the resource can not be found
		///   ServiceUnavailableException : if the REST API service is not available (possibly due To rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param Name="ObjectId"> the ID of the object To share - share : the share object </param>
		/// <param Name="share"> the share </param>
		/// <returns> the created share </returns>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
		public virtual Share ShareTo(long objectId, Share share)
		{
			return this.CreateResource<Share>(MasterResourceType + "/" + objectId + "/shares", typeof(Share), share);
		}

		/// <summary>
		/// Share the object.
		/// 
		/// It mirrors To the following Smartsheet REST API method: POST /workspace/{Id}/shares POST /sheet/{Id}/shares
		/// 
		/// Returns: the created share
		/// 
		/// Exceptions:
		///   IllegalArgumentException : if share is null
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ResourceNotFoundException : if the resource can not be found
		///   ServiceUnavailableException : if the REST API service is not available (possibly due To rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param Name="ObjectId"> the Id of the object To share </param>
		/// <param Name="share"> the share object </param>
		/// <param Name="sendEmail"> whether To send Email </param>
		/// <returns> the created share </returns>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
		public virtual Share ShareTo(long objectId, Share share, bool sendEmail)
		{
			return this.CreateResource<Share>(MasterResourceType + "/" + objectId + "/shares?sendEmail=" + sendEmail, typeof(Share), share);
		}

		/// <summary>
		/// Share the object with multiple Users, without sending Email.
		/// 
		/// It mirrors To the following Smartsheet REST API method: POST /workspace/{Id}/multishare POST
		/// /sheet/{Id}/multishare
		/// 
		/// Exceptions:
		///   IllegalArgumentException : if multiShare is null
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ResourceNotFoundException : if the resource can not be found
		///   ServiceUnavailableException : if the REST API service is not available (possibly due To rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param Name="ObjectId"> the ID of the object To share </param>
		/// <param Name="multiShare"> the MultiShare object </param>
		/// <returns> the created shares </returns>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
		public virtual IList<Share> ShareTo(long objectId, MultiShare multiShare)
		{
			return this.PostAndReceiveList<MultiShare,Share>(MasterResourceType + "/" + objectId + "/multishare", multiShare, typeof(Share));
		}

		/// <summary>
		/// Share the object with multiple Users.
		/// 
		/// It mirrors To the following Smartsheet REST API method: POST /workspace/{Id}/multishare POST
		/// /sheet/{Id}/multishare
		/// 
		/// Exceptions:
		///   IllegalArgumentException : if multiShare is null
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ResourceNotFoundException : if the resource can not be found
		///   ServiceUnavailableException : if the REST API service is not available (possibly due To rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param Name="ObjectId"> the ID of the object To share </param>
		/// <param Name="multiShare"> the MultiShare object </param>
		/// <param Name="sendEmail"> whether To send Email </param>
		/// <returns> the created shares </returns>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
		public virtual IList<Share> ShareTo(long objectId, MultiShare multiShare, bool sendEmail)
		{
			return this.PostAndReceiveList<MultiShare,Share>(MasterResourceType + "/" + objectId + "/multishare?sendEmail=" + sendEmail, multiShare, typeof(Share));
		}

		/// <summary>
		/// Update a share.
		/// 
		/// It mirrors To the following Smartsheet REST API method: PUT /workspace/{Id}/share/{userId} PUT
		/// /sheet/{Id}/share/{userId}
		/// 
		/// Exceptions:
		///   IllegalArgumentException : if share is null
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ResourceNotFoundException : if the resource can not be found
		///   ServiceUnavailableException : if the REST API service is not available (possibly due To rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param Name="ObjectId"> the ID of the object To share </param>
		/// <param Name="userId"> the ID of the user To whom the object is shared </param>
		/// <param Name="share"> the share </param>
		/// <returns> the updated share (note that if there is no such resource, this method will throw
		/// ResourceNotFoundException rather than returning null). </returns>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
		public virtual Share UpdateShare(long objectId, long userId, Share share)
		{
			return this.UpdateResource<Share>(MasterResourceType + "/" + objectId + "/share/" + userId, typeof(Share), share);
		}

		/// <summary>
		/// Delete a share.
		/// 
		/// It mirrors To the following Smartsheet REST API method: DELETE /workspace/{Id}/share/{userId} DELETE
		/// /sheet/{Id}/share/{userId}
		/// 
		/// Exceptions:
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ResourceNotFoundException : if the resource can not be found
		///   ServiceUnavailableException : if the REST API service is not available (possibly due To rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param Name="ObjectId"> the ID of the object To share </param>
		/// <param Name="userId"> the ID of the user To whom the object is shared </param>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
		public virtual void DeleteShare(long objectId, long userId)
		{
			this.DeleteResource<Share>(MasterResourceType + "/" + objectId + "/share/" + userId, typeof(Share));
		}
	}

}