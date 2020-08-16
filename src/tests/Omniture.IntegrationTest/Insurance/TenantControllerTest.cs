//using System;
//using System.Net.Http;
//using System.Threading.Tasks;
//using Omniture.Core.Model.Insurance;
//using Omniture.Db.Abstractions.Enums;
//using SocietyCareAPI;
//using Xunit;

//namespace Omniture.IntegrationTest
//{
//    public class TenantControllerTest : IClassFixture<CustomWebApplicationFactory<Startup>>
//    {
//        private readonly HttpClient _client;

//        public TenantControllerTest(CustomWebApplicationFactory<Startup> factory)
//        {
//            _client = factory.CreateClient();
//        }

//        [Theory]
//        [InlineData("Tenant", 404)]
//        [InlineData("Tenant/1", 200)]
//        public async Task CanGetTenant(String url, int expectedResult)
//        {
//            var httpResponse = await _client.GetAsync($"/api/" + url);
//            Assert.Equal(expectedResult, Convert.ToInt32(httpResponse.StatusCode));
//        }

//        [Theory]
//        [InlineData("", "", 1, 1, 25, 400)]
//        [InlineData("john", "smith", 2, 2, 25, 201)]
//        public async Task CanCreateTenant(String surname, string forename, int titleid, int entryFrom,
//            int year, int expectedResult)
//        {
//            TenantViewModel Tenant = new TenantViewModel
//            {
//                EntryFrom =  (EntryTypes)entryFrom,
//                DateOfBirth = DateTime.Now.AddYears(-year),
//                Forename = forename,
//                Surname = surname,
//                TitleId = titleid
//            };
//            var httpResponse = await _client.PostAsJsonAsync($"/api/Tenant", Tenant);
//            Assert.Equal(expectedResult, Convert.ToInt32(httpResponse.StatusCode));
//        }

//        [Theory]
//        [InlineData(2,"", "", 1, 1, 25, 400)]
//        [InlineData(2,"john", "smith", 2, 2, 25, 201)]
//        [InlineData(8, "john 1", "smith 1", 1, 1, 25, 404)]
//        public async Task CanUpdateTenant(int TenantId, String surname, string forename, int titleid, int entryFrom,
//            int year, int expectedResult)
//        {
//            TenantViewModel Tenant = new TenantViewModel
//            {
//                EntryFrom = (EntryTypes)entryFrom,
//                DateOfBirth = DateTime.Now.AddYears(-year),
//                Forename = forename,
//                Surname = surname,
//                TitleId = titleid
//            };

//            var httpResponse = await _client.PutAsJsonAsync($"/api/Tenant/{TenantId}", Tenant);
//            Assert.Equal(expectedResult, Convert.ToInt32(httpResponse.StatusCode));
//        }

//        [Theory]
//        [InlineData(4, 204)]
//        public async Task CanDeleteTenant(int userid, int expectedResult)
//        {
//            var httpResponse = await _client.DeleteAsync($"/api/Tenant/{userid}");
//            Assert.Equal(expectedResult, Convert.ToInt32(httpResponse.StatusCode));
//            var httpResponseGet = await _client.GetAsync($"/api/Tenant/{userid}");
//            Assert.Equal(404, Convert.ToInt32(httpResponseGet.StatusCode));
//        }
//    }
//}
