namespace GiphyApiClient.NetCore.Models.Input
{
    public class SearchParams
    {
        public string q { get; private set; }
        public int? limit { get; private set; }
        public int? offset { get; private set; }
        public string rating { get; private set; }
        public string lang { get; private set; }
        public string fmt { get; private set; }

        public SearchParams(string query,
            int? limitResults = null,
            int? resultOffset = null,
            string contentRating = null,
            string language = null,
            string format = null)
        {
            q = query;
            limit = limitResults;
            offset = resultOffset;
            rating = contentRating;
            lang = language;
            fmt = format;
        }

        public SearchParams WithLimit(int limit)
        {
            this.limit = limit;
            return this;
        }

        public SearchParams WithOffset(int offset)
        {
            this.offset = offset;
            return this;
        }

        public SearchParams WithRating(string rating)
        {
            this.rating = rating;
            return this;
        }

        public SearchParams WithLanguage(string language)
        {
            this.lang = language;
            return this;
        }

        public SearchParams WithFormat(string format)
        {
            this.fmt = format;
            return this;
        }


    }
}

