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
	/// Represents column types.
	/// </summary>
	public enum ColumnType
	{
		/// <summary>
		/// Represents the TEXT_NUMBER column type. </summary>
		TEXT_NUMBER,

		/// <summary>
		/// Represents the PICKLIST column type. </summary>
		PICKLIST,

		/// <summary>
		/// Represents the DATE column type. </summary>
		DATE,

		/// <summary>
		/// Represents the DATETIME (auto number) column type </summary>
		DATETIME,

		/// <summary>
		/// Represents the CONTACT_LIST column type. </summary>
		CONTACT_LIST,

		/// <summary>
		/// Represents the CHECKBOX column type. </summary>
		CHECKBOX
	}

}