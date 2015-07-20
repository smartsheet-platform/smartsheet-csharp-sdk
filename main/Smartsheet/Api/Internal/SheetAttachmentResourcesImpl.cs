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

using Smartsheet.Api.Models;
using System;
using System.Collections.Generic;

namespace Smartsheet.Api.Internal
{
	/// <summary>
	/// This is the implementation of the SheetAttachmentResources.
	/// 
	/// Thread Safety: This class is thread safe because it is immutable and its base class is thread safe.
	/// </summary>
	public class SheetAttachmentResourcesImpl : AbstractResources, SheetAttachmentResources
	{
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="smartsheet"> the Smartsheet </param>
		/// <exception cref="IllegalArgumentException">if any argument is null</exception>
		public SheetAttachmentResourcesImpl(SmartsheetImpl smartsheet)
			: base(smartsheet)
		{
		}

		public virtual Attachment AttachFile(long sheetId, string file, string fileType)
		{
			throw new System.NotImplementedException();
		}

		public virtual Attachment AttachUrl(long sheetId, Attachment attachment)
		{
			throw new System.NotImplementedException();
		}

		public virtual void DeleteAttachment(long sheetId, long attachmentId)
		{
			throw new NotImplementedException();
		}

		public Attachment GetAttachment(long sheetId, long attachmentId)
		{
			throw new NotImplementedException();
		}

		public DataWrapper<Attachment> ListAttachments(long sheetId, PaginationParameters paging)
		{
			throw new NotImplementedException();
		}

		public AttachmentVersioningResources VersioningResources()
		{
			throw new NotImplementedException();
		}
	}
}