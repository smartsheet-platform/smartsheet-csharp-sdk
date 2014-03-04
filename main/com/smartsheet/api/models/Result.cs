namespace com.smartsheet.api.models
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
	/// Result object to contain information about a PUT or POST request.
	/// </summary>
	/// @param <T> the generic type </param>
	public class Result<T>
	{
		/// <summary>
		/// Represents the result code from the request. </summary>
		private int? resultCode_Renamed;

		/// <summary>
		/// Represents the message from the request. </summary>
		private string message_Renamed;

		/// <summary>
		/// Represents the object that was created or updated. </summary>
		private T result_Renamed;

		/// <summary>
		/// Represents the new version of the sheet. It is only available on some operations. </summary>
		private int? version_Renamed;

		/// <summary>
		/// Gets the result code from the request.
		/// </summary>
		/// <returns> the result code </returns>
		public virtual int? resultCode
		{
			get
			{
				return resultCode_Renamed;
			}
			set
			{
				this.resultCode_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the message from the request.
		/// </summary>
		/// <returns> the message </returns>
		public virtual string message
		{
			get
			{
				return message_Renamed;
			}
			set
			{
				this.message_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the result from the request.
		/// </summary>
		/// <returns> the result </returns>
		public virtual T result
		{
			get
			{
				return result_Renamed;
			}
			set
			{
				this.result_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the new version of the sheet. It is only available on some operations..
		/// </summary>
		/// <returns> the version </returns>
		public virtual int? version
		{
			get
			{
				return version_Renamed;
			}
			set
			{
				this.version_Renamed = value;
			}
		}



	}

}