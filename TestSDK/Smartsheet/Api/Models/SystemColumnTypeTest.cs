namespace Smartsheet.Api.models
{
	using NUnit.Framework;
    using Smartsheet.Api.Models;
    using System;

	public class SystemColumnTypeTest
	{

		[SetUp]
		public virtual void SetUp()
		{
		}

		[Test]
		public virtual void TestSystemColumnType()
		{
			Assert.NotNull(SystemColumnType.AUTO_NUMBER);
			Assert.NotNull(SystemColumnType.MODIFIED_DATE);
			Assert.NotNull(SystemColumnType.MODIFIED_BY);
			Assert.NotNull(SystemColumnType.CREATED_DATE);
			Assert.NotNull(SystemColumnType.CREATED_BY);

			Assert.AreEqual(5,Enum.GetValues(typeof(SystemColumnType)).Length);
		}

	}

}