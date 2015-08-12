﻿//    #[license]
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
	/// Represents specific objects that can be included in some responses.
	/// </summary>
	[System.Obsolete("Deprecated", true)]
	[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
	public enum ObjectInclusion
	{
		/// <summary>
		/// The discussions
		/// </summary>
		[EnumMember(Value = "discussions")]
		DISCUSSIONS,
		/// <summary>
		/// The attachments
		/// </summary>
		[EnumMember(Value = "attachments")]
		ATTACHMENTS,
		/// <summary>
		/// The data
		/// </summary>
		[EnumMember(Value = "data")]
		DATA,
		/// <summary>
		/// The columns
		/// </summary>
		[EnumMember(Value = "columns")]
		COLUMNS,
		/// <summary>
		/// The templates
		/// </summary>
		[EnumMember(Value = "templates")]
		TEMPLATES,
		/// <summary>
		/// The reports
		/// </summary>
		[EnumMember(Value = "reports")]
		REPORTS,
		/// <summary>
		/// The reports
		/// </summary>
		[EnumMember(Value = "sourceSheets")]
		SOURCESHEETS,
		/// <summary>
		/// The reports
		/// </summary>
		[EnumMember(Value = "format")]
		FORMAT
	}
}