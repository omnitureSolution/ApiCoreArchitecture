using Omniture.Core.Interfaces.Notification;
using Omniture.Db;
using Omniture.Db.Abstractions.Enums;
using Omniture.Db.Entity.Notification;
using Omniture.NotificationService.Context;
using Omniture.Shared.Common;
using System;
using System.Linq;

namespace Omniture.NotificationService.Repository
{
    public class NotificationRepository : Repository<NotificationQueue>, INotificationQueue
    {
        private readonly OmnitureNotificationContext _context;
        public NotificationRepository(OmnitureNotificationContext context) : base(context)
        {
            _context = context;
        }
        public void AddToQueue(Guid messageId)
        {
            Add(new NotificationQueue
            {
                MessageId = messageId,
                Status = NotificationSentStatus.New,
                RetryCount = 0,
            });
            _context.SaveChangesAsync().Wait();
        }
        public void DeleteQueue(Guid messageId)
        {
            var item = this.All.Where(r => r.MessageId == messageId).FirstOrDefault();
            if (item != null)
                Delete(item);
        }
        public void ReQueue(string messageId)
        {
            var guidMessage = Guid.Parse(messageId);
            var queue = All.FirstOrDefault(t => t.MessageId == guidMessage);
            if (queue != null)
            {
                queue.RetryCount = 0;
                queue.Status = NotificationSentStatus.New;
                Update(queue);
            }
            else
            {
                throw new ModelNotFoundException("Not enough data to send mail");
            }
            _context.SaveChangesAsync().Wait();
        }
    }
}
