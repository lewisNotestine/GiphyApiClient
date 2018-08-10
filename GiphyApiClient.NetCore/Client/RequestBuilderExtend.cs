using GiphyApiClient.NetCore.Models.Input;
using RestSharp;

namespace GiphyApiClient.NetCore.Client
{
    ///<summary>
    /// Convenience methods to make the requestBuilder build specific requests for this client.
    ///</summary>
    internal static class RequestBuilderExtend
    {
        //Resource names
        private const string SEARCH = "gifs/search";
        private const string TRENDING = "gifs/trending";
        private const string TRANSLATE = "gifs/translate";
        private const string RANDOM = "gifs/random";

        private const string STICKERS_SEARCH = "stickers/search";
        private const string STICKERS_TRENDING = "stickers/trending";
        private const string STICKERS_TRANSLATE = "stickers/translate";
        private const string STICKERS_RANDOM = "stickers/random";

        //Param names
        private const string Q = "q";
        private const string LIMIT = "limit";
        private const string OFFSET = "offset";
        private const string RATING = "rating";
        private const string LANG = "lang";
        private const string FMT = "format";
        private const string API_KEY = "api_key";
        private const string S = "s";
        private const string TAG = "tag";


        public static RequestBuilder WithApiKey(this RequestBuilder builder, string apiKey)
        {
            return builder.AddParameter(API_KEY, apiKey, ParameterType.QueryString);
        }

        private static RequestBuilder GetSearchRequest(this RequestBuilder builder, string resource, SearchParams searchParams )
        {
            builder.ForResource(resource)
                .WithMethod(Method.GET)
                .AddParameter(Q, searchParams.q, ParameterType.QueryString);

            if (searchParams.limit.HasValue)
            {
                builder.AddParameter(LIMIT, searchParams.limit, ParameterType.QueryString);
            }

            if (searchParams.offset.HasValue)
            {
                builder.AddParameter(OFFSET, searchParams.offset, ParameterType.QueryString);
            }

            if (!string.IsNullOrEmpty(searchParams.rating))
            {
                builder.AddParameter(RATING, searchParams.rating, ParameterType.QueryString);
            }

            if (!string.IsNullOrEmpty(searchParams.lang))
            {
                builder.AddParameter(LANG, searchParams.lang, ParameterType.QueryString);
            }

            if (!string.IsNullOrEmpty(searchParams.fmt))
            {
                builder.AddParameter(FMT, searchParams.fmt, ParameterType.QueryString);
            }

            return builder;
        }

        public static RequestBuilder GetSearchRequest(this RequestBuilder builder, SearchParams searchParams)
        {
            return builder.GetSearchRequest(SEARCH, searchParams);
        }

        public static RequestBuilder GetStickerSearchRequest(this RequestBuilder builder, SearchParams searchParams)
        {
            return builder.GetSearchRequest(STICKERS_SEARCH, searchParams);
        }

        private static RequestBuilder GetTrendingRequest(this RequestBuilder builder, string resource, TrendingParams trendingParams)
        {
            builder.ForResource(TRENDING)
                .WithMethod(Method.GET);

            if (trendingParams.limit.HasValue)
            {
                builder.AddParameter(LIMIT, trendingParams.limit.Value, ParameterType.QueryString);
            }

            if (!string.IsNullOrEmpty(trendingParams.rating))
            {
                builder.AddParameter(RATING, trendingParams.rating, ParameterType.QueryString);
            }

            if (!string.IsNullOrEmpty(trendingParams.fmt))
            {
                builder.AddParameter(FMT, trendingParams.fmt, ParameterType.QueryString);
            }

            return builder;
        }

        public static RequestBuilder GetTrendingRequest(this RequestBuilder builder, TrendingParams trendingParams)
        {
            return builder.GetTrendingRequest(TRENDING, trendingParams);
        }

        public static RequestBuilder GetStickerTrendingRequest(this RequestBuilder builder, TrendingParams trendingParams)
        {
            return builder.GetTrendingRequest(STICKERS_TRENDING, trendingParams);
        }

        private static RequestBuilder GetTranslateRequest(this RequestBuilder builder, string resource, TranslateParams parms)
        {
            builder.ForResource(resource)
                .WithMethod(Method.GET)
                .AddParameter(S, parms.s, ParameterType.QueryString);

            if (!string.IsNullOrWhiteSpace(parms.rating))
            {
                builder.AddParameter(RATING, parms.rating, ParameterType.QueryString);
            }

            if (!string.IsNullOrWhiteSpace(parms.lang))
            {
                builder.AddParameter(LANG, parms.lang, ParameterType.QueryString);
            }

            if (!string.IsNullOrWhiteSpace(parms.fmt))
            {
                builder.AddParameter(FMT, parms.fmt, ParameterType.QueryString);
            }

            return builder;
        }

        public static RequestBuilder GetTranslateRequest(this RequestBuilder builder, TranslateParams translateParams)
        {
            return builder.GetTranslateRequest(TRANSLATE, translateParams);
        }

        public static RequestBuilder GetStickerTranslateRequest(this RequestBuilder builder, TranslateParams translateParams)
        {
            return builder.GetTranslateRequest(STICKERS_TRANSLATE, translateParams);
        }

        private static RequestBuilder GetRandomRequest(this RequestBuilder builder, string resource, RandomParams parms)
        {
            builder.ForResource(resource)
                .WithMethod(Method.GET);

            if (!string.IsNullOrWhiteSpace(parms.tag))
            {
                builder.AddParameter(TAG, parms.tag, ParameterType.QueryString);
            }

            if (!string.IsNullOrWhiteSpace(parms.rating))
            {
                builder.AddParameter(RATING, parms.rating, ParameterType.QueryString);
            }

            if (!string.IsNullOrWhiteSpace(parms.fmt))
            {
                builder.AddParameter(FMT, parms.fmt, ParameterType.QueryString);
            }

            return builder;
        }

        public static RequestBuilder GetRandomRequest(this RequestBuilder builder, RandomParams randomParams)
        {
            return builder.GetRandomRequest(RANDOM, randomParams);
        }

        public static RequestBuilder GetStickerRandomRequest(this RequestBuilder builder, RandomParams randomParams)
        {
            return builder.GetRandomRequest(STICKERS_RANDOM, randomParams);
        }

        public static RequestBuilder GetSearchByIdRequest(this RequestBuilder builder, GifByIdParams parms)
        {
            builder.ForResource($"gifs/{parms.id}")
                .WithMethod(Method.GET);
            return builder;
        }


    }
}