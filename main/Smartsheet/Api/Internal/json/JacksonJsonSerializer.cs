using Smartsheet.Api.Internal.util;
using Smartsheet.Api.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Smartsheet.Api.Internal.json
{

    /*
     * #[license]
     * Smartsheet SDK for C#
     * %%
     * Copyright (C) 2014 Smartsheet
     * %%
     * Licensed under the Apache License, Version 2.0 (the "License");
     * you may not use this file except in compliance with the License.
     * You may obtain a copy of the License at
     * 
     *      http://www.apache.org/licenses/LICENSE-2.0
     * 
     * Unless required by applicable law or agreed To in writing, software
     * distributed under the License is distributed on an "AS IS" BASIS,
     * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
     * See the License for the specific language governing permissions and
     * limitations under the License.
     * %[license]
     */


    //using Include = fasterxml.jackson.annotation.JsonInclude.Include;
    //using JsonGenerationException = fasterxml.jackson.core.JsonGenerationException;
    //using JsonParseException = fasterxml.jackson.core.JsonParseException;
    //using TypeReference = fasterxml.jackson.core.Type.TypeReference;
    //using DeserializationFeature = fasterxml.jackson.databind.DeserializationFeature;
    //using JsonMappingException = fasterxml.jackson.databind.JsonMappingException;
    //using ObjectMapper = fasterxml.jackson.databind.ObjectMapper;
    //using Util = Api.Internal.util.Util;
    //using IdentifiableModel = Api.Models.IdentifiableModel;
    //using Smartsheet.Api.Models;

    /// <summary>
    /// This is the Jackson based JsonSerializer implementation.
    /// 
    /// Thread Safety: This class is thread safe because it is immutable and the underlying Jackson ObjectMapper is thread
    /// safe as long as it is not re-configured.
    /// </summary>
    public class JacksonJsonSerializer : JsonSerializer
    {
        /// <summary>
        /// Represents the ObjectMapper used To serialize/de-serialize JSON.
        /// 
        /// It will be initialized in a static initializer and will not change afterwards.
        /// 
        /// Because ObjectMapper is thread-safe as long as it's not reconfigured, a static final class-level ObjectMapper is
        /// used To achieve best performance.
        /// </summary>
        //private static readonly ObjectMapper OBJECT_MAPPER = new ObjectMapper();
        private static readonly Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();

        static JacksonJsonSerializer()
        {

            // No formatting To decrease the length;
            serializer.Formatting = Newtonsoft.Json.Formatting.None;

            // Allow deserialization if there are properties that can't be deserialized
            serializer.MissingMemberHandling = Newtonsoft.Json.MissingMemberHandling.Ignore;

            // Set the date Format To ISO 8601
            serializer.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat;

            // Only include non-null properties in when serializing
            serializer.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;

            // Excludes "Id" field from being serialized To JSON for any IdentifiableModel class
            serializer.ContractResolver = new IdExclusion();

            // Convert all enums To a string representation for serialization
            serializer.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
        }

        /// <summary>
        /// Sets if the OBJECT MAPPER should ignore unknown properties or fail when de-serializing the JSON data.
        /// </summary>
        /// <param Name="Value">
        ///            true if it should fail, false otherwise. </param>
        public virtual Newtonsoft.Json.MissingMemberHandling failOnUnknownProperties
        {
            set
            {
                serializer.MissingMemberHandling = value;
            }
        }

        /// <summary>
        /// Constructor.
        /// 
        /// Parameters: None
        /// 
        /// Exceptions: None
        /// </summary>
        public JacksonJsonSerializer()
        {
        }

        /// <summary>
        /// Serialize an object To JSON.
        /// 
        /// Parameters: 
        ///   object : the object To serialize
        ///   outputStream : the output stream To which the JSON will be written
        /// 
        /// Returns: None
        /// 
        /// Exceptions: - IllegalArgumentException : if any argument is null - JSONSerializationException : if there is any
        /// other error occurred during the operation
        /// </summary>
        /// <param Name="outputStream"> </param>
        /// <param Name="object"> </param>
        /// <exception cref="JSONSerializationException"> </exception>
        // @Override
        public virtual void serialize<T>(T @object, StreamWriter outputStream)
        {
            Util.ThrowIfNull(@object, outputStream);

            try
            {
                serializer.Serialize(new Newtonsoft.Json.JsonTextWriter(outputStream), @object);
                outputStream.Flush();
            }
            catch (Newtonsoft.Json.JsonException ex)
            {
                throw new JSONSerializationException(ex);
            }
            catch (IOException ex)
            {
                throw new JSONSerializationException(ex);
            }
        }

        /// <summary>
        /// De-serialize an object from JSON.
        /// 
        /// Returns: the de-serialized object
        /// 
        /// Exceptions: 
        ///   - IllegalArgumentException : if any argument is null 
        ///   - JSONSerializationException : if there is any other error occurred during the operation
        /// </summary>
        /// <param Name="inputStream"> the input stream from which the JSON will be read </param>
        /// <param Name="objectClass"> the class of the object To de-serialize
        /// @return </param>
        /// <exception cref="JSONSerializationException"> </exception>
        // @Override
        //TODO: remove objectClass variable
        public virtual T deserialize<T>(StreamReader inputStream)
        {
            Util.ThrowIfNull(inputStream);
            try
            {
                return serializer.Deserialize<T>(new Newtonsoft.Json.JsonTextReader(inputStream));
            }
            catch (Newtonsoft.Json.JsonException ex)
            {
                throw new JSONSerializationException(ex);
            }
            catch (IOException ex)
            {
                throw new JSONSerializationException(ex);
            }


            //return OBJECT_MAPPER.readValue(inputStream, objectClass);
        }

        /// <summary>
        /// De-serialize an object list from JSON. 
        /// 
        /// Returns: the de-serialized list
        /// 
        /// Exceptions: 
        ///   - IllegalArgumentException : if any argument is null 
        ///   - JSONSerializationException : if there is any other error occurred during the operation
        /// </summary>
        /// <param Name="inputStream"> the input stream from which the JSON will be read </param>
        /// <param Name="objectClass"> the class of the object (of the list) To de-serialize
        /// @return </param>
        /// <exception cref="JSONSerializationException"> </exception>
        // @Override
        //TODO: remove objectClass variable
        public virtual IList<T> deserializeList<T>(StreamReader inputStream)
        {
            Util.ThrowIfNull(inputStream);

            IList<T> list = null;

            try
            {
                // Read the json input stream into a List.
                list = serializer.Deserialize<IList<T>>(new Newtonsoft.Json.JsonTextReader(inputStream));
            }
            catch (Newtonsoft.Json.JsonException ex)
            {
                throw new JSONSerializationException(ex);
            }
            catch (IOException ex)
            {
                throw new JSONSerializationException(ex);
            }

            return list;
        }

        /// <summary>
        /// De-serialize To a map from JSON.
        /// </summary>
        /// <param Name="objectClass"> </param>
        /// <param Name="inputStream">
        /// @return </param>
        /// <exception cref="JSONSerializationException"> </exception>
        // @Override
        public virtual IDictionary<string, object> DeserializeMap(StreamReader inputStream)
        {
            Util.ThrowIfNull(inputStream);

            IDictionary<string, object> map = null;

            try
            {
                map = serializer.Deserialize<IDictionary<string,object>>(new Newtonsoft.Json.JsonTextReader(inputStream));
            }
            catch (Newtonsoft.Json.JsonException ex)
            {
                throw new JSONSerializationException(ex);
            }
            catch (IOException ex)
            {
                throw new JSONSerializationException(ex);
            }

            return map;
        }

        /// <summary>
        /// De-serialize a Result<T> object from JSON. 
        /// 
        /// Exceptions: 
        ///   - IllegalArgumentException : if any argument is null 
        ///   - JSONSerializationException : if there is any other error occurred during the operation
        /// </summary>
        /// <param Name="inputStream"> the input stream from which the JSON will be read </param>
        /// <param Name="objectClass"> the class of the object (of the Result) To de-serialize </param>
        /// <returns> the de-serialized Result </returns>
        /// <exception cref="JSONSerializationException"> </exception>
        // @Override
        public virtual Result<T> deserializeResult<T>(StreamReader inputStream)
        {
            Util.ThrowIfNull(inputStream);

            Result<T> result = null;

            try
            {
                result = serializer.Deserialize<Result<T>>(new Newtonsoft.Json.JsonTextReader(inputStream));
            }
            catch (Newtonsoft.Json.JsonException ex)
            {
                throw new JSONSerializationException(ex);
            }
            catch (IOException ex)
            {
                throw new JSONSerializationException(ex);
            }

            return result;
        }

        /// <summary>
        /// De-serialize a Result<List<T>> object from JSON.
        /// 
        /// Parameters: - objectClass :  - inputStream : 
        /// 
        /// Returns: the de-serialized Result
        /// 
        /// Exceptions: 
        ///   - IllegalArgumentException : if any argument is null 
        ///   - JSONSerializationException : if there is any other error occurred during the operation
        /// </summary>
        /// <param Name="inputStream"> the input stream from which the JSON will be read </param>
        /// <param Name="objectClass"> the class of the object (of the Result) To de-serialize
        /// @return </param>
        /// <exception cref="JSONSerializationException"> </exception>
        // @Override
        public virtual Result<IList<T>> deserializeListResult<T>(StreamReader inputStream)
        {
            Util.ThrowIfNull(inputStream);

            Result<IList<T>> result = null;

            try
            {
                result = serializer.Deserialize<Result<IList<T>>>(new Newtonsoft.Json.JsonTextReader(inputStream));
            }
            catch (Newtonsoft.Json.JsonException ex)
            {
                throw new JSONSerializationException(ex);
            }
            catch (IOException ex)
            {
                throw new JSONSerializationException(ex);
            }

            return result;
        }
    }

}