using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WLiteLog.Database;

namespace WLiteLogService.Controllers
{
    public class Log
    {
        public DateTime LogTime { get; set; }
        public string LogLevel { get; set; }
        public string Application { get; set; }
        public string Session { get; set; }
        public string CallSite { get; set; }
        public string Message { get; set; }
    }

    public class LogController : ApiController
    {
        public void Log(Log log)
        {
            var logEntry = new LogEntry
            {
                Id = Guid.NewGuid().ToString(),
                LogLevel = log.LogLevel,
                Application = log.Application,
                Session = log.Session,
                Callsite = log.CallSite,
                LogDateTime = log.LogTime,
                Message = log.Message
                
            };
            DatabaseHandler.Instance.AddLog(logEntry);
        }
    }
}
