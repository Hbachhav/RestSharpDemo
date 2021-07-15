using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serialization.Json;
using RestSharpDemo.DTO;

namespace RestSharpDemo
{
    [TestClass]
    public class TestRun
    {

        [TestInitialize]
        public void setupInit()
        {

          
        }

        [TestMethod]
        [DataRow("https://reqres.in/api/users/3")]


        public void GetUser(string url)
        {
           
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            GetUserDTO UserResponse =  new JsonDeserializer().Deserialize<GetUserDTO>(response);

            Assert.AreEqual(3, UserResponse.Data.Id);
           Assert.AreEqual("Emma", UserResponse.Data.FirstName);

        }

        [TestMethod]
        [DataRow("https://reqres.in/api/users", @"{
                                ""name"": ""Rahul"",
                                 ""job"": ""Member"" 
                               }")]

        public void createUser(string url, dynamic payload)
        {
               
       
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest(Method.POST);
            
            request.AddJsonBody(payload);
            IRestResponse response = client.Execute(request);
            CreateUserDTO UserResponse = new JsonDeserializer().Deserialize<CreateUserDTO>(response);

            Assert.AreEqual("Rahul", UserResponse.Name);

        }

        [TestMethod]
        [DataRow("https://reqres.in/api/users/2", @"{
                                ""name"": ""update Rahul"",
                                 ""job"": ""updated Member"" 
                               }")]

        public void updateUser(string url, dynamic payload)
        {


            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest(Method.PUT);

            request.AddJsonBody(payload);
            IRestResponse response = client.Execute(request);
            UpdateUserDTO UserResponse = new JsonDeserializer().Deserialize<UpdateUserDTO>(response);

            Assert.AreEqual("update Rahul", UserResponse.Name);

        }

        [TestMethod]
        [DataRow("https://reqres.in/api/users/2")]


        public void DeleteUser(string url)
        {

            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest(Method.DELETE);
            IRestResponse response = client.Execute(request);

            Assert.AreEqual(true,response.IsSuccessful );
           

        }

    }
}
