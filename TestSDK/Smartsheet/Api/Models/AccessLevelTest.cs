namespace Smartsheet.Api.Models
{
    using NUnit.Framework;
    using System;

	public class AccessLevelTest
	{

        [SetUp]
		public virtual void SetUp()
		{
		}

        [Test]
		public virtual void TestAccessLevel()
		{
			Assert.NotNull(AccessLevel.VIEWER);
			Assert.NotNull(AccessLevel.EDITOR);
			Assert.NotNull(AccessLevel.EDITOR_SHARE);
			Assert.NotNull(AccessLevel.ADMIN);
			Assert.NotNull(AccessLevel.OWNER);
			Assert.AreEqual(5,Enum.GetValues(typeof(AccessLevel)).Length);
		}
	}

}