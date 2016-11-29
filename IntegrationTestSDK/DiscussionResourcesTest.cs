using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smartsheet.Api;
using Smartsheet.Api.Models;
using System.Collections.Generic;
using System.Configuration;

namespace IntegrationTestSDK
{
	using NUnit.Framework;
	
	public class DiscussionResourcesTest
	{
		[Test]
		public void TestDiscussionResources()
		{
			string accessToken = ConfigurationManager.AppSettings["accessToken"];

			SmartsheetClient smartsheet = new SmartsheetBuilder().SetAccessToken(accessToken).Build(); long sheetId = CreateSheet(smartsheet);

			Discussion discussionToCreate = new Discussion.CreateDiscussionBuilder("A discussion", new Comment.AddCommentBuilder("a comment").Build()).Build();
			Discussion createdDiscussion = smartsheet.SheetResources.DiscussionResources.CreateDiscussion(sheetId, discussionToCreate);
			long createdDiscussionId = createdDiscussion.Id.Value;
			string path = "../../../IntegrationTestSDK/TestFile.txt";
			Discussion createdDiscussionWithFile = smartsheet.SheetResources.DiscussionResources.CreateDiscussionWithAttachment(sheetId, discussionToCreate, path, null);
			Assert.IsTrue(createdDiscussionWithFile.Comments[0].Attachments[0].Name == "TestFile.txt");


			PaginatedResult<Discussion> discussions = smartsheet.SheetResources.DiscussionResources.ListDiscussions(sheetId, new DiscussionInclusion[] { DiscussionInclusion.COMMENTS, DiscussionInclusion.ATTACHMENTS }, null);
			Assert.IsTrue(discussions.TotalCount == 2);
			Assert.IsTrue(discussions.Data.Count == 2);
			Assert.IsTrue(discussions.Data[0].Id.Value == createdDiscussion.Id.Value || discussions.Data[0].Id.Value == createdDiscussionWithFile.Id.Value);
			Assert.IsTrue(discussions.Data[1].Id.Value == createdDiscussion.Id.Value || discussions.Data[1].Id.Value == createdDiscussionWithFile.Id.Value);


			Discussion getDiscussionWithFile = smartsheet.SheetResources.DiscussionResources.GetDiscussion(sheetId, createdDiscussionWithFile.Id.Value);
			Assert.IsTrue(getDiscussionWithFile.Title == "A discussion");
			Assert.IsTrue(getDiscussionWithFile.Comments.Count == 1);
			Assert.IsTrue(getDiscussionWithFile.Comments[0].Attachments.Count == 1);
			Assert.IsTrue(getDiscussionWithFile.Comments[0].Attachments[0].Name == "TestFile.txt");

			Row row = new Row.AddRowBuilder(true, null, null, null, null).Build();
			IList<Row> rows = smartsheet.SheetResources.RowResources.AddRows(sheetId, new Row[] { row });
			Assert.IsTrue(rows.Count == 1);
			Assert.IsTrue(rows[0].Id.HasValue);
			long rowId = rows[0].Id.Value;
			Comment comment = new Comment.AddCommentBuilder("a comment!").Build();
			Discussion discussionToCreateOnRow = new Discussion.CreateDiscussionBuilder("discussion on row", comment).Build();
			Discussion discussionCreatedOnRow = smartsheet.SheetResources.RowResources.DiscussionResources.CreateDiscussionWithAttachment(sheetId, rowId, discussionToCreateOnRow, path, null);
			PaginatedResult<Discussion> discussionsOnRow = smartsheet.SheetResources.RowResources.DiscussionResources
			.ListDiscussions(sheetId, rowId, new DiscussionInclusion[] { DiscussionInclusion.COMMENTS }, null);
			Assert.IsTrue(discussionsOnRow.Data.Count == 1);
			Assert.IsTrue(discussionsOnRow.Data[0].Title == "discussion on row");
			Assert.IsTrue(discussionsOnRow.Data[0].Comments[0].Text == "discussion on row\n\na comment!");
		}

		private static long CreateSheet(SmartsheetClient smartsheet)
		{
			Column[] columnsToCreate = new Column[] {
			new Column.CreateSheetColumnBuilder("col 1", true, ColumnType.TEXT_NUMBER).Build(),
			new Column.CreateSheetColumnBuilder("col 2", false, ColumnType.DATE).Build(),
			new Column.CreateSheetColumnBuilder("col 3", false, ColumnType.TEXT_NUMBER).Build(),
			};
			Sheet createdSheet = smartsheet.SheetResources.CreateSheet(new Sheet.CreateSheetBuilder("new sheet", columnsToCreate).Build());
			Assert.IsTrue(createdSheet.Columns.Count == 3);
			Assert.IsTrue(createdSheet.Columns[1].Title == "col 2");
			return createdSheet.Id.Value;
		}
	}
}