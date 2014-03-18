using System.Collections.Generic;

namespace Smartsheet.Api.Internal
{
	using NUnit.Framework;

	using DefaultHttpClient = Smartsheet.Api.Internal.Http.DefaultHttpClient;
	using Cell = Smartsheet.Api.Models.Cell;
	using Column = Smartsheet.Api.Models.Column;
	using Link = Smartsheet.Api.Models.Link;
	using LinkType = Smartsheet.Api.Models.LinkType;
	using Row = Smartsheet.Api.Models.Row;
	using RowWrapper = Smartsheet.Api.Models.RowWrapper;

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
		public virtual void TestInsertRows()
		{
			server.setResponseBody("../../../TestSDK/resources/insertRows.json");

			// Create a set of cells
			IList<Cell> cells = new List<Cell>();
			Cell cell = new Cell();
			cell.DisplayValue = "Testing";
			cell.ColumnId = 8764071660021636L;
			cell.RowId = 1234L;
			Link link = new Link();
			link.Url = "http://google.com";
			link.Type = LinkType.URL;
			link.SheetId = 1234L;
			link.ColumnId = 1234L;
			link.RowId = 1234L;
			cell.Link = link;
			cell.Formula = "=1+1";

			// Create a row and add the cells to it.
			IList<Row> rows = new List<Row>();
			Row row = new Row();
			row.Cells = cells;
			rows.Add(row);

			// Create a rowWrapper to hold the rows for inserting.
			RowWrapper rowWrapper = new RowWrapper();
			rowWrapper.ToBottom = true;
			rowWrapper.Rows = rows;

			IList<Row> newRows = sheetRowResource.InsertRows(1234L, rowWrapper);

			Assert.NotNull(newRows);
				Assert.AreEqual(rows.Count, newRows.Count, "The number of rows created & inserted is not correct.");
			Column col = new Column();
			col.ID = 8764071660021636L;
			Assert.Null(rows[0].GetColumnByIndex(0));
			Assert.Null(rows[0].GetColumnById(8764071660021636L));
		}

		[Test]
		public virtual void TestGetRow()
		{
			server.setResponseBody("../../../TestSDK/resources/getRow.json");

			Row row = sheetRowResource.GetRow(1234L, 1);

			Assert.NotNull(row);
				Assert.True(1 == row.RowNumber, "Wrong row retrieved.");
		}

	}

}