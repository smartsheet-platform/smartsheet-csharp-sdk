namespace Smartsheet.Api.models
{
	using NUnit.Framework;
	using Smartsheet.Api.Models;
	using System;

	public class AttachmentParentTypeTest
	{

		[SetUp]
		public virtual void SetUp()
		{
		}

		[Test]
		public virtual void TestAttachmentParentType()
		{
			Assert.NotNull(AttachmentParentType.SHEET);
			Assert.NotNull(AttachmentParentType.ROW);
			Assert.NotNull(AttachmentParentType.COMMENT);
			Assert.AreEqual(3,Enum.GetValues(typeof(AttachmentParentType)).Length);
		}

	}

}