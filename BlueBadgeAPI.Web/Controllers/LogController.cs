using BlueBadgeAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlueBadgeAPI.Web.Controllers
{
    public class LogController : ApiController
    {
        private LogService CreateLogService()
        {
            var logService = new LogService();
            return logService;
        }

        public IHttpActionResult Get()
        {
            LogService logService = CreateLogService();
            var logs = logService.GetLogs();

            string newLog = "All Logs Received";
            logService.LogCreate(newLog);

            return Ok(logs);
        }
    }
}
