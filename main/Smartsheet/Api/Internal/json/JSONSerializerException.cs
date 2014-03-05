using System;

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



	/// <summary>
	/// This is the exception throw by JSONSerializer To indicate errors occurred during JSON serialization/de-serialization.
	/// 
	/// Thread safety: Exceptions are not thread safe.
	/// </summary>
	public class JSONSerializationException : SmartsheetException
	{



		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param Name="Message"> the Message </param>
		public JSONSerializationException(string message) : base(message)
		{
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param Name="Message"> the Message </param>
		/// <param Name="cause"> the cause </param>
		public JSONSerializationException(string message, Exception cause) : base(message, cause)
		{
		}

		/// <summary>
		/// Instantiates a new JSON serializer exception.
		/// </summary>
		/// <param Name="e"> the e </param>
		public JSONSerializationException(Exception e) : base(e)
		{
		}
	}

}