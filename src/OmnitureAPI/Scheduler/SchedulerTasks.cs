using FluentScheduler;
using Omniture.Core.Interfaces.Notification;
using Omniture.Core.Interfaces.Services.Account;
using Omniture.Db.Shared.Services;
using Omniture.Shared.WebClient;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;

namespace SocietyCareAPI.Scheduler
{
    public class SchedulerTasks : Registry
    {
        public SchedulerTasks(string url)
        {
            Log.Warning("Schedule started");
            Schedule(() => new SchdeuleJob().CallScheduleJob(url, "")).ToRunEvery(30).Minutes();
            Schedule(() => new SchdeuleJob().CallScheduleJob(url, "send")).ToRunEvery(2).Minutes();

            Schedule(() => new SchdeuleJob().CallScheduleJob(url, "")).ToRunNow();
        }
    }


    public class SchdeuleJob
    {
        public void CallScheduleJob(string url, string endpointName)
        {
            var result = HttpApiClient.Get($"{url}/Scheduler/{endpointName}", "");
            if (!result.IsSuccessful)
            {
                Log.Error($"{result.StatusDescription} - {result.ErrorException}", $"CallScheduleJob:{url}");
            }
        }
    }
}
