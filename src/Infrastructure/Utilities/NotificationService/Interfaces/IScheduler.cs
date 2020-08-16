using System;
using System.Collections.Generic;
using System.Text;
using iSocietyCare.Db.Abstractions.Repository;
using iSocietyCare.Db.Entity.Notification;

namespace iSocietyCare.NotificationService.Interfaces
{
    public interface IScheduler : IEntityRepository<Scheduler>
    {
        void Execute();
        void CreateHitory(Scheduler sch, string response);
    }
}
