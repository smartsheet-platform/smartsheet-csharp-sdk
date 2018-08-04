# Advanced Topics for the Smartsheet SDK for C#

## Logging
The Smartsheet C# SDK references the [NLog project](http://nlog-project.org) for SDK logging. NLog is highly configurable for console
and file logging. The root folder contains an `NLog.config` file which specifies the logging configuration of the SDK. Targets for File and ColorConsole logging are used by the SDK.

Using NLog, the Smartsheet C# SDK logs all API queries including HTTP method, URI, HTTP status, and response time 
to `INFO`. API Request and Response details are logged to `DEBUG`. 

## Passthrough Option

If there is an API feature that is not yet supported by the C# SDK, there is a passthrough option that allows you to 
pass and receive raw JSON objects.

To invoke the passthrough, your code can call one of the following four methods:

`string jsonResponse = smartsheet.PassthroughResources().PostRequest(endpoint, payload, parameters);`

`string jsonResponse = smartsheet.PassthroughResources().GetRequest(endpoint, parameters);`

`string jsonResponse = smartsheet.PassthroughResources().PutRequest(endpoint, payload, parameters);`

`string jsonResponse = smartsheet.PassthroughResources().DeleteRequest(endpoint);`

* `endpoint (string)`: The specific API endpoint you wish to invoke. The client object base URL gets prepended to the caller’s 
endpoint URL argument, e.g., if endpoint is 'sheets' an HTTP GET is requested from the URL https://api.smartsheet.com/2.0/sheets
* `payload (string)`: The data to be passed through in the request payload as a string.
* `query_params (Dictionary<string,string>)`: An optional list of query parameters.

All calls to passthrough methods return a JSON string result.

### Passthrough Example

The following example shows how to POST data to https://api.smartsheet.com/2.0/sheets using the passthrough method and 
a JSON string payload:
```csharp
SmartsheetClient smartsheet = new SmartsheetBuilder().SetMaxRetryTimeout(30000).Build();

string payload =
  "{\"name\": \"my new sheet\"," +
    "\"columns\": [" +
      "{\"title\": \"Favorite\", \"type\": \"CHECKBOX\", \"symbol\": \"STAR\"}," +
      "{\"title\": \"Primary Column\", \"primary\": true, \"type\": \"TEXT_NUMBER\"}" +
    "]" +
  "}";

string jsonResponse = smartsheet.PassthroughResources.PostRequest("sheets", payload);

long id = 0;
JsonReader reader = new JsonTextReader(new StringReader(jsonResponse));
while(id == 0 && reader.Read()) {
  switch (reader.TokenType)
  {
    case JsonToken.StartObject:
      break;
    case JsonToken.PropertyName:
      if(reader.Value.ToString().Contains("message")) 
      {
        string message = reader.ReadAsString();
        Assert.AreEqual(message, "SUCCESS");
      }
      else if(reader.Value.ToString().Contains("id"))
      {
        reader.Read();
        id = (long)reader.Value;
      }
      else
      {
        reader.Read();
      }
      break;
    default:
      reader.Read();
      break;
  }
}
```
A more complete example can be found in the Integration test file, `PassthroughResourcesTest.cs`.

## Testing
Integration tests:
1. Your environment must contain a variable named SMARTSHEET_ACCESS_TOKEN containing an api access token in order to proceed with the tests.
2. Run the tests within the from within Visual Studio.

Mock API tests:
1. Clone the [Smartsheet sdk tests](https://github.com/smartsheet-platform/smartsheet-sdk-tests) repo and follow the instructions from the readme to start the mock server.
2. Run the tests within the `TestSDKMockAPI` project from within Visual Studio.

## Overriding HTTP Client Behavior
You can provide a number of customizations to the default HTTP behavior by extending the DefaultHttpClient class and 
overriding one or more methods (examples below). 

Common customizations may include:
- implementing an HTTP proxy
- injecting additional HTTP headers
- overriding default timeout or retry behavior
 
### Sample ProxyHttpClient
The following example shows how to enable a proxy by providing the SmartsheetBuilder with an HttpClient that extends 
DefaultHttpClient.  

Invoke the SmartsheetBuilder with a custom HttpClient:

```csharp
// Initialize client
SmartsheetClient ss = new SmartsheetBuilder()
    .SetHttpClient(new ProxyHttpClient("localhost", 8888))
    .Build();
``` 

```csharp
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
```
### Sample RetryHttpClient
The following example shows how to override the default retry/timeout logic.  

Invoke the SmartsheetBuilder with a custom HttpClient:
```csharp
// Initialize client
SmartsheetClient ss = new SmartsheetBuilder()
    .SetHttpClient(new RetryHttpClient())
    .Build();
```

```csharp
using System;
using System.IO;
using System.Threading;
using Smartsheet.Api;
using Smartsheet.Api.Models;
using Smartsheet.Api.Internal.Http;
using Newtonsoft.Json;

namespace sdk_csharp_sample
{
    class RetryHttpClient : DefaultHttpClient
    {
        /// <summary>
        /// Override this method to perform API requests for special cases
        /// </summary>
        /// <param name="previousAttempts"> number of previous attempts </param>
        /// <param name="totalElapsedTime"> the total elapsed time for the API request </param>
        /// <param name="response"> the last response from the API </param>
        /// <returns> true to retry, false to exit and return error to the caller </returns>
        public override bool ShouldRetry(int previousAttempts, long totalElapsedTime, HttpResponse response)
        {
            string contentType = response.Entity.ContentType;
            if (contentType != null && !contentType.StartsWith("application/json"))
            {
                // it's not JSON; don't try to parse it
                return false;
            }

            Error error;
            try
            {
                // Details about the Smartsheet API error condition
                error = jsonSerializer.deserialize<Error>(
                    response.Entity.GetContent());
            }
            catch (JsonSerializationException ex)
            {
                throw new SmartsheetException(ex);
            }
            catch (Newtonsoft.Json.JsonException ex)
            {
                throw new SmartsheetException(ex);
            }
            catch (IOException ex)
            {
                throw new SmartsheetException(ex);
            }

            switch (error.ErrorCode)
            {
                // The default shouldRetry, retries 4001, 4002, 4003, 4004 codes
                case 4001:
                case 4002:
                case 4003:
                case 4004:
                case 9999: // adding my fictional error code to the retry list
                    break;
                default:
                    return false;
            }

            // The default calcBackoff uses exponential backoff, add custom behavior by overriding calcBackoff
            long backoff = CalcBackoff(previousAttempts, totalElapsedTime, error);
            if (backoff < 0)
                return false;

            logger.Info(string.Format("HttpError StatusCode={0}: Retrying in {1} milliseconds", response.StatusCode, backoff));
            Thread.Sleep(TimeSpan.FromMilliseconds(backoff));
            return true;
        }
    }
}
```
