using Omniture.Db.Abstractions.Enums;
using Omniture.Db.Abstractions.Repository;
using Omniture.Db.Entity.Notification;
using System;

namespace Omniture.Core.Interfaces.Notification
{
    public interface INotificationQueue : IEntityRepository<NotificationQueue>
    {
        void AddToQueue( Guid messageId);
        void DeleteQueue(Guid messageId);
        void ReQueue(string messageId);
    }
}
