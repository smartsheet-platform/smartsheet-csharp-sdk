using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smartsheet.Api;
using Smartsheet.Api.Models;
using System.IO;
using System.Configuration;

namespace IntegrationTestSDK
{
	[TestClass]
	public class SheetResourcesTest
	{

		[TestMethod]
		public void TestSheetResources()
		{
			string accessToken = ConfigurationManager.AppSettings["accessToken"];

			SmartsheetClient smartsheet = new SmartsheetBuilder().SetAccessToken(accessToken).Build();
			long sheetId = CreateSheet(smartsheet);
			SendSheet(smartsheet, sheetId);
			UpdateSheet(smartsheet, sheetId);
			UpdatePublishSheetStatus(smartsheet, sheetId);
			GetSheetAsPDF(smartsheet, sheetId);
			DeleteSheet(smartsheet, sheetId);
		}

		private static void DeleteSheet(SmartsheetClient smartsheet, long sheetId)
		{
			smartsheet.SheetResources.DeleteSheet(sheetId);
			try
			{
				smartsheet.SheetResources.GetSheet(sheetId, null, null, null, null, null, null, null);
				Assert.Fail("Exception should have been thrown because Sheet should have been deleted.");
			}
			catch
			{
				//Not found.
			}
		}

		private static void GetSheetAsPDF(SmartsheetClient smartsheet, long sheetId)
		{
			BinaryWriter writer = new BinaryWriter(new MemoryStream());
			smartsheet.SheetResources.GetSheetAsPDF(sheetId, writer, PaperSize.A3);
			//smartsheet.SheetResources.GetSheetAsExcel(sheetId, writer);
			//smartsheet.SheetResources.GetSheetAsCSV(sheetId, writer);
		}

		private static void UpdatePublishSheetStatus(SmartsheetClient smartsheet, long sheetId)
		{
			SheetPublish sheetPublish = smartsheet.SheetResources.UpdatePublishStatus(sheetId, new SheetPublish.PublishStatusBuilder(true, false, false, false).Build());
			Assert.IsTrue(sheetPublish.ReadOnlyLiteEnabled.Value);
			Assert.IsTrue(!sheetPublish.ReadOnlyFullEnabled.Value);
		}

		private static void UpdateSheet(SmartsheetClient smartsheet, long sheetId)
		{
			Sheet updatedSheet = smartsheet.SheetResources.UpdateSheet(new Sheet.UpdateSheetBuilder(sheetId).SetName("updated sheet").Build());
			Assert.IsTrue(updatedSheet.Name == "updated sheet");
		}

		private static void SendSheet(SmartsheetClient smartsheet, long sheetId)
		{
			SheetEmail sheetEmail = new SheetEmail { SendTo = new Recipient[] { new Recipient { Email = "eric.yan@smartsheet.com" } }, Subject = "Subject", Format = SheetEmailFormat.PDF };
			smartsheet.SheetResources.SendSheet(sheetId, sheetEmail);
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