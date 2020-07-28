using System;
using Smartsheet.Api;
using Smartsheet.Api.Models;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegrationTestSDK
{
    [TestClass]
    public class UserResourcesTest : TestResources
    {
        private static string email = "test+email@invalidsmartsheet.com";
        User user;

        [TestInitialize]
        public void SetUp()
        {
            smartsheet = CreateClient();

            // Remove user if it exists from a previous run.
            PaginatedResult<User> users = smartsheet.UserResources.ListUsers(null, new PaginationParameters(true, null, null));
            foreach (User tmpUser in users.Data)
            {
                if (tmpUser.Email == email)
                {
                    smartsheet.UserResources.RemoveUser((long)tmpUser.Id, null, null, true);
                    break;
                }
            }
        }

        [TestMethod]
        public void GetMe()
        {
            UserProfile userMe = smartsheet.UserResources.GetCurrentUser();
            Assert.IsTrue(userMe.Email != null);
        }

        [TestMethod]
        public void TestUserResources()
        {
            AddUser();
            GetUser();
            UpdateUser();
            ListOneUser();
            ListAllUsers();
            RemoveUser();
        }

        private void AddUser()
        {
            User _user = new User.AddUserBuilder(email, true, true).Build();
            _user.FirstName = "Mister";
            _user.LastName = "CSharp";
            user = smartsheet.UserResources.AddUser(_user, true, true);
            Assert.IsTrue(user.Admin.Value);
            Assert.IsTrue(user.LicensedSheetCreator.Value);
        }

        private void GetUser()
        {
            smartsheet.UserResources.GetUser(user.Id.Value);
        }

        private void UpdateUser()
        {
            User _user = new User.UpdateUserBuilder(user.Id.Value, false, false).Build();
            user = smartsheet.UserResources.UpdateUser(_user);
            Assert.IsFalse(user.Admin.Value);
            Assert.IsFalse(user.LicensedSheetCreator.Value);
        }

        private void ListOneUser()
        {
            PaginatedResult<User> users = smartsheet.UserResources.ListUsers(new String[] { "test+email@invalidsmartsheet.com" }, null);
            Assert.AreEqual(1, users.TotalCount);
            Assert.AreEqual(users.Data[0].Email, "test+email@invalidsmartsheet.com");
        }

        private void ListAllUsers()
        {
            PaginatedResult<User> users = smartsheet.UserResources.ListUsers(null, null);
            // current user + added user
            Assert.IsTrue(users.Data.Count >= 2);
        }

        private void RemoveUser()
        {
            smartsheet.UserResources.RemoveUser(user.Id.Value, null, null, null);
        }

        [TestMethod]
        public void TestAlternateEmail()
        {
            UserProfile me = smartsheet.UserResources.GetCurrentUser();

            AlternateEmail altEmail1 = new AlternateEmail.AlternateEmailBuilder("test+altemail2@invalidsmartsheet.com").Build();
            AlternateEmail altEmail2 = new AlternateEmail.AlternateEmailBuilder("test+altemail3@invalidsmartsheet.com").Build();
            smartsheet.UserResources.AddAlternateEmail(me.Id.Value, new AlternateEmail[] { altEmail1, altEmail2 });

            PaginatedResult<AlternateEmail> altEmails = smartsheet.UserResources.ListAlternateEmails(me.Id.Value, null);
            Assert.IsTrue(altEmails.Data.Count >= 2);

            AlternateEmail altEmail = smartsheet.UserResources.GetAlternateEmail(me.Id.Value, altEmails.Data[0].Id.Value);
            Assert.AreEqual(altEmail.Email, "test+altemail2@invalidsmartsheet.com");

            smartsheet.UserResources.DeleteAlternateEmail(me.Id.Value, altEmails.Data[0].Id.Value);
            smartsheet.UserResources.DeleteAlternateEmail(me.Id.Value, altEmails.Data[1].Id.Value);
        }

        [TestMethod]
        public void AddProfileImage()
        {
            UserProfile me = smartsheet.UserResources.GetCurrentUser();
            smartsheet.UserResources.AddProfileImage(me.Id.Value, "../../../../../IntegrationTestSDK/curly.jpg", "image/jpeg");
            me = smartsheet.UserResources.GetCurrentUser();
            Assert.IsNotNull(me.ProfileImage.ImageId);
            const int squareProfileImageSize = 1050;
            Assert.AreEqual(squareProfileImageSize, me.ProfileImage.Width);
            Assert.AreEqual(squareProfileImageSize, me.ProfileImage.Height);
        }
    }
}