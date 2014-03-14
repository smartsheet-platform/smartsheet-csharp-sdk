namespace Smartsheet.Api
{
	using NUnit.Framework;
    using System;

	public class SmartsheetExceptionTest
	{

		[SetUp]
		public virtual void SetUp()
		{
		}

		[Test]
		public virtual void TestSmartsheetExceptionString()
		{
            try
            {
                throw new SmartsheetException("My Exception");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("My Exception", ex.Message);
                Assert.AreEqual(typeof(SmartsheetException), ex.GetType());
            }
		}

		[Test]
		public virtual void TestSmartsheetExceptionStringThrowable()
		{
			System.NullReferenceException expected = new System.NullReferenceException();

            try
            {
                throw new SmartsheetException("Throwable exception", expected);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Throwable exception", ex.Message);
                Assert.AreEqual(typeof(SmartsheetException), ex.GetType());
                Assert.That(ex.InnerException, Is.InstanceOf<NullReferenceException>());
            }
		}

		[Test]
		public virtual void TestSmartsheetExceptionException()
		{
			System.NullReferenceException expected = new System.NullReferenceException();
            try
            {
                throw new SmartsheetException(expected);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(typeof(SmartsheetException), ex.GetType());
                Assert.That(ex.InnerException, Is.InstanceOf<NullReferenceException>());
            }
		}

	}

}