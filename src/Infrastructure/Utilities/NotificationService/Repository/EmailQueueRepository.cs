//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Omniture.Db;
//using Omniture.NotificationService.Context;
//
//
//using Omniture.NotificationService.Interfaces.Templates;
//

//namespace Omniture.NotificationService.Repository
//{
//    public class EmailQueueRepository : Repository<EmailQueue>, IEMailQueue, INotificationHandler
//    {
//        private readonly OmnitureNotificationContext _context;

//        public EmailQueueRepository(OmnitureNotificationContext context) : base(context)
//        {
//            _context = context;
//        }

//        public void Send(ITemplates template,Notification notification)
//        {
//            this.AddToQueue(template.GetMessage(), configuration, template.TemplateView.NotificationQueueId);
//        }

//        private void AddToQueue(MessageTemplate emailMessage, NotificationConfiguration configuration, int? notificationQueueId)
//        {
//            if (!configuration.SMTP.SMTPSenderDetail.Any())
//                throw new ArgumentNullException($"SMTP sender details not found for the SMTP. SMTP configuration id:{configuration.SMTPConfigurationId}");

//            var emailQueue = new EmailQueue
//            {
//                QueueDateTime = DateTime.Now,
//                Status = NotificationSentStatus.New,
//                RetryCount = 0,
//                MessageId = emailMessage.MessageId,
//                EmailType = emailMessage.EmailType
//            };

//            var smtpSender = !string.IsNullOrEmpty(emailMessage.From) ?
//                configuration.SMTP.SMTPSenderDetail.First(t => t.MailFrom == emailMessage.From) :
//                configuration.SMTP.SMTPSenderDetail.First(t => t.IsDefault);
//            emailQueue.From = smtpSender.MailFrom;

//            foreach (string address in emailMessage.To)
//            {
//                if (!string.IsNullOrEmpty(address) && !string.IsNullOrWhiteSpace(address))
//                {
//                    emailQueue.To += address + ";";
//                }
//            }

//            if (smtpSender.DefaultCC != null)
//                foreach (string address in smtpSender.DefaultCC.Split(';'))
//                {
//                    if (!string.IsNullOrEmpty(address) && !string.IsNullOrWhiteSpace(address))
//                    {
//                        emailQueue.CC += address + ";";
//                    }
//                }

//            if (smtpSender.DefaultBCC != null)
//                foreach (string address in smtpSender.DefaultBCC.Split(';'))
//                {
//                    if (!string.IsNullOrEmpty(address) && !string.IsNullOrWhiteSpace(address))
//                    {
//                        emailQueue.BCC += address + ";";
//                    }
//                }

//            emailQueue.Subject = emailMessage.Subject;
//            emailQueue.MessageBody = emailMessage.MessageBody;
//            emailQueue.NotificationConfigurationId = configuration.NotificationConfigurationId;
//            emailQueue.SenderId = smtpSender.SMTPSenderDetailsId;
//            emailQueue.NotificationQueueId = notificationQueueId;
//            this.Add(emailQueue);
//            _context.SaveChangesAsync().Wait();

//        }
//    }
//}
