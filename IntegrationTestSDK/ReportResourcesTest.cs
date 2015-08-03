using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smartsheet.Api;
using Smartsheet.Api.Models;
using System.Collections.Generic;
using System.Configuration;

namespace IntegrationTestSDK
{
	[TestClass]
	public class ReportResourcesTest
	{
		[TestMethod]
		public void TestReportResources()
		{
			string accessToken = ConfigurationManager.AppSettings["accessToken"];

			SmartsheetClient smartsheet = new SmartsheetBuilder().SetAccessToken(accessToken).Build();

			//Must manually create a Report at smartsheet.com and paste reportId below.
			long reportId = 6224034443618180;

			Report report = smartsheet.ReportResources.GetReport(reportId, new ReportInclusion[] { ReportInclusion.ATTACHMENTS, ReportInclusion.DISCUSSIONS }, null, null);
			Assert.IsTrue(report.Rows.Count > 0);
			SheetEmail email = new SheetEmail.CreateSheetEmail(new Recipient[] { new Recipient { Email = "ericyan99@outlook.com" } }, SheetEmailFormat.PDF).SetCcMe(true).Build();
			smartsheet.ReportResources.SendReport(reportId, email);
		}
	}
}