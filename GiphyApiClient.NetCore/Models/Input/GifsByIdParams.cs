using System;

namespace GiphyApiClient.NetCore.Models.Input
{
    public class GifsByIdParams
    {
        public string ids;

        public GifsByIdParams(params string[] gifIds)
        {
            ids = string.Join("%2C", gifIds);
        }
    }
}