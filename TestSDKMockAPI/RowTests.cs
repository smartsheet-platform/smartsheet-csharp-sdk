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
        public void UpdateRows_AssignValues()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Update Rows - Assign Values");
          
            Row rowA = new Row{
                Id = 10,
                Cells = new List<Cell>
                {
                    new Cell{
                        ColumnId = 101,
                        Value = "Apple"
                    },
                    new Cell{
                        ColumnId = 102,
                        Value = "Red Fruit"
                    }
                }
            };
               
            Row rowB = new Row{
                Id = 11,
                Cells = new List<Cell>
                {
                    new Cell{
                        ColumnId = 101,
                        Value = "Banana"
                    },
                    new Cell{
                        ColumnId = 102,
                        Value = "Yellow Fruit"
                    }
                }
            };

            // Update rows in sheet
            IList<Row> updatedRows = ss.SheetResources.RowResources.UpdateRows(1,new Row[] { rowA, rowB });

            Row row = updatedRows.Where(r => r.Id == 10).FirstOrDefault();
            Cell cell = row.Cells.Where(c => c.Value.Equals("Apple")).FirstOrDefault();

            Assert.AreEqual(cell.ColumnId, 101);
        }


        [TestMethod]
        public void UpdateRows_AssignFormulae()
        {
            SmartsheetClient ss =  HelperFunctions.SetupClient("Update Rows - Assign Formulae");

            Row rowA = new Row
            {
                Id = 11,
                Cells = new List<Cell>
                {
                    new Cell{
                        ColumnId = 101,
                        Formula = "=SUM([Column2]3, [Column2]4)*2"
                    },
                    new Cell{
                        ColumnId = 102,
                        Formula = "=SUM([Column2]3, [Column2]3, [Column2]4)"
                    }
                }
            };

            IList<Row> updatedRows = ss.SheetResources.RowResources.UpdateRows(1, new Row[] { rowA });

            Cell cell = updatedRows[0].Cells.Where(c => c.Formula.Equals("=SUM([Column2]3, [Column2]3, [Column2]4)")).FirstOrDefault();

            Assert.AreEqual(cell.ColumnId, 102);
        }


        [TestMethod]
        [ExpectedException(typeof(SmartsheetException), 
            "If cell.formula is specified, then value, objectValue, image, hyperlink, and linkInFromCell must not be specified.")]
        public void UpdateRows_Invalid_AssignValueAndFormulae()
        {
            SmartsheetClient ss =  HelperFunctions.SetupClient("Update Rows - Invalid - Assign Value and Formulae");

            Row rowA = new Row
            {
                Id = 10,
                Cells = new List<Cell>
                {
                    new Cell{
                        ColumnId = 101,
                        Formula = "=SUM([Column2]3, [Column2]4)*2",
                        Value = "20"

                    },
                    new Cell{
                        ColumnId = 102,
                        Formula = "=SUM([Column2]3, [Column2]3, [Column2]4)"
                    }
                }
            };

            ss.SheetResources.RowResources.UpdateRows(1, new Row[] { rowA });
            //No assert defined as the exception expected is what is being tested.
        }
    }
}
