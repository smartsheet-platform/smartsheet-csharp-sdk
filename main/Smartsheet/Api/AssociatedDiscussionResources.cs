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
	/// <para>This interface provides methods To access Discussion resources that are associated To a resource object. Currently 
	/// Discussions can be added To Sheets or Rows.</para>
	/// 
	/// <para>Thread Safety: Implementation of this interface must be thread safe.</para>
	/// </summary>
	[Obsolete("Deprecated", true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface AssociatedDiscussionResources
	{
		[Obsolete("Deprecated", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		Discussion CreateDiscussion(long objectId, Discussion discussion);
	}
}