using System;
using System.Collections.Generic;

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




	using com.smartsheet.api.models;
    using System.IO;

	/// <summary>
	/// This interface defines methods to handle JSON serialization/de-serialization.
	/// 
	/// Thread Safety: Implementation of this interface must be thread safe.
	/// </summary>
	public interface JsonSerializer
	{

		/// <summary>
		/// Serialize an object to JSON.
		/// 
		/// Parameters: - object : the object to serialize - outputStream : the output stream to which the JSON will be
		/// written
		/// 
		/// Returns: None
		/// 
		/// Exceptions: - IllegalArgumentException : if any argument is null - JSONSerializationException : if there is any
		/// other error occurred during the operation
		/// </summary>
		/// @param <T> the generic type </param>
		/// <param name="object"> the object </param>
		/// <param name="outputStream"> the output stream </param>
		/// <exception cref="JSONSerializationException"> the JSON serializer exception </exception>
		void serialize<T>(T @object, StreamWriter outputStream);

		/// <summary>
		/// De-serialize an object from JSON.
		/// 
		/// Parameters: - objectClass : the class of the object to de-serialize - inputStream : the input stream from which
		/// the JSON will be read
		/// 
		/// Returns: the de-serialized object
		/// 
		/// Exceptions: - IllegalArgumentException : if any argument is null - JSONSerializationException : if there is any
		/// other error occurred during the operation
		/// </summary>
		/// @param <T> the generic type </param>
		/// <param name="objectClass"> the object class </param>
		/// <param name="inputStream"> the input stream </param>
		/// <returns> the t </returns>
		/// <exception cref="JsonParseException"> the json parse exception </exception>
		/// <exception cref="JsonMappingException"> the json mapping exception </exception>
		/// <exception cref="IOException"> Signals that an I/O exception has occurred. </exception>
		T deserialize<T>(StreamReader inputStream);

		/// <summary>
		/// De-serialize an object list from JSON.
		/// 
		/// Parameters: - objectClass : the class of the object (of the list) to de-serialize - inputStream : the input
		/// stream from which the JSON will be read
		/// 
		/// Returns: the de-serialized list
		/// 
		/// Exceptions: - IllegalArgumentException : if any argument is null - JSONSerializationException : if there is any
		/// other error occurred during the operation
		/// </summary>
		/// @param <T> the generic type </param>
		/// <param name="objectClass"> the object class </param>
		/// <param name="inputStream"> the input stream </param>
		/// <returns> the list </returns>
		/// <exception cref="JSONSerializationException"> the JSON serializer exception </exception>
		IList<T> deserializeList<T>(StreamReader inputStream);


		/// <summary>
		/// De-serialize an object list from JSON to a Map.
		/// </summary>
		/// <param name="inputStream"> the input stream </param>
		/// <returns> the map </returns>
		/// <exception cref="JSONSerializationException"> the JSON serializer exception </exception>
		IDictionary<string, object> DeserializeMap(StreamReader inputStream);

		/// <summary>
		/// De-serialize a Result<T> object from JSON.
		/// 
		/// Parameters: - objectClass : the class of the object (of the Result) to de-serialize - inputStream : the input
		/// stream from which the JSON will be read
		/// 
		/// Returns: the de-serialized result
		/// 
		/// Exceptions: - IllegalArgumentException : if any argument is null - JSONSerializationException : if there is any
		/// other error occurred during the operation
		/// </summary>
		/// @param <T> the generic type </param>
		/// <param name="objectClass"> the object class </param>
		/// <param name="inputStream"> the input stream </param>
		/// <returns> the result </returns>
		/// <exception cref="JSONSerializationException"> the JSON serializer exception </exception>
		Result<T> deserializeResult<T>(StreamReader inputStream);

		/// <summary>
		/// De-serialize a Result<List<T>> object from JSON.
		/// 
		/// Parameters: - objectClass : the class of the object (of the Result) to de-serialize - inputStream : the input
		/// stream from which the JSON will be read
		/// 
		/// Returns: the de-serialized result
		/// 
		/// Exceptions: - IllegalArgumentException : if any argument is null - JSONSerializationException : if there is any
		/// other error occurred during the operation
		/// </summary>
		/// @param <T> the generic type </param>
		/// <param name="objectClass"> the object class </param>
		/// <param name="inputStream"> the input stream </param>
		/// <returns> the result </returns>
		/// <exception cref="JSONSerializationException"> the JSON serializer exception </exception>
		Result<IList<T>> deserializeListResult<T>(StreamReader inputStream);

	}

}