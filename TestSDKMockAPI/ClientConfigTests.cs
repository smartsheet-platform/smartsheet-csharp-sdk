using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smartsheet.Api;
using Smartsheet.Api.Models;
using System.Collections.Generic;

namespace TestSDKMockAPI
{
    [TestClass]
    public class ClientConfigTests
    {
        [TestMethod]
        public void CanAssignChangeAgent()
        {
            SmartsheetClient ss = HelperFunctions
                .SetupClientBase("Change Agent Header - Can Be Passed")
                .SetChangeAgent("MyChangeAgent")
                .Build();

            var sheet = new Sheet
            {
                Name = "My new sheet",
                Columns = new List<Column>
                {
                    new Column
                    {
                        Title = "Col1",
                        Primary = true,
                        Type = ColumnType.TEXT_NUMBER
                    }
                }
            };

            ss.SheetResources.CreateSheet(sheet);
        }

        [TestMethod]
        public void CanAssumeUser()
        {
            SmartsheetClient ss = HelperFunctions
                .SetupClientBase("Assume User - Can Be Set")
                .SetAssumedUser("john.doe@smartsheet.com")
                .Build();

            var result = ss.SheetResources.GetSheet(123, null, null, null, null, null, null, null);
        }
    }
}
