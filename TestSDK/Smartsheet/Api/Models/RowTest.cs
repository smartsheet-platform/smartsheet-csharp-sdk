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
			col.Id = 1234L;
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

        [Test]
        public void UpdateRowBuilderEmpty()
        {
            Row row = new Row.UpdateRowBuilder(1)
                .Build();
            Assert.AreEqual(1, row.Id);
            Assert.IsNull(row.SiblingId);
            Assert.IsNull(row.ParentId);
            Assert.IsNull(row.Expanded);
            Assert.IsNull(row.Above);
        }

        [Test]
        public void UpdateRowBuilderExpand()
        {
            Row row = new Row.UpdateRowBuilder(1)
                .SetExpanded(true)
                .Build();
            Assert.AreEqual(1, row.Id);
            Assert.IsTrue(row.Expanded.Value);
        }

        [Test]
        public void UpdateRowBuilderParentSibling()
        {
            Row row = new Row.UpdateRowBuilder(1)
                .SetParentId(100)
                .Build();
            Assert.AreEqual(1, row.Id);
            Assert.AreEqual(100, row.ParentId);

            row = new Row.UpdateRowBuilder(1)
                .SetSiblingId(100)
                .Build();
            Assert.AreEqual(1, row.Id);
            Assert.AreEqual(100, row.SiblingId);
        }

        [Test]
        public void UpdateRowBuilderAbove()
        {
            Row row = new Row.UpdateRowBuilder(1)
                .SetSiblingId(100)
                .SetAbove(true)
                .Build();
            Assert.AreEqual(1, row.Id);
            Assert.AreEqual(100, row.SiblingId);
            Assert.IsTrue(row.Above.Value);
        }

    }

}