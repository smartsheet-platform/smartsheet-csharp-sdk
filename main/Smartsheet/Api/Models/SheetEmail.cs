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
		public virtual SheetEmailFormat? Format
		{
			get
			{
				return format;
			}
			set
			{
				this.format = value;
			}
		}


		/// <summary>
		/// Gets the Format details (paper dimensions).
		/// </summary>
		/// <returns> the Format details </returns>
		public virtual FormatDetails FormatDetails
		{
			get
			{
				return formatDetails;
			}
			set
			{
				this.formatDetails = value;
			}
		}



	}

}