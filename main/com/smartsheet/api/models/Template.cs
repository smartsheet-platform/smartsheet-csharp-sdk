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
	/// A template object that is a default layout for future sheets. </summary>
	/// <seealso cref= <a href="http://help.smartsheet.com/customer/portal/articles/522123-using-templates">Using Templates Help</a> </seealso>
	public class Template : NamedModel
	{
		/// <summary>
		/// Represents the description for the template.
		/// </summary>
		private string description_Renamed;

		/// <summary>
		/// Represents the access level for the template.
		/// </summary>
		private AccessLevel? accessLevel_Renamed;


		/// <summary>
		/// Gets the description of the template.
		/// </summary>
		/// <returns> the description </returns>
		public virtual string description
		{
			get
			{
				return description_Renamed;
			}
			set
			{
				this.description_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the access level of the template.
		/// </summary>
		/// <returns> the access level </returns>
		public virtual AccessLevel? accessLevel
		{
			get
			{
				return accessLevel_Renamed;
			}
			set
			{
				this.accessLevel_Renamed = value;
			}
		}

	}

}