namespace Smartsheet.Api.Internal
{
	using NUnit.Framework;



	using DefaultHttpClient = Smartsheet.Api.Internal.Http.DefaultHttpClient;

	public class CommentAttachmentResourcesTest : ResourcesImplBase
	{

		private CommentAttachmentResources commentAttachmentResource;

		[SetUp]
		public virtual void SetUp()
		{
			commentAttachmentResource = new CommentAttachmentResources(new SmartsheetImpl("http://localhost:9090/1.1/", "accessToken", new DefaultHttpClient(), serializer));
		}

		[Test]
		public virtual void TestCommentAttachmentResources()
		{
		}
		[Test]
		public virtual void TestListAttachments()
		{
			try
			{
				commentAttachmentResource.ListAttachments(1234L);
				Assert.Fail("Should have thrown an exception");
			}
			catch (System.NotSupportedException)
			{
				// Expected
			}
		}
	}

}