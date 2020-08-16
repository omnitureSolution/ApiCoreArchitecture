using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Omniture.NotificationService.Repository;
using Omniture.NotificationService.Context;
 

using Omniture.NotificationService.Services;
using Omniture.NotificationService.Services.Template;
using Omniture.Db.Context;
using Omniture.Db;
using Omniture.Db.Abstractions.Enums;
using Omniture.Core.Interfaces.Notification;
using Omniture.Core.Interfaces.Notification.Templates;

namespace Omniture.NotificationService
{
    public static class OmnitureNotificationExtension
    {
        public static void AddNotificationContext<TContext>(this IServiceCollection services,
            IConfiguration configuration) where TContext : IContext
        {
            //var connectionString = configuration["connectionStrings:SocietyCareContext"];
            //services.AddDbContext<SocietyCareNotificationContext>(o => o.UseSqlServer(connectionString));
            
            //services.AddScoped<IUnitOfWork, UnitOfWork<TContext>>();
            //services.AddScoped(typeof(IUnitOfWork<TContext>), typeof(UnitOfWork<TContext>));

            //services.AddScoped<ISMTPSenderDetail, SMTPSenderDetailRepository>();
            services.AddScoped<IEmailLog, EmailLogRepository>();
            //services.AddScoped<INotificationConfiguration, NotificationConfigurationRepository>();
            services.AddScoped<INotificationQueue, NotificationRepository>();
            services.AddScoped<IMessageTemplate, MessageTemplateRepository>();
            //services.AddScoped<IEMailQueue, EmailQueueRepository>();

            services.AddScoped<INotifier, Notifier>();

            //services.AddScoped<INotificationHandler, EmailService>();
            //services.AddScoped<INotificationHandler, EmailQueueRepository>();
            //services.AddScoped<INotificationHandler, SMSService>();

            services.AddScoped<EmailService>();
            //services.AddScoped<EmailQueueRepository>();
            services.AddScoped<SMSService>();

            services.AddScoped<Func<NotificationTypes, INotificationHandler>>(provider => (key) =>
            {
                switch (key)
                {
                    case NotificationTypes.Email:
                        return provider.GetService<EmailService>();
                    //return provider.GetService<EmailService>();
                    case NotificationTypes.SMS:
                        return provider.GetService<SMSService>();
                    default:
                        return null;
                }
            });

            //services.AddScoped<IEmailSender, EmailService>();
            //services.AddScoped<ITemplateProvider, TemplateProvider>();

            services.AddScoped<IScheduler, SchedulerRepository>();
            services.AddScoped<IScheduleHistory, ScheduleHistoryRepository>();

            services.AddScoped<IScheduleHandler, ScheduleHandler>();
            services.AddScoped<APICallingMethod>();
            services.AddScoped<AssemblyCallingMethod>();

            services.AddScoped<Func<CallTypes, ICallingMethod>>(provider => (key) =>
            {
                switch (key)
                {
                    case CallTypes.Api:
                        return provider.GetService<APICallingMethod>();
                    case CallTypes.Assembly:
                        return provider.GetService<AssemblyCallingMethod>();
                    default:
                        return null;
                }
            });



            #region Template Generator
            services.AddScoped<ITemplateGenerator, TemplateGenerator>();
            services.AddScoped<EmailTemplateGenerator>();
            services.AddScoped<SMSTemplateGenerator>();

            services.AddScoped<Func<NotificationTypes, ITemplates>>(provider => (key) =>
            {
                switch (key)
                {
                    case NotificationTypes.Email:
                        return provider.GetService<EmailTemplateGenerator>();
                    //return provider.GetService<EmailService>();
                    case NotificationTypes.SMS:
                        return provider.GetService<SMSTemplateGenerator>();
                    default:
                        return null;
                }
            });

            services.AddScoped<IEmailTemplateGenerator, EmailTemplateGenerator>();
            services.AddScoped<ISMSTemplateGenerator, SMSTemplateGenerator>();

            #endregion
        }
         
    }
}
