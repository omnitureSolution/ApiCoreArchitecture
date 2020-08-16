using Omniture.Db;
using System;
using System.ComponentModel.DataAnnotations;
 
using Omniture.Db.Abstractions.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Omniture.Db.Entity.Notification
{
    //[Table("NotificationQueue", Schema = "not")]
    public class NotificationQueue : AuditEntity
    {
        [Key]
        public int NotificationQueueId { get; set; }
        //public NotificationTypes NotificationType { get; set; } 
        public Guid MessageId { get; set; }
        public NotificationSentStatus Status { get; set; }
        public int RetryCount { get; set; }
        public string Description { get; set; }
        public string Parameters { get; set; }
        
    }
}
