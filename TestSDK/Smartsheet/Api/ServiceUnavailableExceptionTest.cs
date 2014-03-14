namespace Smartsheet.Api
{
	using NUnit.Framework;


	using Error = Smartsheet.Api.Models.Error;

	public class ServiceUnavailableExceptionTest
	{

		[SetUp]
		public virtual void SetUp()
		{
		}

		[Test]
		public virtual void TestServiceUnavailableException()
		{
			try
			{
				Error error = new Error();
				error.ErrorCode = 1;
				error.Message = "testing testing";
				throw new ServiceUnavailableException(error);
			}
			catch (ServiceUnavailableException e)
			{
				Assert.AreEqual("testing testing",e.Message);
				Assert.AreEqual(1, e.ErrorCode);
			}
		}

	}

}