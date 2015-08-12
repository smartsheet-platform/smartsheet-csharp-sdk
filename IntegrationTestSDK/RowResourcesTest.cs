﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smartsheet.Api;
using Smartsheet.Api.Models;
using System.Collections.Generic;
using System.Configuration;

namespace IntegrationTestSDK
{
	[TestClass]
	public class RowResourcesTest
	{
		[TestMethod]
		public void TestRowResources()
		{
			string accessToken = ConfigurationManager.AppSettings["testAccessToken"];

			SmartsheetClient smartsheet = new SmartsheetBuilder().SetAccessToken(accessToken).SetBaseURI("https://api.test.smartsheet.com/2.0/").Build();

			long templateId = smartsheet.TemplateResources.ListPublicTemplates(null).Data[0].Id.Value;
			long sheetId = CreateSheetFromTemplate(smartsheet, templateId);

			PaginatedResult<Column> columnsResult = smartsheet.SheetResources.ColumnResources.ListColumns(sheetId, null, null);
			long columnId = columnsResult.Data[0].Id.Value;

			Cell[] cellsToAdd = new Cell[] { new Cell.AddCellBuilder(columnId, true).SetValue("hello").SetStrict(false).Build() };

			long rowId = AddRows(smartsheet, sheetId, columnId, cellsToAdd);

			CopyRowToCreatedSheet(smartsheet, sheetId, rowId);

			DeleteRowAndGetRow(smartsheet, sheetId, rowId);

		}

		private static void DeleteRowAndGetRow(SmartsheetClient smartsheet, long sheetId, long rowId)
		{

			smartsheet.SheetResources.RowResources.DeleteRows(sheetId, new long[] { rowId }, false);
			try
			{
				smartsheet.SheetResources.RowResources.GetRow(sheetId, rowId, new RowInclusion[] { RowInclusion.COLUMNS }, null);
				Assert.Fail("Cannot get a deleted row.");
			}
			catch
			{
				//Not found.
			}
		}

		private static void CopyRowToCreatedSheet(SmartsheetClient smartsheet, long sheetId, long rowId)
		{
			long tempSheetId = smartsheet.SheetResources.CreateSheet(new Sheet.CreateSheetBuilder("tempSheet", new Column[] { new Column.CreateSheetColumnBuilder("col1", true, ColumnType.TEXT_NUMBER).Build() }).Build()).Id.Value;
			CopyOrMoveRowDestination destination = new CopyOrMoveRowDestination { SheetId = tempSheetId };
			CopyOrMoveRowDirective directive = new CopyOrMoveRowDirective { RowIds = new long[] { rowId }, To = destination };
			CopyOrMoveRowResult result = smartsheet.SheetResources.RowResources.CopyRowsToAnotherSheet(sheetId, directive, new CopyRowInclusion[] { CopyRowInclusion.CHILDREN }, false);
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


		private static long CreateSheetFromTemplate(SmartsheetClient smartsheet, long templateId)
		{
			// Create a new sheet off of that template.
			Sheet newSheet = smartsheet.SheetResources.CreateSheetFromTemplate(new Sheet.CreateSheetFromTemplateBuilder("New Sheet", templateId).Build(), new TemplateInclusion[] { TemplateInclusion.DATA });
			return newSheet.Id.Value;
		}
	}
}