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
namespace Smartsheet.Api.Models
{
    /// <summary>
    /// Represents the publish Status of a sheet. </summary>
    /// <seealso href="http://help.Smartsheet.com/customer/portal/articles/522078-publishing-Sheets">Help Publishing 
    /// Sheets</seealso>
    public class SheetPublish
    {
        /// <summary>
        /// Represents the read-only lite (static HTML UI) flag.
        /// </summary>
        private bool? readOnlyLiteEnabled;

        /// <summary>
        /// Represents the read-only full (fancy UI) flag.
        /// </summary>
        private bool? readOnlyFullEnabled;

        /// <summary>
        /// Represents the read-write enabled flag.
        /// </summary>
        private bool? readWriteEnabled;

        /// <summary>
        /// Represents the iCal enabled flag.
        /// </summary>
        private bool? icalEnabled;

        /// <summary>
        /// Flag to indicate who can access the 'Read-Only Full’ view of the published sheet:
        ///        If “ALL”, it is available to anyone who has the link.
        ///        If “ORG”, it is available only to members of the sheet owner’s Smartsheet organization.
        /// </summary>
        private string readOnlyFullAccessibleBy;

        /// <summary>
        /// Flag to indicate who can access the 'Edit by Anyone’ view of the published sheet:
        ///        If “ALL”, it is available to anyone who has the link.
        ///        If “ORG”, it is available only to members of the sheet owner’s Smartsheet organization.
        /// </summary>
        private string readWriteAccessibleBy;

        /// <summary>
        /// Represents the read-only lite (static HTML UI) URL.
        /// </summary>
        private string readOnlyLiteUrl;

        /// <summary>
        /// Represents the read-only full URL.
        /// </summary>
        private string readOnlyFullUrl;

        /// <summary>
        /// Represents the read-write URL.
        /// </summary>
        private string readWriteUrl;

        /// <summary>
        /// Represents the iCal URL.
        /// </summary>
        private string icalUrl;

        /// <summary>
        /// Flag to show or hide the left nav toolbar for the read only sheet.
        /// </summary>
        private bool? readOnlyFullShowToolbar;

        /// <summary>
        /// Flag to show or hide the left nav toolbar for the read/write sheet.
        /// </summary>
        private bool? readWriteShowToolbar;

        /// <summary>
        /// Default view for read only published sheet. (GRID, CARDS, CALENDAR)
        /// </summary>
        private string readOnlyFullDefaultView;

        /// <summary>
        /// Default view for read write published sheet. (GRID, CARDS, CALENDAR)
        /// </summary>
        private string readWriteDefaultView;

        /// <summary>
        /// Gets the read only lite enabled flag.
        /// </summary>
        /// <returns> the read only lite enabled flag </returns>
        public bool? ReadOnlyLiteEnabled
        {
            get { return readOnlyLiteEnabled; }
            set { readOnlyLiteEnabled = value; }
        }

        /// <summary>
        /// Gets the read only full (fancy UI) enabled flag.
        /// </summary>
        /// <returns> the read only full enabled flag </returns>
        public bool? ReadOnlyFullEnabled
        {
            get { return readOnlyFullEnabled; }
            set { readOnlyFullEnabled = value; }
        }
        
        /// <summary>
        /// Gets the read write enabled flag.
        /// </summary>
        /// <returns> the read write enabled flag </returns>
        public bool? ReadWriteEnabled
        {
            get { return readWriteEnabled; }
            set { readWriteEnabled = value; }
        }
        
        /// <summary>
        /// Gets the ical enabled flag.
        /// </summary>
        /// <returns> the ical enabled flag </returns>
        public bool? IcalEnabled
        {
            get { return icalEnabled; }
            set { icalEnabled = value; }
        }
        
        /// <summary>
        /// Flag to indicate who can access the 'Read-Only Full’ view of the published sheet.
        /// </summary>
        /// <returns> the access flag </returns>
        public string ReadOnlyFullAccessibleBy
        {
            get { return readOnlyFullAccessibleBy; }
            set { readOnlyFullAccessibleBy = value; }
        }
        
        /// <summary>
        /// Flag to indicate who can access the 'Edit by Anyone’ view of the published sheet.
        /// </summary>
        /// <returns> the access flag </returns>
        public string ReadWriteAccessibleBy
        {
            get { return readWriteAccessibleBy; }
            set { readWriteAccessibleBy = value; }
        }

        /// <summary>
        /// Gets the read only lite Url flag.
        /// </summary>
        /// <returns> the read only lite Url flag </returns>
        public string ReadOnlyLiteUrl
        {
            get { return readOnlyLiteUrl; }
            set { readOnlyLiteUrl = value; }
        }
        
        /// <summary>
        /// Gets the read only full (fancy UI) Url.
        /// </summary>
        /// <returns> the read only full Url </returns>
        public string ReadOnlyFullUrl
        {
            get { return readOnlyFullUrl; }
            set { readOnlyFullUrl = value;    }
        }
        
        /// <summary>
        /// Gets the read write Url.
        /// </summary>
        /// <returns> the read write Url </returns>
        public string ReadWriteUrl
        {
            get { return readWriteUrl; }
            set { readWriteUrl = value; }
        }
        
        /// <summary>
        /// Gets the ical Url.
        /// </summary>
        /// <returns> the ical Url </returns>
        public string IcalUrl
        {
            get { return icalUrl; }
            set { icalUrl = value; }
        }
        
        /// <summary>
        /// Get the read only full show toolbar flag
        /// </summary>
        /// <returns> the flag </returns>
        public bool? ReadOnlyFullShowToolbar
        {
            get { return readOnlyFullShowToolbar; }
            set { readOnlyFullShowToolbar = value; }
        }
                
        /// <summary>
        /// Get the read/write show toolbar flag
        /// </summary>
        public bool? ReadWriteShowToolbar
        {
            get { return readWriteShowToolbar; }
            set { readWriteShowToolbar = value; }
        }
                
        /// <summary>
        /// Get the read only full default view
        /// </summary>
        /// <returns> Valid options are "GRID", "CARDS", "CALENDAR" </returns>
        public string ReadOnlyFullDefaultView
        {
            get { return readOnlyFullDefaultView; }
            set { readOnlyFullDefaultView = value; }
        }
        
        /// <summary>
        /// Get the read write default view
        /// </summary>
        /// <returns> Valid options are "GRID", "CARDS", "CALENDAR" </returns>
        public string ReadWriteDefaultView
        {
            get { return readWriteDefaultView; }
            set { readWriteDefaultView = value; }
        }
        
        /// <summary>
        /// A convenience class for making a <seealso cref="SheetPublish"/> object with the necessary fields to publish a sheet.
        /// </summary>
        public class PublishStatusBuilder
        {
            private bool? readOnlyLiteEnabled;
            private bool? readOnlyFullEnabled;
            private bool? readWriteEnabled;
            private bool? icalEnabled;

            /// <summary>
            /// Sets the required properties to publish a Sheet
            /// </summary>
            /// <param name="readOnlyLiteEnabled"> Status of Read-Only HTML </param>
            /// <param name="readOnlyFullEnabled"> Status of Read-Only Full </param>
            /// <param name="readWriteEnabled"> Status of Edit by Anyone </param>
            /// <param name="icalEnabled"> Status of iCal </param>
            public PublishStatusBuilder(bool? readOnlyLiteEnabled, bool? readOnlyFullEnabled, bool? readWriteEnabled, bool? icalEnabled)
            {
                this.readOnlyLiteEnabled = readOnlyLiteEnabled;
                this.readOnlyFullEnabled = readOnlyFullEnabled;
                this.readWriteEnabled = readWriteEnabled;
                this.icalEnabled = icalEnabled;
            }

            /// <summary>
            /// Read only lite enabled.
            /// </summary>
            /// <param name="readOnlyLiteEnabled"> the read only lite (static html UI) enabled </param>
            /// <returns> the publish Status builder </returns>
            public PublishStatusBuilder SetReadOnlyLiteEnabled(bool? readOnlyLiteEnabled)
            {
                this.readOnlyLiteEnabled = readOnlyLiteEnabled;
                return this;
            }

            /// <summary>
            /// Read only full (fancy UI) enabled.
            /// </summary>
            /// <param name="readOnlyFullEnabled"> the read only full enabled </param>
            /// <returns> the publish Status builder </returns>
            public PublishStatusBuilder SetReadOnlyFullEnabled(bool? readOnlyFullEnabled)
            {
                this.readOnlyFullEnabled = readOnlyFullEnabled;
                return this;
            }

            /// <summary>
            /// Read write enabled.
            /// </summary>
            /// <param name="readWriteEnabled"> the read write enabled </param>
            /// <returns> the publish Status builder </returns>
            public PublishStatusBuilder SetReadWriteEnabled(bool? readWriteEnabled)
            {
                this.readWriteEnabled = readWriteEnabled;
                return this;
            }

            /// <summary>
            /// Ical enabled.
            /// </summary>
            /// <param name="icalEnabled"> the ical enabled </param>
            /// <returns> the publish Status builder </returns>
            public PublishStatusBuilder SetIcalEnabled(bool? icalEnabled)
            {
                this.icalEnabled = icalEnabled;
                return this;
            }

            /// <summary>
            /// Gets the read only lite enabled.
            /// </summary>
            /// <returns> the read only lite enabled </returns>
            public bool? ReadOnlyLiteEnabled
            {
                get { return readOnlyLiteEnabled; }
            }

            /// <summary>
            /// Gets the read only full enabled.
            /// </summary>
            /// <returns> the read only full enabled </returns>
            public bool? ReadOnlyFullEnabled
            {
                get { return readOnlyFullEnabled; }
            }

            /// <summary>
            /// Gets the read write enabled.
            /// </summary>
            /// <returns> the read write enabled </returns>
            public bool? ReadWriteEnabled
            {
                get { return readWriteEnabled; }
            }

            /// <summary>
            /// Gets the ical enabled.
            /// </summary>
            /// <returns> the ical enabled </returns>
            public bool? IcalEnabled
            {
                get { return icalEnabled; }
            }

            /// <summary>
            /// Builds the.
            /// </summary>
            /// <returns> the sheet publish </returns>
            public SheetPublish Build()
            {

                if (readOnlyLiteEnabled == null || readOnlyFullEnabled == null || readWriteEnabled == null)
                {
                    throw new InvalidOperationException("'Read only lite', 'read only full' and 'read write' must be set to " + "update the publishing status.");
                }

                SheetPublish sheetPublish = new SheetPublish();
                sheetPublish.readOnlyLiteEnabled = readOnlyLiteEnabled;
                sheetPublish.readOnlyFullEnabled = readOnlyFullEnabled;
                sheetPublish.readWriteEnabled = readWriteEnabled;
                sheetPublish.icalEnabled = icalEnabled;
                return sheetPublish;
            }
        }
    }
}