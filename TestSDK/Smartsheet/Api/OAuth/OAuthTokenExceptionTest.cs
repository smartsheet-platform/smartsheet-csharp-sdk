namespace Smartsheet.Api.OAuth
{
	using NUnit.Framework;


	public class OAuthTokenExceptionTest
	{

		[SetUp]
		public virtual void SetUp()
		{
		}

		[Test]
		public virtual void TestOAuthTokenExceptionString()
		{
			try
			{
				throw new OAuthTokenException("message");
			}
			catch (OAuthTokenException e)
			{
				Assert.AreEqual("message", e.Message);
			}
		}

		[Test]
		public virtual void TestOAuthTokenExceptionStringThrowable()
		{
			try
			{
				throw new OAuthTokenException("message", null);
			}
			catch (OAuthTokenException ex)
			{
				Assert.AreEqual("message", ex.Message);
			}
		}
	}

}