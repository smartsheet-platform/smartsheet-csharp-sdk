using com.smartsheet.api.@internal.util;
using com.smartsheet.api.models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace com.smartsheet.api.@internal.json
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
     * Unless required by applicable law or agreed to in writing, software
     * distributed under the License is distributed on an "AS IS" BASIS,
     * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
     * See the License for the specific language governing permissions and
     * limitations under the License.
     * %[license]
     */


    //using Include = com.fasterxml.jackson.annotation.JsonInclude.Include;
    //using JsonGenerationException = com.fasterxml.jackson.core.JsonGenerationException;
    //using JsonParseException = com.fasterxml.jackson.core.JsonParseException;
    //using TypeReference = com.fasterxml.jackson.core.type.TypeReference;
    //using DeserializationFeature = com.fasterxml.jackson.databind.DeserializationFeature;
    //using JsonMappingException = com.fasterxml.jackson.databind.JsonMappingException;
    //using ObjectMapper = com.fasterxml.jackson.databind.ObjectMapper;
    //using Util = com.smartsheet.api.@internal.util.Util;
    //using IdentifiableModel = com.smartsheet.api.models.IdentifiableModel;
    //using com.smartsheet.api.models;

    /// <summary>
    /// This is the Jackson based JsonSerializer implementation.
    /// 
    /// Thread Safety: This class is thread safe because it is immutable and the underlying Jackson ObjectMapper is thread
    /// safe as long as it is not re-configured.
    /// </summary>
    public class JacksonJsonSerializer : JsonSerializer
    {
        /// <summary>
        /// Represents the ObjectMapper used to serialize/de-serialize JSON.
        /// 
        /// It will be initialized in a static initializer and will not change afterwards.
        /// 
        /// Because ObjectMapper is thread-safe as long as it's not reconfigured, a static final class-level ObjectMapper is
        /// used to achieve best performance.
        /// </summary>
        //private static readonly ObjectMapper OBJECT_MAPPER = new ObjectMapper();
        private static readonly new Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();

        static JacksonJsonSerializer()
        {

            // No formatting to decrease the length;
            serializer.Formatting = Newtonsoft.Json.Formatting.None;

            // Allow deserialization if there are properties that can't be deserialized
            serializer.MissingMemberHandling = Newtonsoft.Json.MissingMemberHandling.Ignore;

            // Set the date format to ISO 8601
            serializer.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat;

            // Only include non-null properties in when serializing
            serializer.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;

            // Excludes "id" field from being serialized to JSON for any IdentifiableModel class
            serializer.ContractResolver = new IdExclusion();

            // Convert all enums to a string representation for serialization
            serializer.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
        }

        /// <summary>
        /// Sets if the OBJECT MAPPER should ignore unknown properties or fail when de-serializing the JSON data.
        /// </summary>
        /// <param name="value">
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
        /// Serialize an object to JSON.
        /// 
        /// Parameters: 
        ///   object : the object to serialize
        ///   outputStream : the output stream to which the JSON will be written
        /// 
        /// Returns: None
        /// 
        /// Exceptions: - IllegalArgumentException : if any argument is null - JSONSerializationException : if there is any
        /// other error occurred during the operation
        /// </summary>
        /// <param name="outputStream"> </param>
        /// <param name="object"> </param>
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
        /// <param name="inputStream"> the input stream from which the JSON will be read </param>
        /// <param name="objectClass"> the class of the object to de-serialize
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
        /// <param name="inputStream"> the input stream from which the JSON will be read </param>
        /// <param name="objectClass"> the class of the object (of the list) to de-serialize
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
        /// De-serialize to a map from JSON.
        /// </summary>
        /// <param name="objectClass"> </param>
        /// <param name="inputStream">
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
        /// <param name="inputStream"> the input stream from which the JSON will be read </param>
        /// <param name="objectClass"> the class of the object (of the Result) to de-serialize </param>
        /// <returns> the de-serialized result </returns>
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
        /// Returns: the de-serialized result
        /// 
        /// Exceptions: 
        ///   - IllegalArgumentException : if any argument is null 
        ///   - JSONSerializationException : if there is any other error occurred during the operation
        /// </summary>
        /// <param name="inputStream"> the input stream from which the JSON will be read </param>
        /// <param name="objectClass"> the class of the object (of the Result) to de-serialize
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