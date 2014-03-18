namespace Smartsheet.Api.models
{
	using NUnit.Framework;
	using Smartsheet.Api.Models;
	using System;

	public class AttachmentSubTypeTest
	{

		[SetUp]
		public virtual void SetUp()
		{
		}

		[Test]
		public virtual void TestAttachmentSubType()
		{
			Assert.NotNull(AttachmentSubType.DOCUMENT);
			Assert.NotNull(AttachmentSubType.SPREADSHEET);
			Assert.NotNull(AttachmentSubType.PRESENTATION);
			Assert.NotNull(AttachmentSubType.PDF);
			Assert.NotNull(AttachmentSubType.DRAWING);
			Assert.AreEqual(5,Enum.GetValues(typeof(AttachmentSubType)).Length);
		}

	}

}