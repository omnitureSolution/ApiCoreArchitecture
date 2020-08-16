using iSocietyCare.Db.Abstractions.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace iSocietyCare.NotificationService.Models
{
    public class EMailDataView
    {
        public List<string> To { get; set; }
        public List<string> Bcc { get; set; }
        public List<string> Cc { get; set; }
        public string Subject { get; set; }
        public string TemplateData { get; set; }
        public string Template { get; set; }
        public string FromEmail { get; set; }
        public int EmailType { get; set; }
    }

    public class TemplateLoaderView
    {
        public MessageTypes MessageType { get; set; }
        public EMailDataView EMailData { get; set; }
    }
}
