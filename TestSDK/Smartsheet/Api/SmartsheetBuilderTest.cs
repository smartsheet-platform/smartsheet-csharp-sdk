namespace Smartsheet.Api
{
	using NUnit.Framework;
	using SmartsheetImpl = Smartsheet.Api.Internal.SmartsheetImpl;
	using DefaultHttpClient = Smartsheet.Api.Internal.Http.DefaultHttpClient;
    using Smartsheet.Api.Internal.Json;

	public class SmartsheetBuilderTest
	{

		[SetUp]
		public virtual void SetUp()
		{
		}

		[Test]
		public virtual void TestSmartsheetBuilder()
		{
		}
		[Test]
		public virtual void TestSetHttpClient()
		{

		}

		[Test]
		public virtual void TestBuild()
		{
			SmartsheetClient smartsheet = (new SmartsheetBuilder()).Build();
			Assert.True(smartsheet is SmartsheetImpl);

			SmartsheetClient ss = (SmartsheetImpl)(new SmartsheetBuilder()).SetBaseURI("http://google.com/").SetAccessToken("b").
                SetHttpClient(new DefaultHttpClient()).SetJsonSerializer(new JsonNetSerializer()).
                SetAssumedUser("user").Build();
            ss.GetType();
		}

	}

}