using System.Collections.Generic;

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
	/// Represents an Email object.
	/// </summary>
	public abstract class Email
	{
		/// <summary>
		/// Represents the email recipient(s).
		/// </summary>
		private IList<string> to_Renamed;

		/// <summary>
		/// Represents the subject.
		/// </summary>
		private string subject_Renamed;

		/// <summary>
		/// Represents the message.
		/// </summary>
		private string message_Renamed;

		/// <summary>
		/// Represents the CC me flag.
		/// </summary>
		private bool? ccMe_Renamed;

		/// <summary>
		/// Gets the to.
		/// </summary>
		/// <returns> the to </returns>
		public virtual IList<string> to
		{
			get
			{
				return to_Renamed;
			}
			set
			{
				this.to_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the subject.
		/// </summary>
		/// <returns> the subject </returns>
		public virtual string subject
		{
			get
			{
				return subject_Renamed;
			}
			set
			{
				this.subject_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the message.
		/// </summary>
		/// <returns> the message </returns>
		public virtual string message
		{
			get
			{
				return message_Renamed;
			}
			set
			{
				this.message_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the carbon copy me flag.
		/// </summary>
		/// <returns> the cc me </returns>
		public virtual bool? ccMe
		{
			get
			{
				return ccMe_Renamed;
			}
			set
			{
				this.ccMe_Renamed = value;
			}
		}



	}

}