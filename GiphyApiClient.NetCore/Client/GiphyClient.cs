using System;
using RestSharp;
using GiphyApiClient.NetCore.Models.Input;
using GiphyApiClient.NetCore.Models.Output;
using GiphyApiClient.NetCore.Config;
using System.Net;

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

            var restRequest = new RestRequest(resource: "search",
                method: Method.GET);
            restRequest.AddParameter(new Parameter()
            {
                Name = "q",
                Value = searchInput.q,
                Type = ParameterType.QueryString
            });


            if (searchInput.limit.HasValue)
            {
                restRequest.AddParameter(new Parameter()
                {
                    Name = "limit",
                    Value = searchInput.limit,
                    Type = ParameterType.QueryString
                });
            }

            if (searchInput.offset.HasValue)
            {
                restRequest.AddParameter(new Parameter()
                {
                    Name = "offset",
                    Value = searchInput.offset,
                    Type = ParameterType.QueryString
                });
            }

            if (!string.IsNullOrEmpty(searchInput.rating))
            {
                restRequest.AddParameter(new Parameter()
                {
                    Name = "rating",
                    Value = searchInput.rating,
                    Type = ParameterType.QueryString
                });
            }

            if (!string.IsNullOrEmpty(searchInput.lang))
            {
                restRequest.AddParameter(new Parameter()
                {
                    Name = "lang",
                    Value = searchInput.lang,
                    Type = ParameterType.QueryString
                });
            }


            if (!string.IsNullOrEmpty(searchInput.fmt))
            {
                restRequest.AddParameter(new Parameter()
                {
                    Name = "fmt",
                    Value = searchInput.fmt,
                    Type = ParameterType.QueryString
                });
            }

            restRequest.AddParameter(new Parameter()
            {
                Name = "api_key",
                Value = Config.ApiKey,
                Type = ParameterType.QueryString
            });
            
            return RestClnt.GetAsync<MultipleResult>(restRequest, callback);            
        }

        public RestRequestAsyncHandle TrendingAsync(TrendingParams input, Action<IRestResponse<MultipleResult>, RestRequestAsyncHandle> callback)
        {
        
            var restRequest = new RestRequest(resource: "trending",
                method: Method.GET);
            if (input.limit.HasValue)
            {
                restRequest.AddParameter(new Parameter() 
                {
                    Name = "limit",
                    Value = input.limit.Value,
                    Type = ParameterType.QueryString
                });
            }

            if (!string.IsNullOrEmpty(input.rating))
            {
                restRequest.AddParameter(new Parameter()
                {
                    Name = "rating",
                    Value = input.rating,
                    Type = ParameterType.QueryString
                });
            }

            if (!string.IsNullOrEmpty(input.fmt))
            {
                restRequest.AddParameter(new Parameter()
                {
                    Name = "fmt",
                    Value = input.fmt,
                    Type = ParameterType.QueryString
                });
            }

            restRequest.AddParameter(new Parameter()
            {
                Name = "api_key",
                Value = Config.ApiKey,
                Type = ParameterType.QueryString
            });

           return RestClnt.GetAsync<MultipleResult>(restRequest, callback);
        }

        public RestRequestAsyncHandle TranslateAsync(TranslateParams parms, Action<IRestResponse<SingleResult>, RestRequestAsyncHandle> callback)
        {
            var request = new RestRequest(resource: "translate", method: Method.GET);
            
            request.AddParameter(new Parameter()
            {
                Name = "s",
                Value = parms.s,
                Type = ParameterType.QueryString
            });

            if (!string.IsNullOrWhiteSpace(parms.rating))
            {
                request.AddParameter(new Parameter()
                {
                    Name = "rating",
                    Value = parms.rating,
                    Type = ParameterType.QueryString
                });
            }

            if (!string.IsNullOrWhiteSpace(parms.lang))
            {
                request.AddParameter(new Parameter()
                {
                    Name = "lang",
                    Value = parms.lang,
                    Type = ParameterType.QueryString
                });
            }

            if (!string.IsNullOrWhiteSpace(parms.fmt))
            {
                request.AddParameter(new Parameter()
                {
                    Name = "fmt",
                    Value = parms.fmt,
                    Type = ParameterType.QueryString
                });
            }

            request.AddParameter(new Parameter()
            {
                Name = "api_key",
                Value = Config.ApiKey, 
                Type = ParameterType.QueryString
            });
            
            return RestClnt.GetAsync<SingleResult>(request, callback);
        }

        public RestRequestAsyncHandle RandomAsync(RandomParams parms, Action<IRestResponse<RandomResult>, RestRequestAsyncHandle> callback)
        {
            var request = new RestRequest(resource: "random");
            if (!string.IsNullOrWhiteSpace(parms.tag))
            {
                request.AddParameter(new Parameter()
                {
                    Name = "tag",
                    Value = parms.tag,
                    Type = ParameterType.QueryString
                });
            }

            if (!string.IsNullOrWhiteSpace(parms.rating))
            {
                request.AddParameter(new Parameter()
                {
                    Name = "rating",
                    Value = parms.rating,
                    Type = ParameterType.QueryString
                });
            }

            if (!string.IsNullOrWhiteSpace(parms.fmt))
            {
                request.AddParameter(new Parameter()
                {
                    Name = "fmt",
                    Value = parms.fmt,
                    Type = ParameterType.QueryString
                });
            }

            request.AddParameter(new Parameter()
            {
                Name = "api_key",
                Value = Config.ApiKey,
                Type = ParameterType.QueryString
            });

           return RestClnt.GetAsync<RandomResult>(request, callback);
        } 

        public RestRequestAsyncHandle GifByIdAsync(GifByIdParams parms, Action<IRestResponse<SingleResult>, RestRequestAsyncHandle> callback)
        {
            if (string.IsNullOrWhiteSpace(parms.id))
            {
                throw new ArgumentException("id parameter is not optional");
            }

            var request = new RestRequest(resource: parms.id);
            request.AddParameter(new Parameter()
            {
                Name = "api_key", 
                Value = Config.ApiKey,
                Type = ParameterType.QueryString
            });

            return RestClnt.GetAsync(request, callback);
        }

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
    }
}