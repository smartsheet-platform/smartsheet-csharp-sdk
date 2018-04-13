using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smartsheet.Api;
using Smartsheet.Api.Models;
using System.Configuration;

namespace IntegrationTestSDK
{
	using NUnit.Framework;

	public class FolderResourcesCopyTest
	{
		[Test]
		public void TestFolderCopyResources()
		{
			SmartsheetClient smartsheet = new SmartsheetBuilder().SetMaxRetryTimeout(30000).Build();
			// Before
			// Folder1-----SubFolder1
			// Folder2

			// After
			// Folder1-----SubFolder1
			// Folder2-----SubFolder1Copy
			long createdFolderInHomeId1 = CreateFolderInHome(smartsheet, "Folder1");
			long createdFolderInHomeId2 = CreateFolderInHome(smartsheet, "Folder2");

			long createdFolderInFolderId = CreateFolderInFolder(smartsheet, createdFolderInHomeId1, "SubFolder1");

			ContainerDestination destination = new ContainerDestination
			{
				DestinationId = createdFolderInHomeId2,
				DestinationType = DestinationType.FOLDER,
				NewName = "SubFolder1Copy"
			};
			Folder newCopiedFolder = smartsheet.FolderResources.CopyFolder(createdFolderInFolderId, destination, new FolderCopyInclusion[] { FolderCopyInclusion.ALL }, new FolderRemapExclusion[] { FolderRemapExclusion.CELL_LINKS });

			Assert.IsTrue(newCopiedFolder.Name == "SubFolder1Copy");

			long copiedFolderId = newCopiedFolder.Id.Value;

			Folder copiedFolder = smartsheet.FolderResources.GetFolder(copiedFolderId, null);
			Assert.IsTrue(copiedFolder.Name == "SubFolder1Copy");

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