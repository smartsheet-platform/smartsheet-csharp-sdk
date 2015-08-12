namespace Smartsheet.Api.models
{
	using NUnit.Framework;
	using Smartsheet.Api.Models;
	using System;

	public class IdentifiableModelTest
	{

		[SetUp]
		public virtual void SetUp()
		{
		}

		[Test]
		public virtual void TestHashCode()
		{
			Row row = new Row();
			// Same Object
			Assert.AreEqual(row,row);
			row.Id = 1234L;
			Row row1 = new Row();
			row1.Id = 1234L;
			row.Equals(row);
			// Same id in two different objects
			Assert.AreEqual(row,row1);

			// Different Objects
			Assert.AreNotEqual(row,new object());
		}

		[Test]
		public virtual void TestEqualsObject()
		{
			Row row = new Row();
			Assert.NotNull(row.GetHashCode());
		}

	}

}