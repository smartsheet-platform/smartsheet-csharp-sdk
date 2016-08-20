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

namespace Smartsheet.Api.Models
{
	public class Duration
	{
		/// <summary>
		/// DURATION
		/// </summary>
		private string objectType;

		/// <summary>
		/// When used as a predecessor’s lag value, indicates whether the lag is negative (if true), or positive (false).
		/// </summary>
		private bool? negative;

		/// <summary>
		/// If true, indicates this duration represents elapsed time, which ignores non-working time.
		/// </summary>
		private bool? elapsed;

		/// <summary>
		/// The number of weeks for this duration.
		/// </summary>
		private int? weeks;

		/// <summary>
		/// The number of days for this duration.
		/// </summary>
		private int? days;

		/// <summary>
		/// The number of hours for this duration.
		/// </summary>
		private int? hours;

		/// <summary>
		/// The number of minutes for this duration.
		/// </summary>
		private int? minutes;

		/// <summary>
		/// The number of seconds for this duration.
		/// </summary>
		private int? seconds;

		/// <summary>
		/// The number of milliseconds for this duration.
		/// </summary>
		private int? milliseconds;

		/// <summary>
		/// Gets the objectType.
		/// </summary>
		/// <returns> DURATION </returns>
		public virtual string ObjectType
		{
			get
			{
				return objectType;
			}
			set
			{
				this.objectType = value;
			}
		}

		/// <summary>
		/// When used as a predecessor’s lag value, indicates whether the lag is negative (if true), or positive (false).
		/// </summary>
		/// <returns> the negative flag </returns>
		public virtual bool? Negative
		{
			get
			{
				return negative;
			}
			set
			{
				this.negative = value;
			}
		}

		/// <summary>
		/// If true, indicates this duration represents elapsed time, which ignores non-working time.
		/// </summary>
		/// <returns> the elapsed flag </returns>
		public virtual bool? Elapsed
		{
			get
			{
				return elapsed;
			}
			set
			{
				this.elapsed = value;
			}
		}

		/// <summary>
		/// The number of weeks for this duration.
		/// </summary>
		/// <returns> the number of weeks in duration </returns>
		public virtual int? Weeks
		{
			get
			{
				return weeks;
			}
			set
			{
				this.weeks = value;
			}
		}

		/// <summary>
		/// The number of days for this duration.
		/// </summary>
		/// <returns> the number of days in duration </returns>
		public virtual int? Days
		{
			get
			{
				return days;
			}
			set
			{
				this.days = value;
			}
		}

		/// <summary>
		/// The number of hours for this duration.
		/// </summary>
		/// <returns> the number of hours in duration </returns>
		public virtual int? Hours
		{
			get
			{
				return hours;
			}
			set
			{
				this.hours = value;
			}
		}

		/// <summary>
		/// The number of minutes for this duration.
		/// </summary>
		/// <returns> the number of minutes in duration </returns>
		public virtual int? Minutes
		{
			get
			{
				return minutes;
			}
			set
			{
				this.minutes = value;
			}
		}

		/// <summary>
		/// The number of seconds for this duration.
		/// </summary>
		/// <returns> the number of seconds in duration </returns>
		public virtual int? Seconds
		{
			get
			{
				return seconds;
			}
			set
			{
				this.seconds = value;
			}
		}

		/// <summary>
		/// The number of milliseconds for this duration.
		/// </summary>
		/// <returns> the number of milliseconds in duration </returns>
		public virtual int? Milliseconds
		{
			get
			{
				return milliseconds;
			}
			set
			{
				this.milliseconds = value;
			}
		}
	}
}
