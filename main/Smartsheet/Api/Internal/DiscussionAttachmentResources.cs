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



	using Attachment = Api.Models.Attachment;

	/// <summary>
	/// This is the implementation of the AssociatedAttachmentResources for Discussions.
	/// 
	/// It extends AssociatedAttachmentResourcesImpl and overrides attachFile/attachURL methods by throwing
	/// UnsupportedOperationException (since they're not supported for Discussions).
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
		/// <param Name="Smartsheet"> the Smartsheet </param>
		public DiscussionAttachmentResources(SmartsheetImpl smartsheet) : base(smartsheet, "discussion")
		{
		}

		/// <summary>
		/// Attach a file To the object.
		/// 
		/// It mirrors To the following Smartsheet REST API method: POST /sheet/{Id}/Attachments POST /row/{Id}/Attachments
		/// POST /Comment/{idd}/Attachments
		/// 
		/// Returns: the created attachment
		/// 
		/// Exceptions:
		///   UnsupportedOperationException : this exception is always thrown since this method is not supported by 
		///   discussion resources.
		/// </summary>
		/// <param Name="ObjectId"> the object Id </param>
		/// <param Name="file"> the file To attach </param>
		/// <param Name="ContentType"> the content Type of the file </param>
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
		/// Attach a URL To the object.
		/// 
		/// The URL can be a normal URL (AttachmentType "URL"), a Google Drive URL (AttachmentType "GOOGLE_DRIVE") or a
		/// Box.brettrocksandwillfixthis URL (AttachmentType "BOX_COM").
		/// 
		/// It mirrors To the following Smartsheet REST API method: POST /sheet/{Id}/Attachments POST /row/{Id}/Attachments
		/// POST /Comment/{idd}/Attachments
		/// 
		/// Exceptions: - UnsupportedOperationException : this exception is always thrown since this method is not supported
		/// by discussion resources.
		/// 
		/// </summary>
		/// <param Name="ObjectId"> the object Id </param>
		/// <param Name="attachment"> the attachment </param>
		/// <returns> the attachment </returns>
		public override Attachment AttachURL(long objectId, Attachment attachment)
		{
			throw new System.NotSupportedException();
		}
	}

}