//    #[ license]
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
//    Unless required by applicable law or agreed To in writing, software
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
	class CellLinkTypeConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return typeof(CellLink).IsAssignableFrom(objectType);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
		{
			if (reader.TokenType == JsonToken.StartObject)
			{
				object objectToDeserialize = Activator.CreateInstance(objectType);
				serializer.Populate(reader, objectToDeserialize);
				return objectToDeserialize;
			}
			return null;
		}

		public override void WriteJson(JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
		{
			Newtonsoft.Json.JsonSerializer serializerHelper = new Newtonsoft.Json.JsonSerializer();
			serializerHelper.Formatting = Newtonsoft.Json.Formatting.None;
			serializerHelper.MissingMemberHandling = Newtonsoft.Json.MissingMemberHandling.Ignore;
			serializerHelper.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat;
			serializerHelper.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
			serializerHelper.ContractResolver = new ContractResolver();
			serializerHelper.Converters.Add(new JsonEnumTypeConverter());

			CellLink cellLink = (CellLink)value;
			if (cellLink.IsNull)
			{
				writer.WriteNull();
			}
			else
				serializerHelper.Serialize(writer, value);
		}
	}
}

