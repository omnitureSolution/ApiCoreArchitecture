using Omniture.Core.Interfaces.Notification.Templates;

namespace Omniture.Core.Interfaces.Notification
{
    public interface INotificationHandler
    {
        void Send(ITemplates template, Db.Entity.Notification.Notification notification);

    }

    public interface IEmailSender
    {
        void ProcessQueue();
    }


}
