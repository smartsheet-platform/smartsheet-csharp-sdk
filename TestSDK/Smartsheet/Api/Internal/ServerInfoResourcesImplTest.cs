using System.Collections.Generic;

namespace Smartsheet.Api.Internal
{
	using NUnit.Framework;
	using Smartsheet.Api.Models;
	using DefaultHttpClient = Smartsheet.Api.Internal.Http.DefaultHttpClient;

	public class ServerInfoResourcesImplTest : ResourcesImplBase
	{

		private ServerInfoResourcesImpl serverInfoResources;

		[SetUp]
		public virtual void SetUp()
		{
			serverInfoResources = new ServerInfoResourcesImpl(new SmartsheetImpl("http://localhost:9090/1.1/", "accessToken", new DefaultHttpClient(), serializer));
		}

		[Test]
		public virtual void TestGetServerInfo()
		{
			server.setResponseBody("../../../TestSDK/resources/getServerInfo.json");
			 ServerInfo info = serverInfoResources.GetServerInfo();
			 Assert.True(info.SupportedLocales[6] == "en_NZ");
			 Assert.True(info.Formats != null);
		}

	}

}