using System.Collections.Generic;

namespace Smartsheet.Api.Internal
{
	using NUnit.Framework;




	using DefaultHttpClient = Smartsheet.Api.Internal.Http.DefaultHttpClient;
	using AccessLevel = Smartsheet.Api.Models.AccessLevel;
	using MultiShare = Smartsheet.Api.Models.MultiShare;
	using Share = Smartsheet.Api.Models.Share;
	using User = Smartsheet.Api.Models.User;

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

			IList<Share> shares = shareResourcesImpl.ListShares(2906571706525572L);
			Assert.True(shares.Count == 2, "The number of shares returned is incorrect.");

			Assert.AreEqual("email@email.com", shares[0].Email, "Email attribute of the share is incorrect.");
			Assert.AreEqual("someone@somewhere.com", shares[1].Email, "Email attribute of the share is incorrect.");
		}

		[Test]
		public virtual void TestGetShare()
		{
			server.setResponseBody("../../../TestSDK/resources/getShare.json");

			Share share = shareResourcesImpl.GetShare(1234L, 12344L);

			Assert.AreEqual("email@email.com", share.Email);
			Assert.AreEqual(AccessLevel.ADMIN, share.AccessLevel);
			Assert.AreEqual(8166691168380804L, (long)share.ID);
		}

		[Test]
		public virtual void TestShareToLongShare()
		{
			server.setResponseBody("../../../TestSDK/resources/shareToOne.json");

			Share share = new Share();
			share.Email = "email@email.com";
			share.AccessLevel = AccessLevel.ADMIN;
			shareResourcesImpl.ShareTo(1234L, share);

			Assert.AreEqual("email@email.com", share.Email);
			Assert.AreEqual(AccessLevel.ADMIN, share.AccessLevel);
		}

		[Test]
		public virtual void TestShareToLongShareBoolean()
		{

			server.setResponseBody("../../../TestSDK/resources/shareToOne.json");

			Share share = new Share();
			share.Email = "email@email.com";
			share.AccessLevel = AccessLevel.ADMIN;
			shareResourcesImpl.ShareTo(1234L, share, true);

			Assert.AreEqual("email@email.com", share.Email);
			Assert.AreEqual(AccessLevel.ADMIN, share.AccessLevel);
		}

		[Test]
		public virtual void TestShareToLongMultiShare()
		{
			server.setResponseBody("../../../TestSDK/resources/shareToMany.json");

			MultiShare share = new MultiShare();
			share.AccessLevel = AccessLevel.ADMIN;
			share.Message = "I have shared a Smartsheet with you. Please review it for the latest updates";
			share.Subject = "Testing";
			share.CCMe = false;

			IList<User> users = new List<User>();
			User user = new User();
			user.Email = "john.doe@smartsheet.com";
			users.Add(user);
			user.Email = "jane.doe@smartsheet.com";
			users.Add(user);
			share.Users = users;

			IList<Share> shares = shareResourcesImpl.ShareTo(1234L, share);

			Assert.True(shares.Count == 2);
			Assert.AreEqual("john.doe@smartsheet.com", shares[0].Email);
			Assert.AreEqual("jane.doe@smartsheet.com", shares[1].Email);
		}

		[Test]
		public virtual void TestShareToLongMultiShareBoolean()
		{
			server.setResponseBody("../../../TestSDK/resources/shareToMany.json");

			MultiShare share = new MultiShare();
			share.AccessLevel = AccessLevel.ADMIN;
			share.Message = "I have shared a Smartsheet with you. Please review it for the latest updates";
			share.CCMe = false;

			IList<User> users = new List<User>();
			User user = new User();
			user.Email = "john.doe@smartsheet.com";
			users.Add(user);
			user.Email = "jane.doe@smartsheet.com";
			users.Add(user);
			share.Users = users;

			IList<Share> shares = shareResourcesImpl.ShareTo(1234L, share, true);
			Assert.True(shares.Count == 2);
			Assert.AreEqual("john.doe@smartsheet.com", shares[0].Email);
			Assert.AreEqual("jane.doe@smartsheet.com", shares[1].Email);
		}

		[Test]
		public virtual void TestUpdateShare()
		{
			server.setResponseBody("../../../TestSDK/resources/updateShare.json");
			Share share = new Share();
			share.AccessLevel = AccessLevel.ADMIN;
			Share newShare = shareResourcesImpl.UpdateShare(1234L, 123454L, share);
			Assert.AreEqual(share.AccessLevel, newShare.AccessLevel);
		}

		[Test]
		public virtual void TestDeleteShare()
		{
			server.setResponseBody("../../../TestSDK/resources/deleteShare.json");

			shareResourcesImpl.DeleteShare(1234L, 142124L);
		}

	}

}