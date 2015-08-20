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
	using System;
	using System.ComponentModel;
	using Comment = Api.Models.Comment;
	using Discussion = Api.Models.Discussion;

	/// <summary>
	/// This is the implementation of the DiscussionResources.
	/// 
	/// Thread Safety: This class is thread safe because it is immutable and its base class is thread safe.
	/// </summary>
	[Obsolete("Deprecated", true)]
	[EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
	public class DiscussionResourcesImpl : AbstractResources, DiscussionResources
	{
		///// <summary>
		///// Represents the AssociatedAttachmentResources.
		///// 
		///// It will be initialized in constructor and will not change afterwards.
		///// </summary>
		//private AssociatedAttachmentResources attachments;

		/// <summary>
		/// Constructor.
		/// 
		/// Exceptions: - IllegalArgumentException : if any argument is null
		/// </summary>
		/// <param name="smartsheet"> the Smartsheet </param>
		[Obsolete("Deprecated", true)]
		[EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public DiscussionResourcesImpl(SmartsheetImpl smartsheet)
			: base(smartsheet)
		{
		}

		[Obsolete("Deprecated", true)]
		[EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public virtual Discussion GetDiscussion(long id)
		{
			throw new NotSupportedException();
		}

		[Obsolete("Deprecated", true)]
		[EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public virtual Comment AddDiscussionComment(long id, Comment comment)
		{
			throw new NotSupportedException();
		}

		[Obsolete("Deprecated", true)]
		[EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public virtual AssociatedAttachmentResources Attachments()
		{
			//return this.attachments;
			throw new NotSupportedException();
		}
	}

}