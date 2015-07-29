using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smartsheet.Api;
using Smartsheet.Api.Models;

namespace IntegrationTestSDK
{
	[TestClass]
	public class HomeResourcesTest
	{

		[TestMethod]
		public void TestHomeResources()
		{
			SmartsheetClient smartsheet = new SmartsheetBuilder().SetAccessToken("47ieup4lwsu9nj34j7kitol7nb").Build();
			
			Home home = smartsheet.HomeResources().GetHome(new SourceInclusion[] { SourceInclusion.SOURCE });

			Assert.IsTrue(home != null);
		}
	}
}