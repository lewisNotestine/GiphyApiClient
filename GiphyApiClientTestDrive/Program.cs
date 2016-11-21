using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GiphyApiClient.NetCore.Client;
using GiphyApiClient.NetCore.Config;
using GiphyApiClient.NetCore.Models.Input;
using GiphyApiClient.NetCore.Models.Output;
using RestSharp;

namespace GiphyApiClientTestDrive
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            var input = string.Empty;
            while (input != "3") 
            {
                Console.WriteLine(
                    @"
Press 1 for testing with AsyncHandles. 
Press 2 for testing with tasks. 
Press 3 to quit.");
                
                var key = Console.ReadKey();
                input = key.KeyChar.ToString(); 
                switch (input)
                {                    
                    case "1":
                        TestWithHandles();                        
                        break;
                    case "2":
                        TestWithTasks();                        
                        break;
                    case "3":                                                
                    default: 
                        break;
                }
                Console.WriteLine("done testing. Press a key");
                Console.ReadKey();

            }
        }        

        private static void TestWithTasks()
        {
            var config = new GiphyApiClientConfig();
            var restClient = new RestClient(config.BaseUrl);
            var giphyClient = new GiphyClient(restClient, config);

            //tests.
            Console.WriteLine("Performing Search Task...");
            var searchTask = giphyClient.SearchAsyncTask(new SearchParams("Barf"));
            var trendingTask = giphyClient.TrendingAsyncTask(new TrendingParams(contentRating: "pg-13"));
            var translateTask = giphyClient.TranslateAsyncTask(new TranslateParams(search: "chewy", 
                contentRating: null,
                language: null,
                format: null));
            var randomTask = giphyClient.RandomAsyncTask(new RandomParams(limitingTag: null, contentRating: null, format: null));
            var idTask = giphyClient.GifByIdAsyncTask(new GifByIdParams(gifId: "3oriNV6Cxf43fczQje"));
            var idsTask = giphyClient.GifsByIdsAsyncTask(new GifsByIdParams(gifIds: new string[] {"3oriNV6Cxf43fczQje", "3oriNRqnlzW4LwLUqI"}));
            
            Task.WaitAll(searchTask, 
                trendingTask,
                translateTask, 
                randomTask,
                idTask, 
                idsTask);

            Console.WriteLine("\nGot all awaited results");
            
            Console.WriteLine("\nsearch task results");
            HandleMultipleCallback(searchTask.Result, null);

            Console.WriteLine("trending task results");
            HandleMultipleCallback(trendingTask.Result, null);

            Console.WriteLine("translate Task results");
            HandleSingleCallback(translateTask.Result, null);

            Console.WriteLine("random task results");
            HandleRandomCallback(randomTask.Result, null);

            Console.WriteLine("id task results");
            HandleSingleCallback(idTask.Result, null);

            Console.WriteLine("ids task results");
            HandleMultipleCallback(idsTask.Result, null);
        }

        private static void TestWithHandles()
        {
            var config = new GiphyApiClientConfig();
            var restClient = new RestClient(config.BaseUrl);
            var giphyClient = new GiphyClient(restClient, config);
            
            //Search test.
            Console.WriteLine("press a key to test Search");
            Console.ReadKey();
            Console.WriteLine("testing the giphy API Search method!");
            var searchHandle = giphyClient.SearchAsync(new SearchParams("Barf"),
             callback: (rr, ah) => HandleMultipleCallback(rr, ah));     
            Console.WriteLine($"sent request, have response yet? {searchHandle?.WebRequest.HaveResponse}. press a key to continue");
            Console.ReadKey();
            Console.WriteLine();
            
            //Trending test.
            Console.WriteLine("press a key to test Trending");
            Console.ReadKey();
            Console.WriteLine("testing the giphy API Trending method!");
            var trendingHandle = giphyClient.TrendingAsync(new TrendingParams(contentRating: "pg-13"), 
            callback: (rr, ah) => HandleMultipleCallback(rr, ah));
            Console.WriteLine($"sent request, have response yet? {trendingHandle?.WebRequest.HaveResponse}. press a key to continue");
            Console.ReadKey();
            Console.WriteLine();

            //Translate test.
            Console.WriteLine("press a key to test Translate");
            Console.ReadKey();
            Console.WriteLine("testing the giphy API Translate method!");
            var translateHandle = giphyClient.TranslateAsync(new TranslateParams(search: "chewy", 
                contentRating: null,
                language: null,
                format: null), 
            callback: (rr, ah) => HandleSingleCallback(rr, ah));
            Console.WriteLine($"sent request, have response yet? {translateHandle?.WebRequest.HaveResponse}. press a key to continue");
            Console.ReadKey();
            Console.WriteLine();

            //Random test.
            Console.WriteLine("press a key to test Random");
            Console.ReadKey();
            Console.WriteLine("testing the giphy API random method!");
            var randomHandle = giphyClient.RandomAsync(new RandomParams(limitingTag: null, contentRating: null, format: null), 
                callback: (rr, ah) => HandleRandomCallback(rr, ah));
            Console.WriteLine($"sent request, have response yet? {randomHandle?.WebRequest.HaveResponse}. press a key to continue");
            Console.ReadKey();
            Console.WriteLine();

            //get-by-id test.
            Console.WriteLine("press a key to test GifById");
            Console.ReadKey();
            Console.WriteLine("testing the giphy API GifbyId method!");
            var idHandle = giphyClient.GifByIdAsync(new GifByIdParams(gifId: "3oriNV6Cxf43fczQje"), 
                callback: (rr, ah) => HandleSingleCallback(rr, ah));
            Console.WriteLine($"sent request, have response yet? {idHandle?.WebRequest.HaveResponse}. press a key to continue");
            Console.ReadKey();
            Console.WriteLine();

            //Get-by-ids test.
            Console.WriteLine("press a key to test GifsById");
            Console.ReadKey();
            Console.WriteLine("testing the giphy API GifsbyId method!");
            var gifIdParms = new GifsByIdParams(gifIds: new string[] {"3oriNV6Cxf43fczQje", "3oriNRqnlzW4LwLUqI"});
            Console.WriteLine(gifIdParms.ids);
            var idsHandle = giphyClient.GifsByIdAsync(gifIdParms, 
                callback: (rr, ah) => HandleMultipleCallback(rr, ah));
            Console.WriteLine($"sent request, have response yet? {idsHandle?.WebRequest.HaveResponse}. press a key to continue");
            Console.ReadKey();
            Console.WriteLine();

        }

        private static void HandleMultipleCallback(IRestResponse<MultipleResult> response, RestRequestAsyncHandle requestHandle)                 
        {                

            Console.WriteLine($"got response {requestHandle?.ToString()}");
            var responsedata = response?.Data?.data;
            if (responsedata == null)
            {
                Console.WriteLine("problem with method");
            }
            else
            {
                foreach (var datum in responsedata)
                {
                    Console.WriteLine(datum.images.fixed_height_small.url);
                }
            }
        }

        private static void HandleSingleCallback(IRestResponse<SingleResult> response, RestRequestAsyncHandle requestHandle)
        {
            Console.WriteLine($"got response {requestHandle?.ToString()}");
            var responsedata = response?.Data?.data;
            if (responsedata == null)
            {
                Console.WriteLine("problem with method");
            }
            else
            {
                Console.WriteLine(responsedata.images.fixed_height_small.url);                
            }
        }

        private static void HandleRandomCallback(IRestResponse<RandomResult> response, RestRequestAsyncHandle requestHandle)
        {
            Console.WriteLine($"got response {requestHandle?.ToString()}");
            var responsedata = response?.Data?.data;
            if (responsedata == null)
            {
                Console.WriteLine("problem with method");
            }
            else
            {
                Console.WriteLine(responsedata.fixed_height_small_url);                
            }
        }

        ///<remarks>
        /// This is just a dummy implementation of the config. a better way to implement it would be to read via a JSON file and use .NET core's built-in config support. 
        ///</remarks>
        public class GiphyApiClientConfig : IGiphyApiClientConfig
        {
            //This is Giphy's published public API key. 
            public string ApiKey 
            { 
                get { return "dc6zaTOxFJmzC"; } 
            }

            public string BaseUrl
            {
                get { return "http://api.giphy.com/v1/gifs"; }
            }
        
        }
    }
}
