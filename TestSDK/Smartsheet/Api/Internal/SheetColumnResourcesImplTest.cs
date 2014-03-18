using System.Collections.Generic;

namespace Smartsheet.Api.Internal
{
	using NUnit.Framework;




	using DefaultHttpClient = Smartsheet.Api.Internal.Http.DefaultHttpClient;
	using AutoNumberFormat = Smartsheet.Api.Models.AutoNumberFormat;
	using Column = Smartsheet.Api.Models.Column;
	using ColumnType = Smartsheet.Api.Models.ColumnType;

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

			IList<Column> columns = sheetColumnResourcesImpl.ListColumns(1234L);
			Assert.True(columns.Count == 1);
			Assert.AreEqual(columns[0].Title,"something new");
		}

		[Test]
		public virtual void TestAddColumn()
		{
			server.setResponseBody("../../../TestSDK/resources/addColumn.json");
			Column col = new Column();
			col.Index = 1;
			col.Title = "Status";
			col.Type = ColumnType.PICKLIST;
			AutoNumberFormat format = new AutoNumberFormat();
			format.Prefix = "pre";
			format.Suffix = "suf";
			format.StartingNumber = 0L;
			format.Fill = "000";
			col.AutoNumberFormat = format;

			col.Options = new List<string>(new string[] { "Not Started", "Started", "Completed" });

			Column newCol = sheetColumnResourcesImpl.AddColumn(1234L, col);
			Assert.AreEqual("Status", newCol.Title);
			Assert.True(ColumnType.PICKLIST == col.Type);


		}

	}

}