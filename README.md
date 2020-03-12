# Smartsheet SDK for C# [![Build Status](https://travis-ci.org/smartsheet-platform/smartsheet-csharp-sdk.svg?branch=master)](https://travis-ci.org/smartsheet-platform/smartsheet-csharp-sdk) [![Coverage Status](https://coveralls.io/repos/github/smartsheet-platform/smartsheet-csharp-sdk/badge.svg?branch=master)](https://coveralls.io/github/smartsheet-platform/smartsheet-csharp-sdk?branch=master) [![NuGet](https://img.shields.io/nuget/v/smartsheet-csharp-sdk.svg)](https://www.nuget.org/packages/smartsheet-csharp-sdk/)

This is a C# SDK to simplify connecting to the [Smartsheet API](https://smartsheet-platform.github.io/api-docs/) from .NET applications.

**NOTE ON 2.93.0 RELEASE**

While investigating issue [#113](https://github.com/smartsheet-platform/smartsheet-csharp-sdk/issues/113), the API/SDK team discovered that Newtonsoft Json.NET, by default, deserializes JSON strings that "look like" dates into C# DateTime objects. 
You can read the discussion [here](https://github.com/JamesNK/Newtonsoft.Json/issues/862). Smartsheet believes this to 
be undesirable behavior (since JSON doesn't have a date construct, all JSON strings should be handled as C# strings), 
therefore, this release changes the global behavior to disable this feature of Json.NET. If you have implementations that rely on the previous behavior, there is an opt-out feature that you can use. An example of the opt-out code is here:

```csharp
SmartsheetClient smartsheet = new SmartsheetBuilder()
    .SetAccessToken("feo3t736fc2lpansdevs4a1as")       // TODO: Set your API access in environment variable SMARTSHEET_ACCESS_TOKEN or else here
    .SetHttpClient(new RetryHttpClient())
    .SetDateTimeFixOptOut(true)
    .Build();
```
   
## System Requirements

The SDK supports C# version 4.0 or later and targets .NET Framework version 4.5.2 or later or .NET Standard 2.0 or later. 
In addition, we support any .NET language compatible with those platform versions.

## Installation
The SDK can be installed by using NuGet or by compiling from source. These two alternatives are outlined below.

### Install with NuGet
If unfamiliar with NuGet, please take a look at the [NuGet documentation](http://docs.nuget.org/). 

To install the SDK in Visual Studio, right click the **References** for the project and select **Manage NuGet Packages**.

Select the **Browse** or **Online** tab (depending upon the version of Visual Studio) then type **smartsheet** in the search box. Select **smartsheet-csharp-sdk** in the search results and click the **Install** button.

After clicking **Install**, you will be asked to accept the License (Apache). Then it will install the Smartsheet SDK and the dependencies (RestSharp, Newtonsoft.Json, and NLog) by adding these libraries to the **References** section of the project.

You can also use the following command in the **[Package Manager Console](http://docs.nuget.org/docs/start-here/using-the-package-manager-console)** to install the SDK:

```dos
Install-Package smartsheet-csharp-sdk
```

### Compile From Source
You can download and compile the source code for the SDK from Github. Use [git](http://git-scm.com/) to fetch it and 
use Visual Studio 2017 or later to build it.

```dos
git clone https://github.com/smartsheet-platform/smartsheet-csharp-sdk.git
```

In Visual Studio 2017 you can open the entire solution with the file **smartsheet-csharp-sdk-v2.sln**, or open the specific 
project **smartsheet-csharp-sdk-v2.csproj**.

## Example Usage
To call the API, you will need an *access token*, which looks something like this example: ll352u9jujauoqz4gstvsae05. You can find the access token in the UI at Account > Personal Settings > API Access.

The following is a brief sample that shows you how to:

* Initialize the client
* List all sheets
* Load one sheet

```csharp
using Smartsheet.Api;
using Smartsheet.Api.Models;

static void Sample()
{
    // Initialize client
    SmartsheetClient smartsheet = new SmartsheetBuilder()
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
A simple, but complete sample application project is here: https://github.com/smartsheet-samples/csharp-read-write-sheet

## Advanced Topics
For details about logging, testing, how to use a passthrough option, and how to override HTTP client behavior, see [Advanced Topics](ADVANCED.md).

## Documentation
The full Smartsheet API documentation is here: http://smartsheet-platform.github.io/api-docs/?csharp#.

The generated SDK class documentation is here: [http://smartsheet-platform.github.io/smartsheet-csharp-sdk/](http://smartsheet-platform.github.io/smartsheet-csharp-sdk/).

## Contributing
If you would like to contribute a change to the SDK, please fork a branch and then submit a pull request. [More info here.](https://help.github.com/articles/using-pull-requests)

## Version Numbers
Starting from the v2.68.0 release, Smartsheet SDKs will use a new versioning strategy. Since all users are on the 
Smartsheet API 2.0, the SDK version numbers will start with 2. The 2nd number will be an internal reference number.
The 3rd number is for incremental changes.

For example, v2.68.0 means that you are using our 2.0 version of the API, the API is synced internally to a tag of 68,
and then if there are numbers after the last decimal, that will indicate a minor change.

## Support
If you have any questions or issues with this SDK please post on [StackOverflow using the tag "smartsheet-api"](http://stackoverflow.com/questions/tagged/smartsheet-api) or contact us directly at api@smartsheet.com.

## Release Notes

All releases and release notes are available on [Github](https://github.com/smartsheet-platform/smartsheet-csharp-sdk/releases) or the [NuGet repository](https://www.nuget.org/packages/smartsheet-csharp-sdk/).

