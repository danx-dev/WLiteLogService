using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WLiteLog.Database
{
    public class LogEntry
    {
        public string Id { get; set; }
        public DateTime LogDateTime { get; set; }
        public string LogLevel { get; set; }
        public string Application { get; set; }
        public string Session { get; set; }
        public string Callsite { get; set; }
        public string Message { get; set; }
    }
}
