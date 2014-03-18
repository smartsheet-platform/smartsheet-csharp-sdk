namespace Smartsheet.Api.Internal
{
	using NUnit.Framework;

	using DefaultHttpClient = Smartsheet.Api.Internal.Http.DefaultHttpClient;
	using Column = Smartsheet.Api.Models.Column;
	using Symbol = Smartsheet.Api.Models.Symbol;
	using SystemColumnType = Smartsheet.Api.Models.SystemColumnType;

	public class ColumnResourcesImplTest : ResourcesImplBase
	{
		internal ColumnResourcesImpl columnResource;

		[SetUp]
		public virtual void SetUp()
		{
			columnResource = new ColumnResourcesImpl(new SmartsheetImpl("http://localhost:9090/1.1/",
					"accessToken", new DefaultHttpClient(), serializer));
		}

		[Test]
		public virtual void TestColumnResourcesImpl()
		{
		}
		[Test]
		public virtual void TestUpdateColumn()
		{
			server.setResponseBody("../../../TestSDK/resources/updateColumn.json");

			Column col = new Column();

			col.Index = 0;
			col.Title = "something new";
			col.SheetId = 2906571706525572L;
			col.Hidden = false;
			col.Symbol = Symbol.STAR;
			col.SystemColumnType = SystemColumnType.AUTO_NUMBER;
			Column colNew = columnResource.UpdateColumn(col);

			Assert.NotNull(colNew);
			Assert.AreEqual("something new",colNew.Title);

			try
			{
				columnResource.UpdateColumn(null);
				Assert.Fail("Exception should have been thrown");
			}
			catch (System.ArgumentException)
			{
				// expected
			}
		}

		[Test]
		public virtual void TestDeleteColumn()
		{
			server.setResponseBody("../../../TestSDK/resources/deleteColumn.json");
			columnResource.DeleteColumn(179084870346628L, 2906571706525572L);
		}

	}

}