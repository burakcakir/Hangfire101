using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangfireTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HangfireController : ControllerBase
    {
        [HttpPost]
        [Route("[action]")]
        public IActionResult Welcome()
        {
            var jobId = BackgroundJob.Enqueue(() => SendWelcomeEMail("Welcome test application"));

            return Ok($"Job Id: {jobId} Welcome mail send to the user!");
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult DbUpdate()
        {
            RecurringJob.AddOrUpdate(() => Console.WriteLine("test zamanlamalı"), Cron.Minutely);

            return Ok("test zamanlama tamam.");
        }

        public void SendWelcomeEMail(string text)
        {
            Console.WriteLine(text);
        }
    }
}
