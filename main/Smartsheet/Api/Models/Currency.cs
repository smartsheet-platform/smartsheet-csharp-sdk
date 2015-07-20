﻿//    #[license]
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
using System.Collections.Generic;

namespace Smartsheet.Api.Models
{
	/// <summary>
	/// The Currency info
	/// </summary>
	public class Currency
	{
		private string code;

		private string symbol;

		/// <summary>
		/// The ISO 4217 currency code (e.g. “EUR”)
		/// </summary>
		public string Code
		{
			get { return code; }
			set { code = value; }
		}

		/// <summary>
		/// The currency symbol (e.g. “€”)
		/// </summary>
		public string Symbol
		{
			get { return symbol; }
			set { symbol = value; }
		}
	}
}