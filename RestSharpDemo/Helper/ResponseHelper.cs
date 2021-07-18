using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace RestSharpDemo.Helper
{
    public class ResponseHelper<T>
    {
        public IRestResponse ExecuteRequest(IRestClient restClient, RestRequest restRequest)
        {
            return restClient.Execute(restRequest);
        }

        public int GetStatus(IRestResponse restResponse)
        {
            HttpStatusCode httpStatusCode = restResponse.StatusCode;

            return (int)httpStatusCode;
        }

        public DC GetContent<DC>(IRestResponse restResponse)
        {
            return JsonConvert.DeserializeObject<DC>(restResponse.Content);
        }
    }
}
