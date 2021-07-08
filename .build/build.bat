@setlocal 
@set /P TEMPVER= Enter the version number to build for:

msbuild.exe .\smartsheet-csharp-sdk.msbuild /p:TheVersion=%TEMPVER%
