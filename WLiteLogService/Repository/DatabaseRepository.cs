using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WLiteLog.Database;
using WLiteLogService.Models;

namespace WLiteLogService.Repository
{
    public class DatabaseRepository: IDatabaseRepository
    {
        public List<LogEntryViewModel> GetDefault()
        {
            var list = new List<LogEntryViewModel>();
            foreach (var l in DatabaseHandler.Instance.GetDefault())
            {
                var logView = new LogEntryViewModel();
                logView.Id = l.Id;
                logView.LogTime = l.LogDateTime;
                logView.Application = l.Application;
                logView.Session = l.Session;
                logView.Message = l.Message;

                list.Add(logView);
            }
            return list;
        }

        public List<string> GetApps()
        {
            return DatabaseHandler.Instance.GetApps(DateTime.Today.AddDays(-14));
        }
    }
}