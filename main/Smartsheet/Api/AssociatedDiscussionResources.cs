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

namespace Smartsheet.Api
{


	using System;
	using System.ComponentModel;
	using Discussion = Api.Models.Discussion;

	/// <summary>
	/// <para>Use SheetDiscussionResources instead.</para>
	/// </summary>
	[Obsolete("Deprecated", true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface AssociatedDiscussionResources
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="objectId"></param>
		/// <param name="discussion"></param>
		/// <returns></returns>
		[Obsolete("Deprecated", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		Discussion CreateDiscussion(long objectId, Discussion discussion);
	}
}