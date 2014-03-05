using System.Collections.Generic;

namespace Smartsheet.Api.Internal.http
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
	/// This is the base class of HTTP messages, it holds Headers and an HttpEntity.
	/// 
	/// Thread Safety: This class is not thread safe since it's mutable.
	/// </summary>
	public abstract class HttpMessage
	{
		/// <summary>
		/// Represents the HTTP Headers.
		/// 
		/// It has a pair of setter/getter (not shown on class diagram for brevity).
		/// </summary>
		private IDictionary<string, string> headers;

		/// <summary>
		/// Represents the HTTP Entity.
		/// 
		/// It has a pair of setter/getter (not shown on class diagram for brevity).
		/// </summary>
		private HttpEntity entity;

		/// <summary>
		/// Gets the Headers.
		/// </summary>
		/// <returns> the Headers </returns>
		public virtual IDictionary<string, string> Headers
		{
			get
			{
				return headers;
			}
			set
			{
				this.headers = value;
			}
		}


		/// <summary>
		/// Gets the Entity.
		/// </summary>
		/// <returns> the Entity </returns>
		public virtual HttpEntity Entity
		{
			get
			{
				return entity;
			}
			set
			{
				this.entity = value;
			}
		}

	}

}