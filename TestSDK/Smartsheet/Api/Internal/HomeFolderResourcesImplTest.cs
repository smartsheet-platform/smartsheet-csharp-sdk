using System.Collections.Generic;

namespace Smartsheet.Api.Internal
{
	using NUnit.Framework;




	using DefaultHttpClient = Smartsheet.Api.Internal.Http.DefaultHttpClient;
	using Folder = Smartsheet.Api.Models.Folder;

	public class HomeFolderResourcesImplTest : ResourcesImplBase
	{

		private HomeFolderResourcesImpl homeFolderResources;

		[SetUp]
		public virtual void SetUp()
		{
			homeFolderResources = new HomeFolderResourcesImpl(new SmartsheetImpl("http://localhost:9090/1.1/", 
                "accessToken", new DefaultHttpClient(), serializer));
		}

		[Test]
		public virtual void TestHomeFolderResourcesImpl()
		{
		}

		[Test]
		public virtual void TestListFolders()
		{
			server.ResponseBody = "../../../TestSDK/resources/listFolders.json";

			IList<Folder> folders = homeFolderResources.ListFolders();

			Assert.True(folders.Count == 2);
			Assert.AreEqual("Personal", folders[0].Name);
			Assert.AreEqual("Expenses", folders[1].Name);
			Assert.True(1138268709382020L == folders[0].ID);
		}

		[Test]
		public virtual void TestCreateFolder()
		{
			server.ResponseBody = "../../../TestSDK/resources/createFolders.json";

			Folder folder = new Folder();
			folder.Name = "Hello World";

			Folder newFolder = homeFolderResources.CreateFolder(folder);
			Assert.True(6821399500220292L == newFolder.ID);
			Assert.AreEqual("hello world", newFolder.Name);
		}
	}

}