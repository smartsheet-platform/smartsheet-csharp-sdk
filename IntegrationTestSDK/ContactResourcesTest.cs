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
			string accessToken = ConfigurationManager.AppSettings["accessToken"];

			SmartsheetClient smartsheet = new SmartsheetBuilder().SetAccessToken(accessToken).Build();
			
			PaginatedResult<Contact> contactResults = smartsheet.ContactResources.ListContacts(null);
			bool foundContact = false;
			foreach (Contact contact in contactResults.Data)
			{
				if (contact.Email == "eric.yan@smartsheet.com")
				{
					foundContact = true;
					string contactId = contact.Id;
					Contact getContact = smartsheet.ContactResources.GetContact(contactId);
					Assert.IsTrue(getContact.Email == "eric.yan@smartsheet.com");
				}
			}
			Assert.IsTrue(foundContact);
		}
	}
}