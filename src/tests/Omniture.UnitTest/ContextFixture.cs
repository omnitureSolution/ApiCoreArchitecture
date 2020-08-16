//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Options;
//using Omniture.Core.Model.Account;
////using Omniture.Db.Entity.Database;
//using Omniture.Shared.Helper;

//namespace Omniture.UnitTest
//{
//    public static class ContextProvider
//    {
//        public static SocietyCareContext GetContext()
//        {
//            var optionsBuilder = new DbContextOptionsBuilder<SocietyCareContext>()
//                .UseInMemoryDatabase(databaseName: "SocietyCare_Test")
//                .Options;
//            return new SocietyCareContext(optionsBuilder, new UserInformation());
//        }

//    }


//    public class TestCommon
//    {
//        public static OptionsWrapper<AuthenticationKeys> AuthConfiguration =>
//            new OptionsWrapper<AuthenticationKeys>(new AuthenticationKeys
//            {
//                Audience = "http://localhost/",
//                EncKey = "N67MNb56unj90vdf",
//                ExpireInMin = 1,
//                Issuer = "http://localhost/",
//                SigningKey = "AB12sd1245E4thdB"
//            });
//    }
//}
