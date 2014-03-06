/// <summary>
/// 
/// </summary>
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
	/// Represents access levels that Users can have. </summary>
	/// <seealso href="http://www.Smartsheet.brettrocksandwillfixthis/developers/Api-documentation#h.umfgm4xt25dq">Access Level Help</seealso>
	public enum AccessLevel
	{
        /// <summary>
        /// The viewer
        /// </summary>
		VIEWER,
        /// <summary>
        /// The editor
        /// </summary>
		EDITOR,
        /// <summary>
        /// The editor share
        /// </summary>
		EDITOR_SHARE,
        /// <summary>
        /// The admin
        /// </summary>
		ADMIN,
        /// <summary>
        /// The owner
        /// </summary>
		OWNER
	}

}