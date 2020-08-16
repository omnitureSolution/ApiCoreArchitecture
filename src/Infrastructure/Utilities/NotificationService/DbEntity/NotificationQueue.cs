using iSocietyCare.Db;
using System;
using System.ComponentModel.DataAnnotations;
using iSocietyCare.NotificationService.Models;
using iSocietyCare.Db.Abstractions.Enums;

namespace iSocietyCare.NotificationService.DbEntity
{
    public class NotificationQueue : AuditEntity
    {
        [Key]
        public int NotificationQueueId { get; set; }
        //public NotificationTypes NotificationType { get; set; }
        public MessageTypes MessageType { get; set; }
        public Guid MessageId { get; set; }
        public NotificationSentStatus Status { get; set; }
        public int RetryCount { get; set; }
        public string Description { get; set; }
        public string Parameters { get; set; }
        
    }
}
