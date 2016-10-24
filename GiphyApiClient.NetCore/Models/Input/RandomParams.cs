using System;

namespace GiphyApiClient.NetCore.Models.Input
{
    public class RandomParams 
    {
        public string tag;
        public string rating;
        public string fmt;

        [Obsolete("for deserialization")]
        public RandomParams()
        {}

        public RandomParams(string limitingTag, string contentRating, string format = null)
        {
            tag = limitingTag;
            rating = contentRating;
            fmt = format;
        }
    }
}