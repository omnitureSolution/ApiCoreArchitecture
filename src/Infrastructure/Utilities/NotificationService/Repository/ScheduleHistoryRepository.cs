using System;
using System.Collections.Generic;
using System.Text;
using Omniture.Core.Interfaces.Notification;
using Omniture.Db;
using Omniture.Db.Entity.Notification;
using Omniture.NotificationService.Context;


 

namespace Omniture.NotificationService.Repository
{
    public class ScheduleHistoryRepository : Repository<ScheduleHistory>, IScheduleHistory
    {
        public ScheduleHistoryRepository(OmnitureNotificationContext context) : base(context)
        {
        }
    }
}
