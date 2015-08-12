namespace Smartsheet.Api.Internal
{
	using NUnit.Framework;
	using Smartsheet.Api.Models;
	using DefaultHttpClient = Smartsheet.Api.Internal.Http.DefaultHttpClient;

	public class ContactResourcesImplTest : ResourcesImplBase
	{

		private ContactResources contactResources;

		[SetUp]
		public virtual void SetUp()
		{
			contactResources = new ContactResourcesImpl(new SmartsheetImpl("http://localhost:9090/1.1/", "accessToken", new DefaultHttpClient(), serializer));
		}

		[Test]
		public virtual void TestGetContact()
		{
			server.setResponseBody("../../../TestSDK/resources/getContact.json");

			Contact contact = contactResources.GetContact("123");

			Assert.AreEqual(contact.Email, "dd@example.com");
			Assert.AreEqual(contact.Name, "David Davidson");
			Assert.AreEqual(contact.Id, "AAAAATYU54QAD7_fNhTnhA");
		}

		[Test]
		public virtual void TestListContacts()
		{
			server.setResponseBody("../../../TestSDK/resources/listContacts.json");

			PaginatedResult<Contact> contactsResult = contactResources.ListContacts(new PaginationParameters(true, null, null));

			Assert.AreEqual(contactsResult.TotalCount, 2);
			Assert.AreEqual(contactsResult.Data[0].Name, "David Davidson");
			Assert.AreEqual(contactsResult.Data[1].Name, "Ed Edwin");
			Assert.AreEqual(contactsResult.Data[1].Id, "AAAAATYU54QAH7_fNhTnhA");
			Assert.AreEqual(contactsResult.Data[1].Email, "ee@example.com");

		}
	}

}