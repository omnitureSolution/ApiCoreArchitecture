//using System;
//using System.Net.Http;
//using System.Threading.Tasks;
////using Omniture.Core.Model.Insurance;
//using Omniture.Db.Abstractions.Enums;
//using SocietyCareAPI;
//using Xunit;

//namespace Omniture.IntegrationTest
//{
//    public class AddressControllerTest : IClassFixture<CustomWebApplicationFactory<Startup>>
//    {
//        private readonly HttpClient _client;

//        public AddressControllerTest(CustomWebApplicationFactory<Startup> factory)
//        {
//            _client = factory.CreateClient();
//        }

//        [Theory]
//        [InlineData("address", 404)]
//        [InlineData("address/4", 200)]
//        public async Task CanGetaddress(String url, int expectedResult)
//        {
//            var httpResponse = await _client.GetAsync($"/api/" + url);            
//            Assert.Equal(expectedResult, Convert.ToInt32(httpResponse.StatusCode));
//        }

//        [Theory]
//        //[InlineData("adress", Db.Entity.EnumTypes.AddressType.EnquiryRental, 422)]
//        [InlineData("",  AddressTypes.EnquiryRental, 400)]
//        [InlineData("address 3",  AddressTypes.EnquiryRental, 201)]
//        public async Task CanCreateaddress(String AddressLine1, AddressTypes AddressType, int expectedResult)
//        {
//            AddressViewModel address = new AddressViewModel
//            {
//                AddressLine1 = AddressLine1,
//                AddressTypeId = AddressType,
//            };
//            var httpResponse = await _client.PostAsJsonAsync($"/api/address", address);
//            Assert.Equal(expectedResult, Convert.ToInt32(httpResponse.StatusCode));
//        }

//        [Theory]
//        [InlineData(2, "update1", "update  address line 2", 201)]
//        [InlineData(2, "", "update line 2", 400)]
//        [InlineData(8, "address", "update", 404)]
//        public async Task CanUpdateaddress(int addressId, String AddressLine1, string AddressLine2, int expectedResult)
//        {
//            AddressViewModel address = new AddressViewModel
//            {
//                AddressId = addressId,
//                AddressTypeId =  AddressTypes.EnquiryRental,
//                AddressLine1 = AddressLine1,
//                AddressLine2 = AddressLine2,
//            };

//            var httpResponse = await _client.PutAsJsonAsync($"/api/address/{addressId}", address);
//            Assert.Equal(expectedResult, Convert.ToInt32(httpResponse.StatusCode));
//        }

//        [Theory]
//        [InlineData(4, 204)]
//        public async Task CanDeleteaddress(int userid, int expectedResult)
//        {
//            var httpResponse = await _client.DeleteAsync($"/api/address/{userid}");
//            Assert.Equal(expectedResult, Convert.ToInt32(httpResponse.StatusCode));
//            var httpResponseGet = await _client.GetAsync($"/api/address/{userid}");
//            Assert.Equal(404, Convert.ToInt32(httpResponseGet.StatusCode));
//        }
//    }
//}
