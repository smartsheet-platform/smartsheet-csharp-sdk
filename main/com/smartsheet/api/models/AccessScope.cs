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
	/// Represents the type of access that is granted on a given sheet. </summary>
	/// <seealso cref= <a href="http://www.smartsheet.com/developers/api-documentation#h.89hb3ivv7eum">Access Scopes Help</a> </seealso>
	public enum AccessScope
	{
		READ_SHEETS,
		WRITE_SHEETS,
		SHARE_SHEETS,
		DELETE_SHEETS,
		CREATE_SHEETS,
		ADMIN_USERS,
		ADMIN_SHEETS,
		ADMIN_WORKSPACES
	}

}