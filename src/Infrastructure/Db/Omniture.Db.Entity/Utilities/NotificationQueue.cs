using iSocietyCare.Db.Abstractions.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace iSocietyCare.Db.Entity.Utilities
{
    public class NotificationQueue : AuditEntity
    {
        [Key]
        public int NotificationQueueId { get; set; }
        public NotificationTypes NotificationType { get; set; }
        public MessageTypes MessageType { get; set; }
        public Guid MessageId { get; set; }
        public string Parameters { get; set; }
        public int RetryCount { get; set; }
        public NotificationTypes Status { get; set; }
        public string Description { get; set; }
    }
}
