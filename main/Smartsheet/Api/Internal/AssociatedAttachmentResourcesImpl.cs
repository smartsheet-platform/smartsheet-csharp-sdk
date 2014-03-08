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

using System.Collections.Generic;

namespace Smartsheet.Api.Internal
{



	using HttpEntity = Api.Internal.http.HttpEntity;
	using HttpMethod = Api.Internal.http.HttpMethod;
	using HttpRequest = Api.Internal.http.HttpRequest;
	using HttpResponse = Api.Internal.http.HttpResponse;
    using Utils = Api.Internal.Utility.Utility;
	using Attachment = Api.Models.Attachment;
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
		/// <param name="smartsheet"> the Smartsheet </param>
		/// <param name="masterResourceType"> the master resource Type (e.g. "sheet", "workspace") </param>
		public AssociatedAttachmentResourcesImpl(SmartsheetImpl smartsheet, string masterResourceType) : base(smartsheet, masterResourceType)
		{
		}

		/// <summary>
		/// List Attachments of a given object.
		/// 
		/// It mirrors To the following Smartsheet REST API method: GET /sheet/{Id}/Attachments GET /row/{Id}/Attachments GET
		/// /Comment/{Id}/Attachments
		/// 
		/// Exceptions:
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ResourceNotFoundException : if the resource can not be found
		///   ServiceUnavailableException : if the REST API service is not available (possibly due To rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="objectId"> the ID of the object To which the Attachments are associated </param>
		/// <returns> the Attachments (note that empty list will be returned if there is none) </returns>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
		public virtual IList<Attachment> ListAttachments(long objectId)
		{
            return this.ListResources<Attachment>(MasterResourceType + "/" + objectId + "/attachments", typeof(Attachment));
		}

		/// <summary>
		/// Attach a file To the object.
		/// 
		/// It mirrors To the following Smartsheet REST API method: POST /sheet/{Id}/Attachments POST /row/{Id}/Attachments
		/// POST /Comment/{idd}/Attachments
		/// 
		/// Exceptions:
		///   IllegalArgumentException : if any argument is null or empty string
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token) 
		///   ResourceNotFoundException : if the resource can not be found
		///   ServiceUnavailableException : if the REST API service is not available (possibly due To rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="objectId"> the object Id </param>
		/// <param name="file"> the file To attach </param>
		/// <param name="contentType"> the content Type of the file </param>
		/// <returns> the created attachment </returns>
		/// <exception cref="FileNotFoundException"> the file not found exception </exception>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
		public virtual Attachment AttachFile(long objectId, string file, string contentType)
		{
			Utils.ThrowIfNull(objectId, file, contentType);
			Utils.ThrowIfEmpty(contentType);

            FileInfo fi = new FileInfo(file);
			return AttachFile(objectId, file, contentType, fi.Length);
		}

		/// <summary>
		/// Attach file.
		/// </summary>
		/// <param name="objectId"> the object Id </param>
		/// <param name="file"> the file </param>
		/// <param name="contentType"> the content Type </param>
		/// <param name="contentLength"> the content length </param>
		/// <returns> the attachment </returns>
		/// <exception cref="FileNotFoundException"> the file not found exception </exception>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
		public virtual Attachment AttachFile(long objectId, string file, string contentType, long contentLength)
		{
            Utils.ThrowIfNull(file, contentType);

            FileInfo fi = new FileInfo(file);
			HttpRequest request = CreateHttpRequest(new Uri(this.Smartsheet.BaseURI,MasterResourceType + "/" +
                objectId + "/attachments"), HttpMethod.POST);
            
			request.Headers["Content-Disposition"] = "attachment; filename=" + fi.Length;
			
            HttpEntity entity = new HttpEntity();
			entity.ContentType = contentType;
            //FIXME: major problem here reading the file into a string
            entity.Content = File.ReadAllText(file);
			entity.ContentLength = contentLength;
			request.Entity = entity;

			HttpResponse response = this.Smartsheet.HttpClient.Request(request);

			Attachment attachment = null;
			switch (response.StatusCode)
			{
			case HttpStatusCode.OK:
                    attachment = this.Smartsheet.JsonSerializer.deserializeResult<Attachment>(
                        response.Entity.GetContent()).Result;
				break;
			default:
				HandleError(response);
			break;
			}

			this.Smartsheet.HttpClient.ReleaseConnection();

			return attachment;
		}

		/// <summary>
		/// Attach a URL To the object.
		/// 
		/// The URL can be a normal URL (AttachmentType "URL"), a Google Drive URL (AttachmentType "GOOGLE_DRIVE") or a
		/// Box.brettrocksandwillfixthis URL (AttachmentType "BOX_COM").
		/// 
		/// It mirrors To the following Smartsheet REST API method: POST /sheet/{Id}/Attachments POST /row/{Id}/Attachments
		/// POST /Comment/{idd}/Attachments
		/// 
		/// Parameters: - ObjectId : the ID of the object - attachment : the attachment object limited To the following
		/// attributes: * Name * Description (applicable when attaching To sheet or row only) * Url * AttachmentType *
		/// AttachmentSubType
		/// 
		/// Returns: the created attachment
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
		/// <param name="objectId"> the object Id </param>
		/// <param name="attachment"> the attachment </param>
		/// <returns> the attachment </returns>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
		public virtual Attachment AttachURL(long objectId, Attachment attachment)
		{
            Utils.ThrowIfNull(objectId, attachment);
            //RequestResult<T>
			return this.CreateResource(MasterResourceType + "/" + objectId + "/attachments", 
                typeof(Attachment), attachment);
		}
	}

}