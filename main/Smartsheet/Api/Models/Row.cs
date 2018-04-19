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
using Smartsheet.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smartsheet.Api.Models
{
	/// <summary>
	/// A Row is a component of a Sheet or Report. Each Row is composed of a collection of Cells, and may optionally contain Discussions and/or Attachments.
	/// </summary>
	public class Row : AbstractRow<Column, Cell>
	{
		// Override Id property so that JSON.NET knows to make an exception of not serialization row Id.
		// So Row Id will be serialized.
		public override long? Id
		{
			get
			{
				return base.Id;
			}
			set
			{
				base.Id = value;
			}
		}

		/// <summary>
		/// A convenience class for creating a Row with the necessary fields for inserting into a list of Rows.
		/// </summary>
		/// <remarks>
		/// If multiple rows are specified in the request,
		/// all rows must be inserted at the same location
		/// (i.e. the toTop, toBottom, parentId, siblingId,
		/// and above attributes must be the same for all rows in the request).
		/// </remarks>
		public class AddRowBuilder
		{
			private bool? toTop;
			private bool? toBottom;
			private long? parentId;
			private long? siblingId;
			private bool? above;
			private string format;
			private bool? expanded;
			private IList<Cell> cells;

			/// <summary>
			/// Sets the required property/properties for Adding a Row
			/// </summary>
			/// <remarks>
			/// If multiple rows are specified in the request,
			/// all rows must be inserted at the same location
			/// (i.e. the toTop, toBottom, parentId, siblingId,
			/// and above attributes must be the same for all rows in the request).
			/// </remarks>
			/// <param name="toTop"> Indicates that the row should be added to the top of the sheet. </param>
			/// <param name="toBottom"> Indicates that the row should be added to the bottom of the sheet, or, if used in conjunction with parentId, added as the last child of the parent. </param>
			/// <param name="parentId"> Indicates that the row should be added as the first child of this row. </param>
			/// <param name="siblingId"> Indicates that the row should be added as the next row at the same hierarchical level of this row. </param>
			/// <param name="above"> Optionally used in conjunction with siblingId with a value of true to indicate that the row should be added above the specified sibling row. </param>
			public AddRowBuilder(bool? toTop, bool? toBottom, long? parentId, long? siblingId, bool? above)
			{
				this.toTop = toTop;
				this.toBottom = toBottom;
				this.parentId = parentId;
				this.siblingId = siblingId;
				this.above = above;
			}


			/// <summary>
			/// Sets the to top flag that puts the row at the top of the sheet.
			/// </summary>
			/// <param name="toTop"> the to top flag </param>
			/// <returns> the add row builder </returns>
			public virtual AddRowBuilder SetToTop(bool? toTop)
			{
				this.toTop = toTop;
				return this;
			}

			/// <summary>
			/// Sets the to bottom flag that puts the row at the bottom of the sheet.
			/// </summary>
			/// <param name="toBottom"> the to bottom </param>
			/// <returns> the add row builder </returns>
			public virtual AddRowBuilder SetToBottom(bool? toBottom)
			{
				this.toBottom = toBottom;
				return this;
			}

			/// <summary>
			/// Sets the parent Id that puts the row as the first child of the specified Id.
			/// </summary>
			/// <param name="parentId"> the parent Id </param>
			/// <returns> the add row builder </returns>
			public virtual AddRowBuilder SetParentId(long? parentId)
			{
				this.parentId = parentId;
				return this;
			}

			/// <summary>
			/// Sets the sibling Id that puts the row as the next row at the same hierarchical level of this row.
			/// </summary>
			/// <param name="siblingId"> the sibling Id </param>
			/// <returns> the add row builder </returns>
			public virtual AddRowBuilder SetSiblingId(long? siblingId)
			{
				this.siblingId = siblingId;
				return this;
			}

			/// <summary>
			/// Sets the flag which which is used in conjunction with siblingId with a value of true to
			/// indicate that the row should be added above the specified sibling row.
			/// </summary>
			/// <param name="above"> the above flag </param>
			/// <returns> the add row builder </returns>
			public virtual AddRowBuilder SetAbove(bool? above)
			{
				this.above = above;
				return this;
			}

			/// <summary>
			/// Sets the cells of the row.
			/// </summary>
			/// <param name="cells"> the cells </param>
			/// <returns> the add row builder </returns>
			public virtual AddRowBuilder SetCells(IList<Cell> cells)
			{
				this.cells = cells;
				return this;
			}

			/// <summary>
			/// Sets the Format.
			/// </summary>
			/// <param name="format"> the format </param>
			/// <returns> the add row builder </returns>
			public virtual AddRowBuilder SetFormat(string format)
			{
				this.format = format;
				return this;
			}

			/// <summary>
			/// Sets if expanded.
			/// </summary>
			/// <param name="expanded"> the expanded </param>
			/// <returns> the add row builder </returns>
			public virtual AddRowBuilder SetExpanded(bool? expanded)
			{
				this.expanded = expanded;
				return this;
			}


			/// <summary>
			/// Gets the to top.
			/// </summary>
			/// <returns> the to top </returns>
			public virtual bool? GetToTop()
			{
				return toTop;
			}

			/// <summary>
			/// Gets the to bottom.
			/// </summary>
			/// <returns> the to bottom </returns>
			public virtual bool? GetToBottom()
			{
				return toBottom;
			}

			/// <summary>
			/// Gets the parent Id.
			/// </summary>
			/// <returns> the parent Id </returns>
			public virtual long? GetParentId()
			{
				return parentId;
			}

			/// <summary>
			/// Gets the sibling Id.
			/// </summary>
			/// <returns> the sibling Id </returns>
			public virtual long? GetSiblingId()
			{
				return siblingId;
			}

			/// <summary>
			/// Gets the cells.
			/// </summary>
			/// <returns> the cells </returns>
			public virtual IList<Cell> GetCells()
			{
				return cells;
			}

			/// <summary>
			/// Gets the above flag.
			/// </summary>
			/// <returns>the above flag</returns>
			public virtual bool? GetAbove()
			{
				return above;
			}

			/// <summary>
			/// Gets the format
			/// </summary>
			/// <returns>the format</returns>
			public virtual string GetFormat()
			{
				return format;
			}

			/// <summary>
			/// Gets the expanded flag.
			/// </summary>
			/// <returns>the expanded flag</returns>
			public virtual bool? GetExpanded()
			{
				return expanded;
			}

			/// <summary>
			/// Builds the Row.
			/// </summary>
			/// <returns>the row</returns>
			public virtual Row Build()
			{
				Row row = new Row
				{
					ToTop = toTop,
					ToBottom = toBottom,
					ParentId = parentId,
					SiblingId = siblingId,
					Above = above,
					Format = format,
					Expanded = expanded,
					Cells = cells
				};
				return row;
			}
		}
		/// <summary>
		/// A convenience class for updating a Row with the necessary fields for inserting into a list of Rows.
		/// </summary>
		public class UpdateRowBuilder
		{
			private bool? toTop;
			private bool? toBottom;
			private long? parentId;
			private long? siblingId;
			private bool? above;
			private int? indent;
			private int? outdent;
			private string format;
			private bool? expanded;
			private IList<Cell> cells;
			private bool? locked;
			private long? id;

			/// <summary>
			/// Sets the required parameters to updating a row.
			/// </summary>
			/// <param name="rowId">the row ID</param>
			public UpdateRowBuilder(long? rowId)
			{
				this.id = rowId;
			}

			/// <summary>
			/// Sets the to top flag that puts the row at the top of the sheet.
			/// </summary>
			/// <param name="toTop"> the to top flag </param>
			/// <returns> the update row builder </returns>
			public virtual UpdateRowBuilder SetToTop(bool? toTop)
			{
				this.toTop = toTop;
				return this;
			}

			/// <summary>
			/// Sets the to bottom flag that puts the row at the bottom of the sheet.
			/// </summary>
			/// <param name="toBottom"> the to bottom </param>
			/// <returns> the update row builder </returns>
			public virtual UpdateRowBuilder SetToBottom(bool? toBottom)
			{
				this.toBottom = toBottom;
				return this;
			}

			/// <summary>
			/// Sets the parent Id that puts the row as the first child of the specified Id.
			/// </summary>
			/// <param name="parentId"> the parent Id </param>
			/// <returns> the update row builder </returns>
			public virtual UpdateRowBuilder SetParentId(long? parentId)
			{
				this.parentId = parentId;
				return this;
			}

			/// <summary>
			/// Sets the sibling Id that puts the row as the next row at the same hierarchical level of this row.
			/// </summary>
			/// <param name="siblingId"> the sibling Id </param>
			/// <returns> the update row builder </returns>
			public virtual UpdateRowBuilder SetSiblingId(long? siblingId)
			{
				this.siblingId = siblingId;
				return this;
			}

			/// <summary>
			/// Sets the above flag two move the Row directly above the specified sibling Row (at the same hierarchical level).
			/// </summary>
			/// <param name="above"> the above flag </param>
			/// <returns> the update row builder </returns>
			public virtual UpdateRowBuilder SetAbove(bool? above)
			{
				this.above = above;
				return this;
			}

			public virtual UpdateRowBuilder SetIndent(int? indent)
			{
				this.indent = indent;
				return this;
			}

			public virtual UpdateRowBuilder SetOutdent(int? outdent)
			{
				this.outdent = outdent;
				return this;
			}

			/// <summary>
			/// Sets the list of cells.
			/// </summary>
			/// <param name="cells"> the list of cells </param>
			/// <returns> the update row builder </returns>
			public virtual UpdateRowBuilder SetCells(IList<Cell> cells)
			{
				this.cells = cells;
				return this;
			}

			/// <summary>
			/// Sets the Format.
			/// </summary>
			/// <param name="format"> the format </param>
			/// <returns> the update row builder </returns>
			public virtual UpdateRowBuilder SetFormat(string format)
			{
				this.format = format;
				return this;
			}

			/// <summary>
			/// Sets if expanded.
			/// </summary>
			/// <param name="expanded"> the expanded </param>
			/// <returns> the update row builder </returns>
			public virtual UpdateRowBuilder SetExpanded(bool? expanded)
			{
				this.expanded = expanded;
				return this;
			}

			/// <summary>
			/// Sets whether row is locked (true) or not (false).
			/// </summary>
			/// <param name="locked"> row locked </param>
			/// <returns> the update row builder </returns>
			public virtual UpdateRowBuilder SetLocked(bool? locked)
			{
				this.locked = locked;
				return this;
			}

			/// <summary>
			/// Gets the to top.
			/// </summary>
			/// <returns> the to top </returns>
			public virtual bool? GetToTop()
			{
				return toTop;
			}

			/// <summary>
			/// Gets the to bottom.
			/// </summary>
			/// <returns> the to bottom </returns>
			public virtual bool? GetToBottom()
			{
				return toBottom;
			}

			/// <summary>
			/// Gets the parent Id.
			/// </summary>
			/// <returns> the parent Id </returns>
			public virtual long? GetParentId()
			{
				return parentId;
			}

			/// <summary>
			/// Gets the sibling Id.
			/// </summary>
			/// <returns> the sibling Id </returns>
			public virtual long? GetSiblingId()
			{
				return siblingId;
			}

			/// <summary>
			/// Gets the cells.
			/// </summary>
			/// <returns> the cells </returns>
			public virtual IList<Cell> GetCells()
			{
				return cells;
			}

			/// <summary>
			/// Gets the format.
			/// </summary>
			/// <returns>the format</returns>
			public virtual string GetFormat()
			{
				return format;
			}

			/// <summary>
			/// Gets the expanded flag.
			/// </summary>
			/// <returns>the expanded flag</returns>
			public virtual bool? GetExpanded()
			{
				return expanded;
			}

			/// <summary>
			/// Gets whether row is locked.
			/// </summary>
			/// <returns> the locked </returns>
			public virtual bool? GetLocked()
			{
				return locked;
			}

			/// <summary>
			/// Gets the row id.
			/// </summary>
			/// <returns> the row id </returns>
			public virtual long? GetId()
			{
				return id;
			}

			/// <summary>
			/// Builds anad returns the Row.
			/// </summary>
			/// <returns> the row </returns>
			public virtual Row Build()
			{
				Row row = new Row
				{
					ToTop = toTop,
					ToBottom = toBottom,
					ParentId = parentId,
					SiblingId = siblingId,
					Above = above,
					Indent = indent,
					Outdent = outdent,
					Locked = locked,
					Format = format,
					Expanded = expanded,
					Cells = cells,
					Id = id
				};
				return row;
			}
		}
	}
}
