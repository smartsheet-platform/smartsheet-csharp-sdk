using System;
using System.Collections.Generic;

namespace Smartsheet.Api.Internal
{
	using NUnit.Framework;

	using DefaultHttpClient = Smartsheet.Api.Internal.Http.DefaultHttpClient;
	using Attachment = Smartsheet.Api.Models.Attachment;
	using Comment = Smartsheet.Api.Models.Comment;
	using Discussion = Smartsheet.Api.Models.Discussion;
	using User = Smartsheet.Api.Models.User;
	using System.Net;

	public class AssociatedDiscussionResourcesImplTest : ResourcesImplBase
	{

		//private AssociatedDiscussionResourcesImpl discussionResources;

		//[SetUp]
		//public virtual void SetUp()
		//{
		//	discussionResources = new AssociatedDiscussionResourcesImpl(new SmartsheetImpl("http://localhost:9090/1.1/", "accessToken", new DefaultHttpClient(), serializer),"sheet");
		//}

		//[Test]
		//public virtual void TestAssociatedDiscussionResourcesImpl()
		//{
		//}

		//[Test]
		//public virtual void TestCreateDiscussion()
		//{
		//		server.setResponseBody("../../../TestSDK/resources/createDiscussion.json");

		//	// Test success
		//	IList<Comment> comments = new List<Comment>();
		//	Comment comment = new Comment();
		//	comment.Text = "This is a test.";
		//	comment.Attachments = new List<Attachment>();
		//	comments.Add(comment);
		//	Discussion discussion = new Discussion();
		//	discussion.Title = "New Discussion";
		//	discussion.Comments = comments;
		//	discussion.LastCommentedUser = new User();
		//	discussion.LastCommentedAt = DateTime.Now;
		//	discussion.CommentAttachments = new List<Attachment>();
		//	Discussion newDiscussion = discussionResources.CreateDiscussion(1234L, discussion);

		//	Assert.NotNull(newDiscussion.Comments);
		//	Assert.True(newDiscussion.Comments.Count == 1);
		//	Assert.AreEqual("Brett Batie", newDiscussion.Comments[0].CreatedBy.Name);
		//	Assert.AreEqual("email@email.com", newDiscussion.Comments[0].CreatedBy.Email);


		//	// Test failure - CreatedBy not allowed & only one comment can be added when creating a discussion.
		//		server.Status = HttpStatusCode.BadRequest;
		//		server.setResponseBody("../../../TestSDK/resources/createDiscussion_1032.json");
		//	comment = new Comment();
		//	User user = new User();
		//	user.Name = "John Doe";
		//	user.Email = "email@email.com";
		//	comment.CreatedBy = user;
		//	comment.Text = "This is a test.";
		//	comments.Add(comment);
		//	discussion.Comments = comments;
		//	try
		//	{
		//		discussionResources.CreateDiscussion(1234L, discussion);
		//		Assert.Fail("An exception should have been thrown");
		//	}
		//	catch (InvalidRequestException)
		//	{
		//		// expected
		//	}
		//}

	}

}