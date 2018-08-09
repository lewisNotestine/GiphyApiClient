using System;
using System.Collections.Generic;
using RestSharp;

namespace GiphyApiClient.NetCore.Client
{
    internal class RequestBuilder
    {
        private string Resource;
        private Method RequestMethod;
        private readonly List<Parameter> ParameterList;

        public RequestBuilder()
        {
            ParameterList = new List<Parameter>();
        }

        public RequestBuilder ForResource(string resource)
        {
            Resource = resource;
            return this;
        }

        public RequestBuilder WithMethod(Method method)
        {
            RequestMethod = method;
            return this;
        }

        public RequestBuilder AddParameter(string name, object val, ParameterType type)
        {
            ParameterList.Add(new Parameter() 
            {
                Name = name,
                Value = val,
                Type = type
            });

            return this;
        }

        public IRestRequest Build()
        {            
            if (Resource == null)
            {
                throw new InvalidOperationException("you must assign a resource. If calling the root of your API, just pass String.Empty to the ForResource() method.");
            }

            //This is assigning itself the same value. The only reason I'm doing this is to future-proof this in case the enum changes, which I doubt will happen but whatever...
            if (RequestMethod == default(Method))
            {
                RequestMethod = Method.GET;
            }

            var request = new RestRequest(Resource, RequestMethod);
            request.Parameters.AddRange(ParameterList);

            return request;
        }
    }
}