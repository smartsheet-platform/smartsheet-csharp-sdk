//    #[license]
//    Smartsheet SDK for C#
//    %%
//    Copyright (C) 2014 Smartsheet
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


	/// <summary>
	/// A profile object that contains the basic fields that most profiles will contain.
	/// </summary>
	public class UserProfile : NamedModel
	{
		/// <summary>
		/// Represents the Email address.
		/// </summary>
		private string email;

		/// <summary>
		/// Represents the first Name.
		/// </summary>
		private string firstName;

		/// <summary>
		/// Represents the last Name.
		/// </summary>
		private string lastName;

		/// <summary>
		/// Gets the Email address.
		/// </summary>
		/// <returns> the Email address </returns>
		public virtual string Email
		{
			get
			{
				return email;
			}
			set
			{
				this.email = value;
			}
		}


		/// <summary>
		/// Gets the first Name.
		/// </summary>
		/// <returns> the first Name </returns>
		public virtual string FirstName
		{
			get
			{
				return firstName;
			}
			set
			{
				this.firstName = value;
			}
		}


		/// <summary>
		/// Gets the last Name.
		/// </summary>
		/// <returns> the last Name </returns>
		public virtual string LastName
		{
			get
			{
				return lastName;
			}
			set
			{
				this.lastName = value;
			}
		}

	}

}