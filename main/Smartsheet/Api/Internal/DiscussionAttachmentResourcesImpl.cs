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


	using Attachment = Api.Models.Attachment;

	/// <summary>
	/// This is the implementation of the AssociatedAttachmentResources for Discussions.
	/// 
	/// It extends AssociatedAttachmentResourcesImpl and overrides attachFile/attachURL methods by throwing
	/// UnsupportedOperationException (since they're not supported for Discussions).
	/// 
	/// Thread Safety: This class is thread safe because it is immutable and its base class is thread safe.
	/// </summary>
	public class DiscussionAttachmentResourcesImpl : AbstractResources, DiscussionAttachmentResources
	{
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="smartsheet"> the Smartsheet </param>
		/// <exception cref="IllegalArgumentException">if any argument is null</exception>
		public DiscussionAttachmentResourcesImpl(SmartsheetImpl smartsheet) : base(smartsheet)
		{
		}
	}
}