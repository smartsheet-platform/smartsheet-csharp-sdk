namespace Smartsheet.Api.Internal
{
	using NUnit.Framework;



	using DefaultHttpClient = Smartsheet.Api.Internal.Http.DefaultHttpClient;
	using Attachment = Smartsheet.Api.Models.Attachment;

	public class AttachmentResourcesImplTest : ResourcesImplBase
	{

		//private AttachmentResourcesImpl attachmentResourcesImpl;

		//[SetUp]
		//public virtual void SetUp()
		//{
		//	attachmentResourcesImpl = new AttachmentResourcesImpl(
		//			new SmartsheetImpl("http://localhost:9090/1.1/", "accessToken", 
		//				new DefaultHttpClient(), serializer));
		//}

		//[Test]
		//public virtual void TestAttachmentResourcesImpl()
		//{
		//}
		//[Test]
		//public virtual void TestGetAttachment()
		//{
		//		server.setResponseBody("../../../TestSDK/resources/getAttachment.json");

		//	Attachment attachment = attachmentResourcesImpl.GetAttachment(1234L);
		//	Assert.NotNull(attachment.Url);
		//	Assert.AreEqual("AbstractResources.mup",attachment.Name);
		//}

		//[Test]
		//public virtual void TestDeleteAttachment()
		//{
		//		server.setResponseBody("../../../TestSDK/resources/deleteAttachment.json");

		//	attachmentResourcesImpl.DeleteAttachment(1234L);
		//}

	}

}