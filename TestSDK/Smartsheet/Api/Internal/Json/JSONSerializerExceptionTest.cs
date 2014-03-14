namespace Smartsheet.Api.Internal.Json
{
	using NUnit.Framework;
    using System;

	public class JSONSerializerExceptionTest
	{

		[SetUp]
		public virtual void SetUp()
		{
		}

		[Test]
		public virtual void TestJSONSerializerExceptionString()
		{
            Assert.Throws(Is.TypeOf<JsonSerializationException>().And.Message.EqualTo("Test Exception"),
                delegate { throw new JsonSerializationException("Test Exception"); });
		}



		[Test]
		public virtual void TestJSONSerializerExceptionStringThrowable()
		{
            JsonSerializationException e = new JsonSerializationException("test");
            string message = "Test Exception1";
            try
            {
                throw new JsonSerializationException(message, e);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Test Exception1", ex.Message);
                Assert.AreEqual(typeof(JsonSerializationException), ex.GetType());
                Assert.That(ex.InnerException, Is.InstanceOf<JsonSerializationException>());
                Assert.AreEqual(ex.InnerException.Message, "test");
            }
		}

		[Test]
		public virtual void TestJSONSerializerExceptionException()
		{
            JsonSerializationException e = new JsonSerializationException("test");
            try
            {
                throw new JsonSerializationException(e);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("test", ex.Message);
                Assert.AreEqual(typeof(JsonSerializationException), ex.GetType());
                Assert.That(ex.InnerException, Is.InstanceOf<JsonSerializationException>());
            }
		}

	}

}