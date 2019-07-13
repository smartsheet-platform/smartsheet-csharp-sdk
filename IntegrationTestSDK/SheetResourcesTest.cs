using System.IO;
using System.Collections.Generic;
using Smartsheet.Api;
using Smartsheet.Api.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegrationTestSDK
{
    [TestClass]
    public class SheetResourcesTest : TestResources
    {
        private Sheet sheetHome;
        private Sheet newSheetHome;
        private Sheet newSheetTemplate;
        private Folder folder;
        private Workspace workspace;

        [TestInitialize]
        public void TestInitialize()
        {
            smartsheet = CreateClient();
        }

        [TestMethod]
        public void TestSheetResources()
        {
            TestCreateSheetHome();
            TestCopySheet();
            TestMoveSheet();
            TestCreateSheetHomeFromTemplate();
            TestCreateSheetInFolder();
            TestCreateSheetInFolderFromTemplate();
            TestCreateSheetInWorkspace();
            TestCreateSheetInWorkspaceFromTemplate();
            TestGetSheet();
            TestGetSheetVersion();
            TestGetSheetAsExcel();
            TestGetSheetAsPDF();
            TestGetPublishStatus();
            TestPublishSheetDefaults();
            TestPublishSheet();
            TestUpdateSheet();
            TestListSheets();
            TestSendSheet();
            TestCreateUpdateRequest();
            TestSortSheet();
            TestDeleteSheet();
        }

        private void TestCreateSheetHome()
        {
            sheetHome = CreateSheetObject();
            newSheetHome = smartsheet.SheetResources.CreateSheet(sheetHome);
            if(newSheetHome.Columns.Count != sheetHome.Columns.Count)
            {
                Assert.Fail("SheetResourcesTest.TestCreateSheetHome Failed to create sheet");
            }
        }

        private void TestCopySheet()
        {
            Folder folder = CreateFolderHome();

            ContainerDestination destination = new ContainerDestination();
            destination.DestinationType = DestinationType.FOLDER;
            destination.DestinationId = folder.Id;
            destination.NewName = "CSharp SDK Copied Sheet";
            Sheet sheet = smartsheet.SheetResources.CopySheet(newSheetHome.Id.Value, destination,
                new List<SheetCopyInclusion> { SheetCopyInclusion.ALL });
            Assert.IsTrue(sheet.Name == "CSharp SDK Copied Sheet");
            DeleteFolder(folder.Id.Value);
        }

        private void TestMoveSheet()
        {
            Folder folder = CreateFolderHome();
            Sheet sheet = smartsheet.SheetResources.CreateSheet(CreateSheetObject());

            ContainerDestination destination = new ContainerDestination();
            destination.DestinationType = DestinationType.FOLDER;
            destination.DestinationId = folder.Id;

            Sheet movedSheet = smartsheet.SheetResources.MoveSheet(sheet.Id.Value, destination);
            Assert.IsNotNull(movedSheet);
            DeleteSheet(movedSheet.Id.Value);
            DeleteFolder(folder.Id.Value);
        }

        private void TestCreateSheetHomeFromTemplate()
        {
            Sheet sheet = new Sheet.CreateSheetFromTemplateBuilder("CSharp SDK Sheet from Template", newSheetHome.Id.Value).Build();
            newSheetTemplate = smartsheet.SheetResources.CreateSheetFromTemplate(sheet,
                new List<TemplateInclusion> { TemplateInclusion.ATTACHMENTS, TemplateInclusion.DATA, TemplateInclusion.DISCUSSIONS });
            Assert.AreEqual(AccessLevel.OWNER, newSheetTemplate.AccessLevel);
        }

        private void TestCreateSheetInFolder()
        {
            folder = CreateFolderHome();
            Sheet newSheetFolder = smartsheet.FolderResources.SheetResources.CreateSheet(folder.Id.Value, sheetHome);

            if(newSheetFolder.Columns.Count != sheetHome.Columns.Count)
            {
                Assert.Fail("SheetResourcesTest.TestCreateSheetInFolder Failed to create sheet");
            }
        }

        private void TestCreateSheetInFolderFromTemplate()
        {
            Sheet sheet = new Sheet.CreateSheetFromTemplateBuilder("CSharp SDK Sheet from Template", newSheetHome.Id.Value).Build();
            Sheet newSheetFromTemplate = smartsheet.FolderResources.SheetResources.CreateSheetFromTemplate(folder.Id.Value, sheet, null);

            if(newSheetFromTemplate.Id.ToString().Length == 0 || newSheetFromTemplate.AccessLevel != AccessLevel.OWNER ||
                newSheetFromTemplate.Permalink.Length == 0)
            {
                Assert.Fail("SheetResourcesTest.TestCreateSheetInFolderFromTemplate Failed to create sheet");
            }
        }

        private void TestCreateSheetInWorkspace()
        {
            workspace = CreateWorkspace("CSharp Test Workspace");
            Sheet newSheet = smartsheet.WorkspaceResources.SheetResources.CreateSheet(workspace.Id.Value, sheetHome);
            Assert.AreEqual(sheetHome.Columns.Count, newSheet.Columns.Count);
        }

        private void TestCreateSheetInWorkspaceFromTemplate()
        {
            Sheet sheet = new Sheet.CreateSheetFromTemplateBuilder("CSharp SDK Sheet in Workspace from Template", newSheetHome.Id.Value).Build();
            Sheet newSheetFromTemplate = smartsheet.WorkspaceResources.SheetResources.CreateSheetFromTemplate(workspace.Id.Value, sheet,
                new List<TemplateInclusion> { TemplateInclusion.ATTACHMENTS, TemplateInclusion.DATA, TemplateInclusion.DISCUSSIONS });
            if (newSheetFromTemplate.Id.ToString().Length == 0 || newSheetFromTemplate.AccessLevel != AccessLevel.OWNER ||
                newSheetFromTemplate.Permalink.Length == 0)
            {
                Assert.Fail("SheetResourcesTest.TestCreateSheetInWorkspaceFromTemplate Failed to create sheet");
            }
        }

        private void TestGetSheet()
        {
            Sheet sheet = smartsheet.SheetResources.GetSheet(newSheetHome.Id.Value, null, null, null, null, null, null, null);
            Assert.AreEqual(sheet.Permalink, newSheetHome.Permalink);
        }

        private void TestGetSheetVersion()
        {
            int? version = smartsheet.SheetResources.GetSheetVersion(newSheetHome.Id.Value);
            if (version.Value != 1)
                Assert.Fail("SheetResourcesTest.TestGetSheetVersion GetSheetVersion incorrect");
        }

        private void TestGetSheetAsExcel()
        {
            BinaryWriter writer = new BinaryWriter(new MemoryStream());
            smartsheet.SheetResources.GetSheetAsExcel(newSheetHome.Id.Value, writer);
        }

        private void TestGetSheetAsPDF()
        {
            BinaryWriter writer = new BinaryWriter(new MemoryStream());
            smartsheet.SheetResources.GetSheetAsPDF(newSheetHome.Id.Value, writer, PaperSize.A3);
        }

        private void TestGetPublishStatus()
        {
            SheetPublish sheetPublish = smartsheet.SheetResources.GetPublishStatus(newSheetHome.Id.Value);
            Assert.IsNotNull(sheetPublish);
        }

        private void TestUpdateSheet()
        {
            Sheet sheet = new Sheet.UpdateSheetBuilder(newSheetHome.Id).SetName("CSharp SDK Updated Sheet").Build();
            Sheet newSheet = smartsheet.SheetResources.UpdateSheet(sheet);
            Assert.AreEqual(sheet.Name, newSheet.Name);
        }

        private void TestPublishSheetDefaults()
        {
            SheetPublish sheetPublish = new SheetPublish.PublishStatusBuilder(true, true, true, false).Build();
            SheetPublish newSheetPublish = smartsheet.SheetResources.UpdatePublishStatus(newSheetHome.Id.Value, sheetPublish);
            Assert.IsTrue(newSheetPublish.ReadWriteShowToolbar.Value);
        }

        private void TestPublishSheet()
        {
            SheetPublish sheetPublish = new SheetPublish();
            sheetPublish.IcalEnabled = false;
            sheetPublish.ReadOnlyFullEnabled = true;
            sheetPublish.ReadWriteEnabled = true;
            sheetPublish.ReadOnlyLiteEnabled = true;
            sheetPublish.ReadWriteShowToolbar = false;
            sheetPublish.ReadOnlyFullShowToolbar = false;
            SheetPublish newSheetPublish = smartsheet.SheetResources.UpdatePublishStatus(newSheetHome.Id.Value, sheetPublish);
            Assert.IsFalse(newSheetPublish.ReadWriteShowToolbar.Value);
            Assert.IsFalse(newSheetPublish.ReadOnlyFullShowToolbar.Value);
        }

        private void TestListSheets()
        {
            PaginationParameters pagination = new PaginationParameters(false, 1, 1);
            PaginatedResult<Sheet> sheets = smartsheet.SheetResources.ListSheets(new List<SheetInclusion> { SheetInclusion.SOURCE }, pagination);
            Assert.IsTrue(sheets.PageNumber == 1);
        }

        private void TestSendSheet()
        {
            List<Recipient> recipients = new List<Recipient>();
            Recipient recipient = new Recipient();
            recipient.Email = "test.user@smartsheet.com";
            recipients.Add(recipient);

            FormatDetails formatDetails = new FormatDetails();
            formatDetails.PaperSize = PaperSize.A4;

            SheetEmail email = new SheetEmail.CreateSheetEmail(recipients, SheetEmailFormat.PDF).SetFormatDetails(formatDetails).Build();
            smartsheet.SheetResources.SendSheet(newSheetHome.Id.Value, email);
        }

        private void TestCreateUpdateRequest()
        {
            Sheet sheet = smartsheet.SheetResources.CreateSheet(CreateSheetObject());

            PaginationParameters pagination = new PaginationParameters(true, null, null);
            PaginatedResult<Column> columns = smartsheet.SheetResources.ColumnResources.ListColumns(sheet.Id.Value, new List<ColumnInclusion> { ColumnInclusion.FILTERS }, pagination);

            Column addedColumn1 = columns.Data[0];
            Column addedColumn2 = columns.Data[1];

            List<Cell> cellsA = new List<Cell> { new Cell.AddCellBuilder(addedColumn1.Id.Value, true).Build(),
                new Cell.AddCellBuilder(addedColumn2.Id.Value, "new status").Build() };

            Row rowA = new Row.AddRowBuilder(null, true, null, null, null).SetCells(cellsA).Build();

            List<Cell> cellsB = new List<Cell> { new Cell.AddCellBuilder(addedColumn1.Id.Value, true).Build(),
                new Cell.AddCellBuilder(addedColumn2.Id.Value, "new status").Build() };

            Row rowB = new Row.AddRowBuilder(null, true, null, null, null).SetCells(cellsB).Build();

            IList<Row> newRows = smartsheet.SheetResources.RowResources.AddRows(sheet.Id.Value, new Row[] { rowA, rowB });

            List<Recipient> recipients = new List<Recipient>();
            Recipient recipient = new Recipient();
            recipient.Email = "test.user@smartsheet.com";
            recipients.Add(recipient);

            UpdateRequest updateRequest = new UpdateRequest();
            updateRequest.SendTo = recipients;
            updateRequest.Subject = "some subject";
            updateRequest.Message = "some message";
            updateRequest.CcMe = false;
            updateRequest.RowIds = new List<long> { newRows[0].Id.Value };
            updateRequest.ColumnIds = new List<long> { addedColumn2.Id.Value };
            updateRequest.IncludeAttachments = false;
            updateRequest.IncludeDiscussions = false;

            smartsheet.SheetResources.UpdateRequestResources.CreateUpdateRequest(sheet.Id.Value, updateRequest);

            DeleteSheet(sheet.Id.Value);
        }

        private void TestSortSheet()
        {
            Sheet sheet = smartsheet.SheetResources.CreateSheet(CreateSheetObject());
            Cell cellA = new Cell.AddCellBuilder(sheet.Columns[1].Id.Value, null).SetValue("A").SetStrict(false).Build();
            Cell cellB = new Cell.AddCellBuilder(sheet.Columns[1].Id.Value, null).SetValue("B").SetStrict(false).Build();
            Cell cellC = new Cell.AddCellBuilder(sheet.Columns[1].Id.Value, null).SetValue("C").SetStrict(false).Build();
            Row rowA = new Row.AddRowBuilder(true, null, null, null, null).SetCells(new Cell[] { cellA }).Build();
            Row rowB = new Row.AddRowBuilder(true, null, null, null, null).SetCells(new Cell[] { cellB }).Build();
            Row rowC = new Row.AddRowBuilder(true, null, null, null, null).SetCells(new Cell[] { cellC }).Build();
            smartsheet.SheetResources.RowResources.AddRows(sheet.Id.Value, new Row[] { rowA, rowB, rowC });

            SortSpecifier specifier = new SortSpecifier();
            SortCriterion criterion = new SortCriterion();
            criterion.ColumnId = sheet.Columns[1].Id.Value;
            criterion.Direction = SortDirection.DESCENDING;
            specifier.SortCriteria = new SortCriterion[] { criterion };
            sheet = smartsheet.SheetResources.SortSheet(sheet.Id.Value, specifier);
            Assert.AreEqual(sheet.Rows[0].Cells[1].DisplayValue, "C");

            DeleteSheet(sheet.Id.Value);
        }

        private void TestDeleteSheet()
        {
            smartsheet.SheetResources.DeleteSheet(newSheetHome.Id.Value);
            smartsheet.SheetResources.DeleteSheet(newSheetTemplate.Id.Value);
            DeleteWorkspace(workspace.Id.Value);
            DeleteFolder(folder.Id.Value);
        }
    }
}