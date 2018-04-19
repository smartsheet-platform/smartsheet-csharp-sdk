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
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//    %[license]

using System.Collections.Generic;

namespace Smartsheet.Api.Models
{
	/// <summary>
	/// The FormatTables object is retrieved via the GET /serverinfo operation and contains all of the lookup tables
	/// that the Format Descriptor indexes refer to, as well as a property called defaults, which is
	/// a Format Descriptor that describes which formats the Smartsheet web application displays for unset formats.</summary>
	public class FormatTables
	{
		private string defaults;

		private IList<FontFamily> fontFamily;

		private IList<string> fontSize;

		private IList<string> bold;

		private IList<string> italic;

		private IList<string> underline;

		private IList<string> strikethrough;

		private IList<string> horizontalAlign;

		private IList<string> verticalAlign;

		private IList<string> color;

		private IList<Currency> currency;

		private IList<string> decimalCount;

		private IList<string> thousandsSeparator;

		private IList<string> numberFormat;

		private IList<string> textWrap;

		/// <summary>
		/// A format descriptor where each element describes the formats
		/// the Smartsheet web application displays for format values that have not been set.
		/// </summary>
		public string Defaults
		{
			get { return defaults; }
			set { defaults = value; }
		}

		/// <summary>
		/// Font families with additional font information
		/// </summary>
		public IList<FontFamily> FontFamily
		{
			get { return fontFamily; }
			set { fontFamily = value; }
		}

		/// <summary>
		/// Font sizes in points
		/// </summary>
		public IList<string> FontSize
		{
			get { return fontSize; }
			set { fontSize = value; }
		}

		/// <summary>
		/// Possible values: none, on.
		/// </summary>
		public IList<string> Bold
		{
			get { return bold; }
			set { bold = value; }
		}

		/// <summary>
		/// Possible values: none, on.
		/// </summary>
		public IList<string> Italic
		{
			get { return italic; }
			set { italic = value; }
		}

		/// <summary>
		/// Possible values: none, on.
		/// </summary>
		public IList<string> Underline
		{
			get { return underline; }
			set { underline = value; }
		}

		/// <summary>
		/// Possible values: none, on.
		/// </summary>
		public IList<string> Strikethrough
		{
			get { return strikethrough; }
			set { strikethrough = value; }
		}

		/// <summary>
		/// Possible values: none, on.
		/// </summary>
		public IList<string> HorizontalAlign
		{
			get { return horizontalAlign; }
			set { horizontalAlign = value; }
		}

		/// <summary>
		/// Vertical alignment, possible values:
		/// none, middle, bottom.
		/// Note: “default” is the default value, which is equivalent to “top”.
		/// </summary>
		public IList<string> VerticalAlign
		{
			get { return verticalAlign; }
			set { verticalAlign = value; }
		}

		/// <summary>
		/// Color hex values. 
		/// <para>Note: “none” is the default value for all colors. Applications will need
		/// to handle this value and use app-defined colors (typically this is Black for
		/// text color and White for background color)</para>
		/// </summary>
		public IList<string> Color
		{
			get { return color; }
			set { color = value; }
		}

		/// <summary>
		/// Currency codes and symbols
		/// </summary>
		public IList<Currency> Currency
		{
			get { return currency; }
			set { currency = value; }
		}

		/// <summary>
		/// All allowed decimal count values
		/// </summary>
		public IList<string> DecimalCount
		{
			get { return decimalCount; }
			set { decimalCount = value; }
		}

		/// <summary>
		/// Possible values: none, on
		/// </summary>
		public IList<string> ThousandsSeparator
		{
			get { return thousandsSeparator; }
			set { thousandsSeparator = value; }
		}

		/// <summary>
		/// Possible values: none, NUMBER, CURRENCY, PERCENT.
		/// </summary>
		public IList<string> NumberFormat
		{
			get { return numberFormat; }
			set { numberFormat = value; }
		}

		/// <summary>
		/// Possible values: none, on
		/// </summary>
		public IList<string> TextWrap
		{
			get { return textWrap; }
			set { textWrap = value; }
		}
	}
}
