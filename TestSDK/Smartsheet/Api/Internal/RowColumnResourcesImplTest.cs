using System.Collections.Generic;

namespace Smartsheet.Api.Internal
{
	using NUnit.Framework;
	using DefaultHttpClient = Smartsheet.Api.Internal.Http.DefaultHttpClient;
	using Api.Models;
	using System;

	public class RowColumnResourcesImplTest : ResourcesImplBase
	{

		private RowColumnResourcesImpl cellResources;

		[SetUp]
		public virtual void SetUp()
		{
			cellResources = new RowColumnResourcesImpl(new SmartsheetImpl("http://localhost:9090/1.1/", "accessToken", new DefaultHttpClient(), serializer));
		}

		[Test]
		public virtual void TestGetCellHistory()
		{
			server.setResponseBody("../../../TestSDK/resources/getCellHistory.json");

			PaginatedResult<CellHistory> histories = cellResources.GetCellHistory(1231654654, 313213132, 4555465465, null);

			Assert.IsTrue(histories.TotalCount == 3);
			Assert.IsTrue(histories.Data[0].ColumnId == 642523719853956);
			Assert.IsTrue(histories.Data[1].DisplayValue == "Revision 2");
			Assert.IsTrue(histories.Data[1].Type == ColumnType.TEXT_NUMBER);
			Assert.IsTrue(histories.Data[0].ModifiedBy.Email == "jane.smart@smartsheet.com");
		}
	}
}