using System;
using System.Collections.Generic;
using System.Configuration;

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
	/// Represents the RowWrapper object that is used to specify the location for a <seealso cref="Row"/> or set of Rows.
	/// </summary>
	public class RowWrapper
	{
		/// <summary>
		/// Represents to-top flag that puts the row at the top of the sheet.
		/// </summary>
		private bool? toTop_Renamed;

		/// <summary>
		/// Represents to-bottom flag that puts the row at the bottom of the sheet.
		/// </summary>
		private bool? toBottom_Renamed;

		/// <summary>
		/// Represents the parent ID that puts the row as the first child of the specified id.
		/// </summary>
		private long? parentId_Renamed;

		/// <summary>
		/// Represents the sibling ID that puts the row as the next row at the same hierarchical level of this row.
		/// </summary>
		private long? siblingId_Renamed;

		/// <summary>
		/// Represents the rows.
		/// </summary>
		private IList<Row> rows_Renamed;

		/// <summary>
		/// Gets the to top flag that puts the row at the top of the sheet.
		/// </summary>
		/// <returns> the to top </returns>
		public virtual bool? toTop
		{
			get
			{
				return toTop_Renamed;
			}
			set
			{
				this.toTop_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the to bottom flag that puts the row at the bottom of the sheet.
		/// </summary>
		/// <returns> the to bottom </returns>
		public virtual bool? toBottom
		{
			get
			{
				return toBottom_Renamed;
			}
			set
			{
				this.toBottom_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the parent id that puts the row as the first child of the specified id.
		/// </summary>
		/// <returns> the parent id </returns>
		public virtual long? parentId
		{
			get
			{
				return parentId_Renamed;
			}
			set
			{
				this.parentId_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the sibling id that puts the row as the next row at the same hierarchical level of this row.
		/// </summary>
		/// <returns> the sibling id </returns>
		public virtual long? siblingId
		{
			get
			{
				return siblingId_Renamed;
			}
			set
			{
				this.siblingId_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the rows.
		/// </summary>
		/// <returns> the rows </returns>
		public virtual IList<Row> rows
		{
			get
			{
				return rows_Renamed;
			}
			set
			{
				this.rows_Renamed = value;
			}
		}


		/// <summary>
		/// A convenience class for creating a <seealso cref="RowWrapper"/> with the necessary fields for inserting a <seealso cref="Row"/> or 
		/// set of rows.
		/// </summary>
		public class InsertRowsBuilder
		{
			internal bool? toTop_Renamed;
			internal bool? toBottom_Renamed;
			internal long? parentId_Renamed;
			internal long? siblingId_Renamed;
			internal IList<Row> rows_Renamed;

			/// <summary>
			/// Sets the to top flag that puts the row at the top of the sheet.
			/// </summary>
			/// <param name="toTop"> the to top flag </param>
			/// <returns> the insert rows builder </returns>
			public virtual InsertRowsBuilder SetToTop(bool? toTop)
			{
				this.toTop_Renamed = toTop;
				return this;
			}

			/// <summary>
			/// Sets the to bottom flag that puts the row at the bottom of the sheet.
			/// </summary>
			/// <param name="toBottom"> the to bottom </param>
			/// <returns> the insert rows builder </returns>
			public virtual InsertRowsBuilder SetToBottom(bool? toBottom)
			{
				this.toBottom_Renamed = toBottom;
				return this;
			}

			/// <summary>
			/// Sets the parent id that puts the row as the first child of the specified id.
			/// </summary>
			/// <param name="parentId"> the parent id </param>
			/// <returns> the insert rows builder </returns>
			public virtual InsertRowsBuilder SetParentId(long? parentId)
			{
				this.parentId_Renamed = parentId;
				return this;
			}

			/// <summary>
			/// Sets the sibling id that puts the row as the next row at the same hierarchical level of this row.
			/// </summary>
			/// <param name="siblingId"> the sibling id </param>
			/// <returns> the insert rows builder </returns>
			public virtual InsertRowsBuilder SetSiblingId(long? siblingId)
			{
				this.siblingId_Renamed = siblingId;
				return this;
			}

			/// <summary>
			/// Sets the rows.
			/// </summary>
			/// <param name="rows"> the rows </param>
			/// <returns> the insert rows builder </returns>
			public virtual InsertRowsBuilder SetRows(IList<Row> rows)
			{
				this.rows_Renamed = rows;
				return this;
			}



			/// <summary>
			/// Gets the to top.
			/// </summary>
			/// <returns> the to top </returns>
			public virtual bool? toTop
			{
				get
				{
					return toTop_Renamed;
				}
			}

			/// <summary>
			/// Gets the to bottom.
			/// </summary>
			/// <returns> the to bottom </returns>
			public virtual bool? toBottom
			{
				get
				{
					return toBottom_Renamed;
				}
			}

			/// <summary>
			/// Gets the parent id.
			/// </summary>
			/// <returns> the parent id </returns>
			public virtual long? parentId
			{
				get
				{
					return parentId_Renamed;
				}
			}

			/// <summary>
			/// Gets the sibling id.
			/// </summary>
			/// <returns> the sibling id </returns>
			public virtual long? siblingId
			{
				get
				{
					return siblingId_Renamed;
				}
			}

			/// <summary>
			/// Gets the rows.
			/// </summary>
			/// <returns> the rows </returns>
			public virtual IList<Row> rows
			{
				get
				{
					return rows_Renamed;
				}
			}

			/// <summary>
			/// Builds the RowWrapper.
			/// </summary>
			/// <returns> the row wrapper </returns>
			public virtual RowWrapper Build()
			{
				if (toTop_Renamed == null && toBottom_Renamed == null && parentId_Renamed == null && siblingId_Renamed == null)
				{
					new MemberAccessException("One of the following fields must be set toTop, toBottom, parentId or" + " sibling Id");
				}

				RowWrapper rowWrapper = new RowWrapper();
				rowWrapper.toTop_Renamed = toTop_Renamed;
				rowWrapper.toBottom_Renamed = toBottom_Renamed;
				rowWrapper.parentId_Renamed = parentId_Renamed;
				rowWrapper.siblingId_Renamed = siblingId_Renamed;
				rowWrapper.rows_Renamed = rows_Renamed;
				return rowWrapper;
			}
		}

		/// <summary>
		/// A convenience class for creating a <seealso cref="RowWrapper"/> with the necessary fields for moving a <seealso cref="Row"/> or set 
		/// of rows.
		/// </summary>
		public class MoveRowBuilder
		{
			internal bool? toTop_Renamed;
			internal bool? toBottom_Renamed;
			internal long? parentId_Renamed;
			internal long? siblingId_Renamed;

			/// <summary>
			/// Sets the to top flag that puts the row at the top of the sheet.
			/// </summary>
			/// <param name="toTop"> the to top </param>
			/// <returns> the move row builder </returns>
			public virtual MoveRowBuilder SetToTop(bool? toTop)
			{
				this.toTop_Renamed = toTop;
				return this;
			}

			/// <summary>
			/// Sets the to bottom flag that puts the row at the bottom of the sheet.
			/// </summary>
			/// <param name="toBottom"> the to bottom </param>
			/// <returns> the move row builder </returns>
			public virtual MoveRowBuilder SetToBottom(bool? toBottom)
			{
				this.toBottom_Renamed = toBottom;
				return this;
			}

			/// <summary>
			/// Sets the parent id that puts the row as the first child of the specified id.
			/// </summary>
			/// <param name="parentId"> the parent id </param>
			/// <returns> the move row builder </returns>
			public virtual MoveRowBuilder SetParentId(long? parentId)
			{
				this.parentId_Renamed = parentId;
				return this;
			}

			/// <summary>
			/// Sets the sibling id that puts the row as the next row at the same hierarchical level of this row.
			/// </summary>
			/// <param name="siblingId"> the sibling id </param>
			/// <returns> the move row builder </returns>
			public virtual MoveRowBuilder SetSiblingId(long? siblingId)
			{
				this.siblingId_Renamed = siblingId;
				return this;
			}

			/// <summary>
			/// Gets the to top.
			/// </summary>
			/// <returns> the to top </returns>
			public virtual bool? toTop
			{
				get
				{
					return toTop_Renamed;
				}
			}

			/// <summary>
			/// Gets the to bottom.
			/// </summary>
			/// <returns> the to bottom </returns>
			public virtual bool? toBottom
			{
				get
				{
					return toBottom_Renamed;
				}
			}

			/// <summary>
			/// Gets the parent id.
			/// </summary>
			/// <returns> the parent id </returns>
			public virtual long? parentId
			{
				get
				{
					return parentId_Renamed;
				}
			}

			/// <summary>
			/// Gets the sibling id.
			/// </summary>
			/// <returns> the sibling id </returns>
			public virtual long? siblingId
			{
				get
				{
					return siblingId_Renamed;
				}
			}

			/// <summary>
			/// Builds the RowWrapper.
			/// </summary>
			/// <returns> the row wrapper </returns>
			public virtual RowWrapper Build()
			{
				if (toTop_Renamed == null && toBottom_Renamed == null && parentId_Renamed == null && siblingId_Renamed == null)
				{
					throw new InvalidOperationException("One of the following must be defined to move a row: toTop, "+
                        "toBottom, parentId, siblingId.");
				}

				RowWrapper rowWrapper = new RowWrapper();
				rowWrapper.toTop_Renamed = toTop_Renamed;
				rowWrapper.toBottom_Renamed = toBottom_Renamed;
				rowWrapper.parentId_Renamed = parentId_Renamed;
				rowWrapper.siblingId_Renamed = siblingId_Renamed;
				return rowWrapper;
			}
		}
	}

}