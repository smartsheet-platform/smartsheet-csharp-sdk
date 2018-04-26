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
    /// Represents Sheet Email object used for sending a sheet by Email. </summary>
    /// <seealso href="http://help.Smartsheet.com/customer/portal/articles/504773-sending-Sheets-Rows-via-Email">Help Sending
    /// Sheets &amp; Rows via Email</seealso>
    public class SheetEmail : Email
    {
        /// <summary>
        /// Represents the sheet Email Format (PDF or Excel).
        /// </summary>
        private SheetEmailFormat? format;

        /// <summary>
        /// Represents the Format details (paper dimensions).
        /// </summary>
        private FormatDetails formatDetails;

        /// <summary>
        /// Gets the sheet Email Format (PDF or Excel).
        /// </summary>
        /// <returns> the Format </returns>
        public SheetEmailFormat? Format
        {
            get { return format; }
            set { this.format = value; }
        }
        
        /// <summary>
        /// Gets the Format details (paper dimensions).
        /// </summary>
        /// <returns> the Format details </returns>
        public FormatDetails FormatDetails
        {
            get { return formatDetails; }
            set { this.formatDetails = value; }
        }

        /// <summary>
        /// A convenience class for creating a SheetEmail object with the necessary fields.
        /// </summary>
        public class CreateSheetEmail
        {
            /// <summary>
            /// Represents the sheet Email Format (PDF or Excel).
            /// </summary>
            private SheetEmailFormat? format;

            /// <summary>
            /// Represents the Format details (paper dimensions).
            /// </summary>
            private FormatDetails formatDetails;

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
            /// Sets the required properties for creating a SheetEmail.
            /// </summary>
            /// <param name="sendTo"></param>
            /// <param name="format"></param>
            public CreateSheetEmail(IList<Recipient> sendTo, SheetEmailFormat? format)
            {
                this.sendTo = sendTo;
                this.format = format;
            }

            /// <summary>
            /// Sets the subject of the SheetEmail.
            /// </summary>
            /// <param name="subject">the subject</param>
            /// <returns>this CreateSheetEmail object</returns>
            public CreateSheetEmail SetSubject(string subject)
            {
                this.subject = subject;
                return this;
            }

            /// <summary>
            /// Sets the message of the SheetEmail.
            /// </summary>
            /// <param name="message">the message</param>
            /// <returns>this CreateSheetEmail object</returns>
            public CreateSheetEmail SetMessage(string message)
            {
                this.message = message;
                return this;
            }

            /// <summary>
            /// Sets whether to ccMe.
            /// </summary>
            /// <param name="ccMe">the ccMe option</param>
            /// <returns>this CreateSheetEmail object</returns>
            public CreateSheetEmail SetCcMe(bool? ccMe)
            {
                this.ccMe = ccMe;
                return this;
            }

            /// <summary>
            /// Sets the format details of the SheetEmail.
            /// </summary>
            /// <param name="formatDetails">the format details</param>
            /// <returns>this CreateSheetEmail object</returns>
            public CreateSheetEmail SetFormatDetails(FormatDetails formatDetails)
            {
                this.formatDetails = formatDetails;
                return this;
            }

            /// <summary>
            /// Creates and returns the SheetEmail object.
            /// </summary>
            /// <returns>the SheetEmail object</returns>
            public SheetEmail Build()
            {
                return new SheetEmail
                {
                    SendTo = sendTo,
                    Format = format,
                    FormatDetails = formatDetails,
                    Subject = subject,
                    Message = message,
                    CcMe = ccMe
                };
            }
        }
    }
}