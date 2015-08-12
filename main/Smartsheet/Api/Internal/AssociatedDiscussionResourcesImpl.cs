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


	using Utils = Api.Internal.Utility.Utility;
	using Discussion = Api.Models.Discussion;

	/// <summary>
	/// This is the implementation of the AssociatedDiscussionResources.
	/// 
	/// Thread Safety: This class is thread safe because it is immutable and its base class is thread safe.
	/// </summary>
	[System.Obsolete("Deprecated", true)]
	[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
	public class AssociatedDiscussionResourcesImpl : AbstractAssociatedResources, AssociatedDiscussionResources
	{

		/// <summary>
		/// Constructor.
		/// 
		/// Exceptions:
		///   IllegalArgumentException : if any argument is null or empty string
		/// </summary>
		/// <param name="smartsheet"> the Smartsheet </param>
		/// <param name="masterResourceType"> the master resource Type (e.g. "sheet", "workspace") </param>
		[System.Obsolete("Deprecated", true)]
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public AssociatedDiscussionResourcesImpl(SmartsheetImpl smartsheet, string masterResourceType) :
			base(smartsheet, masterResourceType)
		{
		}

		[System.Obsolete("Deprecated", true)]
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public virtual Discussion CreateDiscussion(long objectId, Discussion discussion)
		{
			throw new System.NotSupportedException();
		}
	}

}