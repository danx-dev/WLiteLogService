using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WLiteLogService.Models;
using WLiteLogService.Repository;

namespace WLiteLogService.Controllers
{
    public class DashboardController : Controller
    {
        private IDatabaseRepository _databaseRepository = new DatabaseRepository();

        // GET: Dashboard
        public ActionResult Index()
        {
            var model = new DashboardViewModel();
            model.ListOfLogEntryViewModels = new List<LogEntryViewModel>();
            model.ListOfLogEntryViewModels.Add(new LogEntryViewModel{LogTime = DateTime.Now, Application = "Application1", Message = "Message dfsfsd fsd fds fs fds f dsf sdf ds fds fdsfdsfdsfsdfdsfsdfsdfdsfdsfs", Session = "Session1", LogLevel = "Message"});
            model.ListOfLogEntryViewModels.Add(new LogEntryViewModel { LogTime = DateTime.Now, Application = "Application2", Message = "Message dfsfsd fsd fds fs fds f dsf sdf ds fds fdsfdsfdsfsdfdsfsdfsdfdsfdsfs", Session = "Session2" , LogLevel = "danger"});
            foreach (var app in _databaseRepository.GetApps())
            {
                model.ListOfApplications.Add(new BaseEntity{ Name = app});
            }
            return View(model);
        }
    }
}