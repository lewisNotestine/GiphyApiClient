---------------------------------------------
------- GIPHY API CLIENT FOR .NET CORE ------
---------------------------------------------



# GiphyApiClient
A .NET Core class library for consuming Giphy's JSON API. 

#### Version History:
* 1.0.0 Created with basic Async methods.
* 1.1.0 Added async/await versions of main search methods, clean up a bit from 1.0.0
* 2.0.0 Migrated to new .NET Core .csproj file format, created .sln file.

## Notes
This uses RestSharp.NetCore (https://www.nuget.org/packages/RestSharp.NetCore/) to get the job done.   

## Usage:
Meant to be consumed as a nuget package in your consuming application. 
This repo includes a little console app used as a testbed for the Giphy client 

## More notes:
As of this writing, there is a serialization dependencency for RestSharp asking for a version of System.Runtime.Serialization.Formatters, which is currently not published on NuGet.org as far as I can tell. So, you will see a compiler warning for a mismatched dependency.