using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smartsheet.Api;
using Smartsheet.Api.Models;

namespace IntegrationTestSDK
{
    [TestClass]
    public class EventResourcesTest
    {
        [TestMethod]
        public void TestListEvents()
        {
            SmartsheetClient smartsheet = new SmartsheetBuilder().SetMaxRetryTimeout(30000).Build();

            DateTime lastHour = DateTime.Today.AddHours(-1);
            EventResult eventResult = smartsheet.EventResources.ListEvents(lastHour, null, 10, false);
            Assert.IsTrue(eventResult.Data.Count <= 10);
            foreach(Event _event in eventResult.Data)
            {
                Assert.IsNotNull(_event.ObjectType);
                Assert.IsNotNull(_event.Action);
                Assert.IsNotNull(_event.ObjectId);
                Assert.IsNotNull(_event.EventId);
                Assert.IsTrue(_event.EventTimestamp is string);
                Assert.IsNotNull(_event.UserId);
                Assert.IsNotNull(_event.RequestUserId);
                Assert.IsNotNull(_event.Source);
            }

            while(eventResult.MoreAvailable == true)
            {
                eventResult = smartsheet.EventResources.ListEvents(null, eventResult.NextStreamPosition, 10, true);
                Assert.IsTrue(eventResult.Data.Count != 0);
                Assert.IsTrue(eventResult.Data.Count <= 10);
                foreach(Event _event in eventResult.Data)
                {
                    Assert.IsNotNull(_event.ObjectType);
                    Assert.IsNotNull(_event.Action);
                    Assert.IsNotNull(_event.ObjectId);
                    Assert.IsNotNull(_event.EventId);
                    Assert.IsTrue(_event.EventTimestamp is long);
                    Assert.IsNotNull(_event.UserId);
                    Assert.IsNotNull(_event.RequestUserId);
                    Assert.IsNotNull(_event.Source);
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidRequestException))]
        public void TestInvalidParams()
        {
            SmartsheetClient smartsheet = new SmartsheetBuilder().SetMaxRetryTimeout(30000).Build();
            EventResult eventResult = smartsheet.EventResources.ListEvents(0, "2.1.0An4ZapaQaOXPdojlmediSZ1WqMdi5U_3l9gViOW7ic", 10, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidRequestException))]
        public void TestInvalidParams_2()
        {
            SmartsheetClient smartsheet = new SmartsheetBuilder().SetMaxRetryTimeout(30000).Build();
            EventResult eventResult = smartsheet.EventResources.ListEvents(DateTime.Today, null, 10, true);
        }
    }
}  

