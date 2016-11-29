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

namespace Smartsheet.Api.Models
{
	public class ObjectValue : object
	{
		/// <summary>
		/// Represents the objectValue Type.
		/// </summary>
		private ObjectValueType? objectType;

		private IList<Predecessor> predecessors;

		/// <summary>
		/// Gets the objectValue Type.
		/// </summary>
		/// <returns> the Type </returns>
		public virtual ObjectValueType? ObjectType
		{
			get
			{
				return objectType;
			}
			set
			{
				this.objectType = value;
			}
		}

		/// <summary>
		/// Gets the array of Predecessor objects.
		/// </summary>
		/// <returns> the array </returns>
		public virtual IList<Predecessor> Predecessors
		{
			get
			{
				return predecessors;
			}
			set
			{
				this.predecessors = value;
			}
		}

	}
}
