using Omniture.Core.Interfaces.Notification;
using Omniture.Db;
using Omniture.Db.Entity.Notification;
using Omniture.NotificationService.Context;
using System;


namespace Omniture.NotificationService.Repository
{
    public class SchedulerRepository : Repository<Scheduler>, IScheduler
    {
        private IScheduleHistory _history;
        private OmnitureNotificationContext _context;
        public SchedulerRepository(OmnitureNotificationContext context, IScheduleHistory history) : base(context)
        {
            _history = history;
            _context = context;
        }

        public void CreateHitory(Scheduler sch, string response)
        {
            var scheduleHistory = new ScheduleHistory
            {
                HistoryDateTime = DateTime.Now,
                Response = response,
                ScheduleId = sch.ScheduleId
            };
            _history.Add(scheduleHistory);

            sch.State = Db.Abstractions.MaintananceState.Modified;
            sch.NextDateTime = sch.LatestNextDateTime;
            Update(sch);
            _context.SaveChangesAsync().Wait();

        }

        public void Execute()
        {
        }
    }
}
