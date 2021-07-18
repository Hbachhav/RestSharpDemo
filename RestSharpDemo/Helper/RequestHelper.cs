using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestSharpDemo.Helper
{
    public class RequestHelper
    {
         RestRequest restRequest;
        
        public  RestRequest GeneratePostRequest(dynamic Payload)
        {
            restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Accept","application/json");
            restRequest.AddJsonBody(Payload);
            return restRequest;
        }

        public RestRequest GeneratePutRequest(dynamic Payload)
        {
            restRequest = new RestRequest(Method.PUT);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddJsonBody(Payload);
            return restRequest;
        }
        public RestRequest GenerateDeleteRequest()
        {
            restRequest = new RestRequest(Method.DELETE);
            restRequest.AddHeader("Accept", "application/json");
          
            return restRequest;
        }

        public RestRequest GenerateGetRequest()
        {
            restRequest = new RestRequest(Method.GET);
            restRequest.AddHeader("Accept", "application/json");

            return restRequest;
        }

    }
}
