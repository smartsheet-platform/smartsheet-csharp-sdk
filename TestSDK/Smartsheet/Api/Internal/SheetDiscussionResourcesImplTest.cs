using System.Collections.Generic;

namespace Smartsheet.Api.Internal
{
	using NUnit.Framework;
	using Smartsheet.Api.Models;
	using DefaultHttpClient = Smartsheet.Api.Internal.Http.DefaultHttpClient;


	public class SheetDiscussionResourcesImplTest : ResourcesImplBase
	{

		private SheetDiscussionResourcesImpl sheetDiscussionResourcesImpl;

		[SetUp]
		public virtual void SetUp()
		{
			sheetDiscussionResourcesImpl = new SheetDiscussionResourcesImpl(new SmartsheetImpl("http://localhost:9090/1.1/",
				"accessToken", new DefaultHttpClient(), serializer));
		}


		[Test]
		public virtual void TestListDiscussions()
		{
			server.setResponseBody("../../../TestSDK/resources/listDiscussions.json");

			// Will fail if Attachment object is not updated to API2.0 due to the property 'createdBy'
			// not yet implemented in the Attachment object
			DataWrapper<Discussion> result = sheetDiscussionResourcesImpl.ListDiscussions
			(1234L, new DiscussionInclusion[] { DiscussionInclusion.ATTACHMENTS }, null);
			Assert.True(result.Data[0].ID == 3138415114905476);
			Assert.True(result.Data[0].Title == "Lincoln");
			Assert.True(result.Data[0].Comments[0].ID == 7320407591151492);
			Assert.True(result.Data[0].Comments[0].Text == "16th President");
			Assert.True(result.Data[0].Comments[0].CreatedBy.Name == "Test User");
			Assert.True(result.Data[0].Comments[0].Attachments[0].Name == "test.html");
			Assert.True(result.Data[0].Comments[0].Attachments[0].AttachmentType == AttachmentType.FILE);
			Assert.True(result.Data[0].AccessLevel == AccessLevel.OWNER);
			Assert.True(result.Data[0].ParentId == 4508369022150532);
			Assert.True(result.Data[0].ReadOnly == false);
		}


		[Test]
		public virtual void TestGetDiscussion()
		{
			server.setResponseBody("../../../TestSDK/resources/getDiscussion.json");

			Discussion discussion = sheetDiscussionResourcesImpl.GetDiscussion(13654, 534654654);
			Assert.True(discussion.ID == 2331373580117892);
			Assert.True(discussion.Title == "This is a new discussion");
			Assert.True(discussion.Comments[0].Text == "This text is the body of the discussion");
		}


		[Test]
		public virtual void TestCreateDiscussion()
		{
			server.setResponseBody("../../../TestSDK/resources/createDiscussion.json");

			Comment comment = new Comment();
			comment.Text = "This text is the body of the first comment";
			Discussion discussion = new Discussion.CreateDiscussionBuilder("This is a new discussion", comment).Build();
			Discussion newDiscussion = sheetDiscussionResourcesImpl.CreateDiscussion(13654, discussion);
			Assert.True(discussion.Title == newDiscussion.Title);
			Assert.True(discussion.Comment.Text == newDiscussion.Comments[0].Text);
			Assert.True(newDiscussion.Comments[0].CreatedBy.Email == "jane.doev@smartsheet.com");
		}

		[Test]
		public virtual void TestCreateDiscussionWithAttachment()
		{
			// Will fail unless Attachment is properly implemented
			server.setResponseBody("../../../TestSDK/resources/createDiscussionWithAttachment.json");

			string file = @"..\..\..\TestSDK\resources\wordFile.docx";
			Comment comment = new Comment();
			comment.Text = "Please review the attached image.";
			Discussion discussion = new Discussion.CreateDiscussionBuilder("a title", comment).Build();
			Discussion newDiscussion = sheetDiscussionResourcesImpl.CreateDiscussionWithAttachment(13654, discussion, file, null);
			Assert.True(discussion.Title == newDiscussion.Title);
			Assert.True(discussion.Comment.Text == newDiscussion.Comments[0].Text);
			Assert.True(newDiscussion.Comments[0].CreatedBy.Email == "jane.doev@smartsheet.com");
			Assert.True(newDiscussion.Comments[0].Attachments[0].ParentId == 5706209564092292);
		}
	}
}