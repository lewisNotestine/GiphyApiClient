---------------------------------------------
------- GIPHY API CLIENT FOR .NET CORE ------
---------------------------------------------



# GiphyApiClient
A .NET Core class library for consuming Giphy's JSON API. 

#### Version History:
* 1.0.0 Created with basic Async methods.
* 1.1.0 Added async/await versions of main search methods, clean up a bit from 1.0.0
* 2.0.0 Migrated to new .NET Core 1.1.0 .csproj file format, created .sln file.
* 2.0.2 updated documentation & nuspec file contents. first version to be published to NuGet.org.

## Notes
This uses RestSharp.NetCore (https://www.nuget.org/packages/RestSharp.NetCore/) to get the job done.   

## Usage:
Meant to be consumed as a nuget package in your consuming application. 
This repo includes a little console app used as a testbed for the Giphy client 
https://github.com/lewisNotestine/GiphyApiClient
