//    #[ license]
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Smartsheet.Api.Internal.Json
{
	/*
	 * Taken from SO: http://stackoverflow.com/questions/22752075/how-can-i-ignore-unknown-enum-values-during-json-deserialization
	 * If the value found in the JSON matches the enum (either as a string or an integer), that value is used. 
	 * (If the value is integer and there are multiple possible matches, the first of those is used.)
	 * Otherwise if the enum type is nullable, then the value is set to null.
	 * Otherwise if the enum has a value called "Unknown", then that value is used.
	 * Otherwise the first value of the enum is used.
	 */
	class JsonEnumTypeConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			Type type = IsNullableType(objectType) ? Nullable.GetUnderlyingType(objectType) : objectType;
			return type.IsEnum;
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
		{
			bool isNullable = IsNullableType(objectType);
			Type enumType = isNullable ? Nullable.GetUnderlyingType(objectType) : objectType;

			string[] names = Enum.GetNames(enumType);

			if (reader.TokenType == JsonToken.String)
			{
				string enumText = reader.Value.ToString();

				if (!string.IsNullOrEmpty(enumText))
				{
					string match = names
						.Where(n => string.Equals(n, enumText, StringComparison.OrdinalIgnoreCase))
						.FirstOrDefault();

					if (match != null)
					{
						return Enum.Parse(enumType, match);
					}
				}
			}
			else if (reader.TokenType == JsonToken.Integer)
			{
				int enumVal = Convert.ToInt32(reader.Value);
				int[] values = (int[])Enum.GetValues(enumType);
				if (values.Contains(enumVal))
				{
					return Enum.Parse(enumType, enumVal.ToString());
				}
			}

			if (!isNullable)
			{
				string defaultName = names
					.Where(n => string.Equals(n, "Unknown", StringComparison.OrdinalIgnoreCase))
					.FirstOrDefault();

				if (defaultName == null)
				{
					defaultName = names.First();
				}

				return Enum.Parse(enumType, defaultName);
			}

			return null;
		}

		public override void WriteJson(JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
		{
			writer.WriteValue(value.ToString());
		}

		private bool IsNullableType(Type t)
		{
			return (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
		}
	}
}
