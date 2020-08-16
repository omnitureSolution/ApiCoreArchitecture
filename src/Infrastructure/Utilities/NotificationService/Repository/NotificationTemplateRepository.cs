using System.Linq;
using Omniture.NotificationService.Context;

using Omniture.Db;
using Omniture.Db.Abstractions.Enums;
using Omniture.Db.Entity.Notification;
using Omniture.Core.Interfaces.Notification;

namespace Omniture.NotificationService.Repository
{
    public class MessageTemplateRepository : Repository<MessageTemplate>, IMessageTemplate
    {
        public MessageTemplateRepository(OmnitureNotificationContext context) : base(context)
        {

        }

        public MessageTemplate GetTemplate()
        {
            return FindByIncludeAsync(r => r.IsDeleteProcess).Result.FirstOrDefault();
        }
    }
}
