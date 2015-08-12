using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smartsheet.Api;
using Smartsheet.Api.Models;
using System.Configuration;

namespace IntegrationTestSDK
{
	[TestClass]
	public class WorkspaceResourcesTest
	{
		[TestMethod]
		public void TestWorkspaceResources()
		{
			string accessToken = ConfigurationManager.AppSettings["accessToken"];

			SmartsheetClient smartsheet = new SmartsheetBuilder().SetAccessToken(accessToken).Build();
			
			long workspaceId = CreateWorkspace(smartsheet);

			UpdateWorkspace(smartsheet, workspaceId);

			GetWorkspace(smartsheet, workspaceId);

			ListWorkspaces(smartsheet, workspaceId);

			DeleteWorkspace(smartsheet, workspaceId);
		}

		private static void DeleteWorkspace(SmartsheetClient smartsheet, long workspaceId)
		{
			smartsheet.WorkspaceResources.DeleteWorkspace(workspaceId);
			try
			{
				smartsheet.WorkspaceResources.GetWorkspace(workspaceId, null, null);
				Assert.Fail("Cannot get a workspace that was deleted.");
			}
			catch
			{
				//Not found.
			}
		}

		private static void ListWorkspaces(SmartsheetClient smartsheet, long workspaceId)
		{
			PaginatedResult<Workspace> workspaceResult = smartsheet.WorkspaceResources.ListWorkspaces(null);
			Assert.IsTrue(workspaceResult.Data.Count > 0);
			bool contains = false;
			foreach (Workspace ws in workspaceResult.Data)
			{
				if (ws.Id.Value == workspaceId)
				{
					contains = true;
					break;	
				}
			}
			Assert.IsTrue(contains);
		}
		private static void GetWorkspace(SmartsheetClient smartsheet, long workspaceId)
		{
			Workspace workspace = smartsheet.WorkspaceResources.GetWorkspace(workspaceId, true, new WorkspaceInclusion[] { WorkspaceInclusion.SOURCE });
			Assert.IsTrue(workspace.Id.Value == workspaceId);
		}

		private static void UpdateWorkspace(SmartsheetClient smartsheet, long workspaceId)
		{
			Workspace workspace = new Workspace.UpdateWorkspaceBuilder(workspaceId, "updated workspace").Build();

			Workspace updatedWorkspace = smartsheet.WorkspaceResources.UpdateWorkspace(workspace);

			Assert.IsTrue(updatedWorkspace.Name == "updated workspace");
		}

		private static long CreateWorkspace(SmartsheetClient smartsheet)
		{
			Workspace workspace = new Workspace.CreateWorkspaceBuilder("workspace").Build();

			Workspace createdWorkspace = smartsheet.WorkspaceResources.CreateWorkspace(workspace);
			Assert.IsTrue(createdWorkspace.Name == "workspace");
			return createdWorkspace.Id.Value;
		}
	}
}