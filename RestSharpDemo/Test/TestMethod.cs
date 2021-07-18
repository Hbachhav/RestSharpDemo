using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serialization.Json;
using RestSharpDemo.BaseConfig;
using RestSharpDemo.DTO;
using RestSharpDemo.Helper;


namespace RestSharpDemo
{
    [TestClass]

    public class TestRun:Config

    {
          


        [TestMethod]
      [DataRow("users/2")]


        public void GetUser(string EndPoint)
        {

           // // var apiurl = string.Format(GetURL.GetUser,3);
           // // var endpoint = $"{baseUrl}/{apiurl}";

           // //RestClient client = new RestClient(endpoint);
           //    var client = SetupRestClient(EndPoint);
            
           //   RestRequest request = new RestRequest(Method.GET);


           // IRestResponse response = client.Execute(request);
           // GetUserDTO UserResponse =  new JsonDeserializer().Deserialize<GetUserDTO>(response);

           // Assert.AreEqual(2, UserResponse.Data.Id);
           //Assert.AreEqual("Janet", UserResponse.Data.FirstName);


            var client = SetupRestClient(EndPoint);
            var request = ObjRequestHelper.GenerateGetRequest();
            var responseHelper = new ResponseHelper<GetUserDTO>();
            var response = responseHelper.ExecuteRequest(client, request);

            GetUserDTO UserResponse = responseHelper.GetContent<GetUserDTO>(response);
            Assert.AreEqual(200, responseHelper.GetStatus(response));
            Assert.AreEqual("Janet", UserResponse.Data.First_Name);
            Assert.AreEqual(2, UserResponse.Data.Id);

        }

        [TestMethod]
        [DataRow("users", @"{
                                ""name"": ""Rahul"",
                                 ""job"": ""Member"" 
                               }")]

        public void CreateUser(string EndPoint, dynamic payload)
        {


            //   RestClient client = new RestClient(url);

            var client = SetupRestClient(EndPoint);
            var request = ObjRequestHelper.GeneratePostRequest(payload);
            //   RestRequest request = new RestRequest(Method.POST);

            // request.AddJsonBody(payload);
            //  IRestResponse response = client.Execute(request);
            // CreateUserDTO UserResponse = new JsonDeserializer().Deserialize<CreateUserDTO>(response);

            var responseHelper = new ResponseHelper<CreateUserDTO>();
            var response = responseHelper.ExecuteRequest(client,request);

            CreateUserDTO UserResponse = responseHelper.GetContent<CreateUserDTO>(response);

            Assert.AreEqual(201, responseHelper.GetStatus(response));

            Assert.AreEqual("Rahul", UserResponse.Name);

        }

        [TestMethod]
        [DataRow("users/2", @"{
                                ""name"": ""updated Rahul"",
                                 ""job"": ""updated Member"" 
                               }")]

        public void UpdateUser(string EndPoint, dynamic payload)
        {


            //RestClient client = new RestClient(url);
            //RestRequest request = new RestRequest(Method.PUT);

            //request.AddJsonBody(payload);
            //IRestResponse response = client.Execute(request);
         


            var client = SetupRestClient(EndPoint);
            var request = ObjRequestHelper.GeneratePutRequest(payload);
            var responseHelper = new ResponseHelper<CreateUserDTO>();
            var response = responseHelper.ExecuteRequest(client, request);
            UpdateUserDTO UserResponse = responseHelper.GetContent<UpdateUserDTO>(response);

            Assert.AreEqual("updated Rahul", UserResponse.Name);

        }

        [TestMethod]
        [DataRow("users/2")]


        public void DeleteUser(string EndPoint)
        {

            
            var client = SetupRestClient(EndPoint);
            var request = ObjRequestHelper.GenerateDeleteRequest();
            IRestResponse response = client.Execute(request);


            Assert.AreEqual(true,response.IsSuccessful );
           

        }

    }
}
