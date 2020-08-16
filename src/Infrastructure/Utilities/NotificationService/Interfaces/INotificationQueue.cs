using iSocietyCare.Db.Abstractions.Enums;
using iSocietyCare.Db.Abstractions.Repository;
using iSocietyCare.Db.Entity.Notification;
using iSocietyCare.NotificationService.Models;
using System;

namespace iSocietyCare.NotificationService.Interfaces
{
    public interface INotificationQueue : IEntityRepository<NotificationQueue>
    {
        void AddToQueue(MessageTypes messageType, Guid messageId);
    }
}
