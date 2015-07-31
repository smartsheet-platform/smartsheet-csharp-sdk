using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smartsheet.Api;
using Smartsheet.Api.Models;
using System.Configuration;

namespace IntegrationTestSDK
{
	[TestClass]
	public class HomeResourcesTest
	{

		[TestMethod]
		public void TestHomeResources()
		{
			string accessToken = ConfigurationManager.AppSettings["accessToken"];

			SmartsheetClient smartsheet = new SmartsheetBuilder().SetAccessToken(accessToken).Build();
						
			Home home = smartsheet.HomeResources().GetHome(new SourceInclusion[] { SourceInclusion.SOURCE });

			Assert.IsTrue(home != null);
		}
	}
}