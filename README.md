# Introduction
A basic example of using Azure Search based on Premier League team data. This example has been adopted from here: https://docs.microsoft.com/en-gb/azure/search/search-get-started-dotnet

# Getting Started
Create a new Azure Search service as per these instructions: https://docs.microsoft.com/en-gb/azure/search/search-create-service-portal

Under `src/dotnet` add a new file with the name `appsettings.dev.json`, this should have the same structure as `appsettings.json` i.e.

```
{
  "SearchServiceName": "yourServiceName",
  "SearchServiceAdminApiKey": "yourAdminApiKey",
  "SearchIndexName": "yourSearchIndexName"
}
```

# Build and Test
Under the directory `src/dotnet/PremierLeague` run the commands:  
`dotnet restore`  
`dotnet run`  
You should then see the output in the console for the queries found in `RunQueries()`

# Author TODO
Add more data and more queries
