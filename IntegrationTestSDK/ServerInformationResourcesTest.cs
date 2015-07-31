using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smartsheet.Api;
using Smartsheet.Api.Models;
using System.Collections.Generic;

namespace IntegrationTestSDK
{
	[TestClass]
	public class ServerInformationResourcesTest
	{

		[TestMethod]
		public void TestServerInfoResources()
		{
			SmartsheetClient smartsheet = new SmartsheetBuilder().SetAccessToken("47ieup4lwsu9nj34j7kitol7nb").Build();

			ServerInfo info = smartsheet.ServerInfoResources().GetServerInfo();
			Assert.IsTrue(info.FeatureInfo != null);
			Assert.IsTrue(info.Formats != null);
			Assert.IsTrue(info.SupportedLocales != null);

		}
	}
}