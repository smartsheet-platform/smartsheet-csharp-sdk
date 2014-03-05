@echo off

:: Run unit tests

:: Build the source code
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\msbuild smartsheet-csharp-sdk.sln /property:Configuration=release

:: Build documentation (sandcastle)
cd documentation
C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe /p:Configuration=Release smartsheet-csharp-sdk-docs.shfbproj
cd ..

:: zip dll's

:: package for nuget
