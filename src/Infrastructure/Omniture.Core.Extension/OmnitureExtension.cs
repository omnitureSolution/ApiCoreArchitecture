using Omniture.Core.Interfaces.Services.Account;
using Omniture.Core.Interfaces.Services.Masters;
using Omniture.Db;
using Omniture.Db.Context;
using Omniture.Db.Entity.Database;
using Omniture.Insurance.Data.Repository.Account;
using Omniture.Insurance.Services.Account;
using Omniture.NotificationService.Context;
using MastersService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
//using NotificationService;

namespace Omniture.DependecyResolver
{
    public static class OmnitureExtension
    {
        public static void AddContext<TContext>(this IServiceCollection services, IConfigurationRoot configuration)
            where TContext : IContext
        {
            var connectionString = configuration["connectionStrings:OmnitureContext"];
            services.AddDbContext<OmnitureContext>(o => o.UseSqlServer(connectionString));
            services.AddScoped<OmnitureContext, OmnitureContext>();
            services.AddScoped<OmnitureNotificationContext, OmnitureContext>();
            
            services.AddScoped<IUnitOfWork, UnitOfWork<TContext>>();
            services.AddScoped(typeof(IUnitOfWork<TContext>), typeof(UnitOfWork<TContext>));

            #region Account
            services.AddScoped<IUser, UserRepository>(); 
            #endregion

            #region services
            services.AddScoped<IUserService, UserService>(); 
            #endregion

            #region Masters
            services.AddScoped<IMasters, Masters>();
            services.AddScoped<IFileUpload, FileUploadService>();
            #endregion
             
        }
    }


}
