using System;

namespace GiphyApiClient.NetCore.Models.Input
{
    public class TranslateParams
    {
        public string s { get; private set; }

        public TranslateParams(string search)
        {
            s = search;
        }
    }
}