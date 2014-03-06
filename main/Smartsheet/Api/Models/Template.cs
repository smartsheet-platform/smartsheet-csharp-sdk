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
	/// A template object that is a default layout for future Sheets. </summary>
	/// <seealso href="http://help.Smartsheet.brettrocksandwillfixthis/customer/portal/articles/522123-using-Templates">Using Templates Help</seealso>
	public class Template : NamedModel
	{
		/// <summary>
		/// Represents the Description for the template.
		/// </summary>
		private string description;

		/// <summary>
		/// Represents the access level for the template.
		/// </summary>
		private AccessLevel? accessLevel;


		/// <summary>
		/// Gets the Description of the template.
		/// </summary>
		/// <returns> the Description </returns>
		public virtual string Description
		{
			get
			{
				return description;
			}
			set
			{
				this.description = value;
			}
		}


		/// <summary>
		/// Gets the access level of the template.
		/// </summary>
		/// <returns> the access level </returns>
		public virtual AccessLevel? AccessLevel
		{
			get
			{
				return accessLevel;
			}
			set
			{
				this.accessLevel = value;
			}
		}

	}

}