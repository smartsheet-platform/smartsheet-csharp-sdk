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
    public class ColumnTests
    {
        [TestMethod]
        public void UpdateColumn_ChangeType_Picklist()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Update Column - Change Type - Picklist");

            Column column = new Column
            {
                Id = 234,
                Index = 2,
                Title = "Updated Column",
                Type = ColumnType.PICKLIST,
                Options = new List<string>
                {
                    "An",
                    "updated",
                    "column"
                },
                Width = 200
            };

            Column updatedColumn = ss.SheetResources.ColumnResources.UpdateColumn(123, column);

            Assert.AreEqual(ColumnType.PICKLIST, updatedColumn.Type);
            Assert.AreEqual(3, updatedColumn.Options.Count);
        }

        [TestMethod]
        public void UpdateColumn_ChangeType_ContactList()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Update Column - Change Type - Contact List");

            Column column = new Column
            {
                Id = 234,
                Index = 2,
                Title = "Updated Column",
                Type = ColumnType.CONTACT_LIST,
                ContactOptions = new List<Contact>
                {
                    new Contact
                    {
                        Name = "Some Contact",
                        Email = "some.contact@smartsheet.com"
                    },
                    new Contact
                    {
                        Name = "Some Other Contact",
                        Email = "some.other.contact@smartsheet.com"
                    }
                },
                Width = 200
            };

            Column updatedColumn = ss.SheetResources.ColumnResources.UpdateColumn(123, column);

            Assert.AreEqual(ColumnType.CONTACT_LIST, updatedColumn.Type);
            Assert.AreEqual(2, updatedColumn.ContactOptions.Count);
        }
    }
}
