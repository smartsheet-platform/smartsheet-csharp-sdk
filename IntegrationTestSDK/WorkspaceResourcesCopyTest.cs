
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smartsheet.Api;
using Smartsheet.Api.Models;
using System.Configuration;

namespace IntegrationTestSDK
{
	using NUnit.Framework;

	public class WorkspaceResourcesCopyTest
	{
		[Test]
		public void TestWorkspaceCopyResources()
		{
			SmartsheetClient smartsheet = new SmartsheetBuilder().SetMaxRetryTimeout(30000).Build();
			// Before
			// Workspace1
			// Folder2

			// After
			// Workspace1
			// Folder2-----Workspace1Copy

			Workspace workspace = smartsheet.WorkspaceResources.CreateWorkspace(new Workspace.CreateWorkspaceBuilder("Workspace1").Build());
			long workspaceId = workspace.Id.Value;

			ContainerDestination destination = new ContainerDestination
			{
				NewName = "Workspace1Copy"
			};
			Workspace newCopiedWorkspace = smartsheet.WorkspaceResources.CopyWorkspace(workspaceId, destination, new WorkspaceCopyInclusion[] { WorkspaceCopyInclusion.ALL }, new WorkspaceRemapExclusion[] { WorkspaceRemapExclusion.CELL_LINKS });

			Assert.IsTrue(newCopiedWorkspace.Name == "Workspace1Copy");

			long copiedWorkspaceId = newCopiedWorkspace.Id.Value;

			Workspace copiedWorkspace = smartsheet.WorkspaceResources.GetWorkspace(copiedWorkspaceId, null, null);
			Assert.IsTrue(copiedWorkspace.Name == "Workspace1Copy");

			smartsheet.WorkspaceResources.DeleteWorkspace(workspaceId);
			smartsheet.WorkspaceResources.DeleteWorkspace(copiedWorkspaceId);
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

		private static long CreateWorkspaceInFolder(SmartsheetClient smartsheet, long folderId, string folderName)
		{
			Folder createdFolderInFolder = smartsheet.WorkspaceResources.FolderResources.CreateFolder(folderId, new Folder.CreateFolderBuilder(folderName).Build());
			return createdFolderInFolder.Id.Value;
		}

		private static long CreateFolderInHome(SmartsheetClient smartsheet, string folderName)
		{
			Folder createdFolderInHome = smartsheet.HomeResources.FolderResources.CreateFolder(new Folder.CreateFolderBuilder(folderName).Build());
			return createdFolderInHome.Id.Value;
		}
	}
}