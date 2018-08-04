# Smartsheet SDK for C# [![NuGet](https://img.shields.io/nuget/v/smartsheet-csharp-sdk.svg)](https://www.nuget.org/packages/smartsheet-csharp-sdk/)

This is a C# SDK to simplify connecting to the [Smartsheet API](http://www.smartsheet.com/developers/api-documentation) from .NET applications.

## System Requirements

The SDK supports C# version 4.0 or later running on .NET platform version 4.5.2 or later. In addition, we support any .NET language compatible with that platform version.

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
You can download and compile the source code for the SDK from Github. Use [git](http://git-scm.com/) to fetch it and use Visual Studio or a program such as [MSBuild](http://msdn.microsoft.com/en-us/library/wea2sca5(v=vs.90).aspx) to build it.

In Visual Studio you can open the entire solution with the file **Smartsheet-csharp-sdk.sln**, or open the specific project **Smartsheet-csharp-sdk.csproj**.

You can also do this via the command line with the following three commands.
Note: The path to **msbuild** may vary.

```dos
git clone https://github.com/smartsheet-platform/smartsheet-csharp-sdk.git
cd smartsheet-csharp-sdk
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\msbuild smartsheet-csharp-sdk.sln /property:Configuration=release /t:rebuild
```

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
    SmartsheetClient ss = new SmartsheetBuilder()
        // TODO: Set your API access in environment variable SMARTSHEET_ACCESS_TOKEN or else here
        // .SetAccessToken("ll352u9jujauoqz4gstvsae05")
        .Build();

    // List all sheets
    PaginatedResult<Sheet> sheets = ss.SheetResources.ListSheets();
    Console.WriteLine("Found " + sheets.TotalCount + " sheets");

    long sheetId = (long) sheets.Data[0].Id;                // Default to first sheet

    // sheetId = 567034672138842;                         // TODO: Uncomment if you wish to read a specific sheet

    Console.WriteLine("Loading sheet id: " + sheetId);

    // Load the entire sheet
    var sheet = ss.SheetResources.GetSheet(
        5670346721388420            // long sheetId
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

## Support
If you have any questions or issues with this SDK please post on [StackOverflow using the tag "smartsheet-api"](http://stackoverflow.com/questions/tagged/smartsheet-api) or contact us directly at api@smartsheet.com.

## Release Notes

All releases and release notes are available on [Github](https://github.com/smartsheet-platform/smartsheet-csharp-sdk/releases) or the [NuGet repository](https://www.nuget.org/packages/smartsheet-csharp-sdk/).

