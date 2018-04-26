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
    [TestClass]
    public class SightsTest
    {
        [TestMethod]
        public void ListSights()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("List Sights");
            PaginatedResult<Sight> sights = ss.SightResources.ListSights(null, null);
            Assert.AreEqual(6, (long)sights.TotalCount);
        }

        [TestMethod]
        public void GetSight()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Get Sight");
            Sight sight = ss.SightResources.GetSight(52);
            Assert.AreEqual(52, (long)sight.Id);
        }

        [Ignore]
        [TestMethod]
        public void CopySight()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Copy Sight");
            ContainerDestination dest = new ContainerDestination();
            dest.DestinationType = DestinationType.FOLDER;
            dest.DestinationId = 424;
            dest.NewName = "new sight";
            Sight sight = ss.SightResources.CopySight(52, dest);
        }

        [TestMethod]
        public void UpdateSight()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Update Sight");
            Sight sight = new Sight();
            sight.Id = 812;
            sight.Name = "new new sight";
            ss.SightResources.UpdateSight(sight);
        }

        [TestMethod]
        public void SetPublishStatus()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Set Sight Publish Status");
            SightPublish publish = new SightPublish();
            publish.ReadOnlyFullEnabled = true;
            publish.ReadOnlyFullAccessibleBy = "ALL";
            ss.SightResources.SetPublishStatus(812, publish);
        }

        [TestMethod]
        public void GetPublishStatus()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Get Sight Publish Status");
            SightPublish publish = ss.SightResources.GetPublishStatus(812);
            Assert.IsTrue(publish.ReadOnlyFullEnabled.Value);
        }

        [TestMethod]
        public void DeleteSight()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Delete Sight");
            ss.SightResources.DeleteSight(700);
        }
    }
}
