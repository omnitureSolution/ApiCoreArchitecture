using iSocietyCare.Db.Entity.Notification;
using iSocietyCare.NotificationService.Interfaces.Templates;

namespace iSocietyCare.NotificationService.Interfaces
{
    public interface INotificationHandler
    {
        void Send(ITemplates template,Notification notification);

    }

    public interface IEmailSender
    {
        void ProcessQueue();
    }


}
