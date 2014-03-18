using System.Collections.Generic;

namespace Smartsheet.Api.models
{
	using NUnit.Framework;
	using Smartsheet.Api.Models;
	using System;



	public class SheetTest
	{

		[SetUp]
		public virtual void SetUp()
		{
		}

		[Test]
		public virtual void TestGetRowByRowNumber()
		{
			Sheet sheet = new Sheet();
			sheet.ReadOnly = false;
			sheet.Discussions = new List<Discussion>();
			sheet.Attachments = new List<Attachment>();

			IList<Row> rows = new List<Row>();
			Row row = new Row();
			row.RowNumber = 5;
			row.ID = 1234L;
			rows.Add(row);
			sheet.Rows = rows;

			Assert.AreEqual(row,sheet.GetRowByRowNumber(5));
			Assert.Null(sheet.GetRowByRowNumber(20));
			Assert.Null((new Sheet()).GetRowByRowNumber(0));
		}

	}

}