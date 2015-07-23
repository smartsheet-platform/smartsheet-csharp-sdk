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

namespace Smartsheet.Api.Internal
{
	using HttpMethod = Api.Internal.Http.HttpMethod;
	using HttpRequest = Api.Internal.Http.HttpRequest;
	using Utils = Api.Internal.Utility.Utility;
	using Smartsheet.Api.Models;
	using System.IO;
	using Smartsheet.Api.Internal.Http;
	using System.Net;
	using System;

	/// <summary>
	/// This is the implementation of the AssociatedAttachmentResources for Comments.
	/// 
	/// It extends AssociatedAttachmentResourcesImpl and overrides listAttachments method by throwing
	/// UnsupportedOperationException (since it's not supported for Comments).
	/// 
	/// Thread Safety: This class is thread safe because it is immutable and its base class is thread safe.
	/// </summary>
	public class CommentAttachmentResourcesImpl : AbstractResources, CommentAttachmentResources
	{
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="smartsheet"> the Smartsheet </param>
		/// <exception cref="IllegalArgumentException">if any argument is null</exception>
		public CommentAttachmentResourcesImpl(SmartsheetImpl smartsheet)
			: base(smartsheet)
		{
		}

		/// <summary>
		/// <para>Attaches a file to the Comment.</para>
		/// <para>This operation will always create a new attachment.
		/// To upload a new version of the same attachment, use the Attach New Version operation.</para>
		/// <para>It mirrors To the following Smartsheet REST API method:
		/// POST /sheets/{sheetId}/comments/{commentId}/attachments</para>
		/// </summary>
		/// <param name="sheetId"> the sheetId </param>
		/// <param name="commentId"> the comment Id </param>
		/// <param name="file"> the file path </param>
		/// <param name="fileType"> the file type </param>
		/// <returns> the newly created Attachment </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual Attachment AttachFile(long sheetId, long commentId, string file, string fileType)
		{
			return AttachFile("sheets/" + sheetId + "/comments/" + commentId + "/attachments", file, fileType);
		}

		/// <summary>
		/// <para>Attaches a URL to the Comment.</para>
		/// <para>It mirrors To the following Smartsheet REST API method:
		/// POST /sheets/{sheetId}/comments/{commentId}/attachments</para>
		/// <remarks><para>attachmentSubType is valid only for GOOGLE_DRIVE attachments which are Google Docs.
		/// It can optionally be included to indicate the type of a file.
		/// The following attachmentSubTypes are valid for GOOGLE_DRIVE attachments "DOCUMENT", "SPREADSHEET", "PRESENTATION", "PDF", "DRAWING".</para>
		/// <para>When the attachment type is BOX_COM, DROPBOX, or GOOGLE_DRIVE (without an attachmentSubType specified),
		/// the mimeType will be derived by the file extension specified on the "name".</para>
		/// </remarks>
		/// </summary>
		/// <param name="sheetId"> the sheetId </param>
		/// <param name="commentId"> the comment Id </param>
		/// <param name="attachment"> the attachment object </param>
		/// <returns> the newly created Attachment </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual Attachment AttachUrl(long sheetId, long commentId, Attachment attachment)
		{
			return this.CreateResource("sheets/" + sheetId + "/comments/" + commentId + "/attachments", typeof(Attachment), attachment);
		}

		/// <summary>
		/// Attach file.
		/// </summary>
		/// <param name="path"> the url path </param>
		/// <param name="file"> the file </param>
		/// <param name="contentType"> the content Type </param>
		/// <returns> the attachment </returns>
		/// <exception cref="FileNotFoundException"> the file not found exception </exception>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
		private Attachment AttachFile(string path, string file, string contentType)
		{
			Utility.Utility.ThrowIfNull(file, contentType);

			FileInfo fi = new FileInfo(file);
			HttpRequest request = CreateHttpRequest(new Uri(this.Smartsheet.BaseURI, path), HttpMethod.POST);

			request.Headers["Content-Disposition"] = "attachment; filename=\"" + fi.Name + "\"";

			HttpEntity entity = new HttpEntity();
			entity.ContentType = contentType;

			entity.Content = File.ReadAllBytes(file);
			entity.ContentLength = fi.Length;
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
	}
}