using Omniture.Core.Interfaces.Notification;
using Omniture.Core.Interfaces.Repository.Utilities;
using Omniture.Db.Entity.Notification;
using System;


namespace Omniture.NotificationService.Services
{
    public class AssemblyCallingMethod : ICallingMethod
    {
        private readonly Func<string, IScheduleUpdate> _callingMethods;
        public AssemblyCallingMethod(Func<string, IScheduleUpdate> callingMethods)
        {
            _callingMethods = callingMethods;
        }
        public string Call(Scheduler sch)
        {
            var handler = _callingMethods(sch.Action);
            handler.HandlerSchedule(1, sch.Parameter);
            return "";
        }
    }
}
