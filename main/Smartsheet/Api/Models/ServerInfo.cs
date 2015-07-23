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
using System.Collections.Generic;
namespace Smartsheet.Api.Models
{
	/// <summary>
	/// Represents a Server Infromation Object. </summary>
	public class ServerInfo
	{
		private IList<string> supportedLocales;

		private FeatureInfo featureInfo;

		private FormatTables formats;

		/// <summary>
		/// Array of strings representing all Smartsheet-supported locales.
		/// </summary>
		public IList<string> SupportedLocales
		{
			get { return supportedLocales; }
			set { supportedLocales = value; }
		}

		/// <summary>
		/// Feature Information.
		/// </summary>
		public FeatureInfo FeatureInfo
		{
			get { return featureInfo; }
			set { featureInfo = value; }
		}

		/// <summary>
		/// Definition of format tables that are used in
		/// Column, Row, and Cell format property. For more information, see Formatting.
		/// </summary>
		public FormatTables Formats
		{
			get { return formats; }
			set { formats = value; }
		}
	}
}