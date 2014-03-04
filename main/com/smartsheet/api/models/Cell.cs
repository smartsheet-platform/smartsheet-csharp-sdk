using System.Collections.Generic;

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
	/// Represents the Cell object that holds data in a sheet.
	/// </summary>
	public class Cell
	{

		/// <summary>
		/// Represents the column type.
		/// </summary>
		private ColumnType? type_Renamed;

		/// <summary>
		/// Represents the value.
		/// </summary>
		private string value_Renamed;

		/// <summary>
		/// Represents the display value.
		/// </summary>
		private string displayValue_Renamed;

		/// <summary>
		/// Represents the column ID for this cell.
		/// </summary>
		private long? columnId_Renamed;

		/// <summary>
		/// Represents the row ID for this cell.
		/// </summary>
		private long? rowId_Renamed;

		/// <summary>
		/// Represents the optional link that a cell might have.
		/// </summary>
		private Link link_Renamed;

		/// <summary>
		/// The formula for the cell.
		/// </summary>
		private string formula_Renamed;

		/// <summary>
		/// Represents the strict flag.
		/// </summary>
		private bool? strict_Renamed;

		/// <summary>
		/// Gets the column type.
		/// </summary>
		/// <returns> the type </returns>
		public virtual ColumnType? type
		{
			get
			{
				return type_Renamed;
			}
			set
			{
				this.type_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the value.
		/// </summary>
		/// <returns> the value </returns>
		public virtual string value
		{
			get
			{
				return value_Renamed;
			}
			set
			{
				this.value_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the display value used on special columns such as "Contact List".
		/// </summary>
		/// <returns> the display value </returns>
		public virtual string displayValue
		{
			get
			{
				return displayValue_Renamed;
			}
			set
			{
				this.displayValue_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the column id for this cell.
		/// </summary>
		/// <returns> the column id </returns>
		public virtual long? columnId
		{
			get
			{
				return columnId_Renamed;
			}
			set
			{
				this.columnId_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the row id for this cell.
		/// </summary>
		/// <returns> the row id </returns>
		public virtual long? rowId
		{
			get
			{
				return rowId_Renamed;
			}
			set
			{
				this.rowId_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the link for this cell.
		/// </summary>
		/// <returns> the link </returns>
		public virtual Link link
		{
			get
			{
				return link_Renamed;
			}
			set
			{
				this.link_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the formula for this cell.
		/// </summary>
		/// <returns> the formula </returns>
		public virtual string formula
		{
			get
			{
				return formula_Renamed;
			}
			set
			{
				this.formula_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the strict value for this cell.
		/// </summary>
		/// <seealso cref= <a href="http://www.smartsheet.com/developers/api-documentation#h.lay2yj3x1pp8">Column Types</a> </seealso>
		/// <returns> the strict </returns>
		public virtual bool? strict
		{
			get
			{
				return strict_Renamed;
			}
			set
			{
				this.strict_Renamed = value;
			}
		}


		/// <summary>
		/// A convenience class for quickly creating a List of cells to update.
		/// </summary>
		// TODO: check if default values can be used for any of the builders.
		public class UpdateRowCellsBuilder
		{

			/// <summary>
			/// The cells. </summary>
			internal IList<Cell> cells_Renamed = new List<Cell>();

			/// <summary>
			/// Adds the cell.
			/// </summary>
			/// <param name="columnId"> the column id </param>
			/// <param name="value"> the value </param>
			/// <param name="strict"> the strict </param>
			/// <returns> the update row cells builder </returns>
			public virtual UpdateRowCellsBuilder AddCell(long? columnId, string value, bool? strict)
			{
				Cell cell = new Cell();
				cell.columnId = columnId;
				cell.value = value;
				cell.strict = strict;
				cells_Renamed.Add(cell);
				return this;
			}

			public virtual IList<Cell> cells
			{
				get
				{
					return cells_Renamed;
				}
			}

			/// <summary>
			/// Adds the cell.
			/// </summary>
			/// <param name="columnId"> the column id </param>
			/// <param name="value"> the value </param>
			/// <returns> the update row cells builder </returns>
			public virtual UpdateRowCellsBuilder AddCell(long? columnId, string value)
			{
				AddCell(columnId, value, true);
				return this;
			}

			/// <summary>
			/// Returns the list of cells.
			/// </summary>
			/// <returns> the list </returns>
			public virtual IList<Cell> Build()
			{
				return cells_Renamed;
			}
		}
	}

}