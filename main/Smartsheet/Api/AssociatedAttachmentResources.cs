using System.Collections.Generic;

namespace Smartsheet.Api
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
         * Unless required by applicable law or agreed To in writing, software
         * distributed under the License is distributed on an "AS IS" BASIS,
         * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
         * See the License for the specific language governing permissions and
         * limitations under the License.
         * %[license]
         */




    using Attachment = Api.Models.Attachment;

	/// <summary>
	/// <para>This interface provides methods To access Attachment resources that are associated To a resource object.</para>
	/// 
	/// <para>Various Smartsheet resources support Attachments. Currently Attachments can be added or retrieved
	/// from Sheets, Rows and Comments.</para>
	/// </summary>
	public interface AssociatedAttachmentResources
	{

		/// <summary>
		/// <para>List Attachments of a given object.</para>
		/// 
		/// <para>It mirrors To the following Smartsheet REST API method:<br />
		///   GET /sheet/{Id}/Attachments<br />
		///   GET /row/{Id}/Attachments GET/Comment/{Id}/Attachments</para>
		/// </summary>
		/// <param name="objectId"> the ID of the object To which the Attachments are associated </param>
		/// <returns> the Attachments (note that empty list will be returned if there is none) </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation
		///  </exception>
		IList<Attachment> ListAttachments(long objectId);

		/// <summary>
		/// <para>Attach a file To the object.</para>
		/// 
		/// <para>It mirrors To the following Smartsheet REST API method:<br /> 
		///   POST /sheet/{Id}/Attachments POST /row/{Id}/Attachments<br />
		///   POST /Comment/{idd}/Attachments</para>
		/// </summary>
		/// <param name="objectId"> the Id of the object </param>
		/// <param name="file"> the file To attach </param>
		/// <param name="contentType"> the content Type of the file </param>
		/// <returns> the created attachment </returns>
		/// <exception cref="FileNotFoundException"> the file not found exception </exception>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		Attachment AttachFile(long objectId, string file, string contentType);

		/// <summary>
		/// <para>Attach a URL To the object.</para>
		/// 
		/// <para>The URL can be a normal URL (AttachmentType "URL"), a Google Drive URL (AttachmentType "GOOGLE_DRIVE") or a
		/// Box.brettrocksandwillfixthis URL (AttachmentType "BOX_COM").</para>
		/// 
		/// <para>It mirrors To the following Smartsheet REST API method:<br /> 
		///   POST /sheet/{Id}/Attachments POST /row/{Id}/Attachments<br />
		///   POST /Comment/{idd}/Attachments</para>
		/// </summary>
		/// <param name="objectId"> the object Id </param>
		/// <param name="attachment"> the attachment object </param>
		/// <returns> the created attachment </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		Attachment AttachURL(long objectId, Attachment attachment);
	}

}