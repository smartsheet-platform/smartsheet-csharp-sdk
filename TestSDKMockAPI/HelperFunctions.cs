using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smartsheet.Api;
using Smartsheet.Api.Models;
using Smartsheet.Api.Internal.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;

namespace TestSDKMockAPI
{
    public static class HelperFunctions
    {
        public static SmartsheetClient SetupClient(string apiScenario)
        {
			TestHttpClient testHttpClient = new TestHttpClient(apiScenario);
            SmartsheetClient ss = new SmartsheetBuilder()
            .SetBaseURI("http://localhost:8082/")
            .SetAccessToken("aaaaaaaaaaaaaaaaaaaaaaaaaa")
            .SetHttpClient(testHttpClient)
            .Build();

            return ss;
        }

        ///<summary>
        /// Runs the action statement and asserts that it causes an exception with the expected type and message
        ///</summary>
        ///<typeparam name="TException"></typeparam>
        ///<param name="action"></param>
        ///<param name="expectedMessage"></param>
        public static void AssertRaisesException<TException>(Action action, string expectedMessage)
            where TException : Exception
        {
            try
            {
                action();
                Assert.Fail("Call suceeded. Expected exception of type: {0} with message: {1}", (typeof(TException).Name), expectedMessage);
            }
            catch (TException ex)
            {
                Assert.AreEqual(expectedMessage, ex.Message, "Expected message: {0}", expectedMessage);
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected exception of type: {0}, actual type: {1}", (typeof(TException).Name), ex.GetType().Name);
            }
        }
    }
}
