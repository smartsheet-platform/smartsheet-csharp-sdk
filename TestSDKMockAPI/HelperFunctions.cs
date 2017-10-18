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
            SmartsheetClient ss = new SmartsheetBuilder()
            .SetBaseURI("http://localhost:8080/")
            .SetAccessToken("aaaaaaaaaaaaaaaaaaaaaaaaaa")
            .SetSDKAPITestScenario(apiScenario)
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
            catch (Exception ex)
            {
                if (ex is AssertFailedException)
                    throw ex;
 
                var exception = ex as TException;
                Assert.IsNotNull(exception, "Expected exception of type: {0}, actual type: {1}", (typeof(TException).Name), ex.GetType().Name);
                Assert.AreEqual(expectedMessage, exception.Message, "Expected message: {0}", expectedMessage);
            }
        }
    }
}
