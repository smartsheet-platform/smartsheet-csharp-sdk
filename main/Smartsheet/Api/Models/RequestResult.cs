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

namespace Smartsheet.Api.Models
{
    /// <summary>
    /// RequestResult object to contain information about a PUT or POST request.
    /// </summary>
    public class RequestResult<T>
    {
        /// <summary>
        /// Represents the RequestResult Code from the request. </summary>
        private int? resultCode;

        /// <summary>
        /// Represents the Message from the request. </summary>
        private string message;

        /// <summary>
        /// Represents the object that was created or updated. </summary>
        private T result;

        /// <summary>
        /// Represents the new Version of the sheet. It is only available on some operations. </summary>
        private int? version;

        /// <summary>
        /// Gets the RequestResult Code from the request.
        /// </summary>
        /// <value>
        /// The result code.
        /// </value>
        /// <returns> the RequestResult Code </returns>
        public int? ResultCode
        {
            get { return resultCode; }
            set { resultCode = value; }
        }
        
        /// <summary>
        /// Gets the Message from the request.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        /// <returns> the Message </returns>
        public string Message
        {
            get { return message; }
            set { message = value; }
        }
        
        /// <summary>
        /// Gets the RequestResult from the request.
        /// </summary>
        /// <value>
        /// The result object.
        /// </value>
        /// <returns> the RequestResult </returns>
        public T Result
        {
            get { return result; }
            set { result = value; }
        }

        /// <summary>
        /// Gets the new Version of the sheet. It is only available on some operations..
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        /// <returns> the Version </returns>
        public int? Version
        {
            get { return version; }
            set { version = value; }
        }
    }
}