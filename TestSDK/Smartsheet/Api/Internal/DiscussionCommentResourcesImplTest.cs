namespace Smartsheet.Api.Internal
{
	using NUnit.Framework;
	using DefaultHttpClient = Smartsheet.Api.Internal.Http.DefaultHttpClient;
	using Comment = Smartsheet.Api.Models.Comment;
	using Discussion = Smartsheet.Api.Models.Discussion;


	public class DiscussionCommentResourcesImplTest : ResourcesImplBase
	{

		private DiscussionCommentResourcesImpl commentResources;

		[SetUp]
		public virtual void SetUp()
		{
			commentResources = new DiscussionCommentResourcesImpl(new SmartsheetImpl("http://localhost:9090/1.1/",
					"accessToken", new DefaultHttpClient(), serializer));
		}


		[Test]
		public virtual void TestAddCommentWithAttachment()
		{
			string file = @"..\..\..\TestSDK\resources\wordFile.docx";
			Comment comment = new Comment.AddCommentBuilder().SetText("This is a new comment.").Build();
			server.setResponseBody("../../../TestSDK/resources/addCommentWithAttachment.json");
			commentResources.AddCommentWithAttachment(8357140688594820, 5773448686397316, comment, file, "application/msword");

			//Will not be able to deserialize (wIll throw error) unless Attachment object is also updated.
			//Assset TO-DO
		}

		[Test]
		public virtual void TestAddComment()
		{
			Comment comment = new Comment.AddCommentBuilder().SetText("This is a new comment.").Build();
			server.setResponseBody("../../../TestSDK/resources/addComment.json");
			comment = commentResources.AddComment(8357140688594820, 5773448686397316, comment);

			Assert.IsTrue(comment.CreatedBy.Email == "john.doe@smartsheet.com");
			Assert.IsTrue(comment.ID == 6834973207488388);
			Assert.IsTrue(comment.Text == "This is a new comment.");

		}
	}
}