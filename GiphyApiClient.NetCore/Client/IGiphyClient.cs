using System;
using System.Threading.Tasks;
using GiphyApiClient.NetCore.Models.Input;
using GiphyApiClient.NetCore.Models.Output;
using RestSharp;

namespace GiphyApiClient.NetCore.Client
{
    ///<remarks>
    ///Implements the set of API operations noted in Giphy's public-facing client; documented at https://github.com/Giphy/GiphyApi
    ///Does NOT implement the "sticker" api yet.
    ///NOTE: all of the operations here are asynchronous, but they come in two flavors - One returns RestSharp's RestRequestAsyncHandle, and the second set returns a Task that can be <code>await</code>ed.   
    ///</remarks>
    public interface IGiphyClient
    {
        RestRequestAsyncHandle SearchAsync(SearchParams searchInput, Action<IRestResponse<MultipleResult>, RestRequestAsyncHandle> callback);
        RestRequestAsyncHandle TrendingAsync(TrendingParams input, Action<IRestResponse<MultipleResult>, RestRequestAsyncHandle> callback);
        RestRequestAsyncHandle TranslateAsync(TranslateParams input, Action<IRestResponse<SingleResult>, RestRequestAsyncHandle> callback);
        RestRequestAsyncHandle RandomAsync(RandomParams input, Action<IRestResponse<RandomResult>, RestRequestAsyncHandle> callback);
        RestRequestAsyncHandle GifByIdAsync(GifByIdParams parms, Action<IRestResponse<SingleResult>, RestRequestAsyncHandle> callback);
        RestRequestAsyncHandle GifsByIdAsync(GifsByIdParams parms, Action<IRestResponse<MultipleResult>, RestRequestAsyncHandle> callback);
        Task<IRestResponse<MultipleResult>> SearchAsyncTask(SearchParams searchParams);
        Task<IRestResponse<MultipleResult>> TrendingAsyncTask(TrendingParams trendingParams);
        Task<IRestResponse<SingleResult>> TranslateAsyncTask(TranslateParams translateParams);
        Task<IRestResponse<RandomResult>> RandomAsyncTask(RandomParams randomParams);
        Task<IRestResponse<SingleResult>> GifByIdAsyncTask(GifByIdParams idParams);
        Task<IRestResponse<MultipleResult>> GifsByIdsAsyncTask(GifsByIdParams idsParams);

    }
}