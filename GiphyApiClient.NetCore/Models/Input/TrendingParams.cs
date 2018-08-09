namespace GiphyApiClient.NetCore.Models.Input
{
    public class TrendingParams
    {
        private const string DEFAULT_CONTENT_RATING = "pg-13";
        public readonly int? limit;
        public readonly string rating;
        public readonly string fmt;

        public TrendingParams(int? resultLimit = null, string contentRating = DEFAULT_CONTENT_RATING , string format = null)
        {
            limit = resultLimit;
            rating = contentRating;
            fmt = format;
        }
    }
}

