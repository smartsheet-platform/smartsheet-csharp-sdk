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
	/// Represents access levels that users can have. </summary>
	/// <seealso cref= <a href="http://www.smartsheet.com/developers/api-documentation#h.umfgm4xt25dq">Access Level Help</a> </seealso>
	public enum AccessLevel
	{
		VIEWER,
		EDITOR,
		EDITOR_SHARE,
		ADMIN,
		OWNER
	}

}