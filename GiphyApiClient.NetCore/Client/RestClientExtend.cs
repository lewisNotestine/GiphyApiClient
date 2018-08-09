using System;
using System.Threading;
using System.Threading.Tasks;
using RestSharp;

namespace GiphyApiClient.NetCore.Client
{

    ///<summary>
    ///This set of extension methods is meant to provide a stopgap, RestSharp has methods that do implement the async/await pattern, but the .net core lib i'm using does not. 
    ///therefore, I grabbed some of the async task methods defined here: https://github.com/restsharp/RestSharp/blob/e7c65df751427298cb59f5456bbf1f59967996be/RestSharp/RestClient.Async.cs
    ///</summary>
    ///<remarks>
    /// Am tracking development of ZhongZf's fork of RestSharp with .net core support.  
    /// When these methods are implemented there, this class can go away. 
    /// If i understand correctly, it should be just a change to a specific compiler directive noted in the class above.
    /// see https://github.com/zhongzf/RestSharp    
    ///</remarks>
    public static class RestClientExtend
    {
        public static Task<IRestResponse<T>> ExecuteTaskAsync<T>(this IRestClient client, IRestRequest request, CancellationToken token)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            TaskCompletionSource<IRestResponse<T>> taskCompletionSource = new TaskCompletionSource<IRestResponse<T>>();

            try
            {
                RestRequestAsyncHandle async = client.ExecuteAsync<T>(
                    request,
                    (response, _) =>
                    {
                        if (token.IsCancellationRequested)
                        {
                            taskCompletionSource.TrySetCanceled();
                        }
                        // Don't run TrySetException, since we should set Error properties and swallow exceptions
                        // to be consistent with sync methods
                        else
                        {
                            taskCompletionSource.TrySetResult(response);
                        }
                    });


                CancellationTokenRegistration registration =
                    token.Register(() =>
                                   {
                                       async.Abort();
                                       taskCompletionSource.TrySetCanceled();
                                   });


                taskCompletionSource.Task.ContinueWith(t => registration.Dispose(), token);
            }
            catch (Exception ex)
            {
                taskCompletionSource.TrySetException(ex);
            }

            return taskCompletionSource.Task;
        }
             
        public static Task<IRestResponse<T>> ExecuteGetTaskAsync<T>(this IRestClient client, IRestRequest request)
        {
            return client.ExecuteGetTaskAsync<T>(request, CancellationToken.None);
        }

        public static Task<IRestResponse<T>> ExecuteGetTaskAsync<T>(this IRestClient client, IRestRequest request, CancellationToken token)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            request.Method = Method.GET;
            return client.ExecuteTaskAsync<T>(request, token);
        }

        public static Task<IRestResponse<T>> ExecutePostTaskAsync<T>(this IRestClient client, IRestRequest request, CancellationToken token)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            request.Method = Method.POST;

            return client.ExecuteTaskAsync<T>(request, token);
        }

        public static Task<IRestResponse<T>> ExecutePostTaskAsync<T>(this IRestClient client, IRestRequest request)
        {
            return client.ExecutePostTaskAsync<T>(request, CancellationToken.None);
        }

        public static Task<IRestResponse<T>> ExecuteTaskAsync<T>(this IRestClient client, IRestRequest request)
        {
            return client.ExecuteTaskAsync<T>(request, CancellationToken.None);
        }

        public static Task<IRestResponse> ExecuteTaskAsync(this IRestClient client, IRestRequest request)
        {
            return client.ExecuteTaskAsync(request, CancellationToken.None);
        }

        public static Task<IRestResponse> ExecuteGetTaskAsync(this IRestClient client, IRestRequest request)
        {
            return client.ExecuteGetTaskAsync(request, CancellationToken.None);
        }

        public static Task<IRestResponse> ExecuteGetTaskAsync(this IRestClient client, IRestRequest request, CancellationToken token)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            request.Method = Method.GET;
            return client.ExecuteTaskAsync(request, token);
        }

        public static Task<IRestResponse> ExecutePostTaskAsync(this IRestClient client, IRestRequest request)
        {
            return client.ExecutePostTaskAsync(request, CancellationToken.None);
        }

        public static Task<IRestResponse> ExecutePostTaskAsync(this IRestClient client, IRestRequest request, CancellationToken token)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            request.Method = Method.POST;
            return client.ExecuteTaskAsync(request, token);
        }

        public static Task<IRestResponse> ExecuteTaskAsync(this IRestClient client, IRestRequest request, CancellationToken token)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            TaskCompletionSource<IRestResponse> taskCompletionSource = new TaskCompletionSource<IRestResponse>();

            try
            {
                RestRequestAsyncHandle async = client.ExecuteAsync(
                    request,
                    (response, _) =>
                    {
                        if (token.IsCancellationRequested)
                        {
                            taskCompletionSource.TrySetCanceled();
                        }
                        // Don't run TrySetException, since we should set Error
                        // properties and swallow exceptions to be consistent
                        // with sync methods
                        else
                        {
                            taskCompletionSource.TrySetResult(response);
                        }
                    });

                CancellationTokenRegistration registration =
                    token.Register(() =>
                                   {
                                       async.Abort();
                                       taskCompletionSource.TrySetCanceled();
                                   });


                taskCompletionSource.Task.ContinueWith(t => registration.Dispose(), token);
            }
            catch (Exception ex)
            {
                taskCompletionSource.TrySetException(ex);
            }

            return taskCompletionSource.Task;
        }
    }
    
}