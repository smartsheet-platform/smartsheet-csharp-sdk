using System.Collections.Generic;

namespace Smartsheet.Api.Internal
{
	using NUnit.Framework;
	using DefaultHttpClient = Smartsheet.Api.Internal.Http.DefaultHttpClient;
	using Smartsheet.Api.Models;

	public class ShareResourcesImplTest : ResourcesImplBase
	{

		private ShareResourcesImpl shareResourcesImpl;

		[SetUp]
		public virtual void SetUp()
		{
			shareResourcesImpl = new ShareResourcesImpl(new SmartsheetImpl("http://localhost:9090/1.1/", "accessToken", new DefaultHttpClient(), serializer), "sheet");
		}

		[Test]
		public virtual void TestShareResourcesImpl()
		{
		}

		[Test]
		public virtual void TestListShares()
		{

			server.setResponseBody("../../../TestSDK/resources/listShares.json");

			PaginatedResult<Share> result = shareResourcesImpl.ListShares(2906571706525572L, new PaginationParameters(false, 100, 1));
			Assert.True(result.Data.Count == 2, "The number of shares returned is incorrect.");

			Assert.AreEqual("john.doe@smartsheet.com", result.Data[0].Email, "Email attribute of the share is incorrect.");
			Assert.AreEqual(null, result.Data[1].Email, "Email attribute of the share is incorrect.");
			Assert.IsTrue(AccessLevel.OWNER == result.Data[0].AccessLevel);
			Assert.IsTrue(ShareType.USER == result.Data[0].Type);
			Assert.IsTrue(2331373580117892 == result.Data[1].GroupId);
			Assert.IsTrue(ShareType.GROUP == result.Data[1].Type);
			Assert.IsTrue("AQAISF82FOeE" == result.Data[1].Id);
			Assert.IsTrue(AccessLevel.ADMIN == result.Data[1].AccessLevel);

		}

		[Test]
		public virtual void TestGetShare()
		{
			server.setResponseBody("../../../TestSDK/resources/getShare.json");

			Share share = shareResourcesImpl.GetShare(1234L, "12sdf3fg44L");

			Assert.AreEqual(null, share.Email);
			Assert.AreEqual(2331373580117892, share.GroupId);
			Assert.AreEqual(AccessLevel.ADMIN, share.AccessLevel);
			Assert.AreEqual("AQAISF82FOeE", share.Id);
			Assert.AreEqual("Group 1", share.Name);

		}

		[Test]
		public virtual void TestShareTo()
		{
			server.setResponseBody("../../../TestSDK/resources/shareToOne.json");

			Share share = new Share.ShareToOneBuilder("jane.doe@smartsheet.com", AccessLevel.EDITOR).Build();
			IList<Share> shares = shareResourcesImpl.ShareTo(1234L, new Share[] { share }, true);

			Assert.AreEqual("jane.doe@smartsheet.com", shares[0].Email);
			Assert.AreEqual(AccessLevel.EDITOR, shares[0].AccessLevel);
			Assert.AreEqual("AAAFeF82FOeE", shares[0].Id);
			Assert.AreEqual(ShareType.USER, shares[0].Type);
			Assert.AreEqual("Jane Doe", shares[0].Name);

		}

		//[Test]
		//public virtual void TestShareToLongShareBoolean()
		//{

		//	server.setResponseBody("../../../TestSDK/resources/shareToOne.json");

		//	Share share = new Share();
		//	share.Email = "email@email.com";
		//	share.AccessLevel = AccessLevel.ADMIN;
		//	shareResourcesImpl.ShareTo(1234L, share, true);

		//	Assert.AreEqual("email@email.com", share.Email);
		//	Assert.AreEqual(AccessLevel.ADMIN, share.AccessLevel);
		//}

		//[Test]
		//public virtual void TestShareToLongMultiShare()
		//{
		//	server.setResponseBody("../../../TestSDK/resources/shareToMany.json");

		//	MultiShare share = new MultiShare();
		//	share.AccessLevel = AccessLevel.ADMIN;
		//	share.Message = "I have shared a Smartsheet with you. Please review it for the latest updates";
		//	share.Subject = "Testing";
		//	share.CCMe = false;

		//	IList<User> users = new List<User>();
		//	User user = new User();
		//	user.Email = "john.doe@smartsheet.com";
		//	users.Add(user);
		//	user.Email = "jane.doe@smartsheet.com";
		//	users.Add(user);
		//	share.Users = users;

		//	IList<Share> shares = shareResourcesImpl.ShareTo(1234L, share);

		//	Assert.True(shares.Count == 2);
		//	Assert.AreEqual("john.doe@smartsheet.com", shares[0].Email);
		//	Assert.AreEqual("jane.doe@smartsheet.com", shares[1].Email);
		//}

		//[Test]
		//public virtual void TestShareToLongMultiShareBoolean()
		//{
		//	server.setResponseBody("../../../TestSDK/resources/shareToMany.json");

		//	MultiShare share = new MultiShare();
		//	share.AccessLevel = AccessLevel.ADMIN;
		//	share.Message = "I have shared a Smartsheet with you. Please review it for the latest updates";
		//	share.CCMe = false;

		//	IList<User> users = new List<User>();
		//	User user = new User();
		//	user.Email = "john.doe@smartsheet.com";
		//	users.Add(user);
		//	user.Email = "jane.doe@smartsheet.com";
		//	users.Add(user);
		//	share.Users = users;

		//	IList<Share> shares = shareResourcesImpl.ShareTo(1234L, share, true);
		//	Assert.True(shares.Count == 2);
		//	Assert.AreEqual("john.doe@smartsheet.com", shares[0].Email);
		//	Assert.AreEqual("jane.doe@smartsheet.com", shares[1].Email);
		//}

		[Test]
		public virtual void TestUpdateShare()
		{
			server.setResponseBody("../../../TestSDK/resources/updateShare.json");
			Share share = new Share.UpdateShareBuilder(AccessLevel.VIEWER).Build();
			Share newShare = shareResourcesImpl.UpdateShare(1234L, "12dfgfg34sdf54L", share);
			Assert.AreEqual(share.AccessLevel, newShare.AccessLevel);
			Assert.AreEqual(newShare.UserId, 1539725208119172);
		}

		[Test]
		public virtual void TestDeleteShare()
		{
			server.setResponseBody("../../../TestSDK/resources/deleteShare.json");

			shareResourcesImpl.DeleteShare(1234L, "1dfg42124hgL");
		}

	}

}