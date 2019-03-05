﻿using System;
using System.Collections.Generic;

// Add nuget reference to smartsheet-csharp-sdk (https://www.nuget.org/packages/smartsheet-csharp-sdk/)
using Smartsheet.Api;
using Smartsheet.Api.Models;
using System.Linq;

namespace sdk_csharp_sample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize client
            SmartsheetClient smartsheet = new SmartsheetBuilder()
                // .SetAccessToken("feo3t736fc2lpansdevs4a1as")       // TODO: Set your API access in environment variable SMARTSHEET_ACCESS_TOKEN or else here
                .SetHttpClient(new RetryHttpClient())
                .Build();

            // List all sheets
            PaginatedResult<Sheet> sheets = smartsheet.SheetResources.ListSheets(new List<SheetInclusion>{SheetInclusion.SHEET_VERSION}, null, null);
            Console.WriteLine("Found " + sheets.TotalCount + " sheets");

            if (sheets.TotalCount > 0)
            {
                long sheetId = (long) sheets.Data[0].Id;                // Default first sheet

                // sheetId = 5670346721388420L;                         // TODO: Uncomment if you wish to read a specific sheet

                Console.WriteLine("Loading sheet id: " + sheetId);

                // Load the entire sheet
                var sheet = smartsheet.SheetResources.GetSheet(sheetId, null, null, null, null, null, null, null);
                Console.WriteLine("Loaded " + sheet.Rows.Count + " rows from sheet: " + sheet.Name);

                // Display the first 5 rows
                foreach (Row row in sheet.Rows.Take(5))
                {
                    dumpRow(row, sheet.Columns);
                }
            }

            Console.WriteLine("Done (Hit enter)");                      // Keep console window open
            Console.ReadLine();
        }

        // Display row contents
        static void dumpRow(Row row, IList<Column> columns)
        {
            Console.WriteLine("Row # " + row.RowNumber + ":");
            foreach (var cell in row.Cells)
            {
                // Find column name by Id in column collection
                var columName = columns.First(column => column.Id == cell.ColumnId).Title;
                Console.WriteLine("    " + columName + ": " + cell.Value);
            }
        }
    }
}

