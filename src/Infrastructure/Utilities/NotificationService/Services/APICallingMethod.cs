using System;
using Serilog;

using Omniture.NotificationService.Context;
using Omniture.Db.Entity.Notification;
using Omniture.Core.Interfaces.Notification;

namespace Omniture.NotificationService.Services
{
    public class APICallingMethod : ICallingMethod
    {
        OmnitureNotificationContext _visionPlusConfiguration;
        public APICallingMethod(OmnitureNotificationContext visionPlusConfiguration)
        {
            _visionPlusConfiguration = visionPlusConfiguration;
        }
        public string Call(Scheduler sch)
        {
            //temp
            return string.Empty;
            //Log.Warning($"Scheduler.APICallingMethod.Call:{sch.Action}");
            //var url = _visionPlusConfiguration.ReplaceConfiguration(sch.Action);
            //var response = HttpApiClient.Post(url, "", sch.Parameter).Result;
            //Log.Warning($"Scheduler.APICallingMethod.Call Response: {response}");
            //return response.ToString();
        }
    }
}
