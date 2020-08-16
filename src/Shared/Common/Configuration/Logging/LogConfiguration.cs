using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Serilog;
using Serilog.Context;
using Serilog.Sinks.MSSqlServer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Omniture.Shared.Configuration.Authorization;

namespace Omniture.Shared.Configuration.Logging
{
    public class LogConfiguration
    {
        public static void Configure()
        {

            var _environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
                       .AddJsonFile("config\\appsettings.json")
                       .AddJsonFile($"config\\appsettings.{_environmentName}.json", optional: true, reloadOnChange: true)
                       .AddEnvironmentVariables()
                       .Build();

            var applicationName = Assembly.GetEntryAssembly().GetName().Name;


            //var connectionString = configuration["Serilog:WriteTo:0:Args:connectionString"];
            //var tableName = configuration["Serilog:WriteTo:0:Args:tableName"];

            //var customColumnOptions = new ColumnOptions();

            //customColumnOptions.AdditionalDataColumns = new List<System.Data.DataColumn> {
            //    new System.Data.DataColumn("Application",typeof(string)),
            //    new System.Data.DataColumn("UserId",typeof(int)),
            //    new System.Data.DataColumn("ThreadId",typeof(string)),
            //    new System.Data.DataColumn("CorrelationId",typeof(string)),
            //};

            Log.Logger = new LoggerConfiguration()
                          .ReadFrom.Configuration(configuration)
                          .Enrich.WithProperty("Application", applicationName)
                          .Enrich.WithThreadId()
                         .Enrich.FromLogContext()
                        .CreateLogger();
        }
    }

    public class LogUserNameMiddleware
    {
        private readonly RequestDelegate next;

        public LogUserNameMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public Task Invoke(HttpContext context)
        {
            var user = context.Request.Headers["user"];
            if (!string.IsNullOrEmpty(user))
            {
                var userdata = JsonConvert.DeserializeObject<UserInformation>(user);
                LogContext.PushProperty("UserId", userdata.UserId);
                LogContext.PushProperty("CorrelationId", context.TraceIdentifier);
            }

            return next(context);
        }
    }

}
