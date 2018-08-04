using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smartsheet.Api;
using Smartsheet.Api.Models;
using System.IO;
using System.Configuration;

namespace IntegrationTestSDK
{
    [TestClass]
    public class SheetResourcesTest
    {
        [TestMethod]
        public void TestSheetResources()
        {
            SmartsheetClient smartsheet = new SmartsheetBuilder().SetMaxRetryTimeout(30000).Build();
            long sheetId = CreateSheet(smartsheet);
            SendSheet(smartsheet, sheetId);
            UpdateSheet(smartsheet, sheetId);
            UpdatePublishSheetStatus(smartsheet, sheetId);
            GetSheetAsPDF(smartsheet, sheetId);
            SortSheet(smartsheet, sheetId);
            DeleteSheet(smartsheet, sheetId);
        }

        private static void DeleteSheet(SmartsheetClient smartsheet, long sheetId)
        {
            smartsheet.SheetResources.DeleteSheet(sheetId);
            try
            {
                smartsheet.SheetResources.GetSheet(sheetId);
                Assert.Fail("Exception should have been thrown because Sheet should have been deleted.");
            }
            catch
            {
                //Not found.
            }
        }

        private static void GetSheetAsPDF(SmartsheetClient smartsheet, long sheetId)
        {
            BinaryWriter writer = new BinaryWriter(new MemoryStream());
            smartsheet.SheetResources.GetSheetAsPDF(sheetId, writer, PaperSize.A3);
            //smartsheet.SheetResources.GetSheetAsExcel(sheetId, writer);
            //smartsheet.SheetResources.GetSheetAsCSV(sheetId, writer);
        }

        private static void UpdatePublishSheetStatus(SmartsheetClient smartsheet, long sheetId)
        {
            SheetPublish sheetPublish = smartsheet.SheetResources.UpdatePublishStatus(
                sheetId,
                new SheetPublish.PublishStatusBuilder(
                    readOnlyLiteEnabled: true,
                    readOnlyFullEnabled: false,
                    readWriteEnabled: false,
                    icalEnabled: false
                ).Build()
            );
            Assert.IsTrue(sheetPublish.ReadOnlyLiteEnabled.Value);
            Assert.IsTrue(!sheetPublish.ReadOnlyFullEnabled.Value);
        }

        private static void UpdateSheet(SmartsheetClient smartsheet, long sheetId)
        {
            Sheet updatedSheet = smartsheet.SheetResources.UpdateSheet(new Sheet.UpdateSheetBuilder(sheetId).SetName("updated sheet").Build());
            Assert.IsTrue(updatedSheet.Name == "updated sheet");
        }

        private static void SendSheet(SmartsheetClient smartsheet, long sheetId)
        {
            SheetEmail sheetEmail = new SheetEmail { SendTo = new Recipient[] { new Recipient { Email = "eric.yan@smartsheet.com" } }, Subject = "Subject", Format = SheetEmailFormat.PDF };
            smartsheet.SheetResources.SendSheet(sheetId, sheetEmail);
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

            Cell cellA = new Cell.AddCellBuilder((long)createdSheet.Columns[0].Id, value: "A").SetStrict(false).Build();
            Cell cellB = new Cell.AddCellBuilder((long)createdSheet.Columns[0].Id, value: "B").SetStrict(false).Build();
            Cell cellC = new Cell.AddCellBuilder((long)createdSheet.Columns[0].Id, value: "C").SetStrict(false).Build();
            Row rowA = new Row.AddRowBuilder(toTop: true).SetCells(new Cell[] { cellA }).Build();
            Row rowB = new Row.AddRowBuilder(toTop: true).SetCells(new Cell[] { cellB }).Build();
            Row rowC = new Row.AddRowBuilder(toTop: true).SetCells(new Cell[] { cellC }).Build();
            smartsheet.SheetResources.RowResources.AddRows((long)createdSheet.Id, new Row[] { rowA, rowB, rowC });
        
            return createdSheet.Id.Value;
        }

        private static void SortSheet(SmartsheetClient smartsheet, long sheetId)
        {
            Sheet sheet = smartsheet.SheetResources.GetSheet(sheetId);
            SortSpecifier specifier = new SortSpecifier();
            SortCriterion criterion = new SortCriterion();
            criterion.ColumnId = (long)sheet.Columns[0].Id;
            criterion.Direction = SortDirection.DESCENDING;
            specifier.SortCriteria = new SortCriterion[] { criterion };
            sheet = smartsheet.SheetResources.SortSheet(sheetId, specifier);
            Assert.AreEqual(sheet.Rows[0].Cells[0].DisplayValue, "C");
        }
    }
}