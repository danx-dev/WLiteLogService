using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WLiteLogService.Models
{
    public class DashboardViewModel
    {
        public DashboardViewModel()
        {
            ListOfApplications = new List<BaseEntity>();
        }

        public List<LogEntryViewModel> ListOfLogEntryViewModels { get; set; }
        public List<BaseEntity> ListOfApplications { get; set; }
    }
}