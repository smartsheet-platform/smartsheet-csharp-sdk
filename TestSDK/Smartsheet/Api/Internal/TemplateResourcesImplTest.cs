using System.Collections.Generic;

namespace Smartsheet.Api.Internal
{
	using NUnit.Framework;



	using DefaultHttpClient = Smartsheet.Api.Internal.Http.DefaultHttpClient;
	using AccessLevel = Smartsheet.Api.Models.AccessLevel;
	using Template = Smartsheet.Api.Models.Template;

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
		public virtual void TestListTemplates()
		{
			server.setResponseBody("../../../TestSDK/resources/listTemplates.json");

			IList<Template> templates = templateResources.ListTemplates();
			Assert.NotNull(templates);
			Assert.AreEqual(11,templates.Count);
			Assert.AreEqual(AccessLevel.ADMIN, templates[0].AccessLevel);
			Assert.AreEqual(4705477956265860L, (long)templates[0].ID);
			Assert.AreEqual("testing1234", templates[0].Description);
			Assert.AreEqual("<feature> -  Issues Template", templates[0].Name);
		}
	}

}