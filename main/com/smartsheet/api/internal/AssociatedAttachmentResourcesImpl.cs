using System.Collections.Generic;

namespace com.smartsheet.api.@internal
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
	 * Unless required by applicable law or agreed to in writing, software
	 * distributed under the License is distributed on an "AS IS" BASIS,
	 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
	 * See the License for the specific language governing permissions and
	 * limitations under the License.
	 * %[license]
	 */




	using HttpEntity = com.smartsheet.api.@internal.http.HttpEntity;
	using HttpMethod = com.smartsheet.api.@internal.http.HttpMethod;
	using HttpRequest = com.smartsheet.api.@internal.http.HttpRequest;
	using HttpResponse = com.smartsheet.api.@internal.http.HttpResponse;
	using Util = com.smartsheet.api.@internal.util.Util;
	using Attachment = com.smartsheet.api.models.Attachment;
    using System.IO;
    using System.Net;
    using System.Text;
    using System;

	/// <summary>
	/// This is the implementation of the AssociatedAttachmentResources.
	/// 
	/// Thread Safety: This class is thread safe because it is immutable and its base class is thread safe.
	/// </summary>
	public class AssociatedAttachmentResourcesImpl : AbstractAssociatedResources, AssociatedAttachmentResources
	{

		/// <summary>
		/// Constructor.
		/// 
		/// Exceptions:
		///   IllegalArgumentException : if any argument is null or empty string
		/// </summary>
		/// <param name="smartsheet"> the smartsheet </param>
		/// <param name="masterResourceType"> the master resource type (e.g. "sheet", "workspace") </param>
		public AssociatedAttachmentResourcesImpl(SmartsheetImpl smartsheet, string masterResourceType) : base(smartsheet, masterResourceType)
		{
		}

		/// <summary>
		/// List attachments of a given object.
		/// 
		/// It mirrors to the following Smartsheet REST API method: GET /sheet/{id}/attachments GET /row/{id}/attachments GET
		/// /comment/{id}/attachments
		/// 
		/// Exceptions:
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ResourceNotFoundException : if the resource can not be found
		///   ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="objectId"> the ID of the object to which the attachments are associated </param>
		/// <returns> the attachments (note that empty list will be returned if there is none) </returns>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		public virtual IList<Attachment> ListAttachments(long objectId)
		{
            return this.ListResources<Attachment>(masterResourceType + "/" + objectId + "/attachments", typeof(Attachment));
		}

		/// <summary>
		/// Attach a file to the object.
		/// 
		/// It mirrors to the following Smartsheet REST API method: POST /sheet/{id}/attachments POST /row/{id}/attachments
		/// POST /comment/{idd}/attachments
		/// 
		/// Exceptions:
		///   IllegalArgumentException : if any argument is null or empty string
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token) 
		///   ResourceNotFoundException : if the resource can not be found
		///   ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="objectId"> the object id </param>
		/// <param name="file"> the file to attach </param>
		/// <param name="contentType"> the content type of the file </param>
		/// <returns> the created attachment </returns>
		/// <exception cref="FileNotFoundException"> the file not found exception </exception>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		public virtual Attachment AttachFile(long objectId, string file, string contentType)
		{
			Util.ThrowIfNull(objectId, file, contentType);
			Util.ThrowIfEmpty(contentType);

            FileInfo fi = new FileInfo(file);
			return AttachFile(objectId, file, contentType, fi.Length);
		}

		/// <summary>
		/// Attach file.
		/// </summary>
		/// <param name="objectId"> the object id </param>
		/// <param name="file"> the file </param>
		/// <param name="contentType"> the content type </param>
		/// <param name="contentLength"> the content length </param>
		/// <returns> the attachment </returns>
		/// <exception cref="FileNotFoundException"> the file not found exception </exception>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		public virtual Attachment AttachFile(long objectId, string file, string contentType, long contentLength)
		{
			Util.ThrowIfNull(file, contentType);

            FileInfo fi = new FileInfo(file);
			HttpRequest request = CreateHttpRequest(new Uri(this.Smartsheet.baseURI,masterResourceType + "/" +
                objectId + "/attachments"), HttpMethod.POST);
            
			request.headers["Content-Disposition"] = "attachment; filename=" + fi.Length;
			
            HttpEntity entity = new HttpEntity();
			entity.contentType = contentType;
            //FIXME: major problem here reading the file into a string
            entity.Content = File.ReadAllText(file);
			entity.contentLength = contentLength;
			request.entity = entity;

			HttpResponse response = this.Smartsheet.httpClient.Request(request);

			Attachment attachment = null;
			switch (response.StatusCode)
			{
			case HttpStatusCode.OK:
                    attachment = this.Smartsheet.jsonSerializer.deserializeResult<Attachment>(
                        response.entity.getContent()).result;
				break;
			default:
				HandleError(response);
			break;
			}

			this.Smartsheet.httpClient.ReleaseConnection();

			return attachment;
		}

		/// <summary>
		/// Attach a URL to the object.
		/// 
		/// The URL can be a normal URL (attachmentType "URL"), a Google Drive URL (attachmentType "GOOGLE_DRIVE") or a
		/// Box.com URL (attachmentType "BOX_COM").
		/// 
		/// It mirrors to the following Smartsheet REST API method: POST /sheet/{id}/attachments POST /row/{id}/attachments
		/// POST /comment/{idd}/attachments
		/// 
		/// Parameters: - objectId : the ID of the object - attachment : the attachment object limited to the following
		/// attributes: * name * description (applicable when attaching to sheet or row only) * url * attachmentType *
		/// attachmentSubType
		/// 
		/// Returns: the created attachment
		/// 
		/// Exceptions:
		///   IllegalArgumentException : if any argument is null
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ResourceNotFoundException : if the resource can not be found
		///   ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="objectId"> the object id </param>
		/// <param name="attachment"> the attachment </param>
		/// <returns> the attachment </returns>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		public virtual Attachment AttachURL(long objectId, Attachment attachment)
		{
			Util.ThrowIfNull(objectId, attachment);
            //Result<T>
			return this.CreateResource(masterResourceType + "/" + objectId + "/attachments", 
                typeof(Attachment), attachment);
		}
	}

}