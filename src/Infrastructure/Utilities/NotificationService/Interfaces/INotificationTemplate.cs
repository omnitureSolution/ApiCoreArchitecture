using iSocietyCare.NotificationService.DbEntity;
using iSocietyCare.Db.Abstractions.Repository;
using iSocietyCare.Db.Abstractions.Enums;
using iSocietyCare.Db.Entity.Notification;

namespace iSocietyCare.NotificationService.Interfaces
{
    public interface IMessageTemplate : IEntityRepository<MessageTemplate>
    {

        MessageTemplate GetTemplate(MessageTypes messageType);
    }
}
