# Advanced Topics for the Smartsheet SDK for C#

## Testing
Integration tests:
1. Your environment must contain a variable named SMARTSHEET_ACCESS_TOKEN containing an api access token in order to proceed with the tests.
2. Run the tests within the from within Visual Studio.

Mock API tests:
1. Clone the [Smartsheet sdk tests](https://github.com/smartsheet-platform/smartsheet-sdk-tests) repo and follow the instructions from the readme to start the mock server.
2. Run the tests within the `TestSDKMockAPI` project from within Visual Studio.
