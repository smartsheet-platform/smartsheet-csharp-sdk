using System.Collections.Generic;

namespace Smartsheet.Api.Internal
{
	using NUnit.Framework;




	using DefaultHttpClient = Smartsheet.Api.Internal.Http.DefaultHttpClient;
	using AccessLevel = Smartsheet.Api.Models.AccessLevel;
	using Workspace = Smartsheet.Api.Models.Workspace;
	using Smartsheet.Api.Models;

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

			DataWrapper<Workspace> result = workspaceResources.ListWorkspaces(null);
			Assert.AreEqual(2, result.TotalCount);
			Assert.AreEqual(3457273486960516, (long)result.Data[0].Id);
			Assert.AreEqual("workspace 1", result.Data[0].Name);
			Assert.AreEqual(AccessLevel.OWNER, result.Data[0].AccessLevel);
			Assert.AreEqual("https://app.smartsheet.com/b/home?lx=JLiJbgXtXc0pzni9tzAKiR", result.Data[1].Permalink);
		}

		[Test]
		public virtual void TestGetWorkspace()
		{
			server.setResponseBody("../../../TestSDK/resources/getWorkspace.json");

			Workspace workspace = workspaceResources.GetWorkspace(1234L, false, null);
			Assert.AreEqual(7116448184199044, (long)workspace.Id);
			Assert.AreEqual("New workspace", workspace.Name);
			Assert.AreEqual(1, workspace.Sheets.Count);
			Assert.AreEqual(null, workspace.Folders);
			Assert.AreEqual(AccessLevel.OWNER, workspace.AccessLevel);
			Assert.AreEqual("https://app.smartsheet.com/b/home?lx=8Z0XuFUEAkxmHCSsMw4Zgg", workspace.Permalink);
		}

		[Test]
		public virtual void TestCreateWorkspace()
		{
			server.setResponseBody("../../../TestSDK/resources/createWorkspace.json");

			Workspace workspace = new Workspace.CreateWorkspaceBuilder("New workspace").Build();
			Workspace newWorkspace = workspaceResources.CreateWorkspace(workspace);
			Assert.AreEqual(7960873114331012, (long)newWorkspace.Id);
			Assert.AreEqual("New workspace", newWorkspace.Name);
			Assert.AreEqual(AccessLevel.OWNER, newWorkspace.AccessLevel);
			Assert.AreEqual("https://app.smartsheet.com/b/home?lx=rBU8QqUVPCJ3geRgl7L8yQ", newWorkspace.Permalink);
		}

		[Test]
		public virtual void TestUpdateWorkspace()
		{
			server.setResponseBody("../../../TestSDK/resources/updateWorkspace.json");

			Workspace workspace = new Workspace.UpdateWorkspaceBuilder("Updated workspace").Build();
			Workspace newWorkspace = workspaceResources.UpdateWorkspace(32434534, workspace);
			Assert.AreEqual(7960873114331012, (long)newWorkspace.Id);
			Assert.AreEqual("Updated workspace", newWorkspace.Name);
			Assert.AreEqual(AccessLevel.OWNER, newWorkspace.AccessLevel);
			Assert.AreEqual("https://app.smartsheet.com/b/home?lx=rBU8QqUVPCJ3geRgl7L8yQ", newWorkspace.Permalink);
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
			Assert.NotNull(workspaceResources.FolderResources());
		}

		[Test]
		public virtual void TestShares()
		{
			Assert.NotNull(workspaceResources.ShareResources());
		}

	}

}