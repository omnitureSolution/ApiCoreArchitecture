using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Omniture.Shared.Helper
{
    public static class ConfigurationMapping
    {
        public static void AddConfig(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.Configure<AuthenticationKeys>(configuration.GetSection("AuthenticationKeys"));
            services.Configure<Logging>(configuration.GetSection("Logging"));
 
            services.Configure<ApplicationSettings>(configuration.GetSection("ApplicationSettings"));
            services.Configure<DocPath>(configuration.GetSection("DocPath"));
            
        }
    }

    public class Logging
    {
        public Boolean IncludeScopes { get; set; }
        public LogLevel LogLevel { get; set; }
    }

    public class LogLevel
    {
        public String Default { get; set; }
        public String System { get; set; }
        public String Microsoft { get; set; }

    }
 

    public class ApplicationSettings
    {
        public string Mode { get; set; }
    }

    public class DocPath
    {
        public string DocDir { get; set; }
    }

    public class FtpSetting
    {
        public string Url { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class AuthenticationKeys
    {
        public String Issuer { get; set; }
        public String Audience { get; set; }
        public String SigningKey { get; set; }
        public String EncKey { get; set; }
        public int ExpireInMin { get; set; }
    }

    public class ReportSettings
    {
        public string ReportUrl { get; set; }
    }

}
