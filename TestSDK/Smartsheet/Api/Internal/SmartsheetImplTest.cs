namespace Smartsheet.Api.Internal
{
	using NUnit.Framework;


	using DefaultHttpClient = Smartsheet.Api.Internal.Http.DefaultHttpClient;

	public class SmartsheetImplTest : ResourcesImplBase
	{

		private SmartsheetImpl smartsheet;

		[SetUp]
		public virtual void SetUp()
		{
			smartsheet = new SmartsheetImpl("http://localhost:9090/1.1/", "accessToken", new DefaultHttpClient(), serializer);
		}

		[Test]
		public virtual void TestFinalize()
		{

		}

		[Test]
		public virtual void TestSmartsheetImpl()
		{

		}

		[Test]
		public virtual void TestGetHttpClient()
		{

		}

		[Test]
		public virtual void TestGetJsonSerializer()
		{

		}

		[Test]
		public virtual void TestGetBaseURI()
		{

		}

		[Test]
		public virtual void TestGetAssumedUser()
		{

		}

		[Test]
		public virtual void TestGetAccessToken()
		{

		}

		[Test]
		public virtual void TestHome()
		{
			Assert.NotNull(smartsheet.HomeResources);
		}

		[Test]
		public virtual void TestWorkspaces()
		{
			Assert.NotNull(smartsheet.WorkspaceResources);
		}

		[Test]
		public virtual void TestFolders()
		{
			Assert.NotNull(smartsheet.FolderResources);
		}

		[Test]
		public virtual void TestTemplates()
		{
			Assert.NotNull(smartsheet.TemplateResources);
		}

		[Test]
		public virtual void TestSheets()
		{
			Assert.NotNull(smartsheet.SheetResources);
		}

		//[Test]
		//public virtual void TestColumns()
		//{
		//	Assert.NotNull(smartsheet());
		//}

		//[Test]
		//public virtual void TestRows()
		//{
		//	Assert.NotNull(smartsheet.Rows());
		//}

		//[Test]
		//public virtual void TestAttachments()
		//{
		//	Assert.NotNull(smartsheet.Attachments());
		//}

		//[Test]
		//public virtual void TestDiscussions()
		//{
		//	Assert.NotNull(smartsheet());
		//}

		//[Test]
		//public virtual void TestComments()
		//{
		//	Assert.NotNull(smartsheet.Comments());
		//}

		[Test]
		public virtual void TestUsers()
		{
			Assert.NotNull(smartsheet.UserResources);
		}

		[Test]
		public virtual void TestSearch()
		{
			Assert.NotNull(smartsheet.SearchResources);
		}

		[Test]
		public virtual void TestSetAssumedUser()
		{
			smartsheet.AssumedUser = "user";
		}

		[Test]
		public virtual void TestSetAccessToken()
		{
			smartsheet.AccessToken = "1234";
		}

	}

}