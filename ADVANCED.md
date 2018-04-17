# Advanced Topics for the Smartsheet SDK for C#

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
```
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
