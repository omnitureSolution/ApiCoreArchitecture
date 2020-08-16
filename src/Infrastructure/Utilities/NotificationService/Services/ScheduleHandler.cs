using Omniture.Core.Interfaces.Notification;
using Omniture.Db;
using Omniture.Db.Abstractions.Enums;
using Serilog;
using System;
using System.Linq;

namespace Omniture.NotificationService.Services
{
    public class ScheduleHandler : IScheduleHandler
    {
        private IScheduler _schedule;
        private readonly Func<CallTypes, ICallingMethod> _callingMethods;
        private readonly IUnitOfWork _unitOfWork;
        public ScheduleHandler(IScheduler schedule, Func<CallTypes, ICallingMethod> callingMethods,
            IUnitOfWork unitOfWork)
        {
            _schedule = schedule;
            _callingMethods = callingMethods;
            _unitOfWork = unitOfWork;
        }

        public void Execute()
        {
            var scheduleForProcess = _schedule.All
                                    .Where(t => t.NextDateTime
                                        <= DateTime.Now && t.IsActive)
                                    .ToList();

            Log.Information("ScheduleHandler.Execute count {@scheduleForProcess}", scheduleForProcess.Count);
            foreach (var sch in scheduleForProcess)
            {
                string response = "";
                try
                {
                    Log.Information($"ScheduleHandler.Execute type {sch.ScheduleType.ToString()}");
                    var service = _callingMethods(sch.CallTypeValue);
                    response = service.Call(sch);
                    Log.Information($"ScheduleHandler.Execute response {response}");
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "ScheduleHandler");
                }
                finally
                {
                    _schedule.CreateHitory(sch, response);
                }
            }
        }
    }
}
