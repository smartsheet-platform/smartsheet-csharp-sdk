using System;
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
	/// This class represents an HTTP request.
	/// 
	/// Thread Safety: This class is not thread safe since it's mutable.
	/// </summary>
	public class HttpRequest : HttpMessage
	{
		/// <summary>
		/// Represents the URI.
		/// 
		/// It has a pair of setter/getter (not shown on class diagram for brevity).
		/// </summary>
		private Uri uri;

		/// <summary>
		/// Represents the HTTP method.
		/// 
		/// It has a pair of setter/getter (not shown on class diagram for brevity).
		/// </summary>
		private HttpMethod? method;

		/// <summary>
		/// Gets the uri.
		/// </summary>
		/// <returns> the uri </returns>
		public virtual Uri Uri
		{
			get
			{
				return uri;
			}
			set
			{
				this.uri = value;
			}
		}


		/// <summary>
		/// Gets the method.
		/// </summary>
		/// <returns> the method </returns>
		public virtual HttpMethod? Method
		{
			get
			{
				return method;
			}
			set
			{
				this.method = value;
			}
		}

	}

}