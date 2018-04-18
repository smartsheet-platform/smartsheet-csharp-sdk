# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
and this project adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## [Unreleased]

## [2.2.2] - 2018-04-18
### Added
- [Automation rules](http://smartsheet-platform.github.io/api-docs/?shell#automation-rules)
- [Cross sheet references](http://smartsheet-platform.github.io/api-docs/?shell#cross-sheet-references)
- Added import API endpoints to allow SDK users to import Sheets from XLSX and CSV files
- Data validation (more information about cell value parsing including validation can be found [here](http://smartsheet-platform.github.io/api-docs/#cell-reference))
- Passthrough mechanism to pass raw JSON requests through to the API (documented in README/Advanced Topics)
- Sheet filter implementation
- Row sort feature
- User profile properties (including profileImage) to UserModel
- Scope, location, and favoriteFlag inclusion to search
- getSheet() ifVersionAfter parameter 
- Expose Change-Agent, Assumed-User, and User-Agent on Smartsheet client
- Bulk access to sheet version through sheetVersion inclusion
- Missing report and sheet publish flags
- Missing title widget for Sights
- Deserialization of error detail
- Cleaned up logging for binary HTTP entities
- Methods to clear hyperlink and cellLink (examples can be found in the `RowTests.cs` mock tests)

### Changed
- Implementation of objectValue to better support PredecessorList and objectValue primitives (examples of how to set and clear Predecessor list can be found in the `RowTests.cs` mock tests)
- HttpClient interface to allow SDK users to inject HTTP headers or implement an HTTP proxy by extending 
DefaultHttpClient (a proxy sample is provided in the Advanced Topics section of the README)
- Removed outdated Link model and replaced all references with current Hyperlink model
- Removed ShouldRetry and CalcBackoff interfaces and replaced with HttpClient interface methods. You can now customize 
shouldRetry or calcBackoff using the same method as proxy or request header injection (i.e., extend DefaultHttpClient).

### Fixed
- Several deserialization issues with Sights
- Changed Duration values to floats to be consistent with the API
- Don't modify comments array when setComment is called for outbound comment
- Don't attempt to rety non-JSON responses

## Earlier releases
- Documented in [Github releases page](https://github.com/smartsheet-platform/smartsheet-csharp-sdk/releases)
