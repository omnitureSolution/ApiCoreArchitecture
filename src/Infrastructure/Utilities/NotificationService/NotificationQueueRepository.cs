//using iSocietyCare.Core.Interfaces.Repository.Utilities;
//using iSocietyCare.Db;
//using iSocietyCare.Db.Abstractions.Enums;
//using iSocietyCare.Db.Entity.Database;
//using iSocietyCare.Db.Entity.Utilities;
//using System;

//namespace NotificationService
//{
//  public class NotificationQueueRepository : Repository<NotificationQueue>, INotificationQueue
//  {

//    public NotificationQueueRepository(ISocietyCareContext context) : base(context)
//    {
//    }

//    public void Queue(MessageTypes messageType, Guid messageId)
//    {
//      Add(new NotificationQueue
//      {
//        MessageId = messageId,
//        MessageType = messageType,
//        NotificationType = NotificationTypes.Email
//      });
//    }
//  }
//}
