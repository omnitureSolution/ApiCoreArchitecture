using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using Omniture.Core.Model.Account;
using Omniture.Db.Entity.Database;

namespace SocietyCareAPI.DesignTimeContext
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<OmnitureContext>
    {
        public OmnitureContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Config\\appsettings.Development.json")
                .Build();
            var builder = new DbContextOptionsBuilder<OmnitureContext>();
            var connectionString = configuration["connectionStrings:SocietyCareContext"];
            builder.UseSqlServer(connectionString);
            return new OmnitureContext(builder.Options,new UserInformation());
        }
    }
}
