using System.IO;
using System.Text;
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


    //FIXME: remove all of the "_Renamed"
	/// <summary>
	/// This class represents an HTTP Entity (http://www.w3.org/Protocols/rfc2616/rfc2616-sec7.html).
	/// 
	/// Thread Safety: This class is not thread safe since it's mutable.
	/// </summary>
	public class HttpEntity
	{
		/// <summary>
		/// Represents the content type.
		/// 
		/// It has a pair of setter/getter (not shown on class diagram for brevity).
		/// </summary>
		private string contentType_Renamed;

		/// <summary>
		/// Represents the content length.
		/// 
		/// It has a pair of setter/getter (not shown on class diagram for brevity).
		/// </summary>
		private long contentLength_Renamed;

		/// <summary>
		/// Represents the content as an InputStream.
		/// 
		/// It has a pair of setter/getter (not shown on class diagram for brevity).
		/// </summary>
		private string content;

		/// <summary>
		/// Gets the content type.
		/// </summary>
		/// <returns> the content type </returns>
		public virtual string contentType
		{
			get
			{
				return contentType_Renamed;
			}
			set
			{
				this.contentType_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the content length.
		/// </summary>
		/// <returns> the content length </returns>
		public virtual long contentLength
		{
			get
			{
				return contentLength_Renamed;
			}
			set
			{
				this.contentLength_Renamed = value;
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
        public virtual StreamReader getContent()
        {
            //FIXME: Modify restsharp to use a stream for the content to save memory.
            return new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(content)));
        }


	}

}