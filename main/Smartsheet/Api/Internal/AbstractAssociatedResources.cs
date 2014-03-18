//    #[license]
//    Smartsheet SDK for C#
//    %%
//    Copyright (C) 2014 Smartsheet
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


	/// <summary>
	/// This is the base class of the Smartsheet REST API resources that are associated To other resources.
	/// 
	/// Thread Safety: This class is thread safe because it is immutable and its base class is thread safe.
	/// </summary>
	public abstract class AbstractAssociatedResources : AbstractResources
	{
		/// <summary>
		/// Represents the master resource Type (e.g. "sheet", "workspace").
		/// 
		/// It will be initialized in constructor and will not change afterwards.
		/// </summary>
		private string masterResourceType;

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="smartsheet"> the Smartsheet </param>
		/// <param name="masterResourceType"> the master resource Type </param>
		public AbstractAssociatedResources(SmartsheetImpl smartsheet, string masterResourceType) : base(smartsheet)
		{
			Utils.ThrowIfNull(masterResourceType);
			Utils.ThrowIfEmpty(masterResourceType);

			this.masterResourceType = masterResourceType;
		}

		/// <summary>
		/// Getter of corresponding field.
		/// </summary>
		/// <returns> the master resource Type </returns>
		protected internal virtual string MasterResourceType
		{
			get
			{
				return masterResourceType;
			}
		}
	}

}