namespace Smartsheet.Api.Internal
{
	using NUnit.Framework;
    using Smartsheet.Api.Internal.Json;

	public class ResourcesImplBase
	{

		internal HttpTestServer server;
        internal JsonNetSerializer serializer;

        [SetUp]
		public virtual void BaseSetUp()
		{
			// Setup test server
			server = new HttpTestServer();
			server.Start();

			// Setup the serializer
			serializer = new JsonNetSerializer();
            serializer.failOnUnknownProperties = Newtonsoft.Json.MissingMemberHandling.Error;
		}

        [TearDown]
		public virtual void BaseTearDown()
		{
			server.Stop();
		}
	}

}