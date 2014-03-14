namespace Smartsheet.Api.models
{
	using NUnit.Framework;
    using Smartsheet.Api.Models;
    using System;

	public class SheetEmailFormatTest
	{

		[SetUp]
		public virtual void SetUp()
		{
		}

		[Test]
		public virtual void TestSheetEmail()
		{
			Assert.NotNull(SheetEmailFormat.PDF);
			Assert.NotNull(SheetEmailFormat.EXCEL);
			Assert.AreEqual(2,Enum.GetValues(typeof(SheetEmailFormat)).Length);
		}

	}

}