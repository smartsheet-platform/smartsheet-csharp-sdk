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

namespace Smartsheet.Api.Internal
{

	using Attachment = Api.Models.Attachment;


	/// <summary>
	/// This is the implementation of the AssociatedAttachmentResources for Comments.
	/// 
	/// It extends AssociatedAttachmentResourcesImpl and overrides listAttachments method by throwing
	/// UnsupportedOperationException (since it's not supported for Comments).
	/// 
	/// Thread Safety: This class is thread safe because it is immutable and its base class is thread safe.
	/// </summary>
	public class CommentAttachmentResourcesImpl : AbstractResources, CommentAttachmentResources
	{

		/// <summary>
		/// Constructor.
		/// 
		/// Parameters: - Smartsheet : the SmartsheetImpl
		/// 
		/// Exceptions:
		///   IllegalArgumentException : if any argument is null or empty string
		/// </summary>
		/// <param name="smartsheet"> the Smartsheet </param>
		public CommentAttachmentResourcesImpl(SmartsheetImpl smartsheet)
			: base(smartsheet)
		{
		}

		///// <summary>
		///// 
		///// </summary>
		///// <param name="objectId"></param>
		///// <returns></returns>
		//public virtual IList<Attachment> ListAttachments(long objectId)
		//{
		//	throw new System.NotSupportedException();
		//}
	}

}