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
        private const string SEARCH = "search";
        private const string TRENDING = "trending";
        private const string TRANSLATE = "translate";
        private const string RANDOM = "random";

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

        public static RequestBuilder GetSearchRequest(this RequestBuilder builder, SearchParams searchParams)
        {
            builder.ForResource(SEARCH)
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

        public static RequestBuilder GetTrendingRequest(this RequestBuilder builder, TrendingParams trendingParams)
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

        public static RequestBuilder GetTranslateRequest(this RequestBuilder builder, TranslateParams parms)
        {
            builder.ForResource(TRANSLATE)
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

        public static RequestBuilder GetRandomRequest(this RequestBuilder builder, RandomParams parms)
        {
            builder.ForResource(RANDOM)
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

        public static RequestBuilder GetSearchByIdRequest(this RequestBuilder builder, GifByIdParams parms)
        {
            builder.ForResource(parms.id)
                .WithMethod(Method.GET);
            return builder;
        }        


    }
}