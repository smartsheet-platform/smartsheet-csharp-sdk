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
//    Unless required by applicable law or agreed To in writing, software
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
		/// Gets the read only lite enabled flag.
		/// </summary>
		/// <returns> the read only lite enabled flag </returns>
		public virtual bool? ReadOnlyLiteEnabled
		{
			get
			{
				return readOnlyLiteEnabled;
			}
			set
			{
				this.readOnlyLiteEnabled = value;
			}
		}


		/// <summary>
		/// Gets the read only full (fancy UI) enabled flag.
		/// </summary>
		/// <returns> the read only full enabled flag </returns>
		public virtual bool? ReadOnlyFullEnabled
		{
			get
			{
				return readOnlyFullEnabled;
			}
			set
			{
				this.readOnlyFullEnabled = value;
			}
		}


		/// <summary>
		/// Gets the read write enabled flag.
		/// </summary>
		/// <returns> the read write enabled flag </returns>
		public virtual bool? ReadWriteEnabled
		{
			get
			{
				return readWriteEnabled;
			}
			set
			{
				this.readWriteEnabled = value;
			}
		}


		/// <summary>
		/// Gets the ical enabled flag.
		/// </summary>
		/// <returns> the ical enabled flag </returns>
		public virtual bool? IcalEnabled
		{
			get
			{
				return icalEnabled;
			}
			set
			{
				this.icalEnabled = value;
			}
		}


		/// <summary>
		/// Gets the read only lite Url flag.
		/// </summary>
		/// <returns> the read only lite Url flag </returns>
		public virtual string ReadOnlyLiteUrl
		{
			get
			{
				return readOnlyLiteUrl;
			}
			set
			{
				this.readOnlyLiteUrl = value;
			}
		}


		/// <summary>
		/// Gets the read only full (fancy UI) Url.
		/// </summary>
		/// <returns> the read only full Url </returns>
		public virtual string ReadOnlyFullUrl
		{
			get
			{
				return readOnlyFullUrl;
			}
			set
			{
				this.readOnlyFullUrl = value;
			}
		}


		/// <summary>
		/// Gets the read write Url.
		/// </summary>
		/// <returns> the read write Url </returns>
		public virtual string ReadWriteUrl
		{
			get
			{
				return readWriteUrl;
			}
			set
			{
				this.readWriteUrl = value;
			}
		}


		/// <summary>
		/// Gets the ical Url.
		/// </summary>
		/// <returns> the ical Url </returns>
		public virtual string IcalUrl
		{
			get
			{
				return icalUrl;
			}
			set
			{
				this.icalUrl = value;
			}
		}


		/// <summary>
		/// A convenience class for making a <seealso cref="SheetPublish"/> object with the necessary fields To publish a sheet.
		/// </summary>
		public class PublishStatusBuilder
		{
			internal bool? readOnlyLiteEnabled;
			internal bool? readOnlyFullEnabled;
			internal bool? readWriteEnabled;
			internal bool? icalEnabled;

			/// <summary>
			/// Read only lite enabled.
			/// </summary>
			/// <param name="readOnlyLiteEnabled"> the read only lite (static html UI) enabled </param>
			/// <returns> the publish Status builder </returns>
			public virtual PublishStatusBuilder SetReadOnlyLiteEnabled(bool? readOnlyLiteEnabled)
			{
				this.readOnlyLiteEnabled = readOnlyLiteEnabled;
				return this;
			}

			/// <summary>
			/// Read only full (fancy UI) enabled.
			/// </summary>
			/// <param name="readOnlyFullEnabled"> the read only full enabled </param>
			/// <returns> the publish Status builder </returns>
			public virtual PublishStatusBuilder SetReadOnlyFullEnabled(bool? readOnlyFullEnabled)
			{
				this.readOnlyFullEnabled = readOnlyFullEnabled;
				return this;
			}

			/// <summary>
			/// Read write enabled.
			/// </summary>
			/// <param name="readWriteEnabled"> the read write enabled </param>
			/// <returns> the publish Status builder </returns>
			public virtual PublishStatusBuilder SetReadWriteEnabled(bool? readWriteEnabled)
			{
				this.readWriteEnabled = readWriteEnabled;
				return this;
			}

			/// <summary>
			/// Ical enabled.
			/// </summary>
			/// <param name="icalEnabled"> the ical enabled </param>
			/// <returns> the publish Status builder </returns>
			public virtual PublishStatusBuilder SetIcalEnabled(bool? icalEnabled)
			{
				this.icalEnabled = icalEnabled;
				return this;
			}

			/// <summary>
			/// Gets the read only lite enabled.
			/// </summary>
			/// <returns> the read only lite enabled </returns>
			public virtual bool? ReadOnlyLiteEnabled
			{
				get
				{
					return readOnlyLiteEnabled;
				}
			}

			/// <summary>
			/// Gets the read only full enabled.
			/// </summary>
			/// <returns> the read only full enabled </returns>
			public virtual bool? ReadOnlyFullEnabled
			{
				get
				{
					return readOnlyFullEnabled;
				}
			}

			/// <summary>
			/// Gets the read write enabled.
			/// </summary>
			/// <returns> the read write enabled </returns>
			public virtual bool? ReadWriteEnabled
			{
				get
				{
					return readWriteEnabled;
				}
			}

			/// <summary>
			/// Gets the ical enabled.
			/// </summary>
			/// <returns> the ical enabled </returns>
			public virtual bool? IcalEnabled
			{
				get
				{
					return icalEnabled;
				}
			}

			/// <summary>
			/// Builds the.
			/// </summary>
			/// <returns> the sheet publish </returns>
			public virtual SheetPublish Build()
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