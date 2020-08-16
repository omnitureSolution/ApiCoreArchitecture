using Omniture.Db.Context;
using Omniture.Db.Entity.Notification;
using Microsoft.EntityFrameworkCore;

namespace Omniture.NotificationService.Context
{
    public interface OmnitureNotificationContext : IContext
    {
        DbSet<EmailLog> EmailLog { get; set; }
        //DbSet<NotificationConfiguration> NotificationConfiguration { get; set; }
        DbSet<Notification> Notification { get; set; }
        //DbSet<NotificationFeature> NotificationFeature { get; set; }
        //DbSet<NotificationTemplate> NotificationTemplate { get; set; }
        DbSet<SMTPConfiguration> SMTPConfiguration { get; set; }
        DbSet<NotificationQueue> NotificationQueue { get; set; }
        //DbSet<SMTPSenderDetail> SMTPSenderDetail  { get; set; }
        DbSet<Scheduler> Scheduler { get; set; }
        DbSet<ScheduleHistory> ScheduleHistory { get; set; }
        DbSet<MessageTemplate> MessageTemplate { get; set; }
        //DbSet<EmailQueue> EmailQueue { get; set; }
    }
}
