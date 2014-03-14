using System.Collections.Generic;

namespace Smartsheet.Api.Internal
{
	using NUnit.Framework;



	using DefaultHttpClient = Smartsheet.Api.Internal.Http.DefaultHttpClient;
	using User = Smartsheet.Api.Models.User;
	using UserProfile = Smartsheet.Api.Models.UserProfile;
	using UserStatus = Smartsheet.Api.Models.UserStatus;

	public class UserResourcesImplTest : ResourcesImplBase
	{

		private UserResourcesImpl userResources;

		[SetUp]
		public virtual void SetUp()
		{
			userResources = new UserResourcesImpl(new SmartsheetImpl("http://localhost:9090/1.1/", "accessToken", new DefaultHttpClient(), serializer));
		}

		[Test]
		public virtual void TestUserResourcesImpl()
		{
		}
		[Test]
		public virtual void TestListUsers()
		{
			server.ResponseBody = "../../../TestSDK/resources/listUsers.json";

			IList<User> users = userResources.ListUsers();
			Assert.NotNull(users);
			Assert.AreEqual(2, users.Count);
			Assert.AreEqual(94094820842L, (long)users[0].ID);
			Assert.AreEqual(true, users[0].Admin);
			Assert.AreEqual("john.doe@smartsheet.com", users[0].Email);
			Assert.AreEqual("John Doe", users[0].Name);
			Assert.AreEqual(true, users[0].LicensedSheetCreator);
			Assert.AreEqual(UserStatus.ACTIVE, users[0].Status);
		}

		[Test]
		public virtual void TestAddUserUser()
		{
			server.ResponseBody = "../../../TestSDK/resources/addUser.json";

			User user = new User();
			user.Admin = true;
			user.Email = "test@test.com";
			user.FirstName = "test425";
			user.LastName = "test425";
			user.LicensedSheetCreator = true;
			User newUser = userResources.AddUser(user);

			Assert.AreEqual("test@test.com", newUser.Email);
			Assert.AreEqual("test425 test425", newUser.Name);
			Assert.AreEqual(false, newUser.Admin);
			Assert.AreEqual(true, newUser.LicensedSheetCreator);
			Assert.AreEqual(3210982882338692L, (long)newUser.ID);
		}

		[Test]
		public virtual void TestAddUserUserBoolean()
		{
			server.ResponseBody = "../../../TestSDK/resources/addUser.json";

			User user = new User();
			user.Admin = true;
			user.Email = "test@test.com";
			user.FirstName = "test425";
			user.LastName = "test425";
			user.LicensedSheetCreator = true;
			User newUser = userResources.AddUser(user, false);

			Assert.AreEqual("test@test.com", newUser.Email);
			Assert.AreEqual("test425 test425", newUser.Name);
			Assert.AreEqual(false, newUser.Admin);
			Assert.AreEqual(true, newUser.LicensedSheetCreator);
			Assert.AreEqual(3210982882338692L, (long)newUser.ID);
		}

		[Test]
		public virtual void TestGetCurrentUser()
		{
			server.ResponseBody = "../../../TestSDK/resources/getCurrentUser.json";

			UserProfile user = userResources.currentUser;
			Assert.AreEqual("email@email.com",user.Email);
			Assert.AreEqual(6199527427336068L, (long)user.ID);
			Assert.AreEqual("Brett", user.FirstName);
			Assert.AreEqual("Batie", user.LastName);
		}

		[Test]
		public virtual void TestUpdateUser()
		{
			server.ResponseBody = "../../../TestSDK/resources/updateUser.json";

			User user = new User();
			user.ID = 1234L;
			user.Admin = true;
			user.LicensedSheetCreator = true;
			User updatedUser = userResources.UpdateUser(user);
			Assert.AreEqual("email@email.com", updatedUser.Email);
			Assert.AreEqual(false, updatedUser.Admin);
			Assert.AreEqual(true, updatedUser.LicensedSheetCreator);
			Assert.AreEqual(8166691168380804L, (long)updatedUser.ID);
			Assert.AreEqual(UserStatus.ACTIVE, updatedUser.Status);
		}

		[Test]
		public virtual void TestDeleteUser()
		{
			server.ResponseBody = "../../../TestSDK/resources/deleteUser.json";

			userResources.DeleteUser(1234L);
		}

	}

}