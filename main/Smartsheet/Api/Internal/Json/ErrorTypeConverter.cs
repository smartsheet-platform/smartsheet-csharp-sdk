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

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smartsheet.Api.Models;

namespace Smartsheet.Api.Internal.Json
{
    class ErrorTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(Error).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartObject)
            {
                Error error = (Error)Activator.CreateInstance(objectType);
                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.PropertyName)
                    {
                        if (reader.Value.Equals("errorCode"))
                        {
                            error.ErrorCode = reader.ReadAsInt32();
                        }
                        else if (reader.Value.Equals("message"))
                        {
                            error.Message = reader.ReadAsString();
                        }
                        else if (reader.Value.Equals("refId"))
                        {
                            error.RefId = reader.ReadAsString();
                        }
                        else if (reader.Value.Equals("detail"))
                        {
                            reader.Read();
                            if (reader.TokenType == JsonToken.StartObject)
                            {
                                ErrorDetail errorDetail = new ErrorDetail();
                                serializer.Populate(reader, errorDetail);
                                error.Detail = errorDetail;
                                reader.Read(); // JsonToken.EndObject
                            }
                            else if (reader.TokenType == JsonToken.StartArray)
                            {
                                IList<ErrorDetail> errorDetails = null;
                                errorDetails = serializer.Deserialize<IList<ErrorDetail>>(reader);
                                error.Detail = errorDetails;
                                reader.Read(); // JsonToken.EndArray
                            }
                        }
                    }
                    else if (reader.TokenType == JsonToken.EndObject)
                    {
                        break;
                    }
                }
                return error;
            }
            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
        {
        }
    }
}
