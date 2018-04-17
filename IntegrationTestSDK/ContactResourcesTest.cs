using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smartsheet.Api;
using Smartsheet.Api.Models;
using System.Configuration;

namespace IntegrationTestSDK
{
	[TestClass]
	public class ContactResourcesTest
	{
		[TestMethod]
		public void TestContactResources()
		{
			SmartsheetClient smartsheet = new SmartsheetBuilder().SetMaxRetryTimeout(30000).Build();
			
			PaginatedResult<Contact> contactResults = smartsheet.ContactResources.ListContacts(null);
			Assert.IsTrue(contactResults.TotalCount >= 0);
		}
	}
}