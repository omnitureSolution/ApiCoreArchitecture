using Omniture.Core.Interfaces.Notification;
using Omniture.Core.Model.Notification;
using Omniture.Db;
using Omniture.Db.Entity.Notification;
using Omniture.NotificationService.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Omniture.NotificationService.Repository
{
    public class EmailLogRepository : Repository<EmailLog>, IEmailLog
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmailLogRepository(OmnitureNotificationContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddEMailLog(MailMessage mail, NotificationQueue queue)
        {
            var log = new EmailLog();
            log.From = mail.From.Address;
            log.To = string.Join(';', mail.To.Select(t => t.Address).ToArray());
            log.CC = string.Join(';', mail.CC.Select(t => t.Address).ToArray());
            log.BCC = string.Join(';', mail.Bcc.Select(t => t.Address).ToArray());
            log.MessageBody = mail.Body;
            log.SentDateTime = DateTime.Now;
            log.Subject = mail.Subject;
            log.Description = queue.Description;
            log.MessageId = queue.MessageId;
            Add(log);
        }
        public async Task<List<EmailView>> GetMails(string messageId)
        {
            var guidMessage = Guid.Parse(messageId);
            return await All.Where(r => r.MessageId == guidMessage)
                 .Select(t => new EmailView
                 {
                     From = t.From,
                     To = t.To,
                     Subject = t.Subject,
                     MessageBody = t.MessageBody,
                     SendDateTime=t.SentDateTime
                 }).ToListAsync();

        }
    }
}
