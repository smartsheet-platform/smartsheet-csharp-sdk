namespace Smartsheet.Api.models
{
	using NUnit.Framework;
	using Smartsheet.Api.Models;
	using System;

	public class ColumnTagTest
	{

		[SetUp]
		public virtual void SetUp()
		{
		}

		[Test]
		public virtual void TestColumnTag()
		{
			Assert.NotNull(ColumnTag.CALENDAR_START_DATE);
			Assert.NotNull(ColumnTag.CALENDAR_END_DATE);
			Assert.NotNull(ColumnTag.GANTT_START_DATE);
			Assert.NotNull(ColumnTag.GANTT_END_DATE);
			Assert.NotNull(ColumnTag.GANTT_PERCENT_COMPLETE);
			Assert.NotNull(ColumnTag.GANTT_DISPLAY_LABEL);
			Assert.NotNull(ColumnTag.GANTT_PREDECESSOR);
			Assert.NotNull(ColumnTag.GANTT_DURATION);
			Assert.NotNull(ColumnTag.GANTT_ASSIGNED_RESOURCE);
		}

	}


}