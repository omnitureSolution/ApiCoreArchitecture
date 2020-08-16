using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Omniture.Core.Interfaces.Notification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocietyCareAPI.Filters;

namespace OmnitureAPI.Controllers.Utility
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SchedulerController : ControllerBase
    {
        IScheduleHandler _scheduleHandler;
        INotifier _notifier;
        INotificationQueue _queue;
        public SchedulerController(IScheduleHandler scheduleHandler, INotifier notifier, INotificationQueue queue)
        {
            _scheduleHandler = scheduleHandler;
            _notifier = notifier;
            _queue = queue;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Post()
        {
            _scheduleHandler.Execute();
            return Ok();
        }

        [HttpGet]
        [Route("send")]
        [AllowAnonymous]
        public IActionResult Send()
        {
            _notifier.SendPending();
            return Ok();
        }

        [HttpPost]
        [Route("{messageId}/SendAgain")]
        public IActionResult SendAgain([FromRoute]string messageId)
        {
            _queue.ReQueue(messageId);
            _notifier.SendPending();
            return Ok();
        }
    }
}