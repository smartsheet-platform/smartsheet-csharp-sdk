using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smartsheet.Api;
using Smartsheet.Api.Models;
using System.Configuration;

namespace IntegrationTestSDK
{
    [TestClass]
    public class FolderResourcesTest
    {
        /// <summary>
        /// Create Folder
        /// smartsheet.HomeResources.FolderResources.CreateFolder(new Folder.CreateFolderBuilder("New Folder").Build());
        /// 
        /// Create Folder (Folder)
        /// smartsheet.FolderResources.CreateFolder(123, new Folder.CreateFolderBuilder("New Folder").Build());
        /// 
        /// Create Folder (Workspace)
        /// smartsheet.WorkspaceResources.FolderResources.CreateFolder(123, new Folder.CreateFolderBuilder("New Folder").Build());
        /// 
        /// Delete Folder
        /// smartsheet.FolderResources.DeleteFolder(123);
        /// 
        /// Get Folder
        /// smartsheet.FolderResources.GetFolder(123, null);
        /// 
        /// List Folder
        /// smartsheet.HomeResources.FolderResources.ListFolders(null);
        /// 
        /// List Folders (Folder)
        /// smartsheet.FolderResources.ListFolders(123, null);
        /// 
        /// List Folders (Workspace)
        /// smartsheet.WorkspaceResources.FolderResources.ListFolders(123, null);
        /// 
        /// Update Folder
        /// smartsheet.FolderResources.UpdateFolder(123, new Folder.UpdateFolderBuilder("New name for folder").Build());
        /// </summary>

        private static string folderInHomeName = "new folder in home";
        private static string folderInFolderName = "new folder in folder";
        private static string updatedFolderInFolderName = "updated folder in folder";

        [TestMethod]
        public void TestFolderResources()
        {
            SmartsheetClient smartsheet = new SmartsheetBuilder().SetMaxRetryTimeout(30000).Build();

            long createdFolderInHomeId = CreateFolderInHome(smartsheet);
            long createdFolderInFolderId = CreateFolderInFolder(smartsheet, createdFolderInHomeId);
            ListFoldersInFolder(smartsheet, createdFolderInHomeId, createdFolderInFolderId);
            UpdateFolderInFolder(smartsheet, createdFolderInFolderId);
            GetFolderInHome(smartsheet, createdFolderInHomeId, createdFolderInFolderId);
            DeleteFolders(smartsheet, createdFolderInHomeId, createdFolderInFolderId);
        }


        private static void DeleteFolders(SmartsheetClient smartsheet, long createdFolderInHomeId, long createdFolderInFolderId)
        {
            smartsheet.FolderResources.DeleteFolder(createdFolderInFolderId);
            try
            {
                smartsheet.FolderResources.GetFolder(createdFolderInFolderId, null);
                Assert.Fail("Exception should have been thrown. Cannot get a deleted folder.");
            }
            catch
            {
                // Should be "Not Found".
            }
            smartsheet.FolderResources.DeleteFolder(createdFolderInHomeId);
            try
            {
                smartsheet.FolderResources.GetFolder(createdFolderInHomeId, null);
                Assert.Fail("Exception should have been thrown. Cannot get a deleted folder.");
            }
            catch
            {
                // Should be "Not Found".
            }
        }

        private static void GetFolderInHome(SmartsheetClient smartsheet, long createdFolderInHomeId, long createdFolderInFolderId)
        {
            Folder getFolder = smartsheet.FolderResources.GetFolder(createdFolderInHomeId, null);
            Assert.IsTrue(getFolder.Id == createdFolderInHomeId);
            Assert.IsTrue(getFolder.Name == folderInHomeName);
            Assert.IsTrue(getFolder.Folders.Count == 1);
            Assert.IsTrue(getFolder.Folders[0].Id == createdFolderInFolderId);
            Assert.IsTrue(getFolder.Folders[0].Name == updatedFolderInFolderName);
        }

        private static void UpdateFolderInFolder(SmartsheetClient smartsheet, long createdFolderInFolderId)
        {
            Folder updatedFolderInFolder = smartsheet.FolderResources.UpdateFolder(new Folder.UpdateFolderBuilder(createdFolderInFolderId, updatedFolderInFolderName).Build());
            Assert.IsTrue(updatedFolderInFolder.Name == updatedFolderInFolderName);
        }

        private static void ListFoldersInFolder(SmartsheetClient smartsheet, long createdFolderInHomeId, long createdFolderInFolderId)
        {
            PaginatedResult<Folder> folderResults = smartsheet.FolderResources.ListFolders(createdFolderInHomeId, null);
            Assert.IsTrue(folderResults.Data.Count == 1);
            Assert.IsTrue(folderResults.TotalCount == 1);
            Assert.IsTrue(folderResults.Data[0].Id == createdFolderInFolderId);
        }

        private static long CreateFolderInFolder(SmartsheetClient smartsheet, long createdFolderInHomeId)
        {
            Folder createdFolderInFolder = smartsheet.FolderResources.CreateFolder(createdFolderInHomeId, new Folder.CreateFolderBuilder(folderInFolderName).Build());
            Assert.IsTrue(createdFolderInFolder.Name == folderInFolderName);
            return createdFolderInFolder.Id.Value;
        }

        private static long CreateFolderInHome(SmartsheetClient smartsheet)
        {
            Folder createdFolderInHome = smartsheet.HomeResources.FolderResources.CreateFolder(new Folder.CreateFolderBuilder(folderInHomeName).Build());
            Assert.IsTrue(createdFolderInHome.Name == folderInHomeName);
            return createdFolderInHome.Id.Value;
        }
    }
}