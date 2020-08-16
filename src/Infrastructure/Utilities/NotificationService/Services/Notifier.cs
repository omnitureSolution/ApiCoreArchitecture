using Omniture.Core.Interfaces.Notification;
using Omniture.Core.Interfaces.Notification.Templates;
using Omniture.Core.Models.Notification;
using Omniture.Db.Abstractions.Enums;
using Omniture.Db.Entity.Notification;
using Omniture.Db.Shared.Services;
using Omniture.NotificationService.Context;
 
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Linq;

namespace Omniture.NotificationService.Services
{
    public class Notifier : INotifier
    {
        private readonly ITemplateGenerator _templateGenerator;
        private readonly OmnitureNotificationContext _context;
        private readonly OmnitureConfiguration _config;
        private readonly Func<NotificationTypes, INotificationHandler> _notificationHandlers;
        private readonly INotificationQueue _notificationQueue;

        public Notifier(ITemplateGenerator templateGenerator,
            OmnitureNotificationContext context,
            Func<NotificationTypes, INotificationHandler> notificationHandlers,
            INotificationQueue notificationQueue,
            OmnitureConfiguration config)
        {
            _templateGenerator = templateGenerator;
            _context = context;
            _config = config;
            _notificationHandlers = notificationHandlers;
            _notificationQueue = notificationQueue;
        }

        public void SendPending()
        {
            //Boolean.TryParse(_config.GetConfigValue(NotificationConfig.EnableEmailService.ToString()), out Boolean isEMailEnable);
            //Log.Information("Notifier.SendPending", "is email service enable ", isEMailEnable);
            //if (!isEMailEnable)
            //    return;

            var queuedData = _context.NotificationQueue.Where(t => t.Status == NotificationSentStatus.New
                            || (t.Status == NotificationSentStatus.Failed && t.RetryCount < 5)).ToList();
            Log.Information("Notifier.SendPending", "total record found ", queuedData);
            foreach (var notification in queuedData)
            {
                try
                {
                    UpdateQueueStatus(notification, NotificationSentStatus.Processing);
                    var result = SendNotification(notification);
                    Log.Information("Notifier.SendPending", "result of send notification ", result);
                    UpdateQueueStatus(notification, result.Item1, result.Item2);

                }
                catch (Exception ex)
                {
                    UpdateQueueStatus(notification, NotificationSentStatus.Failed, ex.ToString());
                    Log.Error(ex, $"Notifier.SendPending(NotificationQueueId:{notification.NotificationQueueId})");
                }
            }
        }

        private int UpdateQueueStatus(NotificationQueue queue, NotificationSentStatus status, String description = "")
        {
            queue.Status = status;
            if (status == NotificationSentStatus.Failed)
                queue.RetryCount += 1;
            queue.Description = description;
            if (status == NotificationSentStatus.Sent)
                _context.NotificationQueue.Remove(queue);
            else
                _context.NotificationQueue.Update(queue);
            return _context.SaveChangesAsync().Result;
        }

        private Tuple<NotificationSentStatus, string> SendNotification(NotificationQueue notificationQueue)
        {
            var feature = _context.Notification
                          .Include(r => r.SMTP)
                          .Where(r => r.IsActive).ToList();
            var description = "";
            int completed = 0;
            foreach (var item in feature)
            {
                try
                {
                    var selectedHandler = _notificationHandlers(item.NotificationType);
                    if (!item.IsActive)
                    {
                        description += $"Feature disabled :{item.NotificationId.ToString()}; ";
                        continue;
                    }
                    var template = _templateGenerator.GetTemplateHandler(new TemplateGenerateView
                    {
                        NotificationQueue = notificationQueue,
                        MessageId = notificationQueue.MessageId,
                        NotificationType = item.NotificationType,
                    });
                    selectedHandler.Send(template, item);
                    completed++;
                }
                catch (Exception ex)
                {
                    description = ex.ToString();
                    Log.Error(ex, "Notifier.SendNotification");
                }
            }

            if (completed == 0)
                return Tuple.Create(NotificationSentStatus.Failed, description);
            //if (completed == feature.)
            //    return Tuple.Create(Models.NotificationSentStatus.Sent, description);
            return Tuple.Create(NotificationSentStatus.Partial, description);

        }
    }
}
