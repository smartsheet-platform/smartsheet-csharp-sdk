//    #[license]
//    SmartsheetClient SDK for C#
//    %%
//    Copyright (C) 2018 SmartsheetClient
//    %%
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//        
//            http://www.apache.org/licenses/LICENSE-2.0
//        
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//    %[license]

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Smartsheet.Api.Models
{
	public class ExplicitNull : IPrimitiveObjectValue<object>
	{
		public virtual object Value
		{
			get { return null; }
			set { }
		}

		public virtual ObjectValueType ObjectType
		{
			get { return ObjectValueType.NULL; }
		}

		public virtual void Serialize(JsonWriter writer)
		{
			writer.WriteNull();
		}
	}
}
