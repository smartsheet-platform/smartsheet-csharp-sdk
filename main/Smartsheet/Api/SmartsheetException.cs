//    #[license]
//    Smartsheet SDK for C#
//    %%
//    Copyright (C) 2014 Smartsheet
//    %%
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//        
//            http://www.apache.org/licenses/LICENSE-2.0
//        
//    Unless required by applicable law or agreed To in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//    %[license]

using System;

namespace Smartsheet.Api
{



	/// <summary>
	/// <para>This is the base class for all exceptions thrown from the Smartsheet SDK.</para>
	/// 
	/// <para>Thread safety: Exceptions are not thread safe.</para>
	/// </summary>
	public class SmartsheetException : Exception
	{



		/// <summary>
		/// <para>Constructor.</para>
		/// </summary>
		/// <param name="message"> the Message </param>
		public SmartsheetException(string message) : base(message)
		{
		}

		/// <summary>
		/// <para>Constructor.</para>
		/// </summary>
		/// <param name="message"> the Message </param>
		/// <param name="cause"> the cause </param>
		public SmartsheetException(string message, Exception cause) : base(message, cause)
		{
		}

		/// <summary>
		/// <para>Instantiates a new Smartsheet exception.</para>
		/// </summary>
		/// <param name="e"> the exception </param>
		public SmartsheetException(Exception e) : base(e.Message,e)
		{
		}
	}

}