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

using System.Collections.Generic;

namespace Smartsheet.Api.Models
{

	/// <summary>
	/// Represents the Cell object that holds data in a sheet.
	/// </summary>
	public class Cell
	{

		/// <summary>
		/// Represents the column Type.
		/// </summary>
		private ColumnType? columnType;

		/// <summary>
		/// Represents the Value.
		/// </summary>
		private object value;

		/// <summary>
		/// Represents the display Value.
		/// </summary>
		private string displayValue;

		/// <summary>
		/// Represents the column ID for this cell.
		/// </summary>
		private long? columnId;

		/// <summary>
		/// Represents the row ID for this cell.
		/// </summary>
		private long? rowId;

		/// <summary>
		/// Represents a hyperlink to a URL, sheet, or report.
		/// </summary>
		private Link hyperlink;

		/// <summary>
		/// The Formula for the cell.
		/// </summary>
		private string formula;

		/// <summary>
		/// Represents the Strict flag.
		/// </summary>
		private bool? strict;

		private CellLink linkInFromCell;

		private IList<CellLink> linksOutToCells;

		private string format;

		private string conditionalFormat;

		/// <summary>
		/// The image that the cell contains. Only returned if the cell contains an image
		/// </summary>
		private Image image;

		/// <summary>
		/// An array of CellLink objects. Zero or more outbound links from this cell to cells in other sheets whose values mirror this cell's value.
		/// </summary>
		private IList<CellLink> LinksOutToCells
		{
			get { return linksOutToCells; }
			set { linksOutToCells = value; }
		}

		/// <summary>
		/// An inbound link from a cell in another sheet. This cell's value mirrors the linked cell's value.
		/// </summary>
		public CellLink LinkInFromCell
		{
			get { return linkInFromCell; }
			set { linkInFromCell = value; }
		}

		/// <summary>
		/// <para>
		/// The format descriptor
		/// </para>
		/// <para>
		/// Only returned if the include query string parameter contains format and this cell has a non-default format applied.
		/// </para>
		/// </summary>
		public string Format
		{
			get { return format; }
			set { format = value; }
		}

		/// <summary>
		/// <para>
		/// The format descriptor describing this cell's conditional format
		/// </para>
		/// <para>
		/// Only returned if the include query string parameter contains format and this cell has a conditional format applied.
		/// </para>
		/// </summary>
		public string ConditionalFormat
		{
			get { return conditionalFormat; }
			set { conditionalFormat = value; }
		}

		/// <summary>
		/// Gets the column Type.
		/// </summary>
		/// <returns> the Type </returns>
		public virtual ColumnType? ColumnType
		{
			get
			{
				return columnType;
			}
			set
			{
				this.columnType = value;
			}
		}


		/// <summary>
		/// Gets the Value.
		/// </summary>
		/// <returns> the Value </returns>
		public virtual object Value
		{
			get
			{
				return value;
			}
			set
			{
				this.value = value;
			}
		}


		/// <summary>
		/// Gets the display Value used on special Columns such as "Contact List".
		/// </summary>
		/// <returns> the display Value </returns>
		public virtual string DisplayValue
		{
			get
			{
				return displayValue;
			}
			set
			{
				this.displayValue = value;
			}
		}


		/// <summary>
		/// Gets the column Id for this cell.
		/// </summary>
		/// <returns> the column Id </returns>
		public virtual long? ColumnId
		{
			get
			{
				return columnId;
			}
			set
			{
				this.columnId = value;
			}
		}


		/// <summary>
		/// Gets the row Id for this cell.
		/// </summary>
		/// <returns> the row Id </returns>
		public virtual long? RowId
		{
			get
			{
				return rowId;
			}
			set
			{
				this.rowId = value;
			}
		}


		/// <summary>
		/// A hyperlink to a URL, sheet, or report
		/// </summary>
		/// <returns> the Link </returns>
		public virtual Link Hyperlink
		{
			get
			{
				return hyperlink;
			}
			set
			{
				this.hyperlink = value;
			}
		}


		/// <summary>
		/// Gets the Formula for this cell.
		/// </summary>
		/// <returns> the Formula </returns>
		public virtual string Formula
		{
			get
			{
				return formula;
			}
			set
			{
				this.formula = value;
			}
		}


		/// <summary>
		/// Gets the Strict Value for this cell.
		/// </summary>
		/// <seealso href="http://www.Smartsheet.com/developers/Api-documentation#h.lay2yj3x1pp8">Column Types</seealso>
		/// <returns> the Strict </returns>
		public virtual bool? Strict
		{
			get
			{
				return strict;
			}
			set
			{
				this.strict = value;
			}
		}

		/// <summary>
		/// Gets the Strict Value for this cell.
		/// </summary>
		/// <seealso href="http://www.Smartsheet.com/developers/Api-documentation#h.lay2yj3x1pp8">Column Types</seealso>
		/// <returns> the Strict </returns>
		public virtual Image Image
		{
			get
			{
				return image;
			}
			set
			{
				this.image = value;
			}
		}

		///// <summary>
		///// A convenience class for quickly creating a List of Cells To update.
		///// </summary>
		//public class UpdateRowCellsBuilder
		//{

		//	/// <summary>
		//	/// The Cells. </summary>
		//	internal IList<Cell> cells = new List<Cell>();

		//	/// <summary>
		//	/// Adds the cell.
		//	/// </summary>
		//	/// <param name="columnId"> the column Id </param>
		//	/// <param name="value"> the Value </param>
		//	/// <param name="strict"> the Strict </param>
		//	/// <returns> the update row Cells builder </returns>
		//	public virtual UpdateRowCellsBuilder AddCell(long? columnId, object value, bool? strict)
		//	{
		//		Cell cell = new Cell();
		//		cell.columnId = columnId;
		//		cell.value = value;
		//		cell.strict = strict;
		//		cells.Add(cell);
		//		return this;
		//	}

		//	/// <summary>
		//	/// Gets the cells.
		//	/// </summary>
		//	/// <value>
		//	/// The cells.
		//	/// </value>
		//	public virtual IList<Cell> Cells
		//	{
		//		get
		//		{
		//			return cells;
		//		}
		//	}

		//	/// <summary>
		//	/// Adds the cell.
		//	/// </summary>
		//	/// <param name="columnId"> the column Id </param>
		//	/// <param name="value"> the Value </param>
		//	/// <returns> the update row Cells builder </returns>
		//	public virtual UpdateRowCellsBuilder AddCell(long? columnId, object value)
		//	{
		//		AddCell(columnId, value, true);
		//		return this;
		//	}

		//	/// <summary>
		//	/// Returns the list of Cells.
		//	/// </summary>
		//	/// <returns> the list </returns>
		//	public virtual IList<Cell> Build()
		//	{
		//		return cells;
		//	}
		//}

		/// <summary>
		/// A convenience class for adding a Cell with the necessary fields for inserting into a list of Cells.
		/// </summary>
		public class AddCellBuilder
		{
			private long? columnId;

			private object value;

			private bool? strict;

			private string format;

			private Link hyperlink;

			/// <summary>
			/// Set required properties.
			/// </summary>
			/// <param name="columnId">the column Id</param>
			/// <param name="value">the value of the cell</param>
			public AddCellBuilder(long? columnId, object value)
			{
				this.columnId = columnId;
				this.value = value;
			}

			/// <summary>
			/// Sets the Column Id
			/// </summary>
			/// <param name="columnId">the column Id</param>
			/// <returns>this AddCellBuilder</returns>
			public virtual AddCellBuilder SetColumnId(long? columnId)
			{
				this.columnId = columnId;
				return this;
			}


			/// <summary>
			/// Sets the cell value
			/// </summary>
			/// <param name="value">the value</param>
			/// <returns>this AddCellBuilder</returns>
			public virtual AddCellBuilder SetValue(object value)
			{
				this.value = value;
				return this;
			}


			/// <summary>
			/// Sets whether cells is strict or not.
			/// </summary>
			/// <param name="strict">the strict option</param>
			/// <returns>this AddCellBuilder</returns>
			public virtual AddCellBuilder SetStrict(bool? strict)
			{
				this.strict = strict;
				return this;
			}


			/// <summary>
			/// Sets the format.
			/// </summary>
			/// <param name="format">the format</param>
			/// <returns>this AddCellBuilder</returns>
			public virtual AddCellBuilder SetFormat(string format)
			{
				this.format = format;
				return this;
			}


			/// <summary>
			/// Sets the hyperlink.
			/// </summary>
			/// <param name="hyperlink">the hyperlink</param>
			/// <returns> this AddCellBuilder </returns>
			public virtual AddCellBuilder SetHyperlink(Link hyperlink)
			{
				this.hyperlink = hyperlink;
				return this;
			}

			/// <summary>
			/// Gets the column Id.
			/// </summary>
			/// <returns>the column id</returns>
			public virtual long? GetColumnId()
			{
				return columnId;
			}

			/// <summary>
			/// Gets the Value.
			/// </summary>
			/// <returns>the value</returns>
			public virtual object GetValue()
			{
				return value;
			}

			/// <summary>
			/// Gets the Strict option.
			/// </summary>
			/// <returns>the strict option</returns>
			public virtual bool? GetStrict()
			{
				return strict;
			}

			/// <summary>
			/// Gets the Format.
			/// </summary>
			/// <returns>the format</returns>
			public virtual string GetFormat()
			{
				return format;
			}


			/// <summary>
			/// Gets the Hyperlink.
			/// </summary>
			/// <returns>the hyperlink</returns>
			public virtual Link GetHyperlink()
			{
				return hyperlink;
			}

			/// <summary>
			/// Builds and returns the Cell object.
			/// </summary>
			/// <returns>Cell object</returns>
			public virtual Cell Build()
			{
				Cell cell = new Cell();
				cell.ColumnId = columnId;
				cell.Value = value;
				cell.Strict = strict;
				cell.Format = format;
				cell.Hyperlink = hyperlink;
				return cell;
			}
		}

		/// <summary>
		/// A convenience class for updating a Cell with the necessary fields for inserting into a list of Cells.
		/// </summary>
		public class UpdateCellBuilder
		{
			private long? columnId;

			private object value;

			private bool? strict;

			private string format;

			private Link hyperlink;

			private CellLink linkInFromCell;

			/// <summary>
			/// Set required properties.
			/// </summary>
			/// <param name="columnId">required</param>
			/// <param name="value">required</param>
			public UpdateCellBuilder(long? columnId, object value)
			{
				this.columnId = columnId;
				this.value = value;
			}

			/// <summary>
			/// Sets the Column Id
			/// </summary>
			/// <param name="columnId">columnId</param>
			/// <returns>this UpdateCellBuilder</returns>
			public virtual UpdateCellBuilder SetColumnId(long? columnId)
			{
				this.columnId = columnId;
				return this;
			}

			/// <summary>
			/// Sets the value.
			/// </summary>
			/// <param name="value">(required)</param>
			/// <returns>this UpdateCellBuilder</returns>
			public virtual UpdateCellBuilder SetValue(object value)
			{
				this.value = value;
				return this;
			}

			/// <summary>
			/// Sets the strict.
			/// </summary>
			/// <param name="strict">(optional)</param>
			/// <returns>this UpdateCellBuilder</returns>
			public virtual UpdateCellBuilder SetStrict(bool? strict)
			{
				this.strict = strict;
				return this;
			}

			/// <summary>
			/// Sets the format.
			/// </summary>
			/// <param name="format">(optional)</param>
			/// <returns>this UpdateCellBuilder</returns>
			public virtual UpdateCellBuilder SetFormat(string format)
			{
				this.format = format;
				return this;
			}

			/// <summary>
			/// (optional) with exactly one of the following attributes set:
			/// <list type="bullet">
			/// <item>url</item>
			/// <item>sheetId</item>
			/// <item>reportId</item>
			/// </list>
			/// </summary>
			/// <param name="hyperlink"> Link object </param>
			/// <returns> this UpdateCellBuilder </returns>
			public virtual UpdateCellBuilder SetHyperlink(Link hyperlink)
			{
				this.hyperlink = hyperlink;
				return this;
			}

			/// <summary>
			/// (optional) with all of the following attributes set:
			/// <list type="bullet">
			/// <item>sheetId</item>
			/// <item>rowId</item>
			/// <item>columnId</item>
			/// </list>
			/// </summary>
			/// <param name="linkInFromCell"> CellLink object </param>
			/// <returns> this UpdateCellBuilder </returns>
			public virtual UpdateCellBuilder SetLinkInFromCell(CellLink linkInFromCell)
			{
				this.linkInFromCell = linkInFromCell;
				return this;
			}

			/// <summary>
			/// Gets the Column Id.
			/// </summary>
			/// <returns>the column Id.</returns>
			public virtual long? GetColumnId()
			{
				return columnId;
			}

			/// <summary>
			/// Gets the value.
			/// </summary>
			/// <returns>the value.</returns>
			public virtual object GetValue()
			{
				return value;
			}

			/// <summary>
			/// Gets the Strict.
			/// </summary>
			/// <returns>
			/// the strict.
			/// </returns>
			public virtual bool? GetStrict()
			{
				return strict;
			}

			/// <summary>
			/// Gets the Format.
			/// </summary>
			/// <returns>the format</returns>
			public virtual string GetFormat()
			{
				return format;
			}

			/// <summary>
			/// Gets the HyperLink
			/// </summary>
			/// <returns>the hyperlink</returns>
			public virtual Link GetHyperlink()
			{
				return hyperlink;
			}

			/// <summary>
			/// Gets Link In From Cell.
			/// </summary>
			/// <returns>the link in from cell</returns>
			public virtual CellLink GetLinkInFromCell()
			{
				return linkInFromCell;
			}

			/// <summary>
			/// Builds and returns the Cell object.
			/// </summary>
			/// <returns>Cell object</returns>
			public virtual Cell Build()
			{
				Cell cell = new Cell();
				cell.ColumnId = columnId;
				cell.Value = value;
				cell.Strict = strict;
				cell.Format = format;
				cell.Hyperlink = hyperlink;
				cell.LinkInFromCell = linkInFromCell;
				return cell;
			}
		}
	}
}