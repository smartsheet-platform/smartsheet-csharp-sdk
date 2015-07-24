using System.Collections.Generic;

namespace Smartsheet.Api.Internal
{
	using NUnit.Framework;
	using Smartsheet.Api.Models;
	using DefaultHttpClient = Smartsheet.Api.Internal.Http.DefaultHttpClient;

	public class FolderResourcesImplTest : ResourcesImplBase
	{
		FolderResourcesImpl folderResource;

		[SetUp]
		public virtual void SetUp()
		{
			// Create a folder resource
			folderResource = new FolderResourcesImpl(new SmartsheetImpl(
				"http://localhost:9090/1.1/", "accessToken", new DefaultHttpClient(), serializer));
		}

		[Test]
		public virtual void TestFolderResourcesImpl()
		{
		}

		[Test]
		public virtual void TestGetFolder()
		{
			// Test will fail unless Sheet is implemented to API2.0 because of Sheet.Source
			// Set a fake response
			server.setResponseBody("../../../TestSDK/resources/getFolder.json");

			// User can get Folder by specifying a list of FolderInclude enum values or specifying null.
			Folder folder = folderResource.GetFolder(123L, new List<SourceInclusion> { SourceInclusion.SOURCE });

			// Verify results
			Assert.AreEqual("Projects", folder.Name);
			Assert.AreEqual(9, folder.Sheets.Count);
			Assert.AreEqual(1, folder.Folders.Count);
			//Uncomment below once Sheet is implemented with Source object to test whether Source test validates.
			//Assert.AreEqual(6075276170946436, folder.Sheets[0].Source.ID);

		}

		[Test]
		public virtual void TestUpdateFolder()
		{
			server.setResponseBody("../../../TestSDK/resources/updateFolder.json");

			Folder newFolder = new Folder.UpdateFolderBuilder("New name for folder").Build();

			Folder resultFolder = folderResource.UpdateFolder(1486948649985924, newFolder);

			Assert.AreEqual(resultFolder.Name, newFolder.Name);
		}

		[Test]
		public virtual void TestDeleteFolder()
		{

			server.setResponseBody("../../../TestSDK/resources/deleteFolder.json");

			folderResource.DeleteFolder(7752230582413188L);
		}

		[Test]
		public virtual void TestListFolders()
		{

			server.setResponseBody("../../../TestSDK/resources/listFolders.json");

			PaginatedResult<Folder> result = folderResource.ListFolders(12345L, new PaginationParameters(false, null, null));
			Assert.AreEqual(2, result.Data.Count);
		}

		[Test]
		public virtual void TestCreateFolder()
		{
			server.setResponseBody("../../../TestSDK/resources/createFolder.json");

			Folder newFolder = new Folder.CreateFolderBuilder("New folder").Build();
			Folder createdFolder = folderResource.CreateFolder(123L, newFolder);

			Assert.AreEqual(createdFolder.Name, newFolder.Name);

		}

	}

}