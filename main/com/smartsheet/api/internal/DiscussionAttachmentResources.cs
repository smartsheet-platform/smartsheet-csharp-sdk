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



	using Attachment = com.smartsheet.api.models.Attachment;

	/// <summary>
	/// This is the implementation of the AssociatedAttachmentResources for discussions.
	/// 
	/// It extends AssociatedAttachmentResourcesImpl and overrides attachFile/attachURL methods by throwing
	/// UnsupportedOperationException (since they're not supported for discussions).
	/// 
	/// Thread Safety: This class is thread safe because it is immutable and its base class is thread safe.
	/// </summary>
	public class DiscussionAttachmentResources : AssociatedAttachmentResourcesImpl
	{

		/// <summary>
		/// Constructor.
		/// 
		/// Exceptions: - IllegalArgumentException : if any argument is null or empty string
		/// </summary>
		/// <param name="smartsheet"> the smartsheet </param>
		public DiscussionAttachmentResources(SmartsheetImpl smartsheet) : base(smartsheet, "discussion")
		{
		}

		/// <summary>
		/// Attach a file to the object.
		/// 
		/// It mirrors to the following Smartsheet REST API method: POST /sheet/{id}/attachments POST /row/{id}/attachments
		/// POST /comment/{idd}/attachments
		/// 
		/// Returns: the created attachment
		/// 
		/// Exceptions:
		///   UnsupportedOperationException : this exception is always thrown since this method is not supported by 
		///   discussion resources.
		/// </summary>
		/// <param name="objectId"> the object id </param>
		/// <param name="file"> the file to attach </param>
		/// <param name="contentType"> the content type of the file </param>
		/// <returns> the attachment </returns>
		public override Attachment AttachFile(long objectId, string file, string contentType)
		{
			throw new System.NotSupportedException();
		}

		/// <summary>
		/// Throws an UnsupportedOperationException.
		/// </summary>
		public override Attachment AttachFile(long objectId, string file, string contentType, long contentLength)
		{
			throw new System.NotSupportedException();
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
		/// Exceptions: - UnsupportedOperationException : this exception is always thrown since this method is not supported
		/// by discussion resources.
		/// 
		/// </summary>
		/// <param name="objectId"> the object id </param>
		/// <param name="attachment"> the attachment </param>
		/// <returns> the attachment </returns>
		public override Attachment AttachURL(long objectId, Attachment attachment)
		{
			throw new System.NotSupportedException();
		}
	}

}