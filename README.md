[![nuget][nuget-badge]][nuget-url]
[nuget-badge]: https://img.shields.io/nuget/v/smartsheet-csharp-sdk.svg
[nuget-url]: https://www.nuget.org/packages/smartsheet-csharp-sdk/


#Smartsheet C# SDK

This is a C# SDK to simplify connecting to the [Smartsheet API](http://www.smartsheet.com/developers/api-documentation) from applications.

##Installation
The SDK can be installed by using NuGet or by compiling from source. These two steps are outlined below.

###Install with NuGet
If unfamiliar with NuGet, please take a look at the [NuGet documentation](http://docs.nuget.org/). 

To install the SDK in Visual Studio, right click the **References** for the project and select **Manage NuGet Packages**.

Select the **Browse** or **Online** tab (depending upon the version of VS) then type **smartsheet** in the search box. Select **smartsheet-csharp-sdk** in the search results and click the **Install** button.

After clicking **Install**, you will be asked to accept the License (Apache). Then it will install the Smartsheet SDK and the dependencies (RestSharp & Newtonsoft.Json) by adding these libraries to the **References** section of the project.

The SDK can also be installed with the following command in the **[Package Manager Console](http://docs.nuget.org/docs/start-here/using-the-package-manager-console)**:

```dos
Install-Package smartsheet-csharp-sdk
```

###Compile from source
The source code for the SDK can be downloaded from Github and then compiled. This can be accomplished using [git](http://git-scm.com/) to fetch it and then using Visual Studio or a program such as [MSBuild](http://msdn.microsoft.com/en-us/library/wea2sca5(v=vs.90).aspx) to built it.

In Visual Studio you can open the entire solution with the file **Smartsheet-csharp-sdk.sln**, or open the specific project **Smartsheet-csharp-sdk.csproj**. Once the project is open in Visual Studio, you can hit **F6** to build the solution.

This can also be accomplished via the command line with the following three commands.
Note: The path to **msbuild** may very.

```dos
git clone https://github.com/smartsheet-platform/smartsheet-csharp-sdk.git
cd smartsheet-csharp-sdk
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\msbuild smartsheet-csharp-sdk.sln /property:Configuration=release /t:rebuild
```

## Documentation
The SDK API documentation can be viewed online at [http://smartsheet-platform.github.io/smartsheet-csharp-sdk/](http://smartsheet-platform.github.io/smartsheet-csharp-sdk/).

##Example Usage
To use the C# SDK, you'll need to include the appropriate **using** directives in your code. 
For example, the code examples in this section require the following **using** directives:

```csharp
using Smartsheet.Api;
using Smartsheet.Api.Models;
using Smartsheet.Api.OAuth;
```

<!-- note: java has better syntax highlighting on github -->
```csharp
public static void OAuthExample()
{
	// Setup the information that is necessary to request an authorization code
	OAuthFlow oauth = new OAuthFlowBuilder().SetClientId("cxggphqv52axrylaux")
		.SetClientSecret("1lllvnekmjafoad0si").SetRedirectURL("https://batie.com/").Build();

	// Create the URL that the user will go to grant authorization to the application
	string url = oauth.NewAuthorizationURL(new Smartsheet.Api.OAuth.AccessScope[] { 
		Smartsheet.Api.OAuth.AccessScope.CREATE_SHEETS, 
		Smartsheet.Api.OAuth.AccessScope.WRITE_SHEETS }, "key=YOUR_VALUE");

	// Take the user to the following URL
	Console.WriteLine(url);

	// After the user accepts or declines the authorization they are taken to the redirect URL. 
	// The URL of the page the user is taken to can be used to generate
	// an AuthorizationResult object.
	string authorizationResponseURL = 
		"https://batie.com/?code=dxe7eykuh912rhs&expires_in=239824&state=key%3DYOUR_VALUE";

	// On this page pass in the full URL of the page to create an authorizationResult object  
	AuthorizationResult authResult = oauth.ExtractAuthorizationResult(authorizationResponseURL);

	// Get the token from the authorization result
	Token token = oauth.ObtainNewToken(authResult);

	// Save the token or use it.
}

public static void SampleCode()
{
	// Set the Access Token
	Token token = new Token();
	token.AccessToken = "YOUR_TOKEN";

	// Use the Smartsheet Builder to create a Smartsheet
	SmartsheetClient smartsheet = new SmartsheetBuilder()
		.SetAccessToken(token.AccessToken).Build();

	// List all contents (specify 'include' parameter with value of "source").
	Home home = smartsheet.HomeResources.GetHome(new HomeInclusion[] { HomeInclusion.SOURCE });

	// List folders in "Sheets" folder (specify 'includeAll' parameter with value of "true").
	IList<Folder> homeFolders = home.Folders;
	foreach (Folder tmpFolder in homeFolders)
	{
		Console.WriteLine("folder:" + tmpFolder.Name);
	}

	// List sheets (omit 'include' parameter and pagination parameters).
	PaginatedResult<Sheet> homeSheetsResult = smartsheet.SheetResources.ListSheets(null, null);
	foreach (Sheet tmpSheet in homeSheetsResult.Data)
	{
		Console.WriteLine("sheet:" + tmpSheet.Name);
	}

	// Create folder in home
	Folder folder = new Folder.CreateFolderBuilder("New Folder").Build();
	folder = smartsheet.HomeResources.FolderResources.CreateFolder(folder);
	Console.WriteLine("Folder ID:" + folder.Id + ", Folder Name:" + folder.Name);

	// Setup checkbox Column Object
	Column checkboxColumn = new Column
		.CreateSheetColumnBuilder("Finished", true, ColumnType.CHECKBOX).Build();
	// Setup text Column Object
	Column textColumn = new Column
		.CreateSheetColumnBuilder("To Do List", false, ColumnType.TEXT_NUMBER).Build();

	// Add the 2 Columns (flag & text) to a new Sheet Object
	Sheet sheet = new Sheet
		.CreateSheetBuilder("New Sheet", new Column[] { checkboxColumn, textColumn }).Build();
	// Send the request to create the sheet @ Smartsheet
	sheet = smartsheet.SheetResources.CreateSheet(sheet);
}
```

More examples are available [here](http://smartsheet-platform.github.io/api-docs/?csharp#c#-sample-code).

## Contributing
If you would like to contribute a change to the SDK, please fork a branch and then submit a pull request. More info [here](https://help.github.com/articles/using-pull-requests).

## Support
If you have any questions or issues with this SDK please post on [StackOverflow using the tag "smartsheet-api"](http://stackoverflow.com/questions/tagged/smartsheet-api) or contact us directly at api@smartsheet.com.

## Releases

All releases are available for download via [Github](https://github.com/smartsheet-platform/smartsheet-csharp-sdk/tags) or the [NuGet repository](https://www.nuget.org/packages/smartsheet-csharp-sdk/).

[Release notes](https://github.com/smartsheet-platform/smartsheet-csharp-sdk/releases)
