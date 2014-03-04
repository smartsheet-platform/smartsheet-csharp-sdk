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
	/// Represents the system column types. </summary>
	/// <seealso cref= <a href="http://help.smartsheet.com/customer/portal/articles/504619-column-types">Column Types Help</a> </seealso>
	public enum SystemColumnType
	{
		/// <summary>
		/// Represents the AUTO_NUMBER system column type.
		/// </summary>
		AUTO_NUMBER,

		/// <summary>
		/// Represents the MODIFIED_DATE system column type.
		/// </summary>
		MODIFIED_DATE,

		/// <summary>
		/// Represents the MODIFIED_BY system column type.
		/// </summary>
		MODIFIED_BY,

		/// <summary>
		/// Represents the CREATED_DATE system column type.
		/// </summary>
		CREATED_DATE,

		/// <summary>
		/// Represents the CREATED_BY system column type.
		/// </summary>
		CREATED_BY


	}

}