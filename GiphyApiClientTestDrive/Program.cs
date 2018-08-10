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
            do
            {
                Console.WriteLine(
                    @"
Press 1 for testing.
Press anything else to quit.");

                var key = Console.ReadKey();
                input = key.KeyChar.ToString();
                switch (input)
                {
                    case "1":
                        TestWithTasks().Wait();
                        break;
                    default:
                        break;
                }
                Console.WriteLine("done testing. Press a key");
                Console.ReadKey();

            }
            while (input == "1");
        }

        private async static Task TestWithTasks()
        {
            var config = new GiphyApiClientConfig();
            var restClient = new RestClient(config.BaseUrl);
            var giphyClient = new GiphyClient(restClient, config);

            //tests.
            Console.WriteLine("\nPerforming gifs Tasks...");


            var searchTask = await giphyClient.SearchAsync(new SearchParams("Barf"));
            Console.WriteLine("\nsearch task results");
            HandleMultipleCallback(searchTask);


            var trendingResult = await giphyClient.TrendingAsync(new TrendingParams(contentRating: "pg-13"));
            Console.WriteLine("trending task results");
            HandleMultipleCallback(trendingResult);


            var translateResult = await giphyClient.TranslateAsync(new TranslateParams(search: "chewy",
                contentRating: null,
                language: null,
                format: null));
            Console.WriteLine("translate Task results");
            HandleSingleCallback(translateResult);


            var randomResult = await giphyClient.RandomAsync(new RandomParams(limitingTag: null, contentRating: null, format: null));
            Console.WriteLine("random task results");
            HandleRandomCallback(randomResult);


            var idResult = await giphyClient.GifByIdAsync(new GifByIdParams(gifId: "3oriNV6Cxf43fczQje"));
            Console.WriteLine("id task results");
            HandleSingleCallback(idResult);


            var idsResult = await giphyClient.GifsByIdsAsync(new GifsByIdParams(gifIds: new string[] { "3oriNV6Cxf43fczQje", "3oriNRqnlzW4LwLUqI" }));
            Console.WriteLine("ids task results");
            HandleMultipleCallback(idsResult);


            Console.WriteLine("\nPerforming Stickers Tasks...");
            var searchStickersResult = await giphyClient.StickerSearchAsync(new SearchParams("Barf"));
            Console.WriteLine("search stickers results");
            HandleMultipleCallback(searchStickersResult);


            var trendingStickersResult = await giphyClient.StickerTrendingAsync(new TrendingParams(5, "pg-13", "json"));
            Console.WriteLine("trending stickers results");
            HandleMultipleCallback(trendingStickersResult);


            var translateStickersResult = await giphyClient.StickerTranslateAsync(new TranslateParams("larb", "pg-13", null, "json"));
            Console.WriteLine("translate stickers results");
            HandleSingleCallback(translateStickersResult);


            var randomStickersResult = await giphyClient.StickerRandomAsync(new RandomParams(null, null));
            Console.WriteLine("random stickers results");
            HandleRandomCallback(randomStickersResult);
        }

        private static void HandleMultipleCallback(IRestResponse<MultipleResult> response)
        {

            Console.WriteLine($"got response");
            var responsedata = response?.Data?.data;
            if (responsedata == null)
            {
                Console.WriteLine("problem with method");
                Console.WriteLine(response.ErrorMessage);
            }
            else
            {
                foreach (var datum in responsedata)
                {
                    Console.WriteLine(datum.images.fixed_height_small.url);
                }
            }

            Console.WriteLine("------------------------------");
        }

        private static void HandleSingleCallback(IRestResponse<SingleResult> response)
        {
            Console.WriteLine($"got response");
            var responsedata = response?.Data?.data;
            if (responsedata == null)
            {
                Console.WriteLine("problem with method");
                Console.WriteLine(response.ErrorMessage);
            }
            else
            {
                Console.WriteLine(responsedata.images.fixed_height_small.url);
            }
            Console.WriteLine("------------------------------");
        }

        private static void HandleRandomCallback(IRestResponse<RandomResult> response)
        {
            Console.WriteLine($"got response");
            var responsedata = response?.Data?.data;
            if (responsedata == null)
            {
                Console.WriteLine("problem with method");
                Console.WriteLine(response.ErrorMessage);
            }
            else
            {
                Console.WriteLine(responsedata.fixed_height_small_url);
            }
            Console.WriteLine("------------------------------");
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
                get { return "http://api.giphy.com/v1/"; }
            }

        }
    }
}
