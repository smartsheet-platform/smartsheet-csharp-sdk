namespace Smartsheet.Api.models
{
	using NUnit.Framework;
    using Smartsheet.Api.Models;
    using System;

	public class UserStatusTest
	{

		[SetUp]
		public virtual void SetUp()
		{
		}

		[Test]
		public virtual void TestUserStatus()
		{
			Assert.NotNull(UserStatus.ACTIVE);
			Assert.NotNull(UserStatus.PENDING);
			Assert.NotNull(UserStatus.DECLINED);

			Assert.AreEqual(3,Enum.GetValues(typeof(UserStatus)).Length);
		}

	}

}