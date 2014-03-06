using System.IO;
using System.Text;
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
	/// This class represents an HTTP Entity (http://www.w3.org/Protocols/rfc2616/rfc2616-sec7.html).
	/// 
	/// Thread Safety: This class is not thread safe since it's mutable.
	/// </summary>
	public class HttpEntity
	{
		/// <summary>
		/// Represents the content Type.
		/// 
		/// It has a pair of setter/getter (not shown on class diagram for brevity).
		/// </summary>
		private string contentType;

		/// <summary>
		/// Represents the content length.
		/// 
		/// It has a pair of setter/getter (not shown on class diagram for brevity).
		/// </summary>
		private long contentLength;

		/// <summary>
		/// Represents the content as an InputStream.
		/// 
		/// It has a pair of setter/getter (not shown on class diagram for brevity).
		/// </summary>
		private string content;

		/// <summary>
		/// Gets the content Type.
		/// </summary>
		/// <returns> the content Type </returns>
		public virtual string ContentType
		{
			get
			{
				return contentType;
			}
			set
			{
				this.contentType = value;
			}
		}


		/// <summary>
		/// Gets the content length.
		/// </summary>
		/// <returns> the content length </returns>
		public virtual long ContentLength
		{
			get
			{
				return contentLength;
			}
			set
			{
				this.contentLength = value;
			}
		}


		/// <summary>
		/// Gets the content.
		/// </summary>
		/// <returns> the content </returns>
		public virtual string Content
		{
			set
			{
				this.content = value;
			}
		}
        /// <summary>
        /// Gets the content as a stream
        /// </summary>
        /// <returns></returns>
        public virtual StreamReader getContent()
        {
            //FIXME: Modify restsharp To use a stream for the content To save memory.
            return new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(content)));
        }


	}

}