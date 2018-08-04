﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smartsheet.Api;
using Smartsheet.Api.Models;
using System.Configuration;

namespace IntegrationTestSDK
{
    [TestClass]
    public class AttachmentResourcesTest
    {
        string path = "../../../IntegrationTestSDK/TestFile.txt";

        [TestMethod]
        public void TestAttachmentResources()
        {
            SmartsheetClient smartsheet = new SmartsheetBuilder().SetMaxRetryTimeout(30000).Build();
            long sheetId = CreateSheet(smartsheet);

            long discussionId = AttachFileAndUrlToComment(smartsheet, sheetId);

            ListDiscussionAttachments(smartsheet, sheetId, discussionId);

            long rowId = AttachFileAndUrlToRow(smartsheet, sheetId);

            ListRowAttachments(smartsheet, sheetId, rowId);

            long attachmentId = AttachFileAndUrlToSheet(smartsheet, sheetId);

            GetAttachment(smartsheet, sheetId, attachmentId);

            AttachNewVersion(smartsheet, sheetId, attachmentId);

            ListAttachmentVersions(smartsheet, sheetId, attachmentId);

            DeleteAttachment(smartsheet, sheetId, attachmentId);

            smartsheet.SheetResources.DeleteSheet(sheetId);
        }

        private static void ListAttachmentVersions(SmartsheetClient smartsheet, long sheetId, long attachmentId)
        {
            PaginatedResult<Attachment> attachmentVersions = smartsheet.SheetResources.AttachmentResources.VersioningResources.ListVersions(sheetId, attachmentId);
            Assert.IsTrue(attachmentVersions.Data.Count == 2);
        }

        private void AttachNewVersion(SmartsheetClient smartsheet, long sheetId, long attachmentId)
        {
            smartsheet.SheetResources.AttachmentResources.VersioningResources.AttachNewVersion(sheetId, attachmentId, path, "text/plain");
        }

        private static void ListRowAttachments(SmartsheetClient smartsheet, long sheetId, long rowId)
        {
            PaginatedResult<Attachment> attachments = smartsheet.SheetResources.RowResources.AttachmentResources.ListAttachments(sheetId, rowId);
            Assert.IsTrue(attachments.Data.Count == 2);
        }

        private static void ListDiscussionAttachments(SmartsheetClient smartsheet, long sheetId, long discussionId)
        {
            PaginatedResult<Attachment> attachments = smartsheet.SheetResources.DiscussionResources.AttachmentResources.ListAttachments(sheetId, discussionId);
            Assert.IsTrue(attachments.Data.Count == 2);
        }

        private static void DeleteAttachment(SmartsheetClient smartsheet, long sheetId, long attachmentId)
        {
            smartsheet.SheetResources.AttachmentResources.DeleteAttachment(sheetId, attachmentId);
            try
            {
                smartsheet.SheetResources.AttachmentResources.GetAttachment(sheetId, attachmentId);
                Assert.Fail("Cannot get deleted attachment.");
            }
            catch
            {
                //Not Found.
            }
        }

        private void GetAttachment(SmartsheetClient smartsheet, long sheetId, long attachmentId)
        {
            Attachment attachment = smartsheet.SheetResources.AttachmentResources.GetAttachment(sheetId, attachmentId);
            Assert.IsTrue(attachment.Name == "TestFile.txt");
        }

        private long AttachFileAndUrlToSheet(SmartsheetClient smartsheet, long sheetId)
        {
            Attachment attachToResource = new Attachment.CreateAttachmentBuilder("http://www.smartsheet.com", AttachmentType.LINK).Build();
            Attachment attachment = smartsheet.SheetResources.AttachmentResources.AttachUrl(sheetId, attachToResource);
            Assert.IsTrue(attachment.Url == "http://www.smartsheet.com");

            attachment = smartsheet.SheetResources.AttachmentResources.AttachFile(sheetId, path);
            Assert.IsTrue(attachment.AttachmentType == AttachmentType.FILE);
            Assert.IsTrue(attachment.Name == "TestFile.txt");


            return attachment.Id.Value;
        }

        private long AttachFileAndUrlToRow(SmartsheetClient smartsheet, long sheetId)
        {
            Row[] rows = new Row[] { new Row.AddRowBuilder(toTop: true).Build() };
            smartsheet.SheetResources.RowResources.AddRows(sheetId, rows);
            Sheet sheet = smartsheet.SheetResources.GetSheet(sheetId);
            long rowId = sheet.Rows[0].Id.Value;
            Attachment attachment = smartsheet.SheetResources.RowResources.AttachmentResources.AttachFile(sheetId, rowId, path);
            Assert.IsTrue(attachment.AttachmentType == AttachmentType.FILE);
            Assert.IsTrue(attachment.Name == "TestFile.txt");

            Attachment attachToResource = new Attachment.CreateAttachmentBuilder("http://www.bing.com", AttachmentType.LINK).Build();
            attachment = smartsheet.SheetResources.RowResources.AttachmentResources.AttachUrl(sheetId, rowId, attachToResource);
            Assert.IsTrue(attachment.Url == "http://www.bing.com");

            return rowId;
        }

        private long AttachFileAndUrlToComment(SmartsheetClient smartsheet, long sheetId)
        {
            Discussion discussionToCreate = new Discussion.CreateDiscussionBuilder("A Disc", new Comment.AddCommentBuilder("A comm").Build()).Build();
            Discussion discussionCreated = smartsheet.SheetResources.DiscussionResources.CreateDiscussion(sheetId, discussionToCreate);
            long commentId = discussionCreated.Comments[0].Id.Value;
            Attachment attachment = smartsheet.SheetResources.CommentResources.AttachmentResources.AttachFile(sheetId, commentId, path, "text/plain");
            Assert.IsTrue(attachment.AttachmentType == AttachmentType.FILE);
            Assert.IsTrue(attachment.Name == "TestFile.txt");

            Attachment attachToResource = new Attachment.CreateAttachmentBuilder("http://www.google.com", AttachmentType.LINK).Build();
            attachment = smartsheet.SheetResources.CommentResources.AttachmentResources.AttachUrl(sheetId, commentId, attachToResource);
            Assert.IsTrue(attachment.Url == "http://www.google.com");

            return discussionCreated.Id.Value;
        }

        private static long CreateSheet(SmartsheetClient smartsheet)
        {
            Column[] columnsToCreate = new Column[] {
            new Column.CreateSheetColumnBuilder("col 1", primary: true, type: ColumnType.TEXT_NUMBER).Build(),
            new Column.CreateSheetColumnBuilder("col 2", primary: false, type: ColumnType.DATE).Build(),
            new Column.CreateSheetColumnBuilder("col 3", primary: false, type: ColumnType.TEXT_NUMBER).Build(),
            };
            Sheet createdSheet = smartsheet.SheetResources.CreateSheet(new Sheet.CreateSheetBuilder("new sheet", columnsToCreate).Build());
            Assert.IsTrue(createdSheet.Columns.Count == 3);
            Assert.IsTrue(createdSheet.Columns[1].Title == "col 2");
            return createdSheet.Id.Value;
        }
    }
}