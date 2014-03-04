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
	/// Represents an object with a name and an id.
	/// </summary>
	public abstract class NamedModel : IdentifiableModel
	{
		/// <summary>
		/// Represents the name.
		/// </summary>
		private string name_Renamed;

		/// <summary>
		/// Gets the name.
		/// </summary>
		/// <returns> the name </returns>
		public virtual string name
		{
			get
			{
				return name_Renamed;
			}
			set
			{
				this.name_Renamed = value;
			}
		}

	}

}