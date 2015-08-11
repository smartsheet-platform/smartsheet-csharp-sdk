using System;
using NUnit.Framework;
using System.Collections.Generic;
using Smartsheet.Api.Internal.Util;
using Smartsheet.Api.Models;

namespace TestSDK.Smartsheet.Api.Internal.Util
{
	class QueryUtilTest
	{
		[Test]
		public virtual void TestGenerateCommaSeparatedList()
		{
			HashSet<long> list = new HashSet<long>();
			list.Add(123456789L);
			list.Add(987654321L);

			// List
			string commaSeparatedStringList = QueryUtil.GenerateCommaSeparatedList(list);
			Assert.AreEqual("123456789,987654321", commaSeparatedStringList);

			// EnumSet
			string commaSeparatedStringEnumSet = QueryUtil.GenerateCommaSeparatedList(new List<RowInclusion> { RowInclusion.DISCUSSIONS, RowInclusion.ATTACHMENTS });
			Assert.AreEqual("discussions,attachments", commaSeparatedStringEnumSet);

			Assert.AreEqual("", QueryUtil.GenerateCommaSeparatedList<object>(null));
		}

		[Test]
		public virtual void TestGenerateUrl()
		{
			Assert.AreEqual("", QueryUtil.GenerateUrl(null, null));
			Assert.AreEqual("url", QueryUtil.GenerateUrl("url", null));

			Dictionary<string, string> map = new Dictionary<string, string>();
			map.Add("param1", "1");
			map.Add("param2", "2");
			Assert.AreEqual("?param1=1&param2=2", QueryUtil.GenerateUrl(null, map));
			map.Clear();

			map.Add("param3", null);
			Assert.AreEqual("?param3=", QueryUtil.GenerateUrl(null, map));
		}
	}
}
