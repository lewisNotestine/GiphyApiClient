using System;

namespace GiphyApiClient.NetCore.Models.Input
{
    public class TranslateParams
    {
        public string s {get;set;}
        public string rating { get; set;}
        public string lang { get; set; }
        public string fmt { get; set;}


        [ObsoleteAttribute("deserialization only")]
        public TranslateParams()
        {}

        public TranslateParams(string search, string contentRating = null, string language = null, string format = null)
        {
            s = search;
            rating = contentRating;
            lang = language;
            fmt = format;
        }


    }
}