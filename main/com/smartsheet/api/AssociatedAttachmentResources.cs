using System.Collections.Generic;

namespace com.smartsheet.api
{

    using System.IO;
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




    using Attachment = com.smartsheet.api.models.Attachment;

	/// <summary>
	/// <para>This interface provides methods to access Attachment resources that are associated to a resource object.</para>
	/// 
	/// <para>Various Smartsheet resources support attachments. Currently attachments can be added or retrieved
	/// from sheets, rows and comments.</para>
	/// </summary>
	public interface AssociatedAttachmentResources
	{

		/// <summary>
		/// <para>List attachments of a given object.</para>
		/// 
		/// <para>It mirrors to the following Smartsheet REST API method:<br />
		///   GET /sheet/{id}/attachments<br />
		///   GET /row/{id}/attachments GET/comment/{id}/attachments</para>
		/// </summary>
		/// <param name="objectId"> the ID of the object to which the attachments are associated </param>
		/// <returns> the attachments (note that empty list will be returned if there is none) </returns>
		/// <exception cref="InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation
		///  </exception>
		IList<Attachment> ListAttachments(long objectId);

		/// <summary>
		/// <para>Attach a file to the object.</para>
		/// 
		/// <para>It mirrors to the following Smartsheet REST API method:<br /> 
		///   POST /sheet/{id}/attachments POST /row/{id}/attachments<br />
		///   POST /comment/{idd}/attachments</para>
		/// </summary>
		/// <param name="objectId"> the id of the object </param>
		/// <param name="file"> the file to attach </param>
		/// <param name="contentType"> the content type of the file </param>
		/// <returns> the created attachment </returns>
		/// <exception cref="FileNotFoundException"> the file not found exception </exception>
		/// <exception cref="InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		Attachment AttachFile(long objectId, string file, string contentType);

		/// <summary>
		/// <para>Attach a URL to the object.</para>
		/// 
		/// <para>The URL can be a normal URL (attachmentType "URL"), a Google Drive URL (attachmentType "GOOGLE_DRIVE") or a
		/// Box.com URL (attachmentType "BOX_COM").</para>
		/// 
		/// <para>It mirrors to the following Smartsheet REST API method:<br /> 
		///   POST /sheet/{id}/attachments POST /row/{id}/attachments<br />
		///   POST /comment/{idd}/attachments</para>
		/// </summary>
		/// <param name="objectId"> the object id </param>
		/// <param name="attachment"> the attachment object </param>
		/// <returns> the created attachment </returns>
		/// <exception cref="InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		Attachment AttachURL(long objectId, Attachment attachment);
	}

}