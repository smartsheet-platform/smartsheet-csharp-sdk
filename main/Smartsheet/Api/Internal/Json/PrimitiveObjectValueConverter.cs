//    #[ license]
//    SmartsheetClient SDK for C#
//    %%
//    Copyright (C) 2017 SmartsheetClient
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
using Smartsheet.Api.Models;

namespace Smartsheet.Api.Internal.Json
{
	class PrimitiveObjectValueConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			bool isPrimitiveObjectValue = objectType.GetInterfaces().Any(x =>
			  x.IsGenericType &&  x.GetGenericTypeDefinition() == typeof(IPrimitiveObjectValue<>));
			return isPrimitiveObjectValue;
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
		{
			object objectToDeserialize = Activator.CreateInstance(objectType);
			serializer.Populate(reader, objectToDeserialize);
			return objectToDeserialize;
		}

		public override void WriteJson(JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
		{
			if (value == null)
			{
				writer.WriteNull();
			}
			else
			{
				Type type = value.GetType();
				object[] args = new object[] { writer };
				type.GetMethod("Serialize").Invoke(value, args);
			}
		}
	}
}
