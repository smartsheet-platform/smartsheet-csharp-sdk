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

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Smartsheet.Api.Internal.Json
{
	internal class ContractResolver : DefaultContractResolver
	{
		public ContractResolver()
		{
		}

		protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
		{
				JsonProperty property = base.CreateProperty(member, memberSerialization);
				//This below will not serialize the property "id" unless commented out.
				//if (property.PropertyName.ToLower().Equals("id"))
				//{
				//	 property.ShouldSerialize = (object instance) => false;
				//}
				return property;
		}

		protected override string ResolvePropertyName(string propertyName)
		{
			string str;
			str = ((string.IsNullOrEmpty(propertyName) || char.IsLower(propertyName, 0) ? false : 
				propertyName.Length >= 2) ? string.Concat(propertyName.Substring(0, 1).ToLower(), 
				propertyName.Substring(1)) : propertyName);
			return str;
		}
	}
}