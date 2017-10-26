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

            Assert.AreEqual(cell.ColumnId, 101);
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
            
            Assert.AreEqual(row.RowNumber, 1);
            Assert.AreEqual(cell.ColumnId, 101);
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

            Assert.AreEqual(row.RowNumber, 100);
            Assert.AreEqual(cell.ColumnId, 101);
        }

        [TestMethod]
        public void AddRows_Location_Indent()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Add Rows - Location - Indent");

            Row rowA = new Row
            {
                Indent = 3,
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

            Assert.AreEqual(row.RowNumber, 100);
            Assert.AreEqual(cell.ColumnId, 101);
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

            Assert.AreEqual(cell.ColumnId, 101);
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

            Assert.AreEqual(cell.ColumnId, 101);
        }

        //[TestMethod]
        //public void AddRows_AssignValues_Date()
        //{
        //    SmartsheetClient ss = HelperFunctions.SetupClient("Add Rows - Assign Values - Date");

        //    Row rowA = new Row
        //    {
        //        Cells = new List<Cell>
        //        {
        //            new Cell{
        //                ColumnId = 101,
        //                ObjectValue = new ObjectType()
        //                }
        //            },
        //            new Cell{
        //                ColumnId = 102,
        //                Value = "This is True"
        //            }
        //        }
        //    };

        //    Row rowB = new Row
        //    {
        //        Cells = new List<Cell>
        //        {
        //            new Cell{
        //                ColumnId = 101,
        //                Value = false
        //            },
        //            new Cell{
        //                ColumnId = 102,
        //                Value = "This is False"
        //            }
        //        }
        //    };

        //    // Update rows in sheet
        //    IList<Row> addedRows = ss.SheetResources.RowResources.AddRows(1, new Row[] { rowA, rowB });

        //    Row row = addedRows.Where(r => r.Id == 10).FirstOrDefault();
        //    Cell cell = row.Cells.Where(c => c.Value.Equals(true)).FirstOrDefault();

        //    Assert.AreEqual(cell.ColumnId, 101);
        //}

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
                        Formula = "=SUM([Column2]6, [Column2]4)*2"
                    },
                    new Cell{
                        ColumnId = 102,
                        Formula = "=SUM([Column2]3, [Column2]3, [Column2]4)"
                    }
                }
            };

            IList<Row> addedRows = ss.SheetResources.RowResources.AddRows(1, new Row[] { rowA });

            Cell cell = addedRows[0].Cells.Where(c => c.Formula.Equals("=SUM([Column2]3, [Column2]3, [Column2]4)")).FirstOrDefault();

            Assert.AreEqual(cell.ColumnId, 102);
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
                        Hyperlink = new Link{
                            Url = "http://google.com"
                        }
                    },
                    new Cell{
                        ColumnId = 102,
                        Value = "Bing",
                        Hyperlink = new Link{
                            Url = "http://bing.com"
                        }
                    }
                }
            };

            IList<Row> addedRows = ss.SheetResources.RowResources.AddRows(1, new Row[] { rowA });

            Cell cell = addedRows[0].Cells.Where(c => c.Value.Equals("Google")).FirstOrDefault();
            Link link = cell.Hyperlink;

            Assert.AreEqual(cell.ColumnId, 101);
            Assert.AreEqual(link.Url, "http://google.com");
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
                        Hyperlink = new Link{
                            SheetId = 2
                        }
                    },
                    new Cell{
                        ColumnId = 102,
                        Value = "Sheet3",
                        Hyperlink = new Link{
                            SheetId = 3
                        }
                    }
                }
            };

            IList<Row> addedRows = ss.SheetResources.RowResources.AddRows(1, new Row[] { rowA });

            Cell cell = addedRows[0].Cells.Where(c => c.Value.Equals("Sheet3")).FirstOrDefault();
            Link link = cell.Hyperlink;

            Assert.AreEqual(cell.ColumnId, 102);
            Assert.AreEqual(link.SheetId, 3);
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
                        Hyperlink = new Link{
                            ReportId = 9
                        }
                    },
                    new Cell{
                        ColumnId = 102,
                        Value = "Report8",
                        Hyperlink = new Link{
                            ReportId = 8
                        }
                    }
                }
            };

            IList<Row> addedRows = ss.SheetResources.RowResources.AddRows(1, new Row[] { rowA });

            Cell cell = addedRows[0].Cells.Where(c => c.Value.Equals("Report8")).FirstOrDefault();
            Link link = cell.Hyperlink;

            Assert.AreEqual(cell.ColumnId, 102);
            Assert.AreEqual(link.ReportId, 8);
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
                        Hyperlink = new Link{
                            Url = "http://google.com",
                            SheetId = 2
                        }
                    },
                    new Cell{
                        ColumnId = 102,
                        Value = "Bing",
                        Hyperlink = new Link{
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

            Assert.AreEqual(cell.ColumnId, 101);
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

            Assert.AreEqual(cell.ColumnId, 101);
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
                        Formula = "=SUM([Column2], [Column2]4)*2"
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
                        Hyperlink = new Link{
                            Url = "http://google.com"
                        }
                    },
                    new Cell{
                        ColumnId = 102,
                        Value = "Bing",
                        Hyperlink = new Link{
                            Url = "http://bing.com"
                        }
                    }
                }
            };

            IList<Row> updatedRows = ss.SheetResources.RowResources.UpdateRows(1, new Row[] { rowA });

            Cell cell = updatedRows[0].Cells.Where(c => c.Value.Equals("Google")).FirstOrDefault();
            Link link = cell.Hyperlink;

            Assert.AreEqual(cell.ColumnId, 101);
            Assert.AreEqual(link.Url, "http://google.com");
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
                        Hyperlink = new Link{
                            SheetId = 2
                        }
                    },
                    new Cell{
                        ColumnId = 102,
                        Value = "Sheet3",
                        Hyperlink = new Link{
                            SheetId = 3
                        }
                    }
                }
            };

            IList<Row> updatedRows = ss.SheetResources.RowResources.UpdateRows(1, new Row[] { rowA });

            Cell cell = updatedRows[0].Cells.Where(c => c.Value.Equals("Sheet3")).FirstOrDefault();
            Link link = cell.Hyperlink;

            Assert.AreEqual(cell.ColumnId, 102);
            Assert.AreEqual(link.SheetId, 3);
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
                        Hyperlink = new Link{
                            ReportId = 9
                        }
                    },
                    new Cell{
                        ColumnId = 102,
                        Value = "Report8",
                        Hyperlink = new Link{
                            ReportId = 8
                        }
                    }
                }
            };

            IList<Row> updatedRows = ss.SheetResources.RowResources.UpdateRows(1, new Row[] { rowA });

            Cell cell = updatedRows[0].Cells.Where(c => c.Value.Equals("Report8")).FirstOrDefault();
            Link link = cell.Hyperlink;

            Assert.AreEqual(cell.ColumnId, 102);
            Assert.AreEqual(link.ReportId, 8);
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
                        Hyperlink = new Link{
                            Url = "http://google.com",
                            SheetId = 2
                        }
                    },
                    new Cell{
                        ColumnId = 102,
                        Value = "Bing",
                        Hyperlink = new Link{
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
    }
}
