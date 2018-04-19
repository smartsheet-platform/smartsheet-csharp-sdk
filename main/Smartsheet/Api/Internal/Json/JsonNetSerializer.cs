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
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//    %[license]

using Newtonsoft.Json;
using Smartsheet.Api.Internal.Utility;
using Smartsheet.Api.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Smartsheet.Api.Internal.Json
{
	using Utils = Api.Internal.Utility.Utility;

	/// <summary>
	/// This is the Jackson based JsonSerializer implementation.
	/// 
	/// Thread Safety: This class is thread safe because it is immutable and the underlying JSON.NET is thread
	/// safe as long as it is not re-configured.
	/// </summary>
	public class JsonNetSerializer : JsonSerializer
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
		private static readonly Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();

		static JsonNetSerializer()
		{
			// No formatting to decrease the length;
			serializer.Formatting = Newtonsoft.Json.Formatting.None;

			// Allow deserialization if there are properties that can't be deserialized
			serializer.MissingMemberHandling = Newtonsoft.Json.MissingMemberHandling.Ignore;

			// Set the date Format to ISO 8601
			serializer.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat;

			// Only include non-null properties in when serializing
			serializer.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;

			// Excludes "Id" field from being serialized to JSON for any IdentifiableModel class
			serializer.ContractResolver = new ContractResolver();

			// Handles enum serialization
			serializer.Converters.Add(new JsonEnumTypeConverter());

			// Convert all enums to a string representation for serialization
			serializer.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());

			// Handles objectValue serialization
			serializer.Converters.Add(new ObjectValueTypeConverter());

			// Handles primitive objectValue serialization
			serializer.Converters.Add(new PrimitiveObjectValueConverter());

			// Handles Hyperlink serialization in the case of an empty hyperlink (reset)
			serializer.Converters.Add(new HyperlinkConverter());

			// Handles linkInFromCell serialization
			serializer.Converters.Add(new CellTypeConverter());

			// Handles ErrorDetails 
			serializer.Converters.Add(new ErrorTypeConverter());
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
		public JsonNetSerializer()
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
		/// <exception cref="JsonSerializationException"> </exception>
		// @Override
		public virtual void serialize<T>(T @object, StreamWriter outputStream)
		{
			Utils.ThrowIfNull(@object, outputStream);
			try
			{
				serializer.Serialize(new Newtonsoft.Json.JsonTextWriter(outputStream), @object);
				outputStream.Flush();
			}
			catch (Newtonsoft.Json.JsonException ex)
			{
				throw new JsonSerializationException(ex);
			}
			catch (IOException ex)
			{
				throw new JsonSerializationException(ex);
			}
			catch (ObjectDisposedException ex)
			{
				throw new JsonSerializationException(ex);
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
		/// <exception cref="Api.Internal.Json.JsonSerializationException"> </exception>
		public virtual T deserialize<T>(StreamReader inputStream)
		{
			Utils.ThrowIfNull(inputStream);
			try
			{
				return serializer.Deserialize<T>(new Newtonsoft.Json.JsonTextReader(inputStream));
			}
			catch (Newtonsoft.Json.JsonException ex)
			{
				throw new JsonSerializationException(ex);
			}
			catch (IOException ex)
			{

				throw new JsonSerializationException(ex);
			}
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
		/// <exception cref="JsonSerializationException"> </exception>
		public virtual IList<T> deserializeList<T>(StreamReader inputStream)
		{
			Utils.ThrowIfNull(inputStream);

			IList<T> list = null;

			try
			{
				// Read the Json input stream into a List.
				list = serializer.Deserialize<IList<T>>(new Newtonsoft.Json.JsonTextReader(inputStream));
			}
			catch (Newtonsoft.Json.JsonException ex)
			{
				throw new JsonSerializationException(ex);
			}
			catch (IOException ex)
			{
				throw new JsonSerializationException(ex);
			}

			return list;
		}

		/// <summary>
		/// De-serialize to a DataWrapper (holds pagination info) from JSON
		/// </summary>
		/// <returns>DataWrapper containing data and pagination info</returns>
		/// <param name="inputStream"> the input stream from which the JSON will be read </param>
		/// <exception cref="ArgumentException"> if any argument is null </exception>
		/// <exception cref="JsonSerializationException">if there is any other error occurred during the operation </exception>
		public PaginatedResult<T> DeserializeDataWrapper<T>(StreamReader inputStream)
		{
			Utils.ThrowIfNull(inputStream);

			PaginatedResult<T> rw = null;

			try
			{
				// Read the Json input stream into a List.
				rw = serializer.Deserialize<PaginatedResult<T>>(new Newtonsoft.Json.JsonTextReader(inputStream));
			}
			catch (Newtonsoft.Json.JsonException ex)
			{
				throw new JsonSerializationException(ex);
			}
			catch (IOException ex)
			{
				throw new JsonSerializationException(ex);
			}

			return rw;
		}

		/// <summary>
		/// De-serialize to a map from JSON.
		/// </summary>
		/// <param name="inputStream">
		/// @return </param>
		/// <exception cref="JsonSerializationException"> </exception>
		// @Override
		public virtual IDictionary<string, object> DeserializeMap(StreamReader inputStream)
		{
			Utils.ThrowIfNull(inputStream);

			IDictionary<string, object> map = null;

			try
			{
				map = serializer.Deserialize<IDictionary<string, object>>(new Newtonsoft.Json.JsonTextReader(inputStream));
			}
			catch (Newtonsoft.Json.JsonException ex)
			{
				throw new JsonSerializationException(ex);
			}
			catch (IOException ex)
			{
				throw new JsonSerializationException(ex);
			}

			return map;
		}

		/// <summary>
		/// De-serialize a RequestResult&lt;T&gt; object from JSON. 
		/// 
		/// Exceptions: 
		///   - IllegalArgumentException : if any argument is null 
		///   - JSONSerializationException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="inputStream"> the input stream from which the JSON will be read </param>
		/// <returns> the de-serialized RequestResult </returns>
		/// <exception cref="JsonSerializationException"> </exception>
		// @Override
		public virtual RequestResult<T> deserializeResult<T>(StreamReader inputStream)
		{
			Utils.ThrowIfNull(inputStream);

			RequestResult<T> result = null;

			try
			{
				result = serializer.Deserialize<RequestResult<T>>(new Newtonsoft.Json.JsonTextReader(inputStream));
			}
			catch (Newtonsoft.Json.JsonException ex)
			{
				throw new JsonSerializationException(ex);
			}
			catch (IOException ex)
			{
				throw new JsonSerializationException(ex);
			}
			catch (ObjectDisposedException ex)
			{
				throw new JsonSerializationException(ex);
			}

			return result;
		}

		/// <summary>
		/// De-serialize a RequestResult&lt;List&lt;T&gt;&gt; object from JSON.
		/// 
		/// Parameters: - objectClass :  - inputStream : 
		/// 
		/// Returns: the de-serialized RequestResult
		/// 
		/// Exceptions: 
		///   - IllegalArgumentException : if any argument is null 
		///   - JSONSerializationException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="inputStream"> the input stream from which the JSON will be read </param>
		/// <exception cref="JsonSerializationException"> </exception>
		// @Override
		public virtual RequestResult<IList<T>> deserializeListResult<T>(StreamReader inputStream)
		{
			Utils.ThrowIfNull(inputStream);

			RequestResult<IList<T>> result = null;

			try
			{
				result = serializer.Deserialize<RequestResult<IList<T>>>(new Newtonsoft.Json.JsonTextReader(inputStream));
			}
			catch (Newtonsoft.Json.JsonException ex)
			{
				throw new JsonSerializationException(ex);
			}
			catch (IOException ex)
			{
				throw new JsonSerializationException(ex);
			}

			return result;
		}

		public virtual CopyOrMoveRowResult DeserializeRowResult(StreamReader inputStream)
		{
			Utils.ThrowIfNull(inputStream);

			CopyOrMoveRowResult result = null;

			try
			{
				result = serializer.Deserialize<CopyOrMoveRowResult>(new Newtonsoft.Json.JsonTextReader(inputStream));
			}
			catch (Newtonsoft.Json.JsonException ex)
			{
				throw new JsonSerializationException(ex);
			}
			catch (IOException ex)
			{
				throw new JsonSerializationException(ex);
			}

			return result;
		}

	}

}