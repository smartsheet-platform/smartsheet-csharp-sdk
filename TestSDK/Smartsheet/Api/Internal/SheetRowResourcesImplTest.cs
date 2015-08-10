using System.Collections.Generic;

namespace Smartsheet.Api.Internal
{
	using NUnit.Framework;
	using DefaultHttpClient = Smartsheet.Api.Internal.Http.DefaultHttpClient;
	using Api.Models;
	using System;

	public class SheetRowResourcesImplTest : ResourcesImplBase
	{

		private SheetRowResourcesImpl sheetRowResource;

		[SetUp]
		public virtual void SetUp()
		{
			sheetRowResource = new SheetRowResourcesImpl(new SmartsheetImpl("http://localhost:9090/1.1/", "accessToken", new DefaultHttpClient(), serializer));
		}

		[Test]
		public virtual void TestSheetRowResourcesImpl()
		{
		}

		[Test]
		public virtual void TestAddRows()
		{
			server.setResponseBody("../../../TestSDK/resources/addRows.json");

			// Create a set of cells
			IList<Cell> cells = new List<Cell>();
			Cell cell = new Cell.AddCellBuilder(123, "lala").SetStrict(true).Build();
			cells.Add(cell);

			// Create a row and add the cells to it.
			IList<Row> rows = new List<Row>
			{
				new Row.AddRowBuilder(true, null, null, null, null).SetCells(cells).Build(),
				new Row.AddRowBuilder(null, null, 123, null, null).SetFormat("A").Build()
			};

			IList<Row> newRows = sheetRowResource.AddRows(2331373580117892L, rows);

			Assert.NotNull(newRows);
			Assert.AreEqual(2, newRows.Count, "The number of rows created & inserted is not correct.");
			Assert.AreEqual(2331373580117892, newRows[1].SheetId);

			Column col = new Column();
			col.Id = 8764071660021636L;
			Assert.Null(rows[0].GetColumnByIndex(0));
			Assert.Null(rows[0].GetColumnById(8764071660021636L));
		}

		[Test]
		public virtual void TestGetRow()
		{
			server.setResponseBody("../../../TestSDK/resources/getRow.json");

			Row row = sheetRowResource.GetRow(1, 1, null, null);
			Assert.AreEqual(row.Expanded, true);
			Assert.NotNull(row);
			Assert.True(1 == row.RowNumber, "Wrong row retrieved.");
		}

		public virtual void TestCopyRowsToAnotherSheet()
		{
			server.setResponseBody("../../../TestSDK/resources/copyOrMoveRowResult.json");

			CopyOrMoveRowDirective directive = new CopyOrMoveRowDirective() { RowIds = new List<long> { 147258369, 963852741 }, To = new CopyOrMoveRowDestination() { SheetId = 123 } };
			CopyOrMoveRowResult row = sheetRowResource.CopyRowsToAnotherSheet(123, directive, null, true);
			Assert.NotNull(row);
			Assert.AreEqual(row.RowMappings[0].From, 145417762563972);
		}

		[Test]
		public virtual void TestMoveRowsToAnotherSheet()
		{
			server.setResponseBody("../../../TestSDK/resources/copyOrMoveRowResult.json");

			CopyOrMoveRowDirective directive = new CopyOrMoveRowDirective() { RowIds = new List<long> { 147258369, 963852741 }, To = new CopyOrMoveRowDestination() { SheetId = 123 } };
			CopyOrMoveRowResult row = sheetRowResource.MoveRowsToAnotherSheet(123, directive, null, true);
			Assert.NotNull(row);
			Assert.AreEqual(row.RowMappings[1].To, 2256565987239812);
		}


		[Test]
		public virtual void TestUpdateRows()
		{
			server.setResponseBody("../../../TestSDK/resources/updateRows.json");

			Cell cell1 = new Cell.UpdateCellBuilder(117, true).Build();
			Cell cell2 = new Cell.UpdateCellBuilder(343, 99999999).Build();
			IList<Cell> cells = new List<Cell> { cell1, cell2 };

			Row row = new Row.UpdateRowBuilder(65654654).SetLocked(true).SetExpanded(true).SetCells(cells).Build();
			Row row2 = new Row.UpdateRowBuilder(4554684).SetToBottom(true).SetExpanded(false).Build();

			IList<Row> rows = sheetRowResource.UpdateRows(123, new List<Row> { row, row2 });

			Assert.AreEqual(rows[1].ParentRowNumber, 1);
			Assert.AreEqual(rows[1].ParentId, 4624744004773764);
			Assert.AreEqual(rows[1].Expanded, true);
			Assert.AreEqual(rows[1].CreatedAt.Value.ToString(), DateTime.Parse("2015-01-09T11:41:55-08:00").ToString());
			Assert.AreEqual(rows[1].Cells[1].ColumnType, ColumnType.PICKLIST);
			Assert.AreEqual(rows[1].Cells[1].Value, rows[1].Cells[1].DisplayValue);
		}
	}
}