using iSocietyCare.NotificationService.DbEntity;
using Microsoft.EntityFrameworkCore;

namespace iSocietyCare.NotificationService.Context
{
    public interface ISocietyCareNotificationContext : iSocietyCare.Db.Context.IContext
    {
        DbSet<EmailLog> EmailLog { get; set; }
        //DbSet<NotificationConfiguration> NotificationConfiguration { get; set; }
        DbSet<DbEntity.Notification> Notification { get; set; }
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
