using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smartsheet.Api;
using Smartsheet.Api.Models;
using System.Configuration;

namespace IntegrationTestSDK
{
	[TestClass]
	public class UserResourcesTest
	{
		private static string otherEmail = "ericyan1@outlook.com";
		private static string myEmail = "ericyan99@outlook.com";

		[TestMethod]
		public void TestUserResources()
		{
			string accessToken = ConfigurationManager.AppSettings["accessToken"];

			SmartsheetClient smartsheet = new SmartsheetBuilder().SetAccessToken(accessToken).Build();
			
			long userId = AddUser(smartsheet);

			GetMe(smartsheet);

			UpdateUser(smartsheet, userId);

			ListUsers(smartsheet);

			ListUserSheets(smartsheet);

			RemoveUser(smartsheet, userId);
		}

		private static void RemoveUser(SmartsheetClient smartsheet, long userId)
		{
			smartsheet.UserResources.RemoveUser(userId, null, null, true);
		}

		private static void ListUserSheets(SmartsheetClient smartsheet)
		{
			PaginatedResult<Sheet> sheets = smartsheet.UserResources.SheetResources.ListSheets();
		}

		private static void ListUsers(SmartsheetClient smartsheet)
		{
			PaginatedResult<User> users = smartsheet.UserResources.ListUsers(null, null);
			Assert.IsTrue(users.TotalCount == 2);
			if (users.Data[0].Email == otherEmail)
			{
				Assert.IsTrue(!users.Data[0].Admin.Value);
			}
			else if (users.Data[1].Email == otherEmail)
			{
				Assert.IsTrue(!users.Data[1].Admin.Value);
			}
			else
			{
				Assert.Fail();
			}
		}

		private static void UpdateUser(SmartsheetClient smartsheet, long userId)
		{
			smartsheet.UserResources.UpdateUser(userId, new User.UpdateUserBuilder(false, false).Build());
		}

		private static void GetMe(SmartsheetClient smartsheet)
		{
			UserProfile userMe = smartsheet.UserResources.GetCurrentUser();
			Assert.IsTrue(userMe.FirstName == "Eric");
			Assert.IsTrue(userMe.Email == myEmail);
		}

		private static long AddUser(SmartsheetClient smartsheet)
		{
			User user = smartsheet.UserResources.AddUser(new User.AddUserBuilder(otherEmail, true, true).Build(), true);
			long userId = user.Id.Value;
			Assert.IsTrue(user.Admin.Value);
			Assert.IsTrue(user.LicensedSheetCreator.Value);
			return userId;
		}
	}
}