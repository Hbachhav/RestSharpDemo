using RestSharp;
using RestSharpDemo.Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace RestSharpDemo.BaseConfig
{
   public abstract class Config
    {
        public RequestHelper ObjRequestHelper = new RequestHelper();
        public IRestClient SetupRestClient(string EndPoint)
        {
            
            RestClient client = new RestClient(ConfigurationManager.AppSettings["baseurl"] + EndPoint);
            return client;

        }
    }
}
