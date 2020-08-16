using iSocietyCare.Db;
using System;
using System.ComponentModel.DataAnnotations;
using iSocietyCare.NotificationService.Models;
using iSocietyCare.Db.Abstractions.Enums;

namespace iSocietyCare.NotificationService.DbEntity
{
    public class EmailLog : BaseEntity
    {
        [Key]
        public int EmailId { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public string CC { get; set; }
        public string BCC { get; set; }
        public string Subject { get; set; }
        public string MessageBody { get; set; }
        public DateTime SentDateTime { get; set; }
        public String Description { get; set; }
        public MessageTypes MessageType { get; set; }
        public Guid? MessageId { get; set; }
    }
}
