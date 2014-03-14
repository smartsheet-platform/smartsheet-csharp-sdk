using System.Collections.Generic;

namespace Smartsheet.Api.Internal
{
	using NUnit.Framework;



	using DefaultHttpClient = Smartsheet.Api.Internal.Http.DefaultHttpClient;
	using Folder = Smartsheet.Api.Models.Folder;

	public class WorkspaceFolderResourcesImplTest : ResourcesImplBase
	{

		private WorkspaceFolderResourcesImpl workspaceFolderResources;

		[SetUp]
		public virtual void SetUp()
		{
			workspaceFolderResources = new WorkspaceFolderResourcesImpl(new SmartsheetImpl("http://localhost:9090/1.1/", "accessToken", new DefaultHttpClient(), serializer));
		}

		[Test]
		public virtual void TestWorkspaceFolderResourcesImpl()
		{
		}
		[Test]
		public virtual void TestListFolders()
		{
			server.ResponseBody = "../../../TestSDK/resources/listWorkspaceFolders.json";

			IList<Folder> folders = workspaceFolderResources.ListFolders(1234L);
			Assert.AreEqual(1,folders.Count);
			Assert.AreEqual(4298196408133508L, (long)folders[0].ID);
			Assert.AreEqual("Human Resources", folders[0].Name);

		}

		[Test]
		public virtual void TestCreateFolder()
		{
			server.ResponseBody = "../../../TestSDK/resources/newWorkspaceFolder.json";

			Folder folder = new Folder();
			folder.Name = "New Folder";
			Folder newFolder = workspaceFolderResources.CreateFolder(1234L, folder);
			Assert.AreEqual(8121709439018884L, (long)newFolder.ID);
			Assert.AreEqual("New Folder", newFolder.Name);
		}

	}

}