namespace Smartsheet.Api.models
{
	using NUnit.Framework;
	using Smartsheet.Api.Models;
	using System;

	public class PaperSizeTest
	{

		[SetUp]
		public virtual void SetUp()
		{
		}

		[Test]
		public virtual void TestPaperSize()
		{

			Assert.NotNull(PaperSize.LETTER);
			Assert.NotNull(PaperSize.LEGAL);
			Assert.NotNull(PaperSize.WIDE);
			Assert.NotNull(PaperSize.ARCHD);
			Assert.NotNull(PaperSize.A4);
			Assert.NotNull(PaperSize.A3);
			Assert.NotNull(PaperSize.A2);
			Assert.NotNull(PaperSize.A1);
			Assert.NotNull(PaperSize.A0);


			Assert.AreEqual(9,Enum.GetValues(typeof(PaperSize)).Length);
		}

	}

}