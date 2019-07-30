namespace PremierLeague
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Linq;
    using System.Threading;
    using Microsoft.Azure.Search;
    using Microsoft.Azure.Search.Models;
    using Microsoft.Extensions.Configuration;
    using PremierLeague.Models;
    using PremierLeague.Data;

    class Program
    {
        static void Main(string[] args)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.dev.json");
            IConfigurationRoot configuration = builder.Build();

            SearchServiceClient serviceClient = CreateSearchServiceClient(configuration);

            string indexName = configuration["SearchIndexName"];

            Console.WriteLine($"Deleting index {indexName}...\n");
            DeleteIndexIfExists(indexName, serviceClient);

            Console.WriteLine("{0}", "Creating index...\n");
            CreateIndex(indexName, serviceClient);

            ISearchIndexClient indexClient = serviceClient.Indexes.GetClient(indexName);
            Console.WriteLine("{0}", "Uploading documents...\n");
            UploadDocuments(indexClient);

            Console.WriteLine("{0}", "Searching index...\n");
            RunQueries(indexClient);

            Console.WriteLine("{0}", "Complete.  Press any key to end application...\n");
            Console.ReadKey();
        }

        public static SearchServiceClient CreateSearchServiceClient(IConfigurationRoot configuration)
        {
            string searchServiceName = configuration["SearchServiceName"];
            string adminApiKey = configuration["SearchServiceAdminApiKey"];

            SearchServiceClient serviceClient = new SearchServiceClient(searchServiceName, new SearchCredentials(adminApiKey));
            return serviceClient;
        }

        private static void DeleteIndexIfExists(string indexName, SearchServiceClient serviceClient)
        {
            if (serviceClient.Indexes.Exists(indexName))
            {
                serviceClient.Indexes.Delete(indexName);
            }
        }

        private static void CreateIndex(string indexName, SearchServiceClient serviceClient)
        {
            var definition = new Index()
            {
                Name = indexName,
                Fields = FieldBuilder.BuildForType<Team>()
            };

            serviceClient.Indexes.Create(definition);
        }

        private static void UploadDocuments(ISearchIndexClient indexClient)
        {
            var actions = new List<IndexAction<Team>>();

            foreach (var team in Teams.GetTeams())
            {
                Console.WriteLine($"Uploading team {team.TeamName}");
                actions.Add(IndexAction.Upload(team));
            }

            var batch = IndexBatch.New(actions);

            try
            {
                indexClient.Documents.Index(batch);
            }
            catch (IndexBatchException e)
            {
                Console.WriteLine(
                    "Failed to index some of the documents: {0}",
                    String.Join(", ", e.IndexingResults.Where(r => !r.Succeeded).Select(r => r.Key)));
            }

            Console.WriteLine("Waiting for indexing...\n");
            Thread.Sleep(2000);
        }

        private static void WriteDocuments(DocumentSearchResult<Team> searchResults)
        {
            foreach (SearchResult<Team> result in searchResults.Results)
            {
                Console.WriteLine(result.Document.TeamName);
            }

            Console.WriteLine();
        }
        private static void RunQueries(ISearchIndexClient indexClient)
        {
            SearchParameters parameters;
            DocumentSearchResult<Team> results;

            // Query 1
            Console.WriteLine("Query 1: Search for Teams with 'Stadium' in their Stadium's name");
            parameters =
                new SearchParameters()
                {
                    Select = new[] { "stadium", "teamName" }
                };
            results = indexClient.Documents.Search<Team>("stadium", parameters);
            WriteDocuments(results);
        }
    }
}
