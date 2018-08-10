namespace GiphyApiClient.NetCore.Models.Input
{
    public class TrendingParams
    {
        public int? limit { get; private set; }
        public int? offset { get; private set; }
        public string rating { get; private set; }
        public string fmt { get; private set; }

        public TrendingParams(int? resultLimit = null, int? offset = null,  string contentRating = null , string format = null)
        {
            limit = resultLimit;
            this.offset = offset;
            rating = contentRating;
            fmt = format;
        }

        public TrendingParams WithLimit(int limit)
        {
            this.limit = limit;
            return this;
        }

        public TrendingParams WithOffset(int offset)
        {
            this.offset = offset;
            return this;
        }

        public TrendingParams WithRating(string contentRating)
        {
            this.rating = contentRating;
            return this;
        }

        public TrendingParams WithFormat(string format)
        {
            this.fmt = format;
            return this;
        }
    }
}

