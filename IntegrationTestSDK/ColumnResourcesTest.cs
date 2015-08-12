﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smartsheet.Api;
using Smartsheet.Api.Models;
using System.Collections.Generic;
using System.Configuration;

namespace IntegrationTestSDK
{
	[TestClass]
	public class ColumnResourcesTest
	{
		[TestMethod]
		public void TestColumnResources()
		{
			string accessToken = ConfigurationManager.AppSettings["accessToken"];

			SmartsheetClient smartsheet = new SmartsheetBuilder().SetAccessToken(accessToken).Build();
			long sheetId = CreateSheet(smartsheet);
			AddColumns(smartsheet, sheetId);

			long columnId = ListColumns(smartsheet, sheetId);
			UpdateColumn(smartsheet, sheetId, columnId);
			DeleteAndGetColumn(smartsheet, sheetId, columnId);
		}

		private static void DeleteAndGetColumn(SmartsheetClient smartsheet, long sheetId, long columnId)
		{
			smartsheet.SheetResources.ColumnResources.DeleteColumn(sheetId, columnId);
			try
			{
				smartsheet.SheetResources.ColumnResources.GetColumn(sheetId, columnId, null);
				Assert.Fail("Cannot get a column that is deleted.");
			}
			catch
			{
				//Not found.
			}
		}

		private static long ListColumns(SmartsheetClient smartsheet, long sheetId)
		{
			PaginatedResult<Column> columnsResult = smartsheet.SheetResources.ColumnResources.ListColumns(sheetId, new ColumnInclusion[] { ColumnInclusion.FILTERS }, null);
			Assert.IsTrue(columnsResult.TotalCount == 4);
			Assert.IsTrue(columnsResult.Data.Count == 4);
			return columnsResult.Data[3].Id.Value;
		}

		private static void UpdateColumn(SmartsheetClient smartsheet, long sheetId, long columnId)
		{
			Column updatedColumn = smartsheet.SheetResources.ColumnResources.UpdateColumn(sheetId, new Column.UpdateColumnBuilder(columnId, "col 4 updated", 2).Build());
			Assert.IsTrue(updatedColumn.Title == "col 4 updated");
		}

		private static void AddColumns(SmartsheetClient smartsheet, long sheetId)
		{
			IList<Column> columnsAdded = smartsheet.SheetResources.ColumnResources.AddColumns(sheetId, new Column[] { new Column.AddColumnBuilder("col 4", 3, ColumnType.CONTACT_LIST).Build() });
			Assert.IsTrue(columnsAdded.Count == 1);
			Assert.IsTrue(columnsAdded[0].Title == "col 4");
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