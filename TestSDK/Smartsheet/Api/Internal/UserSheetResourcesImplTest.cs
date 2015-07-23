using System.Collections.Generic;
using System;

namespace Smartsheet.Api.Internal
{
	using NUnit.Framework;

	using DefaultHttpClient = Smartsheet.Api.Internal.Http.DefaultHttpClient;
	using Api.Models;
	using System.IO;

	public class UserSheetResourcesImplTest : ResourcesImplBase
	{
		internal UserSheetResources sheetResource;

		[SetUp]
		public virtual void SetUp()
		{
			// Create a folder resource
			sheetResource = new UserSheetResourcesImpl(new SmartsheetImpl("http://localhost:9090/1.1/", "accessToken", new DefaultHttpClient(), serializer));
		}

		[Test]
		public virtual void TestListAllOrgSheets()
		{
			server.setResponseBody("../../../TestSDK/resources/listOrgSheets.json");

			DataWrapper<Sheet> result = sheetResource.ListSheets();
			Assert.AreEqual(result.Data[0].Id, 2894323533539204);
			Assert.AreEqual(result.Data[0].Name, "New Sheet");
			Assert.AreEqual(result.Data[0].Owner, "john.doe@smartsheet.com");
			Assert.AreEqual(result.Data[0].OwnerId, 995857572373);
		}
	}

}