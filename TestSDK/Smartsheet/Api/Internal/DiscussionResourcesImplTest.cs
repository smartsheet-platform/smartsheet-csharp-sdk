namespace Smartsheet.Api.Internal
{
	using NUnit.Framework;
	using DefaultHttpClient = Smartsheet.Api.Internal.Http.DefaultHttpClient;
	using Comment = Smartsheet.Api.Models.Comment;
	using Discussion = Smartsheet.Api.Models.Discussion;

	public class DiscussionResourcesImplTest : ResourcesImplBase
	{

		private DiscussionResourcesImpl discussionResources;

		[SetUp]
		public virtual void SetUp()
		{
			discussionResources = new DiscussionResourcesImpl(new SmartsheetImpl("http://localhost:9090/1.1/", 
					"accessToken", new DefaultHttpClient(), serializer));
		}

		[Test]
		public virtual void TestDiscussionResourcesImpl()
		{
		}

		[Test]
		public virtual void TestGetDiscussion()
		{
			server.setResponseBody("../../../TestSDK/resources/getDiscussion.json");

			Discussion discussion = discussionResources.GetDiscussion(1234L);

			Assert.AreEqual("New Discussion", discussion.Title);
			Assert.NotNull(discussion.Comments);
			Assert.True(discussion.Comments.Count == 3);
			Assert.AreEqual("This text is the body of the first comment4", discussion.Comments[0].Text);
			Assert.NotNull(discussion.Comments[0].CreatedBy);
			Assert.AreEqual("Brett Batie", discussion.Comments[0].CreatedBy.Name);
			Assert.AreEqual("email@email.com", discussion.Comments[0].CreatedBy.Email);
		}

		//[Test]
		//public virtual void TestAddDiscussionComment()
		//{
		//	server.setResponseBody("../../../TestSDK/resources/addDiscussionComment.json");

		//	Comment comment = new Comment();
		//	comment.Text = "Some new Text";

		//	Comment newComment = discussionResources.AddDiscussionComment(1234L, comment);

		//	Assert.AreEqual("Some new text",newComment.Text);
		//	Assert.AreEqual("Brett Batie", newComment.CreatedBy.Name);
		//}

		//[Test]
		//public virtual void TestAttachments()
		//{
		//		server.setResponseBody("../../../TestSDK/resources/emptyFile.json");
		//	Assert.Null(discussionResources.Attachments());
		//}

	}

}