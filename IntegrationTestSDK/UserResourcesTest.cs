using System;
using Smartsheet.Api;
using Smartsheet.Api.Models;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegrationTestSDK
{
    [TestClass]
    public class UserResourcesTest
    {
        private static string email = "test+email@invalidsmartsheet.com";
        private SmartsheetClient smartsheet;

        [TestInitialize]
        public void SetUp()
        {
            smartsheet = new SmartsheetBuilder().SetMaxRetryTimeout(30000).Build();
        }

        [TestMethod]
        public void ListOneUser()
        {
            User user1 = smartsheet.UserResources.AddUser(
                new User.AddUserBuilder("test+email3@invalidsmartsheet.com", admin: false, licensedSheetCreator: false).Build(),
                sendEmail: true,
                allowInviteAccountAdmin: true
            );
            User user2 = smartsheet.UserResources.AddUser(
                new User.AddUserBuilder("test+email4@invalidsmartsheet.com", admin: false, licensedSheetCreator: false).Build(),
                sendEmail: true,
                allowInviteAccountAdmin: true
            );
            PaginatedResult<User> users = smartsheet.UserResources.ListUsers(new String[] { "test+email3@invalidsmartsheet.com" });
            // Verify that the total amount of users in the org went up by one
            Assert.AreEqual(1, users.TotalCount);
            Assert.AreEqual(user1.Email, "test+email3@invalidsmartsheet.com");
            smartsheet.UserResources.RemoveUser((long)user1.Id, removeFromSharing: true);
            smartsheet.UserResources.RemoveUser((long)user2.Id, removeFromSharing: true);
        }

        [TestMethod]
        public void UpdateUser()
        {
            // Create user as admin
            User user = smartsheet.UserResources.AddUser(
                new User.AddUserBuilder(email, admin: true, licensedSheetCreator: true).Build(),
                sendEmail: true,
                allowInviteAccountAdmin: true
            );
            // Validate user is an admin
            UserProfile userProfile = smartsheet.UserResources.GetUser((long)user.Id);
            Assert.AreEqual(userProfile.Admin, true);

            // Change to non-admin
            smartsheet.UserResources.UpdateUser(
                new User.UpdateUserBuilder(user.Id, admin: false, licensedSheetCreator: false).Build()
            );
            
            // Validate user is not admin
            userProfile = smartsheet.UserResources.GetUser((long)user.Id);
            Assert.AreEqual(userProfile.Admin, false);

            smartsheet.UserResources.RemoveUser((long)user.Id, removeFromSharing: true);
        }

        [TestMethod]
        public void GetMe()
        {
            UserProfile userMe = smartsheet.UserResources.GetCurrentUser();
            Assert.IsTrue(userMe.Email != null);
        }

        [TestMethod]
        public void AddRemoveUser()
        {
            PaginatedResult<User> users = smartsheet.UserResources.ListUsers(
                paging: new PaginationParameters(includeAll: true)
            );
            
            // Remove user if it exists from a previous run.
            foreach (User tmpUser in users.Data)
            {
                if (tmpUser.Email == email)
                {
                    smartsheet.UserResources.RemoveUser((long)tmpUser.Id, removeFromSharing: true);
                    users = smartsheet.UserResources.ListUsers(paging: new PaginationParameters(includeAll: true));
                    break; 
                }
            }

            int? userCount = users.TotalCount;
            User user1 = smartsheet.UserResources.AddUser(
                new User.AddUserBuilder(email, admin: true, licensedSheetCreator: true).Build(),
                sendEmail: true,
                allowInviteAccountAdmin: true
            );

            int? addedUserCount =
                smartsheet.UserResources.ListUsers(paging: new PaginationParameters(includeAll: true)).TotalCount;
            Assert.AreEqual(userCount + 1, addedUserCount);
            long userId = user1.Id.Value;
            Assert.IsTrue(user1.Admin.Value);
            Assert.IsTrue(user1.LicensedSheetCreator.Value);
            smartsheet.UserResources.RemoveUser(userId, removeFromSharing: true);
            int? removedUserCount =
                smartsheet.UserResources.ListUsers(paging: new PaginationParameters(includeAll: true)).TotalCount;
            Assert.AreEqual(addedUserCount-1, removedUserCount);
        }
    }
}