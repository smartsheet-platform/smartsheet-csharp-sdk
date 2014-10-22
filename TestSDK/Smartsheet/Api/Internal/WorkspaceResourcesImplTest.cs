using System.Collections.Generic;

namespace Smartsheet.Api.Internal
{
	using NUnit.Framework;




	using DefaultHttpClient = Smartsheet.Api.Internal.Http.DefaultHttpClient;
	using AccessLevel = Smartsheet.Api.Models.AccessLevel;
	using Workspace = Smartsheet.Api.Models.Workspace;

	public class WorkspaceResourcesImplTest : ResourcesImplBase
	{

		private WorkspaceResourcesImpl workspaceResources;

		[SetUp]
		public virtual void SetUp()
		{
			workspaceResources = new WorkspaceResourcesImpl(new SmartsheetImpl("http://localhost:9090/1.1/", 
				"accessToken", new DefaultHttpClient(), serializer));
		}

		[Test]
		public virtual void TestWorkspaceResourcesImpl()
		{
		}
		[Test]
		public virtual void TestListWorkspaces()
		{
			server.setResponseBody("../../../TestSDK/resources/listWorkspaces.json");

			IList<Workspace> workspace = workspaceResources.ListWorkspaces();
			Assert.AreEqual(7, workspace.Count);
			Assert.AreEqual(995897522841476L, (long)workspace[0].ID);
			Assert.AreEqual("Bootcamp Company", workspace[0].Name);
			Assert.AreEqual(AccessLevel.OWNER, workspace[0].AccessLevel);
			Assert.AreEqual("https://app.smartsheet.com/b/home?lx=asdsa", workspace[0].Permalink);
		}

		[Test]
		public virtual void TestGetWorkspace()
		{
			server.setResponseBody("../../../TestSDK/resources/getWorkspace.json");

			Workspace workspace = workspaceResources.GetWorkspace(1234L);
			Assert.AreEqual(995897522841476L, (long)workspace.ID);
			Assert.AreEqual("Bootcamp Company", workspace.Name);
			Assert.AreEqual(0, workspace.Sheets.Count);
			Assert.AreEqual(2, workspace.Folders.Count);
			Assert.AreEqual(AccessLevel.OWNER, workspace.AccessLevel);
			Assert.AreEqual("https://app.smartsheet.com/b/home?asdf", workspace.Permalink);
		}

		[Test]
		public virtual void TestCreateWorkspace()
		{
			server.setResponseBody("../../../TestSDK/resources/createWorkspace.json");

			Workspace workspace = new Workspace();
			workspace.Name = "New Workspace";
			Workspace newWorkspace = workspaceResources.CreateWorkspace(workspace);
			Assert.AreEqual(2349499415848836L, (long)newWorkspace.ID);
			Assert.AreEqual("New Workspace", newWorkspace.Name);
			Assert.AreEqual(AccessLevel.OWNER, newWorkspace.AccessLevel);
			Assert.AreEqual("https://app.smartsheet.com/b/home?lx=Jasdfa", newWorkspace.Permalink);
		}

		[Test]
		public virtual void TestUpdateWorkspace()
		{
			server.setResponseBody("../../../TestSDK/resources/updateWorkspace.json");

			Workspace workspace = new Workspace();
			workspace.Name = "New Workspace";
			Workspace newWorkspace = workspaceResources.UpdateWorkspace(workspace);
			Assert.AreEqual(2349499415848836L, (long)newWorkspace.ID);
			Assert.AreEqual("New Workspace1", newWorkspace.Name);
			Assert.AreEqual(AccessLevel.OWNER, newWorkspace.AccessLevel);
			Assert.AreEqual("https://app.smartsheet.com/b/home?lx=asdf", newWorkspace.Permalink);
		}

		[Test]
		public virtual void TestDeleteWorkspace()
		{
			server.setResponseBody("../../../TestSDK/resources/deleteWorkspace.json");
			workspaceResources.DeleteWorkspace(1234L);
		}

		[Test]
		public virtual void TestFolders()
		{
			Assert.NotNull(workspaceResources.Folders());
		}

		[Test]
		public virtual void TestShares()
		{
			Assert.NotNull(workspaceResources.Shares());
		}

	}

}