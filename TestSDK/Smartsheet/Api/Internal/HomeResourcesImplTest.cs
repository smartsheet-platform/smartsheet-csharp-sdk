using System.Collections.Generic;

namespace Smartsheet.Api.Internal
{
	using NUnit.Framework;





	using DefaultHttpClient = Smartsheet.Api.Internal.Http.DefaultHttpClient;
	using Home = Smartsheet.Api.Models.Home;
	using ObjectInclusion = Smartsheet.Api.Models.ObjectInclusion;
	using Template = Smartsheet.Api.Models.Template;

	public class HomeResourcesImplTest : ResourcesImplBase
	{

		private HomeResourcesImpl homeResources;

		[SetUp]
		public virtual void SetUp()
		{
			homeResources = new HomeResourcesImpl(new SmartsheetImpl("http://localhost:9090/1.1/", "accessToken", new DefaultHttpClient(), serializer));
		}

		[Test]
		public virtual void TestHomeResourcesImpl()
		{
		}
		[Test]
		public virtual void TestGetHome()
		{
			server.setResponseBody("../../../TestSDK/resources/getHome.json");

			IList<Home> homes = new List<Home>();
			homes.Add(homeResources.GetHome(new ObjectInclusion[]{ObjectInclusion.TEMPLATES}));
			homes.Add(homeResources.GetHome(null));
			foreach (Home home in homes)
			{
				Assert.NotNull(home.Sheets);
				Assert.True(home.Sheets.Count == 7);
				Assert.NotNull(home.Folders);
				Assert.True(home.Folders.Count == 5);
				Assert.NotNull(home.Workspaces);
				Assert.True(home.Workspaces.Count == 7);
				Assert.Null(home.Templates);
				home.Templates = new List<Template>();
			}
		}

		//[Test]
		//public virtual void TestFolders()
		//{
		//	server.setResponseBody("../../../TestSDK/resources/getHomeFolders.json");

		//	HomeFolderResources folders = homeResources.Folders();
		//	Assert.NotNull(folders.ListFolders());
		//	Assert.True(folders.ListFolders().Count == 5);
		//}

	}

}