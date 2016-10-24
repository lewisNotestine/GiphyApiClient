# GiphyApiClient
A .NET Core class library for consuming Giphy's JSON API. 

## Notes
This uses RestSharp.NetCore (https://www.nuget.org/packages/RestSharp.NetCore/) to get the job done.   

## Usage:
Meant to be consumed as a nuget package in your consuming application. 
This repo includes a little console app used as a testbed for the Giphy client 

## More notes:
As of this writing, there is a serialization dependencency for RestSharp asking for a version of System.Runtime.Serialization.Formatters, which is currently not published on NuGet.org as far as I can tell. So, you will see a compiler warning for a mismatched dependency.
