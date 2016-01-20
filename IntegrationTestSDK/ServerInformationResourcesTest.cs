using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smartsheet.Api;
using Smartsheet.Api.Models;
using System.Collections.Generic;
using System.Configuration;

namespace IntegrationTestSDK
{
	using NUnit.Framework;

	public class ServerInformationResourcesTest
	{

		[Test]
		public void TestServerInfoResources()
		{
			string accessToken = ConfigurationManager.AppSettings["accessToken"];

			SmartsheetClient smartsheet = new SmartsheetBuilder().SetAccessToken(accessToken).Build();

			ServerInfo info = smartsheet.ServerInfoResources.GetServerInfo();
			Assert.IsTrue(info.FeatureInfo != null);
			Assert.IsTrue(info.Formats != null);
			Assert.IsTrue(info.SupportedLocales != null);

		}
	}
}