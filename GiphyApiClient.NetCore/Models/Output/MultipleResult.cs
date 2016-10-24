using System.Collections.Generic;

/// <summary>
/// Generated from JSON Example at http://jsonutils.com/
/// </summary>
namespace GiphyApiClient.NetCore.Models.Output
{


    public class MultipleResult
    {
        public List<Datum> data { get; set; }
        public Meta meta { get; set; }
        public Pagination pagination { get; set; }
    }
}