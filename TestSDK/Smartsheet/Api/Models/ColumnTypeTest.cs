namespace Smartsheet.Api.models
{
	using NUnit.Framework;
	using Smartsheet.Api.Models;
	using System;

	public class ColumnTypeTest
	{

		[SetUp]
		public virtual void SetUp()
		{
		}

		[Test]
		public virtual void TestColumnType()
		{
			Assert.NotNull(ColumnType.TEXT_NUMBER);
			Assert.NotNull(ColumnType.PICKLIST);
			Assert.NotNull(ColumnType.DATE);
			Assert.NotNull(ColumnType.CONTACT_LIST);
			Assert.NotNull(ColumnType.CHECKBOX);
				Assert.NotNull(ColumnType.DATETIME);

			Assert.AreEqual(6, Enum.GetValues(typeof(ColumnType)).Length);
		}

	}

}