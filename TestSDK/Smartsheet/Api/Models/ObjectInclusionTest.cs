namespace Smartsheet.Api.models
{
	using NUnit.Framework;
	using Smartsheet.Api.Models;
	using System;

	public class ObjectInclusionTest
	{

		[SetUp]
		public virtual void SetUp()
		{
		}

		[Test]
		public virtual void TestObjectInclusion()
		{
			Assert.NotNull(ObjectInclusion.DISCUSSIONS);
			Assert.NotNull(ObjectInclusion.ATTACHMENTS);
			Assert.NotNull(ObjectInclusion.DATA);
			Assert.NotNull(ObjectInclusion.COLUMNS);
			Assert.NotNull(ObjectInclusion.TEMPLATES);

			Assert.AreEqual(5,Enum.GetValues(typeof(ObjectInclusion)).Length);
		}

	}

}