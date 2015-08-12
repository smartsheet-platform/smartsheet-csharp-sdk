using System.Collections.Generic;

namespace Smartsheet.Api.Internal
{
	using NUnit.Framework;
	using Smartsheet.Api.Models;
	using DefaultHttpClient = Smartsheet.Api.Internal.Http.DefaultHttpClient;

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
			server.setResponseBody("../../../TestSDK/resources/listFoldersInHome.json");

			PaginatedResult<Folder> result = homeFolderResources.ListFolders(new PaginationParameters(false, null, null));

			Assert.True(result.Data.Count == 2);
			Assert.AreEqual("Folder 1", result.Data[0].Name);
			Assert.AreEqual("Folder 2", result.Data[1].Name);
			Assert.True(7116448184199044L == result.Data[0].Id);
		}

		[Test]
		public virtual void TestCreateFolder()
		{
			server.setResponseBody("../../../TestSDK/resources/createFolder.json");

			Folder folder = new Folder.CreateFolderBuilder("New folder").Build();

			Folder newFolder = homeFolderResources.CreateFolder(folder);
			Assert.True(1486948649985924L == newFolder.Id);
			Assert.AreEqual(folder.Name, newFolder.Name);
		}
	}

}