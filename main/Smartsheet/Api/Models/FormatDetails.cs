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
	/// Represents the Format details when generating a digital copy (PDF/EXCEL) of a sheet.
	/// </summary>
	public class FormatDetails
	{
		/// <summary>
		/// Represents the paper size.
		/// </summary>
		private PaperSize? paperSize;

		/// <summary>
		/// Gets the paper size.
		/// </summary>
		/// <returns> the paper size </returns>
		public virtual PaperSize? PaperSize
		{
			get
			{
				return paperSize;
			}
			set
			{
				this.paperSize = value;
			}
		}

	}

}