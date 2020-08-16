using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Omniture.Core.Interfaces.Notification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OmnitureAPI.Controllers.Utility
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MessageController : ControllerBase
    {
        IEmailLog _email;
        public MessageController(IEmailLog email)
        {
            _email = email;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMessages(string id)
        {
            return Ok(await _email.GetMails(id));
        }
    }
}