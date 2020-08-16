using iSocietyCare.Db.Entity.Notification;
using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace iSocietyCare.NotificationService.Models
{
    public class MessageTemplateView
    {
        public int EmailId { get; set; }
        public List<string> To { get; set; }
        public string From { get; set; }
        public List<string> CC { get; set; }
        public List<string> BCC { get; set; }
        public string Subject { get; set; }
        public string MessageBody { get; set; }
        public Boolean IsBodyHtml { get; set; }
        public Guid? MessageId { get; set; }
        public List<Attachment> Attachments { get; set; } = new List<Attachment>();
        public List<string> ToMobileNumber { get; set; }
        public NotificationQueue NotificationQueue { get; set; }

    }
}
