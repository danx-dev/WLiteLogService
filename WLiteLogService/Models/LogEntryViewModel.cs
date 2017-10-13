using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WLiteLogService.Models
{
    public class LogEntryViewModel
    {
        public long Id { get; set; }
        public DateTime LogTime { get; set; }
        public string LogLevel { get; set; }
        public string Application { get; set; }
        public string Session { get; set; }
        public string Message { get; set; }

        public string ShortMessage => Message.Substring(0, 45);
    }
}