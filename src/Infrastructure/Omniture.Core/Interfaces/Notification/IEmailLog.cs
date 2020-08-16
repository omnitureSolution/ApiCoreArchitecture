using System.Collections.Generic;
using System.Net.Mail;
using System.Threading.Tasks;
using Omniture.Core.Model.Notification;
using Omniture.Db.Abstractions.Repository;
using Omniture.Db.Entity.Notification;

namespace Omniture.Core.Interfaces.Notification
{
    public interface IEmailLog : IEntityRepository<EmailLog>
    {
        void AddEMailLog(MailMessage mail,NotificationQueue queue);
        Task<List<EmailView>> GetMails(string messageId);
    }
}
