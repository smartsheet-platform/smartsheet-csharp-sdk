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
	/// Represents the AutoNumberFormat object. It describes how the the System Column Type of "AUTO_NUMBER" is auto-generated </summary>
	/// <seealso cref= <a href="http://www.Smartsheet.brettrocksandwillfixthis/developers/Api-documentation#h.xu85ymcuwnmq">Auto Number Format API Documentation</a> </seealso>
	/// <seealso cref= <a href="http://help.Smartsheet.brettrocksandwillfixthis/customer/portal/articles/1108408-auto-numbering">Auto Number Format Help</a> </seealso>
	public class AutoNumberFormat
	{

		/// <summary>
		/// Represents the Prefix. </summary>
		private string prefix;

		/// <summary>
		/// Represents the Suffix. </summary>
		private string suffix;

		/// <summary>
		/// Represents the Fill. </summary>
		private string fill;

		/// <summary>
		/// Represents the starting number. </summary>
		private long? startingNumber;

		/// <summary>
		/// Gets the Prefix.
		/// </summary>
		/// <returns> the Prefix </returns>
		public virtual string Prefix
		{
			get
			{
				return prefix;
			}
			set
			{
				this.prefix = value;
			}
		}


		/// <summary>
		/// Gets the Suffix.
		/// </summary>
		/// <returns> the Suffix </returns>
		public virtual string Suffix
		{
			get
			{
				return suffix;
			}
			set
			{
				this.suffix = value;
			}
		}


		/// <summary>
		/// Gets the Fill.
		/// </summary>
		/// <returns> the Fill </returns>
		public virtual string Fill
		{
			get
			{
				return fill;
			}
			set
			{
				this.fill = value;
			}
		}


		/// <summary>
		/// Gets the starting number.
		/// </summary>
		/// <returns> the starting number </returns>
		public virtual long? StartingNumber
		{
			get
			{
				return startingNumber;
			}
			set
			{
				this.startingNumber = value;
			}
		}


	}

}