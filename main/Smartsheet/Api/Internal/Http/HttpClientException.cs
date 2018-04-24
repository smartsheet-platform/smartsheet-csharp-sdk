//    #[license]
//    SmartsheetClient SDK for C#
//    %%
//    Copyright (C) 2014 SmartsheetClient
//    %%
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//        
//            http://www.apache.org/licenses/LICENSE-2.0
//        
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//    %[license]

using System;

namespace Smartsheet.Api.Internal.Http
{


    /// <summary>
    /// This is the exception throw by HttpClient to indicate errors occurred during HTTP operation.
    /// 
    /// Thread safety: Exceptions are not thread safe.
    /// </summary>
    public class HttpClientException : SmartsheetException
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message"> the Message </param>
        public HttpClientException(string message) : base(message)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message"> the Message </param>
        /// <param name="cause"> the cause </param>
        public HttpClientException(string message, Exception cause) : base(message, cause)
        {
        }
    }

}