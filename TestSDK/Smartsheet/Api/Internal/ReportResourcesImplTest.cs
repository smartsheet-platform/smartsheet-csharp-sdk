using System.Collections.Generic;
using System;

namespace Smartsheet.Api.Internal
{
	using NUnit.Framework;

	using DefaultHttpClient = Smartsheet.Api.Internal.Http.DefaultHttpClient;
	using Api.Models;
	using System.IO;

	public class ReportResourcesImplTest : ResourcesImplBase
	{
		internal ReportResourcesImpl reportResource;

		[SetUp]
		public virtual void SetUp()
		{
			// Create a folder resource
			reportResource = new ReportResourcesImpl(new SmartsheetImpl("http://localhost:9090/1.1/", "accessToken", new DefaultHttpClient(), serializer));
		}

		[Test]
		public virtual void TestListReports()
		{

			server.setResponseBody("../../../TestSDK/resources/listReports.json");

			PaginatedResult<Report> result = reportResource.ListReports(null, null);
			Assert.AreEqual(2, result.Data.Count);
			Assert.IsTrue("r1" == result.Data[0].Name);

		}


		[Test]
		public virtual void TestGetReport()
		{

			server.setResponseBody("../../../TestSDK/resources/getReport.json");
			Report report = reportResource.GetReport(123123L, null, null, null);
			Assert.AreEqual(2, report.Columns.Count);
			Assert.AreEqual(1, report.Rows.Count);
			Assert.AreEqual(2, report.Rows[0].Cells.Count);

		}

		[Test]
		public virtual void TestGetReportAsExcel()
		{
			string file = "../../../TestSDK/resources/getExcel.xls";
			server.setResponseBody(file);
			server.ContentType = "application/vnd.ms-excel";

			MemoryStream ms = new MemoryStream();
			BinaryWriter output = new BinaryWriter(ms);
			reportResource.GetReportAsExcel(1234L, output);

			Assert.NotNull(output);
			Assert.True(ms.ToArray().Length > 0);

			byte[] original = File.ReadAllBytes(file);
			Assert.AreEqual(original.Length, ms.Length);
		}
	}
}