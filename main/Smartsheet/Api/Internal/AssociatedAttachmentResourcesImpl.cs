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
using System.Collections.Generic;

namespace Smartsheet.Api.Internal
{
	/// <summary>
	/// This is the implementation of the AssociatedAttachmentResources.
	/// 
	/// Thread Safety: This class is thread safe because it is immutable and its base class is thread safe.
	/// </summary>
	[System.Obsolete("Deprecated", true)]
	[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
	public class AssociatedAttachmentResourcesImpl : AbstractAssociatedResources, AssociatedAttachmentResources
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="smartsheet"></param>
		/// <param name="masterResourceType"></param>
		[System.Obsolete("Deprecated", true)]
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public AssociatedAttachmentResourcesImpl(SmartsheetImpl smartsheet, string masterResourceType)
			: base(smartsheet, masterResourceType)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="objectId"></param>
		/// <returns></returns>
		[System.Obsolete("Deprecated", true)]
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public virtual IList<Attachment> ListAttachments(long objectId)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="objectId"></param>
		/// <param name="file"></param>
		/// <param name="contentType"></param>
		/// <returns></returns>
		[System.Obsolete("Deprecated", true)]
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public virtual Attachment AttachFile(long objectId, string file, string contentType)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="objectId"></param>
		/// <param name="file"></param>
		/// <param name="contentType"></param>
		/// <param name="contentLength"></param>
		/// <returns></returns>
		[System.Obsolete("Deprecated", true)]
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public virtual Attachment AttachFile(long objectId, string file, string contentType, long contentLength)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="objectId"></param>
		/// <param name="attachment"></param>
		/// <returns></returns>
		[System.Obsolete("Deprecated", true)]
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public virtual Attachment AttachURL(long objectId, Attachment attachment)
		{
			throw new System.NotImplementedException();
		}
	}
}