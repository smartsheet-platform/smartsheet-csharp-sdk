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
			Comment comment = new Comment.AddCommentBuilder().SetText("sddfhghjhjgherdh AAAA").Build();
			server.setResponseBody("../../../TestSDK/resources/addComment.json");
			commentResources.AddComment(8357140688594820, 5773448686397316, comment, file, "application/msword");

		}
	}
}