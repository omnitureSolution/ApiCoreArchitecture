using AutoMapper;
using FluentScheduler;
using FluentValidation.AspNetCore;
using Omniture.Core.Model.Account;
using Omniture.Db.Shared;
using Omniture.DependecyResolver;
using Omniture.DependecyResolver.Mapping;
using Omniture.NotificationService;
using Omniture.NotificationService.Context;
using Omniture.Shared.Configuration.Authorization;
using Omniture.Shared.Configuration.Exception;
using Omniture.Shared.Configuration.Logging;
using Omniture.Shared.Helper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using SocietyCareAPI.Filters;
using SocietyCareAPI.Scheduler;
using System.IO;

namespace SocietyCareAPI
{
    public class Startup
    {
        private static IConfigurationRoot _configuration;
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddEnvironmentVariables()
                .AddJsonFile("config\\appSettings.json", optional: false, reloadOnChange: true)
               .AddJsonFile($"config\\appsettings.{env.EnvironmentName}.json", optional: false, reloadOnChange: true);
            _configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuth(_configuration);
            services.AddContext<Omniture.Db.Entity.Database.OmnitureContext>(_configuration);
            services.AddNotificationContext<OmnitureNotificationContext>(_configuration);
            services.AddConfig(_configuration);
            services.AddAutoMapper(System.Reflection.Assembly.GetAssembly(typeof(ModelMapping)));

            services.AddConfigurationSupport(_configuration);

            services.AddControllers(options =>
                {
                    options.EnableEndpointRouting = false;
                    options.Filters.Add(typeof(ValidateModelAttribute));
                    options.Filters.Add(typeof(TransactionFilter));
                    options.Filters.Add(typeof(SaveChangesFilter));
                })
            .AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<UsersViewModel>())
            .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore); 

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Omniture API", Version = "v1" });

            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            JobManager.Initialize(new SchedulerTasks(_configuration["API:Url"]));
        }

        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            app.UseExceptionHandler(ExceptionHandler.HttpExceptionHandling(env));
            app.UseAuthentication();
            
            app.UseMiddleware<LogUserNameMiddleware>();
        
            app.UseStaticFiles();
            var doc = _configuration["DocPath:DocDir"];

            if (!string.IsNullOrEmpty(doc))
            {
                if (!Directory.Exists(doc))
                    Directory.CreateDirectory(doc);
                app.UseStaticFiles(new StaticFileOptions
                {
                    FileProvider = new PhysicalFileProvider(
                        Path.Combine(Directory.GetCurrentDirectory(), "TempDoc")),
                    RequestPath = "/static"
                });
            }

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                      Path.Combine(Directory.GetCurrentDirectory(), "Uploads")),
                RequestPath = "/userimage"
            });
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/v1/swagger.json", "Omniture API V1");
            });
            app.UseRouting();
            app.UseCors("AllowCorsPolicy");
            app.UseAuthorization();
            app.UseEndpoints(e => e.MapControllers());
            app.UseSpa(spa => {
                spa.Options.SourcePath = "wwwroot";
            });
        }
    }

}


