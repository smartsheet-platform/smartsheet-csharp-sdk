using System.Collections.Generic;

namespace Smartsheet.Api.Internal
{
	using NUnit.Framework;
	using Smartsheet.Api.Models;
	using DefaultHttpClient = Smartsheet.Api.Internal.Http.DefaultHttpClient;
	using Folder = Smartsheet.Api.Models.Folder;

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

			// Set a fake response
			server.setResponseBody("../../../TestSDK/resources/getFolder.json");

			//server.getClass().getClassLoader().getResourceAsStream(
			//		"com/smartsheet/api/internal/getFolder.json"

			// Send the request for a folder

			//folderResource.getSmartsheet().getHttpClient().close();

			Folder folder = folderResource.GetFolder(123L, new List<ObjectInclusion>{ObjectInclusion.ATTACHMENTS});
			//folder.setTemplates(new ArrayList<Template>());
			//folder.setWorkspaces(new ArrayList<Workspace>());
			//folderResource.GetFolder(123L, null);

			// Verify results
			Assert.AreEqual("Projects", folder.Name);
			Assert.AreEqual(1, folder.Sheets.Count);
			Assert.AreEqual(0, folder.Folders.Count);
		}

		[Test]
		public virtual void TestUpdateFolder()
		{
			server.setResponseBody("../../../TestSDK/resources/updateFolder.json");

			Folder newFolder = new Folder();
			newFolder.Name = "New Name";
			newFolder.ID = 1138268709382020L;

			Folder resultFolder = folderResource.UpdateFolder(newFolder);

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

			IList<Folder> folders = folderResource.ListFolders(12345L);
			Assert.AreEqual(2, folders.Count);
		}

		[Test]
		public virtual void TestCreateFolder()
		{
			server.setResponseBody("../../../TestSDK/resources/createFolder.json");

			Folder newFolder = new Folder();
			newFolder.Name = "new folder by brett";
			Folder createdFolder = folderResource.CreateFolder(123L, newFolder);

			Assert.AreEqual(createdFolder.Name, newFolder.Name);

		}

	}

}