namespace GiphyApiClient.NetCore.Config
{
    ///<remarks>
    ///This interface is meant to be implemented by your consuming application.
    ///</remarks>
    public interface IGiphyApiClientConfig
    {       
        string ApiKey { get; }
        string BaseUrl { get; }
    }
}