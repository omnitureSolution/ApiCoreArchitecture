//using System;
//using System.Net.Http;
//using System.Threading.Tasks;
////using Omniture.Core.Model.Insurance;
//using SocietyCareAPI;
//using Xunit;

//namespace Omniture.IntegrationTest
//{
//    public class PolicyControllerTest : IClassFixture<CustomWebApplicationFactory<Startup>>
//    {
//        private readonly HttpClient _client;

//        public PolicyControllerTest(CustomWebApplicationFactory<Startup> factory)
//        {
//            _client = factory.CreateClient();
//        }


//        [Fact]
//        public async Task CanCreatePolicy()
//        {
//            PolicyViewModel Policy = new PolicyViewModel
//            {
//                Tenant = new TenantViewModel
//                {
//                    Forename = "tset",
//                    Surname = "tsstset",
//                    TitleId = 1,
//                }

//            };
//            var httpResponse = await _client.PostAsJsonAsync($"/api/Policy", Policy);
//            Assert.Equal(201, Convert.ToInt32(httpResponse.StatusCode));
//        }

//        //[Theory]
//        //[InlineData(2, "update1", "update  Policy line 2", 201)]
//        //[InlineData(2, "", "update line 2", 400)]
//        //[InlineData(8, "Policy", "update", 404)]
//        //public async Task CanUpdatePolicy(int PolicyId, String PolicyLine1, string PolicyLine2, int expectedResult)
//        //{
//        //    PolicyViewModel Policy = new PolicyViewModel
//        //    {
//        //        PolicyId = PolicyId,
//        //        PolicyType = Db.Entity.EnumTypes.PolicyTypes.EnquiryRental,
//        //        PolicyLine1 = PolicyLine1,
//        //        PolicyLine2 = PolicyLine2,
//        //    };

//        //    var httpResponse = await _client.PutAsJsonAsync($"/api/Policy/{PolicyId}", Policy);
//        //    Assert.Equal(expectedResult, Convert.ToInt32(httpResponse.StatusCode));
//        //}

//        //[Theory]
//        //[InlineData(4, 204)]
//        //public async Task CanDeletePolicy(int userid, int expectedResult)
//        //{
//        //    var httpResponse = await _client.DeleteAsync($"/api/Policy/{userid}");
//        //    Assert.Equal(expectedResult, Convert.ToInt32(httpResponse.StatusCode));
//        //    var httpResponseGet = await _client.GetAsync($"/api/Policy/{userid}");
//        //    Assert.Equal(404, Convert.ToInt32(httpResponseGet.StatusCode));
//        //}
//    }
//}
