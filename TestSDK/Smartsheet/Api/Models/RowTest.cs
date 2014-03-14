using System.Collections.Generic;

namespace Smartsheet.Api.models
{
	using NUnit.Framework;
    using Smartsheet.Api.Models;
    using System;

	public class RowTest
	{

		[SetUp]
		public virtual void SetUp()
		{
		}

		[Test]
		public virtual void TestGetColumnByIndex()
		{
			Row row = new Row();
			Column col = new Column();
			col.ID = 1234L;
			col.Index = 2;
			IList<Column> columns = new List<Column>();
			columns.Add(col);
			row.Columns = columns;
			row.ParentRowNumber = 1;
			row.Discussions = new List<Discussion>();
			row.Attachments = new List<Attachment>();

			Assert.AreEqual(col, row.GetColumnById(1234L));
			Assert.AreEqual(col, row.GetColumnByIndex(2));
			Assert.Null(row.GetColumnById(12345L));
			Assert.Null(row.GetColumnByIndex(22));
			Assert.Null((new Row()).GetColumnById(213L));
			Assert.Null((new Row()).GetColumnByIndex(33));
			Row row1 = new Row();
			row1.Columns = new List<Column>();
			Assert.Null(row1.GetColumnById(1L));
			Assert.Null(row1.GetColumnByIndex(1));

		}

	}

}