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
			string accessToken = ConfigurationManager.AppSettings["testAccessToken"];

			SmartsheetClient smartsheet = new SmartsheetBuilder().SetAccessToken(accessToken).SetBaseURI("https://api.test.smartsheet.com/2.0/").Build();

			// Must have contacts first or GetContact will fail.
			PaginatedResult<Contact> contactsResult = smartsheet.ContactResources.ListContacts(null);
			Assert.IsTrue(contactsResult.Data.Count > 0);
			string contactId = contactsResult.Data[0].Id;
			string contactName = contactsResult.Data[0].Name;
			string contactEmail = contactsResult.Data[0].Email;

			Contact contact = smartsheet.ContactResources.GetContact(contactId);
			Assert.IsTrue(contact.Email.Contains("@"));
			Assert.IsTrue(contact.Email.Contains(".com"));
			Assert.IsTrue(contact.Id == contactId);
			Assert.IsTrue(contact.Name == contactName);
			Assert.IsTrue(contact.Email == contactEmail);

		}

	}
}