using System;

namespace GiphyApiClient.NetCore.Models.Input
{
    public class RandomParams
    {
        public string tag { get; private set; }
        public string rating { get; private set; }
        public string fmt { get; private set; }

        public RandomParams(string limitingTag = null, string contentRating = null, string format = null)
        {
            tag = limitingTag;
            rating = contentRating;
            fmt = format;
        }

        public RandomParams WithTag(string tag)
        {
            this.tag = tag;
            return this;
        }

        public RandomParams WithRating(string rating)
        {
            this.rating = rating;
            return this;
        }

        public RandomParams WithFormat(string format)
        {
            this.fmt = format;
            return this;
        }
    }
}