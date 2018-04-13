using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smartsheet.Api;
using Smartsheet.Api.Models;
using System.Configuration;

namespace IntegrationTestSDK
{
	using NUnit.Framework;

	public class SheetResourcesMoveTest
	{
		[Test]
		public void TestSheetMoveResources()
		{
			SmartsheetClient smartsheet = new SmartsheetBuilder().SetMaxRetryTimeout(30000).Build();
			// Before
			// Sheet
			// Folder

			// After
			// 
			// Folder-----SheetCopy
			long folderId = CreateFolderInHome(smartsheet, "Folder1");

			long sheetId = CreateSheet(smartsheet);

			ContainerDestination destination = new ContainerDestination
			{
				DestinationId = folderId,
				DestinationType = DestinationType.FOLDER,
				//NewName = "hello"
			};
			Sheet newMovedSheet = smartsheet.SheetResources.MoveSheet(sheetId, destination);

			Assert.IsTrue(newMovedSheet.Name == "new sheet");

			long movedSheetId = newMovedSheet.Id.Value;

			Sheet movedSheet = smartsheet.SheetResources.GetSheet(movedSheetId, null, null, null, null, null, null, null);
			Assert.IsTrue(movedSheet.Name == "new sheet");

			//Deleting the folder will also delete the sheet.
			DeleteFolders(smartsheet, folderId);
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