using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WLiteLogService.Models
{
    public class LogEntryViewModel
    {
        public string Id { get; set; }
        public DateTime LogTime { get; set; }
        public string LogLevel { get; set; }
        public string Application { get; set; }
        public string Session { get; set; }
        public string Message { get; set; }

        public string ShortMessage => this.Message.Length > 45 ? Message.Substring(0, 45) : Message;
    }
}