//using System;
//using System.Net.Http;
//using System.Threading.Tasks;
////using Omniture.Core.Model.Insurance;
//using Omniture.Db.Abstractions.Enums;
//using SocietyCareAPI;
//using Xunit;

//namespace Omniture.IntegrationTest
//{
//    public class EnquiryControllerTest : IClassFixture<CustomWebApplicationFactory<Startup>>
//    {
//        private readonly HttpClient _client;

//        public EnquiryControllerTest(CustomWebApplicationFactory<Startup> factory)
//        {
//            _client = factory.CreateClient();
//        }

//        [Theory]
//        [InlineData("Enquiry", 404)]
//        [InlineData("Enquiry/1", 200)]
//        public async Task CanGetEnquiry(String url, int expectedResult)
//        {
//            var httpResponse = await _client.GetAsync($"/api/" + url);
//            Assert.Equal(expectedResult, Convert.ToInt32(httpResponse.StatusCode));
//        }

//        [Theory]
//        [InlineData("00003", 1, 422)]
//        [InlineData("00005", 2, 201)]
//        public async Task CanCreateEnquiry(String EnquiryNumber, int EnquiryType, int expectedResult)
//        {
//            EnquiryViewModel Enquiry = new EnquiryViewModel
//            {
//                EnquiryNumber = EnquiryNumber,
//                EnquiryTypeId = (EnquiryTypes) EnquiryType,
//            };
//            var httpResponse = await _client.PostAsJsonAsync($"/api/Enquiry", Enquiry);
//            Assert.Equal(expectedResult, Convert.ToInt32(httpResponse.StatusCode));
//        }
        
//        [Theory]
//        [InlineData(4, 204)]
//        public async Task CanDeleteEnquiry(int userid, int expectedResult)
//        {
//            var httpResponse = await _client.DeleteAsync($"/api/Enquiry/{userid}");
//            Assert.Equal(expectedResult, Convert.ToInt32(httpResponse.StatusCode));
//            var httpResponseGet = await _client.GetAsync($"/api/Enquiry/{userid}");
//            Assert.Equal(404, Convert.ToInt32(httpResponseGet.StatusCode));
//        }
//    }
//}
