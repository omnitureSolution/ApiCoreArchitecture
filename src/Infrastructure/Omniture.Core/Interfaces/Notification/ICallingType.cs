using Omniture.Db.Entity.Notification;
using System;
using System.Collections.Generic;
using System.Text;

namespace Omniture.Core.Interfaces.Notification
{
    public interface ICallingMethod
    {
        string Call(Scheduler sch);
    }
}
