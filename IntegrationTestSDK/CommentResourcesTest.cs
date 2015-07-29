using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smartsheet.Api;
using Smartsheet.Api.Models;

namespace IntegrationTestSDK
{
	[TestClass]
	public class CommentResourcesTest
	{
		string path = "../../../IntegrationTestSDK/TestFile.txt";


		[TestMethod]
		public void TestCommentResources()
		{
			SmartsheetClient smartsheet = new SmartsheetBuilder().SetAccessToken("47ieup4lwsu9nj34j7kitol7nb").Build();
			long sheetId = CreateSheet(smartsheet);
			long discussionId = CreateDiscussion(smartsheet, sheetId);


			AddCommentWithoutAttachment(smartsheet, sheetId, discussionId);


			long commentId = AddCommentWithAttachment(smartsheet, sheetId, discussionId);

			GetComment(smartsheet, sheetId, commentId);

			DeleteComment(smartsheet, sheetId, commentId);

			smartsheet.SheetResources().DeleteSheet(sheetId);
		}

		private static void DeleteComment(SmartsheetClient smartsheet, long sheetId, long commentId)
		{

			smartsheet.SheetResources().CommentResources().DeleteComment(sheetId, commentId);
			try
			{
				smartsheet.SheetResources().CommentResources().GetComment(sheetId, commentId);
				Assert.Fail("Cannot get deleted comment");
			}
			catch
			{
				//Not found.
			}
		}

		private static void GetComment(SmartsheetClient smartsheet, long sheetId, long commentId)
		{
			Comment getComment = smartsheet.SheetResources().CommentResources().GetComment(sheetId, commentId);
			Assert.IsTrue(getComment.Id.Value == commentId);
			Assert.IsTrue(getComment.Text == "commented2");
		}

		private long AddCommentWithAttachment(SmartsheetClient smartsheet, long sheetId, long discussionId)
		{
			Comment addedCommentWithAttachment = smartsheet.SheetResources().DiscussionResources().CommentResources()
			.AddCommentWithAttachment(sheetId, discussionId, new Comment.AddCommentBuilder("commented2").Build(), path, null);
			//Assert.IsTrue(addedCommentWithAttachment.DiscussionId == discussionId);
			Assert.IsTrue(addedCommentWithAttachment.Text == "commented2");
			Assert.IsTrue(addedCommentWithAttachment.Attachments.Count == 1);
			Assert.IsTrue(addedCommentWithAttachment.Attachments[0].Name == "TestFile.txt");
			long commentId = addedCommentWithAttachment.Id.Value;
			return commentId;
		}

		private static void AddCommentWithoutAttachment(SmartsheetClient smartsheet, long sheetId, long discussionId)
		{
			Comment addedComment = smartsheet.SheetResources().DiscussionResources().CommentResources()
			.AddComment(sheetId, discussionId, new Comment.AddCommentBuilder("commented").Build());
			//Assert.IsTrue(addedComment.DiscussionId == discussionId);
			Assert.IsTrue(addedComment.Text == "commented");
		}

		private static long CreateDiscussion(SmartsheetClient smartsheet, long sheetId)
		{
			Comment commentToAdd = new Comment.AddCommentBuilder("this is a comment").Build();
			Discussion discussion = smartsheet.SheetResources().DiscussionResources().CreateDiscussion(sheetId, new Discussion.CreateDiscussionBuilder("a discussion", commentToAdd).Build());
			long discussionId = discussion.Id.Value;
			return discussionId;
		}
		private static long CreateSheet(SmartsheetClient smartsheet)
		{
			Column[] columnsToCreate = new Column[] {
			new Column.CreateSheetColumnBuilder("col 1", true, ColumnType.TEXT_NUMBER).Build(),
			new Column.CreateSheetColumnBuilder("col 2", false, ColumnType.DATE).Build(),
			new Column.CreateSheetColumnBuilder("col 3", false, ColumnType.TEXT_NUMBER).Build(),
			};
			Sheet createdSheet = smartsheet.SheetResources().CreateSheet(new Sheet.CreateSheetBuilder("new sheet", columnsToCreate).Build());
			Assert.IsTrue(createdSheet.Columns.Count == 3);
			Assert.IsTrue(createdSheet.Columns[1].Title == "col 2");
			return createdSheet.Id.Value;
		}
	}
}