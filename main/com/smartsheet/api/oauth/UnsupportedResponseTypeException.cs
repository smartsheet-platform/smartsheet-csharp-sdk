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
	/// <para>This is the exception thrown by <seealso cref="OAuthFlow"/> to indicate "unsupported_response_type" error occurred when obtaining
	/// an authorization code.</para>
	/// 
	/// <para>Thread safety: Exceptions are not thread safe.</para>
	/// </summary>
	public class UnsupportedResponseTypeException : OAuthAuthorizationCodeException
	{
		/// 


		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="message"> the message </param>
		public UnsupportedResponseTypeException(string message) : base(message)
		{
		}
	}

}