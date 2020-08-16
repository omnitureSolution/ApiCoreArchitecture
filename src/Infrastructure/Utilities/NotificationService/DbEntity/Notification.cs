using iSocietyCare.Db;
using iSocietyCare.Db.Abstractions.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace iSocietyCare.NotificationService.DbEntity
{
    public class Notification : BaseEntity
    {
        [Key]
        public int NotificationId { get; set; }
        public MessageTypes MessageType { get; set; }
        public NotificationTypes NotificationType { get; set; }
        public bool IsActive { get; set; }
        public ICollection<SMTPConfiguration> SMTP { get; set; }

    }
}
