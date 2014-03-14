namespace Smartsheet.Api
{
	using NUnit.Framework;


	using Error = Smartsheet.Api.Models.Error;

	public class ResourceNotFoundExceptionTest
	{

		[SetUp]
		public virtual void SetUp()
		{
		}

		[Test]
		public virtual void TestResourceNotFoundException()
		{
			try
			{
				Error error = new Error();
				error.ErrorCode = 1;
				error.Message = "testing testing";
				throw new ResourceNotFoundException(error);
			}
			catch (ResourceNotFoundException e)
			{
				Assert.AreEqual("testing testing",e.Message);
				Assert.AreEqual(1, e.ErrorCode);
			}
		}

	}

}