using iSocietyCare.Db;
using iSocietyCare.Db.Abstractions.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace iSocietyCare.NotificationService.DbEntity
{
    public class MessageTemplate : BaseEntity
    {
        [Key]
        public int TemplateId { get; set; }
        public String TemplateFullName { get; set; }
        public string Subject { get; set; }
        public MessageTypes MessageType { get; set; }
        public string SmsTemplate { get; set; }
}
}
