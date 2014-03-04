namespace com.smartsheet.api.oauth
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
	/// Represents the access scope. These are the scopes that are required to access an end user's smartsheet data and 
	/// specifies the type of operations that are permitted.
	/// </summary>
    public enum AccessScope
    {
        READ_SHEETS, WRITE_SHEETS, SHARE_SHEETS, DELETE_SHEETS, CREATE_SHEETS, ADMIN_SHEETS, ADMIN_WORKSPACES
    }
}