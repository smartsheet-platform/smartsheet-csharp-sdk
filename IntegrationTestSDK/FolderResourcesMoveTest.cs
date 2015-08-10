using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smartsheet.Api;
using Smartsheet.Api.Models;
using System.Configuration;

namespace IntegrationTestSDK
{
	[TestClass]
	public class FolderResourcesMoveTest
	{
		[TestMethod]
		public void TestFolderMoveResources()
		{
			string accessToken = ConfigurationManager.AppSettings["testAccessToken"];

			SmartsheetClient smartsheet = new SmartsheetBuilder().SetAccessToken(accessToken).SetBaseURI("https://api.test.smartsheet.com/2.0/").Build();
			// Before
			// Folder1-----SubFolder1
			// Folder2

			// After
			// Folder1
			// Folder2-----SubFolder1
			long createdFolderInHomeId1 = CreateFolderInHome(smartsheet, "Folder1");
			long createdFolderInHomeId2 = CreateFolderInHome(smartsheet, "Folder2");

			long createdFolderInFolderId = CreateFolderInFolder(smartsheet, createdFolderInHomeId1, "SubFolder1");

			ContainerDestination destination = new ContainerDestination
			{
				DestinationId = createdFolderInHomeId2,
				DestinationType = DestinationType.FOLDER,
				//NewName = "NotSupported"
			};
			Folder newMovedFolder = smartsheet.FolderResources.MoveFolder(createdFolderInFolderId, destination);

			Assert.IsTrue(newMovedFolder.Name == "SubFolder1");

			long movedFolderId = newMovedFolder.Id.Value;

			Folder movedFolder = smartsheet.FolderResources.GetFolder(movedFolderId, null);
			Assert.IsTrue(movedFolder.Name == "SubFolder1");

			// Assert the Folder which use to contain the moved Folder is now empty.
			PaginatedResult<Folder> foldersResult = smartsheet.FolderResources.ListFolders(createdFolderInHomeId1, null);
			Assert.IsTrue(foldersResult.Data.Count == 0);


			DeleteFolders(smartsheet, createdFolderInHomeId1, createdFolderInHomeId2);
		}


		private static void DeleteFolders(SmartsheetClient smartsheet, long folder1, long folder2)
		{
			smartsheet.FolderResources.DeleteFolder(folder2);
			try
			{
				smartsheet.FolderResources.GetFolder(folder2, null);
				Assert.Fail("Exception should have been thrown. Cannot get a deleted folder.");
			}
			catch
			{
				// Should be "Not Found".
			}
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

		private static long CreateFolderInFolder(SmartsheetClient smartsheet, long createdFolderInHomeId, string folderName)
		{
			Folder createdFolderInFolder = smartsheet.FolderResources.CreateFolder(createdFolderInHomeId, new Folder.CreateFolderBuilder(folderName).Build());
			return createdFolderInFolder.Id.Value;
		}

		private static long CreateFolderInHome(SmartsheetClient smartsheet, string folderName)
		{
			Folder createdFolderInHome = smartsheet.HomeResources.FolderResources.CreateFolder(new Folder.CreateFolderBuilder(folderName).Build());
			return createdFolderInHome.Id.Value;
		}
	}
}