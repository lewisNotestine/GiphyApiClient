using System;

namespace GiphyApiClient.NetCore.Models.Input
{
    public class GifsByIdParams
    {
        public string ids;

        [Obsolete("for deserialization only")]
        public GifsByIdParams()
        {}

        public GifsByIdParams(params string[] gifIds)
        {
            ids = string.Join("%2C", gifIds);
        }
    }
}