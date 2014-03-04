using System;

namespace com.smartsheet.api.models
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

	/// <summary>
	/// Represents the Attachment object. </summary>
	/// <seealso cref= <a href="http://help.smartsheet.com/customer/portal/articles/518408-uploading-attachments">Help Uploading 
	/// Attachments</a> </seealso>
	public class Attachment : NamedModel
	{

		/// <summary>
		/// Represents the URL.
		/// </summary>
		private string url_Renamed;

		/// <summary>
		/// Represents the URL expiration time.
		/// </summary>
		private long? urlExpiresInMillis_Renamed;

		/// <summary>
		/// Represents the attachment type.
		/// </summary>
		private AttachmentType? attachmentType_Renamed;

		/// <summary>
		/// Represents the attachment sub type.
		/// </summary>
		private AttachmentSubType? attachmentSubType_Renamed;

		/// <summary>
		/// Represents the creation timestamp.
		/// </summary>
		private DateTime? createdAt_Renamed;

		/// <summary>
		/// Represents the MIME type. </summary>
		private string mimeType_Renamed;

		/// <summary>
		/// Represents the parent type.
		/// </summary>
		private AttachmentParentType? parentType_Renamed;

		/// <summary>
		/// Represents the parent ID. </summary>
		private long? parentId_Renamed;

		/// <summary>
		/// Represents the attachment size.
		/// </summary>
		private long? sizeInKb_Renamed;

		/// <summary>
		/// Gets the URL.
		/// </summary>
		/// <returns> The url. </returns>
		public virtual string url
		{
			get
			{
				return url_Renamed;
			}
			set
			{
				this.url_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the url expires in millis.
		/// </summary>
		/// <returns> the url expires in millis </returns>
		public virtual long? urlExpiresInMillis
		{
			get
			{
				return urlExpiresInMillis_Renamed;
			}
			set
			{
				this.urlExpiresInMillis_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the attachment type.
		/// </summary>
		/// <returns> the attachment type </returns>
		public virtual AttachmentType? attachmentType
		{
			get
			{
				return attachmentType_Renamed;
			}
			set
			{
				this.attachmentType_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the attachment sub type.
		/// </summary>
		/// <returns> the attachment sub type </returns>
		public virtual AttachmentSubType? attachmentSubType
		{
			get
			{
				return attachmentSubType_Renamed;
			}
			set
			{
				this.attachmentSubType_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the created at.
		/// </summary>
		/// <returns> the created at </returns>
		public virtual DateTime? createdAt
		{
			get
			{
				return createdAt_Renamed;
			}
			set
			{
				this.createdAt_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the mime type.
		/// </summary>
		/// <returns> the mime type </returns>
		public virtual string mimeType
		{
			get
			{
				return mimeType_Renamed;
			}
			set
			{
				this.mimeType_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the parent type.
		/// </summary>
		/// <returns> the parent type </returns>
		public virtual AttachmentParentType? parentType
		{
			get
			{
				return parentType_Renamed;
			}
			set
			{
				this.parentType_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the parent id.
		/// </summary>
		/// <returns> the parent id </returns>
		public virtual long? parentId
		{
			get
			{
				return parentId_Renamed;
			}
			set
			{
				this.parentId_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the size in kb.
		/// </summary>
		/// <returns> the size in kb </returns>
		public virtual long? sizeInKb
		{
			get
			{
				return sizeInKb_Renamed;
			}
			set
			{
				this.sizeInKb_Renamed = value;
			}
		}

	}

}