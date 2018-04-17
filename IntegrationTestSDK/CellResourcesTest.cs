using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smartsheet.Api;
using Smartsheet.Api.Models;
using System.Collections.Generic;
using System.Configuration;

namespace IntegrationTestSDK
{
	[TestClass]
	public class CellResourcesTest
	{
		[TestMethod]
		public void TestCellResources()
		{
			SmartsheetClient smartsheet = new SmartsheetBuilder().SetMaxRetryTimeout(30000).Build(); 
			
			long sheetId = CreateSheet(smartsheet);

			PaginatedResult<Column> columnsResult = smartsheet.SheetResources.ColumnResources.ListColumns(sheetId, null, null);
			long columnId = columnsResult.Data[0].Id.Value;

			Cell[] cellsToAdd = new Cell[] { new Cell.AddCellBuilder(columnId, true).SetValue("hello").SetStrict(false).Build() };

			long rowId = AddRows(smartsheet, sheetId, columnId, cellsToAdd);

			PaginatedResult<CellHistory> histories = smartsheet.SheetResources.RowResources.CellResources.GetCellHistory(sheetId, rowId, columnId, new CellInclusion[] { CellInclusion.COLUMN_TYPE }, null);
			Assert.IsTrue(histories.Data[0].ColumnType == ColumnType.TEXT_NUMBER);
			Assert.IsTrue(histories.Data.Count == 1);
			Assert.IsTrue(histories.Data[0].ColumnId == columnId);

			smartsheet.SheetResources.DeleteSheet(sheetId);
		}

		private static long AddRows(SmartsheetClient smartsheet, long sheetId, long columnId, Cell[] cellsToAdd)
		{
			Row row = new Row.AddRowBuilder(true, null, null, null, null).SetCells(cellsToAdd).Build();
			IList<Row> rows = smartsheet.SheetResources.RowResources.AddRows(sheetId, new Row[] { row });
			Assert.IsTrue(rows.Count == 1);
			long rowId = rows[0].Id.Value;
			bool foundValue = false;
			foreach (Cell cell in rows[0].Cells)
			{
				if (cell.ColumnId == columnId)
				{
					Assert.IsTrue(cell.Value.ToString() == "hello");
					foundValue = true;
					break;
				}
			}
			Assert.IsTrue(foundValue);
			return rowId;
		}

		private static long CreateSheet(SmartsheetClient smartsheet)
		{
			Column[] columnsToCreate = new Column[] {
			new Column.CreateSheetColumnBuilder("col 1", true, ColumnType.TEXT_NUMBER).Build(),
			new Column.CreateSheetColumnBuilder("col 2", false, ColumnType.DATE).Build(),
			new Column.CreateSheetColumnBuilder("col 3", false, ColumnType.TEXT_NUMBER).Build(),
			};
			Sheet createdSheet = smartsheet.SheetResources.CreateSheet(new Sheet.CreateSheetBuilder("new sheet", columnsToCreate).Build());
			Assert.IsTrue(createdSheet.Columns.Count == 3);
			Assert.IsTrue(createdSheet.Columns[1].Title == "col 2");
			return createdSheet.Id.Value;
		}
	}
}