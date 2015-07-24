using System.Collections.Generic;

namespace Smartsheet.Api.Internal
{
	using NUnit.Framework;

	using DefaultHttpClient = Smartsheet.Api.Internal.Http.DefaultHttpClient;
	using Smartsheet.Api.Models;

	public class TemplateResourcesImplTest : ResourcesImplBase
	{

		private TemplateResourcesImpl templateResources;

		[SetUp]
		public virtual void SetUp()
		{
			templateResources = new TemplateResourcesImpl(new SmartsheetImpl("http://localhost:9090/1.1/", 
					"accessToken", new DefaultHttpClient(), serializer));
		}

		[Test]
		public virtual void TestTemplateResourcesImpl()
		{
		}
		[Test]
		public virtual void TestListPublicTemplates()
		{
			server.setResponseBody("../../../TestSDK/resources/listTemplates.json");

			PaginatedResult<Template> result = templateResources.ListPublicTemplates(new PaginationParameters(false, null, null));
			Assert.NotNull(result);
			Assert.AreEqual(2,result.Data.Count);
			Assert.AreEqual(AccessLevel.OWNER,result.Data[0].AccessLevel);
			Assert.AreEqual(3457273486960516, result.Data[0].Id);
			Assert.AreEqual("This is template 1", result.Data[0].Description);
			Assert.AreEqual("This is template 2", result.Data[1].Description);
			Assert.AreEqual(AccessLevel.VIEWER, result.Data[1].AccessLevel);
		}

		[Test]
		public virtual void TestListUserCreatedTemplates()
		{
			server.setResponseBody("../../../TestSDK/resources/listTemplates.json");

			PaginatedResult<Template> result = templateResources.ListUserCreatedTemplates(new PaginationParameters(false, null, null));
			Assert.NotNull(result);
			Assert.AreEqual(2, result.Data.Count);
			Assert.AreEqual(AccessLevel.OWNER, result.Data[0].AccessLevel);
			Assert.AreEqual(3457273486960516, result.Data[0].Id);
			Assert.AreEqual("This is template 1", result.Data[0].Description);
			Assert.AreEqual("This is template 2", result.Data[1].Description);
			Assert.AreEqual(AccessLevel.VIEWER, result.Data[1].AccessLevel);
		}
	}

}