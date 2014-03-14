namespace Smartsheet.Api.models
{
	using NUnit.Framework;
    using Smartsheet.Api.Models;
    using System;

	public class LinkTypeTest
	{

		[SetUp]
		public virtual void SetUp()
		{
		}

		[Test]
		public virtual void TestLinkType()
		{
			Assert.NotNull(LinkType.URL);
			Assert.NotNull(LinkType.SHEETLINK);
			Assert.NotNull(LinkType.CELLLINK);

			Assert.AreEqual(3,Enum.GetValues(typeof(LinkType)).Length);
		}

	}

}