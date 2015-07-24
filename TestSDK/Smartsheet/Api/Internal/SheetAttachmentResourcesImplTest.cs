using System.Collections.Generic;

namespace Smartsheet.Api.Internal
{
	using NUnit.Framework;
	using Smartsheet.Api.Models;
	using System;
	using DefaultHttpClient = Smartsheet.Api.Internal.Http.DefaultHttpClient;

	public class SheetAttachmentResourcesImplTest : ResourcesImplBase
	{

		private SheetAttachmentResourcesImpl sheetAttachmentResource;

		[SetUp]
		public virtual void SetUp()
		{
			sheetAttachmentResource = new SheetAttachmentResourcesImpl(new SmartsheetImpl("http://localhost:9090/1.1/", "accessToken", new DefaultHttpClient(), serializer));
		}

		[Test]
		public virtual void TestAttachFile()
		{
			server.setResponseBody("../../../TestSDK/resources/attachWordFile.json");
			string file = @"..\..\..\TestSDK\resources\large_sheet.pdf";

			Attachment attachment = sheetAttachmentResource.AttachFile(56545654, file, "application/msword");
			Assert.IsTrue(attachment.AttachmentType == AttachmentType.FILE);
			Assert.IsTrue(attachment.CreatedAt == DateTime.Parse("2013-02-28T21:04:56-08:00"));
			Assert.IsTrue(attachment.Id == 4583173393803140);
			Assert.IsTrue(attachment.MimeType == "application/msword");
			Assert.IsTrue(attachment.Name == "ProgressReport.docx");
		}

		[Test]
		public virtual void TestAttachUrl()
		{
			server.setResponseBody("../../../TestSDK/resources/attachUrl.json");

			Attachment attachment = new Attachment.CreateAttachmentBuilder("http://www.google.com", AttachmentType.LINK)
			.SetName("Search Engine").SetDescription("A popular search engine").Build();
			Attachment newAttachment = sheetAttachmentResource.AttachUrl(56545654, attachment);
			Assert.IsTrue(newAttachment.AttachmentType == AttachmentType.LINK);
			Assert.IsTrue(newAttachment.CreatedAt.Value.ToUniversalTime() == DateTime.Parse("2013-02-28T21:52:40-08:00").ToUniversalTime());
			Assert.IsTrue(newAttachment.Id == 1205473673275268);
			Assert.IsTrue(newAttachment.Description == "A popular search engine");
			Assert.IsTrue(newAttachment.Name == "Search Engine");
			Assert.IsTrue(newAttachment.Url == "http://google.com");

		}


		[Test]
		public virtual void TestGetAttachment()
		{
			server.setResponseBody("../../../TestSDK/resources/getAttachment.json");
			Attachment attachment = sheetAttachmentResource.GetAttachment(56545654, 56464654);
			Assert.IsTrue(attachment.AttachmentType == AttachmentType.FILE);
			Assert.IsTrue(attachment.MimeType == "image/png");
			Assert.IsTrue(attachment.Id == 4583173393803140);
			Assert.IsTrue(attachment.Description == null);
			Assert.IsTrue(attachment.Name == "at3.png");
			Assert.IsTrue(attachment.Url == "URL_TO_ATTACHMENT");
			Assert.IsTrue(attachment.UrlExpiresInMillis == 120000);
		}

		[Test]
		public virtual void TestListAttachments()
		{
			server.setResponseBody("../../../TestSDK/resources/listAttachments.json");
			PaginatedResult<Attachment> result = sheetAttachmentResource.ListAttachments(56545654, null);
			Assert.IsTrue(result.Data[0].AttachmentType == AttachmentType.FILE);
			Assert.IsTrue(result.Data[0].MimeType == "image/png");
			Assert.IsTrue(result.Data[0].Id == 4583173393803140);
			Assert.IsTrue(result.Data[0].ParentType == AttachmentParentType.SHEET);
			Assert.IsTrue(result.Data[0].Name == "att3.png");
			Assert.IsTrue(result.Data[0].ParentId == 341847495283);

			Assert.IsTrue(result.Data[1].AttachmentType == AttachmentType.FILE);
			Assert.IsTrue(result.Data[1].MimeType == "image/png");
			Assert.IsTrue(result.Data[1].Id == 4583173393803140);
			Assert.IsTrue(result.Data[1].ParentType == AttachmentParentType.ROW);
			Assert.IsTrue(result.Data[1].Name == "att4.png");
			Assert.IsTrue(result.Data[1].ParentId == 684956754834557);
		}

		
	}

}