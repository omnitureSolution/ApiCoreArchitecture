using Omniture.Db;
using Omniture.Db.Abstractions.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Omniture.Db.Entity.Notification
{
    //[Table("MessageTemplate", Schema = "not")]
    public class MessageTemplate : BaseEntity
    {
        [Key]
        public int TemplateId { get; set; }
        public String TemplateFullName { get; set; }
        public string Subject { get; set; } 
        public string SmsTemplate { get; set; }
}
}
