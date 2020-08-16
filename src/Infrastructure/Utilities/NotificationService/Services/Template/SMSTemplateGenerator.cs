using System;
using Omniture.Core.Interfaces.Notification.Templates;
using Omniture.Core.Models.Notification;
using Omniture.Db.Entity.Notification;


namespace Omniture.NotificationService.Services.Template
{
    public class SMSTemplateGenerator : ISMSTemplateGenerator
    {
        public MessageTemplate Template { get; set; }
        public string JsonData { get; set; }
        public TemplateGenerateView TemplateView { get ; set ; }

        public MessageTemplateView GetMessage()
        {
            throw new NotImplementedException();
        }
    }
}
