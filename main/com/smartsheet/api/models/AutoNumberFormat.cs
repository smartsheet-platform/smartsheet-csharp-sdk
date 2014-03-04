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
	/// Represents the AutoNumberFormat object. It describes how the the System Column type of "AUTO_NUMBER" is auto-generated </summary>
	/// <seealso cref= <a href="http://www.smartsheet.com/developers/api-documentation#h.xu85ymcuwnmq">Auto Number Format API Documentation</a> </seealso>
	/// <seealso cref= <a href="http://help.smartsheet.com/customer/portal/articles/1108408-auto-numbering">Auto Number Format Help</a> </seealso>
	public class AutoNumberFormat
	{

		/// <summary>
		/// Represents the prefix. </summary>
		private string prefix_Renamed;

		/// <summary>
		/// Represents the suffix. </summary>
		private string suffix_Renamed;

		/// <summary>
		/// Represents the fill. </summary>
		private string fill_Renamed;

		/// <summary>
		/// Represents the starting number. </summary>
		private long? startingNumber_Renamed;

		/// <summary>
		/// Gets the prefix.
		/// </summary>
		/// <returns> the prefix </returns>
		public virtual string prefix
		{
			get
			{
				return prefix_Renamed;
			}
			set
			{
				this.prefix_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the suffix.
		/// </summary>
		/// <returns> the suffix </returns>
		public virtual string suffix
		{
			get
			{
				return suffix_Renamed;
			}
			set
			{
				this.suffix_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the fill.
		/// </summary>
		/// <returns> the fill </returns>
		public virtual string fill
		{
			get
			{
				return fill_Renamed;
			}
			set
			{
				this.fill_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the starting number.
		/// </summary>
		/// <returns> the starting number </returns>
		public virtual long? startingNumber
		{
			get
			{
				return startingNumber_Renamed;
			}
			set
			{
				this.startingNumber_Renamed = value;
			}
		}


	}

}