using System;
namespace com.smartsheet.api.models
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
	/// Represents the publish status of a sheet. </summary>
	/// <seealso cref= <a href="http://help.smartsheet.com/customer/portal/articles/522078-publishing-sheets">Help Publishing 
	/// Sheets</a> </seealso>
	public class SheetPublish
	{
		/// <summary>
		/// Represents the read-only lite (static HTML UI) flag.
		/// </summary>
		private bool? readOnlyLiteEnabled_Renamed;

		/// <summary>
		/// Represents the read-only full (fancy UI) flag.
		/// </summary>
		private bool? readOnlyFullEnabled_Renamed;

		/// <summary>
		/// Represents the read-write enabled flag.
		/// </summary>
		private bool? readWriteEnabled_Renamed;

		/// <summary>
		/// Represents the iCal enabled flag.
		/// </summary>
		private bool? icalEnabled_Renamed;

		/// <summary>
		/// Represents the read-only lite (static HTML UI) URL.
		/// </summary>
		private string readOnlyLiteUrl_Renamed;

		/// <summary>
		/// Represents the read-only full URL.
		/// </summary>
		private string readOnlyFullUrl_Renamed;

		/// <summary>
		/// Represents the read-write URL.
		/// </summary>
		private string readWriteUrl_Renamed;

		/// <summary>
		/// Represents the iCal URL.
		/// </summary>
		private string icalUrl_Renamed;

		/// <summary>
		/// Gets the read only lite enabled flag.
		/// </summary>
		/// <returns> the read only lite enabled flag </returns>
		public virtual bool? readOnlyLiteEnabled
		{
			get
			{
				return readOnlyLiteEnabled_Renamed;
			}
			set
			{
				this.readOnlyLiteEnabled_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the read only full (fancy UI) enabled flag.
		/// </summary>
		/// <returns> the read only full enabled flag </returns>
		public virtual bool? readOnlyFullEnabled
		{
			get
			{
				return readOnlyFullEnabled_Renamed;
			}
			set
			{
				this.readOnlyFullEnabled_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the read write enabled flag.
		/// </summary>
		/// <returns> the read write enabled flag </returns>
		public virtual bool? readWriteEnabled
		{
			get
			{
				return readWriteEnabled_Renamed;
			}
			set
			{
				this.readWriteEnabled_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the ical enabled flag.
		/// </summary>
		/// <returns> the ical enabled flag </returns>
		public virtual bool? icalEnabled
		{
			get
			{
				return icalEnabled_Renamed;
			}
			set
			{
				this.icalEnabled_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the read only lite url flag.
		/// </summary>
		/// <returns> the read only lite url flag </returns>
		public virtual string readOnlyLiteUrl
		{
			get
			{
				return readOnlyLiteUrl_Renamed;
			}
			set
			{
				this.readOnlyLiteUrl_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the read only full (fancy UI) url.
		/// </summary>
		/// <returns> the read only full url </returns>
		public virtual string readOnlyFullUrl
		{
			get
			{
				return readOnlyFullUrl_Renamed;
			}
			set
			{
				this.readOnlyFullUrl_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the read write url.
		/// </summary>
		/// <returns> the read write url </returns>
		public virtual string readWriteUrl
		{
			get
			{
				return readWriteUrl_Renamed;
			}
			set
			{
				this.readWriteUrl_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the ical url.
		/// </summary>
		/// <returns> the ical url </returns>
		public virtual string icalUrl
		{
			get
			{
				return icalUrl_Renamed;
			}
			set
			{
				this.icalUrl_Renamed = value;
			}
		}


		/// <summary>
		/// A convenience class for making a <seealso cref="SheetPublish"/> object with the necessary fields to publish a sheet.
		/// </summary>
		public class PublishStatusBuilder
		{
			internal bool? readOnlyLiteEnabled_Renamed;
			internal bool? readOnlyFullEnabled_Renamed;
			internal bool? readWriteEnabled_Renamed;
			internal bool? icalEnabled_Renamed;

			/// <summary>
			/// Read only lite enabled.
			/// </summary>
			/// <param name="readOnlyLiteEnabled"> the read only lite (static html UI) enabled </param>
			/// <returns> the publish status builder </returns>
			public virtual PublishStatusBuilder SetReadOnlyLiteEnabled(bool? readOnlyLiteEnabled)
			{
				this.readOnlyLiteEnabled_Renamed = readOnlyLiteEnabled;
				return this;
			}

			/// <summary>
			/// Read only full (fancy UI) enabled.
			/// </summary>
			/// <param name="readOnlyFullEnabled"> the read only full enabled </param>
			/// <returns> the publish status builder </returns>
			public virtual PublishStatusBuilder SetReadOnlyFullEnabled(bool? readOnlyFullEnabled)
			{
				this.readOnlyFullEnabled_Renamed = readOnlyFullEnabled;
				return this;
			}

			/// <summary>
			/// Read write enabled.
			/// </summary>
			/// <param name="readWriteEnabled"> the read write enabled </param>
			/// <returns> the publish status builder </returns>
			public virtual PublishStatusBuilder SetReadWriteEnabled(bool? readWriteEnabled)
			{
				this.readWriteEnabled_Renamed = readWriteEnabled;
				return this;
			}

			/// <summary>
			/// Ical enabled.
			/// </summary>
			/// <param name="icalEnabled"> the ical enabled </param>
			/// <returns> the publish status builder </returns>
			public virtual PublishStatusBuilder SetIcalEnabled(bool? icalEnabled)
			{
				this.icalEnabled_Renamed = icalEnabled;
				return this;
			}

			/// <summary>
			/// Gets the read only lite enabled.
			/// </summary>
			/// <returns> the read only lite enabled </returns>
			public virtual bool? readOnlyLiteEnabled
			{
				get
				{
					return readOnlyLiteEnabled_Renamed;
				}
			}

			/// <summary>
			/// Gets the read only full enabled.
			/// </summary>
			/// <returns> the read only full enabled </returns>
			public virtual bool? readOnlyFullEnabled
			{
				get
				{
					return readOnlyFullEnabled_Renamed;
				}
			}

			/// <summary>
			/// Gets the read write enabled.
			/// </summary>
			/// <returns> the read write enabled </returns>
			public virtual bool? readWriteEnabled
			{
				get
				{
					return readWriteEnabled_Renamed;
				}
			}

			/// <summary>
			/// Gets the ical enabled.
			/// </summary>
			/// <returns> the ical enabled </returns>
			public virtual bool? icalEnabled
			{
				get
				{
					return icalEnabled_Renamed;
				}
			}

			/// <summary>
			/// Builds the.
			/// </summary>
			/// <returns> the sheet publish </returns>
			public virtual SheetPublish Build()
			{

				if (readOnlyLiteEnabled_Renamed == null || readOnlyFullEnabled_Renamed == null || readWriteEnabled_Renamed == null)
				{
					throw new InvalidOperationException("'Read only lite', 'read only full' and 'read write' must be set to " + "update the publishing status.");
				}

				SheetPublish sheetPublish = new SheetPublish();
				sheetPublish.readOnlyLiteEnabled_Renamed = readOnlyLiteEnabled_Renamed;
				sheetPublish.readOnlyFullEnabled_Renamed = readOnlyFullEnabled_Renamed;
				sheetPublish.readWriteEnabled_Renamed = readWriteEnabled_Renamed;
				sheetPublish.icalEnabled_Renamed = icalEnabled_Renamed;
				return sheetPublish;
			}
		}
	}

}