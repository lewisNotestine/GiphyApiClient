namespace GiphyApiClient.NetCore.Models.Output
{
    //
    // ALL CLASSES in this file were generated from JSON examples at http://jsonutils.com.
    //

    public class FixedHeight
    {
        public string url { get; set; }
        public string width { get; set; }
        public string height { get; set; }
        public string size { get; set; }
        public string mp4 { get; set; }
        public string mp4_size { get; set; }
        public string webp { get; set; }
        public string webp_size { get; set; }
    }

    public class FixedHeightStill
    {
        public string url { get; set; }
        public string width { get; set; }
        public string height { get; set; }
    }

    public class FixedHeightDownsampled
    {
        public string url { get; set; }
        public string width { get; set; }
        public string height { get; set; }
        public string size { get; set; }
        public string webp { get; set; }
        public string webp_size { get; set; }
    }

    public class FixedWidth
    {
        public string url { get; set; }
        public string width { get; set; }
        public string height { get; set; }
        public string size { get; set; }
        public string mp4 { get; set; }
        public string mp4_size { get; set; }
        public string webp { get; set; }
        public string webp_size { get; set; }
    }

    public class FixedWidthStill
    {
        public string url { get; set; }
        public string width { get; set; }
        public string height { get; set; }
    }

    public class FixedWidthDownsampled
    {
        public string url { get; set; }
        public string width { get; set; }
        public string height { get; set; }
        public string size { get; set; }
        public string webp { get; set; }
        public string webp_size { get; set; }
    }

    public class FixedHeightSmall
    {
        public string url { get; set; }
        public string width { get; set; }
        public string height { get; set; }
        public string size { get; set; }
        public string webp { get; set; }
        public string webp_size { get; set; }
    }

    public class FixedHeightSmallStill
    {
        public string url { get; set; }
        public string width { get; set; }
        public string height { get; set; }
    }

    public class FixedWidthSmall
    {
        public string url { get; set; }
        public string width { get; set; }
        public string height { get; set; }
        public string size { get; set; }
        public string webp { get; set; }
        public string webp_size { get; set; }
    }

    public class FixedWidthSmallStill
    {
        public string url { get; set; }
        public string width { get; set; }
        public string height { get; set; }
    }

    public class Downsized
    {
        public string url { get; set; }
        public string width { get; set; }
        public string height { get; set; }
        public string size { get; set; }
    }

    public class DownsizedStill
    {
        public string url { get; set; }
        public string width { get; set; }
        public string height { get; set; }
    }

    public class DownsizedLarge
    {
        public string url { get; set; }
        public string width { get; set; }
        public string height { get; set; }
        public string size { get; set; }
    }

    public class Original
    {
        public string url { get; set; }
        public string width { get; set; }
        public string height { get; set; }
        public string size { get; set; }
        public string frames { get; set; }
        public string mp4 { get; set; }
        public string mp4_size { get; set; }
        public string webp { get; set; }
        public string webp_size { get; set; }
    }

    public class OriginalStill
    {
        public string url { get; set; }
        public string width { get; set; }
        public string height { get; set; }
    }

    public class Images
    {
        public FixedHeight fixed_height { get; set; }
        public FixedHeightStill fixed_height_still { get; set; }
        public FixedHeightDownsampled fixed_height_downsampled { get; set; }
        public FixedWidth fixed_width { get; set; }
        public FixedWidthStill fixed_width_still { get; set; }
        public FixedWidthDownsampled fixed_width_downsampled { get; set; }
        public FixedHeightSmall fixed_height_small { get; set; }
        public FixedHeightSmallStill fixed_height_small_still { get; set; }
        public FixedWidthSmall fixed_width_small { get; set; }
        public FixedWidthSmallStill fixed_width_small_still { get; set; }
        public Downsized downsized { get; set; }
        public DownsizedStill downsized_still { get; set; }
        public DownsizedLarge downsized_large { get; set; }
        public Original original { get; set; }
        public OriginalStill original_still { get; set; }
    }

    public class Datum
    {
        public string type { get; set; }
        public string id { get; set; }
        public string slug { get; set; }
        public string url { get; set; }
        public string bitly_gif_url { get; set; }
        public string bitly_url { get; set; }
        public string embed_url { get; set; }
        public string username { get; set; }
        public string source { get; set; }
        public string rating { get; set; }
        public string caption { get; set; }
        public string content_url { get; set; }
        public string source_tld { get; set; }
        public string source_post_url { get; set; }
        public string import_datetime { get; set; }
        public string trending_datetime { get; set; }
        public Images images { get; set; }
    }

    public class Meta
    {
        public int status { get; set; }
        public string msg { get; set; }
    }

    public class Pagination
    {
        public int total_count { get; set; }
        public int count { get; set; }
        public int offset { get; set; }
    }
}