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

namespace Smartsheet.Api
{

	using System;
	using System.ComponentModel;
	using System.IO;
	using Attachment = Api.Models.Attachment;

	/// <summary>
	/// <para>Use CommentAttachmentResources instead to access comment level attachments.</para>
	/// <para>Use DiscussionAttachmentResources instead to access discussion level attachments.</para>
	/// <para>Use RowAttachmentResources instead to access row level attachments.</para>
	/// <para>Use SheetAttachmentResources instead to access sheet level attachments.</para>
	/// </summary>
	[Obsolete("Deprecated", true)]
	[EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
	public interface AssociatedAttachmentResources
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="objectId"></param>
		/// <returns></returns>
		[Obsolete("Deprecated", true)]
		[EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		IList<Attachment> ListAttachments(long objectId);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="objectId"></param>
		/// <param name="file"></param>
		/// <param name="contentType"></param>
		/// <returns></returns>
		[Obsolete("Deprecated", true)]
		[EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		Attachment AttachFile(long objectId, string file, string contentType);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="objectId"></param>
		/// <param name="attachment"></param>
		/// <returns></returns>
		[Obsolete("Deprecated", true)]
		[EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		Attachment AttachURL(long objectId, Attachment attachment);
	}
}