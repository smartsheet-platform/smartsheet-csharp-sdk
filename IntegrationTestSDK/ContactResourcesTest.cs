using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smartsheet.Api;
using Smartsheet.Api.Models;
using System.Configuration;

namespace IntegrationTestSDK
{
	using NUnit.Framework;

	public class ContactResourcesTest
	{

		[Test]
		public void TestContactResources()
		{
			string accessToken = ConfigurationManager.AppSettings["accessToken"];

			SmartsheetClient smartsheet = new SmartsheetBuilder().SetAccessToken(accessToken).Build();
			
			PaginatedResult<Contact> contactResults = smartsheet.ContactResources.ListContacts(null);
			Assert.IsTrue(contactResults.TotalCount >= 0);
		}
	}
}