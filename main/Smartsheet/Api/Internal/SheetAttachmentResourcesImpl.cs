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
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//    %[license]

using Smartsheet.Api.Internal.Http;
using Smartsheet.Api.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Smartsheet.Api.Internal
{
	/// <summary>
	/// This is the implementation of the SheetAttachmentResources.
	/// 
	/// Thread Safety: This class is thread safe because it is immutable and its base class is thread safe.
	/// </summary>
	public class SheetAttachmentResourcesImpl : AbstractResources, SheetAttachmentResources
	{
		private AttachmentVersioningResources versioning;

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="smartsheet"> the Smartsheet </param>
		public SheetAttachmentResourcesImpl(SmartsheetImpl smartsheet)
			: base(smartsheet)
		{
			this.versioning = new AttachmentVersioningResourcesImpl(smartsheet);
		}

		/// <summary>
		/// <para>Attaches a file to the Sheet.</para>
		/// <para>It mirrors to the following Smartsheet REST API method:<br />
		/// POST /sheets/{sheetId}/attachments</para>
		/// </summary>
		/// <param name="file">the file path</param>
		/// <param name="fileType">the file type</param>
		/// <param name="sheetId">the sheet Id</param>
		/// <returns> the Attachment object </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual Attachment AttachFile(long sheetId, string file, string fileType)
		{
			return AttachFile("sheets/" + sheetId + "/attachments", file, fileType);
		}
		public virtual Attachment AttachUrl(long sheetId, Attachment attachment)
		{
			return this.CreateResource("sheets/" + sheetId + "/attachments", typeof(Attachment), attachment);
		}

		public virtual void DeleteAttachment(long sheetId, long attachmentId)
		{
			this.DeleteResource<Attachment>("sheets/" + sheetId + "/attachments/" + attachmentId, typeof(Attachment));
		}

		public virtual Attachment GetAttachment(long sheetId, long attachmentId)
		{
			return this.GetResource<Attachment>("sheets/" + sheetId + "/attachments/" + attachmentId, typeof(Attachment));
		}

		public virtual PaginatedResult<Attachment> ListAttachments(long sheetId, PaginationParameters paging)
		{
			StringBuilder path = new StringBuilder("sheets/" + sheetId + "/attachments");
			if (paging != null)
			{
				path.Append(paging.ToQueryString());
			}
			return this.ListResourcesWithWrapper<Attachment>(path.ToString());
		}

		public virtual AttachmentVersioningResources VersioningResources
		{
			get
			{
				return this.versioning;
			}
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
			Utility.Utility.ThrowIfNull(file);

			if (contentType == null)
			{
				contentType = "application/octet-stream";
			}

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