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
using System.ComponentModel;
namespace Smartsheet.Api.Internal
{
	/// <summary>
	/// This is the implementation of the CommentResources.
	/// 
	/// Thread Safety: This class is thread safe because it is immutable and its base class is thread safe.
	/// </summary>
	[Obsolete("Deprecated", true)]
	[EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
	public class CommentResourcesImpl : AbstractResources, CommentResources
	{
		///// <summary>
		///// Represents the AssociatedAttachmentResources.
		///// 
		///// It will be initialized in constructor and will not change afterwards.
		///// </summary>
		//private AssociatedAttachmentResources attachments;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="smartsheet"></param>
		[Obsolete("Deprecated", true)]
		[EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public CommentResourcesImpl(SmartsheetImpl smartsheet)
			: base(smartsheet)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Obsolete("Deprecated", true)]
		[EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public virtual Comment GetComment(long id)
		{
			throw new NotSupportedException();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		[Obsolete("Deprecated", true)]
		[EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public virtual void DeleteComment(long id)
		{
			throw new NotSupportedException();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[Obsolete("Deprecated", true)]
		[EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public virtual AssociatedAttachmentResources Attachments()
		{
			//return this.attachments;
			throw new NotSupportedException();
		}
	}
}