//    #[ license]
//    SmartsheetClient SDK for C#
//    %%
//    Copyright (C) 2014-2018 SmartsheetClient
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
using Newtonsoft.Json;
using Smartsheet.Api.Models;

namespace Smartsheet.Api.Internal.Json
{
	class ObjectValueTypeConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return typeof(ObjectValue).IsAssignableFrom(objectType);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
		{
			ObjectValue objectValue;

			if (reader.TokenType == JsonToken.StartObject)
			{
				ObjectValueAttributeSuperset superset = new ObjectValueAttributeSuperset();
				serializer.Populate(reader, superset);
				ObjectValueType parsedObjectType;
				if(!Enum.TryParse(superset.objectType, true, out parsedObjectType)) 
				{
					// If a new object type is introduced to the Smartsheet API that this version of the SDK doesn't support, 
					// return null instead of throwing an exception.
					return null;
				}
				switch (parsedObjectType)
				{
					case ObjectValueType.DURATION:
						objectValue = new Duration(superset.negative, superset.elapsed, superset.weeks, superset.days,
							superset.hours, superset.minutes, superset.seconds, superset.milliseconds);
						break;

					case ObjectValueType.PREDECESSOR_LIST:
						objectValue = new PredecessorList(superset.predecessors);
						break;

					case ObjectValueType.CONTACT:
						ContactObjectValue contactObjectValue = new ContactObjectValue();
						contactObjectValue.Name = superset.name;
						contactObjectValue.Email = superset.email;
						contactObjectValue.Id = superset.id;
						objectValue = contactObjectValue;
						break;

					case ObjectValueType.DATE:
					case ObjectValueType.DATETIME:
					case ObjectValueType.ABSTRACT_DATETIME:
						objectValue = new DateObjectValue(parsedObjectType, superset.value);
						break;

					default:
						objectValue = null;
						break;
				}
			}
			else
			{
				if (reader.TokenType == JsonToken.Boolean)
				{
					objectValue = new BooleanObjectValue((bool)reader.Value);
				}
				else if (reader.TokenType == JsonToken.Integer)
				{
					objectValue = new NumberObjectValue(Convert.ToDouble(reader.Value));
				}
				else if (reader.TokenType == JsonToken.Float)
				{
					objectValue = new NumberObjectValue((double)reader.Value);
				}
				else
				{
					objectValue = new StringObjectValue((string)reader.Value);
				}
			}
			return objectValue;
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
			serializerHelper.Serialize(writer, value);
		}

		private class ObjectValueAttributeSuperset
		{
			public string objectType;

			// PREDECESSOR_LIST specific attributes
			public IList<Predecessor> predecessors;

			// DURATION specific attributes
			public bool negative;
			public bool elapsed;
			public double weeks;
			public double days;
			public double hours;
			public double minutes;
			public double seconds;
			public double milliseconds;

			// CONTACT specific attributes
			public string id;
			public string name;
			public string email;

			// Various other types
			public string value;
		}
	}
}

