#Smartsheet C# SDK

This is a C# SDK to simplify connecting to the [Smartsheet API](http://www.smartsheet.com/developers/api-documentation) from applications.

##Installation
The SDK can be installed by using NuGet or by compiling from source. These two steps are outlined below.

###Install with NuGet
If unfamiliar with NuGet, please take a look at the [NuGet documentation](http://docs.nuget.org/). 

To install the SDK in Visual Studio, right click the **References** for the project and select **Manage NuGet Packages**.

![Manage NuGet Packages](https://googledrive.com/host/0B0ESt9lII6BWZUcyZmlsalBDdlE/nuget1.png "Manage NuGet Packages")

Next a dialog will open like the one below. Check the left sidebar to confirm that you are viewing the **Online** section. Then type in **smartsheet** in the search box. Lastly, click **Install** on the Smartsheet C# SDK.

![Search for and Install Smartsheet C# SDK](https://googledrive.com/host/0B0ESt9lII6BWZUcyZmlsalBDdlE/nuget2.png "Install Smartsheet C# SDK")

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
The SDK API documentation can be viewed online at [http://smartsheet-platform.github.io/smartsheet-csharp-sdk](http://smartsheet-platform.github.io/smartsheet-csharp-sdk/).


##Example Usage

<!-- note: java has better syntax highlighting on github -->
```java
// Set the Access Token
Token token = new Token();
token.AccessToken = "INSERT_YOUR_TOKEN_HERE";

// Use the Smartsheet Builder to create a Smartsheet
SmartsheetClient smartsheet = new SmartsheetBuilder().SetAccessToken(
    token.AccessToken).Build();

// Get home
Home home = smartsheet.Home().GetHome(new ObjectInclusion[]{
    ObjectInclusion.TEMPLATES});

// List home folders
IList<Folder> homeFolders = home.Folders;
foreach(Folder tmpFolder in homeFolders) {
    Console.WriteLine("folder:"+tmpFolder.Name);
}

// List Sheets
IList<Sheet> homeSheets = smartsheet.Sheets().ListSheets();
foreach(Sheet tmpSheet in homeSheets) {
    Console.WriteLine("sheet:"+tmpSheet.Name);
}

// Create folder in home
Folder folder = new Folder();
folder.Name = "New Folder";
folder = smartsheet.Home().Folders().CreateFolder(folder);
Console.WriteLine("Folder ID:"+folder.ID+", Folder Name:"+folder.Name);


// Setup checkbox Column Object
Column checkboxColumn = new Column.AddColumnToSheetBuilder().SetType(
    ColumnType.CHECKBOX).
    SetTitle("Finished").Build();

// Setup text Column Object
Column textColumn = new Column.AddColumnToSheetBuilder().SetPrimary(true).
    SetTitle("To Do List").SetType(ColumnType.TEXT_NUMBER).Build();


// Add the 2 Columns (flag & text) to a new Sheet Object
Sheet sheet = new Sheet.CreateSheetBuilder().SetName("New Sheet").SetColumns(
    new Column[]{checkboxColumn, textColumn}).Build();
// Send the request to create the sheet @ Smartsheet
sheet = smartsheet.Sheets().CreateSheet(sheet);
```

More examples are available [here](https://github.com/smartsheet-platform/smartsheet-csharp-sdk/blob/master/Sample/Program.cs).

## Contributing
If you would like to contribute a change to the SDK, please fork a branch and then submit a pull request. More info [here](https://help.github.com/articles/using-pull-requests).

##Support
If you have any questions or issues with this SDK please post on [StackOverflow using the tag "smartsheet-api"](http://stackoverflow.com/questions/tagged/smartsheet-api) or contact us directly at api@smartsheet.com.

##Release Notes

Each specific release is available for download via [Github](https://github.com/smartsheet-platform/smartsheet-csharp-sdk/tags) or the [NuGet repository](https://www.nuget.org/packages/smartsheet-csharp-sdk/).

<!--
**1.0.
* Updated web documentation to use Visual Studio 2013 format and include searching.
* 
* Updated to the latest version of Newtonsoft.Json
* Added support for code on Azure.

-->
**1.0.7 (Dec 9, 2014)**
* Added ability to retrieve Reports

**1.0.6 (Oct 29, 2014)**
* Added Dropbox and Evernote as attachment types
* Added setColumnId to ModifyColumnBuilder

**1.0.5 (Oct 22, 2014)**
* Fixed an issue where WorkspaceResourcesImpl was not working correctly with folders and shares.

**1.0.4 (Jun 16, 2014)**
* Made enum serialization more flexible

**1.0.3 (Jun 16, 2014)**
* Upgraded json.net library to latest version
* Added support for GANTT_ALLOCATION ColumnTag

**1.0.2 (Apr 17, 2014)**
* Fixed issue with post requests where content body was not handled correctly.
* Added index to the ColumnToSheetBuilder class.
* Added filename when uploading an attachment.

**1.0.1 (Mar 19, 2014)**
* Fixed issue when refreshing an existing OAuth token.

**1.0.0 (Feb 18, 2014)**
* Initial Release of the Smartsheet C# SDK

[![githalytics.com alpha](https://cruel-carlota.pagodabox.com/9200efe449798ebbc03d9ec9f0a11ff1 "githalytics.com")](http://githalytics.com/smartsheet-platform/smartsheet-csharp-sdk)
