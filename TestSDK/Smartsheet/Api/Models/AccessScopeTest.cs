namespace com.smartsheet.api.models
{
	using NUnit.Framework;
    using Smartsheet.Api.Models;
    using System;


	public class AccessScopeTest
	{

		[SetUp]
		public virtual void SetUp()
		{
		}

		[Test]
		public virtual void TestAccessScope()
		{
			Assert.NotNull(AccessScope.READ_SHEETS);
			Assert.NotNull(AccessScope.WRITE_SHEETS);
			Assert.NotNull(AccessScope.SHARE_SHEETS);
			Assert.NotNull(AccessScope.DELETE_SHEETS);
			Assert.NotNull(AccessScope.CREATE_SHEETS);
			Assert.NotNull(AccessScope.ADMIN_USERS);
			Assert.NotNull(AccessScope.ADMIN_SHEETS);
			Assert.NotNull(AccessScope.ADMIN_WORKSPACES);
            Assert.AreEqual(8, Enum.GetValues(typeof(AccessScope)).Length);
		}

	}

}