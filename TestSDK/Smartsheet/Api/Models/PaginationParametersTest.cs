namespace Smartsheet.Api.models
{
	using NUnit.Framework;
	using Smartsheet.Api.Models;
	using System;
	using System.Collections.Generic;

	public class PaginationParametersTest
	{

		[Test]
		public void testPaginationParameters()
		{
			PaginationParameters parameters = new PaginationParameters(true, 1, 1);

			Assert.IsTrue(parameters.IncludeAll);
			Assert.AreEqual(1, parameters.PageSize);
			Assert.AreEqual(1, parameters.Page);
		}

		[Test]
		public void testToQueryString()
		{
			PaginationParameters parameters1 = new PaginationParameters(true, null, null);
			Assert.AreEqual("?includeAll=true", parameters1.ToQueryString());

			PaginationParameters parameters2 = new PaginationParameters(true, 1, 1);
			Assert.AreEqual("?includeAll=true", parameters2.ToQueryString());

			PaginationParameters parameters3 = new PaginationParameters(false, 1, 1);
			Assert.AreEqual("?page=1&pageSize=1&includeAll=false", parameters3.ToQueryString());
		}

		[Test]
		public void testToHashMap()
		{
			PaginationParameters parameters1 = new PaginationParameters(true, null, null);
			IDictionary<string, string> map = parameters1.toDictionary();
			Assert.IsTrue(map.ContainsKey("includeAll"));
			Assert.AreEqual("true", map["includeAll"]);
			Assert.IsFalse(map.ContainsKey("pageSize"));
			Assert.IsFalse(map.ContainsKey("page"));

			PaginationParameters parameters2 = new PaginationParameters(true, 1, 1);
			map = parameters2.toDictionary();
			Assert.IsTrue(map.ContainsKey("includeAll"));
			Assert.AreEqual("true", map["includeAll"]);
			Assert.IsFalse(map.ContainsKey("pageSize"));
			Assert.IsFalse(map.ContainsKey("page"));

			PaginationParameters parameters3 = new PaginationParameters(false, 1, 1);
			map = parameters3.toDictionary();
			Assert.IsTrue(map.ContainsKey("includeAll"));
			Assert.AreEqual("false", map["includeAll"]);
			Assert.IsTrue(map.ContainsKey("pageSize"));
			Assert.AreEqual("1", map["pageSize"]);
			Assert.IsTrue(map.ContainsKey("page"));
			Assert.AreEqual("1", map["page"]);
		}
	}
}
