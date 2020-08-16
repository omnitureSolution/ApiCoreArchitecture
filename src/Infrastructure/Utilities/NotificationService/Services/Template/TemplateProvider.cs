//using Microsoft.AspNetCore.Hosting;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Omniture.NotificationService.Context;
//
//
//using Omniture.NotificationService.Interfaces.Templates;
//
//using Omniture.Db.Abstractions.Enums;

//namespace Omniture.NotificationService.Services.Template
//{
//    public class TemplateProvider : TemplateFormatter, ITemplateProvider, IEmailTemplateGenerator
//    {
//        OmnitureNotificationContext _context;
//        ITemplateGenerator _templateGenerator;
//        IEmailTemplateGenerator _emailTemplateGenerator;
//        IMessageTemplate _notificationtemplate;
//        IEmailSender _emailSender;
//        Func<NotificationTypes, INotificationHandler> _notificationHandlers;
//        EMailDataView _eMailData;

//        public TemplateProvider(OmnitureNotificationContext context,
//            ITemplateGenerator templateGenerator, IEmailTemplateGenerator emailTemplateGenerator,
//             Func<NotificationTypes, INotificationHandler> notificationHandlers,
//            IMessageTemplate notificationtemplate,
//            IHostingEnvironment hostEnvironment,

//            IEmailSender emailSender) : base(hostEnvironment)
//        {
//            _context = context;
//            _templateGenerator = templateGenerator;
//            _emailTemplateGenerator = emailTemplateGenerator;
//            _emailSender = emailSender;
//            _notificationtemplate = notificationtemplate;
//            _notificationHandlers = notificationHandlers;
//        }

//        public MessageTemplate Template { get; set; }
//        public TemplateGenerateView TemplateView { get; set; }

//        public EMailDataView GetTemplate(TemplateLoaderView templateLoaderView)
//        {
//            var feature = _context.MessageTemplate
//                          .FirstOrDefault(r => r.MessageType == templateLoaderView.MessageType);
//            if (feature == null)
//            {
//                throw new InvalidOperationException($"Invalid message type {templateLoaderView.MessageType}; ");
//            }
//            var template = _notificationtemplate.GetTemplate(notification.NotificationId);
//            templateLoaderView.EMailData.Template = _emailTemplateGenerator.FormatMessage(template.TemplateFullName, templateLoaderView.EMailData);
//            templateLoaderView.EMailData.Subject = template.Subject;
//            templateLoaderView.EMailData.FromEmail = templateLoaderView.EMailData.FromEmail;

//            return templateLoaderView.EMailData;
//        }

//        public void SendEmail(TemplateLoaderView templateLoaderView)
//        {
//            var feature = _context.NotificationFeature
//                          .Include(r => r.Notifications)
//                            .ThenInclude(t => t.NotificationConfiguration)
//                                .ThenInclude(k => k.SMTP)
//                                    .ThenInclude(n => n.SMTPSenderDetail)
//                             .FirstOrDefault(r => r.TypeOfFeature == templateLoaderView.FeatureType && r.IsActive);

//            if (feature == null)
//            {
//                throw new InvalidOperationException($"Invalid feature type {templateLoaderView.FeatureType}; ");
//            }
//            var notification = feature.Notifications
//                                    .First(r => r.NotificationConfiguration.TypeOfNotification == NotificationTypes.Email);

//            var selectedHandler = _notificationHandlers(NotificationTypes.Email);

//            if (string.IsNullOrEmpty(templateLoaderView.EMailData.Subject))
//            {
//                var template = _notificationtemplate.GetTemplate(notification.NotificationId);
//                templateLoaderView.EMailData.Subject = template.Subject;
//            }
//            _eMailData = templateLoaderView.EMailData;
//            this.TemplateView = new TemplateGenerateView
//            {
//                NotificationId = notification.NotificationId
//            };
//            selectedHandler.Send(this, notification.NotificationConfiguration);
//        }

//        #region IEmailTemplateGenerator

//        public MessageTemplateView GetMessage()
//        {
//            return new MessageTemplateView
//            {
//                IsBodyHtml = true,
//                From = _eMailData.FromEmail,
//                To = _eMailData.To,
//                Subject = ReplaceTags(_eMailData.Subject, _eMailData),
//                MessageBody = _eMailData.Template,
//                EmailType = _eMailData.EmailType
//            };
//        }

//        #endregion
//    }
//}
