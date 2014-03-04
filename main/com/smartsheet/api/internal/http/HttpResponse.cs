using System.Net;
namespace com.smartsheet.api.@internal.http
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



	/// <summary>
	/// This class represents an HTTP response.
	/// 
	/// Thread Safety: This class is not thread safe since it's mutable.
	/// </summary>
	public class HttpResponse : HttpMessage
	{
		/// <summary>
		/// Represents the response status code.
		/// 
		/// It has a pair of setter/getter (not shown on class diagram for brevity).
		/// </summary>
		private HttpStatusCode statusCode;

		/// <summary>
		/// Gets the status code.
		/// </summary>
		/// <returns> the status code </returns>
		public virtual HttpStatusCode StatusCode
		{
			get
			{
				return statusCode;
			}
			set
			{
				this.statusCode = value;
			}
		}

	}

}