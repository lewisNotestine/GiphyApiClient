using System;
using RestSharp;
using GiphyApiClient.NetCore.Models.Input;
using GiphyApiClient.NetCore.Models.Output;
using GiphyApiClient.NetCore.Config;
using System.Threading.Tasks;

namespace GiphyApiClient.NetCore.Client
{

    public class GiphyClient : IGiphyClient
    {
        private readonly IRestClient RestClnt;
        private readonly IGiphyApiClientConfig Config;

        public GiphyClient(IRestClient client, IGiphyApiClientConfig config)
        {
            RestClnt = client;
            Config = config;
        }

        public async Task<IRestResponse<MultipleResult>> SearchAsync(SearchParams parms)
        {
            var request = new RequestBuilder()
                .GetSearchRequest(parms)
                .WithApiKey(Config.ApiKey)
                .Build();

            return await RestClnt.ExecuteGetTaskAsync<MultipleResult>(request);
        }

        public async Task<IRestResponse<MultipleResult>> TrendingAsync(TrendingParams parms)
        {
            var request = new RequestBuilder()
                .GetTrendingRequest(parms)
                .WithApiKey(Config.ApiKey)
                .Build();

            return await RestClnt.ExecuteGetTaskAsync<MultipleResult>(request);
        }

        public async Task<IRestResponse<SingleResult>> TranslateAsync(TranslateParams parms)
        {
            var request = new RequestBuilder()
                .GetTranslateRequest(parms)
                .WithApiKey(Config.ApiKey)
                .Build();

            return await RestClnt.ExecuteGetTaskAsync<SingleResult>(request);
        }

        public async Task<IRestResponse<RandomResult>> RandomAsync(RandomParams parms)
        {
            var request = new RequestBuilder()
                .GetRandomRequest(parms)
                .WithApiKey(Config.ApiKey)
                .Build();

            return await RestClnt.ExecuteGetTaskAsync<RandomResult>(request);
        }

        public async Task<IRestResponse<SingleResult>> GifByIdAsync(GifByIdParams parms)
        {
            var request = new RequestBuilder()
                .GetSearchByIdRequest(parms)
                .WithApiKey(Config.ApiKey)
                .Build();

            return await RestClnt.ExecuteGetTaskAsync<SingleResult>(request);
        }

        public async Task<IRestResponse<MultipleResult>> GifsByIdsAsync(GifsByIdParams parms)
        {
            if (string.IsNullOrWhiteSpace(parms.ids))
            {
                throw new ArgumentException("ids parameter is not optional");
            }
            var url = new Uri(new Uri(Config.BaseUrl), "gifs");
            var builder = new UriBuilder(url);
            builder.Query = $"?api_key={Config.ApiKey}&ids={parms.ids}";
            var specialClient = new RestClient(builder.Uri);
            var request = new RestRequest();
            return await specialClient.ExecuteGetTaskAsync<MultipleResult>(request);
        }

        public async Task<IRestResponse<MultipleResult>> StickerSearchAsync(SearchParams searchParams)
        {
            var request = new RequestBuilder()
                .GetStickerSearchRequest(searchParams)
                .WithApiKey(Config.ApiKey)
                .Build();

            return await RestClnt.ExecuteGetTaskAsync<MultipleResult>(request);
        }

        public async Task<IRestResponse<MultipleResult>> StickerTrendingAsync(TrendingParams trendingParams)
        {
            var request = new RequestBuilder()
                .GetStickerTrendingRequest(trendingParams)
                .WithApiKey(Config.ApiKey)
                .Build();

            return await RestClnt.ExecuteGetTaskAsync<MultipleResult>(request);
        }

        public async Task<IRestResponse<SingleResult>> StickerTranslateAsync(TranslateParams translateParams)
        {
            var request = new RequestBuilder()
                .GetStickerTranslateRequest(translateParams)
                .WithApiKey(Config.ApiKey)
                .Build();

            return await RestClnt.ExecuteGetTaskAsync<SingleResult>(request);
        }

        public async Task<IRestResponse<RandomResult>> StickerRandomAsync(RandomParams randomParams)
        {
            var request = new RequestBuilder()
               .GetStickerRandomRequest(randomParams)
               .WithApiKey(Config.ApiKey)
               .Build();

            return await RestClnt.ExecuteGetTaskAsync<RandomResult>(request);
        }
    }
}