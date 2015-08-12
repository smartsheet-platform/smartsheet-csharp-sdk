using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smartsheet.Api;
using Smartsheet.Api.Models;
using System.Collections.Generic;
using System.Configuration;

namespace IntegrationTestSDK
{
	[TestClass]
	public class ShareResourcesTest
	{

		[TestMethod]
		public void TestShareResources()
		{
			string accessToken = ConfigurationManager.AppSettings["accessToken"];

			SmartsheetClient smartsheet = new SmartsheetBuilder().SetAccessToken(accessToken).Build();
			
			long sheetId = CreateSheet(smartsheet);
			//long reportId = CreateReport(smartsheet);
			long workspaceId = CreateWorkspace(smartsheet);

			Share share = new Share.CreateShareBuilder("aditi.nioding@smartsheet.com", AccessLevel.EDITOR).Build();
			//string reportShareId = ShareReport(smartsheet, reportId, share);
			string sheetShareId = ShareSheet(smartsheet, sheetId, share);
			string workspaceShareId = ShareWorkspace(smartsheet, workspaceId, share);

			UpdateObjectShares(smartsheet, sheetId, workspaceId, sheetShareId, workspaceShareId);

			//ListReportShares(smartsheet, reportId);
			ListSheetShares(smartsheet, sheetId);
			ListWorkspaceShares(smartsheet, workspaceId);

			smartsheet.SheetResources.DeleteSheet(sheetId);
			smartsheet.WorkspaceResources.DeleteWorkspace(workspaceId);
		}

		private static void ListSheetShares(SmartsheetClient smartsheet, long sheetId)
		{
			PaginatedResult<Share> shares = smartsheet.SheetResources.ShareResources.ListShares(sheetId, null);
			Assert.IsTrue(shares.Data.Count == 2);
			Assert.IsTrue(shares.Data[0].Email == "aditi.nioding@smartsheet.com" || shares.Data[1].Email == "aditi.nioding@smartsheet.com");
		}

		private static void ListWorkspaceShares(SmartsheetClient smartsheet, long workspaceId)
		{
			PaginatedResult<Share> shares = smartsheet.WorkspaceResources.ShareResources.ListShares(workspaceId, null);
			Assert.IsTrue(shares.Data.Count == 2);
			Assert.IsTrue(shares.Data[0].Email == "aditi.nioding@smartsheet.com" || shares.Data[1].Email == "aditi.nioding@smartsheet.com");
		}

		private static void ListReportShares(SmartsheetClient smartsheet, long reportId)
		{
			PaginatedResult<Share> shares = smartsheet.ReportResources.ShareResources.ListShares(reportId, null);
			Assert.IsTrue(shares.Data.Count == 2);
			Assert.IsTrue(shares.Data[0].Email == "aditi.nioding@smartsheet.com" || shares.Data[1].Email == "aditi.nioding@smartsheet.com");
		}

		private static string ShareWorkspace(SmartsheetClient smartsheet, long workspaceId, Share share)
		{
			string workspaceShareId = smartsheet.WorkspaceResources.ShareResources.ShareTo(workspaceId, new Share[] { share }, true)[0].Id;
			return workspaceShareId;
		}

		private static string ShareSheet(SmartsheetClient smartsheet, long sheetId, Share share)
		{
			string sheetShareId = smartsheet.SheetResources.ShareResources.ShareTo(sheetId, new Share[] { share }, true)[0].Id;
			return sheetShareId;
		}

		//private static string ShareReport(SmartsheetClient smartsheet, long reportId, Share share)
		//{
		//	IList<Share> shares = smartsheet.ReportResources.ShareResources.ShareTo(reportId, new Share[] { share }, true);
		//	return shares[0].Id;
		//}

		private static void UpdateObjectShares(SmartsheetClient smartsheet, long sheetId, long workspaceId, string sheetShareId, string workspaceShareId)
		{
			Share updatedShare = smartsheet.SheetResources.ShareResources.UpdateShare(sheetId, sheetShareId, new Share.UpdateShareBuilder(AccessLevel.VIEWER).Build());
			Assert.IsTrue(updatedShare.AccessLevel == AccessLevel.VIEWER);
			//updatedShare = smartsheet.ReportResources.ShareResources.UpdateShare(reportId, reportShareId, new Share.UpdateShareBuilder(AccessLevel.VIEWER).Build());
			//Assert.IsTrue(updatedShare.AccessLevel == AccessLevel.VIEWER);
			updatedShare = smartsheet.WorkspaceResources.ShareResources.UpdateShare(workspaceId, workspaceShareId, new Share.UpdateShareBuilder(AccessLevel.VIEWER).Build());
			Assert.IsTrue(updatedShare.AccessLevel == AccessLevel.VIEWER);
		}

		private static long CreateWorkspace(SmartsheetClient smartsheet)
		{
			Workspace ws = smartsheet.WorkspaceResources.CreateWorkspace(new Workspace.CreateWorkspaceBuilder("workspace").Build());
			long workspaceId = ws.Id.Value;
			return workspaceId;
		}

		private static long CreateReport(SmartsheetClient smartsheet)
		{
			PaginatedResult<Report> reportResult = smartsheet.ReportResources.ListReports(null);
			Assert.IsTrue(reportResult.Data.Count > 0);
			long reportId = reportResult.Data[0].Id.Value;
			return reportId;
		}

		private static long CreateGroup(SmartsheetClient smartsheet)
		{
			GroupMember member = new GroupMember.AddGroupMemberBuilder("aditi.nioding@smartsheet.com").Build();
			Group group = smartsheet.GroupResources.CreateGroup(
			new Group.CreateGroupBuilder("a group", "this is a group").SetMembers(new GroupMember[] { member }).Build());

			Assert.IsTrue(group.Name == "a group");
			return group.Id.Value;
		}

		private static long CreateSheet(SmartsheetClient smartsheet)
		{
			Column[] columnsToCreate = new Column[] {
			new Column.CreateSheetColumnBuilder("col 1", true, ColumnType.TEXT_NUMBER).Build(),
			new Column.CreateSheetColumnBuilder("col 2", false, ColumnType.DATE).Build(),
			new Column.CreateSheetColumnBuilder("col 3", false, ColumnType.TEXT_NUMBER).Build(),
			};
			Sheet createdSheet = smartsheet.SheetResources.CreateSheet(new Sheet.CreateSheetBuilder("new sheet", columnsToCreate).Build());
			Assert.IsTrue(createdSheet.Columns.Count == 3);
			Assert.IsTrue(createdSheet.Columns[1].Title == "col 2");
			return createdSheet.Id.Value;
		}
	}
}