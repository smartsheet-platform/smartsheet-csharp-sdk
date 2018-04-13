using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smartsheet.Api;
using Smartsheet.Api.Models;
using System.Configuration;

namespace IntegrationTestSDK
{
	using NUnit.Framework;

	public class SheetResourcesCopyTest
	{
		[Test]
		public void TestSheetCopyResources()
		{
			SmartsheetClient smartsheet = new SmartsheetBuilder().SetMaxRetryTimeout(30000).Build();
			// Before
			// Sheet
			// Folder

			// After
			// Sheet
			// Folder-----SheetCopy
			long folderId = CreateFolderInHome(smartsheet, "Folder1");

			long sheetId = CreateSheet(smartsheet);

			ContainerDestination destination = new ContainerDestination
			{
				DestinationId = folderId,
				DestinationType = DestinationType.FOLDER,
				NewName = "SheetCopy"
			};
			Sheet newCopiedSheet = smartsheet.SheetResources.CopySheet(sheetId, destination, new SheetCopyInclusion[] { SheetCopyInclusion.ALL });

			Assert.IsTrue(newCopiedSheet.Name == "SheetCopy");

			long copiedSheetId = newCopiedSheet.Id.Value;

			Sheet copiedSheet = smartsheet.SheetResources.GetSheet(copiedSheetId, null, null, null, null, null, null, null);
			Assert.IsTrue(copiedSheet.Name == "SheetCopy");

			DeleteFolders(smartsheet, folderId);
			smartsheet.SheetResources.DeleteSheet(sheetId);
		}


		private static void DeleteFolders(SmartsheetClient smartsheet, long folder1)
		{
			smartsheet.FolderResources.DeleteFolder(folder1);
			try
			{
				smartsheet.FolderResources.GetFolder(folder1, null);
				Assert.Fail("Exception should have been thrown. Cannot get a deleted folder.");
			}
			catch
			{
				// Should be "Not Found".
			}
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

		private static long CreateFolderInHome(SmartsheetClient smartsheet, string folderName)
		{
			Folder createdFolderInHome = smartsheet.HomeResources.FolderResources.CreateFolder(new Folder.CreateFolderBuilder(folderName).Build());
			return createdFolderInHome.Id.Value;
		}
	}
}