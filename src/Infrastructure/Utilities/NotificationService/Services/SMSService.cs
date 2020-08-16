using System;
using Omniture.Core.Interfaces.Notification;
using Omniture.Core.Interfaces.Notification.Templates;
using Omniture.Db.Entity.Notification;
 

namespace Omniture.NotificationService.Services
{
    public class SMSService : INotificationHandler
    {

        public void Send(ITemplates template, Notification notification)
        {
            throw new NotImplementedException();
        }
    }
}
