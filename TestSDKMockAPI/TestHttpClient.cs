using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSDKMockAPI
{
    using Smartsheet.Api.Internal.Http;
    using RestSharp;

    class TestHttpClient : DefaultHttpClient
    {
        private string apiScenario;

        public TestHttpClient(string apiScenario)
        {
            this.apiScenario = apiScenario;
        }

        public override RestRequest CreateRestRequest(HttpRequest smartsheetRequest)
        {
            RestRequest restRequest = base.CreateRestRequest(smartsheetRequest);
            restRequest.AddHeader("Api-Scenario", this.apiScenario);
            return restRequest;
        }
    }
}
