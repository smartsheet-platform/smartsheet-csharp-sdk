namespace Smartsheet.Api.models
{
	using NUnit.Framework;
	using Smartsheet.Api.Models;
	using System;

	public class SymbolTest
	{

		[SetUp]
		public virtual void SetUp()
		{
		}

		[Test]
		public virtual void TestSymbol()
		{
			Assert.NotNull(Symbol.FLAG);
			Assert.NotNull(Symbol.STAR);
			Assert.NotNull(Symbol.HARVEY_BALLS);
			Assert.NotNull(Symbol.RYG);
			Assert.NotNull(Symbol.PRIORITY);

			//Assert.AreEqual(5,Enum.GetValues(typeof(Symbol)).Length);
		}

	}

}