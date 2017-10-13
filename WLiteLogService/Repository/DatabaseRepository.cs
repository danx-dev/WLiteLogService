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
            throw new NotImplementedException();
        }

        public List<string> GetApps()
        {
            return DatabaseHandler.Instance.GetApps(DateTime.Today.AddDays(-14));
        }
    }
}