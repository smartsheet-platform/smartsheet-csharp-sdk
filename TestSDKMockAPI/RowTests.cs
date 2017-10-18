using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smartsheet.Api;
using Smartsheet.Api.Models;
using Smartsheet.Api.Internal.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;

namespace TestSDKMockAPI
{
    [TestClass]
    public class RowTests
    {
        [TestMethod]
        public void UpdateRows()
        {
            SmartsheetClient ss = SetupClient("Update Rows");
            // Specify updated cell values for first row
            Cell[] cellsA = new Cell[] {
                new Cell.UpdateCellBuilder(
                    8888888888888888,                               // long columnId
                    "Red Fruit")                                    // value
                .Build(),
                new Cell.UpdateCellBuilder(9999999999999999, "Apple")       // long columnId, value
                .Build()
            };

            // Specify updated contents of first row
            Row rowA = new Row.UpdateRowBuilder(2222222222222222)       // long rowId
                .SetCells(cellsA)
                .Build();

            // Specify updated cell values for second row
            Cell[] cellsB = new Cell[] {
                new Cell.UpdateCellBuilder(8888888888888888, "Yellow Fruit")
                    .Build(),
                new Cell.UpdateCellBuilder(9999999999999999, "Banana")
                    .Build()
            };

            // Specify updated contents of second row
            Row rowB = new Row.UpdateRowBuilder(3333333333333333)       // long rowId
                .SetCells(cellsB)
                .Build();

            // Update rows in sheet
            IList<Row> updatedRows = ss.SheetResources.RowResources.UpdateRows(
                1111111111111111,                                       // long sheetId
                new Row[] { rowA, rowB }                                // IEnumerable<Row> rowsToUpdate
            );
            Assert.AreEqual(updatedRows.Count, 2);
            Assert.IsNotNull(updatedRows[1].Cells[1].DisplayValue);
        }

        public SmartsheetClient SetupClient(string testScenario)
        {
            SmartsheetClient ss = new SmartsheetBuilder()
            .SetBaseURI("http://localhost:8080/")
            .SetAccessToken("aaaaaaaaaaaaaaaaaaaaaaaaaa")
            .SetSDKTestScenario(testScenario)
            .Build();

            return ss;
        }
    }
}
