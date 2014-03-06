namespace Smartsheet.Api.Models
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
	/// Result object To contain information about a PUT or POST request.
	/// </summary>
	public class Result<T>
	{
		/// <summary>
		/// Represents the Result Code from the request. </summary>
		private int? resultCode;

		/// <summary>
		/// Represents the Message from the request. </summary>
		private string message;

		/// <summary>
		/// Represents the object that was created or updated. </summary>
		private T result;

		/// <summary>
		/// Represents the new Version of the sheet. It is only available on some operations. </summary>
		private int? version;

        /// <summary>
        /// Gets the Result Code from the request.
        /// </summary>
        /// <value>
        /// The result code.
        /// </value>
        /// <returns> the Result Code </returns>
		public virtual int? ResultCode
		{
			get
			{
				return resultCode;
			}
			set
			{
				this.resultCode = value;
			}
		}


        /// <summary>
        /// Gets the Message from the request.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        /// <returns> the Message </returns>
		public virtual string Message
		{
			get
			{
				return message;
			}
			set
			{
				this.message = value;
			}
		}


        /// <summary>
        /// Gets the Result from the request.
        /// </summary>
        /// <value>
        /// The result object.
        /// </value>
        /// <returns> the Result </returns>
		public virtual T ResultObject
		{
			get
			{
				return result;
			}
			set
			{
				this.result = value;
			}
		}


        /// <summary>
        /// Gets the new Version of the sheet. It is only available on some operations..
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        /// <returns> the Version </returns>
		public virtual int? Version
		{
			get
			{
				return version;
			}
			set
			{
				this.version = value;
			}
		}



	}

}