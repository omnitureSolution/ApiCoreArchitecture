//using System;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Mvc.Testing;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Diagnostics;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Logging;
//using Omniture.Db.Entity.Database;
////using Omniture.IntegrationTest.TestData;
//using Omniture.Shared.Configuration.Authorization;
//using Omniture.Shared.Configuration.Logging;
//using Omniture.Shared.Helper;
//using SocietyCareAPI;

//namespace Omniture.IntegrationTest
//{
//    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<Startup>
//    {

//        protected override void ConfigureWebHost(IWebHostBuilder builder)
//        {
//            builder.ConfigureServices(services =>
//            {
//                Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Test");
//                LogConfiguration.Configure();

//                // Create a new service provider.
//                var serviceProvider = new ServiceCollection()
//                    .AddEntityFrameworkInMemoryDatabase()
//                    .BuildServiceProvider();

//                // Add a database context (AppDbContext) using an in-memory database for testing.
//                services.AddDbContext<SocietyCareContext>(options =>
//                {
//                    options.UseInMemoryDatabase("InMemoryAppDb")
//                     .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
//                    options.UseInternalServiceProvider(serviceProvider);
//                });
//                services.AddScoped<IUserInfo, UserInformation>(provider =>
//                {
//                    return new UserInformation
//                    {
//                        UserId = -9999,
//                        UserType = 0
//                    };
//                });

//                var sp = services.BuildServiceProvider();

//                using (var scope = sp.CreateScope())
//                {
//                    var scopedServices = scope.ServiceProvider;
//                    var visionDb = scopedServices.GetRequiredService<SocietyCareContext>();

//                    var logger = scopedServices.GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();
//                    visionDb.Database.EnsureCreated();

//                    try
//                    {
//                        // Seed the database with some specific test data.
//                        SeedData.PopulateTestData(visionDb);
//                    }
//                    catch (Exception ex)
//                    {
//                        logger.LogError(ex, "An error occurred seeding the " +
//                                            "database with test messages. Error: {ex.Message}");
//                    }
//                }
//            });
//        }
//    }
//}