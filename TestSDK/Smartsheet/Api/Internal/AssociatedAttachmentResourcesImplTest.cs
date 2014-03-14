using System.Collections.Generic;

namespace Smartsheet.Api.Internal
{
	using NUnit.Framework;




	using DefaultHttpClient = Smartsheet.Api.Internal.Http.DefaultHttpClient;
	using Attachment = Smartsheet.Api.Models.Attachment;
	using AttachmentParentType = Smartsheet.Api.Models.AttachmentParentType;
	using AttachmentSubType = Smartsheet.Api.Models.AttachmentSubType;
	using AttachmentType = Smartsheet.Api.Models.AttachmentType;

    [TestFixture]
	public class AssociatedAttachmentResourcesImplTest : ResourcesImplBase
	{

		private AssociatedAttachmentResourcesImpl associatedAttachment;

		[SetUp]
		public virtual void SetUp()
		{
			associatedAttachment = new AssociatedAttachmentResourcesImpl(new SmartsheetImpl(
                "http://localhost:9090/1.1/", "accessToken", new DefaultHttpClient(), serializer),"sheet");
		}

		[Test]
		public virtual void TestAssociatedAttachmentResourcesImpl()
		{
		}

		[Test]
		public virtual void TestListAttachments()
		{
            server.ResponseBody = "../../../TestSDK/resources/listAssociatedAttachments.json";

			IList<Attachment> attachments = associatedAttachment.ListAttachments(1234L);
			Assert.True(attachments.Count == 4);
			Assert.True(attachments[0].SizeInKb == 102400);
		}

		[Test]
		public virtual void TestAttachFile()
		{
			server.ResponseBody = @"..\..\..\TestSDK\resources\attachFile.json";
            string file = @"..\..\..\TestSDK\resources\large_sheet.pdf";
			Attachment attachment = associatedAttachment.AttachFile(1234L, file, "application/pdf");
			Assert.True(attachment.ID == 7265404226692996L);
			Assert.AreEqual("Testing.PDF", attachment.Name);
			Assert.AreEqual(AttachmentType.FILE, attachment.AttachmentType);
			Assert.AreEqual("application/pdf", attachment.MimeType);
			Assert.True(1831L == attachment.SizeInKb);
			Assert.AreEqual(AttachmentParentType.SHEET, attachment.ParentType);
		}

		[Test]
		public virtual void TestAttachURL()
		{
			server.ResponseBody = @"..\..\..\TestSDK\resources\attachLink.json";

			Attachment attachment = new Attachment();
			attachment.Url = "http://www.smartsheet.com/sites/all/themes/blue_sky/logo.png";
			attachment.AttachmentType = AttachmentType.LINK;
			attachment.UrlExpiresInMillis = 1L;
			attachment.AttachmentSubType = AttachmentSubType.PDF;

			Attachment newAttachment = associatedAttachment.AttachURL(1234L, attachment);
			Assert.AreEqual("http://www.smartsheet.com/sites/all/themes/blue_sky/logo.png", newAttachment.Name);
			Assert.AreEqual(AttachmentType.LINK, newAttachment.AttachmentType);
		}
	}

}