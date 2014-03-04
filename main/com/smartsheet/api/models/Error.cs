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
	/// Represents Error object.
	/// </summary>
	public class Error
	{
		/// <summary>
		/// Represents the error code.
		/// </summary>
		private int? errorCode_Renamed;

		/// <summary>
		/// Represents the message.
		/// </summary>
		private string message_Renamed;

		/// <summary>
		/// Gets the message.
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
		/// Gets the error code.
		/// </summary>
		/// <returns> the error code </returns>
		public virtual int? errorCode
		{
			get
			{
				return errorCode_Renamed;
			}
			set
			{
				this.errorCode_Renamed = value;
			}
		}

	}

}