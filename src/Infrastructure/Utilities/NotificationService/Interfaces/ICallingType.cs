using iSocietyCare.Db.Entity.Notification;
using System;
using System.Collections.Generic;
using System.Text;

namespace iSocietyCare.NotificationService.Interfaces
{
    public interface ICallingMethod
    {
        string Call(Scheduler sch);
    }
}
