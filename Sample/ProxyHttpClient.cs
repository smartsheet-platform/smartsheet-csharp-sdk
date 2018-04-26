using Smartsheet.Api.Internal.Http;
using System.Net;

namespace sdk_csharp_sample
{
    class ProxyHttpClient : DefaultHttpClient
    {
        public ProxyHttpClient(string host, int port)
            : base()
        {
            // create a WebProxy on the RestSharp client
            this.httpClient.Proxy = new WebProxy(host, port);
        }
    }
}
