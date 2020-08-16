using System;
using System.Collections.Generic;
using System.Text;
using Omniture.Db.Abstractions.Repository;
using Omniture.Db.Entity.Notification;

namespace Omniture.Core.Interfaces.Notification
{
    public interface IScheduler : IEntityRepository<Scheduler>
    {
        void Execute();
        void CreateHitory(Scheduler sch, string response);
    }
}
