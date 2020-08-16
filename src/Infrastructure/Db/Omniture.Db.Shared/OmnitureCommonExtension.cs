using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Omniture.Db.Shared.Services;

namespace Omniture.Db.Shared
{
    public static class OmnitureCommonExtension
    {
        public static void AddConfigurationSupport(this IServiceCollection services, IConfigurationRoot configuration)
            
        {
            var connectionString = configuration["connectionStrings:SocietyCareContext"];
            services.AddDbContext<OmnitureCommonContext>(o => o.UseSqlServer(connectionString));
            services.AddScoped<OmnitureCommonContext, OmnitureCommonContext>();

            //services.AddScoped<IUnitOfWork, UnitOfWork<IVisionCommonContext>>();
            services.AddScoped(typeof(IUnitOfWork<OmnitureCommonContext>), typeof(UnitOfWork<OmnitureCommonContext>));

            services.AddScoped<IOmnitureConfiguration, OmnitureConfiguration>();
        }
    }


}
