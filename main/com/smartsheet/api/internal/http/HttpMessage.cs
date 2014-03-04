using System.Collections.Generic;

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
	/// This is the base class of HTTP messages, it holds headers and an HttpEntity.
	/// 
	/// Thread Safety: This class is not thread safe since it's mutable.
	/// </summary>
	public abstract class HttpMessage
	{
		/// <summary>
		/// Represents the HTTP headers.
		/// 
		/// It has a pair of setter/getter (not shown on class diagram for brevity).
		/// </summary>
		private IDictionary<string, string> headers_Renamed;

		/// <summary>
		/// Represents the HTTP entity.
		/// 
		/// It has a pair of setter/getter (not shown on class diagram for brevity).
		/// </summary>
		private HttpEntity entity_Renamed;

		/// <summary>
		/// Gets the headers.
		/// </summary>
		/// <returns> the headers </returns>
		public virtual IDictionary<string, string> headers
		{
			get
			{
				return headers_Renamed;
			}
			set
			{
				this.headers_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the entity.
		/// </summary>
		/// <returns> the entity </returns>
		public virtual HttpEntity entity
		{
			get
			{
				return entity_Renamed;
			}
			set
			{
				this.entity_Renamed = value;
			}
		}

	}

}