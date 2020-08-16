using Omniture.Core.Interfaces.Notification;
using Omniture.Core.Interfaces.Notification.Templates;
using Omniture.Core.Models.Notification;
using Omniture.Db;
using Omniture.Db.Entity.Notification;
using Omniture.Db.Shared.Services;
using Omniture.NotificationService.Context; 

using Microsoft.AspNetCore.Hosting;
using System;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Omniture.NotificationService.Services
{
    public class EmailService : INotificationHandler
    {
        private readonly IEmailLog _emailLog;
        private readonly INotificationQueue _queue;
        private readonly IUnitOfWork _unitOfWork;
        private readonly OmnitureConfiguration _config;

        private readonly OmnitureNotificationContext _context;
        public EmailService(IEmailLog emailLog, INotificationQueue queue, IUnitOfWork unitOfWork, OmnitureConfiguration config,
            OmnitureNotificationContext context)
        {
            _emailLog = emailLog;
            _queue = queue;
            _unitOfWork = unitOfWork;
            _config = config;
            _context = context; 
        }
        private async Task<Boolean> SendMail(MessageTemplateView template, Notification notification)
        {
            var tranStarted = false;
            try
            {
                var smtpServer = new SmtpClient(notification.SMTP.SMTPserver);
                if (!string.IsNullOrEmpty(notification.SMTP.MailHost))
                    smtpServer.Host = notification.SMTP.MailHost;
                smtpServer.Port = Convert.ToInt32(notification.SMTP.MailPort);
                smtpServer.UseDefaultCredentials = false;
                smtpServer.Credentials = new System.Net.NetworkCredential(notification.SMTP.MailFrom, notification.SMTP.Password);
                smtpServer.EnableSsl = true;
                template.From = notification.SMTP.MailFrom;
                var mail = GetMailDetail(template, notification.SMTP);
                await smtpServer.SendMailAsync(mail);
                _unitOfWork.Begin();
                tranStarted = true;

                _emailLog.AddEMailLog(mail, template.NotificationQueue);
                await _unitOfWork.SaveAsync();
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception)
            {
                //queue.RetryCount++;
                if (tranStarted)
                    _unitOfWork.Rollback();
                //queue.Description = ex.ToString();
                //queue.Status = NotificationSentStatus.Failed;
                //_queue.Update(queue);
                await _unitOfWork.SaveAsync();
                throw;
            }
        }
        private MailMessage GetMailDetail(MessageTemplateView emailMessage,SMTPConfiguration sMTP)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(emailMessage.From);

            foreach (string address in emailMessage.To)
            {
                if (!string.IsNullOrEmpty(address) && !string.IsNullOrWhiteSpace(address))
                {
                    mail.To.Add(new MailAddress(address));
                }
            }

            if (emailMessage.CC != null)
                foreach (string address in emailMessage.CC)
                {
                    if (!string.IsNullOrEmpty(address) && !string.IsNullOrWhiteSpace(address))
                    {
                        mail.CC.Add(new MailAddress(address));
                    }
                }

            if (sMTP.DefaultCC != null)
            {
               var defaultCC = sMTP.DefaultCC.Split(';');
                if(defaultCC==null || !defaultCC.Any())
                     defaultCC = sMTP.DefaultCC.Split(',');
                foreach (string address in defaultCC)
                {
                    if (!string.IsNullOrEmpty(address) && !string.IsNullOrWhiteSpace(address))
                    {
                        mail.CC.Add(new MailAddress(address));
                    }
                }
            }

            if (emailMessage.BCC != null)
                foreach (string address in emailMessage.BCC)
                {
                    if (!string.IsNullOrEmpty(address) && !string.IsNullOrWhiteSpace(address))
                    {
                        mail.Bcc.Add(new MailAddress(address));
                    }
                }

            if (sMTP.DefaultBCC != null)
            {
                var defaultCC = sMTP.DefaultBCC.Split(';');
                if (defaultCC == null || !defaultCC.Any())
                    defaultCC = sMTP.DefaultBCC.Split(',');
                foreach (string address in defaultCC)
                {
                    if (!string.IsNullOrEmpty(address) && !string.IsNullOrWhiteSpace(address))
                    {
                        mail.Bcc.Add(new MailAddress(address));
                    }
                }
            }

            mail.Subject = emailMessage.Subject;
            mail.Body = emailMessage.MessageBody;
            mail.IsBodyHtml = true;

            if (!mail.IsBodyHtml)
            {
                mail.Body = mail.Body.Replace("\r\n", "\r");
                mail.Body = mail.Body.Replace("\r", "\r\n");
            }
            return mail;
        }
        public void Send(ITemplates template, Notification notification)
        {
            //var mailData = template.GetMessage();
            SendMail(template.GetMessage(), notification).Wait();
        }

        //private void AddAttachment(EmailQueue emailQueue, MailMessage mail)
        //{
        //    var response = HttpApiClient.Get<List<DocumentList>>($"{_config.GetConfigValue(SystemConfig.VisionPlusAPIUrl.ToString())}//Document/attachment?messageId={emailQueue.MessageId}", "");
        //    if (response == null || !response.Any())
        //        return;
        //    foreach (var attachment in response)
        //    {
        //        var filePath = $"{_hostEnvironment.ContentRootPath}//Template//{attachment.DocumentPath}";
        //        mail.Attachments.Add(new Attachment(filePath));
        //    }
        //}
    }
}
