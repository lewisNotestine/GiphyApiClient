using System;

namespace GiphyApiClient.NetCore.Models.Input
{
    public class GifByIdParams
    {
        public string id;

        public GifByIdParams(string gifId)
        {
            id = gifId;
        }
    }
}