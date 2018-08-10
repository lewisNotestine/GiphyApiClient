using System;
using System.Threading.Tasks;
using GiphyApiClient.NetCore.Models.Input;
using GiphyApiClient.NetCore.Models.Output;
using RestSharp;

namespace GiphyApiClient.NetCore.Client
{
    ///<remarks>
    ///Implements the set of API operations noted in Giphy's public-facing client; documented at https://developers.giphy.com/docs/
    ///</remarks>
    public interface IGiphyClient
    {
        Task<IRestResponse<MultipleResult>> SearchAsync(SearchParams searchParams);
        Task<IRestResponse<MultipleResult>> TrendingAsync(TrendingParams trendingParams);
        Task<IRestResponse<SingleResult>> TranslateAsync(TranslateParams translateParams);
        Task<IRestResponse<RandomResult>> RandomAsync(RandomParams randomParams);
        Task<IRestResponse<SingleResult>> GifByIdAsync(GifByIdParams idParams);
        Task<IRestResponse<MultipleResult>> GifsByIdsAsync(GifsByIdParams idsParams);

        Task<IRestResponse<MultipleResult>> StickerSearchAsync(SearchParams searchParams);
        Task<IRestResponse<MultipleResult>> StickerTrendingAsync(TrendingParams trendingParams);
        Task<IRestResponse<SingleResult>> StickerTranslateAsync(TranslateParams translateParams);
        Task<IRestResponse<RandomResult>> StickerRandomAsync(RandomParams randomParams);
    }
}