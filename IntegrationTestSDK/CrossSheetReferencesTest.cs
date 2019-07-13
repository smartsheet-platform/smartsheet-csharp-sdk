using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smartsheet.Api;
using Smartsheet.Api.Models;
using System.Collections.Generic;
using System.Configuration;

namespace IntegrationTestSDK
{
    [TestClass]
    public class CrossSheetReferencesTest : TestResources
    {
        private Sheet sheetA;
        private Sheet sheetB;
        private CrossSheetReference xref;

        [TestInitialize]
        public void Setup()
        {
            smartsheet = CreateClient();

            sheetA = smartsheet.SheetResources.CreateSheet(CreateSheetObject());
            sheetB = CreateSheet();
        }

        [TestCleanup]
        public void Cleanup()
        {
            DeleteSheet(sheetA.Id.Value);
            DeleteSheet(sheetB.Id.Value);
        }

        [TestMethod]
        public void TestCrossSheetReferences()
        {
            TestCreateCrossSheetReference();
            TestListCrossSheetReferences();
            TestGetCrossSheetReference();
        }

        private void TestCreateCrossSheetReference()
        {
            xref = new CrossSheetReference();
            xref.SourceSheetId = sheetB.Id.Value;
            xref.StartColumnId = sheetB.Columns[0].Id.Value;
            xref.EndColumnId = sheetB.Columns[0].Id.Value;
            xref.StartRowId = sheetB.Rows[0].Id.Value;
            xref.EndRowId = sheetB.Rows[0].Id.Value;
            xref = smartsheet.SheetResources.CrossSheetReferenceResources.CreateCrossSheetReference(sheetA.Id.Value, xref);
        }

        private void TestListCrossSheetReferences()
        {
            PaginationParameters pagination = new PaginationParameters(true, null, null);
            PaginatedResult<CrossSheetReference> xrefs = smartsheet.SheetResources.CrossSheetReferenceResources.ListCrossSheetReferences(sheetA.Id.Value, pagination);
            Assert.AreEqual(xrefs.Data[0].Id.Value, xref.Id.Value);
        }

        private void TestGetCrossSheetReference()
        {
            Sheet sheet = smartsheet.SheetResources.GetSheet(sheetA.Id.Value, new List<SheetLevelInclusion> { SheetLevelInclusion.CROSS_SHEET_REFERENCES }, null, null, null, null, null, null);
            Assert.IsTrue(sheet.CrossSheetReferences.Count == 1);

            CrossSheetReference _xref = smartsheet.SheetResources.CrossSheetReferenceResources.GetCrossSheetReference(sheetA.Id.Value, sheet.CrossSheetReferences[0].Id.Value);
        }
    }
}