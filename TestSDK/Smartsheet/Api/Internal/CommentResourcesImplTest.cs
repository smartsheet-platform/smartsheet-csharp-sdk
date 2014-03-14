namespace Smartsheet.Api.Internal
{
	using NUnit.Framework;




	using DefaultHttpClient = Smartsheet.Api.Internal.Http.DefaultHttpClient;
	using Comment = Smartsheet.Api.Models.Comment;

	public class CommentResourcesImplTest : ResourcesImplBase
	{

		private CommentResourcesImpl commentResources;

		[SetUp]
		public virtual void SetUp()
		{
			commentResources = new CommentResourcesImpl(new SmartsheetImpl("http://localhost:9090/1.1/", "accessToken", new DefaultHttpClient(), serializer));
		}

		[Test]
		public virtual void TestCommentResourcesImpl()
		{
		}

		[Test]
		public virtual void TestGetComment()
		{
			server.ResponseBody = "../../../TestSDK/resources/getComment.json";

			Comment comment = commentResources.GetComment(1234L);
			Assert.AreEqual(3831661625403268L, (long)comment.ID);
			Assert.AreEqual("This text is the body of the first comment", comment.Text);
			Assert.AreEqual("Brett Batie",comment.CreatedBy.Name);
			Assert.AreEqual("email@email.com", comment.CreatedBy.Email);

			// Test equals method
			Comment newComment = new Comment();
			newComment.ID = 3831661625403268L;
			Assert.True(comment.GetHashCode() == newComment.GetHashCode());
		}

		[Test]
		public virtual void TestDeleteComment()
		{
			server.ResponseBody = "../../../TestSDK/resources/deleteComment.json";

			commentResources.DeleteComment(1234L);
		}

		[Test]
		public virtual void TestAttachments()
		{
			Assert.NotNull(commentResources.Attachments());
		}

	}

}