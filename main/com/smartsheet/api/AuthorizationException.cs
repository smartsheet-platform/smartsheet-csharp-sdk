namespace com.smartsheet.api
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



	using Error = com.smartsheet.api.models.Error;

	/// <summary>
	/// <para>This is the exception to indicate authorization (access token) related errors returned from Smartsheet REST API.</para>
	/// 
	/// <para>Basically this exception will be thrown when the Smartsheet REST API responds with "401 NOT AUTHORIZED" /
	/// "403 FORBIDDEN"</para>
	/// 
	/// <para>Thread safety: Exceptions are not thread safe.</para>
	/// </summary>
	public class AuthorizationException : SmartsheetRestException
	{
		/// 


		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="error"> the Error object from Smartsheet REST API </param>
		public AuthorizationException(Error error) : base(error)
		{
		}
	}

}