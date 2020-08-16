using iSocietyCare.Db;
using System;
using System.ComponentModel.DataAnnotations;
using iSocietyCare.NotificationService.Models;
using iSocietyCare.Db.Abstractions.Enums;

namespace iSocietyCare.NotificationService.DbEntity
{
    public class NotificationConfiguration : BaseEntity
    {
        [Key]
        public int NotificationConfigurationId { get; set; }
        public NotificationTypes TypeOfNotification { get; set; }
        public String ConfigData { get; set; }
        public int? SMTPConfigurationId { get; set; }
        public SMTPConfiguration SMTP { get; set; }
    }
}
