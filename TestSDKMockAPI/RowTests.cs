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
        public void AddRows_AssignValues_String()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Add Rows - Assign Values - String");

            Row rowA = new Row
            {
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

            Row rowB = new Row
            {
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
            IList<Row> addedRows = ss.SheetResources.RowResources.AddRows(1, new Row[] { rowA, rowB });

            Row row = addedRows.Where(r => r.Id == 10).FirstOrDefault();
            Cell cell = row.Cells.Where(c => c.Value.Equals("Apple")).FirstOrDefault();

            Assert.AreEqual(101, cell.ColumnId);
        }

        [TestMethod]
        public void AddRows_Location_Top()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Add Rows - Location - Top");

            Row rowA = new Row
            {
                ToTop = true,
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

            // Update rows in sheet
            IList<Row> addedRows = ss.SheetResources.RowResources.AddRows(1, new Row[] { rowA });

            Row row = addedRows.Where(r => r.Id == 10).FirstOrDefault();
            Cell cell = row.Cells.Where(c => c.Value.Equals("Apple")).FirstOrDefault();
            
            Assert.AreEqual(1, row.RowNumber);
            Assert.AreEqual(101, cell.ColumnId);
        }

        [TestMethod]
        public void AddRows_Location_Bottom()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Add Rows - Location - Bottom");

            Row rowA = new Row
            {
                ToBottom = true,
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

            // Update rows in sheet
            IList<Row> addedRows = ss.SheetResources.RowResources.AddRows(1, new Row[] { rowA });

            Row row = addedRows.Where(r => r.Id == 10).FirstOrDefault();
            Cell cell = row.Cells.Where(c => c.Value.Equals("Apple")).FirstOrDefault();

            Assert.AreEqual(100, row.RowNumber);
            Assert.AreEqual(101, cell.ColumnId);
        }
      
        [TestMethod]
        public void AddRows_AssignValues_Int()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Add Rows - Assign Values - Int");

            Row rowA = new Row
            {
                Cells = new List<Cell>
                {
                    new Cell{
                        ColumnId = 101,
                        Value = 100
                    },
                    new Cell{
                        ColumnId = 102,
                        Value = "One Hundred"
                    }
                }
            };

            Row rowB = new Row
            {
                Cells = new List<Cell>
                {
                    new Cell{
                        ColumnId = 101,
                        Value = 2.1
                    },
                    new Cell{
                        ColumnId = 102,
                        Value = "Two Point One"
                    }
                }
            };

            // Update rows in sheet
            IList<Row> addedRows = ss.SheetResources.RowResources.AddRows(1, new Row[] { rowA, rowB });

            Row row = addedRows.Where(r => r.Id == 10).FirstOrDefault();
            Cell cell = row.Cells.Where(c => Convert.ToInt32(c.Value) == 100).FirstOrDefault();

            Assert.AreEqual(101, cell.ColumnId);
        }

        [TestMethod]
        public void AddRows_AssignValues_Bool()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Add Rows - Assign Values - Bool");

            Row rowA = new Row
            {
                Cells = new List<Cell>
                {
                    new Cell{
                        ColumnId = 101,
                        Value = true
                    },
                    new Cell{
                        ColumnId = 102,
                        Value = "This is True"
                    }
                }
            };

            Row rowB = new Row
            {
                Cells = new List<Cell>
                {
                    new Cell{
                        ColumnId = 101,
                        Value = false
                    },
                    new Cell{
                        ColumnId = 102,
                        Value = "This is False"
                    }
                }
            };

            // Update rows in sheet
            IList<Row> addedRows = ss.SheetResources.RowResources.AddRows(1, new Row[] { rowA, rowB });

            Row row = addedRows.Where(r => r.Id == 10).FirstOrDefault();
            Cell cell = row.Cells.Where(c => c.Value.Equals(true)).FirstOrDefault();

            Assert.AreEqual(101, cell.ColumnId);
        }


        [TestMethod]
        public void AddRows_AssignFormulae()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Add Rows - Assign Formulae");

            Row rowA = new Row
            {
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

            IList<Row> addedRows = ss.SheetResources.RowResources.AddRows(1, new Row[] { rowA });

            Cell cell = addedRows[0].Cells.Where(c => c.Formula.Equals("=SUM([Column2]3, [Column2]3, [Column2]4)")).FirstOrDefault();

            Assert.AreEqual(102, cell.ColumnId);
        }

        [TestMethod]
        public void AddRows_AssignValues_Hyperlink()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Add Rows - Assign Values - Hyperlink");

            Row rowA = new Row
            {
                Cells = new List<Cell>
                {
                    new Cell{
                        ColumnId = 101,
                        Value = "Google",
                        Hyperlink = new Hyperlink{
                            Url = "http://google.com"
                        }
                    },
                    new Cell{
                        ColumnId = 102,
                        Value = "Bing",
                        Hyperlink = new Hyperlink{
                            Url = "http://bing.com"
                        }
                    }
                }
            };

            IList<Row> addedRows = ss.SheetResources.RowResources.AddRows(1, new Row[] { rowA });

            Cell cell = addedRows[0].Cells.Where(c => c.Value.Equals("Google")).FirstOrDefault();
            Hyperlink link = cell.Hyperlink;

            Assert.AreEqual(101, cell.ColumnId);
            Assert.AreEqual("http://google.com", link.Url);
        }

        [TestMethod]
        public void AddRows_AssignValues_HyperlinkSheetID()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Add Rows - Assign Values - Hyperlink SheetID");

            Row rowA = new Row
            {
                Cells = new List<Cell>
                {
                    new Cell{
                        ColumnId = 101,
                        Value = "Sheet2",
                        Hyperlink = new Hyperlink{
                            SheetId = 2
                        }
                    },
                    new Cell{
                        ColumnId = 102,
                        Value = "Sheet3",
                        Hyperlink = new Hyperlink{
                            SheetId = 3
                        }
                    }
                }
            };

            IList<Row> addedRows = ss.SheetResources.RowResources.AddRows(1, new Row[] { rowA });

            Cell cell = addedRows[0].Cells.Where(c => c.Value.Equals("Sheet3")).FirstOrDefault();
            Hyperlink link = cell.Hyperlink;

            Assert.AreEqual(102, cell.ColumnId);
            Assert.AreEqual(3, link.SheetId);
        }

        [TestMethod]
        public void AddRows_AssignValues_HyperlinkReportID()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Add Rows - Assign Values - Hyperlink ReportID");

            Row rowA = new Row
            {
                Cells = new List<Cell>
                {
                    new Cell{
                        ColumnId = 101,
                        Value = "Report9",
                        Hyperlink = new Hyperlink{
                            ReportId = 9
                        }
                    },
                    new Cell{
                        ColumnId = 102,
                        Value = "Report8",
                        Hyperlink = new Hyperlink{
                            ReportId = 8
                        }
                    }
                }
            };

            IList<Row> addedRows = ss.SheetResources.RowResources.AddRows(1, new Row[] { rowA });

            Cell cell = addedRows[0].Cells.Where(c => c.Value.Equals("Report8")).FirstOrDefault();
            Hyperlink link = cell.Hyperlink;

            Assert.AreEqual(102, cell.ColumnId);
            Assert.AreEqual(8, link.ReportId);
        }

        [TestMethod]
        public void AddRows_Invalid_AssignHyperlinkUrlandSheetId()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Add Rows - Invalid - Assign Hyperlink URL and SheetId");

            Row rowA = new Row
            {
                Cells = new List<Cell>
                {
                    new Cell{
                        ColumnId = 101,
                        Value = "Google",
                        Hyperlink = new Hyperlink{
                            Url = "http://google.com",
                            SheetId = 2
                        }
                    },
                    new Cell{
                        ColumnId = 102,
                        Value = "Bing",
                        Hyperlink = new Hyperlink{
                            Url = "http://bing.com"
                        }
                    }
                }
            };


            HelperFunctions.AssertRaisesException<SmartsheetException>(() =>
                ss.SheetResources.RowResources.AddRows(1, new Row[] { rowA }),
                "hyperlink.url must be null for sheet, report, or Sight hyperlinks.");
        }

        [TestMethod]
        public void AddRows_Invalid_AssignValueAndFormulae()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Add Rows - Invalid - Assign Value and Formulae");

            Row rowA = new Row
            {
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

            HelperFunctions.AssertRaisesException<SmartsheetException>(() =>
                ss.SheetResources.RowResources.AddRows(1, new Row[] { rowA }),
                "If cell.formula is specified, then value, objectValue, image, hyperlink, and linkInFromCell must not be specified.");
        }

        [TestMethod]
        public void AddRows_AssignObjectValue_PredecessorList()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Add Rows - Assign Object Value - Predecessor List (using floats)");

            Row rowA = new Row
            {
                Cells = new List<Cell>
                {
                    new Cell
                    {
                        ColumnId = 101,
                        ObjectValue = new PredecessorList
                        {
                            Predecessors = new List<Predecessor>
                            {
                                new Predecessor
                                {
                                    RowId = 10,
                                    Type = "FS",
                                    Lag = new Duration
                                    {
                                        Days = 2.5
                                    }
                                }
                            }
                        }
                    }
                }
            };

            IList<Row> addedRows = ss.SheetResources.RowResources.AddRows(1, new Row[] { rowA });

            Cell predecessorCell = addedRows[0].Cells.Single(c => c.ColumnId == 101);
            Assert.AreEqual("2FS +2.5d", predecessorCell.Value);
        }

        

        [TestMethod]
        public void UpdateRows_AssignValues_String()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Update Rows - Assign Values - String");
          
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

            Assert.AreEqual(101, cell.ColumnId);
        }

        [TestMethod]
        public void UpdateRows_AssignValues_Int()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Update Rows - Assign Values - Int");

            Row rowA = new Row
            {
                Id = 10,
                Cells = new List<Cell>
                {
                    new Cell{
                        ColumnId = 101,
                        Value = 100
                    },
                    new Cell{
                        ColumnId = 102,
                        Value = "One Hundred"
                    }
                }
            };

            Row rowB = new Row
            {
                Id = 11,
                Cells = new List<Cell>
                {
                    new Cell{
                        ColumnId = 101,
                        Value = 2.1
                    },
                    new Cell{
                        ColumnId = 102,
                        Value = "Two Point One"
                    }
                }
            };

            // Update rows in sheet
            IList<Row> updatedRows = ss.SheetResources.RowResources.UpdateRows(1, new Row[] { rowA, rowB });

            Row row = updatedRows.Where(r => r.Id == 10).FirstOrDefault();
            Cell cell = row.Cells.Where(c => Convert.ToInt32(c.Value) == 100).FirstOrDefault();

            Assert.AreEqual(101, cell.ColumnId);
        }

        [TestMethod]
        public void UpdateRows_AssignValues_Bool()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Update Rows - Assign Values - Bool");

            Row rowA = new Row
            {
                Id = 10,
                Cells = new List<Cell>
                {
                    new Cell{
                        ColumnId = 101,
                        Value = true
                    },
                    new Cell{
                        ColumnId = 102,
                        Value = "This is True"
                    }
                }
            };

            Row rowB = new Row
            {
                Id = 11,
                Cells = new List<Cell>
                {
                    new Cell{
                        ColumnId = 101,
                        Value = false
                    },
                    new Cell{
                        ColumnId = 102,
                        Value = "This is False"
                    }
                }
            };

            // Update rows in sheet
            IList<Row> updatedRows = ss.SheetResources.RowResources.UpdateRows(1, new Row[] { rowA, rowB });

            Row row = updatedRows.Where(r => r.Id == 10).FirstOrDefault();
            Cell cell = row.Cells.Where(c => c.Value.Equals(true)).FirstOrDefault();

            Assert.AreEqual(101, cell.ColumnId);
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

            Assert.AreEqual(102, cell.ColumnId);
        }

        [TestMethod]
        public void UpdateRows_AssignValues_Hyperlink()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Update Rows - Assign Values - Hyperlink");

            Row rowA = new Row
            {
                Id = 10,
                Cells = new List<Cell>
                {
                    new Cell{
                        ColumnId = 101,
                        Value = "Google",
                        Hyperlink = new Hyperlink{
                            Url = "http://google.com"
                        }
                    },
                    new Cell{
                        ColumnId = 102,
                        Value = "Bing",
                        Hyperlink = new Hyperlink{
                            Url = "http://bing.com"
                        }
                    }
                }
            };

            IList<Row> updatedRows = ss.SheetResources.RowResources.UpdateRows(1, new Row[] { rowA });

            Cell cell = updatedRows[0].Cells.Where(c => c.Value.Equals("Google")).FirstOrDefault();
            Hyperlink link = cell.Hyperlink;

            Assert.AreEqual(101, cell.ColumnId);
            Assert.AreEqual("http://google.com", link.Url);
        }

        [TestMethod]
        public void UpdateRows_AssignValues_HyperlinkSheetID()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Update Rows - Assign Values - Hyperlink SheetID");

            Row rowA = new Row
            {
                Id = 10,
                Cells = new List<Cell>
                {
                    new Cell{
                        ColumnId = 101,
                        Value = "Sheet2",
                        Hyperlink = new Hyperlink{
                            SheetId = 2
                        }
                    },
                    new Cell{
                        ColumnId = 102,
                        Value = "Sheet3",
                        Hyperlink = new Hyperlink{
                            SheetId = 3
                        }
                    }
                }
            };

            IList<Row> updatedRows = ss.SheetResources.RowResources.UpdateRows(1, new Row[] { rowA });

            Cell cell = updatedRows[0].Cells.Where(c => c.Value.Equals("Sheet3")).FirstOrDefault();
            Hyperlink link = cell.Hyperlink;

            Assert.AreEqual(102, cell.ColumnId);
            Assert.AreEqual(3, link.SheetId);
        }

        [TestMethod]
        public void UpdateRows_AssignValues_HyperlinkReportID()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Update Rows - Assign Values - Hyperlink ReportID");

            Row rowA = new Row
            {
                Id = 10,
                Cells = new List<Cell>
                {
                    new Cell{
                        ColumnId = 101,
                        Value = "Report9",
                        Hyperlink = new Hyperlink{
                            ReportId = 9
                        }
                    },
                    new Cell{
                        ColumnId = 102,
                        Value = "Report8",
                        Hyperlink = new Hyperlink{
                            ReportId = 8
                        }
                    }
                }
            };

            IList<Row> updatedRows = ss.SheetResources.RowResources.UpdateRows(1, new Row[] { rowA });

            Cell cell = updatedRows[0].Cells.Where(c => c.Value.Equals("Report8")).FirstOrDefault();
            Hyperlink link = cell.Hyperlink;

            Assert.AreEqual(102, cell.ColumnId);
            Assert.AreEqual(8, link.ReportId);
        }

        [TestMethod]
        public void UpdateRows_Invalid_AssignHyperlinkUrlandSheetId()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Update Rows - Invalid - Assign Hyperlink URL and SheetId");

            Row rowA = new Row
            {
                Id = 10,
                Cells = new List<Cell>
                {
                    new Cell{
                        ColumnId = 101,
                        Value = "Google",
                        Hyperlink = new Hyperlink{
                            Url = "http://google.com",
                            SheetId = 2
                        }
                    },
                    new Cell{
                        ColumnId = 102,
                        Value = "Bing",
                        Hyperlink = new Hyperlink{
                            Url = "http://bing.com"
                        }
                    }
                }
            };

            HelperFunctions.AssertRaisesException<SmartsheetException>(() =>
                ss.SheetResources.RowResources.UpdateRows(1, new Row[] { rowA }),
                "hyperlink.url must be null for sheet, report, or Sight hyperlinks.");
        }

        [TestMethod]
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

            HelperFunctions.AssertRaisesException<SmartsheetException>(() =>
                ss.SheetResources.RowResources.UpdateRows(1, new Row[] { rowA }),
                "If cell.formula is specified, then value, objectValue, image, hyperlink, and linkInFromCell must not be specified.");
        }

        [TestMethod]
        public void UpdateRows_ClearValue_TextNumber()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Update Rows - Clear Value - Text Number");

            Row rowA = new Row
            {
                Id = 10,
                Cells = new List<Cell>
                {
                    new Cell
                    {
                        ColumnId = 101,
                        Value = ""
                    }
                }
            };

            IList<Row> updatedRows = ss.SheetResources.RowResources.UpdateRows(1, new Row[] { rowA });

            Cell updatedCell = updatedRows[0].Cells.Single(c => c.ColumnId == 101);
            Assert.AreEqual(null, updatedCell.Value);
        }

        [TestMethod]
        public void UpdateRows_ClearValue_Checkbox()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Update Rows - Clear Value - Checkbox");

            Row rowA = new Row
            {
                Id = 10,
                Cells = new List<Cell>
                {
                    new Cell
                    {
                        ColumnId = 101,
                        Value = ""
                    }
                }
            };

            IList<Row> updatedRows = ss.SheetResources.RowResources.UpdateRows(1, new Row[] { rowA });

            Cell updatedCell = updatedRows[0].Cells.Single(c => c.ColumnId == 101);
            Assert.AreEqual(false, updatedCell.Value);
        }

        [TestMethod]
        public void UpdateRows_ClearValue_Hyperlink()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Update Rows - Clear Value - Hyperlink");

            Row rowA = new Row
            {
                Id = 10,
                Cells = new List<Cell>
                {
                    new Cell
                    {
                        ColumnId = 101,
                        Value = "",
                        Hyperlink = new Hyperlink()
                    }
                }
            };

            IList<Row> updatedRows = ss.SheetResources.RowResources.UpdateRows(1, new Row[] { rowA });

            Cell updatedCell = updatedRows[0].Cells.Single(c => c.ColumnId == 101);
            Assert.AreEqual(null, updatedCell.Hyperlink);
            Assert.AreEqual(null, updatedCell.Value);
        }

        [TestMethod]
        public void UpdateRows_ClearValue_CellLink()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Update Rows - Clear Value - Cell Link");

            Row rowA = new Row
            {
                Id = 10,
                Cells = new List<Cell>
                {
                    new Cell
                    {
                        ColumnId = 101,
                        Value = "",
                        LinkInFromCell = new CellLink()
                    }
                }
            };

            IList<Row> updatedRows = ss.SheetResources.RowResources.UpdateRows(1, new Row[] { rowA });

            Cell updatedCell = updatedRows[0].Cells.Single(c => c.ColumnId == 101);
            Assert.AreEqual(null, updatedCell.LinkInFromCell);
            Assert.AreEqual(null, updatedCell.Value);
        }

        [TestMethod]
        public void UpdateRows_Invalid_AssignHyperlinkAndCellLink()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Update Rows - Invalid - Assign Hyperlink and Cell Link");

            Row rowA = new Row
            {
                Id = 10,
                Cells = new List<Cell>
                {
                    new Cell
                    {
                        ColumnId = 101,
                        Value = "",
                        LinkInFromCell = new CellLink
                        {
                            ColumnId = 201,
                            RowId = 20,
                            SheetId = 2
                        },
                        Hyperlink = new Hyperlink
                        {
                            Url = "www.google.com"
                        }
                    }
                }
            };

            HelperFunctions.AssertRaisesException<SmartsheetException>(() =>
                    ss.SheetResources.RowResources.UpdateRows(1, new Row[] { rowA }),
                "Only one of cell.hyperlink or cell.linkInFromCell may be non-null.");
        }

        [TestMethod]
        public void UpdateRows_Location_Top()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Update Rows - Location - Top");

            Row rowA = new Row
            {
                Id = 10,
                ToTop = true
            };

            IList<Row> updatedRows = ss.SheetResources.RowResources.UpdateRows(1, new Row[] { rowA });

            Row updateRow = updatedRows.Single(r => r.Id == 10);
            Assert.AreEqual(1, updateRow.RowNumber);
        }

        [TestMethod]
        public void UpdateRows_Location_Bottom()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Update Rows - Location - Bottom");

            Row rowA = new Row
            {
                Id = 10,
                ToBottom = true
            };

            IList<Row> updatedRows = ss.SheetResources.RowResources.UpdateRows(1, new Row[] { rowA });

            Row updateRow = updatedRows.Single(r => r.Id == 10);
            Assert.AreEqual(100, updateRow.RowNumber);
        }
    }
}
