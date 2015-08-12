using System.Collections.Generic;

namespace Smartsheet.Api.Internal
{
	using NUnit.Framework;
	using Smartsheet.Api.Models;
	using DefaultHttpClient = Smartsheet.Api.Internal.Http.DefaultHttpClient;
	using SearchResult = Smartsheet.Api.Models.SearchResult;
	using SearchResultItem = Smartsheet.Api.Models.SearchResultItem;

	public class SearchResourcesImplTest : ResourcesImplBase
	{

		private SearchResourcesImpl searchResources;

		[SetUp]
		public virtual void SetUp()
		{
			searchResources = new SearchResourcesImpl(new SmartsheetImpl("http://localhost:9090/1.1/", "accessToken", new DefaultHttpClient(), serializer));
		}

		[Test]
		public virtual void TestSearchResourcesImpl()
		{
		}

		[Test]
		public virtual void TestSearch()
		{
			server.setResponseBody("../../../TestSDK/resources/search.json");

			SearchResult result = searchResources.Search("brett");
			Assert.NotNull(result.Results);
			IList<SearchResultItem> results = result.Results;
			Assert.NotNull(results);
			Assert.AreEqual(50, results.Count);
			Assert.AreEqual(50, (int)result.TotalCount);
			Assert.AreEqual("Brett Task Sheet", results[0].Text);
			Assert.IsTrue(SearchObjectType.SHEET == results[0].ObjectType);
			Assert.AreEqual(714377448974212L, (long)results[0].ObjectId);
			Assert.AreEqual("Platform / Team", results[0].ContextData[0]);
		}

		[Test]
		public virtual void TestSearchSheet()
		{
			server.setResponseBody("../../../TestSDK/resources/searchSheet.json");

			SearchResult searchSheet = searchResources.SearchSheet(1234L, "java");
			Assert.NotNull(searchSheet);
			IList<SearchResultItem> results = searchSheet.Results;
			Assert.AreEqual(100,results.Count);
			Assert.AreEqual(130, (int)searchSheet.TotalCount);
			Assert.AreEqual("HomeResources.java", results[0].Text);
			Assert.IsTrue(SearchObjectType.ROW == results[0].ObjectType);
			Assert.AreEqual(7243572589160324L, (long)results[0].ObjectId);
			Assert.AreEqual("Row 12", results[0].ContextData[0]);
			Assert.IsTrue(ObjectType.SHEET == results[0].ParentObjectType);
			Assert.AreEqual(2630121841551236L, (long)results[0].ParentObjectId);
			Assert.AreEqual("SDK Code Checklist", results[0].ParentObjectName);
		}

	}

}