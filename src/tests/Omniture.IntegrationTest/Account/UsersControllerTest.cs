//using System;
//using System.Net;
//using System.Net.Http;
//using System.Threading.Tasks;
//using Omniture.Core.Model.Account;
//using SocietyCareAPI;
//using Xunit;

//namespace Omniture.IntegrationTest.Account
//{
//    public class UsersControllerTest : IClassFixture<CustomWebApplicationFactory<Startup>>
//    {
//        private readonly HttpClient _client;

//        public UsersControllerTest(CustomWebApplicationFactory<Startup> factory)
//        {
//            _client = factory.CreateClient();
//        }

//        [Theory]
//        [InlineData("Users")]
//        [InlineData("Users/1")]
//        public async Task CanGetUsers(string url)
//        {
//            var httpResponse = await _client.GetAsync($"/api/" + url);
//            httpResponse.EnsureSuccessStatusCode();
//            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
//        }

//        [Theory]
//        [InlineData("username1", "", 400)]
//        [InlineData("username1", "password", 201)]
//        public async Task CanCreateUsers(string userName, string password, int expectedResult)
//        {
//            UsersViewModel user = new UsersViewModel
//            {
//                UserName = userName,
//                Password = password
//            };
//            var httpResponse = await _client.PostAsJsonAsync($"/api/Users", user);
//            Assert.Equal(expectedResult, Convert.ToInt32(httpResponse.StatusCode));
//        }

//        [Theory]
//        [InlineData(2, "update1", "password", 201)]
//        [InlineData(2, "user5", "user5", 422)]
//        [InlineData(8, "user5", "user5", 404)]
//        public async Task CanUpdateUsers(int userid, string userName, string password, int expectedResult)
//        {
//            UsersViewModel user = new UsersViewModel
//            {
//                UserId = userid,
//                UserName = userName,
//                Password = password
//            };

//            var httpResponse = await _client.PutAsJsonAsync($"/api/users/{userid}", user);
//            Assert.Equal(expectedResult, Convert.ToInt32(httpResponse.StatusCode));
//        }

//        [Theory]
//        [InlineData(4, 204)]
//        public async Task CanDeleteUsers(int userid, int expectedResult)
//        {
//            var httpResponse = await _client.DeleteAsync($"/api/users/{userid}");
//            Assert.Equal(expectedResult, Convert.ToInt32(httpResponse.StatusCode));
//            var httpResponseGet = await _client.GetAsync($"/api/users/{userid}");
//            Assert.Equal(404, Convert.ToInt32(httpResponseGet.StatusCode));
//        }
//    }
//}
