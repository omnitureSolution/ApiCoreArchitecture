using Omniture.Db.Abstractions.Repository;
using Omniture.Db.Abstractions.Enums;
using Omniture.Db.Entity.Notification;

namespace Omniture.Core.Interfaces.Notification
{
    public interface IMessageTemplate : IEntityRepository<MessageTemplate>
    {

        MessageTemplate GetTemplate();
    }
}
