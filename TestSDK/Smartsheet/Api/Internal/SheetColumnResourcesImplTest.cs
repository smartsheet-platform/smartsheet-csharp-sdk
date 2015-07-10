using System.Collections.Generic;

namespace Smartsheet.Api.Internal
{
	using NUnit.Framework;




	using DefaultHttpClient = Smartsheet.Api.Internal.Http.DefaultHttpClient;
	using AutoNumberFormat = Smartsheet.Api.Models.AutoNumberFormat;
	using Column = Smartsheet.Api.Models.Column;
	using ColumnType = Smartsheet.Api.Models.ColumnType;
	using Smartsheet.Api.Models;

	public class SheetColumnResourcesImplTest : ResourcesImplBase
	{

		private SheetColumnResourcesImpl sheetColumnResourcesImpl;

		[SetUp]
		public virtual void SetUp()
		{
			sheetColumnResourcesImpl = new SheetColumnResourcesImpl(new SmartsheetImpl("http://localhost:9090/1.1/",
				"accessToken", new DefaultHttpClient(), serializer));
		}

		[Test]
		public virtual void TestSheetColumnResourcesImpl()
		{
		}

		[Test]
		public virtual void TestListColumns()
		{

			server.setResponseBody("../../../TestSDK/resources/listColumns.json");

			DataWrapper<Column> result = sheetColumnResourcesImpl.ListColumns(1234L, new List<FilterInclusion> { FilterInclusion.FILTERS }, null);
			Assert.True(result.TotalCount == 9);
			Assert.AreEqual(result.Data[2].Title, "Start");
			Assert.IsTrue(result.Data[3].Filter != null);
			Assert.AreEqual(result.Data[3].Filter.Criteria[0].Operator, CriteriaOperator.GREATER_THAN);
			Assert.AreEqual(result.Data[3].Filter.Criteria[0].Value1, "2015-07-14");
			Assert.IsTrue(result.Data[7].Filter == null);
			Assert.AreEqual(result.Data[7].Options.Count, 5);
			Assert.AreEqual(result.Data[7].Options[3], "At Risk");

		}

		[Test]
		public virtual void TestAddColumn()
		{
			server.setResponseBody("../../../TestSDK/resources/addColumn.json");
			Column col1 = new Column.AddColumnBuilder().SetTitle("New Picklist Column 1").SetType(ColumnType.PICKLIST).Build();
			Column col2 = new Column.AddColumnBuilder().SetTitle("New Picklist Column 1").SetType(ColumnType.PICKLIST).Build();

			col1.Options = new List<string> { "First", "Second", "Third" };

			IList<Column> newCols = sheetColumnResourcesImpl.AddColumns(1234L, new List<Column> { col1, col2 });
			Assert.AreEqual(150, newCols[0].Width);
			Assert.IsTrue(newCols[0].Type == ColumnType.PICKLIST);
			Assert.IsTrue(newCols[0].Index == 4);
			Assert.IsTrue(newCols[2].ID == 6755394238748795);
			Assert.IsTrue(newCols[2].Title == "New Picklist Column 2");
			Assert.IsTrue(newCols[2].Options[1] == "2");
		}

		[Test]
		public virtual void TestGetColumn()
		{
			server.setResponseBody("../../../TestSDK/resources/getColumn.json");

			Column newCol = sheetColumnResourcesImpl.GetColumn(123, 1234L, null);

			Assert.IsTrue(newCol.Type == ColumnType.CHECKBOX);
			Assert.IsTrue(newCol.Index == 2);
			Assert.IsTrue(newCol.ID == 7960873114331012);
			Assert.IsTrue(newCol.Title == "Favorite");
		}

		[Test]
		public virtual void TestUpdateColumn()
		{
			server.setResponseBody("../../../TestSDK/resources/updateColumn.json");
			IList<string> options = new List<string> { "First", "Second", "Third" };

			Column col1 = new Column.UpdateColumnBuilder().SetTitle("First Column").SetIndex(0)
			.SetType(ColumnType.PICKLIST).SetOptions(options).Build();


			Column newCol = sheetColumnResourcesImpl.UpdateColumn(1234L, 132, col1);
			Assert.IsTrue(newCol.Type == ColumnType.PICKLIST);
			Assert.IsTrue(newCol.Index == 0);
			Assert.IsTrue(newCol.ID == 5005385858869124);
			Assert.IsTrue(newCol.Title == "First Column");
			Assert.IsTrue(newCol.Options[0] == "One");
			Assert.IsTrue(newCol.Options[1] == "Two");

		}

	}

}