using System.Collections.Generic;

namespace Smartsheet.Api.Internal
{
	using NUnit.Framework;
	using Smartsheet.Api.Models;
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
			server.setResponseBody("../../../TestSDK/resources/listWorkspaceFolders.json");

			DataWrapper<Folder> result = workspaceFolderResources.ListFolders(1234L, new PaginationParameters(false, 123, 117));
			Assert.AreEqual(2,result.Data.Count);
			Assert.AreEqual(7116448184188022L, (long)result.Data[1].ID);
			Assert.AreEqual("https://app.smartsheet.com/b/home?lx=9sljohj8jEXqvJIbTrK2Hb", result.Data[0].Permalink);

		}

		[Test]
		public virtual void TestCreateFolder()
		{
			server.setResponseBody("../../../TestSDK/resources/newWorkspaceFolder.json");

			Folder folder = new Folder();
			folder.Name = "New folder";
			Folder newFolder = workspaceFolderResources.CreateFolder(1234L, folder);
			Assert.AreEqual(1486948649985924L, (long)newFolder.ID);
			Assert.AreEqual("New folder", newFolder.Name);
		}

	}

}