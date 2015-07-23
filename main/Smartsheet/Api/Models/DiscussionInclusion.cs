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
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Smartsheet.Api.Models
{
	/// <summary>
	/// Represents the discussion elements to include in a response
	/// </summary>
	public enum DiscussionInclusion
	{
		/// <summary>
		/// The comments of the discussion
		/// </summary>
		[EnumMember(Value = "source")]
		COMMENTS,
		/// <summary>
		///  effective only if comments is present, otherwise ignored
		/// </summary>
		[EnumMember(Value = "attachments")]
		ATTACHMENTS
	}
}