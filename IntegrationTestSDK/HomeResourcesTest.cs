using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smartsheet.Api;
using Smartsheet.Api.Models;
using System.Configuration;

namespace IntegrationTestSDK
{
	using NUnit.Framework;

	public class HomeResourcesTest
	{

		[Test]
		public void TestHomeResources()
		{
			SmartsheetClient smartsheet = new SmartsheetBuilder().SetMaxRetryTimeout(30000).Build();

			Home home = smartsheet.HomeResources.GetHome(new HomeInclusion[] { HomeInclusion.SOURCE });

			Assert.IsTrue(home != null);
		}
	}
}