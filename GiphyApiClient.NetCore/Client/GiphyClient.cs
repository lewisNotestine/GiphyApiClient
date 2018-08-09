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

        public RestRequestAsyncHandle SearchAsync(SearchParams searchInput, Action<IRestResponse<MultipleResult>, RestRequestAsyncHandle> callback)
        {
            var restRequest = new RequestBuilder()
                .GetSearchRequest(searchInput)
                .WithApiKey(Config.ApiKey)
                .Build();
       
            return RestClnt.GetAsync<MultipleResult>(restRequest, callback);            
        }

        public RestRequestAsyncHandle TrendingAsync(TrendingParams input, Action<IRestResponse<MultipleResult>, RestRequestAsyncHandle> callback)
        {
            var restRequest = new RequestBuilder()
                .GetTrendingRequest(input)
                .WithApiKey(Config.ApiKey)
                .Build();           

           return RestClnt.GetAsync<MultipleResult>(restRequest, callback);
        }

        public RestRequestAsyncHandle TranslateAsync(TranslateParams parms, Action<IRestResponse<SingleResult>, RestRequestAsyncHandle> callback)
        {
            var request = new RequestBuilder()
                .GetTranslateRequest(parms)
                .WithApiKey(Config.ApiKey)
                .Build();

            return RestClnt.GetAsync<SingleResult>(request, callback);
        }

        public RestRequestAsyncHandle RandomAsync(RandomParams parms, Action<IRestResponse<RandomResult>, RestRequestAsyncHandle> callback)
        {
            var request = new RequestBuilder()
                .GetRandomRequest(parms)
                .WithApiKey(Config.ApiKey)
                .Build();

            return RestClnt.GetAsync<RandomResult>(request, callback);
        } 

        public RestRequestAsyncHandle GifByIdAsync(GifByIdParams parms, Action<IRestResponse<SingleResult>, RestRequestAsyncHandle> callback)
        {
            if (string.IsNullOrWhiteSpace(parms.id))
            {
                throw new ArgumentException("id parameter is not optional");
            }

            var request = new RequestBuilder()
                .GetSearchByIdRequest(parms)
                .WithApiKey(Config.ApiKey)
                .Build();

            return RestClnt.GetAsync(request, callback);
        }

        ///<remarks>
        ///There are some problems with this implementation, specifically that it has to new up a special client to get this done.
        /// The reason is that the <code>ids</code> parameter is a csv format, which RestSharp doesn't seem to like.
        ///</remarks>
        public RestRequestAsyncHandle GifsByIdAsync(GifsByIdParams parms, Action<IRestResponse<MultipleResult>, RestRequestAsyncHandle> callback)
        {
            if (string.IsNullOrWhiteSpace(parms.ids))
            {
                throw new ArgumentException("ids parameter is not optional");
            }
            var specialClient = new RestClient($"{Config.BaseUrl}?api_key={Config.ApiKey}&ids={parms.ids}");
            var request = new RestRequest();
            return specialClient.GetAsync<MultipleResult>(request, callback);
        }

        public Task<IRestResponse<MultipleResult>> SearchAsyncTask(SearchParams parms)
        {
            var request = new RequestBuilder()
                .GetSearchRequest(parms)
                .WithApiKey(Config.ApiKey)
                .Build();
            
            return RestClnt.ExecuteGetTaskAsync<MultipleResult>(request);
        }

        public Task<IRestResponse<MultipleResult>> TrendingAsyncTask(TrendingParams parms)
        {
            var request = new RequestBuilder()
                .GetTrendingRequest(parms)
                .WithApiKey(Config.ApiKey)
                .Build();
            
            return RestClnt.ExecuteGetTaskAsync<MultipleResult>(request);
        }

        public Task<IRestResponse<SingleResult>> TranslateAsyncTask(TranslateParams parms)
        {
            var request = new RequestBuilder()
                .GetTranslateRequest(parms)
                .WithApiKey(Config.ApiKey)
                .Build();
            
            return RestClnt.ExecuteGetTaskAsync<SingleResult>(request);
        }

        public Task<IRestResponse<RandomResult>> RandomAsyncTask(RandomParams parms)
        {
            var request = new RequestBuilder()
                .GetRandomRequest(parms)
                .WithApiKey(Config.ApiKey)
                .Build();

            return RestClnt.ExecuteGetTaskAsync<RandomResult>(request);
        }

        public Task<IRestResponse<SingleResult>> GifByIdAsyncTask(GifByIdParams parms)
        {
            var request = new RequestBuilder()
                .GetSearchByIdRequest(parms)
                .WithApiKey(Config.ApiKey)
                .Build();
            
            return RestClnt.ExecuteGetTaskAsync<SingleResult>(request);
        }

        public Task<IRestResponse<MultipleResult>> GifsByIdsAsyncTask(GifsByIdParams parms)
        {
            if (string.IsNullOrWhiteSpace(parms.ids))
            {
                throw new ArgumentException("ids parameter is not optional");
            }
            var specialClient = new RestClient($"{Config.BaseUrl}?api_key={Config.ApiKey}&ids={parms.ids}");
            var request = new RestRequest();
            return specialClient.ExecuteGetTaskAsync<MultipleResult>(request);
        }
    }
}