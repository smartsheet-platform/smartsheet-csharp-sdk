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

namespace Smartsheet.Api.Internal
{
	using Smartsheet.Api.Models;
	using System;

	/// <summary>
	/// This is the implementation of the AttachmentVersioningResources.
	/// 
	/// Thread Safety: This class is thread safe because it is immutable and its base class is thread safe.
	/// </summary>
	public class AttachmentVersioningResourcesImpl : AbstractResources, AttachmentVersioningResources
	{
		/// <summary>
		/// Constructor.
		/// 
		/// Parameters: - Smartsheet : the SmartsheetImpl
		/// 
		/// Exceptions: - IllegalArgumentException : if any argument is null
		/// </summary>
		/// <param name="smartsheet"> the Smartsheet </param>
		public AttachmentVersioningResourcesImpl(SmartsheetImpl smartsheet)
			: base(smartsheet)
		{
		}

		public virtual Attachment AttachNewVersion(long sheetId, long attachmentId, string file, string fileType)
		{
			throw new NotImplementedException();
		}

		public virtual void DeleteAllVersions(long sheetId, long attachmentId)
		{
			throw new NotImplementedException();
		}

		public virtual DataWrapper<Attachment> ListVersions(long sheetId, long attachmentId, PaginationParameters paging)
		{
			throw new NotImplementedException();
		}
	}
}