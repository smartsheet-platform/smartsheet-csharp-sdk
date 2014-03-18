@echo off
:: Build the source code for all of the projects (SDK, Documentation, Unit Tests)
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\msbuild smartsheet-csharp-sdk.sln /property:Configuration=release /t:rebuild
if not "%errorlevel%"=="0" goto buildFailure


:: Run unit tests
"%programfiles%\NUnit 2.6.3\bin\nunit-console.exe" TestSDK/bin/Release/TestSDK.dll /stoponerror 
if not "%errorlevel%"=="0" goto nunitFailure

:: package for nuget
nuget pack Smartsheet-csharp-sdk.csproj -sym -IncludeReferencedProjects -Prop Configuration=Release
if not "%errorlevel%"=="0" goto nugetFailure

:: Copy documentation to the git directory
xcopy documentation\Website\* documentation\git-docs /E /Y
cd documentation\git-docs\
:: Push the docs to github.io
git add *
git push
cd ..\..\

echo "==================================================="
echo "Now make it live on nuget with a command such as: "
echo "nuget push smartsheet-csharp-sdk.1.0.0.0.nupkg"
echo "==================================================="

:: zip dll's
:: push zip file somewhere so people can easily download? or does github give an easy to use link?

:: push docs to github.io

exit /b 0
:: Failure Cases
:buildFailure
echo "There was an issue building the solution"
exit /b 1
:nunitFailure
echo "There was an issue running the unit tests"
exit /b 1
:nugetFailure
echo "There was an issue packaging for nuget"
exit /b 1