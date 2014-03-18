namespace Smartsheet.Api.Internal
{
	using NUnit.Framework;



	using DefaultHttpClient = Smartsheet.Api.Internal.Http.DefaultHttpClient;
	using Attachment = Smartsheet.Api.Models.Attachment;

	public class DiscussionAttachmentResourcesTest : ResourcesImplBase
	{

		private DiscussionAttachmentResources discussionAttachmentResources;

		[SetUp]
		public virtual void SetUp()
		{
			discussionAttachmentResources = new DiscussionAttachmentResources(new SmartsheetImpl("http://localhost:9090/1.1/", "accessToken", new DefaultHttpClient(), serializer));
		}

		[Test]
		public virtual void TestAttachFileLongFileString()
		{
			try
			{
				discussionAttachmentResources.AttachFile(1234L, "../../../TestSDK/resources/getPDF.pdf", "application/pdf");
				Assert.Fail("Exception should have been thrown.");
			}
			catch (System.NotSupportedException)
			{
				// Expected
			}
		}

		[Test]
		public virtual void TestAttachFileLongFileStringLong()
		{



			try
			{
				discussionAttachmentResources.AttachFile(1234L, "../../../TestSDK/resources/getPDF.pdf",
						"application/pdf", 1234L);
				Assert.Fail("Exception should have been thrown.");
			}
			catch (System.NotSupportedException)
			{
				// Expected
			}
		}

		[Test]
		public virtual void TestAttachURL()
		{
			try
			{
				discussionAttachmentResources.AttachURL(1234L, new Attachment());
				Assert.Fail("Exception should have been thrown.");
			}
			catch (System.NotSupportedException)
			{
				// Expected
			}
		}

		[Test]
		public virtual void TestDiscussionAttachmentResources()
		{
		}

	}

}