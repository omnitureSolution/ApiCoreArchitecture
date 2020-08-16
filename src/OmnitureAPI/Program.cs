using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog;
using Omniture.Shared.Configuration.Logging;

namespace SocietyCareAPI
{
    public class Program
    {

        public static void Main(string[] args)
        {
            //var webHost = BuildWebHost;
            //LogConfiguration.Configure();
            //webHost.Run();
            LogConfiguration.Configure();
            var webHost = CreateWebHostBuilder(args);
     
            webHost.Build().Run();
        }

        static IWebHost BuildWebHost =>
          new WebHostBuilder()
              .UseKestrel()
              .UseContentRoot(Directory.GetCurrentDirectory())
              .UseSetting("detailedErrors", "true")
              .UseIISIntegration()
              .UseStartup<Startup>()
              .CaptureStartupErrors(true)
              .UseSerilog()
              .Build();
    //}

    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                 .UseKestrel()
                  .UseContentRoot(Directory.GetCurrentDirectory())
                  .UseSetting("detailedErrors", "true")
                  .UseIISIntegration()
                  .UseStartup<Startup>()
                  .CaptureStartupErrors(true)
                  .UseSerilog();


    }
}