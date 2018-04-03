using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smartsheet.Api;
using Smartsheet.Api.Models;
using System.Collections.Generic;
using System.Configuration;

namespace IntegrationTestSDK
{
	using NUnit.Framework;
	
	public class FavoriteResourcesTest
	{

		[Test]
		public void TestFavoriteResources()
		{
			string accessToken = ConfigurationManager.AppSettings["accessToken"];

			SmartsheetClient smartsheet = new SmartsheetBuilder().SetAccessToken(accessToken).Build();

			RemoveAllFavoritesBeforeRunningTest(smartsheet);

			long sheetId;
			long folderId;
			//long reportId;
			//long templateId;
			long workspaceId;

			AddFavorites(smartsheet, out sheetId, out folderId, out workspaceId);

			RemoveAndListFavorites(smartsheet, sheetId, folderId, workspaceId);
		}

		private static void RemoveAndListFavorites(SmartsheetClient smartsheet, long sheetId, long folderId, long workspaceId)
		{
			smartsheet.FavoriteResources.RemoveFavorites(ObjectType.SHEET, new long[] { sheetId });
			smartsheet.FavoriteResources.RemoveFavorites(ObjectType.FOLDER, new long[] { folderId });
			//smartsheet.FavoriteResources.RemoveFavorites(ObjectType.REPORT, new long[] { reportId });
			//smartsheet.FavoriteResources().RemoveFavorites(ObjectType.TEMPLATE, new long[] { templateId });
			smartsheet.FavoriteResources.RemoveFavorites(ObjectType.WORKSPACE, new long[] { workspaceId });

			PaginatedResult<Favorite> favsResult = smartsheet.FavoriteResources.ListFavorites(new PaginationParameters(true, null, null));
			Assert.IsTrue(favsResult.Data.Count == 0);
		}

		private static void AddFavorites(SmartsheetClient smartsheet, out long sheetId, out long folderId, out long workspaceId)
		{
			sheetId = CreateSheet(smartsheet);
			folderId = CreateFolder(smartsheet);
			//reportId = CreateReport(smartsheet);
			//templateId = CreateTemplate(smartsheet);
			workspaceId = CreateWorkspace(smartsheet);

			Favorite[] favs = new Favorite[] { 
			new Favorite.AddFavoriteBuilder(ObjectType.SHEET, sheetId).Build(),
			new Favorite.AddFavoriteBuilder(ObjectType.FOLDER, folderId).Build(),
			//new Favorite.AddFavoriteBuilder(ObjectType.REPORT, reportId).Build(),
			//new Favorite.AddFavoriteBuilder(ObjectType.TEMPLATE, templateId).Build(),
			new Favorite.AddFavoriteBuilder(ObjectType.WORKSPACE, workspaceId).Build()
			};

			IList<Favorite> favsAdded = smartsheet.FavoriteResources.AddFavorites(favs);
			Assert.IsTrue(favsAdded.Count == 3);
		}

		private static void RemoveAllFavoritesBeforeRunningTest(SmartsheetClient smartsheet)
		{
			PaginatedResult<Favorite> favsToDelete = smartsheet.FavoriteResources.ListFavorites(new PaginationParameters(true, null, null));
			for (int i = 0; i < 6; i++)
			{
				IList<long> set = new List<long>();
				ObjectType type = ObjectType.FOLDER;
				foreach (Favorite fav in favsToDelete.Data)
				{
					switch (i)
					{
						case 0:
							if (fav.Type == ObjectType.FOLDER)
							{
								set.Add(fav.ObjectId.Value);
							}
							type = ObjectType.FOLDER;
							break;
						case 1:
							if (fav.Type == ObjectType.REPORT)
							{
								set.Add(fav.ObjectId.Value);
							}
							type = ObjectType.REPORT;
							break;
						case 2:
							if (fav.Type == ObjectType.SHEET)
							{
								set.Add(fav.ObjectId.Value);
							}
							type = ObjectType.SHEET;
							break;
						case 3:
							if (fav.Type == ObjectType.TEMPLATE)
							{
								set.Add(fav.ObjectId.Value);
							}
							type = ObjectType.TEMPLATE;
							break;
						case 4:
							if (fav.Type == ObjectType.WORKSPACE)
							{
								set.Add(fav.ObjectId.Value);
							}
							type = ObjectType.WORKSPACE;
							break;
						case 5:
							if (fav.Type == ObjectType.SIGHT)
							{
								set.Add(fav.ObjectId.Value);
							}
							type = ObjectType.SIGHT;
							break;
						default:
							Assert.Fail();
							break;
					}
				}
				if (set.Count > 0)
				{
					smartsheet.FavoriteResources.RemoveFavorites(type, set);
				}
			}
		}

		private static long CreateWorkspace(SmartsheetClient smartsheet)
		{
			Workspace ws = smartsheet.WorkspaceResources.CreateWorkspace(new Workspace.CreateWorkspaceBuilder("workspace").Build());
			long workspaceId = ws.Id.Value;
			return workspaceId;
		}

		// only private sheet-type template ID is allowed.
		//private static long CreateTemplate(SmartsheetClient smartsheet)
		//{
		//	PaginatedResult<Template> templateResult = smartsheet.TemplateResources.ListUserCreatedTemplates(null);
		//	Assert.IsTrue(templateResult.Data.Count > 0);
		//	long templateId = templateResult.Data[0].Id.Value;
		//	return templateId;
		//}

		//private static long CreateReport(SmartsheetClient smartsheet)
		//{
		//	PaginatedResult<Report> reportResult = smartsheet.ReportResources.ListReports(null);
		//	Assert.IsTrue(reportResult.Data.Count > 0);
		//	long reportId = reportResult.Data[0].Id.Value;
		//	return reportId;
		//}

		private static long CreateFolder(SmartsheetClient smartsheet)
		{
			Folder folder = smartsheet.HomeResources.FolderResources.CreateFolder(new Folder.CreateFolderBuilder("folder").Build());
			long folderId = folder.Id.Value;
			return folderId;
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