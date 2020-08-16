using Microsoft.EntityFrameworkCore;
using iSocietyCare.NotificationService.DbEntity;
using iSocietyCare.Db.Context;
using iSocietyCare.Shared.Helper;
using System.Collections.Generic;

namespace iSocietyCare.NotificationService.Context
{
    public class SocietyCareNotificationContext : SocietyCareBaseContext<SocietyCareNotificationContext>, ISocietyCareNotificationContext
    {
        public SocietyCareNotificationContext(DbContextOptions<SocietyCareNotificationContext> options)
         : base(options, new UserInformation())
        {
        }
        public DbSet<EmailLog> EmailLog { get; set; }
        //public DbSet<NotificationConfiguration> NotificationConfiguration { get; set; }
        public DbSet<DbEntity.Notification> Notification { get; set; }
        //public DbSet<NotificationFeature> NotificationFeature { get; set; }
        //public DbSet<NotificationTemplate> NotificationTemplate { get; set; }
        public DbSet<SMTPConfiguration> SMTPConfiguration { get; set; }
        public DbSet<NotificationQueue> NotificationQueue { get; set; }
        //public DbSet<SMTPSenderDetail> SMTPSenderDetail { get; set; }
        public DbSet<Scheduler> Scheduler { get; set; }
        public DbSet<ScheduleHistory> ScheduleHistory { get; set; }
        public DbSet<MessageTemplate> MessageTemplate { get; set; }
        //public DbSet<EmailQueue> EmailQueue { get; set; }
        //public DbSet<EmailAttachment> EmailAttachment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("not");
            base.OnModelCreating(modelBuilder);
        }
    }

    public class UserInformation : IUserInfo
    {
        public int UserId { get; set; }
        public int UserType { get; set; }
        public int UserAccess { get; set; }
        public int ReferenceId { get; set; }
        public ICollection<int> Society { get; set ; }
    }
}
