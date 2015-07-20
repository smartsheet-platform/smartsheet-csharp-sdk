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

namespace Smartsheet.Api.Models
{
	/// <summary>
	/// Represents individual user settings for a specific sheet. 
	/// User settings may be updated even on sheets where the current user only has read access (e.g. viewer permissions or a read-only sheet). </summary>

	public class Source : IdentifiableModel
	{
		private string type;

		/// <summary>
		/// Type of this source. “sheet” or “template”
		/// </summary>
		/// <returns> “sheet” or “template” </returns>
		public string Type
		{
			get { return type; }
			set { type = value; }
		}
	}

}