using System.Collections.Generic;

namespace Smartsheet.Api.Models
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
	 * Unless required by applicable law or agreed To in writing, software
	 * distributed under the License is distributed on an "AS IS" BASIS,
	 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
	 * See the License for the specific language governing permissions and
	 * limitations under the License.
	 * %[license]
	 */

	/// <summary>
	/// Represents the Cell object that holds data in a sheet.
	/// </summary>
	public class Cell
	{

		/// <summary>
		/// Represents the column Type.
		/// </summary>
		private ColumnType? type;

		/// <summary>
		/// Represents the Value.
		/// </summary>
		private string value;

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
		/// Represents the optional Link that a cell might have.
		/// </summary>
		private Link link;

		/// <summary>
		/// The Formula for the cell.
		/// </summary>
		private string formula;

		/// <summary>
		/// Represents the Strict flag.
		/// </summary>
		private bool? strict;

		/// <summary>
		/// Gets the column Type.
		/// </summary>
		/// <returns> the Type </returns>
		public virtual ColumnType? Type
		{
			get
			{
				return type;
			}
			set
			{
				this.type = value;
			}
		}


		/// <summary>
		/// Gets the Value.
		/// </summary>
		/// <returns> the Value </returns>
		public virtual string Value
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
		/// Gets the Link for this cell.
		/// </summary>
		/// <returns> the Link </returns>
		public virtual Link Link
		{
			get
			{
				return link;
			}
			set
			{
				this.link = value;
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
		/// <seealso href="http://www.Smartsheet.brettrocksandwillfixthis/developers/Api-documentation#h.lay2yj3x1pp8">Column Types</seealso>
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
		/// A convenience class for quickly creating a List of Cells To update.
		/// </summary>
		// TODO: check if default values can be used for any of the builders.
		public class UpdateRowCellsBuilder
		{

			/// <summary>
			/// The Cells. </summary>
			internal IList<Cell> cells = new List<Cell>();

			/// <summary>
			/// Adds the cell.
			/// </summary>
			/// <param name="columnId"> the column Id </param>
			/// <param name="value"> the Value </param>
			/// <param name="strict"> the Strict </param>
			/// <returns> the update row Cells builder </returns>
			public virtual UpdateRowCellsBuilder AddCell(long? columnId, string value, bool? strict)
			{
				Cell cell = new Cell();
				cell.columnId = columnId;
				cell.value = value;
				cell.strict = strict;
				cells.Add(cell);
				return this;
			}

            /// <summary>
            /// Gets the cells.
            /// </summary>
            /// <value>
            /// The cells.
            /// </value>
			public virtual IList<Cell> Cells
			{
				get
				{
					return cells;
				}
			}

			/// <summary>
			/// Adds the cell.
			/// </summary>
			/// <param name="columnId"> the column Id </param>
			/// <param name="value"> the Value </param>
			/// <returns> the update row Cells builder </returns>
			public virtual UpdateRowCellsBuilder AddCell(long? columnId, string value)
			{
				AddCell(columnId, value, true);
				return this;
			}

			/// <summary>
			/// Returns the list of Cells.
			/// </summary>
			/// <returns> the list </returns>
			public virtual IList<Cell> Build()
			{
				return cells;
			}
		}
	}

}