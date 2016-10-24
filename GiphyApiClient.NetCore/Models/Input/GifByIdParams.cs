using System;

namespace GiphyApiClient.NetCore.Models.Input
{
    public class GifByIdParams
    {
        public string id;

        [Obsolete("for deserialization only")]
        public GifByIdParams()
        {}

        public GifByIdParams(string gifId)
        {
            id = gifId;
        }
    }
}