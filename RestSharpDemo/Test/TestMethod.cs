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


            
            var client = SetupRestClient(EndPoint);
            var request = ObjRequestHelper.GeneratePostRequest(payload);
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
