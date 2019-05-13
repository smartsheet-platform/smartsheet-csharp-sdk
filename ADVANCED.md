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

string jsonResponse = smartsheet.PassthroughResources.PostRequest("sheets", payload, null);

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
SmartsheetClient smartsheet = new SmartsheetBuilder()
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
SmartsheetClient smartsheet = new SmartsheetBuilder()
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

## Event Reporting
The following sample demonstrates best practices for consuming the event stream from the Smartsheet Event Reporting
feature.

The sample uses the `smartsheet.EventResources.ListEvents` method to request a list of events from the stream. The
first request sets the `since` parameter with the point in time (i.e. event occurrence datetime) in the stream from 
which to start consuming events. The `since` parameter can be set with a datetime value that is either formatted as 
ISO 8601 (e.g. 2010-01-01T00:00:00Z) or as UNIX epoch (in which case the `numericDates` parameter must also be set to 
`true`. By default the `numericDates` parameter is set to `false`).

To consume the next list of events after the initial list of events is returned, set the `streamPosition` parameter 
with the `NextStreamPosition` property obtained from the previous request and don't set the `since` parameter with 
any values. This is because when using the `ListEvents` method, either the `since` parameter or the `streamPosition`
parameter should be set, but never both.

Note that the `MoreAvailable` property in a response indicates whether more events are immediately available for
consumption. If events are not immediately available, they may still be generating so subsequent requests should keep
using the same `NextStreamPosition` value until the next list of events is retrieved.

Many events have additional information available as part of the event. That information can be accessed using the 
Dictionary stored in the `AdditionalDetails` property. Information about the additional details provided can be found
[here.](https://smartsheet-platform.github.io/event-reporting-docs/)

```csharp
class Program
{
    // this example is looking specifically for new sheet events
    private static void PrintNewSheetEventsInList(IList<Event> events)
    {
        //  enumerate all events in the list of returned events
        foreach (Event _event in events)
        {
            // find all created sheets
            if (_event.ObjectType == EventObjectType.SHEET && _event.Action == EventAction.CREATE)
            {
                // additional details are available for some events, they can be accessed as a Dictionary
                // in the AdditionalDetails property
                if (_event.AdditionalDetails.ContainsKey("sheetName"))
                {
                    Console.WriteLine(_event.AdditionalDetails["sheetName"]);
                }
            }
        }
    }

    static void Main(string[] args)
    {
        // Initialize client
        SmartsheetClient smartsheet = new SmartsheetBuilder()
            // .SetAccessToken("feo3t736fc2lpansdevs4a1as")       // TODO: Set your API access in environment variable SMARTSHEET_ACCESS_TOKEN or else here
            .SetHttpClient(new RetryHttpClient())
            .Build();

        // begin listing events in the stream starting with the `since` parameter
        DateTime lastWeek = DateTime.Today.AddDays(-7);
        // this example looks at the previous 7 days of events by providing a since argument set to last week's date 
        EventResult eventResult = smartsheet.EventResources.ListEvents(lastWeek, null, 1000, false);
        PrintNewSheetEventsInList(eventResult.Data);

        // continue listing events in the stream by using the `StreamPosition`, if the previous response indicates 
        // that more data is available.
        while(eventResult.MoreAvailable == true)
        {
            eventResult = smartsheet.EventResources.ListEvents(null, eventResult.NextStreamPosition, 10000, true);
            PrintNewSheetEventsInList(eventResult.Data);
        }
    }    
}
```

## Working With Smartsheetgov.com Accounts

If you need to access Smartsheetgov you will need to specify the Smartsheetgov API URI as the base URI during creation of the Smartsheet client object. SmartsheetGov uses a base URI of https://api.smartsheetgov.com/2.0/. The base URI is defined as a constant in the SmartsheetBuilder class (i.e. `SmartsheetBuilder.GOV_BASE_URI`).

Invoke the SmartsheetBuilder with the base URI pointing to Smartsheetgov:

```csharp
using Smartsheet.Api;
using Smartsheet.Api.Models;

static void Sample()
{
    // Initialize client
    SmartsheetClient smartsheet = new SmartsheetBuilder()
        .SetBaseURI(SmartsheetBuilder.GOV_BASE_URI)
        // TODO: Set your API access in environment variable SMARTSHEET_ACCESS_TOKEN or else here
        // .SetAccessToken("ll352u9jujauoqz4gstvsae05")
        .Build();

    // List all sheets
    PaginatedResult<Sheet> sheets = smartsheet.SheetResources.ListSheets(
        null,               // IEnumerable<SheetInclusion> includes
        null,               // PaginationParameters
        null                // Nullable<DateTime> modifiedSince = null
    );
    Console.WriteLine("Found " + sheets.TotalCount + " sheets");

    long sheetId = (long) sheets.Data[0].Id;                // Default to first sheet

    // sheetId = 567034672138842;                         // TODO: Uncomment if you wish to read a specific sheet

    Console.WriteLine("Loading sheet id: " + sheetId);

    // Load the entire sheet
    var sheet = smartsheet.SheetResources.GetSheet(
        5670346721388420,           // long sheetId
        null,                       // IEnumerable<SheetLevelInclusion> includes
        null,                       // IEnumerable<SheetLevelExclusion> excludes
        null,                       // IEnumerable<long> rowIds
        null,                       // IEnumerable<int> rowNumbers
        null,                       // IEnumerable<long> columnIds
        null,                       // Nullable<long> pageSize
        null                        // Nullable<long> page
    );
    Console.WriteLine("Loaded " + sheet.Rows.Count + " rows from sheet: " + sheet.Name);
}
```
