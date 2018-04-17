using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smartsheet.Api;
using Smartsheet.Api.Models;
using System.Configuration;

namespace IntegrationTestSDK
{
	[TestClass]
	public class SearchingResourcesTest
	{
		[TestMethod]
		public void TestSearchingResources()
		{
			SmartsheetClient smartsheet = new SmartsheetBuilder().SetMaxRetryTimeout(30000).Build();
			
			string query = GenerateRandomQuery();


			long sheetId = CreateSheet(smartsheet);
			AddValuesToSheet(smartsheet, sheetId, query);
			// this very rarely shows up in 5 seconds
			System.Threading.Thread.Sleep(5000);
			SearchEverywhere(smartsheet, query, sheetId);

			SearchSheet(smartsheet, query, sheetId);

			smartsheet.SheetResources.DeleteSheet(sheetId);
		}

		private static void SearchSheet(SmartsheetClient smartsheet, string query, long sheetId)
		{
			SearchResult result = smartsheet.SearchResources.SearchSheet(sheetId, query);
			if (result.Results.Count == 1)
			{
				Assert.IsTrue(result.Results[0].ParentObjectId == sheetId);
				Assert.IsTrue(result.Results[0].ParentObjectType == ObjectType.SHEET);
				Assert.IsTrue(result.Results[0].ObjectType == SearchObjectType.ROW);
				Assert.IsTrue(result.Results[0].Text == query);
			}
		}

		private static void SearchEverywhere(SmartsheetClient smartsheet, string query, long sheetId)
		{
			SearchResult result = smartsheet.SearchResources.Search(query);
			if (result.Results.Count == 1)
			{
				Assert.IsTrue(result.Results[0].ParentObjectId == sheetId);
				Assert.IsTrue(result.Results[0].ParentObjectType == ObjectType.SHEET);
				Assert.IsTrue(result.Results[0].ObjectType == SearchObjectType.ROW);
				Assert.IsTrue(result.Results[0].Text == query);
			}
		}

		private static void AddValuesToSheet(SmartsheetClient smartsheet, long sheetId, string query)
		{
			Sheet sheet = smartsheet.SheetResources.GetSheet(sheetId, null, null, null, null, null, null, null);
			long columnId = sheet.Columns[0].Id.Value;
			Cell cell = new Cell.AddCellBuilder(columnId, query).SetStrict(false).Build();
			Row[] rows = new Row[] { new Row.AddRowBuilder(true, null, null, null, false).SetCells(new Cell[] { cell }).Build() };

			smartsheet.SheetResources.RowResources.AddRows(sheetId, rows);
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

		private static string GenerateRandomQuery()
		{
			var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
			var stringChars = new char[8];
			var random = new Random();

			for (int i = 0; i < stringChars.Length; i++)
			{
				stringChars[i] = chars[random.Next(chars.Length)];
			}

			return new String(stringChars);
		}
	}
}