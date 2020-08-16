using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions; 

using Omniture.Db.Entity.Notification;
using Omniture.Core.Interfaces.Notification.Templates;
using Omniture.Core.Models.Notification;

namespace Omniture.NotificationService.Services.Template
{
    public class EmailTemplateGenerator : TemplateFormatter, IEmailTemplateGenerator
    {
        public MessageTemplate Template { get; set; }
        public TemplateGenerateView TemplateView { get; set; }
        public EmailTemplateGenerator(IHostingEnvironment hostEnvironment)
            : base(hostEnvironment)
        {
        }
        public MessageTemplateView GetMessage()
        {
            var message = FormatMessage(Template.TemplateFullName, TemplateView.EMailDataView);
            return new MessageTemplateView
            {
                IsBodyHtml = true,
                //From = TemplateView.FromEmail,
                To = TemplateView.EMailDataView.To,
                Subject = ReplaceTags(Template.Subject, TemplateView.EMailDataView),
                MessageBody = message,
                NotificationQueue= TemplateView.NotificationQueue,
                MessageId = TemplateView.MessageId
            };
        }
    }
}
