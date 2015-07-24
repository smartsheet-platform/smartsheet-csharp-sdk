using System.Collections.Generic;
using System;

namespace Smartsheet.Api.Internal
{
	using NUnit.Framework;

	using DefaultHttpClient = Smartsheet.Api.Internal.Http.DefaultHttpClient;
	using Api.Models;
	using System.IO;

	public class SheetResourcesImplTest : ResourcesImplBase
	{
		internal SheetResourcesImpl sheetResource;

		[SetUp]
		public virtual void SetUp()
		{
			// Create a folder resource
			sheetResource = new SheetResourcesImpl(new SmartsheetImpl("http://localhost:9090/1.1/", "accessToken", new DefaultHttpClient(), serializer));
		}

		[Test]
		public virtual void TestListSheets()
		{

			server.setResponseBody("../../../TestSDK/resources/listSheets.json");

			PaginatedResult<Sheet> result = sheetResource.ListSheets(null, null);
			Assert.AreEqual(2, result.Data.Count);
		}

		//List all Org Sheets is in UserResources which is not yet implemented
		//[Test]
		//public virtual void TestListOrganizationSheets()
		//{

		//	server.setResponseBody("../../../TestSDK/resources/listOrgSheets.json");
		//	IList<Sheet> sheets = sheetResource.ListOrganizationSheets();
		//	Assert.AreEqual(2, sheets.Count);
		//}

		[Test]
		public virtual void TestGetSheet()
		{

			server.setResponseBody("../../../TestSDK/resources/getSheet.json");
			Sheet sheet = sheetResource.GetSheet(123123L, null, null, null, null, null, null, null);
			Assert.AreEqual(2, sheet.Columns.Count);
			Assert.AreEqual(0, sheet.Rows.Count);
		}

		[Test]
		public virtual void TestGetSheetAsExcel()
		{
			string file = "../../../TestSDK/resources/getExcel.xls";
			server.setResponseBody(file);
			server.ContentType = "application/vnd.ms-excel";

			MemoryStream ms = new MemoryStream();
			BinaryWriter output = new BinaryWriter(ms);
			sheetResource.GetSheetAsExcel(1234L, output);

			Assert.NotNull(output);
			Assert.True(ms.ToArray().Length > 0);

			byte[] original = File.ReadAllBytes(file);
			Assert.AreEqual(original.Length, ms.Length);
		}

		[Test]
		public virtual void TestGetSheetAsPDF()
		{
			string file = "../../../TestSDK/resources/getPDF.pdf";
			server.setResponseBody(file);
			server.ContentType = "application/pdf";

			BinaryWriter output = new BinaryWriter(new MemoryStream());

			sheetResource.GetSheetAsPDF(1234L, output, null);

			Assert.NotNull(output, "Downloaded PDF is null.");
			Assert.True(output.BaseStream.Length > 0, "Downloaded PDF is empty.");
			Assert.AreEqual(107906, output.BaseStream.Length, "Downloaded PDF does not match the original size.");

			//test a larger PDF
			file = "../../../TestSDK/resources/large_sheet.pdf";
			server.setResponseBody(file);
			server.ContentType = "application/pdf";
			MemoryStream ms = new MemoryStream();
			output = new BinaryWriter(ms);
			sheetResource.GetSheetAsPDF(1234L, output, PaperSize.LEGAL);
			Assert.NotNull(output, "Downloaded PDF is null.");
			Assert.True(ms.ToArray().Length > 0, "Downloaded PDF is empty.");
			Assert.AreEqual(936995, ms.ToArray().Length, "Downloaded PDF does not match the original size.");
		}

		[Test]
		public virtual void TestCreateSheet()
		{
			server.setResponseBody("../../../TestSDK/resources/createSheet.json");

			Sheet sheet = new Sheet();
			sheet.Name = "NEW TEST SHEET";
			List<Column> list = new List<Column>();
			Column col = new Column();
			col.Primary = true;
			col.Title = "column1";
			col.Type = ColumnType.TEXT_NUMBER;
			list.Add(col);
			col = new Column();
			col.Title = "column2";
			col.Type = ColumnType.TEXT_NUMBER;
			list.Add(col);

			sheet.Columns = list;
			Sheet newSheet = sheetResource.CreateSheet(sheet);

			if (newSheet.Columns.Count != 2)
			{
				Assert.Fail("Issue creating a sheet");
			}
		}

		[Test]
		public virtual void TestCreateSheetFromExisting()
		{

			server.setResponseBody("../../../TestSDK/resources/createSheetFromExisting.json");

			Sheet sheet = new Sheet.CreateFromTemplateBuilder(2906571706525572L, "bleh").Build();

			Sheet newSheet = sheetResource.CreateSheetFromTemplate(sheet, null);

			Assert.AreEqual(466343087630212L, (long)newSheet.Id);
			Assert.AreEqual(AccessLevel.OWNER, newSheet.AccessLevel);
			Assert.AreEqual("https://app.smartsheet.com/b/home?lx=asdf", newSheet.Permalink);

			newSheet = sheetResource.CreateSheetFromTemplate(sheet, null);
			Assert.AreEqual(466343087630212L, (long)newSheet.Id);
			Assert.AreEqual(AccessLevel.OWNER, newSheet.AccessLevel);
			Assert.AreEqual("https://app.smartsheet.com/b/home?lx=asdf", newSheet.Permalink);

		}

		//[Test]
		//public virtual void TestCreateSheetInFolder()
		//{
		//	server.setResponseBody("../../../TestSDK/resources/createSheet.json");

		//	Sheet sheet = new Sheet();
		//	sheet.Name = "NEW TEST SHEET";
		//	List<Column> list = new List<Column>();
		//	Column col = new Column();
		//	col.Primary = true;
		//	col.Title = "column1";
		//	col.Type = ColumnType.TEXT_NUMBER;
		//	list.Add(col);
		//	col = new Column();
		//	col.Title = "column2";
		//	col.Type = ColumnType.TEXT_NUMBER;
		//	col.ID = 4049365800118148L;
		//	list.Add(col);

		//	sheet.Columns = list;
		//	Sheet newSheet = sheetResource.CreateSheetInFolder(12345L, sheet);

		//	Assert.AreEqual(2, newSheet.Columns.Count);
		//	Assert.AreEqual(col,newSheet.GetColumnByIndex(1));
		//	Assert.AreNotEqual(col, newSheet.GetColumnByIndex(0));
		//	Assert.Null((new Sheet()).GetColumnByIndex(100));
		//	Assert.AreEqual(col,newSheet.GetColumnById(4049365800118148L));
		//	Assert.AreNotEqual(col,newSheet.GetColumnById(4032471613368196L));
		//	Assert.Null((new Sheet()).GetColumnById(100));
		//}

		//[Test]
		//public virtual void TestCreateSheetInFolderFromExisting()
		//{

		//	server.setResponseBody("../../../TestSDK/resources/createSheetFromExisting.json");

		//	Sheet sheet = new Sheet();
		//	sheet.FromId = 2906571706525572L;
		//		Sheet newSheet = sheetResource.CreateSheetInFolderFromTemplate(1234L, sheet, 
		//			new List<ObjectInclusion>((ObjectInclusion[])Enum.GetValues(typeof(ObjectInclusion))));

		//	if (newSheet.ID.ToString().Length == 0 || newSheet.AccessLevel != AccessLevel.OWNER || newSheet.Permalink.ToString().Length == 0)
		//	{
		//		Assert.Fail("Sheet not correctly copied");
		//	}

		//	newSheet = sheetResource.CreateSheetInFolderFromTemplate(1234L, sheet, null);
		//}

		//[Test]
		//public virtual void TestCreateSheetInWorkspace()
		//{
		//	server.setResponseBody("../../../TestSDK/resources/createSheet.json");

		//	Sheet sheet = new Sheet();
		//	sheet.Name = "NEW TEST SHEET";
		//	List<Column> list = new List<Column>();
		//	Column col = new Column();
		//	col.Primary = true;
		//	col.Title = "column1";
		//	col.Type = ColumnType.TEXT_NUMBER;
		//	list.Add(col);
		//	col = new Column();
		//	col.Title = "column2";
		//	col.Type = ColumnType.TEXT_NUMBER;
		//	list.Add(col);

		//	sheet.Columns = list;
		//	Sheet newSheet = sheetResource.CreateSheetInWorkspace(1234L, sheet);
		//	Assert.AreEqual(2, newSheet.Columns.Count);
		//}

		//[Test]
		//public virtual void TestCreateSheetInWorkspaceFromExisting()
		//{
		//	server.setResponseBody("../../../TestSDK/resources/createSheetFromExisting.json");

		//	Sheet sheet = new Sheet();
		//	sheet.FromId = 2906571706525572L;
		//	Sheet newSheet = sheetResource.CreateSheetInWorkspaceFromTemplate(1234L, sheet, 
		//		new List<ObjectInclusion>((ObjectInclusion[])Enum.GetValues(typeof(ObjectInclusion))));

		//	Assert.AreEqual(466343087630212L, (long)newSheet.ID);
		//	Assert.AreEqual(AccessLevel.OWNER, newSheet.AccessLevel);
		//	Assert.AreEqual("https://app.smartsheet.com/b/home?lx=asdf",newSheet.Permalink);

		//	newSheet = sheetResource.CreateSheetInWorkspaceFromTemplate(1234L, sheet, null);
		//}

		[Test]
		public virtual void TestDeleteSheet()
		{
			server.setResponseBody("../../../TestSDK/resources/deleteSheet.json");
			sheetResource.DeleteSheet(1234L);
		}

		[Test]
		public virtual void TestUpdateSheet()
		{
			server.setResponseBody("../../../TestSDK/resources/updateSheet.json");

			Sheet sheet = new Sheet.UpdateSheetBuilder().SetName("new name").Build();
			Sheet newSheet = sheetResource.UpdateSheet(123, sheet);

			Assert.AreEqual("new name", newSheet.Name, "Sheet update (rename) failed.");
		}

		//[Test]
		//public virtual void TestGetSheetVersion()
		//{
		//	server.setResponseBody("../../../TestSDK/resources/getSheetVersion.json");
		//	int? version = sheetResource.GetSheetVersion(1234L);
		//	if (version != 1)
		//	{
		//		Assert.Fail("Issue getting sheet version");
		//	}
		//}

		//[Test]
		//public virtual void TestSendSheet()
		//{
		//	server.setResponseBody("../../../TestSDK/resources/sendEmails.json");

		//	string[] emailAddress = new string[] { "someemail@somewhere.com" };
		//	SheetEmail email = new SheetEmail();
		//	email.Format = SheetEmailFormat.PDF;
		//	FormatDetails format = new FormatDetails();
		//	format.PaperSize = PaperSize.A0;
		//	email.FormatDetails = format;
		//	email.To = new List<string>(emailAddress);
		//	sheetResource.SendSheet(1234L, email);
		//}

		[Test]
		public virtual void TestShares()
		{
			sheetResource.ShareResources();
		}

		[Test]
		public virtual void TestRows()
		{
			sheetResource.RowResources();
		}

		[Test]
		public virtual void TestColumns()
		{
			sheetResource.ColumnResources();
		}

		[Test]
		public virtual void TestAttachments()
		{
			sheetResource.AttachmentResources();
		}

		[Test]
		public virtual void TestDiscussions()
		{
			sheetResource.DiscussionResources();
		}

		//[Test]
		//public virtual void TestGetPublishStatus()
		//{
		//	server.setResponseBody("../../../TestSDK/resources/getPublishStatus.json");

		//	SheetPublish publishStatus = sheetResource.GetPublishStatus(1234L);

		//	if (publishStatus == null || publishStatus.ReadOnlyFullEnabled != false ||
		//		publishStatus.IcalEnabled != false || publishStatus.ReadOnlyLiteEnabled != false ||
		//		publishStatus.ReadWriteEnabled != false)
		//	{

		//		Assert.Fail("Issue creating the publish status object");
		//	}
		//}

		//[Test]
		//public virtual void TestUpdatePublishStatus()
		//{

		//	server.setResponseBody("../../../TestSDK/resources/setPublishStatus.json");

		//	SheetPublish publish = new SheetPublish();
		//	publish.IcalEnabled = true;
		//	publish.ReadOnlyFullEnabled = true;
		//	publish.ReadOnlyLiteEnabled = true;
		//	publish.ReadWriteEnabled = true;
		//	publish.IcalUrl = "http://somedomain.com";
		//	SheetPublish newPublish = sheetResource.UpdatePublishStatus(1234L, publish);

		//	Assert.Null(newPublish.IcalUrl);
		//	Assert.NotNull(newPublish.ReadOnlyFullUrl);
		//	Assert.NotNull(newPublish.ReadOnlyLiteUrl);
		//	Assert.NotNull(newPublish.ReadWriteUrl);

		//}
	}

}