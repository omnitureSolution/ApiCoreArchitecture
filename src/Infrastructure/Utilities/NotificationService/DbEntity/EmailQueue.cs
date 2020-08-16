using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;
using System.Text;
using iSocietyCare.NotificationService.Models;
using iSocietyCare.Db;

namespace iSocietyCare.NotificationService.DbEntity
{
    public class EmailQueue : AuditEntity
    {
        [Key]
        public int EmailQueueId { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public String CC { get; set; }
        public String BCC { get; set; }
        public String Subject { get; set; }
        public String MessageBody { get; set; }
        public DateTime QueueDateTime { get; set; }
        public int RetryCount { get; set; }
        public String Description { get; set; }
        public NotificationSentStatus Status { get; set; }
        public int? NotificationConfigurationId { get; set; }
        public int? NotificationQueueId { get; set; }
        public int? SenderId { get; set; }
        public int EmailType { get; set; }
        public Guid? MessageId { get; set; }
        [ForeignKey("NotificationConfigurationId ")]
        public NotificationConfiguration NotificationConfiguration { get; set; }
        [NotMapped] public String Attachments { get; set; }
    }
}
