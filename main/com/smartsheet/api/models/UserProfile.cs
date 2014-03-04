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
	/// A profile object that contains the basic fields that most profiles will contain.
	/// </summary>
	public class UserProfile : NamedModel
	{
		/// <summary>
		/// Represents the email address.
		/// </summary>
		private string email_Renamed;

		/// <summary>
		/// Represents the first name.
		/// </summary>
		private string firstName_Renamed;

		/// <summary>
		/// Represents the last name.
		/// </summary>
		private string lastName_Renamed;

		/// <summary>
		/// Gets the email address.
		/// </summary>
		/// <returns> the email address </returns>
		public virtual string email
		{
			get
			{
				return email_Renamed;
			}
			set
			{
				this.email_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the first name.
		/// </summary>
		/// <returns> the first name </returns>
		public virtual string firstName
		{
			get
			{
				return firstName_Renamed;
			}
			set
			{
				this.firstName_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the last name.
		/// </summary>
		/// <returns> the last name </returns>
		public virtual string lastName
		{
			get
			{
				return lastName_Renamed;
			}
			set
			{
				this.lastName_Renamed = value;
			}
		}

	}

}