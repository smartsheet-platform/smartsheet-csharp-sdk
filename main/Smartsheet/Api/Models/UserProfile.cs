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
	/// <summary>
	/// A user profile object.
	/// </summary>
	public class UserProfile : UserModel
	{
		private string timeZone;

		private string locale;

		private Account account;

		/// <summary>
		/// Current user’s time zone ID
		/// </summary>
		public string TimeZone
		{
			get { return timeZone; }
			set { timeZone = value; }
		}

		/// <summary>
		/// Current user’s locale (see Server Information)
		/// </summary>
		public string Locale
		{
			get { return locale; }
			set { locale = value; }
		}

		/// <summary>
		/// Account object representing the current user’s customer account
		/// </summary>
		public Account Account
		{
			get { return account; }
			set { account = value; }
		}
	}
}