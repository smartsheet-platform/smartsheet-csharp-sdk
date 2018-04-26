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

using System.Collections.Generic;

namespace Smartsheet.Api.Models
{
    /// <summary>
    /// Represents an Email object.
    /// </summary>
    public abstract class Email
    {
        /// <summary>
        /// Represents the Email recipient(s).
        /// </summary>
        private IList<Recipient> sendTo;

        /// <summary>
        /// Represents the Subject.
        /// </summary>
        private string subject;

        /// <summary>
        /// Represents the Message.
        /// </summary>
        private string message;

        /// <summary>
        /// Represents the CC me flag.
        /// </summary>
        private bool? ccMe;

        /// <summary>
        /// Gets the list of Recipients
        /// </summary>
        /// <returns> the list of Recipients </returns>
        public IList<Recipient> SendTo
        {
            get { return sendTo; }
            set { sendTo = value; }
        }

        /// <summary>
        /// Gets the Subject.
        /// </summary>
        /// <returns> the Subject </returns>
        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }

        /// <summary>
        /// Gets the Message.
        /// </summary>
        /// <returns> the Message </returns>
        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        /// <summary>
        /// Gets the carbon copy me flag.
        /// </summary>
        /// <returns> the cc me </returns>
        public bool? CcMe
        {
            get { return ccMe; }
            set { ccMe = value; }
        }
    }
}