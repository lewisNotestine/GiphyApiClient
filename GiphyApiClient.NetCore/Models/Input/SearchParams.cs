namespace GiphyApiClient.NetCore.Models.Input
{
    public class SearchParams
    {
        public readonly string q;
        public readonly int? limit; 
        public readonly int? offset;
        public readonly string rating;
        public readonly string lang;
        public readonly string fmt;

        
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
    }
}

