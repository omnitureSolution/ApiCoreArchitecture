using System.Net.Mail;
using iSocietyCare.Db.Abstractions.Repository;
using iSocietyCare.Db.Entity.Notification;

namespace iSocietyCare.NotificationService.Interfaces
{
    public interface IEmailLog : IEntityRepository<EmailLog>
    {
        void AddEMailLog(MailMessage mail,NotificationQueue queue);
    }
}
